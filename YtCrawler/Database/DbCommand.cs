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
using System.Data.SqlClient;
using System.Threading;

namespace YtCrawler.Database
{
	public delegate void DbCommandReaderCallback(DbAsyncResult result, DbReader reader);
	public delegate void DbCommandNonQueryCallback(DbAsyncResult result, int count);

	/// <summary>
	/// A class representing a database command.
	/// </summary>
	public abstract class DbCommand : IDisposable
	{
		private string query;

		/// <summary>
		/// Creates a new database command with the specified query.
		/// </summary>
		/// <param name="query">The command query.</param>
		public DbCommand(string query)
		{
			this.query = query;
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the command query.
		/// </summary>
		public string Query { get { return this.query; } }

		// Public methods.

		/// <summary>
		/// Executes the database query asynchronously.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="userState">The user state.</param>
		/// <returns>The asynchronous result.</returns>
		public abstract IAsyncResult ExecuteReader(DbCommandReaderCallback callback, object userState = null);


		/// <summary>
		/// Executes a database statement asynchronously.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="userState">The user state.</param>
		/// <returns>The asynchronous result.</returns>
		public abstract IAsyncResult ExecuteNonQuery(DbCommandNonQueryCallback callback, object userState = null);

		/// <summary>
		/// Cancels the execution of an asynchronous operation.
		/// </summary>
		public abstract void Cancel();

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
