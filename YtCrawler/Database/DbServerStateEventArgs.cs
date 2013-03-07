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

namespace YtCrawler.Database
{
	/// <summary>
	/// A class representing the event arguments for the database state.
	/// </summary>
	public class DbServerStateEventArgs : EventArgs
	{
		private DbServer.ServerState oldState;
		private DbServer.ServerState newState;

		/// <summary>
		/// Creates a new event arguments instance.
		/// </summary>
		/// <param name="oldState">The old state.</param>
		/// <param name="newState">The new state.</param>
		public DbServerStateEventArgs(DbServer.ServerState oldState, DbServer.ServerState newState)
		{
			this.oldState = oldState;
			this.newState = newState;
		}

		/// <summary>
		/// Gets the old state.
		/// </summary>
		public DbServer.ServerState OldState { get { return this.oldState; } }

		/// <summary>
		/// Gets the new state.
		/// </summary>
		public DbServer.ServerState NewState { get { return this.newState; } }
	}
}
