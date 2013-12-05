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
using System.Threading;
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

		private readonly HashSet<int> completedSites = new HashSet<int>();
		private readonly List<PlManagerNodeState> pendingNodes = new List<PlManagerNodeState>();

		private volatile bool isPaused = false;
		private volatile bool isCanceled = false;

		private readonly ManualResetEvent pauseWait = new ManualResetEvent(false);

		private ExecutionStatus status = ExecutionStatus.Stopped;

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

		// Internal properties.

		/// <summary>
		/// Gets the synchronization object for this manager state.
		/// </summary>
		internal object Sync { get { return this.sync; } }
		/// <summary>
		/// Gets or sets the result of a PlanetLab asynchronous operation.
		/// </summary>
		internal IAsyncResult PlanetLabAsyncResult { get; set; }
		/// <summary>
		/// Gets the list of pending nodes.
		/// </summary>
		internal List<PlManagerNodeState> PendingNodes { get { return this.pendingNodes; } }
		/// <summary>
		/// Gets the list of completed sites.
		/// </summary>
		internal HashSet<int> CompletedSites { get { return this.completedSites; } }
		/// <summary>
		/// Gets or sets whether the manager is paused.
		/// </summary>
		internal bool IsPaused
		{
			get { return this.isPaused; }
			set { this.isPaused = value; }
		}
		/// <summary>
		/// Gets or sets whether the manager is canceled.
		/// </summary>
		internal bool IsCanceled
		{
			get { return this.isCanceled; }
			set { this.isCanceled = value; }
		}
		/// <summary>
		/// Gets the pause wait manual reset event.
		/// </summary>
		internal ManualResetEvent PauseWait { get { return this.pauseWait; } }

		// Public methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Dispose the wait handles.
			this.pauseWait.Dispose();
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}
	}
}
