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

namespace InetCrawler.Database
{
	/// <summary>
	/// A delegate representing the event handler for a database relationship.
	/// </summary>
	/// <param name="server">The sender object.</param>
	/// <param name="e">The event arguments.</param>
	public delegate void DbServerRelationshipEventHandler(object sender, DbServerRelationshipEventArgs e);

	/// <summary>
	/// A class representing the event arguments for a database relationship.
	/// </summary>
	public class DbServerRelationshipEventArgs : DbServerEventArgs
	{
		/// <summary>
		/// Creates a new event arguments instance.
		/// </summary>
		/// <param name="server">The database server.</param>
		/// <param name="relationship">The database relationship.</param>
		public DbServerRelationshipEventArgs(DbServer server, IRelationship relationship)
			: base(server)
		{
			this.Relationship = relationship;
		}

		/// <summary>
		/// Gets the old state.
		/// </summary>
		public IRelationship Relationship { get; private set; }
	}
}
