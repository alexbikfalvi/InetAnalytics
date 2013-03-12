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
using System.Collections.Generic;

namespace YtCrawler.Database
{
	/// <summary>
	/// A class representing the mapping between a .NET type and the corresponding database/table/columns.
	/// </summary>
	public class DbMapping
	{
		private DbDatabase database;
		private DbTable table;
		private Dictionary<string, DbColumn> map = new Dictionary<string,DbColumn>();

		/// <summary>
		/// Creates a database type mapping for the following database and table.
		/// </summary>
		/// <param name="database">The database.</param>
		/// <param name="table">The table.</param>
		public DbMapping(DbDatabase database, DbTable table)
		{
			this.database = database;
			this.table = table;
		}

		/// <summary>
		/// Gets the database used by the current mapping.
		/// </summary>
		public DbDatabase Database { get { return this.database; } }

		/// <summary>
		/// Gets the table used by the current mapping.
		/// </summary>
		public DbTable Table { get { return this.table; } }
	}
}
