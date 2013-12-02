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
using System.Text;
using System.Xml.Linq;
using Microsoft.Win32;

namespace InetCrawler.Database
{
	/// <summary>
	/// A class representing the collection of relationships between database tables.
	/// </summary>
	public class DbRelationships : IEnumerable<DbRelationship>
	{
		private static readonly string keyName = "Relationships";
		private string key;

		private static readonly string xmlRoot = "DbRelationships";

		private DbTables tables;
		private readonly HashSet<DbRelationship> relationships = new HashSet<DbRelationship>();

		private readonly object sync = new object();

		/// <summary>
		/// Creates a list of database table relationships, from the specified registry key.
		/// </summary>
		/// <param name="key">The registry key.</param>
		/// <param name="tables">The database tables.</param>
		public DbRelationships(RegistryKey key, DbTables tables)
		{
			// Save the configuration.
			this.key = key.Name;
			this.tables = tables;
		}

		// Public events.

		/// <summary>
		/// An event raised when a relationship was added.
		/// </summary>
		public event DbRelationshipEventHandler RelationshipAdded;
		/// <summary>
		/// An event raised when a relationship was removed.
		/// </summary>
		public event DbRelationshipEventHandler RelationshipRemoved;
		
		// Public methods.

		/// <summary>
		/// Returns the enumrator for the collection of relationships.
		/// </summary>
		/// <returns>The enumerator.</returns>
		public IEnumerator<DbRelationship> GetEnumerator()
		{
			return this.relationships.GetEnumerator();
		}

		/// <summary>
		/// Returns the enumerator for the collection of relationships.
		/// </summary>
		/// <returns>The enumerator.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		/// <summary>
		/// Adds a new database relationship to the collection.
		/// </summary>
		/// <param name="tableLeft">The left table.</param>
		/// <param name="tableRight">The right table.</param>
		/// <param name="fieldLeft">The left field.</param>
		/// <param name="fieldRight">The right field.</param>
		/// <param name="readOnly">Indicates if the relationship is read-only.</param>
		public void Add(ITable tableLeft, ITable tableRight, string fieldLeft, string fieldRight, bool readOnly = true)
		{
			lock (this.sync)
			{
				// Create the relationship.
				DbRelationship relationship = new DbRelationship(tableLeft, tableRight, fieldLeft, fieldRight, readOnly);

				// If the relationship already exists, do nothing.
				if (this.relationships.Contains(relationship)) return;

				// Add the relationship.
				this.relationships.Add(relationship);
				// Raise an event.
				if (null != this.RelationshipAdded) this.RelationshipAdded(this, new DbRelationshipEventArgs(relationship));
			}
		}

		/// <summary>
		/// Removes any relationship containing the specified table.
		/// </summary>
		/// <param name="table">The table identifier.</param>
		public void Remove(Guid table)
		{
			lock (this.sync)
			{
				// Remove all relationships that correspond to the specified table.
				this.relationships.RemoveWhere((DbRelationship relationship) =>
					{
						// If the relationship contains the table.
						if ((relationship.LeftTable.Id == table) || (relationship.RightTable.Id == table))
						{
							// Call the remove event handler for this relationship.
							if (null != this.RelationshipRemoved) this.RelationshipRemoved(this, new DbRelationshipEventArgs(relationship));
							// Return true.
							return true;
						}
						else return false;
					});
			}
		}

		/// <summary>
		/// Removes the specified relationship.
		/// </summary>
		/// <param name="leftTable">The identifier of the left table.</param>
		/// <param name="rightTable">The identifier of the right table.</param>
		/// <param name="leftField">The left field.</param>
		/// <param name="rightField">The right field.</param>
		public void Remove(Guid leftTable, Guid rightTable, string leftField, string rightField)
		{
			lock (this.sync)
			{
				// Remove all relationships that correspond to the specified table.
				this.relationships.RemoveWhere((DbRelationship relationship) =>
				{
					// If the relationship contains the table.
					if ((relationship.LeftTable.Id == leftTable) && (relationship.RightTable.Id == rightTable) && (relationship.LeftField == leftField) && (relationship.RightField == rightField))
					{
						// Call the remove event handler for this relationship.
						if (null != this.RelationshipRemoved) this.RelationshipRemoved(this, new DbRelationshipEventArgs(relationship));
						// Return true.
						return true;
					}
					else return false;
				});
			}
		}

		/// <summary>
		/// Loads the database relationships which are not read-only from the registry.
		/// </summary>
		public void LoadConfiguration()
		{
			// Read the table registry value.
			byte[] value = DotNetApi.Windows.Registry.GetBytes(this.key, DbRelationships.keyName, null);
			// If the value is null, do nothing.
			if (null == value) return;

			try
			{
				lock (this.sync)
				{
					// Read the table XML configuration from the value as UTF-8.
					XDocument document = XDocument.Parse(Encoding.UTF8.GetString(value));

					// Check the document root.
					if (document.Root.Name != DbRelationships.xmlRoot) return;

					// Read the database relationships and add them to the relationships list.
					foreach (XElement element in document.Root.Elements())
					{
						// Create the relationship.
						DbRelationship relationship = DbRelationship.Create(element, this.tables);
						// Add the relationship to the collection.
						this.relationships.Add(relationship);
					}
				}
			}
			catch
			{
				// If any exception occurs, do nothing.
			}
		}

		/// <summary>
		/// Saves the database relationships that are not read-only to the registry.
		/// </summary>
		public void SaveConfiguration()
		{
			lock (this.sync)
			{
				// Create a new XML document for the collection of relationships.
				XDocument document = new XDocument(new XElement(DbRelationships.xmlRoot));

				// Add to the XML document the elements corresponding to the relationships that are not read-only.
				foreach (DbRelationship relationship in this.relationships)
				{
					// If the relationship is read-only, ignore and continue.
					if (relationship.ReadOnly) continue;
					// Else, add to the document root the relationship XML element.
					document.Root.Add(relationship.Xml);
				}

				// Write the document to registry.
				Registry.SetValue(key, DbRelationships.xmlRoot, Encoding.UTF8.GetBytes(document.ToString()), RegistryValueKind.Binary);
			}
		}
	}
}
