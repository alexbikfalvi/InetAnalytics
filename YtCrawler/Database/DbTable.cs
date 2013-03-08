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
	/// A class representing a database table.
	/// </summary>
	public class DbTable
	{
		private delegate void AddRowHandler(DbReader reader);

		private int columnCount = 0;
		private int rowCount = 0;

		private List<object>[] columns;
		private Dictionary<string, List<object>> names = new Dictionary<string,List<object>>();

		private AddRowHandler handler;

		/// <summary>
		/// Initializes a database table using data from the specified reader.
		/// </summary>
		public DbTable()
		{
			// Initialize the handler.
			this.handler = new AddRowHandler(this.AddFirstRow);
		}

		/// <summary>
		/// Gets the row count for this table.
		/// </summary>
		public int RowCount { get { return this.rowCount; } }
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
		public object this[int column, int row] { get { return this.columns[column][row]; } }
		/// <summary>
		/// Gets the element at the specified column name and row.
		/// </summary>
		/// <param name="column">The column name.</param>
		/// <param name="row">The row.</param>
		/// <returns></returns>
		public object this[string column, int row] { get { return this.names[column][row]; } }

		/// <summary>
		/// Adds a row of data to the table from the specified reader.
		/// </summary>
		/// <param name="reader">The database reader.</param>
		public void AddRow(DbReader reader)
		{
			this.handler(reader);
		}

		/// <summary>
		/// Adds the first row to the database table.
		/// </summary>
		/// <param name="reader">The database reader.</param>
		private void AddFirstRow(DbReader reader)
		{
			// Initialize the number of columns based on the data from the reader.
			this.columnCount = reader.ColumnCount;
			// Initialize the table data, organized by columns.
			this.columns = new List<object>[this.columnCount];
			// Initialize the table names.
			for (int index = 0; index < this.columnCount; index++)
			{
				this.names.Add(reader.GetName(index), this.columns[index]);
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
			// If the number of columns in the reader does not match the table, throw an exception.
			if (reader.ColumnCount != this.columnCount) throw new DbException(string.Format("Cannot add a new row to the table. The data column count {0} does not match the table column count {1}.", reader.ColumnCount, this.columnCount));
			// Add a new row to the data.
			for (int index = 0; index < this.columnCount; index++)
			{
				this.columns[index].Add(reader[index]);
			}
			// Increment the row count.
			this.rowCount++;
		}
	}
}
