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
using System.Linq;
using System.Threading;
using DotNetApi.Web;
using PlanetLab.Api;

namespace InetCrawler.PlanetLab
{
	/// <summary>
	/// A class representing the state for the execution of commands on PlanetLab nodes.
	/// </summary>
	public sealed class PlManagerState : IDisposable
	{
		/// <summary>
		/// An enumeration representing the execution status.
		/// </summary>
		public enum ExecutionStatus
		{
			Stopped = 0,
			Starting = 1,
			Started = 2,
			Pausing = 3,
			Paused = 4,
			Resuming = 5,
			Stopping = 6
		}

		private readonly PlConfigSlice slice;
		private readonly ICollection<PlNode> nodes;

		private readonly object sync = new object();

		private volatile ExecutionStatus status = ExecutionStatus.Stopped;

		private volatile bool isPaused = false;
		private volatile bool isStopped = false;

		private readonly ManualResetEvent waitPause = new ManualResetEvent(true);
		private readonly ManualResetEvent waitAsync = new ManualResetEvent(true);
		private readonly ManualResetEvent waitNodes = new ManualResetEvent(true);

		private readonly HashSet<AsyncWebOperation> asyncOperations = new HashSet<AsyncWebOperation>();

		private readonly List<PlManagerNodeState> nodeStates = new List<PlManagerNodeState>();

		private readonly HashSet<int> pendingNodes = new HashSet<int>();
		private readonly HashSet<int> runningNodes = new HashSet<int>();
		private readonly HashSet<int> completedNodes = new HashSet<int>();
		private readonly HashSet<int> skippedNodes = new HashSet<int>();

		private readonly HashSet<int> runningSites = new HashSet<int>();
		private readonly HashSet<int> completedSites = new HashSet<int>();

		/// <summary>
		/// Creates a new manager state for the specified slice.
		/// </summary>
		/// <param name="slice">The slice configuration.</param>
		/// <param name="nodes">The list of PlanetLab nodes.</param>
		public PlManagerState(PlConfigSlice slice, ICollection<PlNode> nodes)
		{
			// Validate the arguments.
			if (null == slice) throw new ArgumentNullException("slice");
			if (null == nodes) throw new ArgumentNullException("nodes");

			// Set the parameters.
			this.slice = slice;
			this.nodes = nodes;
		}

		// Public properties.

		/// <summary>
		/// Gets the synchronization object for this manager state.
		/// </summary>
		public object Sync
		{
			get { return this.sync; }
		}
		/// <summary>
		/// Gets the slice configuration.
		/// </summary>
		public PlConfigSlice Slice
		{
			get { return this.slice; }
		}
		/// <summary>
		/// Gets the current execution status.
		/// </summary>
		public ExecutionStatus Status
		{
			get { return this.status; }
			internal set { this.status = value; }
		}
		/// <summary>
		/// Gets the collection of nodes.
		/// </summary>
		public ICollection<PlNode> Nodes
		{
			get { return this.nodes; }
		}
		/// <summary>
		/// Gets the collection of node states.
		/// </summary>
		public IEnumerable<PlManagerNodeState> NodeStates
		{
			get { return this.nodeStates; }
		}
		/// <summary>
		/// Gets the start time.
		/// </summary>
		public DateTime StartTime { get; internal set; }
		/// <summary>
		/// Gets the finish time.
		/// </summary>
		public DateTime FinishTime { get; internal set; }

		// Internal properties.

		/// <summary>
		/// Gets whether the manager is paused. It is a thread-safe property and it does not require a lock.
		/// </summary>
		internal bool IsPaused
		{
			get { return this.isPaused; }
		}
		/// <summary>
		/// Gets whether the manager is stopped. It is a thread-safe property and it does not require a lock.
		/// </summary>
		internal bool IsStopped
		{
			get { return this.isStopped; }
		}
		/// <summary>
		/// Gets the number of pending PlanetLab nodes.
		/// </summary>
		internal int PendingCount
		{
			get { lock (this.sync) { return this.pendingNodes.Count; } }
		}
		/// <summary>
		/// Gets the number of running PlanetLab nodes.
		/// </summary>
		internal int RunningCount
		{
			get { lock (this.sync) { return this.runningNodes.Count; } }
		}
		/// <summary>
		/// Gets the number of completed PlanetLab nodes.
		/// </summary>
		internal int CompletedCount
		{
			get { lock (this.sync) { return this.completedNodes.Count; } }
		}
		/// <summary>
		/// Gets the number of skipped PlanetLab nodes.
		/// </summary>
		internal int SkippedCount
		{
			get { lock (this.sync) { return this.skippedNodes.Count; } }
		}
		/// <summary>
		/// Gets the list of pending nodes.
		/// </summary>
		internal IEnumerable<int> PendingNodes
		{
			get { return this.pendingNodes; }
		}

		// Public methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Close the wait handles.
			this.waitPause.Close();
			this.waitAsync.Close();
			this.waitNodes.Close();
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		// Internal methods.

		/// <summary>
		/// Pauses the execution of the PlanetLab manager by resetting the pause wait handle and
		/// setting the pause flag to true.
		/// </summary>
		internal void Pause()
		{
			// Reset the pause wait handle to unsignaled state.
			this.waitPause.Reset();
			// Set the pause flag to true.
			lock (this.sync)
			{
				this.isPaused = true;
			}
		}

		/// <summary>
		/// Resumes the execution of the PlanetLab manager by setting the pause wait handle to
		/// the signaled state and the pause flag to false.
		/// </summary>
		internal void Resume()
		{
			// Set the pause flag to false.
			lock (this.sync)
			{
				this.isPaused = false;
			}
			// Set the pause wait handle to the signaled state.
			this.waitPause.Set();
		}

		/// <summary>
		/// Stops the execution of the PlanetLab manager by cancelling all asynchronous operations,
		/// setting the stop flag to true, the pause  flag to false, and setting the pause wait handle
		/// to a signaled state.
		/// </summary>
		internal void Stop()
		{
			lock (this.sync)
			{
				// Cancel all asynchronous operations.
				foreach (AsyncWebOperation operation in this.asyncOperations)
				{
					operation.Cancel();
				}

				// Set the pause and stop flags.
				this.isPaused = false;
				this.isStopped = true;
			}
			// Set the pause wait handle to the signaled state.
			this.waitPause.Set();
		}

		/// <summary>
		/// Waits for the execution of the manager to resume.
		/// </summary>
		internal void WaitPause()
		{
			this.waitPause.WaitOne();
		}

		/// <summary>
		/// Waits for the excution of the manager to complete.
		/// </summary>
		internal void WaitStop()
		{
			// Wait for all asynchronous operations to complete.
			this.waitAsync.WaitOne();
			// Wait for all node operations to complete.
			this.waitNodes.WaitOne();
		}

		/// <summary>
		/// Adds an asynchronous web operation.
		/// </summary>
		/// <param name="request">The asynchronous request.</param>
		/// <param name="result">The asynchronous result.</param>
		/// <returns>The asynchronous operation.</returns>
		internal AsyncWebOperation BeginAsyncOperation(AsyncWebRequest request, IAsyncResult result)
		{
			// Create the asynchronous web operation.
			AsyncWebOperation operation = new AsyncWebOperation(request, result);

			lock (this.sync)
			{
				// Verify that the operation does not exist.
				if (this.asyncOperations.Contains(operation)) throw new InvalidOperationException("Cannot begin an asynchronous operation because the same operation already exists.");

				// Add the operation to the list.
				this.asyncOperations.Add(operation);

				// Set the wait handle to the non-signaled state.
				this.waitAsync.Reset();
			}

			return operation;
		}

		/// <summary>
		/// Removes an asynchronous web operation.
		/// </summary>
		/// <param name="operation">The asynchronous operation.</param>
		internal void EndAsyncOperation(AsyncWebOperation operation)
		{
			lock (this.sync)
			{
				// Remove the operation.
				this.asyncOperations.Remove(operation);

				// If the operations list is empty.
				if (this.asyncOperations.Count == 0)
				{
					// Set the wait handle to the signaled state.
					this.waitAsync.Set();
				}
			}
		}

		/// <summary>
		/// Adds the specified PlanetLab node to the pending state.
		/// </summary>
		/// <param name="node">The PlanetLab node.</param>
		internal void AddNode(PlNode node)
		{
			lock (this.sync)
			{
				// Create a new state for this node.
				PlManagerNodeState nodeState = new PlManagerNodeState(node);
				// Add the node to the nodes state list.
				this.nodeStates.Add(nodeState);
				// Add the state index to the list of pending nodes.
				this.pendingNodes.Add(this.nodeStates.Count - 1);
			}
		}

		/// <summary>
		/// Gets the state for the PlanetLab node at the specified index.
		/// </summary>
		/// <param name="index">The node index.</param>
		/// <returns>The PlanetLab node state.</returns>
		internal PlManagerNodeState GetNode(int index)
		{
			lock (this.sync)
			{
				return this.nodeStates[index];
			}
		}

		/// <summary>
		/// Updates the specified node from the pending to the running state.
		/// </summary>
		/// <param name="index">The node index.</param>
		internal void UpdateNodePendingToRunning(int index)
		{
			lock (this.sync)
			{
				// If the running list is empty.
				if (this.runningNodes.Count == 0)
				{
					// Reset the nodes wait handle.
					this.waitNodes.Reset();
				}

				// Remove the node from the pending list.
				if (!this.pendingNodes.Remove(index)) throw new InvalidOperationException("PlanetLab manager internal error: node not found in the pending list.");
				// Add the node to the running list.
				if (!this.runningNodes.Add(index)) throw new InvalidOperationException("PlanetLab manager internal error: node already exists in the running list.");
				
				// Add the corresponding site to the running list.
				this.runningSites.Add(this.nodeStates[index].Node.SiteId.Value);
			}
		}

		/// <summary>
		/// Updates the specified node from the pending to the skipped state.
		/// </summary>
		/// <param name="index">The node index.</param>
		internal void UpdateNodePendingToSkipped(int index)
		{
			lock (this.sync)
			{
				// Remove the node from the pending list.
				if (!this.pendingNodes.Remove(index)) throw new InvalidOperationException("PlanetLab manager internal error: node not found in the pending list.");
				// Add the node to the running list.
				if (!this.skippedNodes.Add(index)) throw new InvalidOperationException("PlanetLab manager internal error: node already exists in the skipped list.");

				// Update the wait handle.
				this.UpdateWaitNodes();
			}
		}

		/// <summary>
		/// Updates the specified node from the running to the completed state.
		/// </summary>
		/// <param name="index">The node index.</param>
		internal void UpdateNodeRunningToCompleted(int index)
		{
			lock (this.sync)
			{
				// Remove the node from the running list.
				if (!this.runningNodes.Remove(index)) throw new InvalidOperationException("PlanetLab manager internal error: node not found in the running list.");
				// Add the node to the completed list.
				if (!this.completedNodes.Add(index)) throw new InvalidOperationException("PlanetLab manager internal error: node already exists in the completed list.");

				// Remove the corresponding site from the running list.
				this.runningSites.Remove(this.nodeStates[index].Node.SiteId.Value);
				// Add the corresponding site to the completed list.
				this.completedSites.Add(this.nodeStates[index].Node.SiteId.Value);

				// Update the wait handle.
				this.UpdateWaitNodes();
			}
		}

		/// <summary>
		/// Updates the specified node from the running to the skipped state.
		/// </summary>
		/// <param name="index">The node index.</param>
		internal void UpdateNodeRunningToSkipped(int index)
		{
			lock (this.sync)
			{
				// Remove the node from the running list.
				if (!this.runningNodes.Remove(index)) throw new InvalidOperationException("PlanetLab manager internal error: node not found in the running list.");
				// Add the node to the skipped list.
				if (!this.skippedNodes.Add(index)) throw new InvalidOperationException("PlanetLab manager internal error: node already exists in the skipped list.");

				// Remove the corresponding site from the running list.
				this.runningSites.Remove(this.nodeStates[index].Node.SiteId.Value);

				// Update the wait handle.
				this.UpdateWaitNodes();
			}
		}

		/// <summary>
		/// Cancels all pending nodes, moving them to the skipped list.
		/// </summary>
		internal void CancelPendingNodes()
		{
			lock (this.sync)
			{
				// While there are nodes in the pending list.
				while (this.pendingNodes.Count > 0)
				{
					// Get the first pending node.
					int index = this.pendingNodes.First();

					// Remove the node from the pending list.
					if (!this.pendingNodes.Remove(index)) throw new InvalidOperationException("PlanetLab manager internal error: node not found in the pending list.");
					// Add the node to the skipped list.
					if (!this.skippedNodes.Add(index)) throw new InvalidOperationException("PlanetLab manager internal error: node already exists in the skipped list.");
				}

				// Update the wait handle.
				this.UpdateWaitNodes();
			}
		}

		/// <summary>
		/// Indicates whether the specified site has a node in the running state.
		/// </summary>
		/// <param name="site">The site identifier.</param>
		/// <returns><b>True</b> if the site has a node in the running state, <b>false</b> otherwise.</returns>
		internal bool IsSiteRunning(int site)
		{
			lock (this.sync)
			{
				return this.runningSites.Contains(site);
			}
		}

		/// <summary>
		/// Indicates whether the specified site has a node in the completed state.
		/// </summary>
		/// <param name="site">The site identifier.</param>
		/// <returns><b>True</b> if the site has a node in the completed state, <b>false</b> otherwise.</returns>
		internal bool IsSiteCompleted(int site)
		{
			lock (this.sync)
			{
				return this.completedSites.Contains(site);
			}
		}

		// Private methods.

		/// <summary>
		/// Updates the status of the nodes wait handle.
		/// </summary>
		private void UpdateWaitNodes()
		{
			// If the pending and running lists are empty.
			if ((0 == this.pendingNodes.Count) && (0 == this.runningNodes.Count))
			{
				// Set the wait handle to the signaled state.
				this.waitNodes.Set();
			}
		}
	}
}
