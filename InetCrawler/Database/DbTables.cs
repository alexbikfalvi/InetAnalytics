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
using System.Linq;
using Microsoft.Win32;
using InetCrawler.Database.Data;

namespace InetCrawler.Database
{
	/// <summary>
	/// Represents the collection of database tables for a database server.
	/// </summary>
	public sealed class DbTables : IDisposable, IEnumerable<ITable>
	{
		private static readonly string keyName = "Tables";
		private RegistryKey key;

		private readonly object sync = new object();

		private readonly Dictionary<Guid, ITable> tables = new Dictionary<Guid, ITable>();

		/// <summary>
		/// Creates a new database table collection, based on the given server registry key.
		/// </summary>
		/// <param name="keyServer">The registry key of the database server.</param>
		public DbTables(RegistryKey keyServer)
		{
			// Create or open the registry key.
			this.key = keyServer.CreateSubKey(DbTables.keyName);
		}

		// Public properties.

		/// <summary>
		/// Gets the database table with the specified local name.
		/// </summary>
		/// <param name="id">The table identifier.</param>
		/// <returns>The database table.</returns>
		public ITable this[Guid id] { get { return this.tables[id]; } }

		// Public events.

		/// <summary>
		/// An event raised when a database table was added.
		/// </summary>
		public event DbTableEventHandler TableAdded;
		/// <summary>
		/// An event raised when a database table was removed.
		/// </summary>
		public event DbTableEventHandler TableRemoved;
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
		public IEnumerator<ITable> GetEnumerator()
		{
			return this.tables.Values.GetEnumerator();
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
			foreach (ITable table in this.tables.Values)
			{
				table.SaveConfiguration(this.key.Name);
			}
		}

		/// <summary>
		/// Loads the configuration of the database tables that are not marked as read-only.
		/// </summary>
		public void LoadConfiguration()
		{
			// Load the configuration of all tables.
			foreach (ITable table in this.tables.Values)
			{
				table.LoadConfiguration(this.key.Name);
			}
		}

		/// <summary>
		/// Adds the specified table to the tables list, without loading the table configuration.
		/// </summary>
		/// <param name="table">The database table to add.</param>
		public void Add(ITable table)
		{
			lock (this.sync)
			{
				// Check the table does not exist.
				if (this.tables.ContainsKey(table.Id)) throw new DbException("A database table with the specified key already exists.");

				// Add the table to the tables list.
				this.tables.Add(table.Id, table);
				// Setup an event handler for the table.
				table.TableChanged += this.OnTableChanged;

				// Raise a table added event.
				if (null != this.TableAdded) this.TableAdded(this, new DbTableEventArgs(table));
			}
		}

		/// <summary>
		/// Removes the specified table from the tables list.
		/// </summary>
		/// <param name="id">The table identifier.</param>
		public void Remove(Guid id)
		{
			lock (this.sync)
			{
				// The table.
				ITable table;
				
				// Get the table corresponding to the specified identifier.
				if (this.tables.TryGetValue(id, out table))
				{
					// Remove the table.
					this.tables.Remove(id);
					
					// Raise a table removed event.
					if (null != this.TableRemoved) this.TableRemoved(this, new DbTableEventArgs(table));
				}
			}
		}

		/// <summary>
		/// Checks whether the specified table identifier exists.
		/// </summary>
		/// <param name="id">The table identifier.</param>
		/// <returns><b>True</b> if the table exists, <b>false</b> otherwise.</returns>
		public bool HasTable(Guid id)
		{
			lock (this.sync)
			{
				return this.tables.ContainsKey(id);
			}
		}

		/// <summary>
		/// Tries to return the table with the specified identifier.
		/// </summary>
		/// <param name="id">The table identifier.</param>
		/// <param name="table">The database table.</param>
		/// <returns><b>True</b> if the table exists, <b>false</b> otherwise.</returns>
		public bool TryGetTable(Guid id, out ITable table)
		{
			lock (this.sync)
			{
				return this.tables.TryGetValue(id, out table);
			}
		}

		// Private methods.

		/// <summary>
		/// An event handler called when a table was added.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnTableAdded(object sender, DbTableEventArgs e)
		{
			// Raise the event.
			if (this.TableAdded != null) this.TableAdded(sender, e);
		}

		/// <summary>
		/// An event handler called when a table was removed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnTableRemoved(object sender, DbTableEventArgs e)
		{
			// Raise the event.
			if (this.TableRemoved != null) this.TableRemoved(sender, e);
		}

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
