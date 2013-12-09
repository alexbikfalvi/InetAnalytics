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
using System.IO;
using System.Linq;
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
		private static readonly string[] subcommandSeparators = { "\n", "\r\n" };

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
		/// An event raised when a node is enabled to execute commands.
		/// </summary>
		public event PlManagerNodeEventHandler NodeEnabled;
		/// <summary>
		/// An event raised when a node is disabled to execute commands.
		/// </summary>
		public event PlManagerNodeEventHandler NodeDisabled;
		/// <summary>
		/// An event raised when a node has been skipped to execute commands.
		/// </summary>
		public event PlManagerNodeEventHandler NodeSkipped;
		/// <summary>
		/// An event raised when a node started running commands.
		/// </summary>
		public event PlManagerNodeEventHandler NodeStarted;
		/// <summary>
		/// An event raised when a node was canceled in running commands.
		/// </summary>
		public event PlManagerNodeEventHandler NodeCanceled;
		/// <summary>
		/// An event raised when a node finished running the commands with success.
		/// </summary>
		public event PlManagerNodeEventHandler NodeFinishedSuccess;
		/// <summary>
		/// An event raised when a node finished running the commands with failure.
		/// </summary>
		public event PlManagerNodeEventHandler NodeFinishedFail;
		/// <summary>
		/// An event raised when a command was started on a PlanetLab node.
		/// </summary>
		public event PlManagerCommandEventHandler CommandStarted;
		/// <summary>
		/// An event raised when a command completed with success on a PlanetLab node.
		/// </summary>
		public event PlManagerCommandEventHandler CommandFinishedSuccess;
		/// <summary>
		/// An event raised when a command completed with failure on a PlanetLab node.
		/// </summary>
		public event PlManagerCommandEventHandler CommandFinishedFail;
		/// <summary>
		/// An event raised when a command was canceled.
		/// </summary>
		public event PlManagerCommandEventHandler CommandCanceled;
		/// <summary>
		/// An event raised when a PlanetLab subcommand finished with success.
		/// </summary>
		public event PlManagerSubcommandEventHandler SubcommandSuccess;
		/// <summary>
		/// An event raised when a PlanetLab subcommad finished with failure.
		/// </summary>
		public event PlManagerSubcommandEventHandler SubcommandFail;

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
				this.OnRunNodes(state);
			}

			// Return the manager state.
			return state;
		}

		/// <summary>
		/// Pauses the execution of the PlanetLab commands.
		/// </summary>
		/// <param name="state">The manager state.</param>
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

		/// <summary>
		/// Resumes the execution of PlanetLab commands.
		/// </summary>
		/// <param name="state">The manager state.</param>
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

		/// <summary>
		/// Stops the execution of PlanetLab commands.
		/// </summary>
		/// <param name="state">The manager state.</param>
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

		/// <summary>
		/// Tries to pause the execution of PlanetLab commands.
		/// </summary>
		/// <param name="state">The manager state.</param>
		/// <param name="action">The action to take after the execution was paused.</param>
		private void TryPause(PlManagerState state, Action action)
		{
			// Pause the execution through the manager state.
			state.Pause();
			// Execute the action.
			action();
		}

		/// <summary>
		/// Tries to resume the execution of PlanetLab commands.
		/// </summary>
		/// <param name="state">The manager state/</param>
		/// <param name="action">The action to take after the execution was resumed.</param>
		private void TryResume(PlManagerState state, Action action)
		{
			// Resume the execution through the manager state.
			state.Resume();
			// Execute the action.
			action();
		}

		/// <summary>
		/// Tries to stop the execution of PlanetLab commands.
		/// </summary>
		/// <param name="state">The manager state.</param>
		/// <param name="action">The action to take after execution was stopped.</param>
		private void TryStop(PlManagerState state, Action action)
		{
			// Execute on the thread pool.
			ThreadPool.QueueUserWorkItem((object threadState) =>
				{
					// Stop the manager execution.
					state.Stop();

					// Wait for the manager execution to complete.
					state.WaitStop();

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

				// The asynchronous operation.
				AsyncWebOperation asyncOperation = new AsyncWebOperation();

				// Begin an asynchronous request for the PlanetLab nodes information.
				asyncOperation = state.BeginAsyncOperation(this.requestGetNodes, this.requestGetNodes.Begin(
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
							// End the asynchronous operation.
							state.EndAsyncOperation(asyncOperation);

							// If the operation was successful.
							if (success)
							{
								// Execute the commands.
								this.OnRunNodes(state);
							}
							else
							{
								// Stop the manager.
								this.Stop(state);
							}
						}
					}));
			}
		}

		/// <summary>
		/// Runs the commands on the PlanetLab nodes.
		/// </summary>
		/// <param name="state">The manager state.</param>
		private void OnRunNodes(PlManagerState state)
		{
			lock (state.Sync)
			{
				// If the command has been stopped, return.
				if (state.IsStopped) return;

				// Compute the number of commands to execute.
				int commandCount = 0;
				foreach (PlCommand command in state.Slice.Commands)
				{
					commandCount += command.HasParameters ? command.SetsCount : 1;
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
					
					// Add the node to the list of pending nodes.
					state.AddNode(node);
				}
			}

			// Compute the availability of worker threads for parallel processing.
			int availableWorkerThreads;
			int availableCompletionPortThreads;
			int maxWorkerThreads;
			int maxCompletionPortThreads;
			int maxParallel = Math.Max(state.Slice.RunParallelNodes, state.PendingCount);

			// Get the number of threads available on the thread pool.
			ThreadPool.GetAvailableThreads(out availableWorkerThreads, out availableCompletionPortThreads);
			// Get the maximum number of threads on the thread pool.
			ThreadPool.GetMaxThreads(out maxWorkerThreads, out maxCompletionPortThreads);

			// If the number of available worker threads is smaller than the number of parallel nodes.
			if (availableWorkerThreads < maxParallel)
			{
				// Increment the number of maximum threads.
				ThreadPool.SetMaxThreads(
					maxWorkerThreads + maxParallel - availableWorkerThreads,
					maxCompletionPortThreads
					);
			}

			lock (state.Sync)
			{
				// If the list of pending nodes is empty, stop.
				if (0 == state.PendingCount)
				{
					this.Stop(state);
				}

				// Get a cached copy of all the pending PlanetLab nodes.
				int[] pendingCache = state.PendingNodes.ToArray();

				// For all the pending nodes.
				for (int index = 0; (index < pendingCache.Length) && (state.RunningCount < state.Slice.RunParallelNodes); index++)
				{
					// Get the node state corresponding to the pending node.
					PlManagerNodeState nodeState = state.GetNode(pendingCache[index]);

					// If the slice configuration only allows one node per site.
					if (state.Slice.OnlyRunOneNodePerSite)
					{
						// If the node site is completed.
						if (state.IsSiteCompleted(nodeState.Node.SiteId.Value))
						{
							// Change the node from the pending to the skipped state.
							state.UpdateNodePendingToSkipped(index);
							// Raise an event indicating that the node has been skipped.
							if (null != this.NodeSkipped) this.NodeSkipped(this, new PlManagerNodeEventArgs(state, nodeState.Node));
							// Skip the loop to the next node.
							continue;
						}
						// If the node site is running.
						if (state.IsSiteRunning(nodeState.Node.SiteId.Value))
						{
							// Postpone the node for later, and skip the loop to the next node.
							continue;
						}
					}

					// Change the node from the pending to the running state.
					state.UpdateNodePendingToRunning(index);

					// Execute the commands on specified node.
					this.OnRunNode(state, index);
				}
			}
		}

		/// <summary>
		/// Runs the commands on the PlanetLab node at the specified index.
		/// </summary>
		/// <param name="state">The state.</param>
		/// <param name="index">The node state index.</param>
		private void OnRunNode(PlManagerState state, int index)
		{
			lock (state.Sync)
			{
				// If the operation has been canceled, return.
				if (state.IsStopped) return;

				// Get the node state.
				PlManagerNodeState nodeState = state.GetNode(index);
				
				// Execute the secure shell connection on the thread pool.
				ThreadPool.QueueUserWorkItem((object threadState) =>
					{
						// Raise a node started event.
						if (null != this.NodeStarted) this.NodeStarted(this, new PlManagerNodeEventArgs(state, nodeState.Node));

						try
						{
							// Create the private key connection information.
							ConnectionInfo connectionInfo;
							// Create a memory stream with the key data.
							using (MemoryStream memoryStream = new MemoryStream(state.Slice.Key))
							{
								// Create the private key file.
								using (PrivateKeyFile keyFile = new PrivateKeyFile(memoryStream))
								{
									// Create a key connection info.
									connectionInfo = new PrivateKeyConnectionInfo(nodeState.Node.Hostname, state.Slice.Name, keyFile);
								}
							}							

							// Open an SSH client to the PlanetLab node.
							using (SshClient sshClient = new SshClient(connectionInfo))
							{
								// Connect the client.
								sshClient.Connect();

								// For all the slice commands.
								foreach (PlCommand command in state.Slice.Commands)
								{
									// If the command has parameters.
									if (command.HasParameters)
									{
										// Format the command with all parameter sets.
										for (int indexSet = 0; indexSet < command.SetsCount; indexSet++)
										{
											// If the operation has been paused, wait for resume.
											if (state.IsPaused)
											{
												state.WaitPause();
											}

											// If the operation has been canceled, return.
											if (state.IsStopped)
											{
												// Remove the node from the running list.
												state.UpdateNodeRunningToSkipped(index);
												// Cancel all nodes in the pending list.
												state.CancelPendingNodes();
												// Raise the canceled event.
												if (null != this.NodeCanceled) this.NodeCanceled(this, new PlManagerNodeEventArgs(state, nodeState.Node));
												// Return.
												return;
											}

											// Run the command with the current parameters set.
											this.OnRunCommand(state, nodeState, command, indexSet, sshClient);
										}
									}
									else
									{
										// Run the command without parameters.
										this.OnRunCommand(state, nodeState, command, -1, sshClient);
									}
								}

								// Disconnect the client.
								sshClient.Disconnect();
							}

							// Remove the node from the running list.
							state.UpdateNodeRunningToCompleted(index);

							// Raise the success event.
							if (null != this.NodeFinishedSuccess) this.NodeFinishedSuccess(this, new PlManagerNodeEventArgs(state, nodeState.Node));
						}
						catch (Exception exception)
						{
							// Remove the node from the running list.
							state.UpdateNodeRunningToSkipped(index);

							// Raise the fail event.
							if (null != this.NodeFinishedFail) this.NodeFinishedFail(this, new PlManagerNodeEventArgs(state, nodeState.Node, exception));
						}
						finally
						{
							lock (state.Sync)
							{
								// If the operation has not been canceled.
								if (!state.IsStopped)
								{

									// If the list of pending nodes is empty, stop.
									if (0 == state.PendingCount)
									{
										this.Stop(state);
									}

									// Get a cached copy of all the pending PlanetLab nodes.
									int[] pendingCache = state.PendingNodes.ToArray();

									// Find the next pending node to execute commands.
									foreach (int newIndex in pendingCache)
									{
										// Get the node state corresponding to the pending node.
										PlManagerNodeState newNode = state.GetNode(newIndex);

										// If the slice configuration only allows one node per site.
										if (state.Slice.OnlyRunOneNodePerSite)
										{
											// If the node site is completed.
											if (state.IsSiteCompleted(newNode.Node.SiteId.Value))
											{
												// Change the node from the pending to the skipped state.
												state.UpdateNodePendingToSkipped(newIndex);
												// Raise an event indicating that the node has been skipped.
												if (null != this.NodeSkipped) this.NodeSkipped(this, new PlManagerNodeEventArgs(state, newNode.Node));
												// Skip the loop to the next node.
												continue;
											}
											// If the node site is running.
											if (state.IsSiteRunning(newNode.Node.SiteId.Value))
											{
												// Postpone the node for later, and skip the loop to the next node.
												continue;
											}
										}

										// Change the node from the pending to the running state.
										state.UpdateNodePendingToRunning(newIndex);

										// Execute the commands on specified node.
										this.OnRunNode(state, newIndex);

										// Exit the loop.
										break;
									}
								}
							}
						}
					});
			}
		}

		/// <summary>
		/// Runs a command on the specified PlanetLab node.
		/// </summary>
		/// <param name="state">The manager state.</param>
		/// <param name="node">The PlanetLab node state.</param>
		/// <param name="command">The PlanetLab command.</param>
		/// <param name="set">The command parameter set.</param>
		/// <param name="sshClient">The SSH client.</param>
		private void OnRunCommand(PlManagerState state, PlManagerNodeState node, PlCommand command, int set, SshClient sshClient)
		{
			// Raise the command started event.
			if (null != this.CommandStarted) this.CommandStarted(this, new PlManagerCommandEventArgs(state, node.Node, command, set));
			try
			{
				// Compute the command text.
				string commandText = set >= 0 ? command.GetCommand(set) : command.Command;

				// The number of subcommands.
				int success = 0;
				int fail = 0;

				// Divide the command into subcommands.
				string[] subcommands = commandText.Split(PlManager.subcommandSeparators, StringSplitOptions.RemoveEmptyEntries);

				// For all subcommands.
				foreach (string subcommand in subcommands)
				{
					// If the operation has been paused, wait for resume.
					if (state.IsPaused)
					{
						state.WaitPause();
					}
					// If the operation has been canceled, return.
					if (state.IsStopped)
					{
						// Raise the canceled event.
						if (null != this.CommandCanceled) this.CommandCanceled(this, new PlManagerCommandEventArgs(state, node.Node, command, set));
						// Return.
						return;
					}

					// If the subcommand is empty, continue to the next subcommand.
					if (string.IsNullOrWhiteSpace(subcommand)) continue;

					// Create a new SSH command.
					using (SshCommand sshCommand = sshClient.CreateCommand(subcommand))
					{
						try
						{
							// The command duration.
							TimeSpan duration;
							// The retry count.
							int retry = 0;

							do
							{
								// The start time.
								DateTime startTime = DateTime.Now;

								// Execute the command.
								sshCommand.Execute();

								// Compute the command duration.
								duration = DateTime.Now - startTime;
							}
							while ((retry++ < state.Slice.CommandRetries) && (sshCommand.ExitStatus != 0));

							// Create a new command state.
							PlManagerSubcommandState subcommandState = new PlManagerSubcommandState(sshCommand, duration, retry - 1);

							// Increment the number of successful subcommands.
							success++;

							// Add the subcommand.
							node.AddSubcommand(subcommandState);

							// Raise a subcommand success event.
							if (null != this.SubcommandSuccess) this.SubcommandSuccess(this, new PlManagerSubcommandEventArgs(state, node.Node, command, set, subcommandState));
						}
						catch (Exception exception)
						{
							// Create a new subcommand state.
							PlManagerSubcommandState subcommandState = new PlManagerSubcommandState(sshCommand, exception);

							// Increment the number of failed subcommands.
							fail++;

							// Add the subcommand.
							node.AddSubcommand(subcommandState);

							// Raise a subcommand fail event.
							if (null != this.SubcommandFail) this.SubcommandFail(this, new PlManagerSubcommandEventArgs(state, node.Node, command, set, exception));
						}
					}
				}

				// Raise a command completed event.
				if (null != this.CommandFinishedSuccess) this.CommandFinishedSuccess(this, new PlManagerCommandEventArgs(state, node.Node, command, set, success, fail));
			}
			catch (Exception exception)
			{
				// Raise a command completed event.
				if (null != this.CommandFinishedFail) this.CommandFinishedFail(this, new PlManagerCommandEventArgs(state, node.Node, command, set, exception));
			}
		}
	}
}
