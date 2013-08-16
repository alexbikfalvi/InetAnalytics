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
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using DotNetApi;

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
		/// <param name="transaction">The database transaction, or <b>null</b> if no transaction is used.</param>
		public DbCommandSql(SqlConnection connection, DbQuery query, DbTransactionSql transaction = null)
			: base(query)
		{
			// Create a modified query for this server, replacing the query parameters.
			string queryServer = null;
			// Create an array of parameter names.
			string[] parameterNames = null;
			
			// If the command has parameters.
			if (query.Parameters.Count > 0)
			{
				// Process the query parameters, by creating the list of parameter names.
				parameterNames = new string[query.Parameters.Count];
				for (int index = 0; index < query.Parameters.Count; index++)
				{
					parameterNames[index] = "@param{0}".FormatWith(index);
				}
				// Create the query.
				queryServer = query.Query.FormatWith(parameterNames);
			}
			else
			{
				// If there are no parameters, use the givem query.
				queryServer = query.Query;
			}
			
			// If the database transaction is not null.
			if (transaction != null)
				this.command = new SqlCommand(queryServer, connection, transaction.Transaction);
			else
				this.command = new SqlCommand(queryServer, connection);

			// Add the parameters to the command.
			for (int index = 0; index < query.Parameters.Count; index++)
			{
				this.command.Parameters.AddWithValue(parameterNames[index], query.Parameters[index]);
			}
		}

		/// <summary>
		/// Executes a database query asynchronously.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="userState">The user state.</param>
		/// <returns>The asynchronous result.</returns>
		public override IAsyncResult ExecuteReader(DbCommandReaderCallback callback, object userState = null)
		{
			// Create the asynchronous result.
			DbAsyncResult asyncResult = new DbAsyncResult(userState);
			// Begin execute the command asynchronously.
			this.command.BeginExecuteReader((IAsyncResult result) =>
				{
					// Create a new reader for this command.
					DbReaderSql reader = null;

					// Set the synchronous completion of the command.
					asyncResult.CompletedSynchronously = result.CompletedSynchronously;

					try
					{
						// Try and execute the command.
						SqlDataReader sqlReader = this.command.EndExecuteReader(result);
						// Create a new reader instance.
						reader = new DbReaderSql(sqlReader);
					}
					catch (SqlException exception)
					{
						// If an exception occurs, set the exception.
						asyncResult.Exception = new DbException("The execution of the SQL query \'{0}\' failed. {1}".FormatWith(this.Query, exception.Message), exception);
					}
					catch (Exception exception)
					{
						// If an exception occurs, set the exception.
						asyncResult.Exception = new DbException("The execution of the SQL query \'{0}\' failed.".FormatWith(this.Query), exception); 
					}
					// Complete the asynchronous operation.
					asyncResult.Complete();
					// Call the callback method.
					if (callback != null) callback(asyncResult, reader);
				},
				asyncResult.AsyncState);

			return asyncResult;
		}


		/// <summary>
		/// Executes a database statement asynchronously.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="userState">The user state.</param>
		/// <returns>The asynchronous result.</returns>
		public override IAsyncResult ExecuteNonQuery(DbCommandNonQueryCallback callback, object userState = null)
		{
			// Create the asynchronous result.
			DbAsyncResult asyncResult = new DbAsyncResult(userState);
			// Begin execute the command asynchronously.
			this.command.BeginExecuteNonQuery((IAsyncResult result) =>
				{
					// Set the synchronous completion of the command.
					asyncResult.CompletedSynchronously = result.CompletedSynchronously;

					int count = 0;
					try
					{
						count = this.command.EndExecuteNonQuery(result);
					}
					catch (Exception exception)
					{
						// If an exception occurs, set the exception.
						asyncResult.Exception = new DbException("The execution of the SQL statement \'{0}\' failed.".FormatWith(this.Query), exception);
					}
					// Complete the asynchronous operation.
					asyncResult.Complete();
					// Call the callback method.
					if (callback != null) callback(asyncResult, count);
				},
				asyncResult.AsyncState);
			return asyncResult;
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
		/// Adds a parameter to the database command.
		/// </summary>
		/// <param name="name">The parameter name.</param>
		/// <param name="value">The parameter value.</param>
		public override void AddParameter(string name, object value)
		{
			// Add the parameter to the command.
			this.command.Parameters.AddWithValue(name, value);
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
