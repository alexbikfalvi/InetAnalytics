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
using InetCrawler.Database.Data;

namespace InetCrawler.Database
{
	/// <summary>
	/// A class for generic database table object data.
	/// </summary>
	public class DbDataObject : DbData
	{
		private ITable table;
		private readonly List<DbObject> rows = new List<DbObject>();

		/// <summary>
		/// Initializes a database table using data from the specified reader.
		/// </summary>
		/// <param name="table">The database table which specifies the mapping between the database and object names.</param>
		public DbDataObject(ITable table)
		{
			// Set the object properties.
			this.table = table;
		}

		/// <summary>
		/// Gets the row count for this table.
		/// </summary>
		public int RowCount { get { return this.rows.Count; } }
		/// <summary>
		/// Gets the object at the specified row.
		/// </summary>
		/// <param name="row">The row index.</param>
		/// <returns>The database object.</returns>
		public DbObject this[int row] { get { return this.rows[row]; } }
		/// <summary>
		/// Gets the database table used for data conversion.
		/// </summary>
		public ITable Table { get { return this.table; } }

		/// <summary>
		/// Adds a row of data to the table from the specified reader.
		/// </summary>
		/// <param name="reader">The database reader.</param>
		public void AddRow(DbReader reader)
		{
			// Create a new object using the data from the reader, and add the object to the data rows.
			this.rows.Add(this.table.New(reader));
		}
	}

	/// <summary>
	/// A class for specific database table object data.
	/// </summary>
	/// <typeparam name="T">The table object type.</typeparam>
	public class DbDataObject<T> : DbData where T : DbObject, new()
	{
		private readonly List<T> rows = new List<T>();
		private DbTable<T> table;

		/// <summary>
		/// Initializes a database table using data from the specified reader.
		/// </summary>
		/// <param name="table">The database table which specifies the mapping between the database and object names.</param>
		public DbDataObject(DbTable<T> table)
		{
			this.table = table;
		}

		/// <summary>
		/// Gets the row count for this table.
		/// </summary>
		public int RowCount { get { return this.rows.Count; } }
		/// <summary>
		/// Gets the object at the specified row.
		/// </summary>
		/// <param name="row">The row index.</param>
		/// <returns>The database object.</returns>
		public T this[int row] { get { return this.rows[row]; } }
		/// <summary>
		/// Gets the database table used for data conversion.
		/// </summary>
		public DbTable<T> Table { get { return this.table; } }

		/// <summary>
		/// Adds a row of data to the table from the specified reader.
		/// </summary>
		/// <param name="reader">The database reader.</param>
		public void AddRow(DbReader reader)
		{
			// Create a new object using the data from the reader, and add the object to the data rows.
			this.rows.Add(this.table.New(reader) as T);
		}
	}
}
