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
using Microsoft.Win32;

namespace YtCrawler.Database
{
	/// <summary>
	/// A class representing the list of database servers.
	/// </summary>
	public sealed class DbServers
	{
		public enum DbServerType
		{
			Unknown = 0,
			MsSql = 1
		};

		private CrawlerConfig config;

		private Dictionary<string, DbServer> servers = new Dictionary<string, DbServer>();
		private DbServer primary = null;

		/// <summary>
		/// Creates a new database servers list, using the specified configuration.
		/// </summary>
		/// <param name="config">The crawler configuration.</param>
		public DbServers(CrawlerConfig config)
		{
			// Save the configuration.
			this.config = config;

			// Get the ID of the primary database server.
			string primaryId = Registry.GetValue(this.config.DatabaseConfig.Key, "Primary", null) as string;

			// Create the servers list.
			foreach (string id in this.config.DatabaseConfig.Servers)
			{
				// Try to create the database server.
				try
				{
					// Compute the server configuration registry key.
					string key = string.Format("{0}\\{1}", config.DatabaseConfig.Key, id);
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
					// Add the database server to the dictionary.
					this.servers.Add(id, server);
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
	}
}
