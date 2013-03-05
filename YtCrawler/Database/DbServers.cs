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
using System.Threading;
using Microsoft.Win32;

namespace YtCrawler.Database
{
	public delegate void ServerEventHandler(DbServer server);
	public delegate void ServerIdEventHandler(string id);
	public delegate void ServerStateChangedEventHandler(DbServer server, StateChangeEventArgs e);
	public delegate void ServerPrimaryChangedEventHandler(DbServer oldPrimary, DbServer newPrimary);

	/// <summary>
	/// A class representing the list of database servers.
	/// </summary>
	public sealed class DbServers : IDisposable
	{
		public enum DbServerType
		{
			MsSql = 0
		};

		private CrawlerConfig config;

		private Dictionary<string, DbServer> servers = new Dictionary<string, DbServer>();
		private DbServer primary = null;
		private Mutex mutex = new Mutex();

		private static string[] dbServerTypeNames = {
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
			string primaryId = Registry.GetValue(this.config.DatabaseConfig.Key.Name, "Primary", null) as string;

			// Create the servers list.
			foreach (string id in this.config.DatabaseConfig.Servers)
			{
				// Try to create the database server.
				try
				{
					// Compute the server configuration registry key.
					string key = string.Format("{0}\\{1}", this.config.DatabaseConfig.Key.Name, id);
					// Get the database server type.
					DbServerType type = (DbServerType)(Registry.GetValue(key, "Type", 0));
					// Create a server instance for the specified configuration.
					DbServer server;

					switch (type)
					{
						case DbServerType.MsSql:
							server = new DbServerMsSql(key, id);
							break;
						default: continue;
					}
					// Add the database server to the servers list.
					this.Add(server);
					// If this is the primary server, set the primary.
					if (primaryId == id)
					{
						this.primary = server;
					}
				}
				catch (Exception)
				{
					// If any exception occurs, remove the server configuration.
					config.DatabaseConfig.Remove(id);
				}
			}
		}

		// Public events.

		/// <summary>
		/// An event raised when a new was added.
		/// </summary>
		public event ServerEventHandler ServerAdded;
		/// <summary>
		/// An event raised when a server was removed.
		/// </summary>
		public event ServerIdEventHandler ServerRemoved;
		/// <summary>
		/// An event raised when the properties of a server have changed.
		/// </summary>
		public event ServerEventHandler ServerChanged;
		/// <summary>
		/// An event raised when the server state has changed.
		/// </summary>
		public event ServerStateChangedEventHandler StateChanged;
		/// <summary>
		/// An event raised when the primary server has changed.
		/// </summary>
		public event ServerPrimaryChangedEventHandler ServerPrimaryChanged;

		// Public properties.

		/// <summary>
		/// Returns the list of supported server type names.
		/// </summary>
		public static string[] ServerTypeNames { get { return DbServers.dbServerTypeNames; } }

		// Public methods.

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
			string password,
			bool primary
			)
		{
			// Generate the server ID.
			string id = Guid.NewGuid().ToString();
			// Check the server ID does not exist. Otherwise, throw an exception.
			if (this.servers.ContainsKey(id)) throw new CrawlerException(string.Format("Cannot add a new database server. The server ID \'{0}\' already exists.", id));
			// Create the registry key for this server.
			RegistryKey key = this.config.DatabaseConfig.Key.CreateSubKey(id);

			DbServer server;
			try
			{
				// Try create the server object.
				switch (type)
				{
					case DbServerType.MsSql:
						server = new DbServerMsSql(key.Name, id, name, dataSource, username, password);
						break;
					default: throw new CrawlerException(string.Format("Cannot add a new database server. Unknown database server type \'{0}\'.", type));
				}
				// Add the server to the servers list.
				this.Add(server);

				// Close the registry key.
				key.Close();
			}
			catch (Exception)
			{
				// If any exception occurs, delete the registry key, and re-throw the exception.

				// Close the key.
				key.Close();
				// Delete the registry key.
				this.config.DatabaseConfig.Key.DeleteSubKeyTree(id);
				// Re-throw the exception.
				throw;
			}

			// Raise the server add event.
			if (null != this.ServerAdded) this.ServerAdded(server);

			// If the server is primary.
			if (primary)
			{
				DbServer oldPrimary = this.primary;
				// Set the server as primary
				this.primary = server;
				// Raise the primary server changed event.
				if (null != this.ServerPrimaryChanged) this.ServerPrimaryChanged(oldPrimary, this.primary);
				// Update the registry key.
				Registry.SetValue(this.config.DatabaseConfig.Key.Name, "Primary", id, RegistryValueKind.String);
			}
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
			if(!this.servers.ContainsKey(id)) throw new CrawlerException(string.Format("Cannot remove the database server. The server with ID \'{0}\' does not exist.", id));
			// If there are more than one server, and this is the primary server, the user must select a different primary server first.
			if ((this.servers.Count > 1) && (this.primary == server)) throw new CrawlerException("Cannot remove the database server. First, select a different primary server.");
			// If this is the primary server, set the primary server to null.
			if (server == this.primary)
			{
				// Set the primary server to null.
				this.primary = null;
				// Raise the primary server changed event.
				if (this.ServerPrimaryChanged != null) this.ServerPrimaryChanged(server, null);
			}
			// Dispose the server object synchronously.
			server.Dispose();
			// Remove the object from the servers list.
			this.Remove(id);
			// Raise the server removed event.
			if (this.ServerRemoved != null) this.ServerRemoved(id);
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
			if (!this.servers.ContainsKey(id)) throw new CrawlerException(string.Format("Cannot remove the database server. The server with ID \'{0}\' does not exist.", id));
			// If there are more than one server, and this is the primary server, the user must select a different primary server first.
			if ((this.servers.Count > 1) && (this.primary == server)) throw new CrawlerException("Cannot remove the database server. First, select a different primary server.");
			// If this is the primary server, set the primary server to null.
			if (server == this.primary)
			{
				// Set the primary server to null.
				this.primary = null;
				// Raise the primary server changed event.
				if (this.ServerPrimaryChanged != null) this.ServerPrimaryChanged(server, null);
			}
			
			// Create the asynchronous state.
			DbServerAsyncState asyncState = new DbServerAsyncState(userState);
			
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
						if (this.ServerRemoved != null) this.ServerRemoved(id);
					}
					catch (Exception exception)
					{
						// Set the exception in the asynchronous state.
						asyncState.Exception = exception;
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
		}

		// Private methods.

		/// <summary>
		/// Adds the server to the servers list. The method is thread-safe.
		/// </summary>
		/// <param name="server">The server to add.</param>
		private void Add(DbServer server)
		{
			try
			{
				// Lock the mutex.
				this.mutex.WaitOne();
				// Add the server to the dictionary.
				this.servers.Add(server.Id, server);
			}
			finally
			{
				// Unlock the mutex.
				this.mutex.ReleaseMutex();
			}
			// Add the server event handlers.
			server.StateChanged += this.OnStateChanged;
			server.ServerChanged += OnServerChanged;
		}

		/// <summary>
		/// Removes the server with the specified ID from the servers list. The methods is thread-safe.
		/// </summary>
		/// <param name="id">The server ID.</param>
		private void Remove(string id)
		{
			try
			{
				// Lock the mutex.
				this.mutex.WaitOne();
				// Remove the server.
				this.servers.Remove(id);
			}
			finally
			{
				// Unlock the mutex.
				this.mutex.ReleaseMutex();
			}
		}

		/// <summary>
		/// An event handler called when the server connection state has changed.
		/// </summary>
		/// <param name="server">The server.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStateChanged(DbServer server, StateChangeEventArgs e)
		{
			if (this.StateChanged != null) this.StateChanged(server, e);
		}

		/// <summary>
		/// An event handler called when the server configuration has changed.
		/// </summary>
		/// <param name="server">The server.</param>
		private void OnServerChanged(DbServer server)
		{
			if (this.ServerChanged != null) this.ServerChanged(server);
		}
	}
}
