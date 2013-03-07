/* 
 * Copyright (C) 2012-2013 Alex Bikfalvi
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

namespace YtCrawler.Database
{
	public delegate void DbServerCallback(DbServerAsyncState asyncState);

	/// <summary>
	/// A class representing the asynchronous state for a database operation.
	/// </summary>
	public class DbServerAsyncState : IAsyncResult
	{
		private DbServer server;
		private object state;
		private AutoResetEvent wait = new AutoResetEvent(false);
		private bool completed = false;

		/// <summary>
		/// Creates a new instance of the asynchronous state.
		/// </summary>
		/// <param name="server">The database server.</param>
		/// <param name="state">The user state.</param>
		public DbServerAsyncState(DbServer server, object state)
		{
			// Save the database server.
			this.server = server;
			// Save the user state.
			this.state = state;
		}

		// Public properties.

		/// <summary>
		/// Returns the database server that generated the exception.
		/// </summary>
		public DbServer Server { get { return this.server; } }

		/// <summary>
		/// Gets or sets the asynchronous exception.
		/// </summary>
		public DbException Exception { get; set; }

		/// <summary>
		/// Returns the asynchronous user state.
		/// </summary>
		public object AsyncState { get { return this.state; } }

		/// <summary>
		/// Returns the wait handle.
		/// </summary>
		public WaitHandle AsyncWaitHandle { get { return this.wait; } }

		/// <summary>
		/// Indicates whether the operation completed synchronously.
		/// </summary>
		public bool CompletedSynchronously { get { return false; } }

		/// <summary>
		/// Indicates whether the operation completed.
		/// </summary>
		public bool IsCompleted { get { return this.completed; } }

		// Public methods.

		/// <summary>
		/// Completes the asynchronous operation by setting the completed property and the wait handle
		/// to <b>true</b>.
		/// </summary>
		public void Complete()
		{
			this.completed = true;
			this.wait.Set();
		}
	}
}
