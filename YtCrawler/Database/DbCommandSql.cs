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
	/// <summary>
	/// A class representing 
	/// </summary>
	public sealed class DbCommandSql : DbCommand
	{
		private SqlCommand command = null;

		/// <summary>
		/// Creates a new database command with the specified query in transactionless mode.
		/// </summary>
		/// <param name="connection">The database server connection.</param>
		/// <param name="query">The command query.</param>
		/// <param name="state">The user state.</param>
		public DbCommandSql(SqlConnection connection, string query, object state)
			: base(query, state)
		{
			// Create the SQL command.
			this.command = new SqlCommand(query, connection);
		}

		/// <summary>
		/// Executes a database query asynchronously.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="userState">The user state.</param>
		/// <returns>The asynchronous result.</returns>
		public override IAsyncResult ExecuteReader(DbCommandReaderCallback callback, object userState = null)
		{
			// Begin execute the command asynchronously.
			this.command.BeginExecuteReader((IAsyncResult result) =>
				{
					// Create a new reader for this command.
					DbReaderSql reader = null;

					// Set the synchronous completion of the command.
					this.CompletedSynchronously = result.CompletedSynchronously;

					try
					{
						// Try and execute the command.
						SqlDataReader sqlReader = this.command.EndExecuteReader(result);
						// Create a new reader instance.
						reader = new DbReaderSql(sqlReader, userState);
					}
					catch (Exception exception)
					{
						// If an exception occurs, set the exception.
						this.Exception = new DbException(string.Format("The execution of the SQL query \'{0}\' failed.", this.Query), exception); 
					}
					// Complete the asynchronous operation.
					this.Complete();
					// Call the callback method.
					if (callback != null) callback(this, reader);
				},
				this.AsyncState);

			return this;
		}


		/// <summary>
		/// Executes a database statement asynchronously.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="userState">The user state.</param>
		/// <returns>The asynchronous result.</returns>
		public override IAsyncResult ExecuteNonQuery(DbCommandNonQueryCallback callback, object userState = null)
		{
			// Begin execute the command asynchronously.
			this.command.BeginExecuteNonQuery((IAsyncResult result) =>
				{
					// Set the synchronous completion of the command.
					this.CompletedSynchronously = result.CompletedSynchronously;

					int count = 0;
					try
					{
						count = this.command.EndExecuteNonQuery(result);
					}
					catch (Exception exception)
					{
						// If an exception occurs, set the exception.
						this.Exception = new DbException(string.Format("The execution of the SQL statement \'{0}\' failed.", this.Query), exception);
					}
					// Complete the asynchronous operation.
					this.Complete();
					// Call the callback method.
					if (callback != null) callback(this, count);
				},
				this.AsyncState);
			return this;
		}

		/// <summary>
		/// Cancels the execution of an asynchronous operation.
		/// </summary>
		public override void Cancel()
		{
			// Execute the command on the thread pool.
			ThreadPool.QueueUserWorkItem((object state) =>
				{
					this.command.Cancel();
				});
		}

		/// <summary>
		/// A method called when the object is being disposed.
		/// </summary>
		protected override void OnDisposed()
		{
			// Dispose the current command.
			this.command.Dispose();
		}
	}
}
