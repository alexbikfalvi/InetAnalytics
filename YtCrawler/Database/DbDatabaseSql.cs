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
		/// Gets the schema name for the current database.
		/// </summary>
		public override string SchemaName { get { return string.Format("{0}.dbo", this.Name); } }

		/// <summary>
		/// Creates a database instance from the specified registry key.
		/// </summary>
		/// <param name="key">The registry key.</param>
		/// <returns>The database instance.</returns>
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
				new DateTime(Int64.Parse(data[2])));
		}

		/// <summary>
		/// Deletes the database at the specified registry key.
		/// </summary>
		/// <param name="key">The registry key.</param>
		public static void Delete(string key)
		{
			Registry.SetValue(key, "Database", null, RegistryValueKind.MultiString);
		}

		/// <summary>
		/// Save the database at the specified registry key.
		/// </summary>
		/// <param name="key">The registry key.</param>
		public override void Save(string key)
		{
			string[] data = new string[] {
				this.id.ToString(),
				this.name,
				this.dateCreate.Ticks.ToString()
			};
			Registry.SetValue(key, "Database", data, RegistryValueKind.MultiString);
		}

		/// <summary>
		/// Createa a database instance from the specified table row.
		/// </summary>
		/// <param name="table">The table.</param>
		/// <param name="row">The row index.</param>
		/// <returns>The database instance.</returns>
		public static DbDatabaseSql Read(DbData table, int row)
		{
			string name = table["name", row] as string;
			int id = (int)table["database_id", row];
			DateTime dateCreate = (DateTime)table["create_date", row];
			// Create the object.
			return new DbDatabaseSql(id, name, dateCreate);
		}
	}
}
