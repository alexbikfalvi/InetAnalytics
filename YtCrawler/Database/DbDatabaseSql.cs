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
using Microsoft.Win32;

namespace YtCrawler.Database
{
	/// <summary>
	/// A class that represents a database for a Microsoft SQL Server.
	/// </summary>
	public class DbDatabaseSql : DbDatabase
	{
		/// <summary>
		/// Creates a new database instance.
		/// </summary>
		/// <param name="id">The database ID.</param>
		/// <param name="name">The database name.</param>
		/// <param name="dateCreate">The database creation date.</param>
		private DbDatabaseSql(int id, string name, DateTime dateCreate)
			: base(id, name, dateCreate)
		{
		}

		/// <summary>
		/// Creates a database instance from the specified registry key.
		/// </summary>
		/// <param name="key">The registr</param>
		public static DbDatabaseSql Load(string key)
		{
			// Read the data from registry
			string[] data = Registry.GetValue(key, "Database", null) as string[];
			// If the data returned is null, return null.
			if(null == data) return null;
			// Otherwise, initialize the values from the multi string.
			return new DbDatabaseSql(
				int.Parse(data[0]),
				data[1],
				DateTime.Parse(data[2]));
		}
	}
}
