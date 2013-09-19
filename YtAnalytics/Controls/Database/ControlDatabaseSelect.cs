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
using YtAnalytics.Events;
using YtAnalytics.Forms.Database;
using YtCrawler.Database;
using YtCrawler.Database.Data;
using YtCrawler.Log;
using DotNetApi;

namespace YtAnalytics.Controls.Database
{
	/// <summary>
	/// A control that selects items from a database, based on a query selected by the user.
	/// </summary>
	public sealed partial class ControlDatabaseSelect : ControlDatabase
	{
		private DbServer server = null;
		private DbCommand command = null;
		private DbQuery query = null;
		private DbDataObject result = null;

		private FormObjectProperties formObject = new FormObjectProperties();

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlDatabaseSelect()
		{
			// Initialize the component.
			this.InitializeComponent();
		}

		// Public events.

		/// <summary>
		/// An event raised when a database operation has started.
		/// </summary>
		public event EventHandler DatabaseOperationStarted;
		/// <summary>
		/// An event raised when a database operation has finished.
		/// </summary>
		public event EventHandler DatabaseOperationFinished;
		/// <summary>
		/// An event raised when a user selects a database object.
		/// </summary>
		public event DatabaseObjectSelectedEventHandler Selected;
		/// <summary>
		/// An event raised when a user closes the selection of a database object.
		/// </summary>
		public event EventHandler Closed;

		// Public methods.

		/// <summary>
		/// Selects all records for the specified databse server and table.
		/// </summary>
		/// <param name="server">The database server.</param>
		/// <param name="table">The database table.</param>
		/// <param name="result">The database results, if any.</param>
		public void Select(DbServer server, ITable table, DbDataObject result)
		{
			// Create a select all query for all field in the current table.
			DbQuery query = DbQuery.CreateSelectAll(table, server.Database);

			query.MessageStart = "Refreshing the data for table \'{0}\' on the database server \'{1}\'...".FormatWith(table.LocalName, server.Name);
			query.MessageFinishSuccess = "Refreshing the data for table \'{0}\' on the database server \'{1}\' completed successfully.".FormatWith(table.LocalName, server.Name);
			query.MessageFinishFail = "Refreshing the data for table \'{0}\' on the database server \'{1}\' failed.".FormatWith(table.LocalName, server.Name);

			// Use the generic select methods.
			this.Select(server, query, result);
		}

		/// <summary>
		/// Selects records from the specified database server given a custom query.
		/// </summary>
		/// <param name="server">The database server.</param>
		/// <param name="query">The database table.</param>
		/// <param name="result">The database results, if any.</param>
		public void Select(DbServer server, DbQuery query, DbDataObject result)
		{
			// Check the database table is configured.
			if (!query.Table.IsConfigured) throw new DbException("Cannot select the list of database objects for table \'{0}\', because the table is not configured.".FormatWith(query.Table.LocalName));
			// Check the results, if different from null, are for the current table and if not, ignore them.
			if (result != null)
			{
				if (result.Table != query.Table) result = null;
			}

			// Set the current server.
			this.server = server;
			// Set the current query.
			this.query = query;
			// Set the current results.
			this.result = result;

			// Clear the data grid.
			this.dataGrid.Rows.Clear();
			this.dataGrid.Columns.Clear();
			// Initialize the data grid columns.
			foreach (DbField field in this.query.Table.Fields)
			{
				this.dataGrid.Columns.Add(field.Property.Name, field.DisplayName);
			}
			// If a current result exists, intialize the data grid rows.
			if (this.result != null)
			{
				for (int row = 0; row < this.result.RowCount; row++)
				{
					// Add the new row, and get the row index.
					int index = this.dataGrid.Rows.Add(this.query.Table.GetValues(this.result[row]));
					// Set the row tag with the table object.
					this.dataGrid.Rows[index].Tag = result[row];
				}
			}

			// Intialize the buttons.
			this.buttonRefresh.Enabled = true;
			this.buttonCancel.Enabled = false;
			this.buttonSelect.Enabled = false;
			this.buttonClose.Enabled = true;
		}

		/// <summary>
		/// Refreshes the list of database values.
		/// </summary>
		public void RefreshList()
		{
			this.OnRefreshStarted(null, null);
		}

		// Protected methods.

		/// <summary>
		/// A method called when started connecting to the database server.
		/// </summary>
		/// <param name="server">The database server.</param>
		protected override void OnConnectStarted(DbServer server)
		{
			// Disable the buttons.
			this.buttonRefresh.Enabled = false;
			this.buttonClose.Enabled = false;
			// Raise the database operation started event.
			if (this.DatabaseOperationStarted != null) this.DatabaseOperationStarted(this, null);
		}

		/// <summary>
		/// A method called when connecting to the database has succeeded.
		/// </summary>
		/// <param name="server">The database server.</param>
		protected override void OnConnectSucceeded(DbServer server)
		{
			// Enable the buttons.
			this.buttonRefresh.Enabled = true;
			this.buttonClose.Enabled = true;
			// Raise the database operation finished event.
			if (this.DatabaseOperationFinished != null) this.DatabaseOperationFinished(this, null);
		}

		/// <summary>
		/// A method called when connecting to the database has failed.
		/// </summary>
		/// <param name="server">The database server.</param>
		protected override void OnConnectFailed(DbServer server)
		{
			// Enable the buttons.
			this.buttonRefresh.Enabled = true;
			this.buttonClose.Enabled = true;
			// Raise the database operation finished event.
			if (this.DatabaseOperationFinished != null) this.DatabaseOperationFinished(this, null);
		}

		/// <summary>
		/// A method called when the execution of the database query starts.
		/// </summary>
		/// <param name="server">The database server.</param>
		/// <param name="query">The database query.</param>
		/// <param name="command">The database command.</param>
		protected override void OnQueryStarted(DbServer server, DbQuery query, DbCommand command)
		{
			// Save the current command.
			this.command = command;
			// Enable the cancel button.
			this.buttonRefresh.Enabled = false;
			this.buttonClose.Enabled = false;
			this.buttonCancel.Enabled = true;
			// Raise the database operation started event.
			if (this.DatabaseOperationStarted != null) this.DatabaseOperationStarted(this, null);
		}

		/// <summary>
		/// An event handler called when the refresh operation completed successfully and the resulting data is object
		/// data.
		/// </summary>
		/// <param name="server">The database server.</param>
		/// <param name="query">The database query.</param>
		/// <param name="result">The database result.</param>
		/// <param name="recordsAffected">The number of records affected.</param>
		protected override void OnQuerySucceeded(DbServer server, DbQuery query, DbDataObject result, int recordsAffected)
		{
			// Set the current result.
			this.result = result;
			try
			{
				// Add the table rows.
				for (int row = 0; row < this.result.RowCount; row++)
				{
					// Add the new row, and get the row index.
					int index = this.dataGrid.Rows.Add(this.query.Table.GetValues(this.result[row]));
					// Set the row tag with the table object.
					this.dataGrid.Rows[index].Tag = result[row];
				}
			}
			catch (Exception exception)
			{
				// If an exception occurs, call the refresh fail method.
				this.OnQueryFailed(server, query, exception);
				return;
			}
			// Enable the buttons.
			this.buttonRefresh.Enabled = true;
			this.buttonCancel.Enabled = false;
			this.buttonClose.Enabled = true;
			// Update the status box.
			this.labelStatus.Text = "{0} {1} fetched.".FormatWith(result.RowCount, result.RowCount == 1 ? "object" : "objects");
			// Raise the database operation finished event.
			if (this.DatabaseOperationFinished != null) this.DatabaseOperationFinished(this, null);
		}

		/// <summary>
		/// A method called when the executiopn of the database query has failed.
		/// </summary>
		/// <param name="server">The database server.</param>
		/// <param name="query">The database query.</param>
		/// <param name="exception">The exception.</param>
		protected override void OnQueryFailed(DbServer server, DbQuery query, Exception exception)
		{
			// Enable the buttons.
			this.buttonRefresh.Enabled = true;
			this.buttonCancel.Enabled = false;
			this.buttonClose.Enabled = true;

			// Update the status box.
			this.labelStatus.Text = "Query failed. {0}".FormatWith(exception.Message);

			// Raise the database operation finished event.
			if (this.DatabaseOperationFinished != null) this.DatabaseOperationFinished(this, null);
		}

		/// <summary>
		/// A method called when the user cancels a current database query.
		/// </summary>
		/// <param name="query">The database query.</param>
		protected override void OnQueryCanceling(DbQuery query)
		{
			// Disable the cancel button.
			this.buttonCancel.Enabled = false;
		}

		// Private methods.

		/// <summary>
		/// An event handler called when the user refreshes the list of items.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRefreshStarted(object sender, EventArgs e)
		{
			// Disable the buttons.
			this.buttonRefresh.Enabled = false;
			this.buttonCancel.Enabled = false;
			this.buttonSelect.Enabled = false;
			this.buttonClose.Enabled = false;
			// Clear the data grid rows.
			this.dataGrid.Rows.Clear();

			// Execute the database operation.
			this.DatabaseQuery(this.server, this.query);
		}

		/// <summary>
		/// An event handler called when the user chooses an item.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelect(object sender, EventArgs e)
		{
			// If there is no selected database object, do nothing.
			if (this.dataGrid.SelectedRows.Count == 0) return;
			// Else, get the database object corresponding to the first selected item.
			DbObject selectedResult = this.dataGrid.SelectedRows[0].Tag as DbObject;
			// Raise the event.
			if (this.Selected != null) this.Selected(this, new DatabaseObjectSelectedEventArgs(selectedResult, this.result));
		}

		/// <summary>
		/// An event handler called when the user selects the close button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnClose(object sender, EventArgs e)
		{
			// Raise the close event.
			if (this.Closed != null) this.Closed(sender, e);
		}

		/// <summary>
		/// An event handler called when the object selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelectionChanged(object sender, EventArgs e)
		{
			this.buttonSelect.Enabled = this.dataGrid.SelectedRows.Count != 0;
		}

		/// <summary>
		/// An event handler called when the user double clicks on a data cell.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			this.formObject.ShowDialog(this, this.dataGrid.Rows[e.RowIndex].Tag as DbObject);
		}

		/// <summary>
		/// An event handler called when the user cancel a current database command.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCancel(object sender, EventArgs e)
		{
			// If there is no current command, do nothing.
			if (null == this.command) return;
			// Else cancel, the command.
			this.DatabaseQueryCancel(this.command);
		}
	}
}
