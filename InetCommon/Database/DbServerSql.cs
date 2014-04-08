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
using System.Data;
using System.Security;
using System.Threading;
using Microsoft.Win32;
using DotNetApi;
using InetCommon.Database.Data;
using InetCommon.Log;

namespace InetCommon.Database
{
	/// <summary>
	/// A class representing a database server.
	/// </summary>
	public abstract class DbServerSql : DbServer
	{
		/// <summary>
		/// An enumeration representing the SQL database server type.
		/// </summary>
		public enum DbType
		{
			[Description("Microsoft SQL server")]
			MsSql = 0,
			[Description("MySQL server")]
			MySql = 1
		};

		// The server type.
		private readonly DbType type;

		// Database tables and relationships.
		private DbTables tables;
		private DbRelationships relationships;

		/// <summary>
		/// Creates a database server with the specified name and configuration.
		/// </summary>
		/// <param name="config">The configuration.</param>
		/// <param name="type">The SQL server type.</param>
		/// <param name="key">The registry configuration key.</param>
		/// <param name="id">The server ID.</param>
		/// <param name="logFile">The log file for this database server.</param>
		public DbServerSql(IConfig config, DbType type, RegistryKey key, Guid id, string logFile)
			: base(config, DbServerClass.Sql, key, id, logFile)
		{
			// Set the server type.
			this.type = type;

			// Create the database tables and relationships.
			this.tables = new DbTables(this.Key);
			this.relationships = new DbRelationships(this.Key, this.tables);

			// Set the event handlers.
			this.tables.TableAdded += this.OnTableAdded;
			this.tables.TableChanged += this.OnTableChanged;
			this.tables.TableRemoved += this.OnTableRemoved;

			this.relationships.RelationshipAdded += this.OnRelationshipAdded;
			this.relationships.RelationshipRemoved += this.OnRelationshipRemoved;

			// Load the current configuration.
			this.LoadInternalConfiguration();
		}

		/// <summary>
		/// Creates a database server with the specified parameters.
		/// </summary>
		/// <param name="type">The SQL server type.</param>
		/// <param name="key">The registry configuration key.</param>
		/// <param name="id">The server ID.</param>
		/// <param name="name">The server name.</param>
		/// <param name="dataSource">The data source.</param>
		/// <param name="username">The username.</param>
		/// <param name="password">The password.</param>
		/// <param name="logFile">The log file for this database server.</param>
		/// <param name="dateCreated">The date when the server was created.</param>
		/// <param name="dateModified">The date when the server was last modified.</param>
		public DbServerSql(
			DbType type,
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
			: base(DbServerClass.Sql, key, id, name, dataSource, username, password, logFile, dateCreated, dateModified)
		{
			// Set the server type.
			this.type = type;

			// Create the database tables and relationships.
			this.tables = new DbTables(this.Key);
			this.relationships = new DbRelationships(this.Key, this.tables);

			// Set the event handlers.
			this.tables.TableAdded += this.OnTableAdded;
			this.tables.TableChanged += this.OnTableChanged;
			this.tables.TableRemoved += this.OnTableRemoved;

			this.relationships.RelationshipAdded += this.OnRelationshipAdded;
			this.relationships.RelationshipRemoved += this.OnRelationshipRemoved;

			// Save the configuration.
			this.SaveInternalConfiguration();
		}


		// Public properties.

		/// <summary>
		/// Gets the database server type.
		/// </summary>
		public DbType Type { get { return this.type; } }
		/// <summary>
		/// Gets the server type name.
		/// </summary>
		public override string TypeName { get { return this.type.GetDescription(); } }
		/// <summary>
		/// Gets the default database for this server.
		/// </summary>
		public abstract DbObjectDatabase Database { get; set; }
		/// <summary>
		/// Gets the list of database tables for this database server.
		/// </summary>
		public IEnumerable<ITable> Tables { get { return this.tables; } }
		/// <summary>
		/// Gets the list of database relationships for this database server.
		/// </summary>
		public IEnumerable<DbRelationship> Relationships { get { return this.relationships; } }
		/// <summary>
		/// Gets the database table for this server.
		/// </summary>
		public abstract ITable TableDatabase { get; }
		/// <summary>
		/// Gets the schema table for this server.
		/// </summary>
		public abstract ITable TableSchema { get; }
		/// <summary>
		/// Gets the type table for this server.
		/// </summary>
		public abstract ITable TableTypes { get; }
		/// <summary>
		/// Gets the tables table for this server.
		/// </summary>
		public abstract ITable TableTables { get; }
		/// <summary>
		/// Gets the columns table for this server.
		/// </summary>
		public abstract ITable TableColumns { get; }

		// Public events.

		/// <summary>
		/// An event raised when the server default database has changed.
		/// </summary>
		public event DbServerDatabaseChangedEventHandler DatabaseChanged;
		/// <summary>
		/// An event raised when a server database table has been added.
		/// </summary>
		public event DbServerTableEventHandler TableAdded;
		/// <summary>
		/// An event raised when a server database table has been removed.
		/// </summary>
		public event DbServerTableEventHandler TableRemoved;
		/// <summary>
		/// An event raised when a server database table has changed.
		/// </summary>
		public event DbServerTableEventHandler TableChanged;
		/// <summary>
		/// An event raised when a server database relationship has been added.
		/// </summary>
		public event DbServerRelationshipEventHandler RelationshipAdded;
		/// <summary>
		/// An event raised when a server database relationship has been removed.
		/// </summary>
		public event DbServerRelationshipEventHandler RelationshipRemoved; 

		// Public methods.

		/// <summary>
		/// Loads the server configuration.
		/// </summary>
		public override void LoadConfiguration()
		{
			// Load the base configuration.
			base.LoadConfiguration();
			// Load the custom configuration.
			this.LoadInternalConfiguration();
		}

		/// <summary>
		/// Saves the server configuration.
		/// </summary>
		public override void SaveConfiguration()
		{
			// Save the base configuration.
			base.SaveConfiguration();
			// Save the custom configuration.
			this.SaveInternalConfiguration();
		}

		/// <summary>
		/// Creates a new database command with the specified query.
		/// </summary>
		/// <param name="query">The database query.</param>
		/// <returns>The database command.</returns>
		public abstract DbCommand CreateCommand(DbQuerySql query);

		/// <summary>
		/// Creates a new database command with the specified query and transaction.
		/// </summary>
		/// <param name="query">The database query.</param>
		/// <param name="transaction">The database transaction.</param>
		/// <returns>The database command.</returns>
		public abstract DbCommand CreateCommand(DbQuerySql query, DbTransaction transaction);

		/// <summary>
		/// Creates and begins a new database transaction.
		/// </summary>
		/// <param name="isolation">The transaction isolation level.</param>
		/// <returns>A transaction object to use with subsequent commands within the transaction.</returns>
		public abstract DbTransaction BeginTransaction(IsolationLevel isolation);

		/// <summary>
		/// Adds the specified table to the database server.
		/// </summary>
		/// <param name="table">The table.</param>
		public void AddTable(ITable table)
		{
			// Validate the arguments.
			if (null == table) throw new ArgumentNullException("table");

			// Add the table to the tables list.
			this.tables.Add(table);
		}

		/// <summary>
		/// Adds a table to the database server based on the specified table template.
		/// </summary>
		/// <param name="template">The table template.</param>
		public void AddTable(DbTableTemplate template)
		{
			// Validate the arguments.
			if (null == template) throw new ArgumentNullException("template");

			// Create the table and add it to the tables list.
			this.tables.Add(DbTable.Create(template));
		}

		/// <summary>
		/// Removes the specified table.
		/// </summary>
		/// <param name="table">The table.</param>
		public void RemoveTable(ITable table)
		{
			// Validate the arguments.
			if (null == table) throw new ArgumentNullException("table");

			// Remove the table.
			this.tables.Remove(table.Id);

			// Remove any relationship with the specified table.
			this.relationships.Remove(table.Id);
		}

		/// <summary>
		/// Removes the specified table based on the table template.
		/// </summary>
		/// <param name="template">The table template.</param>
		public void RemoveTable(DbTableTemplate template)
		{
			// Validate the arguments.
			if (null == template) throw new ArgumentNullException("template");

			// Remove the table.
			this.tables.Remove(template.Id);

			// Remove any relationship with the specified table.
			this.relationships.Remove(template.Id);
		}

		/// <summary>
		/// Adds a relationship to the database server.
		/// </summary>
		/// <param name="leftTable">The left table.</param>
		/// <param name="rightTable">The right table.</param>
		/// <param name="leftField">The left field.</param>
		/// <param name="rightField">The right field.</param>
		/// <param name="readOnly">Indicates if the relationship is read-only.</param>
		public void AddRelationship(ITable leftTable, ITable rightTable, string leftField, string rightField, bool readOnly = true)
		{
			// Validate the arguments.
			if (null == leftTable) throw new ArgumentNullException("leftTable");
			if (null == rightTable) throw new ArgumentNullException("rightTable");
			if (string.IsNullOrWhiteSpace(leftField)) new ArgumentException("The relationship field cannot be null or empty.", "leftField");
			if (string.IsNullOrWhiteSpace(rightField)) new ArgumentException("The relationship field cannot be null or empty.", "rightField");

			// Check the relationship tables exist.
			if (!this.tables.HasTable(leftTable.Id)) throw new DbException("Cannot add a relationship because the left table does not exist.");
			if (!this.tables.HasTable(rightTable.Id)) throw new DbException("Cannot add a relationship because the right table does not exist.");

			// Add the relationship.
			this.relationships.Add(leftTable, rightTable, leftField, rightField, readOnly);
		}

		/// <summary>
		/// Adds a relationship to the database server based on the specified template.
		/// </summary>
		/// <param name="template">The relationship template.</param>
		public void AddRelationship(DbRelationshipTemplate template)
		{
			// Validate the arguments.
			if (null == template) throw new ArgumentNullException("template");

			// Find the relationship tables.
			ITable leftTable;
			ITable rightTable;

			if (!this.tables.TryGetTable(template.LeftTable.Id, out leftTable)) throw new DbException("Cannot add a relationship because the left table does not exist.");
			if (!this.tables.TryGetTable(template.RightTable.Id, out rightTable)) throw new DbException("Cannot add a relationship because the right table does not exist.");

			// Add the relationship.
			this.relationships.Add(leftTable, rightTable, template.LeftField, template.RightField, template.ReadOnly);
		}

		/// <summary>
		/// Removes a relationship from the database server based on the specified template.
		/// </summary>
		/// <param name="template">The relationship template.</param>
		public void RemoveRelationship(DbRelationshipTemplate template)
		{
			// Validate the arguments.
			if (null == template) throw new ArgumentNullException("template");

			// Remove the relationship.
			this.relationships.Remove(template.LeftTable.Id, template.RightTable.Id, template.LeftField, template.RightField);
		}

		// Protected methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		/// <param name="disposing">If <b>true</b>, clean both managed and native resources. If <b>false</b>, clean only native resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				// Dispose the database tables.
				this.tables.Dispose();
			}
			// Call the base class method.
			base.Dispose(disposing);
		}

		/// <summary>
		/// An event handler called when the current database has changed.
		/// </summary>
		/// <param name="oldDatabase">The old database.</param>
		/// <param name="newDatabase">The new database.</param>
		protected void OnDatabaseChanged(DbObjectDatabase oldDatabase, DbObjectDatabase newDatabase)
		{
			// Call the event.
			if (this.DatabaseChanged != null) this.DatabaseChanged(this, new DbServerDatabaseChangedEventArgs(this, oldDatabase, newDatabase));
		}

		// Private methods.

		/// <summary>
		/// Saves the current server configuration to the registry.
		/// </summary>
		private void SaveInternalConfiguration()
		{
			// Save tables and relationship configuration.
			this.tables.SaveConfiguration();
			this.relationships.SaveConfiguration();
		}

		/// <summary>
		/// Loads the current server configuration from the registry.
		/// </summary>
		private void LoadInternalConfiguration()
		{
			// Load tables and relationships configuration.
			this.tables.LoadConfiguration();
			this.relationships.LoadConfiguration();
		}

		/// <summary>
		/// An event handler called when a table has been added.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		void OnTableAdded(object sender, DbTableEventArgs e)
		{
			// Raise the server event.
			if (this.TableAdded != null) this.TableAdded(this, new DbServerTableEventArgs(this, e.Table));
		}

		/// <summary>
		/// An event handler called when a table has been removed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		void OnTableRemoved(object sender, DbTableEventArgs e)
		{
			// Raise the server event.
			if (this.TableRemoved != null) this.TableRemoved(this, new DbServerTableEventArgs(this, e.Table));
		}

		/// <summary>
		/// An event handler called when a database table has changed.
		/// </summary>
		/// <param name="server">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnTableChanged(object sender, DbTableEventArgs e)
		{
			// Raise the server event.
			if (this.TableChanged != null) this.TableChanged(this, new DbServerTableEventArgs(this, e.Table));
		}

		/// <summary>
		/// An event handler called when a database relatioship has been added.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRelationshipAdded(object sender, DbRelationshipEventArgs e)
		{
			// Raise the server event.
			if (this.RelationshipAdded != null) this.RelationshipAdded(this, new DbServerRelationshipEventArgs(this, e.Relationship));
		}

		/// <summary>
		/// An event handler called when a database relationship has been removed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRelationshipRemoved(object sender, DbRelationshipEventArgs e)
		{
			// Raise the server event.
			if (this.RelationshipRemoved != null) this.RelationshipRemoved(this, new DbServerRelationshipEventArgs(this, e.Relationship));
		}
	}
}
