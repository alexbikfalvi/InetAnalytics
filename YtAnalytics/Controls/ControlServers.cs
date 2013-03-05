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
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YtApi.Api.V2;
using YtApi.Api.V2.Data;
using YtCrawler;
using YtCrawler.Database;
using YtCrawler.Log;
using YtAnalytics.Controls;
using YtAnalytics.Forms;

namespace YtAnalytics.Controls
{
	public delegate void AddServerEventHandler(DbServer server);

	/// <summary>
	/// A class representing the control to browse the video entry in the YouTube API version 2.
	/// </summary>
	public partial class ControlServers : UserControl
	{
		private static string logSource = "Database Servers";

		private Crawler crawler;

		private FormAddServer formAdd = new FormAddServer();
		private ControlMessage message = new ControlMessage();

		private ShowMessageEventHandler delegateShowMessage;
		private HideMessageEventHandler delegateHideMessage;

		private Dictionary<string, ListViewItem> items = new Dictionary<string,ListViewItem>();

		/// <summary>
		/// Creates a new instance of the control.
		/// </summary>
		public ControlServers()
		{
			// Add the message control.
			this.Controls.Add(this.message);

			// Initialize component.
			InitializeComponent();

			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;

			// Delegates.
			this.delegateShowMessage = new ShowMessageEventHandler(this.ShowMessage);
			this.delegateHideMessage = new HideMessageEventHandler(this.HideMessage);
		}

		/// <summary>
		/// Initializes the control with a crawler instance.
		/// </summary>
		/// <param name="crawler">The crawler instance.</param>
		public void Initialize(Crawler crawler)
		{
			// Set the crawler.
			this.crawler = crawler;

			// Add all the servers in the configuration.
			foreach (KeyValuePair<string, DbServer> server in this.crawler.Servers)
			{
				// Create a new server item.
				ListViewItem item = new ListViewItem(new string[] {
					server.Value.Name,
					this.crawler.Servers.IsPrimary(server.Value) ? "Primary" : "Backup",
					server.Value.State.ToString(),
					server.Value.Version,
					server.Value.Id
				});
				item.ImageIndex = (int)server.Value.State;
				item.Tag = server.Key;
				this.listView.Items.Add(item);
				this.items.Add(server.Value.Id, item);
			}

			// Add the event handlers for the servers.
			this.crawler.Servers.ServerAdded += this.OnServerAdded;
			this.crawler.Servers.ServerChanged += this.OnServerChanged;
			this.crawler.Servers.ServerPrimaryChanged += this.OnPrimaryServerChanged;
			this.crawler.Servers.ServerRemoved += this.OnServerRemoved;

			// Add the event handler for the server add form.
			this.formAdd.ServerAdded += OnAdded;
		}

		// Private methods.

		/// <summary>
		/// Shows an alerting message on top of the control.
		/// </summary>
		/// <param name="image">The message icon.</param>
		/// <param name="text">The message text.</param>
		/// <param name="progress">The visibility of the progress bar.</param>
		private void ShowMessage(Image image, string text, bool progress = true)
		{
			// Invoke the function on the UI thread.
			if (this.InvokeRequired)
				this.Invoke(this.delegateShowMessage, new object[] { image, text, progress });
			else
			{
				// Show the message.
				this.message.Show(image, text, progress);
				// Disable the control.
				this.toolStrip.Enabled = false;
				this.listView.Enabled = false;
			}
		}

		/// <summary>
		/// Hides the alerting message.
		/// </summary>
		private void HideMessage()
		{
			// Invoke the function on the UI thread.
			if (this.InvokeRequired)
				this.Invoke(this.delegateHideMessage);
			else
			{
				// Hide the message.
				this.message.Hide();
				// Enable the control.
				this.toolStrip.Enabled = true;
				this.listView.Enabled = true;
			}
		}

		/// <summary>
		/// An event handler called when a new server was added.
		/// </summary>
		/// <param name="server">The server.</param>
		private void OnServerAdded(DbServer server)
		{
			// Add a new menu item for the new server.
			ListViewItem item = new ListViewItem(new string[] {
					server.Name,
					this.crawler.Servers.IsPrimary(server) ? "Primary" : "Backup",
					server.State.ToString(),
					server.Version,
					server.Id
				});
			item.ImageIndex = (int)server.State;
			item.Tag = server.Id;
			this.listView.Items.Add(item);
			this.items.Add(server.Id, item);

			// Log the change.
			this.log.Add(this.crawler.Log.Add(
				LogEventLevel.Verbose,
				LogEventType.Information,
				ControlServers.logSource,
				"Database server with ID {0} and name {1} added.",
				new object[] { server.Id, server.Name }));

			// Hide the message.
			this.HideMessage();
		}

		/// <summary>
		/// An event handler called when a server was removed.
		/// </summary>
		/// <param name="id">The server ID.</param>
		private void OnServerRemoved(string id)
		{
		}

		/// <summary>
		/// An event handler called when a server configuration has changed.
		/// </summary>
		/// <param name="server">The server.</param>
		private void OnServerChanged(DbServer server)
		{
			// Update the server information.

			// Get the list view item corresponding to this server.
			ListViewItem item = this.items[server.Id];
			// Update the server information.
			item.SubItems[0].Text = server.Name;
			item.SubItems[2].Text = server.State.ToString();
			item.SubItems[3].Text =	server.Version;

			// Call the selected item change event to update the buttons.
			this.OnServerSelectionChanged(this, null);
		}

		/// <summary>
		/// An event handler called when the primary server has changed.
		/// </summary>
		/// <param name="oldPrimary">The old primary server.</param>
		/// <param name="newPrimary">The new primary server.</param>
		private void OnPrimaryServerChanged(DbServer oldPrimary, DbServer newPrimary)
		{
			// Update the primary server.

			// Get the list view items.
		}

		/// <summary>
		/// An event handler called when adding a new database server.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAdd(object sender, EventArgs e)
		{
			// Show the server add dialog.
			this.formAdd.ShowDialog(
				this,
				this.crawler.Servers.Count == 0 ? true : false,
				this.crawler.Servers.Count == 0 ? false : true
				);
		}

		/// <summary>
		/// An event handler called when a new server has been added.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAdded(object sender, EventArgs e)
		{
			// Show a message.
			this.ShowMessage(Resources.ServersDatabase_48, "Adding a new database server...");

			// Check if the new server changes the primary server.
			bool primary = this.formAdd.IsPrimary;
			if (primary && this.crawler.Servers.HasPrimary)
			{
				// If the user does not confirm changing the primary server.
				if (DialogResult.No == MessageBox.Show(
					this,
					"The new database server is marked as primary, but a different primary server already exists. Do you want to change the primary server?",
					"Confirm Primary Server Change",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question,
					MessageBoxDefaultButton.Button2))
				{
					// Set the primary to false.
					primary = false;
				}
			}
			try
			{
				// Try add the new server.
				this.crawler.Servers.Add(
					this.formAdd.Type,
					this.formAdd.ServerName,
					this.formAdd.DataSource,
					this.formAdd.Username,
					this.formAdd.Password,
					primary);
			}
			catch (Exception exception)
			{
				// Catch all exceptions and show an error message.
				MessageBox.Show(this, exception.Message, "Add Database Server Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// An event handler called when removing an existing server.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRemove(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// An event handler called when changing the primary server.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnMakePrimary(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// An event handler called when connecting to a database server.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnConnect(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// An event handler called when disconnecting from a database server.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnDisconnect(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// An event handler called when the server selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnServerSelectionChanged(object sender, EventArgs e)
		{
			if (this.listView.SelectedItems.Count != 0)
			{
				// Get the server corresponding to this item.
				DbServer server = this.crawler.Servers[this.listView.SelectedItems[0].Tag as string];

				this.buttonRemove.Enabled = true;
				this.buttonPrimary.Enabled = !this.crawler.Servers.IsPrimary(server);
				this.buttonConnect.Enabled = server.State == DbServer.ServerState.Disconnected;
				this.buttonDisconnect.Enabled = server.State == DbServer.ServerState.Connected;
			}
			else
			{
				this.buttonRemove.Enabled = false;
				this.buttonPrimary.Enabled = false;
				this.buttonConnect.Enabled = false;
				this.buttonDisconnect.Enabled = false;
			}
		}
	}
}
