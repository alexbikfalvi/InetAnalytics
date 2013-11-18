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
using System.Security;
using System.Threading;
using Microsoft.Win32;
using DotNetApi;
using InetCrawler.Database.Data;
using InetCrawler.Log;

namespace InetCrawler.Database
{
	/// <summary>
	/// A class representing a database server.
	/// </summary>
	public abstract class DbServer : IDisposable
	{
		/// <summary>
		/// An enumeration that specifies the current server state.
		/// </summary>
		public enum ServerState
		{
			Disconnected = 0,
			Connected = 1,
			Failed = 2,
			Connecting = 3,
			Disconnecting = 4,
			Busy = 5
		};

		// Config.
		protected RegistryKey key;

		// Settings.
		private string id;
		private string name;
		private string dataSource;
		private string username;
		private SecureString password;
		private DateTime dateCreated;
		private DateTime dateModified;

		// State.
		private ServerState state = ServerState.Disconnected;

		// Log.
		protected Logger log;
		protected string logSource;

		// Database tables and relationships.
		private DbTables tables;
		private DbRelationships relationships;

		/// <summary>
		/// Creates a database server with the specified name and configuration.
		/// </summary>
		/// <param name="key">The registry configuration key.</param>
		/// <param name="id">The server ID.</param>
		/// <param name="logFile">The log file for this database server.</param>
		public DbServer(RegistryKey key, string id, string logFile)
		{
			// Set the server ID.
			this.id = id;

			// Set the root registry key for this server.
			this.key = key;

			// Create the logger for this server.
			this.log = new Logger(logFile);
			this.log.EventLogged += this.OnLog;
			this.logSource = @"Database\{0}".FormatWith(this.id);

			// Create the database tables and relationships.
			this.tables = new DbTables(this.key);
			this.relationships = new DbRelationships(this.key, this.tables);

			// Set the event handlers.
			this.tables.TableChanged += this.OnTableChanged;

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
		public DbServer(
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
		{
			// Save the parameters.
			this.key = key;
			this.id = id;
			this.name = name;
			this.dataSource = dataSource;
			this.username = username;
			this.password = password;
			this.dateCreated = dateCreated;
			this.dateModified = dateModified;

			// Create the logger for this server.
			this.log = new Logger(logFile);
			this.log.EventLogged += this.OnLog;
			this.logSource = @"Database\{0}".FormatWith(this.id);

			// Create the database tables and relationships.
			this.tables = new DbTables(this.key);
			this.relationships = new DbRelationships(this.key, this.tables);

			// Save the configuration.
			this.SaveInternalConfiguration();
		}


		// Public properties.

		/// <summary>
		/// Gets the ID of the current database server.
		/// </summary>
		public string Id { get { return this.id; } }
		/// <summary>
		/// Gets the type of the current database server.
		/// </summary>
		public abstract DbConfig.DbServerType Type { get; }
		/// <summary>
		/// Gets or sets the server name.
		/// </summary>
		public string Name
		{
			get { return this.name; }
			set { this.name = value; this.OnServerChanged(); }
		}
		/// <summary>
		/// Gets or sets the server data source.
		/// </summary>
		public string DataSource
		{
			get { return this.dataSource; }
			set { this.dataSource = value; this.OnServerChanged(); }
		}
		/// <summary>
		/// Gets or sets the server username.
		/// </summary>
		public string Username
		{
			get { return this.username; }
			set { this.username = value; this.OnServerChanged(); }
		}
		/// <summary>
		/// Gets or sets the server password.
		/// </summary>
		public SecureString Password
		{
			get { return this.password; }
			set { this.password = value; this.OnServerChanged(); }
		}
		/// <summary>
		/// Gets the date when the server was created.
		/// </summary>
		public DateTime DateCreated { get { return this.dateCreated; } }
		/// <summary>
		/// Gets the date when the server was last modified.
		/// </summary>
		public DateTime DateModified { get { return this.dateModified; } }
		/// <summary>
		/// Gets the server state.
		/// </summary>
		public ServerState State { get { return this.state; } }
		/// <summary>
		/// Gets the server version.
		/// </summary>
		public abstract string Version { get; }
		/// <summary>
		/// Gets the log for this database server.
		/// </summary>
		public Logger Log { get { return this.log; } }
		/// <summary>
		/// Gets the default database for this server.
		/// </summary>
		public abstract DbObjectDatabase Database { get; set; }
		/// <summary>
		/// Gets the list of database tables for this database server.
		/// </summary>
		public DbTables Tables { get { return this.tables; } }
		/// <summary>
		/// Gets the list of database relationships for this database server.
		/// </summary>
		public DbRelationships Relationships { get { return this.relationships; } }
		/// <summary>
		/// Gets the database table for this server.
		/// </summary>
		public abstract ITable TableDatabase { get; }
		/// <summary>
		/// Gets the schema table for this server.
		/// </summary>
		public abstract ITable TableSchema { get; }
		/// <summary>
		/// Gets the type table for this server.
		/// </summary>
		public abstract ITable TableTypes { get; }
		/// <summary>
		/// Gets the tables table for this server.
		/// </summary>
		public abstract ITable TableTables { get; }
		/// <summary>
		/// Gets the columns table for this server.
		/// </summary>
		public abstract ITable TableColumns { get; }

		// Public events.

		/// <summary>
		/// An event raised when the configuration of the server has changed.
		/// </summary>
		public event DbServerEventHandler ServerChanged;
		/// <summary>
		/// An event raised when the server connection state has changed.
		/// </summary>
		public event DbServerStateEventHandler StateChanged;
		/// <summary>
		/// An event raised when the server default database has changed.
		/// </summary>
		public event DbServerDatabaseChangedEventHandler DatabaseChanged;
		/// <summary>
		/// An event raised when a server database table has changed.
		/// </summary>
		public event DbServerTableChangedEventHandler TableChanged;
		/// <summary>
		/// An event raised when the server begins opening the connection.
		/// </summary>
		public event DbServerEventHandler Opening;
		/// <summary>
		/// An event raised when the server begins reopening the connection.
		/// </summary>
		public event DbServerEventHandler Reopening;
		/// <summary>
		/// An event raised when the server begins closing the connection.
		/// </summary>
		public event DbServerEventHandler Closing;
		/// <summary>
		/// An event raised when a new server event has been logged.
		/// </summary>
		public event LogEventHandler EventLogged;

		// Public methods.

		/// <summary>
		/// Disposes the server object by closing the connection.
		/// </summary>
		public void Dispose()
		{
			// Dispose the server.
			this.Dispose(true);
			// Suppress the finalizer for this object.
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Adds a new event to the event log for the current date/time.
		/// </summary>
		/// <param name="level">The log event level.</param>
		/// <param name="type">The log event type.</param>
		/// <param name="message">The event message.</param>
		/// <param name="parameters">The event parameters.</param>
		/// <param name="exception">The event exception.</param>
		/// <param name="subevents">The list of subevents.</param>
		/// <returns>The log event.</returns>
		public void LogEvent(
			LogEventLevel level,
			LogEventType type,
			string message,
			object[] parameters = null,
			Exception exception = null,
			List<LogEvent> subevents = null
			)
		{
			this.log.Add(level, type, this.logSource, message, parameters, exception, subevents);
		}

		/// <summary>
		/// Loads the server configuration.
		/// </summary>
		public virtual void LoadConfiguration()
		{
			this.LoadInternalConfiguration();
		}

		/// <summary>
		/// Saves the server configuration.
		/// </summary>
		public virtual void SaveConfiguration()
		{
			this.SaveInternalConfiguration();
		}

		/// <summary>
		/// Opens the connection to the database server synchronously.
		/// </summary>
		public abstract void Open();

		/// <summary>
		/// Opens the connection to the database server asynchronously.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="userState">The user state.</param>
		/// <returns>The asynchronous result.</returns>
		public abstract IAsyncResult Open(DbServerCallback callback, object userState = null);

		/// <summary>
		/// Reopens the connection to the database asynchronously.
		/// </summary>
		public abstract void Reopen();

		/// <summary>
		/// Reopens the connection to the database server asynchronously.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="userState">The user state.</param>
		/// <returns>The asynchronous result.</returns>
		public abstract IAsyncResult Reopen(DbServerCallback callback, object userState = null);

		/// <summary>
		/// Closes the connection to the database server asynchronously.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="userState">The user state.</param>
		/// <returns>The asynchronous result.</returns>
		public abstract IAsyncResult Close(DbServerCallback callback, object userState = null);

		/// <summary>
		/// Changes the current password of the database server asynchronously.
		/// </summary>
		/// <param name="newPassword">The new password.</param>
		/// <param name="callback">The callback method.</param>
		/// <param name="userState">The user state.</param>
		/// <returns>The asynchronous result.</returns>
		public abstract IAsyncResult ChangePassword(SecureString newPassword, DbServerCallback callback, object userState = null);

		/// <summary>
		/// Creates a new database command with the specified query.
		/// </summary>
		/// <param name="query">The database query.</param>
		/// <returns>The database command.</returns>
		public abstract DbCommand CreateCommand(DbQuery query);

		/// <summary>
		/// Creates a new database command with the specified query and transaction.
		/// </summary>
		/// <param name="query">The database query.</param>
		/// <param name="transaction">The database transaction.</param>
		/// <returns>The database command.</returns>
		public abstract DbCommand CreateCommand(DbQuery query, DbTransaction transaction);

		/// <summary>
		/// Creates and begins a new database transaction.
		/// </summary>
		/// <param name="isolation">The transaction isolation level.</param>
		/// <returns>A transaction object to use with subsequent commands within the transaction.</returns>
		public abstract DbTransaction BeginTransaction(IsolationLevel isolation);

		// Protected methods.

		/// <summary>
		/// A method called when the server object is being initialized.
		/// </summary>
		protected abstract void OnInitialized();

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		/// <param name="disposing">If <b>true</b>, clean both managed and native resources. If <b>false</b>, clean only native resources.</param>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				// Dispose the log.
				this.log.Dispose();
				// Dispose the database tables.
				this.tables.Dispose();
				// Close the registry key.
				this.key.Close();
			}
		}

		/// <summary>
		/// An event handler called when the server configuration has changed.
		/// </summary>
		protected void OnServerChanged()
		{
			// Call the event.
			if (this.ServerChanged != null) this.ServerChanged(this, new DbServerEventArgs(this));
		}

		/// <summary>
		/// An event handler called when the state of the connection has changed.
		/// </summary>
		/// <param name="state">The new server state.</param>
		/// <param name="e">The event arguments.</param>
		protected void OnStateChange(DbServer.ServerState state)
		{
			// Save the old state.
			DbServer.ServerState oldState = this.state;
			// Set the new state.
			this.state = state;
			// Call the event.
			if(this.StateChanged != null) this.StateChanged(this, new DbServerStateEventArgs(this, oldState, this.state));
		}

		/// <summary>
		/// An event handler called when the current database has changed.
		/// </summary>
		/// <param name="oldDatabase">The old database.</param>
		/// <param name="newDatabase">The new database.</param>
		protected void OnDatabaseChanged(DbObjectDatabase oldDatabase, DbObjectDatabase newDatabase)
		{
			// Call the event.
			if (this.DatabaseChanged != null) this.DatabaseChanged(this, new DbServerDatabaseChangedEventArgs(this, oldDatabase, newDatabase));
		}

		/// <summary>
		/// An event handler called when the server begins opening the connection.
		/// </summary>
		protected void OnOpening()
		{
			// Call the event.
			if (this.Opening != null) this.Opening(this, new DbServerEventArgs(this));
		}

		/// <summary>
		/// An event handler called when the server begins reopening the connection.
		/// </summary>
		protected void OnReopening()
		{
			// Call the event.
			if (this.Reopening != null) this.Reopening(this, new DbServerEventArgs(this));
		}

		/// <summary>
		/// An event handler called when the server begins closing the connection.
		/// </summary>
		protected void OnClosing()
		{
			// Call the event.
			if (this.Closing != null) this.Closing(this, new DbServerEventArgs(this));
		}

		/// <summary>
		/// An event handler called when the server logs a new event.
		/// </summary>
		/// <param name="server">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		protected void OnLog(object sender, LogEventArgs e)
		{
			// Call the event.
			if (this.EventLogged != null) this.EventLogged(this, e);
		}

		// Private methods.

		/// <summary>
		/// Saves the current server configuration to the registry.
		/// </summary>
		private void SaveInternalConfiguration()
		{
			// Update the modification date.
			this.dateModified = DateTime.Now;

			// Save basic configuration.
			DotNetApi.Windows.Registry.SetString(this.key.Name, "Name", this.name);
			DotNetApi.Windows.Registry.SetString(this.key.Name, "DataSource", this.dataSource);
			DotNetApi.Windows.Registry.SetString(this.key.Name, "Username", this.username);
			DotNetApi.Windows.Registry.SetSecureString(this.key.Name, "Password", this.password, CrawlerConfig.cryptoKey, CrawlerConfig.cryptoIV);
			DotNetApi.Windows.Registry.SetDateTime(this.key.Name, "DateCreated", this.dateCreated);
			DotNetApi.Windows.Registry.SetDateTime(this.key.Name, "DateModified", this.dateModified);

			// Save tables and relationship configuration.
			this.tables.SaveConfiguration();
			this.relationships.SaveConfiguration();

			// Log the event.
			this.log.Add(
				LogEventLevel.Normal,
				LogEventType.Success,
				this.logSource,
				"Configuration for database server with ID \'{0}\' was saved to registry. Some changes will take effect the next time you connect.",
				new object[] { this.Id }
				);
		}

		/// <summary>
		/// Loads the current server configuration from the registry.
		/// </summary>
		private void LoadInternalConfiguration()
		{
			// Load basic configuration.
			this.name = DotNetApi.Windows.Registry.GetString(this.key.Name, "Name", null);
			this.dataSource = DotNetApi.Windows.Registry.GetString(this.key.Name, "DataSource", null);
			this.username = DotNetApi.Windows.Registry.GetString(this.key.Name, "Username", null);
			this.password = DotNetApi.Windows.Registry.GetSecureString(this.key.Name, "Password", null, CrawlerConfig.cryptoKey, CrawlerConfig.cryptoIV);
			this.dateCreated = DotNetApi.Windows.Registry.GetDateTime(this.key.Name, "DateCreated", DateTime.Now);
			this.dateModified = DotNetApi.Windows.Registry.GetDateTime(this.key.Name, "DateModified", DateTime.Now);

			// Load tables and relationships configuration.
			this.tables.LoadConfiguration();
			this.relationships.LoadConfiguration();

			// Log the event.
			this.log.Add(
				LogEventLevel.Normal,
				LogEventType.Success,
				this.logSource,
				"Configuration for database server with ID \'{0}\' was loaded from registry. The server name is \'{1}\'.",
				new object[] { this.Id, this.Name }
				);
		}

		/// <summary>
		/// An event handler called when a database table has changed.
		/// </summary>
		/// <param name="server">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnTableChanged(object sender, DbTableEventArgs e)
		{
			// Raise the server event.
			if (this.TableChanged != null) this.TableChanged(this, new DbServerTableChangedEventArgs(this, e.Table));
		}
	}
}
