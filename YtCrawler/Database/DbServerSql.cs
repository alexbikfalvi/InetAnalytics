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
using YtCrawler.Log;
using Microsoft.Win32;

namespace YtCrawler.Database
{
	/// <summary>
	/// A class representing a Microsoft SQL Server.
	/// </summary>
	public sealed class DbServerSql : DbServer
	{
		private SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder();
		private SqlConnection connection = new SqlConnection();
		private Mutex mutex = new Mutex();

		private DbDatabase database = null;

		/// <summary>
		/// Creates a new server instance.
		/// </summary>
		/// <param name="key">The registry configuration key.</param>
		/// <param name="id">The server ID.</param>
		/// <param name="logFile">The log file for this database server.</param>
		public DbServerSql(string key, string id, string logFile)
			: base(key, id, logFile)
		{
			// Initialize the server with the current configuration.
			this.OnInitialized();
			// Set the event handler for the connection state.
			this.connection.StateChange += this.OnConnectionStateChanged;
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
		/// <param name="logFile">The log file for this database server.</param>
		/// <param name="dateCreated">The date when the server was created.</param>
		/// <param name="dateModified">The date when the server was last modified.</param>
		public DbServerSql(
			string key,
			string id,
			string name,
			string dataSource,
			string username,
			string password,
			string logFile,
			DateTime dateCreated,
			DateTime dateModified
			)
			: base(key, id, name, dataSource, username, password, logFile, dateCreated, dateModified)
		{
			// Initialize the server with the current configuration.
			this.OnInitialized();
			// Set the event handler for the connection state.
			this.connection.StateChange += this.OnConnectionStateChanged;
		}

		// Public properties.

		/// <summary>
		/// Gets the type of the database server.
		/// </summary>
		public override DbServers.DbServerType Type { get { return DbServers.DbServerType.MsSql; } }
		/// <summary>
		/// Gets the server version.
		/// </summary>
		public override string Version
		{
			get
			{
				try
				{
					switch (this.connection.State)
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
		/// <summary>
		/// Gets the default database for this database server.
		/// </summary>
		public override DbDatabase Database { get { return this.database; } }
		/// <summary>
		/// Gets the query for the server databases.
		/// </summary>
		public override string QueryDatabases { get { return "SELECT [name],[database_id],[create_date] FROM [master].[sys].[databases]"; } }


		// Public methods.

		/// <summary>
		/// Saves the current server configuration to the registry.
		/// </summary>
		public override void SaveConfiguration()
		{
			// Load the default database.
			try { this.database = DbDatabaseSql.Load(this.key); }
			catch (Exception) { this.database = null; }

			// Call the base class method.
			base.SaveConfiguration();
		}

		/// <summary>
		/// Loads the current server configuration from the registry.
		/// </summary>
		public override void LoadConfiguration()
		{
			// Call the base class method.
			base.LoadConfiguration();
		}

		/// <summary>
		/// Opens the connection to the database server.
		/// </summary>
		public override void Open()
		{
			// Call the event handler.
			base.OnOpening();
			try
			{
				// Lock the mutex (only one state changing operation allowed at one time).
				this.mutex.WaitOne();
				// Change the state of the server to connecting.
				base.OnStateChange(ServerState.Connecting);
				// Log the event.
				this.log.Add(
					LogEventLevel.Verbose,
					LogEventType.Information,
					this.logSource,
					"Connecting to the database server with ID \'{0}\'.",
					new object[] { this.Id }
					);
				// Open the database connection.
				this.connection.Open();
				// Log the event.
				this.log.Add(
					LogEventLevel.Normal,
					LogEventType.Success,
					this.logSource,
					"Connected to the database server with ID \'{0}\'.",
					new object[] { this.Id }
					);
			}
			catch (SqlException exception)
			{
				// Change the state of the server to connecting.
				base.OnStateChange(ServerState.Failed);
				// Log the event.
				this.log.Add(
					LogEventLevel.Important,
					LogEventType.Error,
					this.logSource,
					"Opening the connection to the database server with ID \'{0}\' failed. {1}",
					new object[] { this.Id, exception.Message },
					exception
					);
				// Rethrow the exception;
				throw exception;
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
		public override IAsyncResult Open(DbServerCallback callback, object userState = null)
		{
			// Create a new asynchrounous state for this operation.
			DbServerAsyncState asyncState = new DbServerAsyncState(this, userState);
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
						asyncState.Exception = new DbException(string.Format("Opening the connection to the database server \'{0}\' failed.", this.Name), exception);
					}
					// Complete the asynchronous operation.
					asyncState.Complete();
					// Call the callback method with the given state.
					if (callback != null) callback(asyncState);
				});
			return asyncState;
		}

		/// <summary>
		/// Reopens the connection to the database asynchronously.
		/// </summary>
		public override void Reopen()
		{
			// Call the event handler.
			base.OnReopening();
			try
			{
				// Lock the mutex (only one state changing operation allowed at one time).
				this.mutex.WaitOne();
				// Change the state of the server to disconnecting.
				base.OnStateChange(ServerState.Disconnecting);
				// Log the event.
				this.log.Add(
					LogEventLevel.Verbose,
					LogEventType.Information,
					this.logSource,
					"Reconnecting to the database server with ID \'{0}\'.",
					new object[] { this.Id }
					);
				// Open the database connection.
				this.connection.Close();
				// Change the state of the server to connecting.
				base.OnStateChange(ServerState.Connecting);
				// Open the database connection.
				this.connection.Open();
				// Log the event.
				this.log.Add(
					LogEventLevel.Normal,
					LogEventType.Success,
					this.logSource,
					"Reconnected to the database server with ID \'{0}\'.",
					new object[] { this.Id }
					);
			}
			catch (SqlException exception)
			{
				// Change the state of the server to connecting.
				base.OnStateChange(ServerState.Failed);
				// Log the event.
				this.log.Add(
					LogEventLevel.Important,
					LogEventType.Error,
					this.logSource,
					"Reopening the connection to the database server with ID \'{0}\' failed. {1}",
					new object[] { this.Id, exception.Message },
					exception
					);
				// Rethrow the exception;
				throw exception;
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
		public override IAsyncResult Reopen(DbServerCallback callback, object userState = null)
		{
			// Create a new asynchrounous state for this operation.
			DbServerAsyncState asyncState = new DbServerAsyncState(this, userState);
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
						asyncState.Exception = new DbException(string.Format("Reopening the connection to the database server \'{0}\' failed.", this.Name), exception);
					}
					// Complete the asynchronous operation.
					asyncState.Complete();
					// Call the callback method with the given state.
					if (callback != null) callback(asyncState);
				});
			return asyncState;
		}

		/// <summary>
		/// Closes the connection to the database server synchronously.
		/// </summary>
		private void Close()
		{
			// Call the event handler.
			base.OnClosing();
			try
			{
				// Lock the mutex (only one state changing operation allowed at one time).
				this.mutex.WaitOne();
				// Change the state of the server to disconnecting.
				base.OnStateChange(ServerState.Disconnecting);
				// Log the event.
				this.log.Add(
					LogEventLevel.Verbose,
					LogEventType.Information,
					this.logSource,
					"Disconnecting from the database server with ID \'{0}\'.",
					new object[] { this.Id }
					);
				// Close the database connection.
				this.connection.Close();
				// Log the event.
				this.log.Add(
					LogEventLevel.Normal,
					LogEventType.Success,
					this.logSource,
					"Disconnected from the database server with ID \'{0}\'.",
					new object[] { this.Id }
					);
			}
			catch (SqlException exception)
			{
				// Change the state of the server to connecting.
				base.OnStateChange(ServerState.Failed);
				// Log the event.
				this.log.Add(
					LogEventLevel.Important,
					LogEventType.Error,
					this.logSource,
					"Disconnecting from the database server with ID \'{0}\' failed. {1}",
					new object[] { this.Id, exception.Message },
					exception
					);
				// Rethrow the exception;
				throw exception;
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
		public override IAsyncResult Close(DbServerCallback callback, object userState = null)
		{
			// Create a new asynchrounous state for this operation.
			DbServerAsyncState asyncState = new DbServerAsyncState(this, userState);
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
						asyncState.Exception = new DbException(string.Format("Closing the connection to the database server \'{0}\' failed.", this.Name), exception); ;
					}
					// Complete the asynchronous operation.
					asyncState.Complete();
					// Call the callback method with the given state.
					if (callback != null) callback(asyncState);
				});
			return asyncState;
		}

		/// <summary>
		/// Changes the current password of the database server.
		/// </summary>
		/// <param name="newPassword">The new password.</param>
		private void ChangePassword(string newPassword)
		{
			try
			{
				// Lock the mutex (only one state changing operation allowed at one time).
				this.mutex.WaitOne();
				// Change the server password.
				SqlConnection.ChangePassword(this.connectionString.ConnectionString, newPassword);
				// If the password change was successfull, update the configuration.
				this.Password = newPassword;
				// Log the event.
				this.log.Add(
					LogEventLevel.Verbose,
					LogEventType.Information,
					this.logSource,
					"Changing the password for the database server with ID \'{0}\' completed successfully.",
					new object[] { this.Id }
					);
				// Save the configuration.
				this.SaveConfiguration();
			}
			catch (Exception exception)
			{
				// Log the event.
				this.log.Add(
					LogEventLevel.Important,
					LogEventType.Error,
					this.logSource,
					"Changing the password for the database server with ID \'{0}\' failed. {1}",
					new object[] { this.Id, exception.Message },
					exception
					);
				// Rethrow the exception.
				throw exception;
			}
			finally
			{
				// Unlock the mutex.
				this.mutex.ReleaseMutex();
			}
		}

		/// <summary>
		/// Changes the current password of the database server asynchronously.
		/// </summary>
		/// <param name="newPassword">The new password.</param>
		/// <param name="callback">The callback method.</param>
		/// <param name="userState">The user state.</param>
		/// <returns>The asynchronous result.</returns>
		public override IAsyncResult ChangePassword(string newPassword, DbServerCallback callback, object userState = null)
		{
			// Create a new asynchrounous state for this operation.
			DbServerAsyncState asyncState = new DbServerAsyncState(this, userState);
			// Begin changing the password asynchronously on the thread pool.
			ThreadPool.QueueUserWorkItem((object state) =>
			{
				// Execute asynchronously on the thread pool.
				try
				{
					// Change the database server password.
					this.ChangePassword(newPassword);
				}
				catch (Exception exception)
				{
					// If an exception occurs, set the callback exception.
					asyncState.Exception = new DbException(string.Format("Changing the password for the database server \'{0}\' failed.", this.Name), exception); ;
				}
				// Complete the asynchronous operation.
				asyncState.Complete();
				// Call the callback method with the given state.
				if (callback != null) callback(asyncState);
			});
			return asyncState;
		}

		/// <summary>
		/// Creates a new database command with the specified query.
		/// </summary>
		/// <param name="query">The database query.</param>
		/// <param name="userState">The user state.</param>
		/// <returns>The database command.</returns>
		public override DbCommand CreateCommand(string query, object userState = null)
		{
			return new DbCommandSql(this.connection, query, userState);
		}

		/// <summary>
		/// Creates a database entry from the table data found at the specified index.
		/// </summary>
		/// <param name="data">The table data.</param>
		/// <param name="index">The row index.</param>
		/// <returns>The database instance.</returns>
		public override DbDatabase CreateDatabase(DbTable data, int index)
		{
			return DbDatabaseSql.Read(data, index);
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
		protected sealed override void OnInitialized()
		{
			// Create the connection string for this server.
			this.connectionString.DataSource = this.DataSource;
			this.connectionString.UserID = this.Username;
			this.connectionString.Password = this.Password;

			// Set the connection for the connection string.
			this.connection.ConnectionString = this.connectionString.ConnectionString;
		}

		/// <summary>
		/// An event handler called when the state of the database connection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnConnectionStateChanged(object sender, StateChangeEventArgs e)
		{
			switch (e.CurrentState)
			{
				case ConnectionState.Connecting:
					this.OnStateChange(ServerState.Connecting);
					break;
				case ConnectionState.Open:
				case ConnectionState.Executing:
				case ConnectionState.Fetching:
					this.OnStateChange(ServerState.Connected);
					break;
				case ConnectionState.Closed:
					this.OnStateChange(ServerState.Disconnected);
					break;
				case ConnectionState.Broken:
					this.OnStateChange(ServerState.Failed);
					break;
			}
		}
	}
}
