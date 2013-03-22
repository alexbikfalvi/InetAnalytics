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
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YtApi.Api.V2;
using YtApi.Api.V2.Data;
using YtCrawler;
using YtCrawler.Database;
using YtCrawler.Database.Data;
using YtCrawler.Log;
using YtAnalytics.Controls;
using YtAnalytics.Forms;
using DotNetApi.Windows;

namespace YtAnalytics.Controls
{
	/// <summary>
	/// A class representing the control to browse the video entry in the YouTube API version 2.
	/// </summary>
	public partial class ControlServer : ControlDatabase
	{
		private static string logSource = "Database";

		// UI formatter.
		private Formatting formatting = new Formatting();

		private Crawler crawler;
		private DbServer server;

		private FormServerProperties formProperties = new FormServerProperties();
		private FormDatabaseProperties formDatabaseProperties = new FormDatabaseProperties();
		private FormTable formTable = new FormTable();
		private FormRelationship formRelationship = new FormRelationship();

		private TreeNode treeNode = null;

		private static Image[] images = {
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
		public ControlServer()
		{
			// Initialize component.
			InitializeComponent();

			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;

			// Set the font.
			this.formatting.SetFont(this);
		}

		/// <summary>
		/// Initializes the control.
		/// </summary>
		/// <param name="crawler">The crawler instance.</param>
		/// <param name="server">The database server.</param>
		/// <param name="treeNode">The tree node corresponding to this server.</param>
		public void Initialize(Crawler crawler, DbServer server, TreeNode treeNode)
		{
			// Set the crawler.
			this.crawler = crawler;
			// Set the server.
			this.server = server;
			// Set the tree node and the tree node tag.
			this.treeNode = treeNode;

			// Add the event handlers for the database server.
			this.server.ServerChanged += this.OnServerChanged;
			this.server.StateChanged += this.OnServerStateChanged;
			this.server.DatabaseChanged += this.OnDatabaseChanged;
			this.server.EventLogged += this.OnEventLogged;
			this.crawler.Servers.ServerPrimaryChanged += this.OnPrimaryServerChanged;

			// Initialize the contols.
			this.OnServerChanged(this.server);
			this.OnServerStateChanged(this.server, null);

			// Initialize the server database.
			this.OnDatabaseChanged(this.server, null, this.server.Database);

			// Initialize the server database tables.
			this.OnTablesChanged();

			// Initialize the server database relationships.
			this.OnRelationshipsChanged();
		}

		// Protected methods.

		/// <summary>
		/// A method called when connecting to the database server has failed.
		/// </summary>
		/// <param name="server">The database server.</param>
		protected override void OnConnectFailed(DbServer server)
		{
			this.buttonDatabaseRefresh.Enabled = false;
		}

		/// <summary>
		/// A method called when the execution of the database query succeeded and the data is object.
		/// </summary>
		/// <param name="server">The database server.</param>
		/// <param name="query">The database query.</param>
		/// <param name="result">The result data.</param>
		/// <param name="recordsAffected">The number of records affected.</param>
		protected override void OnQuerySucceeded(DbServer server, DbQuery query, DbDataObject result, int recordsAffected)
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
		protected override void OnQueryFailed(DbServer server, DbQuery query, Exception exception)
		{
			// Enable the refresh button.
			this.buttonDatabaseRefresh.Enabled = true;
		}

		// Private methods.

		/// <summary>
		/// An event handler called when a server configuration has changed.
		/// </summary>
		/// <param name="server">The server.</param>
		private void OnServerChanged(DbServer server)
		{
			this.labelName.Text = server.Name;
			this.labelPrimary.Text = this.crawler.Servers.IsPrimary(server) ? "Primary database server" : "Backup database server";
		}

		/// <summary>
		/// An event handler called when the state of a server connection has changed.
		/// </summary>
		/// <param name="server">The server.</param>
		/// <param name="e">The state change arguments.</param>
		private void OnServerStateChanged(DbServer server, DbServerStateEventArgs e)
		{
			// Call the method on the UI thread.
			if (this.InvokeRequired) this.Invoke(new DbServerStateEventHandler(this.OnServerStateChanged), new object[] { server, e });
			else
			{
				this.buttonConnect.Enabled =
					(this.server.State == DbServer.ServerState.Disconnected) ||
					(this.server.State == DbServer.ServerState.Failed);
				this.buttonDisconnect.Enabled = this.server.State == DbServer.ServerState.Connected;
				this.buttonChangePassword.Enabled =
					(this.server.State == DbServer.ServerState.Disconnected) ||
					(this.server.State == DbServer.ServerState.Failed);
				this.pictureBox.Image = ControlServer.images[(int)this.server.State];
				this.tabControl.Enabled =
					(this.server.State != DbServer.ServerState.Connecting) &&
					(this.server.State != DbServer.ServerState.Disconnecting);
			}
		}

		/// <summary>
		/// An event handler called when the server database has changed.
		/// </summary>
		/// <param name="server">The server.</param>
		/// <param name="oldDatabase">The old database.</param>
		/// <param name="newDatabase">The new database.</param>
		private void OnDatabaseChanged(DbServer server, DbObjectDatabase oldDatabase, DbObjectDatabase newDatabase)
		{
			// Update the current database.
			if (newDatabase != null)
			{
				this.textBoxDatabase.Text = string.Format("{0} (ID {1} created on {2})", this.server.Database.Name, this.server.Database.DatabaseId, this.server.Database.CreateDate);
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
		/// An event handler called when the server tables configuration has changed.
		/// </summary>
		private void OnTablesChanged()
		{
			// Refresh the list of tables.
			this.listViewTables.Items.Clear();
			foreach(KeyValuePair<string, ITable> table in this.server.Tables)
			{
				ListViewItem item = new ListViewItem(new string[] { table.Value.LocalName, table.Value.FieldCount.ToString() + " field(s)" },
					table.Value.IsConfigured ?
					this.imageListLarge.Images.IndexOfKey("TableSuccess") :
					this.imageListLarge.Images.IndexOfKey("TableWarning"));
				item.Tag = table.Value;
				this.listViewTables.Items.Add(item);
			}
		}

		/// <summary>
		/// An event handler called when the server relationship configuration has changed.
		/// </summary>
		private void OnRelationshipsChanged()
		{
			// Refresh the list of relationships.
			this.listViewRelationships.Items.Clear();
			foreach (DbRelationship relationship in this.server.Relationships)
			{
				ListViewItem item = new ListViewItem(new string[] {
					relationship.TableLeft.LocalName, relationship.FieldLeft,
					relationship.TableRight.LocalName, relationship.FieldRight },
					this.imageListSmall.Images.IndexOfKey("Relationship"));
				item.Tag = relationship;
				this.listViewRelationships.Items.Add(item);
			}
		}

		/// <summary>
		/// An event handler called when the primary server has changed.
		/// </summary>
		/// <param name="oldPrimary">The old primary server.</param>
		/// <param name="newPrimary">The new primary server.</param>
		private void OnPrimaryServerChanged(DbServer oldPrimary, DbServer newPrimary)
		{
			// Call the method on the UI thread.
			if (this.InvokeRequired) this.Invoke(new DbServerPrimaryChangedEventHandler(this.OnPrimaryServerChanged), new object[] { oldPrimary, newPrimary });
			else
			{
				this.buttonPrimary.Enabled = !this.crawler.Servers.IsPrimary(this.server);

				// Log the change.
				this.log.Add(this.crawler.Log.Add(
					LogEventLevel.Verbose,
					LogEventType.Information,
					ControlServer.logSource,
					"Primary database server has changed from \'{0}\' to \'{1}\'.",
					new object[] {
						oldPrimary != null ? oldPrimary.Id : string.Empty,
						newPrimary != null ? newPrimary.Id : string.Empty
					}));
			}
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
				"Are you sure you want to change the primary database server? Database information will not be copied.",
				"Confirm Primary Server Change",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2))
			{
				// Change the primary server.
				this.crawler.Servers.SetPrimary(this.server);
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
			this.formProperties.ShowDialog(this, this.server, this.crawler.Servers.IsPrimary(this.server));
		}

		/// <summary>
		/// An event handler called when the database server logs an event.
		/// </summary>
		/// <param name="evt">The event.</param>
		private void OnEventLogged(LogEvent evt)
		{
			// Call this method on the UI thread.
			if (this.InvokeRequired) this.Invoke(new LogEventHandler(this.OnEventLogged), new object[] { evt });
			else
			{
				// Log the event.
				this.log.Add(evt);
			}
		}

		/// <summary>
		/// An event handler called when the user displays the database properties.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCurrentDatabaseProperties(object sender, EventArgs e)
		{
			// Show the properties dialog.
			this.formDatabaseProperties.ShowDialog(this, this.server.Database, true);
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
			DbQuery query = DbQuery.CreateSelectAll(this.server.TableDatabase, null);
			
			query.MessageStart = string.Format("Refreshing the list of databases for the database server \'{0}\'...", this.server.Name);
			query.MessageFinishSuccess = string.Format("Refreshing the list of databases for the database server \'{0}\' completed successfully.", this.server.Name);
			query.MessageFinishFail = string.Format("Refreshing the list of databases for the database server \'{0}\' failed.", this.server.Name);

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
			}
			else
			{
				// Get the item database.
				DbObjectDatabase db = this.listViewDatabases.SelectedItems[0].Tag as DbObjectDatabase;
				// Set the enabled state of the selection button.
				this.buttonDatabaseSelect.Enabled = !db.Equals(this.server.Database);
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
					string.Format("Cannot set the database \'{0}\' as primary. {1}", db.Name, exception.Message),
					"Select Primary Database Failed",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// An event handle called when a database item is activated.
		/// </summary>
		/// <param name="sender">The database item.</param>
		/// <param name="e">The event arguments.</param>
		private void OnDatabaseItemActivated(object sender, EventArgs e)
		{
			// If there are no database items selected, do nothing.
			if (this.listViewDatabases.SelectedItems.Count == 0) return;
			// Else, get the database item.
			DbObjectDatabase db = this.listViewDatabases.SelectedItems[0].Tag as DbObjectDatabase;
			// Show the database properties.
			this.formDatabaseProperties.ShowDialog(this, db, db.Equals(this.server.Database));
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
		/// <param name="sender">The sender control.</param>
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
