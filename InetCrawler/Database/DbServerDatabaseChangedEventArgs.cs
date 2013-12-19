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
using InetCrawler.Database.Data;

namespace InetCrawler.Database
{
	/// <summary>
	/// A delegate representing the event handler for the server database changed.
	/// </summary>
	/// <param name="server">The sender object.</param>
	/// <param name="e">The event arguments.</param>
	public delegate void DbServerDatabaseChangedEventHandler(object sender, DbServerDatabaseChangedEventArgs e);

	/// <summary>
	/// A class representing the event arguments for the server database changed.
	/// </summary>
	public class DbServerDatabaseChangedEventArgs : DbServerEventArgs
	{
		/// <summary>
		/// Creates a new event arguments instance.
		/// </summary>
		/// <param name="oldDatabase">The old database.</param>
		/// <param name="newDatabase">The new database.</param>
		public DbServerDatabaseChangedEventArgs(DbServer server, DbObjectDatabase oldDatabase, DbObjectDatabase newDatabase)
			: base(server)
		{
			this.OldDatabase = oldDatabase;
			this.NewDatabase = newDatabase;
		}

		/// <summary>
		/// Gets the old database.
		/// </summary>
		public DbObjectDatabase OldDatabase { get; private set; }

		/// <summary>
		/// Gets the new database.
		/// </summary>
		public DbObjectDatabase NewDatabase { get; private set; }
	}
}
