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
using System.Data;
using System.Data.SqlClient;
using System.Security;
using System.Text;
using System.Threading;
using Microsoft.Win32;
using DotNetApi;
using DotNetApi.Security;
using YtCrawler.Log;
using YtCrawler.Database.Data;

namespace YtCrawler.Database
{
	/// <summary>
	/// A class representing an SQL Server.
	/// </summary>
	public sealed class DbServerSql : DbServer
	{
		private SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder();
		private SqlConnection connection = new SqlConnection();
		private Mutex mutex = new Mutex();

		private DbObjectDatabase database = null;

		// SQL Server tables.
		private DbTable<DbObjectSqlDatabase> tableDatabases = new DbTable<DbObjectSqlDatabase>("Databases", "databases", "sys", "master", false);
		private DbTable<DbObjectSqlType> tableTypes = new DbTable<DbObjectSqlType>("Types", "types", "sys", "master", false);
		private DbTable<DbObjectSqlSchema> tableSchema = new DbTable<DbObjectSqlSchema>("Schemas", "schemas", "sys", "master", false);
		private DbTable<DbObjectSqlTable> tableTables = new DbTable<DbObjectSqlTable>("Tables", "tables", "sys", "master", true);
		private DbTable<DbObjectSqlColumn> tableColumns = new DbTable<DbObjectSqlColumn>("Columns", "columns", "sys", "master", true);

		/// <summary>
		/// Creates a new server instance.
		/// </summary>
		/// <param name="key">The registry configuration key.</param>
		/// <param name="id">The server ID.</param>
		/// <param name="logFile">The log file for this database server.</param>
		public DbServerSql(RegistryKey key, string id, string logFile)
			: base(key, id, logFile)
		{
			// Initialize the server with the current configuration.
			this.OnInitialized();
			// Set the event handler for the connection state.
			this.connection.StateChange += this.OnConnectionStateChanged;
			// Add tables to the tables list.
			this.Tables.Add(this.tableDatabases);
			this.Tables.Add(this.tableSchema);
			this.Tables.Add(this.tableTypes);
			this.Tables.Add(this.tableTables);
			this.Tables.Add(this.tableColumns);
			// Add relationships to the tables list.
			this.Relationships.Add(this.tableSchema, this.tableTables, "SchemaId", "SchemaId");
			this.Relationships.Add(this.tableColumns, this.tableTables, "ObjectId", "ObjectId");
			this.Relationships.Add(this.tableTypes, this.tableColumns, "SystemTypeId", "SystemTypeId");
			this.Relationships.Add(this.tableTypes, this.tableColumns, "UserTypeId", "UserTypeId");

			// Load the current configuration.
			this.LoadInternalConfiguration();
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
			RegistryKey key,
			string id,
			string name,
			string dataSource,
			string username,
			SecureString password,
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
			// Add tables to the tables list.
			this.Tables.Add(this.tableDatabases);
			this.Tables.Add(this.tableSchema);
			this.Tables.Add(this.tableTypes);
			this.Tables.Add(this.tableTables);
			this.Tables.Add(this.tableColumns);
			// Add relationships to the tables list.
			this.Relationships.Add(this.tableSchema, this.tableTables, "SchemaId", "SchemaId");
			this.Relationships.Add(this.tableColumns, this.tableTables, "ObjectId", "ObjectId");

			// Save the configuration.
			this.SaveInternalConfiguration();
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
		public override DbObjectDatabase Database
		{
			get { return this.database; }
			set
			{
				// Save the old database.
				DbObjectDatabase oldDb = this.database;
				// Change the current database.
				this.database = value;
				// Raise a database change event.
				this.OnDatabaseChanged(oldDb, value);
				// Save the configuration.
				this.SaveConfiguration();
			}
		}
		/// <summary>
		/// Gets the database table for this server.
		/// </summary>
		public override ITable TableDatabase { get { return this.tableDatabases; } }
		/// <summary>
		/// Gets the schema table for this server.
		/// </summary>
		public override ITable TableSchema { get { return this.tableSchema; } }
		/// <summary>
		/// Gets the type table for this server.
		/// </summary>
		public override ITable TableTypes { get { return this.tableTypes; } }
		/// <summary>
		/// Gets the tables table for this server.
		/// </summary>
		public override ITable TableTables { get { return this.tableTables; } }
		/// <summary>
		/// Gets the columns table for this server.
		/// </summary>
		public override ITable TableColumns { get { return this.tableColumns; } }

		// Public methods.


		/// <summary>
		/// Loads the server configuration.
		/// </summary>
		public override void LoadConfiguration()
		{
			// Load the base configuration.
			base.LoadConfiguration();
			// Load the custom configuration.
			this.LoadInternalConfiguration();
		}

		/// <summary>
		/// Saves the server configuration.
		/// </summary>
		public override void SaveConfiguration()
		{
			// Save the base configuration.
			base.SaveConfiguration();
			// Save the custom configuration.
			this.SaveInternalConfiguration();
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
				// Initialize the server.
				this.OnInitialized();
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
				// Rethrow the exception.
				throw;
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
						asyncState.Exception = new DbException("Opening the connection to the database server \'{0}\' failed.".FormatWith(this.Name), exception);
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
				// Initialize the server.
				this.OnInitialized();
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
				// Rethrow the exception.
				throw;
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
						asyncState.Exception = new DbException("Reopening the connection to the database server \'{0}\' failed.".FormatWith(this.Name), exception);
					}
					// Complete the asynchronous operation.
					asyncState.Complete();
					// Call the callback method with the given state.
					if (callback != null) callback(asyncState);
				});
			return asyncState;
		}

		// Private methods.

		/// <summary>
		/// Saves the current server configuration to the registry.
		/// </summary>
		private void SaveInternalConfiguration()
		{
			// Save the default databas
			if (this.database != null) DbObject.SaveToRegistry<DbObjectSqlDatabase>(this.database as DbObjectSqlDatabase, this.key.Name, "Database");
		}

		/// <summary>
		/// Loads the current server configuration from the registry.
		/// </summary>
		private void LoadInternalConfiguration()
		{
			// Load the default database.
			this.database = DbObject.CreateFromRegistry<DbObjectSqlDatabase>(this.key.Name, "Database");
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
				// Rethrow the exception.
				throw;
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
						asyncState.Exception = new DbException("Closing the connection to the database server \'{0}\' failed.".FormatWith(this.Name), exception); ;
					}
					// Complete the asynchronous operation.
					asyncState.Complete();
					// Call the callback method with the given state.
					if (callback != null) callback(asyncState);
				});
			return asyncState;
		}

		/// <summary>
		/// Changes the current password of the database server asynchronously.
		/// </summary>
		/// <param name="newPassword">The new password.</param>
		/// <param name="callback">The callback method.</param>
		/// <param name="userState">The user state.</param>
		/// <returns>The asynchronous result.</returns>
		public override IAsyncResult ChangePassword(SecureString newPassword, DbServerCallback callback, object userState = null)
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
					asyncState.Exception = new DbException("Changing the password for the database server \'{0}\' failed.".FormatWith(this.Name), exception); ;
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
		/// <returns>The database command.</returns>
		public override DbCommand CreateCommand(DbQuery query)
		{
			return new DbCommandSql(this.connection, query);
		}

		/// <summary>
		/// Creates a new database command with the specified query and transaction.
		/// </summary>
		/// <param name="query">The database query.</param>
		/// <param name="transaction">The database transaction.</param>
		/// <returns>The database command.</returns>
		public override DbCommand CreateCommand(DbQuery query, DbTransaction transaction)
		{
			return new DbCommandSql(this.connection, query, transaction as DbTransactionSql);
		}

		/// <summary>
		/// Creates and begins a new database transaction.
		/// </summary>
		/// <param name="isolation">The transaction isolation level.</param>
		/// <returns>A transaction object to use with subsequent commands within the transaction.</returns>
		public override DbTransaction BeginTransaction(IsolationLevel isolation)
		{
			return new DbTransactionSql(this.connection, isolation);
		}

		// Protected methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		/// <param name="disposing">If <b>true</b>, clean both managed and native resources. If <b>false</b>, clean only native resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				// If the server connection is not closed.
				if (this.connection.State != ConnectionState.Closed)
				{
					// Close the server connection synchronously.
					this.Close();
				}
				// Dispose the mutex.
				this.mutex.Dispose();
			}
			// Call the base class method.
			base.Dispose(disposing);
		}

		/// <summary>
		/// Initializes the server configuration.
		/// </summary>
		protected sealed override void OnInitialized()
		{
			// Create the connection string for this server.
			this.connectionString.DataSource = this.DataSource;
			this.connectionString.UserID = this.Username;
			this.connectionString.Password = this.Password.ConvertToUnsecureString();

			// Set the connection for the connection string.
			this.connection.ConnectionString = this.connectionString.ConnectionString;
		}

		// Private methods.

		/// <summary>
		/// Changes the current password of the database server.
		/// </summary>
		/// <param name="newPassword">The new password.</param>
		private void ChangePassword(SecureString newPassword)
		{
			try
			{
				// Lock the mutex (only one state changing operation allowed at one time).
				this.mutex.WaitOne();
				// Initialize the server.
				this.OnInitialized();
				// Change the server password.
				SqlConnection.ChangePassword(this.connectionString.ConnectionString, newPassword.ConvertToUnsecureString());
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
				throw;
			}
			finally
			{
				// Unlock the mutex.
				this.mutex.ReleaseMutex();
			}
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
					this.OnStateChange(ServerState.Connected);
					break;
				case ConnectionState.Closed:
					this.OnStateChange(ServerState.Disconnected);
					break;
				case ConnectionState.Broken:
					this.OnStateChange(ServerState.Failed);
					break;
				case ConnectionState.Executing:
				case ConnectionState.Fetching:
					this.OnStateChange(ServerState.Busy);
					break;
			}
		}
	}
}
