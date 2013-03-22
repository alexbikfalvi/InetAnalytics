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
using YtCrawler.Database.Data;

namespace YtCrawler.Database
{
	/// <summary>
	/// A class representing a database table data of raw values.
	/// </summary>
	public class DbDataRaw : DbData
	{
		private delegate void AddRowHandler(DbReader reader);

		private int columnCount = 0;

		private List<object[]> rows = new List<object[]>();
		private string[] names = null;
		private Dictionary<string, int> mapping = new Dictionary<string, int>();

		private AddRowHandler handler;

		/// <summary>
		/// Initializes a database table using data from the specified reader.
		/// </summary>
		public DbDataRaw()
		{
			// Initialize the handler.
			this.handler = new AddRowHandler(this.AddFirstRow);
		}

		/// <summary>
		/// Gets the row count for this table.
		/// </summary>
		public int RowCount { get { return this.rows.Count; } }
		/// <summary>
		/// Gets the column count for this table.
		/// </summary>
		public int ColumnCount { get { return this.columnCount; } }
		/// <summary>
		/// Gets the element at the specified column and row.
		/// </summary>
		/// <param name="column">The column index.</param>
		/// <param name="row">The row index.</param>
		/// <returns>The table element.</returns>
		public object this[int column, int row] { get { return this.rows[row][column]; } }
		/// <summary>
		/// Gets the element at the specified column name and row.
		/// </summary>
		/// <param name="column">The column name.</param>
		/// <param name="row">The row.</param>
		/// <returns></returns>
		public object this[string column, int row] { get { return this.rows[row][this.mapping[column]]; } }
		/// <summary>
		/// Gets the column names for this table.
		/// </summary>
		public string[] ColumnNames { get { return this.names; } }
		/// <summary>
		/// Returns <b>true</b> if the table has data, or <b>false</b> otherwise.
		/// </summary>
		public bool HasData { get { return this.rows.Count > 0; } }

		/// <summary>
		/// Adds a row of data to the table from the specified reader.
		/// </summary>
		/// <param name="reader">The database reader.</param>
		public void AddRow(DbReader reader)
		{
			this.handler(reader);
		}

		/// <summary>
		/// Gets the row of objects at the specified index.
		/// </summary>
		/// <param name="index">The row index.</param>
		/// <returns>The row of table objects.</returns>
		public object[] GetRow(int index)
		{
			return this.rows[index];
		}

		/// <summary>
		/// Adds the first row to the database table.
		/// </summary>
		/// <param name="reader">The database reader.</param>
		private void AddFirstRow(DbReader reader)
		{
			// Initialize the number of columns based on the data from the reader.
			this.columnCount = reader.ColumnCount;
			// Initialize the column names.
			this.names = new string[this.columnCount];
			// Initialize tha column mappings.
			for (int index = 0; index < this.columnCount; index++)
			{
				this.names[index] = reader.GetName(index);
				this.mapping.Add(this.names[index], index);
			}
			// Change the handler.
			this.handler = new AddRowHandler(this.AddNextRow);
			// Add the first row to the table.
			this.AddNextRow(reader);
		}

		/// <summary>
		/// Adds the next rows to the database tables.
		/// </summary>
		/// <param name="reader">The database reader.</param>
		private void AddNextRow(DbReader reader)
		{
			// Add a new row to the data.
			object[] row = new object[reader.ColumnCount];
			for (int index = 0; index < this.columnCount; index++)
			{
				row[index] = reader[index];
			}
			this.rows.Add(row);
		}
	}
}
