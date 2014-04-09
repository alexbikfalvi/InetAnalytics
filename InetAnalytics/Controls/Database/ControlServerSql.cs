/* 
 * Copyright (C) 2012 Alex Bikfalvi
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
using System.Drawing;
using System.Windows.Forms;
using InetAnalytics.Controls;
using InetAnalytics.Forms.Database;
using InetCommon.Database;
using InetCommon.Database.Data;
using InetCommon.Log;
using InetControls.Controls.Database;
using InetCrawler;
using DotNetApi;
using DotNetApi.Windows;
using DotNetApi.Windows.Controls;

namespace InetAnalytics.Controls.Database
{
	/// <summary>
	/// A class representing a database server control.
	/// </summary>
	public partial class ControlServerSql : ControlBaseSql
	{
		private static readonly string logSource = "Database";

		private Crawler crawler;
		private DbServerSql server;

		private readonly FormServerProperties formProperties = new FormServerProperties();
		private readonly FormDatabaseProperties formDatabaseProperties = new FormDatabaseProperties();
		private readonly FormTableProperties formTable = new FormTableProperties();
		private readonly FormRelationshipProperties formRelationship = new FormRelationshipProperties();

		private TreeNode treeNode = null;

		private static readonly Image[] images = {
													 Resources.ServerDown_48,
													 Resources.ServerUp_48,
													 Resources.ServerWarning_48,
													 Resources.ServerBusy_48,
													 Resources.ServerBusy_48,
													 Resources.ServerBusy_48
												 };

		/// <summary>
		/// Creates a new instance of the control.
		/// </summary>
		public ControlServerSql()
		{
			// Initialize component.
			InitializeComponent();

			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;

			// Set the font.
			Window.SetFont(this);
		}

		/// <summary>
		/// Initializes the control.
		/// </summary>
		/// <param name="crawler">The crawler instance.</param>
		/// <param name="server">The database server.</param>
		/// <param name="treeNode">The tree node corresponding to this server.</param>
		public void Initialize(Crawler crawler, DbServerSql server, TreeNode treeNode)
		{
			// Set the crawler.
			this.crawler = crawler;
			// Set the server.
			this.server = server;
			// Set the tree node and the tree node tag.
			this.treeNode = treeNode;

			// Set the title.
			this.panelServer.Title = "Database Server ({0})".FormatWith(server.Name);

			// Add the event handlers for the database server.
			this.server.ServerChanged += this.OnServerChanged;
			this.server.StateChanged += this.OnServerStateChanged;
			this.server.DatabaseChanged += this.OnDatabaseChanged;
			this.server.TableAdded += this.OnTableAdded;
			this.server.TableRemoved += this.OnTableRemoved;
			this.server.TableChanged += this.OnTableChanged;
			this.server.RelationshipAdded += this.OnRelationshipAdded;
			this.server.RelationshipRemoved += this.OnRelationshipRemoved;
			this.server.EventLogged += this.OnEventLogged;
			this.crawler.Database.Sql.PrimaryServerChanged += this.OnPrimaryServerChanged;

			// Initialize the contols.
			this.OnServerChanged(this, new DbServerEventArgs(this.server));
			this.OnServerStateChanged(this.server, null);

			// Initialize the server database.
			this.OnDatabaseChanged(this, new DbServerDatabaseChangedEventArgs(this.server, null, this.server.Database));

			// Initialize the server database tables.
			this.OnTablesChanged();

			// Initialize the server database relationships.
			this.OnRelationshipsChanged();
		}

		// Protected methods.

		/// <summary>
		/// A method called when connecting to the database server succeeded.
		/// </summary>
		/// <param name="server">The database server.</param>
		protected override void OnConnectSucceeded(DbServer server)
		{
			// Enable the refresh database button.
			this.buttonDatabaseRefresh.Enabled = true;
		}

		/// <summary>
		/// A method called when connecting to the database server failed.
		/// </summary>
		/// <param name="server">The database server.</param>
		protected override void OnConnectFailed(DbServer server)
		{
			// Disable the refresh database button.
			this.buttonDatabaseRefresh.Enabled = false;
		}

		/// <summary>
		/// A method called when the execution of the database query succeeded and the data is object.
		/// </summary>
		/// <param name="server">The database server.</param>
		/// <param name="query">The database query.</param>
		/// <param name="result">The result data.</param>
		/// <param name="recordsAffected">The number of records affected.</param>
		protected override void OnQuerySucceeded(DbServerSql server, DbQuerySql query, DbDataObject result, int recordsAffected)
		{
			// Add the databases to the list.
			for (int row = 0; row < result.RowCount; row++)
			{
				// Get the database object.
				DbObjectDatabase database = result[row] as DbObjectDatabase;
				// Add a new list view item.
				ListViewItem item = new ListViewItem(new string[] {
					database.Name,
					database.DatabaseId.ToString(),
					database.CreateDate.ToString()
				});
				item.Tag = database;
				item.ImageIndex = database.Equals(this.server.Database) ? 1 : 0;
				this.listViewDatabases.Items.Add(item);
			}
			// Enable the refresh button.
			this.buttonDatabaseRefresh.Enabled = true;
		}

		/// <summary>
		/// A method called when the executiopn of the database query has failed.
		/// </summary>
		/// <param name="server">The database server.</param>
		/// <param name="query">The database query.</param>
		/// <param name="exception">The exception.</param>
		protected override void OnQueryFailed(DbServerSql server, DbQuerySql query, Exception exception)
		{
			// Enable the refresh button.
			this.buttonDatabaseRefresh.Enabled = true;
		}

		// Private methods.

		/// <summary>
		/// An event handler called when a server configuration has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnServerChanged(object sender, DbServerEventArgs e)
		{
			// Update the server properties.
			this.labelName.Text = e.Server.Name;
			this.labelPrimary.Text = this.crawler.Database.Sql.IsPrimary(e.Server) ? "Primary database server" : "Backup database server";
		}

		/// <summary>
		/// An event handler called when the state of a server connection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnServerStateChanged(object sender, DbServerStateEventArgs e)
		{
			// Execute the code on the UI thread.
			this.Invoke(() =>
				{
					this.buttonConnect.Enabled =
						(this.server.State == DbServerSql.ServerState.Disconnected) ||
						(this.server.State == DbServerSql.ServerState.Failed);
					this.buttonDisconnect.Enabled = this.server.State == DbServerSql.ServerState.Connected;
					this.buttonChangePassword.Enabled =
						(this.server.State == DbServerSql.ServerState.Disconnected) ||
						(this.server.State == DbServerSql.ServerState.Failed);
					this.pictureBox.Image = ControlServerSql.images[(int)this.server.State];
					this.tabControl.Enabled =
						(this.server.State != DbServerSql.ServerState.Connecting) &&
						(this.server.State != DbServerSql.ServerState.Disconnecting);
				});
		}

		/// <summary>
		/// An event handler called when the server database has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnDatabaseChanged(object sender, DbServerDatabaseChangedEventArgs e)
		{
			// Update the current database.
			if (e.NewDatabase != null)
			{
				this.textBoxDatabase.Text = "{0} (ID {1} created on {2})".FormatWith(this.server.Database.Name, this.server.Database.DatabaseId, this.server.Database.CreateDate);
				this.buttonDatabaseProperties.Enabled = this.server.Database != null;
			}
			else
			{
				this.textBoxDatabase.Text = "(no database selected)";
				this.buttonDatabaseProperties.Enabled = false;
			}

			// Update the databases list.
			foreach (ListViewItem item in this.listViewDatabases.Items)
			{
				// Get the item database.
				DbObjectDatabase db = item.Tag as DbObjectDatabase;
				item.ImageIndex = db.Equals(this.server.Database) ? 
					this.imageListSmall.Images.IndexOfKey("DatabaseStar"): 
					this.imageListSmall.Images.IndexOfKey("Database");
			}
			// Update the select button.
			if (this.listViewDatabases.SelectedItems.Count != 0)
			{
				// Get the item databse.
				DbObjectDatabase db = this.listViewDatabases.SelectedItems[0].Tag as DbObjectDatabase;
				this.buttonDatabaseSelect.Enabled = !db.Equals(this.server.Database);
			}
		}

		/// <summary>
		/// An event handler called when a database table has been added.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnTableAdded(object sender, DbServerTableEventArgs e)
		{
			// Add a new list view item.
			ListViewItem item = new ListViewItem(new string[] { e.Table.LocalName, e.Table.FieldCount.ToString() + " field(s)" });
			item.ImageKey = e.Table.IsConfigured ? "TableSuccess" : "TableWarning";
			item.Tag = e.Table;
			this.listViewTables.Items.Add(item);
		}

		/// <summary>
		/// An event handler called when a database table has been removed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnTableRemoved(object sender, DbServerTableEventArgs e)
		{
			// Get the list view item corresponding to the table.
			ListViewItem item = this.listViewTables.Items.FirstOrDefault((ListViewItem it) =>
			{
				return object.ReferenceEquals(it.Tag, e.Table);
			});

			// Remove the list view item.
			this.listViewTables.Items.Remove(item);

			// Call the table selection changed event handler.
			this.OnTableSelectionChanged(sender, e);
		}

		/// <summary>
		/// An event handler called when a database table has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnTableChanged(object sender, DbServerTableEventArgs e)
		{
			// Get the list view item corresponding to the table.
			ListViewItem item = this.listViewTables.Items.FirstOrDefault((ListViewItem it) =>
				{
					return object.ReferenceEquals(it.Tag, e.Table);
				});

			// If the item exists.
			if (null != item)
			{
				// Update the item.
				item.SubItems[0].Text = e.Table.LocalName;
				item.SubItems[1].Text = e.Table.FieldCount.ToString() + " field(s)";
				item.ImageKey = e.Table.IsConfigured ? "TableSuccess" : "TableWarning";
			}
		}

		/// <summary>
		/// An event handler called when the server tables configuration has changed.
		/// </summary>
		private void OnTablesChanged()
		{
			// If the list of tables is empty.
			if (this.listViewTables.Items.Count == 0)
			{
				// Add a new list view item for each table.
				foreach (ITable table in this.server.Tables)
				{
					ListViewItem item = new ListViewItem(new string[] { table.LocalName, table.FieldCount.ToString() + " field(s)" });
					item.ImageKey = table.IsConfigured ? "TableSuccess" : "TableWarning";
					item.Tag = table;
					this.listViewTables.Items.Add(item);
				}
			}
			else
			{
				// Else, update the list view items for each table.
				foreach (ListViewItem item in this.listViewTables.Items)
				{
					// Get the database table.
					ITable table = item.Tag as ITable;
					// Update the item.
					item.SubItems[0].Text = table.LocalName;
					item.SubItems[1].Text = table.FieldCount.ToString() + " field(s)";
					item.ImageKey = table.IsConfigured ? "TableSuccess" : "TableWarning";
				}
			}
		}

		/// <summary>
		/// An event handler called when a relationship was added.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRelationshipAdded(object sender, DbServerRelationshipEventArgs e)
		{
			// Add a new relationship item.
			ListViewItem item = new ListViewItem(new string[] {
					e.Relationship.LeftTable.LocalName, e.Relationship.LeftField,
					e.Relationship.RightTable.LocalName, e.Relationship.RightField },
				this.imageListSmall.Images.IndexOfKey("Relationship"));
			item.Tag = e.Relationship;
			this.listViewRelationships.Items.Add(item);
		}

		/// <summary>
		/// An event handler called when a relationship was removed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRelationshipRemoved(object sender, DbServerRelationshipEventArgs e)
		{
			// Find the corresponding relationship item.
			ListViewItem item = this.listViewRelationships.Items.FirstOrDefault((ListViewItem it) =>
				{
					return object.ReferenceEquals(it.Tag, e.Relationship);
				});
			// If the item is not null.
			if (null != item)
			{
				// Remove the item.
				this.listViewRelationships.Items.Remove(item);
			}
		}

		/// <summary>
		/// An event handler called when the server relationship configuration has changed.
		/// </summary>
		private void OnRelationshipsChanged()
		{
			// Refresh the list of relationships.
			this.listViewRelationships.Items.Clear();
			foreach (IRelationship relationship in this.server.Relationships)
			{
				ListViewItem item = new ListViewItem(new string[] {
					relationship.LeftTable.LocalName, relationship.LeftField,
					relationship.RightTable.LocalName, relationship.RightField },
					this.imageListSmall.Images.IndexOfKey("Relationship"));
				item.Tag = relationship;
				this.listViewRelationships.Items.Add(item);
			}
		}

		/// <summary>
		/// An event handler called when the primary server has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnPrimaryServerChanged(object sender, DbPrimaryServerChangedEventArgs e)
		{
			// Execute the code on the UI thread.
			this.Invoke(() =>
				{
					// Update the primary server button enabled state.
					this.buttonPrimary.Enabled = !this.crawler.Database.Sql.IsPrimary(this.server);

					// Log the change.
					this.log.Add(this.crawler.Log.Add(
						LogEventLevel.Verbose,
						LogEventType.Information,
						ControlServerSql.logSource,
						"Primary database server has changed from \'{0}\' to \'{1}\'.",
						new object[] {
							e.OldPrimary != null ? e.OldPrimary.Id.ToString() : string.Empty,
							e.NewPrimary != null ? e.NewPrimary.Id.ToString() : string.Empty
						}));
				});
		}

		/// <summary>
		/// An event handler called when changing the primary server.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnMakePrimary(object sender, EventArgs e)
		{
			// Ask the user to confirm changing the primary server.
			if (DialogResult.Yes == MessageBox.Show(
				this,
				"You are changing the primary database server. Do you want to continue? Database information will not be copied.",
				"Confirm Changing the Primary Server",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2))
			{
				// Change the primary server.
				this.crawler.Database.Sql.SetPrimary(this.server);
			}
		}

		/// <summary>
		/// An event handler called when connecting to a database server.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnConnect(object sender, EventArgs e)
		{
			this.DatabaseConnect(this.server);
		}

		/// <summary>
		/// An event handler called when disconnecting from a database server.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnDisconnect(object sender, EventArgs e)
		{
			this.DatabaseDisconnect(this.server);
		}

		/// <summary>
		/// An event handler called when displaying the properties of a database server.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnProperties(object sender, EventArgs e)
		{
			// Show the properties dialog.
			this.formProperties.ShowDialog(this, this.server, this.crawler.Database.Sql.IsPrimary(this.server));
		}

		/// <summary>
		/// An event handler called when the database server logs an event.
		/// </summary>
		/// <param name="server">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnEventLogged(object sender, LogEventArgs e)
		{
			// Execute the code on the UI thread.
			this.Invoke(() =>
				{
					// Log the event.
					this.log.Add(e.Event);
				});
		}

		/// <summary>
		/// An event handler called when the user displays the database properties.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnDatabaseProperties(object sender, EventArgs e)
		{
			// If there are no database items selected, show the default database.
			if (this.listViewDatabases.SelectedItems.Count == 0)
			{
				// Show the properties dialog.
				this.formDatabaseProperties.ShowDialog(this, this.server.Database, true);
			}
			else
			{
				// Else, get the database item.
				DbObjectDatabase db = this.listViewDatabases.SelectedItems[0].Tag as DbObjectDatabase;
				// Show the database properties.
				this.formDatabaseProperties.ShowDialog(this, db, db.Equals(this.server.Database));
			}
		}

		/// <summary>
		/// An event handler called when the user refreshes the list of databases.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRefreshDatabases(object sender, EventArgs e)
		{
			// Refresh the list of databases.

			// Clear the databases list.
			this.listViewDatabases.Items.Clear();
			// Disable the refresh button.
			this.buttonDatabaseRefresh.Enabled = false;
			// Create a select all query for fields in the database table.
			DbQuerySql query = DbQuerySql.CreateSelectAll(this.server.TableDatabase, null);
			
			query.MessageStart = "Refreshing the list of databases for the database server \'{0}\'...".FormatWith(this.server.Name);
			query.MessageFinishSuccess = "Refreshing the list of databases for the database server \'{0}\' completed successfully.".FormatWith(this.server.Name);
			query.MessageFinishFail = "Refreshing the list of databases for the database server \'{0}\' failed.".FormatWith(this.server.Name);

			// Execute the query.
			this.DatabaseQuery(this.server, query);
		}

		/// <summary>
		/// An event handler called when the database selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnDatabaseSelectionChanged(object sender, EventArgs e)
		{
			if (this.listViewDatabases.SelectedItems.Count == 0)
			{
				this.buttonDatabaseSelect.Enabled = false;
				this.buttonDatabaseProperties.Enabled = this.server.Database != null;
			}
			else
			{
				// Get the item database.
				DbObjectDatabase db = this.listViewDatabases.SelectedItems[0].Tag as DbObjectDatabase;
				// Set the enabled state of the selection button.
				this.buttonDatabaseSelect.Enabled = !db.Equals(this.server.Database);
				this.buttonDatabaseProperties.Enabled = true;
			}
		}

		/// <summary>
		/// An event handler called when the user changes the current database.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnDatabaseSelect(object sender, EventArgs e)
		{
			// If no database items are selected, do nothing.
			if (this.listViewDatabases.SelectedItems.Count == 0) return;

			// Get the item database.
			DbObjectDatabase db = this.listViewDatabases.SelectedItems[0].Tag as DbObjectDatabase;

			try
			{
				// Set the database as the current database.
				this.server.Database = db;
			}
			catch (Exception exception)
			{
				MessageBox.Show(
					this,
					"Cannot set the database \'{0}\' as primary. {1}".FormatWith(db.Name, exception.Message),
					"Select Primary Database Failed",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// An event handler called when the table selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnTableSelectionChanged(object sender, EventArgs e)
		{
			this.buttonTableProperties.Enabled = this.listViewTables.SelectedItems.Count != 0;
		}

		/// <summary>
		/// An event handler called when the user selects the properties of a database table.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnTableProperties(object sender, EventArgs e)
		{
			// If there are no selected tables, do nothing.
			if (this.listViewTables.SelectedItems.Count == 0) return;
			// Else, get selected table.
			ITable table = this.listViewTables.SelectedItems[0].Tag as ITable;
			// Open the table properties dialog.
			this.formTable.ShowDialog(this, this.server, table);
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
		/// An event handler called when the user changes the password for the current database server.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnChangePassword(object sender, EventArgs e)
		{
			this.DatabaseChangePassword(this.server);
		}
	}
}
