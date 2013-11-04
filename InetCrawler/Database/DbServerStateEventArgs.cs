/* 
 * Copyright (C) 2012 Alex Bikfalvi
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

namespace InetCrawler.Database
{
	/// <summary>
	/// A delegate representing the event handler for the database state.
	/// </summary>
	/// <param name="server">The sender object.</param>
	/// <param name="e">The event arguments.</param>
	public delegate void DbServerStateEventHandler(object sender, DbServerStateEventArgs e);

	/// <summary>
	/// A class representing the event arguments for the database state.
	/// </summary>
	public class DbServerStateEventArgs : DbServerEventArgs
	{
		/// <summary>
		/// Creates a new event arguments instance.
		/// </summary>
		/// <param name="oldState">The old state.</param>
		/// <param name="newState">The new state.</param>
		public DbServerStateEventArgs(DbServer server, DbServer.ServerState oldState, DbServer.ServerState newState)
			: base(server)
		{
			this.OldState = oldState;
			this.NewState = newState;
		}

		/// <summary>
		/// Gets the old state.
		/// </summary>
		public DbServer.ServerState OldState { get; private set; }
		/// <summary>
		/// Gets the new state.
		/// </summary>
		public DbServer.ServerState NewState { get; private set; }
	}
}
