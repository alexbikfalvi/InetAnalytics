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
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using DotNetApi.Windows;
using YtCrawler.Database.Data;

namespace YtCrawler.Database
{
	public delegate void DbTableChangedEventHandler(ITable table);

	/// <summary>
	/// An interface for a database table.
	/// </summary>
	public interface ITable
	{
		// Public properties.

		/// <summary>
		/// Gets the table database object type.
		/// </summary>
		Type Type { get; }
		/// <summary>
		/// Gets the table local name.
		/// </summary>
		string LocalName { get; }
		/// <summary>
		/// Gets or sets the table database name.
		/// </summary>
		string DatabaseName { get; set; }
		/// <summary>
		/// Gets or sets the schema name.
		/// </summary>
		string Schema { get; set; }
		/// <summary>
		/// Gets or sets the database name.
		/// </summary>
		string Database { get; set; }
		/// <summary>
		/// Gets the number of table fields.
		/// </summary>
		int FieldCount { get; }
		/// <summary>
		/// Gets the table fields.
		/// </summary>
		IEnumerable<DbField> Fields { get; }
		/// <summary>
		/// Gets the table field of the specified name.
		/// </summary>
		/// <param name="name">The field name.</param>
		/// <returns>The table field.</returns>
		DbField this[string name] { get; }
		/// <summary>
		/// Returns <b>true</b> if the table is mapped to a database table, or <b>false</b> otherwise.
		/// </summary>
		bool IsConfigured { get; }
		/// <summary>
		/// Indicates whether this table should be displayed read-only to the user.
		/// </summary>
		bool IsReadOnly { get; }
		/// <summary>
		/// Returns <b>true</b> if a query for this table uses the default database.
		/// </summary>
		bool DefaultDatabase { get; set; }
		/// <summary>
		/// Returns <b>true</b> if a database name has been set for this table, or <b>false</b> otherwise.
		/// </summary>
		bool HasDatabaseName { get; }
		/// <summary>
		/// Returns the collection of relationships for the database table.
		/// </summary>
		IEnumerable<IRelationship> Relationships { get; }

		// Public events.

		/// <summary>
		/// An event raised when the configuration of the table has changed.
		/// </summary>
		event DbTableChangedEventHandler TableChanged;

		// Public methods.

		/// <summary>
		/// Creates a new object using data from the specified database reader, and where the object has the specified
		/// type.
		/// </summary>
		/// <param name="reader">The database reader.</param>
		/// <returns>A table object.</returns>
		DbObject New(DbReader reader);
		/// <summary>
		/// Returns the property values for the specified object.
		/// </summary>
		/// <param name="obj">The database object.</param>
		/// <returns>An object array with the properties values.</returns>
		object[] GetValues(DbObject obj);
		/// <summary>
		/// Loads the table configuration from the specified registry key.
		/// </summary>
		/// <param name="key">The registry key.</param>
		void LoadConfiguration(string key);
		/// <summary>
		/// Saves the table configuration at the specified registry key.
		/// </summary>
		/// <param name="key">The registry key.</param>
		void SaveConfiguration(string key);
		/// <summary>
		/// Adds a relationship to the current left field from the right table based on the right field.
		/// </summary>
		/// <param name="relationship">The database relationship.</param>
		void AddRelationship(IRelationship relationship);
	}

	/// <summary>
	/// A class that represents a database table for a generic type.
	/// </summary>
	public class DbTable<T> : ITable where T : DbObject, new()
	{
		private static string xmlRoot = "DbTable";
		private static string xmlRootLocalName = "localName";
		private static string xmlRootDatabaseName = "databaseName";
		private static string xmlRootSchema = "schema";
		private static string xmlRoolDatabase = "database";
		private static string xmlRootDefaultDatabase = "defaultDatabase";
		private static string xmlField = "DbField";
		private static string xmlFieldLocalName = "localName";
		private static string xmlFieldDatabaseName = "databaseName";
		
		private bool readOnly = true;

		private string localName;
		private string databaseName = string.Empty;
		private string schema = string.Empty;
		private string database = string.Empty;

		private bool defaultDatabase = true;

		private Type type;
		private List<DbField> fieldsList = new List<DbField>();
		private Dictionary<string, DbField> fieldsIndex = new Dictionary<string, DbField>();
		private List<IRelationship> relationships = new List<IRelationship>();

		private static char[] tokenSeparators = { ';', ',', ' ' };

		/// <summary>
		/// Creates a new user-customizable table instance.
		/// </summary>
		/// <param name="localName">The local name.</param>
		public DbTable(string localName)
		{
			// Set the table name.
			this.localName = localName;

			// Set the read-only to false.
			this.readOnly = false;

			// Get the type of the database.
			this.type = typeof(T);

			// Initialize the properties for this type.
			this.InitializeProperties(this.type, false);
		}
		
		/// <summary>
		/// Creates a read-only database table instance.
		/// </summary>
		/// <param name="localName">The local table name.</param>
		/// <param name="databaseName">The database table name.</param>
		/// <param name="schema">The schema name.</param>
		/// <param name="database">The database name. The database name is ignored when using the default database.</param>
		/// <param name="defaultDatabase">Indicates if any query for this table uses the default database.</param>
		public DbTable(string localName, string databaseName, string schema, string database, bool defaultDatabase)
		{
			// Set the table properties.
			this.localName = localName;
			this.databaseName = databaseName;
			this.schema = schema;
			this.database = defaultDatabase ? null : database;
			this.defaultDatabase = defaultDatabase;

			// Get the type of the database.
			this.type = typeof(T);

			// Initialize the properties for this type.
			this.InitializeProperties(this.type, true);
		}

		// Public properties.

		/// <summary>
		/// Gets the table database object type.
		/// </summary>
		public Type Type { get { return this.type; } }
		/// <summary>
		/// Gets the local table name.
		/// </summary>
		public string LocalName { get { return this.localName; } }
		/// <summary>
		/// Gets or sets the database table name.
		/// </summary>
		public string DatabaseName
		{
			get { return this.databaseName; }
			set { this.databaseName = value; }
		}
		/// <summary>
		/// Gets or sets the schema name.
		/// </summary>
		public string Schema
		{
			get { return this.schema; }
			set { this.schema = value; }
		}
		/// <summary>
		/// Gets or sets the database name.
		/// </summary>
		public string Database
		{
			get { return this.database; }
			set { this.database = value; }
		}
		/// <summary>
		/// Gets the number of table fields.
		/// </summary>
		public int FieldCount { get { return this.fieldsList.Count; } }
		/// <summary>
		/// Gets the table fields.
		/// </summary>
		public IEnumerable<DbField> Fields { get { return this.fieldsList; } }
		/// <summary>
		/// Gets the table field of the specified name.
		/// </summary>
		/// <param name="name">The field name.</param>
		/// <returns>The table field.</returns>
		public DbField this[string name] { get { return this.fieldsIndex[name]; } }
		/// <summary>
		/// Returns <b>true</b> if the table is mapped to a database table, or <b>false</b> otherwise.
		/// </summary>
		public bool IsConfigured
		{
			get
			{
				// Check the table name and schema name are not null.
				if((this.DatabaseName == null) || (this.Schema == null)) return false;
				// Check the table name and schema name are not empty.
				if((this.DatabaseName == string.Empty) || (this.Schema == string.Empty)) return false;
				// Check the table uses the default database or a database is configured.
				if ((!this.DefaultDatabase) && (this.Database == null)) return false;
				if ((!this.DefaultDatabase) && (this.Database == string.Empty)) return false;
				// Check the table fields are not null.
				foreach (DbField field in this.fieldsList)
				{
					if (!field.HasName) return false;
				}
				// If all above conditions, are met, return true.
				return true;
			}
		}
		/// <summary>
		/// Indicates whether this table should be displayed read-only to the user.
		/// </summary>
		public bool IsReadOnly { get { return this.readOnly; } }
		/// <summary>
		/// Returns <b>true</b> if a query for this table uses the default a database.
		/// </summary>
		public bool DefaultDatabase
		{
			get { return this.defaultDatabase; }
			set { this.defaultDatabase = value; }
		}
		/// <summary>
		/// Returns <b>true</b> if a database name has been set for this table, or <b>false</b> otherwise.
		/// </summary>
		public bool HasDatabaseName
		{
			get
			{
				if (this.databaseName == null) return false;
				if (this.databaseName == string.Empty) return false;
				return true;
			}
		}
		/// <summary>
		/// Returns the relationships corresponding to the current database table.
		/// </summary>
		public IEnumerable<IRelationship> Relationships { get { return this.relationships; } }

		/// <summary>
		/// An event raised when the configuration of the table has changed.
		/// </summary>
		public event DbTableChangedEventHandler TableChanged;

		// Public methods.

		/// <summary>
		/// Loads the table configuration from the specified registry key.
		/// </summary>
		/// <param name="key">The registry key.</param>
		public void LoadConfiguration(string key)
		{
			// If the table is read-only, do nothing.
			if (this.readOnly) return;
			// Read the table registry value.
			byte[] value = Registry.GetBytes(key, this.localName, null);
			// If the value is null, do nothing.
			if (null == value) return;

			try
			{
				// Read the table XML configuration from the value as UTF-8.
				XDocument document = XDocument.Parse(Encoding.UTF8.GetString(value));

				// Check the document root.
				if (document.Root.Name != DbTable<T>.xmlRoot) return;

				// Check the local name.
				if (this.localName != document.Root.Attribute(DbTable<T>.xmlRootLocalName).Value) return;

				// Read the database name.
				this.databaseName = document.Root.Attribute(DbTable<T>.xmlRootDatabaseName).Value;
				// Read the schema name.
				this.schema = document.Root.Attribute(DbTable<T>.xmlRootSchema).Value;
				// Read the database name.
				this.database = document.Root.Attribute(DbTable<T>.xmlRoolDatabase).Value;
				// Read if the table requires a database.
				this.defaultDatabase = Boolean.Parse(document.Root.Attribute(DbTable<T>.xmlRootDefaultDatabase).Value);

				// Read the table fields.
				foreach (XElement element in document.Root.Elements(DbTable<T>.xmlField))
				{
					// Read the field local name.
					string localName = element.Attribute(DbTable<T>.xmlFieldLocalName).Value;
					// Read the field database name.
					string databaseName = element.Attribute(DbTable<T>.xmlFieldDatabaseName).Value;
					// Get the table field using the local name.
					DbField field = this[localName];
					// If the field does not exist, ignore the XML and move to the next entry.
					if (null == field) continue;
					// Otherwise, set the field database name.
					field.DatabaseName = databaseName;
				}
			}
			catch (Exception)
			{
				// If any exception occurs, do nothing.
			}
		}

		/// <summary>
		/// Saves the table configuration at the specified registry key.
		/// </summary>
		/// <param name="key">The registry key.</param>
		public void SaveConfiguration(string key)
		{
			// If the table is read-only, do nothing.
			if (this.readOnly) return;

			// Create the root XML element.
			XElement element = new XElement(DbTable<T>.xmlRoot, 
				new XAttribute(DbTable<T>.xmlRootLocalName, this.localName),
				new XAttribute(DbTable<T>.xmlRootDatabaseName, this.databaseName),
				new XAttribute(DbTable<T>.xmlRootSchema, this.schema),
				new XAttribute(DbTable<T>.xmlRoolDatabase, this.database),
				new XAttribute(DbTable<T>.xmlRootDefaultDatabase, this.defaultDatabase)
				);

			// Add the field elements.
			foreach(DbField field in this.fieldsList)
			{
				element.Add(new XElement(DbTable<T>.xmlField,
					new XAttribute(DbTable<T>.xmlFieldLocalName, field.Property.Name),
					new XAttribute(DbTable<T>.xmlFieldDatabaseName, field.HasName ? field.DatabaseName : string.Empty)
					));
			}

			// Create a new XML document for this table.
			XDocument document = new XDocument(element);
			// Write the document to registry.
			Registry.SetBytes(key, this.localName, Encoding.UTF8.GetBytes(document.ToString()));
			// Raise the table changed event.
			if (this.TableChanged != null) this.TableChanged(this);
		}

		/// <summary>
		/// Creates a new object using data from the specified database reader.
		/// </summary>
		/// <param name="reader">The database reader.</param>
		/// <returns>A table object.</returns>
		public DbObject New(DbReader reader)
		{
			// Create a new object.
			T obj = new T();
			// Initialize the object using the data from the database reader.
			foreach (DbField field in this.fieldsList)
			{
				// Get the value of the corresponding column from the reader,
				// and set the value to the object property.
				object value = reader[field.DatabaseName];

				// If the type is nullable, and the data value is null.
				if (field.Attribute.IsNullable && Convert.IsDBNull(value))
				{
					// Set the property value to null.
					type.GetProperty(field.Property.Name).SetValue(obj, null, null);
				}
				else
				{
					// Else, set the actual value.
					type.GetProperty(field.Property.Name).SetValue(obj, value, null);
				}
			}
			// Return the object.
			return obj;
		}

		/// <summary>
		/// Creates a new object using data from the data table row.
		/// </summary>
		/// <param name="data">The data table.</param>
		/// <param name="row">The row index.</param>
		/// <returns>A table object.</returns>
		public T New(DbDataRaw data, int row)
		{
			// Create a new object.
			T obj = new T();
			// Get the object type.
			Type type = typeof(T);
			// Initialize the object using the data from the database reader.
			foreach (DbField field in this.fieldsList)
			{
				// Get the value of the corresponding column from the reader,
				// and set the value to the object property.
				object value = data[field.DatabaseName, row];

				// If the type is nullable, and the data value is null.
				if (field.Attribute.IsNullable && Convert.IsDBNull(value))
				{
					// Set the property value to null.
					this.type.GetProperty(field.Property.Name).SetValue(obj, null, null);
				}
				else
				{
					// Else, set the actual value.
					this.type.GetProperty(field.Property.Name).SetValue(obj, value, null);
				}
			}
			// Return the object.
			return obj;
		}

		/// <summary>
		/// Returns the property values for the specified object.
		/// </summary>
		/// <param name="obj">The database object.</param>
		/// <returns>An object array with the properties values.</returns>
		public object[] GetValues(DbObject obj)
		{
			// Check that the type of the object matches the type of the table.
			if (obj.GetType() != this.type) throw new DbException(string.Format("Cannot get the object property values because the object type \'{0}\' does not match the table type \'{1}\'.", obj.GetType(), this.type));
			// Create an array for the object values.
			object[] values = new object[this.FieldCount];
			// Copy the object properties to the values array.
			int index = 0;
			foreach (DbField field in this.Fields)
			{
				values[index++] = this.type.GetProperty(field.Property.Name).GetValue(obj, null);
			}
			// Return the object property values.
			return values;
		}

		/// <summary>
		/// Adds a relationship to the current left field from the right table based on the right field.
		/// </summary>
		/// <param name="relationship">The database relationship.</param>
		public void AddRelationship(IRelationship relationship)
		{
			// Check the relationship left table matches the current table.
			if (relationship.TableLeft != this) throw new DbException("Cannot add a relationship because the left table does not match the current table.");
			// Add the relationship.
			this.relationships.Add(relationship);
		}

		// Private methods.

		private void InitializeProperties(Type type, bool checkDatabaseName)
		{
			// If this type has a base type, first parse the properties of the base type.
			if (type.BaseType != null) this.InitializeProperties(type.BaseType, checkDatabaseName);
			// Initialize the table fields, based on the type properties.
			foreach (PropertyInfo property in this.type.GetProperties())
			{
				// If the declating type for this property is not the current type, ignore and continue.
				if (property.DeclaringType != type) continue;
				// Get the database attributes for this properties.
				object[] attributes = property.GetCustomAttributes(typeof(DbAttribute), true);
				// If there are no database attributes, ignore the property and continue.
				if (attributes.Length == 0) continue;
				// Else, use the first attribute to set the field.
				DbAttribute attribute = attributes[0] as DbAttribute;
				if (checkDatabaseName)
				{
					// If the attribute does not have the name set, throw an exception.
					if (attribute.Name == null) throw new DbFieldException("The property attribute does not have a database field name set.", property.Name);
					if (attribute.Name == string.Empty) throw new DbFieldException("The property attribute does not have a database field name set.", property.Name);
				}
				// Create the field for this property.
				DbField field = new DbField(property, attribute);
				// Add the field to the fields list.
				this.fieldsList.Add(field);
				// Add the field to the fields index.
				this.fieldsIndex.Add(property.Name, field);
			}
		}
	}
}
