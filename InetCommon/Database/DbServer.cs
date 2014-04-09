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
using System.ComponentModel;
using System.Collections.Generic;
using System.Security;
using Microsoft.Win32;
using DotNetApi;
using DotNetApi.Windows;
using InetCommon.Log;

namespace InetCommon.Database
{
	/// <summary>
	/// A class representing a database server.
	/// </summary>
	public abstract class DbServer : IDisposable
	{
		/// <summary>
		/// An enumeration representing the database server class.
		/// </summary>
		public enum DbServerClass
		{
			[Description("SQL server")]
			Sql = 0,
			[Description("MongoDB server")]
			Mongo = 1
		}

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
		private readonly RegistryKey key;

		// Settings.
		private readonly DbServerClass cls;
		private readonly Guid id;
		private string name;
		private string dataSource;
		private string username;
		private SecureString password;
		private DateTime dateCreated;
		private DateTime dateModified;

		// State.
		private ServerState state = ServerState.Disconnected;

		// Log.
		private Logger log;
		private string logSource;

		/// <summary>
		/// Creates a database server with the specified name and configuration.
		/// </summary>
		/// <param name="cls">The database server class.</param>
		/// <param name="key">The registry configuration key.</param>
		/// <param name="id">The server ID.</param>
		/// <param name="logFile">The log file for this database server.</param>
		public DbServer(DbServerClass cls, RegistryKey key, Guid id, string logFile)
		{
			// Set the server class.
			this.cls = cls;

			// Set the server ID.
			this.id = id;

			// Set the root registry key for this server.
			this.key = key;

			// Create the logger for this server.
			this.log = new Logger(logFile);
			this.log.EventLogged += this.OnLog;
			this.logSource = @"Database\{0}".FormatWith(this.id.ToString());

			// Load the current configuration.
			this.LoadInternalConfiguration();
		}

		/// <summary>
		/// Creates a database server with the specified parameters.
		/// </summary>
		/// <param name="cls">The database server class.</param>
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
			DbServerClass cls,
			RegistryKey key,
			Guid id,
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
			this.cls = cls;
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
			this.logSource = @"Database\{0}".FormatWith(this.id.ToString());

			// Save the configuration.
			this.SaveInternalConfiguration();
		}

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

		// Public properties.

		/// <summary>
		/// Gets the ID of the current database server.
		/// </summary>
		public Guid Id { get { return this.id; } }
		/// <summary>
		/// Gets the class of the current database server.
		/// </summary>
		public DbServerClass Class { get { return this.cls; } }
		/// <summary>
		/// Gets the class name of the current database server.
		/// </summary>
		public string ClassName { get { return this.cls.GetDescription(); } }
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
		/// Gets the server log.
		/// </summary>
		public Logger Log { get { return this.log; } }
		/// <summary>
		/// Gets the server version.
		/// </summary>
		public abstract string Version { get; }
		/// <summary>
		/// Gets the server type name.
		/// </summary>
		public abstract string TypeName { get; }

		// Protected properties.

		/// <summary>
		/// Gets the registry key.
		/// </summary>
		protected RegistryKey Key { get { return this.key; } }

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
		protected void OnStateChange(DbServerSql.ServerState state)
		{
			// Save the old state.
			DbServerSql.ServerState oldState = this.state;
			// Set the new state.
			this.state = state;
			// Call the event.
			if (this.StateChanged != null) this.StateChanged(this, new DbServerStateEventArgs(this, oldState, this.state));
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
			RegistryExtensions.SetString(this.key.Name, "Name", this.name);
			RegistryExtensions.SetString(this.key.Name, "DataSource", this.dataSource);
			RegistryExtensions.SetString(this.key.Name, "Username", this.username);
			RegistryExtensions.SetSecureString(this.key.Name, "Password", this.password, ApplicationConfig.CryptoKey, ApplicationConfig.CryptoIV);
			RegistryExtensions.SetDateTime(this.key.Name, "DateCreated", this.dateCreated);
			RegistryExtensions.SetDateTime(this.key.Name, "DateModified", this.dateModified);

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
			this.name = RegistryExtensions.GetString(this.key.Name, "Name", null);
			this.dataSource = RegistryExtensions.GetString(this.key.Name, "DataSource", null);
			this.username = RegistryExtensions.GetString(this.key.Name, "Username", null);
			this.password = RegistryExtensions.GetSecureString(this.key.Name, "Password", null, ApplicationConfig.CryptoKey, ApplicationConfig.CryptoIV);
			this.dateCreated = RegistryExtensions.GetDateTime(this.key.Name, "DateCreated", DateTime.Now);
			this.dateModified = RegistryExtensions.GetDateTime(this.key.Name, "DateModified", DateTime.Now);

			// Log the event.
			this.log.Add(
				LogEventLevel.Normal,
				LogEventType.Success,
				this.logSource,
				"Configuration for database server with ID \'{0}\' was loaded from registry. The server name is \'{1}\'.",
				new object[] { this.Id, this.Name }
				);
		}
	}
}
