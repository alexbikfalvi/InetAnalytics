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
using Microsoft.Win32;

namespace YtCrawler.Database
{
	/// <summary>
	/// A class representing a database server.
	/// </summary>
	public abstract class DbServer : IDisposable
	{
		private string key;

		private string id;
		private string name;
		private string dataSource;
		private string username;
		private string password;
		private bool primary = false;

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
			set { this.name = value; }
		}

		/// <summary>
		/// Gets or sets the server data source.
		/// </summary>
		public string DataSource
		{
			get { return this.dataSource; }
			set { this.dataSource = value; }
		}

		/// <summary>
		/// Gets or sets the server username.
		/// </summary>
		public string Username
		{
			get { return this.username; }
			set { this.username = value; }
		}

		/// <summary>
		/// Gets or sets the server password.
		/// </summary>
		public string Password
		{
			get { return this.password; }
			set { this.password = value; }
		}

		/// <summary>
		/// Gets whether the server is primary.
		/// </summary>
		public bool IsPrimary { get { return this.primary; } }

		/// <summary>
		/// Gets the server connection.
		/// </summary>
		public abstract ConnectionState ConnectionState { get; }

		// Public events.

		/// <summary>
		/// An event raised when the server connection state has changed.
		/// </summary>
		public event StateChangeEventHandler ConnectionStateChanged;

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
		/// Opens the connection to the database server.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="userState">The user state.</param>
		/// <returns>The asynchronous result.</returns>
		public abstract IAsyncResult Open(DbServerCallback callback, object userState = null);

		/// <summary>
		/// Reopens the connection to the database server.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="userState">The user state.</param>
		/// <returns>The asynchronous result.</returns>
		public abstract IAsyncResult Reopen(DbServerCallback callback, object userState = null);

		/// <summary>
		/// Closes the connection to the database server.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="userState">The user state.</param>
		/// <returns>The asynchronous result.</returns>
		public abstract IAsyncResult Close(DbServerCallback callback, object userState = null);

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

		/// <summary>
		/// An event handler called when the state of the connection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		protected void OnConnectionStateChanged(object sender, StateChangeEventArgs e)
		{
			// Call the event.
			if (this.ConnectionStateChanged != null) this.ConnectionStateChanged(sender, e);
		}
	}
}
