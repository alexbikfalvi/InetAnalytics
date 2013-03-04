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

namespace YtCrawler.Database
{
	/// <summary>
	/// A class representing a Microsoft SQL Server.
	/// </summary>
	public sealed class DbServerMsSql : DbServer
	{
		private SqlConnectionStringBuilder connectionString;
		private SqlConnection connection = new SqlConnection();

		/// <summary>
		/// Creates a new server instance.
		/// </summary>
		/// <param name="key">The registry configuration key.</param>
		/// <param name="id">The server ID.</param>
		public DbServerMsSql(string key, string id)
			: base(key, id)
		{
			// Initialize the server with the current configuration.
			this.Initialize();

			// Set the connection event handlers.
			this.connection.StateChange += this.OnConnectionStateChanged;
		}

		// Public properties.

		/// <summary>
		/// Gets the current connection state.
		/// </summary>
		public override ConnectionState ConnectionState
		{
			get { return this.connection.State; }
		}

		// Public methods.

		/// <summary>
		/// Opens the connection to the database server.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="userState">The user state.</param>
		public override void Open(DbServerCallback callback, object userState = null)
		{
			// Create a new asynchrounous state for this operation.
			DbServerAsyncState asyncState = new DbServerAsyncState(userState);
			// Begin open the connection asynchronously on the thread pool.
			ThreadPool.QueueUserWorkItem((object state) =>
				{
					// Execute asynchronously on the thread pool.
					try
					{
						// Open the database connection.
						this.connection.Open();
					}
					catch (Exception exception)
					{
						// If an exception occurs, set the callback exception.
						asyncState.Exception = exception;
					}
					// Call the callback method with the given state, catch all exceptions.
					try { callback(asyncState); }
					catch (Exception) { }
				});
		}

		/// <summary>
		/// Reopens the connection to the database server.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="userState">The user state.</param>
		public override void Reopen(DbServerCallback callback, object userState = null)
		{
			// Create a new asynchrounous state for this operation.
			DbServerAsyncState asyncState = new DbServerAsyncState(userState);
			// Begin open the connection asynchronously on the thread pool.
			ThreadPool.QueueUserWorkItem((object state) =>
			{
				// Execute asynchronously on the thread pool.
				try
				{
					// Close the database connection.
					this.connection.Close();
					// Open the database connection.
					this.connection.Open();
				}
				catch (Exception exception)
				{
					// If an exception occurs, set the callback exception.
					asyncState.Exception = exception;
				}
				// Call the callback method with the given state, catch all exceptions.
				try { callback(asyncState); }
				catch (Exception) { }
			});
		}

		/// <summary>
		/// Closes the connection to the database server.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="userState">The user state.</param>
		public override void Close(DbServerCallback callback, object userState = null)
		{
			// Create a new asynchrounous state for this operation.
			DbServerAsyncState asyncState = new DbServerAsyncState(userState);
			// Begin open the connection asynchronously on the thread pool.
			ThreadPool.QueueUserWorkItem((object state) =>
			{
				// Execute asynchronously on the thread pool.
				try
				{
					// Close the database connection.
					this.connection.Close();
				}
				catch (Exception exception)
				{
					// If an exception occurs, set the callback exception.
					asyncState.Exception = exception;
				}
				// Call the callback method with the given state, catch all exceptions.
				try { callback(asyncState); }
				catch (Exception) { }
			});
		}

		/// <summary>
		/// Initializes the server configuration.
		/// </summary>
		private void Initialize()
		{
			// Create the connection string for this server.
			this.connectionString = new SqlConnectionStringBuilder();
			this.connectionString.DataSource = this.DataSource;
			this.connectionString.UserID = this.Username;
			this.connectionString.Password = this.Password;

			// Set the connection for the connection string.
			this.connection.ConnectionString = this.connection.ConnectionString;
		}

		/// <summary>
		/// An event handler called when the state of the connection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private new void OnConnectionStateChanged(object sender, StateChangeEventArgs e)
		{
			// Call the base class event handler.
			base.OnConnectionStateChanged(sender, e);
		}
	}
}
