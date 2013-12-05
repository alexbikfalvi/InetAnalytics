/* 
 * Copyright (C) 2013 Alex Bikfalvi
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or (at
 * your option) any later version.
 *
 * This program is distributed in the hope that it will be useful, but
 * WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301, USA.
 */

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using DotNetApi;
using DotNetApi.Web;
using DotNetApi.Web.XmlRpc;
using InetCrawler.PlanetLab;
using PlanetLab;
using PlanetLab.Api;
using PlanetLab.Requests;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace InetCrawler.PlanetLab
{
	/// <summary>
	/// A class that manages the execution of commands on a set of PlanetLab nodes.
	/// </summary>
	public sealed class PlManager
	{
		private readonly Crawler crawler;

		private readonly PlRequest requestGetNodes = new PlRequest(PlRequest.RequestMethod.GetNodes);

		/// <summary>
		/// Createa a new PlanetLab manager.
		/// </summary>
		/// <param name="crawler">The crawler.</param>
		public PlManager(Crawler crawler)
		{
			// Validate the arguments.
			if (null == crawler) throw new ArgumentNullException("crawler");
			
			// Set the crawler.
			this.crawler = crawler;
		}

		// Public events.

		/// <summary>
		/// An event raised when the manager is starting.
		/// </summary>
		public event PlManagerEventHandler Starting;
		/// <summary>
		/// An event raised when the manager has started.
		/// </summary>
		public event PlManagerEventHandler Started;
		/// <summary>
		/// An event raised when the manager is pausing.
		/// </summary>
		public event PlManagerEventHandler Pausing;
		/// <summary>
		/// An event raised when the manager has paused.
		/// </summary>
		public event PlManagerEventHandler Paused;
		/// <summary>
		/// An event raised when the manager is resuming.
		/// </summary>
		public event PlManagerEventHandler Resuming;
		/// <summary>
		/// An event raised when the manager has resumed.
		/// </summary>
		public event PlManagerEventHandler Resumed;
		/// <summary>
		/// An event raised when the manager is stopping.
		/// </summary>
		public event PlManagerEventHandler Stopping;
		/// <summary>
		/// An event raised when the manager has stopped.
		/// </summary>
		public event PlManagerEventHandler Stopped;
		/// <summary>
		/// An event raised when started updating the PlanetLab nodes information.
		/// </summary>
		public event PlManagerEventHandler NodesUpdateStarted;
		/// <summary>
		/// An event raised when finished updating the PlanetLab nodes information, and the update succeeded.
		/// </summary>
		public event PlManagerEventHandler NodesUpdateFinishedSuccess;
		/// <summary>
		/// An event raised when finished updating the PlanetLab nodes information, and the update failed.
		/// </summary>
		public event PlManagerEventHandler NodesUpdateFinishedFail;
		/// <summary>
		/// An event raised when canceled updating the PlanetLab nodes information.
		/// </summary>
		public event PlManagerEventHandler NodesUpdateCanceled;
		/// <summary>
		/// An event raised when indicating whether a node is enabled to execute commands.
		/// </summary>
		public event PlManagerNodeEventHandler NodeEnabled;
		/// <summary>
		/// An event raised when indicating whether a node is disabled to execute commands.
		/// </summary>
		public event PlManagerNodeEventHandler NodeDisabled;

		// Public methods.

		/// <summary>
		/// Starts the execution of the PlanetLab commands on the specified list of PlanetLab nodes.
		/// </summary>
		/// <param name="crawler">The crawler.</param>
		/// <param name="slice">The slice configuration.</param>
		/// <param name="nodes">The PlanetLab nodes.</param>
		/// <returns>The manager state.</returns>
		public PlManagerState Start(PlConfigSlice slice, ICollection<PlNode> nodes)
		{
			// Create a new manager state.
			PlManagerState state = new PlManagerState(slice, nodes);

			lock (state.Sync)
			{
				// Update the manager status.
				state.Status = PlManagerState.ExecutionStatus.Starting;

				// Call the starting event handler.
				if (null != this.Starting) this.Starting(this, new PlManagerEventArgs(state));

				// Update the manager status.
				state.Status = PlManagerState.ExecutionStatus.Started;

				// Call the started event handler.
				if (null != this.Started) this.Started(this, new PlManagerEventArgs(state));
			}

			// Check the slice configuration.
			if (slice.UpdateNodesBeforeRun)
			{
				// Update the nodes information.
				this.OnUpdateNodes(state);
			}
			else
			{
				// Execute the commands.
				this.OnExecuteCommands(state);
			}

			// Return the manager state.
			return state;
		}

		public void Pause(PlManagerState state)
		{
			lock (state.Sync)
			{
				// Check the status.
				if (state.Status != PlManagerState.ExecutionStatus.Started) throw new CrawlerException("Cannot pause the PlanetLab manager because it is not in the running state.");

				// Else, change the status.
				state.Status = PlManagerState.ExecutionStatus.Pausing;

				// Raise the event.
				if (null != this.Pausing) this.Pausing(this, new PlManagerEventArgs(state));

				// Try pause.
				this.TryPause(state, () =>
					{
						lock (state.Sync)
						{
							// Else, change the status.
							state.Status = PlManagerState.ExecutionStatus.Paused;

							// Raise the event.
							if (null != this.Paused) this.Paused(this, new PlManagerEventArgs(state));
						}
					});
			}
		}

		public void Resume(PlManagerState state)
		{
			lock (state.Sync)
			{
				// Check the status.
				if (state.Status != PlManagerState.ExecutionStatus.Paused) throw new CrawlerException("Cannot resume the PlanetLab manager because it is not in the paused state.");

				// Else, change the status.
				state.Status = PlManagerState.ExecutionStatus.Resuming;

				// Raise the event.
				if (null != this.Resuming) this.Resuming(this, new PlManagerEventArgs(state));

				// Try resume.
				this.TryResume(state, () =>
					{
						lock (state.Sync)
						{
							// Else, change the status.
							state.Status = PlManagerState.ExecutionStatus.Started;

							// Raise the event.
							if (null != this.Resumed) this.Resumed(this, new PlManagerEventArgs(state));
						}
					});
			}
		}

		public void Stop(PlManagerState state)
		{
			lock (state.Sync)
			{
				// Check the status.
				if ((state.Status != PlManagerState.ExecutionStatus.Paused) && (state.Status != PlManagerState.ExecutionStatus.Started))
					throw new CrawlerException("Cannot resume the PlanetLab manager because it is not in the running or paused state.");

				// Else, change the status.
				state.Status = PlManagerState.ExecutionStatus.Stopping;

				// Raise the event.
				if (null != this.Stopping) this.Stopping(this, new PlManagerEventArgs(state));

				// Try stop.
				this.TryStop(state, () =>
					{
						lock (state.Sync)
						{
							// Else, change the status.
							state.Status = PlManagerState.ExecutionStatus.Stopped;

							// Raise the event.
							if (null != this.Stopped) this.Stopped(this, new PlManagerEventArgs(state));
						}
					});
			}
		}

		// Private methods.

		private void TryPause(PlManagerState state, Action action)
		{
			// Reset the pause wait handle.
			state.PauseWait.Reset();
			lock (state.Sync)
			{
				// Set the paused state to true.
				state.IsPaused = true;
			}
			// Execute the action.
			action();
		}

		private void TryResume(PlManagerState state, Action action)
		{
			lock (state.Sync)
			{
				// Set the paused state to false.
				state.IsPaused = false;
			}
			// Signal the pause wait handle.
			state.PauseWait.Set();
			// Execute the action.
			action();
		}

		private void TryStop(PlManagerState state, Action action)
		{
			// Execute on the thread pool.
			ThreadPool.QueueUserWorkItem((object threadState) =>
				{
					// A copy of the current pending nodes.
					PlManagerNodeState[] pendingNodes;

					lock (state.Sync)
					{
						// Set the state to cancel.
						state.IsCanceled = true;

						// If there is a PlanetLab request in progress.
						if (state.PlanetLabAsyncResult != null)
						{
							// Cancel the request.
							this.requestGetNodes.Cancel(state.PlanetLabAsyncResult);
							// Wait for the request to complete.
							state.PlanetLabAsyncResult.AsyncWaitHandle.WaitOne();
						}

						// Create a copy of current pending nodes.
						pendingNodes = new PlManagerNodeState[state.PendingNodes.Count];
						state.PendingNodes.CopyTo(pendingNodes);
					}

					// For all the pending nodes.
					foreach (PlManagerNodeState nodeState in pendingNodes)
					{
						lock (nodeState.Sync)
						{
							// If the node is not running, skip to the next node.
							if (nodeState.State != PlManagerNodeState.NodeState.Running) continue;
						}
						// Otherwise, wait for the node to complete.
						nodeState.Wait.WaitOne();
					}

					lock (state.Sync)
					{
						// Dispose the node states.
						foreach (PlManagerNodeState nodeState in state.PendingNodes)
						{
							nodeState.Dispose();
						}
					}

					// Execute the action.
					action();
				});
		}

		/// <summary>
		/// Updates the information on the PlanetLab nodes.
		/// </summary>
		/// <param name="state">The manager state.</param>
		private void OnUpdateNodes(PlManagerState state)
		{
			lock (state.Sync)
			{
				// Create the list of PlanetLab nodes.
				List<int> nodes = new List<int>();
				foreach (PlNode node in state.Nodes)
				{
					nodes.Add(node.Id.Value);
				}

				// Raise an event.
				if (null != this.NodesUpdateStarted) this.NodesUpdateStarted(this, new PlManagerEventArgs(state));

				// Begin an asynchronous request for the PlanetLab nodes information.
				state.PlanetLabAsyncResult = this.requestGetNodes.Begin(
					this.crawler.PlanetLab.Username,
					this.crawler.PlanetLab.Password,
					PlNode.GetFilter(PlNode.Fields.NodeId, nodes.ToArray()),
					(AsyncWebResult result) =>
					{
						bool success = false;

						try
						{
							// The asynchronous result.
							AsyncWebResult asyncResult;
							// Complete the asyncrhonous request.
							XmlRpcResponse response = this.requestGetNodes.End(result, out asyncResult);

							// If no fault occurred during the XML-RPC request.
							if (response.Fault == null)
							{
								// Get the response array.
								XmlRpcArray array = response.Value as XmlRpcArray;

								// If the array object is not null.
								if (array != null)
								{
									// For each value in the response array.
									foreach (XmlRpcValue value in array.Values)
									{
										// The PlanetLab node.
										PlNode node = null;

										// Try parse the structure to a PlanetLab node and add it to the nodes list.
										try { node = this.crawler.PlanetLab.Nodes.Add(value.Value as XmlRpcStruct); }
										catch { }
									}

									// Raise an event.
									if (null != this.NodesUpdateFinishedSuccess) this.NodesUpdateFinishedSuccess(this, new PlManagerEventArgs(state));

									// Set the success flag to true.
									success = true;
								}
								else
								{
									// Raise an event.
									if (null != this.NodesUpdateFinishedFail) this.NodesUpdateFinishedFail(this, new PlManagerEventArgs(state, "The received response did not contain any PlanetLab node data."));
								}
							}
							else
							{
								// Raise an event.
								if (null != this.NodesUpdateFinishedFail) this.NodesUpdateFinishedFail(this, new PlManagerEventArgs(state, "{0} (code {1})".FormatWith(response.Fault.FaultString, response.Fault.FaultCode)));
							}
						}
						catch (WebException exception)
						{
							// If the exception status is canceled.
							if (exception.Status == WebExceptionStatus.RequestCanceled)
							{
								// Raise an event.
								if (null != this.NodesUpdateCanceled) this.NodesUpdateCanceled(this, new PlManagerEventArgs(state));
							}
							else
							{
								// Raise an event.
								if (null != this.NodesUpdateFinishedFail) this.NodesUpdateFinishedFail(this, new PlManagerEventArgs(state, exception));
							}
						}
						catch (Exception exception)
						{
							// Raise an event.
							if (null != this.NodesUpdateFinishedFail) this.NodesUpdateFinishedFail(this, new PlManagerEventArgs(state, exception));
						}
						finally
						{
							lock (state.Sync)
							{
								// Set the PlanetLab asynchronous result to null.
								state.PlanetLabAsyncResult = null;
							}

							// If the operation was successful.
							if (success)
							{
								// Execute the commands.
								this.OnExecuteCommands(state);
							}
							else
							{
								// Stop the manager.
								this.Stop(state);
							}
						}
					});
			}
		}

		/// <summary>
		/// Executes the commands on the PlanetLab nodes.
		/// </summary>
		/// <param name="state">The manager state.</param>
		private void OnExecuteCommands(PlManagerState state)
		{
			lock (state.Sync)
			{
				// If the command has been canceled, return.
				if (state.IsCanceled) return;

				// Compute the number of commands to execute.
				int commandCount = 0;
				foreach (PlCommand command in state.Slice.Commands)
				{
					commandCount += command.SetsCount;
				}

				// Create a list of the pending nodes.
				foreach (PlNode node in state.Nodes)
				{
					// If using only the nodes in the boot state, and the node is not in the boot state.
					if (state.Slice.OnlyRunOnBootNodes && (node.GetBootState() != PlBootState.Boot))
					{
						// Raise a node disabled event.
						if (null != this.NodeDisabled) this.NodeDisabled(this, new PlManagerNodeEventArgs(state, node));
						// Skip processing this node.
						continue;
					}
					
					// Raise a node enabled event.
					if (null != this.NodeEnabled) this.NodeEnabled(this, new PlManagerNodeEventArgs(state, node, commandCount));
					
					// Create a new node state information for this node.
					PlManagerNodeState nodeState = new PlManagerNodeState(node);

					// Add the node state to the list of pending nodes.
					state.PendingNodes.Add(nodeState);
				}

				// Begin run the commands on the pending nodes.
				for (int index = 0; (index < state.Slice.RunParallelNodes) && (index < state.PendingNodes.Count); index++)
				{
					// Execute the command on the specified node.
					this.OnExecuteCommandsNode(state, index);
				}
			}
		}

		/// <summary>
		/// Executes the commands on the PlanetLab node at the specified index.
		/// </summary>
		/// <param name="state">The state.</param>
		/// <param name="index">The node state index.</param>
		private void OnExecuteCommandsNode(PlManagerState state, int index)
		{
			lock (state.Sync)
			{
				// If the operation has been canceled, return.
				if (state.IsCanceled) return;

				// Get the node state.
				PlManagerNodeState nodeState = state.PendingNodes[index];
				
				// Execute the secure shell connection on the thread pool.
				ThreadPool.QueueUserWorkItem((object threadState) =>
					{
						lock (nodeState.Sync)
						{
							// If the operation has been canceled, return.
							if (state.IsCanceled) return;
							// Else, set the state to running.
							nodeState.State = PlManagerNodeState.NodeState.Running;
						}

						try
						{
							// Execute the node.
						}
						finally
						{
							// Set the state to completed.
							lock (nodeState.Sync)
							{
								nodeState.State = PlManagerNodeState.NodeState.Completed;
							}
							// Signal the wait handle.
							nodeState.Wait.Set();
						}
					});
			}
		}
	}
}
