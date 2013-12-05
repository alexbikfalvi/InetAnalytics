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
using System.Threading;
using PlanetLab.Api;

namespace InetCrawler.PlanetLab
{
	/// <summary>
	/// A class representing the state of command execution on a PlanetLab node.
	/// </summary>
	internal sealed class PlManagerNodeState : IDisposable
	{
		public enum NodeState
		{
			Pending = 0,
			Running = 1,
			Completed = 2
		}

		private readonly PlNode node;
		private readonly object sync = new object();
		private readonly ManualResetEvent wait = new ManualResetEvent(false);

		/// <summary>
		/// Creates a new node state instance.
		/// </summary>
		/// <param name="node">The PlanetLab node.</param>
		internal PlManagerNodeState(PlNode node)
		{
			this.node = node;

			this.State = NodeState.Pending;
			this.CommandIndex = 0;
			this.ParameterIndex = 0;
			this.SuccessCount = 0;
			this.WarningCount = 0;
			this.FailureCount = 0;
		}

		// Internal properties.

		/// <summary>
		/// Gets the PlanetLab node.
		/// </summary>
		internal PlNode Node { get { return this.node; } }
		/// <summary>
		/// Gets or sets the node state.
		/// </summary>
		internal NodeState State { get; set; }
		/// <summary>
		/// Gets the current command index.
		/// </summary>
		internal int CommandIndex { get; set; }
		/// <summary>
		/// Gets the current parameter set index.
		/// </summary>
		internal int ParameterIndex { get; set; }
		/// <summary>
		/// Gets the success count.
		/// </summary>
		internal int SuccessCount { get; set; }
		/// <summary>
		/// Gets the warning count.
		/// </summary>
		internal int WarningCount { get; set; }
		/// <summary>
		/// Gets the failure count.
		/// </summary>
		internal int FailureCount { get; set; }
		/// <summary>
		/// Gets the synchronization object for this node state.
		/// </summary>
		internal object Sync { get { return this.sync; } }
		/// <summary>
		/// Gets the manual reset event for this 
		/// </summary>
		internal ManualResetEvent Wait { get { return this.wait; } }

		// Public methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Dispose the wait handles.
			this.wait.Dispose();
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}
	}
}
