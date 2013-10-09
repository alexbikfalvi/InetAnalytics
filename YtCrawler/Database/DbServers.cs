﻿/* 
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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading;
using Microsoft.Win32;
using DotNetApi;
using YtCrawler.Database.Data;
using YtCrawler.Log;

namespace YtCrawler.Database
{
	/// <summary>
	/// A class representing the list of database servers.
	/// </summary>
	public sealed class DbServers : IDisposable, IEnumerable<KeyValuePair<string, DbServer>>
	{
		public enum DbServerType
		{
			MsSql = 0
		};

		private CrawlerConfig config;

		private readonly Dictionary<string, DbServer> servers = new Dictionary<string, DbServer>();
		private IOrderedEnumerable<KeyValuePair<string, DbServer>> orderedServers = null;
		private DbServer primary = null;
		//private readonly Mutex mutex = new Mutex();
		private readonly object sync = new object();

		private static readonly string[] dbServerTypeNames = {
																 "Microsoft SQL Server"
															 };

		/// <summary>
		/// Creates a new database servers list, using the specified configuration.
		/// </summary>
		/// <param name="config">The crawler configuration.</param>
		public DbServers(CrawlerConfig config)
		{
			// Save the configuration.
			this.config = config;

			// Get the ID of the primary database server.
			string primaryId = DotNetApi.Windows.Registry.GetString(this.config.Database.Key.Name, "Primary", null);

			// Create the servers list.
			foreach (string id in this.config.Database.Servers)
			{
				// Compute the database server log file.
				string logFile = this.config.DatabaseLogFileName.FormatWith(id, "{0}", "{1}", "{2}");
				// Try to create the database server.
				try
				{
					// Open the server configuration registry key.
					RegistryKey key = this.config.Database.Key.OpenSubKey(id, true);
					// If the registry key could not be opened, continue to the next server.
					if (null == key) continue;
					// Get the database server type.
					DbServerType type = (DbServerType)DotNetApi.Windows.Registry.GetInteger(key.Name, "Type", 0);
					// Create a server instance for the specified configuration.
					DbServer server;
					switch (type)
					{
						case DbServerType.MsSql:
							server = new DbServerSql(key, id, logFile);
							break;
						default: throw new CrawlerException("Cannot add a new database server. Unknown database server type \'{0}\'.".FormatWith(type));
					}
					// Add the database server to the servers list.
					this.Add(server);
					// If this is the primary server, set the primary.
					if (primaryId == id)
					{
						this.primary = server;
					}
					// Add a log event handler for this server.
					server.EventLogged += this.OnEventLogged;
				}
				catch (Exception)
				{
					// If any exception occurs, remove the server configuration.
					config.Database.Remove(id);
				}
			}
		}

		// Public events.

		/// <summary>
		/// An event raised when a new was added.
		/// </summary>
		public event DbServerEventHandler ServerAdded;
		/// <summary>
		/// An event raised when a server was removed.
		/// </summary>
		public event DbIdEventHandler ServerRemoved;
		/// <summary>
		/// An event raised when the properties of a server have changed.
		/// </summary>
		public event DbServerEventHandler ServerChanged;
		/// <summary>
		/// An event raised when the server state has changed.
		/// </summary>
		public event DbServerStateEventHandler ServerStateChanged;
		/// <summary>
		/// An event raised when the primary server has changed.
		/// </summary>
		public event DbPrimaryServerChangedEventHandler ServerPrimaryChanged;
		/// <summary>
		/// An event raised when a database server logs an event.
		/// </summary>
		public event LogEventHandler EventLogged;

		// Public properties.

		/// <summary>
		/// Returns the database server for the specified ID.
		/// </summary>
		/// <param name="id">The server ID.</param>
		/// <returns>The database server.</returns>
		public DbServer this[string id] { get { return this.servers[id]; } }
		/// <summary>
		/// Gets the number of database servers.
		/// </summary>
		public int Count { get { return this.servers.Count; } }
		/// <summary>
		/// Indicates whether there exists a primary server.
		/// </summary>
		public bool HasPrimary { get { return this.primary != null; } }
		/// <summary>
		/// Returns the list of supported server type names.
		/// </summary>
		public static string[] ServerTypeNames { get { return DbServers.dbServerTypeNames; } }
		/// <summary>
		/// Returns the primary database server.
		/// </summary>
		public DbServer Primary { get { return this.primary; } }

		// Public methods.

		/// <summary>
		/// Reloads the configuration of all database servers.
		/// </summary>
		public void Reload()
		{
			foreach (KeyValuePair<string, DbServer> server in this.servers)
			{
				server.Value.LoadConfiguration();
			}
		}

		/// <summary>
		/// Indicates if the specified server is the primary server.
		/// </summary>
		/// <param name="server">The server.</param>
		/// <returns>Returns <b>true</b> if the server is primary, or <b>false</b> otherwise.</returns>
		public bool IsPrimary(DbServer server)
		{
			return this.primary == server;
		}

		/// <summary>
		/// Changes the primary server to the specified server.
		/// </summary>
		/// <param name="server">The database server.</param>
		public void SetPrimary(DbServer server)
		{
			// Save the old primary server.
			DbServer oldPrimary = this.primary;
			// Change the primary server.
			this.primary = server;
			// Update the registry key.
			Registry.SetValue(this.config.Database.Key.Name, "Primary", this.primary != null ? this.primary.Id : string.Empty, RegistryValueKind.String);
			// Raise the primary server changed event.
			if (this.ServerPrimaryChanged != null) this.ServerPrimaryChanged(this, new DbPrimaryServerChangedEventArgs(oldPrimary, this.primary));
		}

		/// <summary>
		/// Returns the enumerator for the current list of database servers.
		/// </summary>
		/// <returns>The enumerator.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		/// <summary>
		/// Returns the generic enumerator for the current list of database servers.
		/// </summary>
		/// <returns>The enumerator.</returns>
		public IEnumerator<KeyValuePair<string, DbServer>> GetEnumerator()
		{
			// Order the server list.
			this.orderedServers = Enumerable.OrderBy<KeyValuePair<string, DbServer>, DateTime>(this.servers, pair => pair.Value.DateCreated);
			return this.orderedServers.GetEnumerator();
		}

		/// <summary>
		/// Adds a new database server. The method is thread-safe but may block if another server operation is under way.
		/// </summary>
		/// <param name="type">The server type.</param>
		/// <param name="name">The server name.</param>
		/// <param name="dataSource">The data source.</param>
		/// <param name="username">The username.</param>
		/// <param name="password">The password.</param>
		/// <param name="primary">Indicates whether the server should be primary.</param>
		public void Add(
			DbServerType type,
			string name,
			string dataSource,
			string username,
			SecureString password,
			bool primary
			)
		{
			// Generate the server ID.
			string id = Guid.NewGuid().ToString();
			// Check the server ID does not exist. Otherwise, throw an exception.
			if (this.servers.ContainsKey(id)) throw new CrawlerException("Cannot add a new database server. The server ID \'{0}\' already exists.".FormatWith(id));
			// Create the registry key for this server.
			RegistryKey key = this.config.Database.Key.CreateSubKey(id);
			// Compute the database server log file.
			string logFile = string.Format(this.config.DatabaseLogFileName, id, "{0}", "{1}", "{2}");
			DbServer server;
			try
			{
				// Try create the server object.
				switch (type)
				{
					case DbServerType.MsSql:
						server = new DbServerSql(key, id, name, dataSource, username, password, logFile, DateTime.Now, DateTime.Now);
						break;
					default: throw new CrawlerException("Cannot add a new database server. Unknown database server type \'{0}\'.".FormatWith(type));
				}
				// Add the server to the servers list.
				this.Add(server);
			}
			catch (Exception)
			{
				// If any exception occurs, delete the registry key, and re-throw the exception.

				// Close the key.
				key.Close();
				// Delete the registry key.
				this.config.Database.Key.DeleteSubKeyTree(id);
				// Re-throw the exception.
				throw;
			}

			// If the server is primary, change the primary.
			if (primary)
			{
				this.SetPrimary(server);
			}

			// Add a log event handler for this server.
			server.EventLogged += this.OnEventLogged;

			// Raise the server add event.
			if (null != this.ServerAdded) this.ServerAdded(this, new DbServerEventArgs(server));
		}

		/// <summary>
		/// Removes an existing database server. The method is thread-safe but may block if another server operation is under way.
		/// </summary>
		/// <param name="server">The database server.</param>
		/// <param name="callback">The callback function, if the operation is performed asynchronusly.</param>
		public void Remove(DbServer server)
		{
			string id = server.Id;
			// Check that the server ID exists.
			if(!this.servers.ContainsKey(id)) throw new CrawlerException("Cannot remove the database server. The server with ID \'{0}\' does not exist.".FormatWith(id));
			// If there are more than one server, and this is the primary server, the user must select a different primary server first.
			if ((this.servers.Count > 1) && (this.primary == server)) throw new CrawlerException("Cannot remove the database server. First, select a different primary server.");
			// If this is the primary server, set the primary server to null.
			if (server == this.primary)
			{
				// Set the primary server to null.
				this.SetPrimary(null);
			}
			// Dispose the server object synchronously.
			server.Dispose();
			// Remove the object from the servers list.
			this.Remove(id);
			// Raise the server removed event.
			if (this.ServerRemoved != null) this.ServerRemoved(this, new DbIdEventArgs(id));
		}

		/// <summary>
		/// Removes an existing database server asynchronously. The method will not block the calling thread
		/// if waiting for closing the database connections.
		/// </summary>
		/// <param name="server">The server.</param>
		/// <param name="callback">The callback function, called only if the operation is performed asynchronously.</param>
		/// <param name="userState">The user state.</param>
		/// <return>The result of the asynchronous call.</return>
		public IAsyncResult RemoveAsync(DbServer server, DbServerCallback callback, object userState = null)
		{
			string id = server.Id;
			// Check that the server ID exists.
			if (!this.servers.ContainsKey(id)) throw new CrawlerException("Cannot remove the database server. The server with ID \'{0}\' does not exist.".FormatWith(id));
			// If there are more than one server, and this is the primary server, the user must select a different primary server first.
			if ((this.servers.Count > 1) && (this.primary == server)) throw new CrawlerException("Cannot remove the database server. First, select a different primary server.");
			// If this is the primary server, set the primary server to null.
			if (server == this.primary)
			{
				// Set the primary server to null.
				this.SetPrimary(null);
			}
			
			// Create the asynchronous state.
			DbServerAsyncState asyncState = new DbServerAsyncState(server, userState);
			
			// Dispose the server object asynchronously on the thread pool.
			ThreadPool.QueueUserWorkItem((object state) =>
				{
					try
					{
						// Dispose the server object.
						server.Dispose();
						// Remove the server.
						this.Remove(id);
						// Raise the server remove event.
						if (this.ServerRemoved != null) this.ServerRemoved(this, new DbIdEventArgs(id));
					}
					catch (Exception exception)
					{
						// Set the exception in the asynchronous state.
						asyncState.Exception = new DbException("Removing the database server \'{0}\' failed.".FormatWith(server.Name), exception); ;
					}
					// Complete the asynchronous operation.
					asyncState.Complete();
					// Execute the callback function.
					if (callback != null) callback(asyncState);
				});

			// Return the asynchronous state.
			return asyncState;
		}

		/// <summary>
		/// Closes the database servers.
		/// </summary>
		public void Dispose()
		{
			// Dispose all database servers.
			foreach (KeyValuePair<string, DbServer> pair in this.servers)
			{
				pair.Value.Dispose();
			}
			// Supress the finalizer.
			GC.SuppressFinalize(this);
		}

		// Private methods.

		/// <summary>
		/// Adds the server to the servers list. The method is thread-safe.
		/// </summary>
		/// <param name="server">The server to add.</param>
		private void Add(DbServer server)
		{
			lock (this.sync)
			{
				// Add the server to the dictionary.
				this.servers.Add(server.Id, server);
			}
			// Add the server event handlers.
			server.StateChanged += this.OnStateChanged;
			server.ServerChanged += this.OnServerChanged;
		}

		/// <summary>
		/// Removes the server with the specified ID from the servers list. The methods is thread-safe.
		/// </summary>
		/// <param name="id">The server ID.</param>
		private void Remove(string id)
		{
			lock (this.sync)
			{
				// Remove the server configuration.
				this.config.Database.Key.DeleteSubKeyTree(id);
				// Remove the server.
				this.servers.Remove(id);
			}
		}

		/// <summary>
		/// An event handler called when the server connection state has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStateChanged(object sender, DbServerStateEventArgs e)
		{
			if (this.ServerStateChanged != null) this.ServerStateChanged(this, e);
		}

		/// <summary>
		/// An event handler called when the server configuration has changed.
		/// </summary>
		/// <param name="server">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnServerChanged(object sender, DbServerEventArgs e)
		{
			if (this.ServerChanged != null) this.ServerChanged(this, e);
		}

		/// <summary>
		/// An event handler called when a database server logs an event.
		/// </summary>
		/// <param name="server">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnEventLogged(object sender, LogEventArgs e)
		{
			if (this.EventLogged != null) this.EventLogged(this, e);
		}
	}
}
