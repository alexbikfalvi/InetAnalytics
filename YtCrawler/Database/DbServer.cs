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
using System.Threading;
using Microsoft.Win32;
using YtCrawler.Log;

namespace YtCrawler.Database
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
			Disconnecting = 4
		};

		// Config.
		protected string key;

		// Settings.
		private string id;
		private string name;
		private string dataSource;
		private string username;
		private string password;
		private DateTime dateCreated;
		private DateTime dateModified;

		// State.
		private ServerState state = ServerState.Disconnected;

		// Log.
		protected Logger log;
		protected string logSource;

		/// <summary>
		/// Creates a database server with the specified name and configuration.
		/// </summary>
		/// <param name="key">The registry configuration key.</param>
		/// <param name="id">The server ID.</param>
		/// <param name="logFile">The log file for this database server.</param>
		public DbServer(string key, string id, string logFile)
		{
			// Set the server ID.
			this.id = id;

			// Set the root registry key for this server.
			this.key = key;

			// Create the logger for this server.
			this.log = new Logger(logFile);
			this.log.EventLogged += this.OnLog;
			this.logSource = string.Format("Database\\{0}", this.id);

			// Load the current configuration.
			this.LoadConfiguration();
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
			this.logSource = string.Format("Database\\{0}", this.id);

			// Save the configuration.
			this.SaveConfiguration();
		}


		// Public properties.

		/// <summary>
		/// Gets the ID of the current database server.
		/// </summary>
		public string Id { get { return this.id; } }
		/// <summary>
		/// Gets the type of the current database server.
		/// </summary>
		public abstract DbServers.DbServerType Type { get; }
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
		public string Password
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
		public abstract DbDatabase Database { get; }

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
		/// Saves the current server configuration to the registry.
		/// </summary>
		public virtual void SaveConfiguration()
		{
			// Update the modification date.
			this.dateModified = DateTime.Now;

			Registry.SetValue(this.key, "Name", this.name, RegistryValueKind.String);
			Registry.SetValue(this.key, "DataSource", this.dataSource, RegistryValueKind.String);
			Registry.SetValue(this.key, "Username", this.username, RegistryValueKind.String);
			Registry.SetValue(this.key, "Password", CrawlerCrypto.Encrypt(this.password), RegistryValueKind.Binary);
			Registry.SetValue(this.key, "DateCreated", this.dateCreated.Ticks, RegistryValueKind.QWord);
			Registry.SetValue(this.key, "DateModified", this.dateModified.Ticks, RegistryValueKind.QWord);

			// Log the event.
			this.log.Add(
				LogEventLevel.Normal,
				LogEventType.Success,
				this.logSource,
				"Configuration for database server with ID \'{0}\' was saved to registry.",
				new object[] { this.Id }
				);

			// Re-initialize the server object.
			this.OnInitialized();
		}

		/// <summary>
		/// Loads the current server configuration from the registry.
		/// </summary>
		public virtual void LoadConfiguration()
		{
			this.name = Registry.GetValue(this.key, "Name", null) as string;
			this.dataSource = Registry.GetValue(this.key, "DataSource", null) as string;
			this.username = Registry.GetValue(this.key, "Username", null) as string;
			this.password = CrawlerCrypto.Decrypt(Registry.GetValue(this.key, "Password", null) as byte[]);
			this.dateCreated = new DateTime((long)Registry.GetValue(this.key, "DateCreated", DateTime.Now.Ticks));
			this.dateModified = new DateTime((long)Registry.GetValue(this.key, "DateModified", DateTime.Now.Ticks));

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
		/// Disposes the server object by closing the connection.
		/// </summary>
		public void Dispose()
		{
			// Dispose the server.
			this.OnDispose();
			// Suppress the finalizer for this object.
			GC.SuppressFinalize(this);
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
		public abstract IAsyncResult ChangePassword(string newPassword, DbServerCallback callback, object userState = null);

		/// <summary>
		/// Creates a new database command with the specified query.
		/// </summary>
		/// <param name="query">The database query.</param>
		/// <param name="userState">The user state.</param>
		/// <returns>The database command.</returns>
		public abstract DbCommand CreateCommand(string query, object userState = null);

		// Protected methods.

		/// <summary>
		/// A method called when the server object is being initialized.
		/// </summary>
		protected abstract void OnInitialized();

		/// <summary>
		/// A  method called when the server object is being disposed.
		/// </summary>
		protected virtual void OnDispose()
		{
			// Dispose the log.
			this.log.Dispose();
		}

		/// <summary>
		/// An event handler called when the server configuration has changed.
		/// </summary>
		protected void OnServerChanged()
		{
			// Call the event.
			if (this.ServerChanged != null) this.ServerChanged(this);
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
			// Call the event handler.
			if(this.StateChanged != null) this.StateChanged(this, new DbServerStateEventArgs(oldState, this.state));
		}

		/// <summary>
		/// An event handler called when the server begins opening the connection.
		/// </summary>
		protected void OnOpening()
		{
			// Call the event.
			if (this.Opening != null) this.Opening(this);
		}

		/// <summary>
		/// An event handler called when the server begins reopening the connection.
		/// </summary>
		protected void OnReopening()
		{
			// Call the event.
			if (this.Reopening != null) this.Reopening(this);
		}

		/// <summary>
		/// An event handler called when the server begins closing the connection.
		/// </summary>
		protected void OnClosing()
		{
			// Call the event.
			if (this.Closing != null) this.Closing(this);
		}

		/// <summary>
		/// An event handler called when the server logs a new event.
		/// </summary>
		protected void OnLog(LogEvent evt)
		{
			// Call the event.
			if (this.EventLogged != null) this.EventLogged(evt);
		}
	}
}
