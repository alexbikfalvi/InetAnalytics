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
using System.Data.SqlClient;
using System.Threading;

namespace YtCrawler.Database
{
	/// <summary>
	/// A class representing a database reader for a Microsoft SQL server.
	/// </summary>
	public sealed class DbReaderSql : DbReader
	{
		private SqlDataReader reader;

		/// <summary>
		/// Create a new database reader instance.
		/// </summary>
		/// <param name="reader">The SQL data reader.</param>
		public DbReaderSql(SqlDataReader reader)
		{
			this.reader = reader;
		}

		/// <summary>
		/// Gets the number of columns in the current row.
		/// </summary>
		public override int ColumnCount { get { return this.reader.FieldCount; } }
		/// <summary>
		/// Indicates whether there are data rows available.
		/// </summary>
		public override bool HasRows { get { return this.reader.HasRows; } }
		/// <summary>
		/// Indicates whether the reader is closed.
		/// </summary>
		public override bool IsClosed { get { return this.reader.IsClosed; } }
		/// <summary>
		/// Gets the value of the cell on the current row at the given column.
		/// </summary>
		/// <param name="index">The column index.</param>
		/// <returns>The cell value.</returns>
		public override object this[int index] { get { return this.reader[index]; } }
		/// <summary>
		/// Gets the value of the cell on the current row at the given column.
		/// </summary>
		/// <param name="name">The column name.</param>
		/// <returns></returns>
		public override object this[string name] { get { return this.reader[name]; } }
		/// <summary>
		/// Gets the number of records changed by the execution of the database command.
		/// </summary>
		public override int RecordsAffected { get { return this.reader.RecordsAffected; } }

		// Public methods.

		/// <summary>
		/// Indicates whether the cell at the specified column index is null.
		/// </summary>
		/// <param name="index">The column index.</param>
		/// <returns><b>True</b> if the cell is null, <b>false</b> otherwise.</returns>
		public override bool IsNull(int index)
		{
			return this.reader.IsDBNull(index);
		}
		/// <summary>
		/// Gets the name of the column at the specified index.
		/// </summary>
		/// <param name="index">The column index.</param>
		/// <returns>The column name.</returns>
		public override string GetName(int index)
		{
			return this.reader.GetName(index);
		}
		/// <summary>
		/// Reads asynchronusly the specified number of records.
		/// </summary>
		/// <param name="count">The number of rows to read. If <b>null</b>, will read all records from the result.</param>
		/// <param name="callback">The callback method.</param>
		/// <param name="userState">The user state.</param>
		/// <returns>The result of the asynchronous operation.</returns>
		public override IAsyncResult Read(int? count, DbReaderCallback callback, object userState = null)
		{
			// Create the asynchronous result.
			DbAsyncResult asyncResult = new DbAsyncResult(userState);
			// Execute the read asynchronously on the thread pool.
			ThreadPool.QueueUserWorkItem((object state) =>
				{
					// Create the result.
					DbData result = new DbData();
					try
					{
						// Read records from the database while there are more records and the records count
						// is less than the specified number or the count is null.
						for (int index = 0; ((index < (count ?? 0)) || (count == null)) && reader.Read(); index++)
						{
							// Add the last row to the results table.
							result.AddRow(this);
						}
					}
					catch (SqlException exception)
					{
						// If an exception occurs, set the exception.
						asyncResult.Exception = new DbException(string.Format("An SQL error occurred while reading the query results from the database. {0}", exception.Message), exception);
					}
					catch (Exception exception)
					{
						// If an exception occurs, set the exception.
						asyncResult.Exception = new DbException("An error occurred while reading the query results from the database.", exception);
					}
					// Complete the asynchronous operation.
					asyncResult.Complete();
					// Call the callback method.
					if (callback != null) callback(asyncResult, result);
				});
			return asyncResult;
		}

		/// <summary>
		/// Closes the database reader.
		/// </summary>
		public override void Close()
		{
			this.reader.Close();
		}

		// Protected methods.

		/// <summary>
		/// A method called when the object is being disposed.
		/// </summary>
		protected override void OnDisposed()
		{
			// Close the reader if not closed.
			if (!this.reader.IsClosed) this.reader.Close();
			// Dispose the current reader.
			this.reader.Dispose();
		}
	}
}
