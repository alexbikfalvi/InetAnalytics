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
using System.Windows.Forms;
using YtAnalytics.Forms.Database;
using YtCrawler.Database;
using YtCrawler.Database.Data;
using DotNetApi;
using DotNetApi.Windows.Controls;

namespace YtAnalytics.Controls.Database
{
	/// <summary>
	/// Displays the information of a database table.
	/// </summary>
	public partial class ControlTableProperties : ControlDatabase
	{
		private delegate void QuerySuccessAction(DbDataObject result, int recordsAffected);

		private DbServer server;
		private ITable table;
		
		private readonly FormDatabaseSelect formDatabaseSelect = new FormDatabaseSelect();
		private readonly FormFieldProperties formField = new FormFieldProperties();
		private readonly FormRelationshipProperties formRelationship = new FormRelationshipProperties();
		private readonly FormCompareFields formCompareFields = new FormCompareFields();

		private DbDataObject resultTables = null;
		private DbDataObject resultDatabases = null;
		private DbDataObject resultSchemas = null;
		private DbDataObject resultColumns = null;
		private DbObjectTable resultTable = null;
		private DbObjectDatabase resultDatabase = null;
		private DbObjectSchema resultSchema = null;
		private DbObjectColumn resultColumn = null;

		private QuerySuccessAction delegateQueryTableSchema;
		private QuerySuccessAction delegateQueryColumnType;

		private bool changes = false;

		/// <summary>
		/// Creates a new log event control instance.
		/// </summary>
		public ControlTableProperties()
		{
			InitializeComponent();

			// Create the delegates.
			this.delegateQueryTableSchema = new QuerySuccessAction(this.OnQuerySuccessTableSchema);
			this.delegateQueryColumnType = new QuerySuccessAction(this.OnQuerySuccessColumnType);
		}

		// Public properties.

		/// <summary>
		/// Gets the current database table.
		/// </summary>
		public ITable Table { get { return this.table; } }
		/// <summary>
		/// Gets the current database server.
		/// </summary>
		public DbServer Server { get { return this.server; } }
		/// <summary>
		/// Gets the new database table name.
		/// </summary>
		public string DbName { get { return this.textBoxNameDatabase.Text; } }
		/// <summary>
		/// Gets the new schema name.
		/// </summary>
		public string Schema { get { return this.textBoxSchema.Text; } }

		// Public events.

		/// <summary>
		/// An event raised when the table configuration has changed.
		/// </summary>
		public event EventHandler ConfigurationChanged;
		/// <summary>
		/// An event raised when the table configuration was saved.
		/// </summary>
		public event EventHandler ConfigurationSaved;
		/// <summary>
		/// An event raised when a database operation has started.
		/// </summary>
		public event EventHandler DatabaseOperationStarted;
		/// <summary>
		/// An event raised when a database operation has finished.
		/// </summary>
		public event EventHandler DatabaseOperationFinished;

		// Public methods.
		
		/// <summary>
		/// Selects a table at the given database server for display.
		/// </summary>
		/// <param name="server">The database server.</param>
		/// <param name="table">The table.</param>
		public void Select(DbServer server, ITable table)
		{
			// Set the parameters.
			this.server = server;
			this.table = table;

			// Reset the results.
			this.resultTables = null;
			this.resultDatabases = null;
			this.resultSchemas = null;
			this.resultColumns = null;
			this.resultTable = null;
			this.resultDatabase = null;
			this.resultSchema = null;

			// Initialize the control.
			this.labelTitle.Text = table.LocalName;
			this.textBoxNameLocal.Text = table.LocalName;
			this.textBoxNameDatabase.Text = table.DatabaseName;
			this.textBoxSchema.Text = table.Schema;
			this.textBoxDatabase.Text = table.DefaultDatabase ? "(default)" : table.Database;
			this.checkBoxDefaultDatabase.Checked = table.DefaultDatabase;
			this.checkBoxReadOnly.Checked = table.IsReadOnly;
			this.pictureBox.Image = table.IsConfigured ? Resources.TableSuccess_32 : Resources.TableWarning_32;
			// The table fields.
			this.listViewFields.Items.Clear();
			foreach (DbField field in table.Fields)
			{
				// If the property type is nullable, replace it with the boxed type.
				ListViewItem item = new ListViewItem(new string[] {
							field.Property.Name,
							field.HasName ? field.GetDatabaseName() : string.Empty,
							field.LocalType,
							field.DatabaseType,
							field.IsNullable ? "Yes" : "No"
						});
				item.ImageKey = field.HasName ? "Field" : "FieldWarning";
				item.Tag = field;
				this.listViewFields.Items.Add(item);
			}
			// The table relationships.
			this.listViewRelationships.Items.Clear();
			foreach (IRelationship relationship in table.Relationships)
			{
				ListViewItem item = new ListViewItem(new string[] {
					relationship.TableRight.LocalName,
					relationship.FieldLeft,
					relationship.FieldRight });
				item.ImageKey = "Relationship";
				item.Tag = relationship;
				this.listViewRelationships.Items.Add(item);
			}

			// Set the enabled state.
			this.buttonSelectTable.Enabled = !table.IsReadOnly;
			this.buttonSelectDatabase.Enabled = !table.IsReadOnly;
			this.buttonSelectField.Enabled = false;
			this.checkBoxDefaultDatabase.Enabled = !table.IsReadOnly && !table.DefaultDatabase;

			// Set the focus.
			this.tabControl.SelectedTab = this.tabPageGeneral;
			this.textBoxNameLocal.Select();
			this.textBoxNameLocal.SelectionStart = 0;
			this.textBoxNameLocal.SelectionLength = 0;
		}

		/// <summary>
		/// Saves the changes made to the current database table.
		/// </summary>
		public void SaveConfiguration()
		{
			// Apply general changes.
			if (this.resultTable != null) this.table.DatabaseName = this.resultTable.Name;
			if (this.resultDatabase != null) this.table.Database = this.resultDatabase.Name;
			if (this.resultSchema != null) this.table.Schema = this.resultSchema.Name;
			this.table.DefaultDatabase = this.checkBoxDefaultDatabase.Checked;
			// Apply field changes.
			foreach (ListViewItem item in this.listViewFields.Items)
			{
				// Get the table field.
				DbField field = item.Tag as DbField;
				// Set the field database name.
				field.SetDatabaseName(item.SubItems[1].Text);
			}
			// Update the table image.
			this.pictureBox.Image = table.IsConfigured ? Resources.TableSuccess_32 : Resources.TableWarning_32;
			// Set the changes to false.
			this.changes = false;
			// Save the server configuration.
			this.server.SaveConfiguration();
			// Raise a configuration saved event.
			if (this.ConfigurationSaved != null) this.ConfigurationSaved(this, EventArgs.Empty);
		}

		// Protected methods.

		/// <summary>
		/// A method called when started connecting to the database server.
		/// </summary>
		/// <param name="server">The database server.</param>
		protected override void OnConnectStarted(DbServer server)
		{
			// Disable the control.
			this.tabControl.Enabled = false;
			// Raise the database operation started event.
			if (this.DatabaseOperationStarted != null) this.DatabaseOperationStarted(this, EventArgs.Empty);
		}

		/// <summary>
		/// A method called when connecting to the database server completed successfully.
		/// </summary>
		/// <param name="server">The database server.</param>
		protected override void OnConnectSucceeded(DbServer server)
		{
			// Enable the control.
			this.tabControl.Enabled = true;
			// Raise the database operation finished event.
			if (this.DatabaseOperationFinished != null) this.DatabaseOperationFinished(this, EventArgs.Empty);
		}

		/// <summary>
		/// A method called when connecting to the database server failed.
		/// </summary>
		/// <param name="server">The database server.</param>
		protected override void OnConnectFailed(DbServer server)
		{
			// Enable the control.
			this.tabControl.Enabled = true;
			// Raise the database operation finished event.
			if (this.DatabaseOperationFinished != null) this.DatabaseOperationFinished(this, EventArgs.Empty);
		}

		/// <summary>
		/// A method called when staring a query.
		/// </summary>
		/// <param name="server">The database server.</param>
		/// <param name="query">The database query.</param>
		/// <param name="command">The database command.</param>
		protected override void OnQueryStarted(DbServer server, DbQuery query, DbCommand command)
		{
			// Disable the control.
			this.tabControl.Enabled = false;
			// Raise the database operation started event.
			if (this.DatabaseOperationStarted != null) this.DatabaseOperationStarted(this, EventArgs.Empty);
		}

		/// <summary>
		/// A method called when a query completed successfully.
		/// </summary>
		/// <param name="server">The database server.</param>
		/// <param name="query">The database query.</param>
		/// <param name="result">The database result.</param>
		/// <param name="recordsAffected">The number of records affected.</param>
		protected override void OnQuerySucceeded(DbServer server, DbQuery query, DbDataObject result, int recordsAffected)
		{
			// Enable the control.
			this.tabControl.Enabled = true;
			// Raise the database operation finished event.
			if (this.DatabaseOperationFinished != null) this.DatabaseOperationFinished(this, EventArgs.Empty);
			// If the query state is not null.
			if (query.State != null)
			{
				// If the query state is a delegate.
				if (query.State is QuerySuccessAction)
				{
					// Get the call the delegate.
					QuerySuccessAction handler = query.State as QuerySuccessAction;
					handler(result, recordsAffected);
				}
			}
		}

		/// <summary>
		/// A method called when a query failed.
		/// </summary>
		/// <param name="server">The database server.</param>
		/// <param name="query">The database query.</param>
		/// <param name="exception">The exception.</param>
		protected override void OnQueryFailed(DbServer server, DbQuery query, Exception exception)
		{
			// Enable the control.
			this.tabControl.Enabled = true;
			// Raise the database operation finished event.
			if (this.DatabaseOperationFinished != null) this.DatabaseOperationFinished(this, EventArgs.Empty);
		}

		// Private methods.

		/// <summary>
		/// An event handler called when the selected table field has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelectedFieldChanged(object sender, EventArgs e)
		{
			// If there are no selected fields, do nothing.
			if (this.listViewFields.SelectedItems.Count == 0)
				this.buttonSelectField.Enabled = false;
			else
				this.buttonSelectField.Enabled = !this.table.IsReadOnly;
		}

		/// <summary>
		/// An event handler called when the user selects a new table.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelectTable(object sender, EventArgs e)
		{
			try
			{
				// Open a new database select window that selects all database tables for the given server.
				if (this.formDatabaseSelect.ShowDialog(this, this.server, this.server.TableTables, this.resultTables) == DialogResult.OK)
				{
					// Get the results.
					this.resultTables = this.formDatabaseSelect.AllResults;
					this.resultTable = this.formDatabaseSelect.SelectedResult as DbObjectTable;
					this.resultColumns = null;
					// Set the name.
					this.textBoxNameDatabase.Text = this.resultTable.Name;
					// Raise a configuration changed event.
					if (this.ConfigurationChanged != null) this.ConfigurationChanged(this, EventArgs.Empty);
					// Set the changes to false.
					this.changes = true;
					// Create a new query to obtain the schema of the selected table.
					DbQuery query = DbQuery.CreateSelectAllOn(this.server.TableSchema, this.server.TableTables, "Name", this.resultTable.Name, this.server.Database, this.delegateQueryTableSchema);
					query.MessageStart = "Updating the database schema for the table \'{0}\'.".FormatWith(this.resultTable.Name);
					query.MessageFinishSuccess = "Updating the database schema for the table \'{0}\' completed successfully.".FormatWith(this.resultTable.Name);
					query.MessageFinishFail = "Updating the database schema for the table \'{0}\' failed".FormatWith(this.resultTable.Name);
					// Get the table schema.
					this.DatabaseQuery(this.server, query);
				}
			}
			catch (Exception exception)
			{
				// If an error occurs, show an error message.
				MessageBox.Show(this,
					"Changing the table database name failed. {0}".FormatWith(exception.Message),
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// An event handler called when the user selects a new database.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelectDatabase(object sender, EventArgs e)
		{
			try
			{
				// Open a new database select window that selects all database tables for the given server.
				if (this.formDatabaseSelect.ShowDialog(this, this.server, this.server.TableDatabase, this.resultDatabases) == DialogResult.OK)
				{
					// Get the result.
					this.resultDatabases = this.formDatabaseSelect.AllResults;
					this.resultDatabase = this.formDatabaseSelect.SelectedResult as DbObjectDatabase;
					this.resultColumns = null;
					// Set the name.
					this.textBoxDatabase.Text = "{0} (custom)".FormatWith(this.resultDatabase.Name);
					// Uncheck and enable the uses default database check box.
					this.checkBoxDefaultDatabase.Checked = false;
					this.checkBoxDefaultDatabase.Enabled = true;
					// Raise a configuration changed event.
					if (this.ConfigurationChanged != null) this.ConfigurationChanged(this, EventArgs.Empty);
					// Set the changes to true.
					this.changes = true;
				}
			}
			catch (Exception exception)
			{
				// If an error occurs, show an error message.
				MessageBox.Show(this,
					"Changing the table database failed. {0}".FormatWith(exception.Message),
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// An event handler called when the user selects a new field.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelectField(object sender, EventArgs e)
		{
			// If there are pending changes, ask the user to save before continuing.
			if (this.changes)
			{
				if (DialogResult.Yes == MessageBox.Show(this,
					"There are pending changes for this table and you cannot modify the table until all changes have been saved. Do you want to save the changes now?",
					"Pending Table Changes",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question))
				{
					// Save the changes.
					this.SaveConfiguration();
				}
				else return;
			}
			// Check the table has a database name.
			if ((this.table.DatabaseName == null) || (this.table.DatabaseName == string.Empty))
			{
				MessageBox.Show(
					this,
					"Cannot change the field for the current table, because the table does not have a database name yet.",
					"Cannot Change Table Field",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}
			// Check the table has a database (either the default database or a custom one.
			if ((!this.table.DefaultDatabase) && ((this.table.Database == null) || (this.table.Database == string.Empty)))
			{
				MessageBox.Show(
					this,
					"Cannot change the field for the current table, because the table does not have a database yet.",
					"Cannot Change Table Field",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}
			
			try
			{
				// Create a new query to obtain the columns of the selected table.
				DbQuery queryColumn = DbQuery.CreateSelectAllOn(this.server.TableColumns, this.server.TableTables, "Name", this.table.DatabaseName, this.server.Database);
				queryColumn.MessageStart = "Updating the fields list for the table \'{0}\'.".FormatWith(this.table.DatabaseName);
				queryColumn.MessageFinishSuccess = "Updating the fields list for the table \'{0}\' completed successfully.".FormatWith(this.table.DatabaseName);
				queryColumn.MessageFinishFail = "Updating the fields list for the table \'{0}\' failed".FormatWith(this.table.DatabaseName);
				
				// Open a new database select window that selects all database columns for the given server and table.
				if (this.formDatabaseSelect.ShowDialog(this, this.server, queryColumn, this.resultColumns) == DialogResult.OK)
				{
					// Get the result.
					this.resultColumn = this.formDatabaseSelect.SelectedResult as DbObjectColumn;
					this.resultColumns = this.formDatabaseSelect.AllResults;
					
					// Create a new query to obtain the type of the selected column.
					DbQuery queryType = DbQuery.CreateSelectAllOn(this.server.TableTypes, this.server.TableColumns, new string[] {"ObjectId", "ColumnId"}, new object[] {this.resultColumn.ObjectId, this.resultColumn.ColumnId}, this.server.Database, this.delegateQueryColumnType);
					queryType.MessageStart = "Updating the type for the table field \'{0}\'.".FormatWith(this.resultColumn.Name);
					queryType.MessageFinishSuccess = "Updating the type for the table field \'{0}\' completed successfully.".FormatWith(this.resultColumn.Name);
					queryType.MessageFinishFail = "Updating the type for the table field \'{0}\' failed".FormatWith(this.resultColumn.Name);
					// Get the column type.
					this.DatabaseQuery(this.server, queryType);
				}
			}
			catch (Exception exception)
			{
				// If an error occurs, show an error message.
				MessageBox.Show(this,
					"Changing the table field failed. {0}".FormatWith(exception.Message),
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// An event handler called when the query for the table schema completed succesfully.
		/// </summary>
		/// <param name="result">The database result.</param>
		/// <param name="recordsAffected">The number of records affected.</param>
		private void OnQuerySuccessTableSchema(DbDataObject result, int recordsAffected)
		{
			// Check the query result has at least one record.
			if (result.RowCount == 0)
			{
				MessageBox.Show(this,
					"A query for the schema of table \'{0}\' did not return any database schema.".FormatWith(this.textBoxNameDatabase.Text),
					"Table Schema Not Found",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return;
			}
			// Get the results.
			this.resultSchemas = result;
			this.resultSchema = null;
			// If the query result has at most one record, let the user select one schema.
			if (result.RowCount > 1)
			{
				try
				{
					// Create a new query to obtain the schema of the selected table.
					DbQuery query = DbQuery.CreateSelectAllOn(this.server.TableSchema, this.server.TableTables, "Name", this.resultTable.Name, this.server.Database, this.delegateQueryTableSchema);

					query.MessageStart = "Updating the database schema for the table \'{0}\'.".FormatWith(this.resultTable.Name);
					query.MessageFinishSuccess = "Updating the database schema for the table \'{0}\' completed successfully.".FormatWith(this.resultTable.Name);
					query.MessageFinishFail = "Updating the database schema for the table \'{0}\' failed".FormatWith(this.resultTable.Name);

					// Repeat until the user selects a schema.
					do
					{
						// Open a new database select window that selects all database tables for the given server.
						if (this.formDatabaseSelect.ShowDialog(this, this.server, query, this.resultSchemas) == DialogResult.OK)
						{
							// Get the results.
							this.resultSchemas = this.formDatabaseSelect.AllResults;
							this.resultSchema = this.formDatabaseSelect.SelectedResult as DbObjectSchema;
						}
						if (this.resultSchema == null)
						{
							MessageBox.Show(this,
								"A query for the schema of table \'{0}\' returned multiple database schemas. You must select a schema before continuing.".FormatWith(this.textBoxNameDatabase.Text),
								"Multiple Table Schemas Found",
								MessageBoxButtons.OK,
								MessageBoxIcon.Warning);
						}
					}
					while (this.resultSchema == null);
				}
				catch (Exception exception)
				{
					// If an error occurs, show an error message.
					MessageBox.Show(this,
						"Changing the table schema failed. {0}".FormatWith(exception.Message),
						"Error",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
					return;
				}
			}
			else
			{
				// Otherwise, select the returned schema.
				this.resultSchema = this.resultSchemas[0] as DbObjectSchema;
			}
			// Set the schema name.
			this.textBoxSchema.Text = this.resultSchema.Name;
			// Raise a configuration changed event.
			if (this.ConfigurationChanged != null) this.ConfigurationChanged(this, EventArgs.Empty);
			// Set the changes to true.
			this.changes = true;
		}

		/// <summary>
		/// An event handler called when a query for the column type completed successfully.
		/// </summary>
		/// <param name="result">The database result.</param>
		/// <param name="recordsAffected">The number of affected records.</param>
		private void OnQuerySuccessColumnType(DbDataObject result, int recordsAffected)
		{
			DbObjectType resultType;
			// Check the query result has at least one record.
			if (result.RowCount == 0)
			{
				MessageBox.Show(this,
					"A query for the type of the table field \'{0}\' did not return any database type.".FormatWith(this.resultColumn.Name),
					"Column Type Not Found",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				// Set the result to null.
				resultType = null;
			}
			// Check the query result has at most one record.
			else if (result.RowCount > 1)
			{
				MessageBox.Show(this,
					"A query for the type of the table field \'{0}\' returned multiple database types.".FormatWith(this.resultColumn.Name),
					"Multiple Column Types Found",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				// Set the result to null.
				resultType = null;
			}
			else
			{
				// Else, choose the result.
				resultType = result[0] as DbObjectType;
			}
			
			// Get the selected field list view item.
			ListViewItem item = this.listViewFields.SelectedItems[0];
			// Get the database field.
			DbField field = item.Tag as DbField;
			
			// Confirm the modification of the field.
			if (this.formCompareFields.ShowDialog(
				this,
				field,
				this.resultColumn.Name,
				resultType != null ? resultType.Name : "(unknown)",
				this.resultColumn.MaximumLength,
				this.resultColumn.Precision,
				this.resultColumn.Scale,
				this.resultColumn.IsNullable) == DialogResult.Yes)
			{
				// Update the field.
				item.SubItems[1].Text = resultColumn.Name;
				item.ImageKey = "Field";
				// Raise a configuration changed event.
				if (this.ConfigurationChanged != null) this.ConfigurationChanged(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// An event handler called when the relationship selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRelationshipSelectionChanged(object sender, EventArgs e)
		{
			this.buttonRelationshipProperties.Enabled = this.listViewRelationships.SelectedItems.Count > 0;
		}

		/// <summary>
		/// An event handler called when the user activates the properties of a database relationship.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRelationshipProperties(object sender, EventArgs e)
		{
			// If there are no selected items, do nothing.
			if (this.listViewRelationships.SelectedItems.Count == 0) return;
			// Else, get the selected relationship.
			IRelationship relationship = this.listViewRelationships.SelectedItems[0].Tag as IRelationship;
			// Open the relationships dialog for the selected relationship.
			this.formRelationship.ShowDialog(this, this.server, relationship);
		}

		/// <summary>
		/// An event handler called when displaying the properties of a database field.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnFieldProperties(object sender, EventArgs e)
		{
			// If there are no table field selected, do nothing.
			if (this.listViewFields.SelectedItems.Count == 0) return;
			// Else, open a field dialog and display the selected field.
			this.formField.ShowDialog(this, this.listViewFields.SelectedItems[0].Tag as DbField);
		}

		/// <summary>
		/// An event handler called when the default database has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnDefaultDatabaseChanged(object sender, EventArgs e)
		{
			// If the default database is not selected, do nothing.
			if (!this.checkBoxDefaultDatabase.Checked) return;
			// Else, set the default database.
			this.textBoxDatabase.Text = "{0} (default)".FormatWith(this.server.Database.Name);
			// Disable the checkbox.
			this.checkBoxDefaultDatabase.Enabled = false;
			// Raise a configuration changed event.
			if (this.ConfigurationChanged != null) this.ConfigurationChanged(this, null);
		}
	}
}
