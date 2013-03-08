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

namespace YtCrawler.Database
{
	public delegate void DbReaderCallback(DbReader reader);

	/// <summary>
	/// A class representing a database reader.
	/// </summary>
	public abstract class DbReader : DbAsyncState, IDisposable
	{
		private DbTable table = new DbTable();

		/// <summary>
		/// Create a new database reader instance.
		/// </summary>
		/// <param name="state">The user state.</param>
		public DbReader(object state)
			: base(state)
		{
		}

		// Public properties.

		/// <summary>
		/// Gets the number of columns in the current row.
		/// </summary>
		public abstract int ColumnCount { get; }
		/// <summary>
		/// Indicates whether there are data rows available.
		/// </summary>
		public abstract bool HasRows { get; }
		/// <summary>
		/// Indicates whether the reader is closed.
		/// </summary>
		public abstract bool IsClosed { get; }
		/// <summary>
		/// Gets the value of the cell on the current row at the given column.
		/// </summary>
		/// <param name="index">The column index.</param>
		/// <returns>The cell value.</returns>
		public abstract object this[int index] { get; }
		/// <summary>
		/// Gets the value of the cell on the current row at the given column.
		/// </summary>
		/// <param name="name">The column name.</param>
		/// <returns></returns>
		public abstract object this[string name] { get; }
		/// <summary>
		/// Gets the number of records changed by the execution of the database command.
		/// </summary>
		public abstract int RecordsAffected { get; }
		/// <summary>
		/// Returns the result table for this reader.
		/// </summary>
		public DbTable Result { get { return this.table; } }

		// Public methods.

		/// <summary>
		/// Indicates whether the cell at the specified column index is null.
		/// </summary>
		/// <param name="index">The column index.</param>
		/// <returns><b>True</b> if the cell is null, <b>false</b> otherwise.</returns>
		public abstract bool IsNull(int index);
		/// <summary>
		/// Gets the name of the column at the specified index.
		/// </summary>
		/// <param name="index">The column index.</param>
		/// <returns>The column name.</returns>
		public abstract string GetName(int index);
		/// <summary>
		/// Reads asynchronusly the specified number of records.
		/// </summary>
		/// <param name="count">The number of rows to read. If <b>null</b>, will read all records from the result.</param>
		/// <param name="callback">The callback method.</param>
		/// <returns>The result of the asynchronous operation.</returns>
		public abstract IAsyncResult Read(int? count, DbReaderCallback callback);
		/// <summary>
		/// Closes the reader.
		/// </summary>
		public abstract void Close();

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			this.OnDisposed();
		}


		// Protected methods.

		/// <summary>
		/// A method called when the object is being disposed.
		/// </summary>
		protected abstract void OnDisposed();
	}
}
