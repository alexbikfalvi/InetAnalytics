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
		private SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder();
		private SqlConnection connection = new SqlConnection();
		private Mutex mutex = new Mutex();

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
			this.connection.StateChange += this.OnStateChanged;
		}

		/// <summary>
		/// Creates a database server with the specified parameters.
		/// </summary>
		/// <param name="key">The registry configuration key.</param>
		/// <param name="id">The server ID.</param>
		/// <param name="name">The server name.</param>
		/// <param name="dataSource">The data source.</param>
		/// <param name="username">The username.</param>
		/// <param name="password">The password.</param>
		public DbServerMsSql(
			string key,
			string id,
			string name,
			string dataSource,
			string username,
			string password
			)
			: base(key, id, name, dataSource, username, password)
		{
			// Initialize the server with the current configuration.
			this.Initialize();

			// Set the connection event handlers.
			this.connection.StateChange += this.OnStateChanged;
		}

		// Public properties.

		/// <summary>
		/// Gets the type of the database server.
		/// </summary>
		public override DbServers.DbServerType Type { get { return Database.DbServers.DbServerType.MsSql; } }

		/// <summary>
		/// Gets the current connection state.
		/// </summary>
		public override ConnectionState ConnectionState { get { return this.connection.State; } }

		/// <summary>
		/// Gets the server version.
		/// </summary>
		public override string Version
		{
			get
			{
				try
				{
					switch (this.ConnectionState)
					{
						case ConnectionState.Open:
						case ConnectionState.Executing:
						case ConnectionState.Fetching:
							return this.connection.ServerVersion;
						default:
							return string.Empty;
					}
				}
				catch (InvalidOperationException) { return string.Empty; }
			}
		}

		// Public methods.

		/// <summary>
		/// Opens the connection to the database server.
		/// </summary>
		public override void Open()
		{
			try
			{
				// Lock the mutex (only one state changing operation allowed at one time).
				this.mutex.WaitOne();
				// Open the database connection.
				this.connection.Open();
			}
			finally
			{
				// Unlock the mutex.
				this.mutex.ReleaseMutex();
			}			
		}

		/// <summary>
		/// Opens the connection to the database server asynchronously.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="userState">The user state.</param>
		/// <returns>The asynchronous result.</returns>
		public override IAsyncResult OpenAsync(DbServerCallback callback, object userState = null)
		{
			// Call the event handler.
			base.OnOpening();
			// Create a new asynchrounous state for this operation.
			DbServerAsyncState asyncState = new DbServerAsyncState(userState);
			// Begin open the connection asynchronously on the thread pool.
			ThreadPool.QueueUserWorkItem((object state) =>
				{
					// Execute asynchronously on the thread pool.
					try
					{
						// Open the connection.
						this.Open();
					}
					catch (Exception exception)
					{
						// If an exception occurs, set the callback exception.
						asyncState.Exception = exception;
					}
					// Complete the asynchronous operation.
					asyncState.Complete();
					// Call the callback method with the given state.
					if (callback != null) callback(asyncState);
				});
			return asyncState;
		}

		/// <summary>
		/// Reopens the connection to the database server.
		/// </summary>
		public override void Reopen()
		{
			try
			{
				// Lock the mutex (only one state changing operation allowed at one time).
				this.mutex.WaitOne();
				// Close the database connection.
				this.connection.Close();
				// Open the database connection.
				this.connection.Open();
			}
			finally
			{
				// Unlock the mutex.
				this.mutex.ReleaseMutex();
			}
		}

		/// <summary>
		/// Reopens the connection to the database server asynchronously.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="userState">The user state.</param>
		/// <returns>The asynchronous result.</returns>
		public override IAsyncResult ReopenAsync(DbServerCallback callback, object userState = null)
		{
			// Call the event handler.
			base.OnReopening();
			// Create a new asynchrounous state for this operation.
			DbServerAsyncState asyncState = new DbServerAsyncState(userState);
			// Begin open the connection asynchronously on the thread pool.
			ThreadPool.QueueUserWorkItem((object state) =>
				{
					// Execute asynchronously on the thread pool.
					try
					{
						// Reopen the connection.
						this.Reopen();
					}
					catch (Exception exception)
					{
						// If an exception occurs, set the callback exception.
						asyncState.Exception = exception;
					}
					// Complete the asynchronous operation.
					asyncState.Complete();
					// Call the callback method with the given state.
					if (callback != null) callback(asyncState);
				});
			return asyncState;
		}

		/// <summary>
		/// Closes the connection to the database server.
		/// </summary>
		public override void Close()
		{
			try
			{
				// Lock the mutex (only one state changing operation allowed at one time).
				this.mutex.WaitOne();
				// Close the database connection.
				this.connection.Close();
			}
			finally
			{
				// Unlock the mutex.
				this.mutex.ReleaseMutex();
			}
		}

		/// <summary>
		/// Closes the connection to the database server asynchronously.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="userState">The user state.</param>
		/// <returns>The asynchronous result.</returns>
		public override IAsyncResult CloseAsync(DbServerCallback callback, object userState = null)
		{
			// Call the event handler.
			base.OnClosing();
			// Create a new asynchrounous state for this operation.
			DbServerAsyncState asyncState = new DbServerAsyncState(userState);
			// Begin open the connection asynchronously on the thread pool.
			ThreadPool.QueueUserWorkItem((object state) =>
				{
					// Execute asynchronously on the thread pool.
					try
					{
						// Close the connection.
						this.Close();
					}
					catch (Exception exception)
					{
						// If an exception occurs, set the callback exception.
						asyncState.Exception = exception;
					}
					// Complete the asynchronous operation.
					asyncState.Complete();
					// Call the callback method with the given state.
					if (callback != null) callback(asyncState);
				});
			return asyncState;
		}

		// Protected methods.

		/// <summary>
		/// A  method called when the server object is being disposed.
		/// </summary>
		protected sealed override void OnDispose()
		{
			// If the server connection is not closed.
			if (this.connection.State != ConnectionState.Closed)
			{
				// Close the server connection synchronously.
				this.Close();
			}
			// Call the base class method.
			base.OnDispose();
		}

		// Private methods.

		/// <summary>
		/// Initializes the server configuration.
		/// </summary>
		private void Initialize()
		{
			// Create the connection string for this server.
			this.connectionString.DataSource = this.DataSource;
			this.connectionString.UserID = this.Username;
			this.connectionString.Password = this.Password;

			// Set the connection for the connection string.
			this.connection.ConnectionString = this.connectionString.ConnectionString;
		}

		/// <summary>
		/// An event handler called when the state of the connection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private new void OnStateChanged(object sender, StateChangeEventArgs e)
		{
			// Call the base class event handler.
			base.OnStateChanged(sender, e);
		}
	}
}
