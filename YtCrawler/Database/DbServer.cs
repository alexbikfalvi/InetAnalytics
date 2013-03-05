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
			Busy = 3
		};

		private string key;

		private string id;
		private string name;
		private string dataSource;
		private string username;
		private string password;

		private ServerState state = ServerState.Disconnected;

		/// <summary>
		/// Creates a database server with the specified name and configuration.
		/// </summary>
		/// <param name="key">The registry configuration key.</param>
		/// <param name="id">The server ID.</param>
		public DbServer(string key, string id)
		{
			// Set the server ID.
			this.id = id;

			// Set the root registry key for this server.
			this.key = key;

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
		public DbServer(
			string key,
			string id,
			string name,
			string dataSource,
			string username,
			string password
			)
		{
			// Save the parameters.
			this.key = key;
			this.id = id;
			this.name = name;
			this.dataSource = dataSource;
			this.username = username;
			this.password = password;

			// Save the configuration.
			this.SaveConfiguration();
		}


		// Public properties.

		/// <summary>
		/// Gets the ID of the current database server.
		/// </summary>
		public string Id { get { return this.id; } }

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
		/// Gets the server connection state.
		/// </summary>
		public abstract ConnectionState ConnectionState { get; }

		/// <summary>
		/// Gets the server state.
		/// </summary>
		public ServerState State { get { return this.state; } }

		/// <summary>
		/// Gets the server version.
		/// </summary>
		public abstract string Version { get; }

		// Public events.

		/// <summary>
		/// An event raised when the configuration of the server has changed.
		/// </summary>
		public event ServerEventHandler ServerChanged;
		/// <summary>
		/// An event raised when the server connection state has changed.
		/// </summary>
		public event ServerStateChangedEventHandler StateChanged;
		/// <summary>
		/// An event raised when the server begins opening the connection.
		/// </summary>
		public event ServerEventHandler Opening;
		/// <summary>
		/// An event raised when the server begins reopening the connection.
		/// </summary>
		public event ServerEventHandler Reopening;
		/// <summary>
		/// An event raised when the server begins closing the connection.
		/// </summary>
		public event ServerEventHandler Closing;

		/// <summary>
		/// Saves the current server configuration to the registry.
		/// </summary>
		public void SaveConfiguration()
		{
			Registry.SetValue(this.key, "Name", this.name, RegistryValueKind.String);
			Registry.SetValue(this.key, "DataSource", this.dataSource, RegistryValueKind.String);
			Registry.SetValue(this.key, "Username", this.username, RegistryValueKind.String);
			Registry.SetValue(this.key, "Password", CrawlerCrypto.Encrypt(this.password), RegistryValueKind.Binary);
		}

		/// <summary>
		/// Discards the current server configuration and loads the previous one from the registry.
		/// </summary>
		public void DiscardConfiguration()
		{
			this.LoadConfiguration();
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
		/// Opens the connection to the database server.
		/// </summary>
		public abstract void Open();

		/// <summary>
		/// Opens the connection to the database server asynchronously.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="userState">The user state.</param>
		/// <returns>The asynchronous result.</returns>
		public abstract IAsyncResult OpenAsync(DbServerCallback callback, object userState = null);

		/// <summary>
		/// Reopens the connection to the database server.
		/// </summary>
		public abstract void Reopen();

		/// <summary>
		/// Reopens the connection to the database server asynchronously.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="userState">The user state.</param>
		/// <returns>The asynchronous result.</returns>
		public abstract IAsyncResult ReopenAsync(DbServerCallback callback, object userState = null);

		/// <summary>
		/// Closes the connection to the database server.
		/// </summary>
		public abstract void Close();

		/// <summary>
		/// Closes the connection to the database server asynchronously.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="userState">The user state.</param>
		/// <returns>The asynchronous result.</returns>
		public abstract IAsyncResult CloseAsync(DbServerCallback callback, object userState = null);

		// Protected methods.

		/// <summary>
		/// A  method called when the server object is being disposed.
		/// </summary>
		protected virtual void OnDispose()
		{
			// Do nothing.
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
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		protected void OnStateChanged(object sender, StateChangeEventArgs e)
		{
			// Update the server state.
			switch (e.CurrentState)
			{
				case System.Data.ConnectionState.Open:
				case System.Data.ConnectionState.Executing:
				case System.Data.ConnectionState.Fetching:
					this.state = ServerState.Connected;
					break;
				case System.Data.ConnectionState.Connecting:
					this.state = ServerState.Busy;
					break;
				case System.Data.ConnectionState.Closed:
					this.state = ServerState.Disconnected;
					break;
				case System.Data.ConnectionState.Broken:
					this.state = ServerState.Failed;
					break;
			}
			// Call the event.
			if (this.StateChanged != null) this.StateChanged(this, e);
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

		// Private methods.

		/// <summary>
		/// Loads the current server configuration from the registry.
		/// </summary>
		private void LoadConfiguration()
		{
			this.name = Registry.GetValue(this.key, "Name", null) as string;
			this.dataSource = Registry.GetValue(this.key, "DataSource", null) as string;
			this.username = Registry.GetValue(this.key, "Username", null) as string;
			this.password = CrawlerCrypto.Decrypt(Registry.GetValue(this.key, "Password", null) as byte[]);
		}
	}
}
