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
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32;
using YtCrawler.Database.Data;

namespace YtCrawler.Database
{
	/// <summary>
	/// Represents the collection of database tables for a database server.
	/// </summary>
	public sealed class DbTables : IDisposable, IEnumerable<KeyValuePair<string, ITable>>
	{
		private static string keyName = "Tables";
		private RegistryKey key;

		private Dictionary<string, ITable> tables = new Dictionary<string,ITable>();

		// YouTube tables.
		private DbTable<DbObjectStandardFeed> tableStandardFeeds = new DbTable<DbObjectStandardFeed>("Standard feeds");

		/// <summary>
		/// Creates a new database table collection, based on the given server registry key.
		/// </summary>
		/// <param name="keyServer">The registry key of the database server.</param>
		public DbTables(RegistryKey keyServer)
		{
			// Create or open the registry key.
			this.key = keyServer.CreateSubKey(DbTables.keyName);

			// Add the static tables.
			this.Add(this.tableStandardFeeds);
		}

		// Public properties.

		/// <summary>
		/// Gets the database table with the specified local name.
		/// </summary>
		/// <param name="localName">The table local name.</param>
		/// <returns>The database table.</returns>
		public ITable this[string localName] { get { return this.tables[localName]; } }
		/// <summary>
		/// Gets the standard feeds table.
		/// </summary>
		public DbTable<DbObjectStandardFeed> TableStandardFeeds { get { return this.tableStandardFeeds; } }

		// Public events.

		/// <summary>
		/// An event raised when a database table has changed.
		/// </summary>
		public event DbTableEventHandler TableChanged;

		// Public methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Close the registry key.
			this.key.Close();
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Returns the enumerator for the current table collection.
		/// </summary>
		/// <returns>The enumerator.</returns>
		public IEnumerator<KeyValuePair<string, ITable>> GetEnumerator()
		{
			return this.tables.GetEnumerator();
		}

		/// <summary>
		/// Returns the enumerator for the current table collection.
		/// </summary>
		/// <returns>The enumerator.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		/// <summary>
		/// Saves the configuration of the database tables that are not marked as read-only.
		/// </summary>
		public void SaveConfiguration()
		{
			// Save the configuration of all tables.
			foreach (KeyValuePair<string, ITable> table in this.tables)
			{
				table.Value.SaveConfiguration(this.key.Name);
			}
		}

		/// <summary>
		/// Loads the configuration of the database tables that are not marked as read-only.
		/// </summary>
		public void LoadConfiguration()
		{
			// Load the configuration of all tables.
			foreach (KeyValuePair<string, ITable> table in this.tables)
			{
				table.Value.LoadConfiguration(this.key.Name);
			}
		}

		/// <summary>
		/// Adds the specified table to the tables list, without loading the table configuration.
		/// </summary>
		/// <param name="table">The database table to add.</param>
		public void Add(ITable table)
		{
			// Add the table to the tables list.
			this.tables.Add(table.LocalName, table);
			// Setup an event handler for the table.
			table.TableChanged += this.OnTableChanged;
		}

		// Private methods.


		/// <summary>
		/// An event handler called when the configuration of a table has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnTableChanged(object sender, DbTableEventArgs e)
		{
			// Raise the event.
			if (this.TableChanged != null) this.TableChanged(sender, e);
		}
	}
}
