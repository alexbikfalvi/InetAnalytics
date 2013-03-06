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
		/// <summary>
		/// A class storing the UI controls associated with a database server.
		/// </summary>
		protected class ServerControls
		{
			private ListViewItem item;
			private TreeNode node;

			/// <summary>
			/// Initializes the server controls object.
			/// </summary>
			/// <param name="item">The list view item.</param>
			/// <param name="node">The tree node.</param>
			public ServerControls(ListViewItem item, TreeNode node)
			{
				this.item = item;
				this.node = node;
			}

			/// <summary>
			/// Gets the list view item.
			/// </summary>
			public ListViewItem Item { get { return this.item; } }
			/// <summary>
			/// Gets the tree node.
			/// </summary>
			public TreeNode Node { get { return this.node; } }
		};

		private static string logSource = "Database";

		private Crawler crawler;

		private FormAddServer formAdd = new FormAddServer();
		private FormServerProperties formProperties = new FormServerProperties();
		private ControlMessage message = new ControlMessage();

		private ShowMessageEventHandler delegateShowMessage;
		private HideMessageEventHandler delegateHideMessage;

		private Dictionary<string, ServerControls> items = new Dictionary<string, ServerControls>();

		private TreeNode treeNode = null;
		private int[] treeImageIndex = null;

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
		/// <param name="treeNode">The root tree node for the database servers.</param>
		public void Initialize(Crawler crawler, TreeNode treeNode, int[] imageIndex)
		{
			// Set the crawler.
			this.crawler = crawler;
			// Set the root tree node.
			this.treeNode = treeNode;
			// Set the tree image index.
			this.treeImageIndex = imageIndex;

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
				// Create a new tree node.
				TreeNode node = new TreeNode(
					this.GetServerTreeName(server.Value),
					this.treeImageIndex[(int)server.Value.State],
					this.treeImageIndex[(int)server.Value.State]);
				this.treeNode.Nodes.Add(node);
				this.treeNode.ExpandAll();
				
				// Add the servers controls to the dictionary.
				this.items.Add(server.Value.Id, new ServerControls(item, node));
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
		/// Returns the server name to display in the tree view.
		/// </summary>
		/// <param name="server">The server.</param>
		/// <returns>The server name</returns>
		private string GetServerTreeName(DbServer server)
		{
			return server.Name + (this.crawler.Servers.IsPrimary(server) ? " (primary)" : string.Empty);
		}

		/// <summary>
		/// An event handler called when a new server was added.
		/// </summary>
		/// <param name="server">The server.</param>
		private void OnServerAdded(DbServer server)
		{
			// Call the method on the UI thread.
			if (this.InvokeRequired) this.Invoke(new ServerEventHandler(this.OnServerAdded), new object[] { server });
			else
			{
				// Create a new menu item for the new server.
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
				// Create a new tree node.
				TreeNode node = new TreeNode(
					this.GetServerTreeName(server),
					this.treeImageIndex[(int)server.State],
					this.treeImageIndex[(int)server.State]);
				this.treeNode.Nodes.Add(node);
				this.treeNode.ExpandAll();

				// Add the servers controls to the dictionary.
				this.items.Add(server.Id, new ServerControls(item, node));
				
				// Log the change.
				this.log.Add(this.crawler.Log.Add(
					LogEventLevel.Verbose,
					LogEventType.Success,
					ControlServers.logSource,
					"Database server with ID \'{0}\' and name \'{1}\' added. The server is {2}.",
					new object[] { server.Id, server.Name, this.crawler.Servers.IsPrimary(server) ? "primary" : "backup" }));

				// Hide the message.
				this.HideMessage();
			}
		}

		/// <summary>
		/// An event handler called when a server was removed.
		/// </summary>
		/// <param name="id">The server ID.</param>
		private void OnServerRemoved(string id)
		{
			// Call the method on the UI thread.
			if (this.InvokeRequired) this.Invoke(new ServerIdEventHandler(this.OnServerRemoved), new object[] { id });
			else
			{
				// Remove the menu item for the specified database server.
				this.listView.Items.Remove(this.items[id].Item);
				this.treeNode.Nodes.Remove(this.items[id].Node);

				// Remove the controls entry from the dictionary.
				this.items.Remove(id);

				// Call the selected item change event to update the buttons.
				this.OnServerSelectionChanged(this, null);

				// Log the change.
				this.log.Add(this.crawler.Log.Add(
					LogEventLevel.Verbose,
					LogEventType.Success,
					ControlServers.logSource,
					"Database server with ID \'{0}\' was removed.",
					new object[] { id }));
			}
		}

		/// <summary>
		/// An event handler called when a server configuration has changed.
		/// </summary>
		/// <param name="server">The server.</param>
		private void OnServerChanged(DbServer server)
		{
			// Call the method on the UI thread.
			if (this.InvokeRequired) this.Invoke(new ServerEventHandler(this.OnServerChanged), new object[] { server });
			else
			{
				// Update the server information.

				// Get the controls corresponding to this server.
				ServerControls controls = this.items[server.Id];
				// Update the server information.
				controls.Item.SubItems[0].Text = server.Name;
				controls.Item.SubItems[2].Text = server.State.ToString();
				controls.Item.SubItems[3].Text = server.Version;
				controls.Node.Text = this.GetServerTreeName(server);

				// Call the selected item change event to update the buttons.
				this.OnServerSelectionChanged(this, null);
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
			if (this.InvokeRequired) this.Invoke(new ServerPrimaryChangedEventHandler(this.OnPrimaryServerChanged), new object[] { oldPrimary, newPrimary });
			else
			{
				// Update the old primary server, if not null.
				if (null != oldPrimary)
				{
					if(this.items.ContainsKey(oldPrimary.Id))
					{
						ServerControls controls = this.items[oldPrimary.Id];
						controls.Item.SubItems[1].Text = "Backup";
						controls.Node.Text = this.GetServerTreeName(oldPrimary);
					}
				}

				// Update the new primary server, if not null.
				if (null != newPrimary)
				{
					if(this.items.ContainsKey(newPrimary.Id))
					{
						ServerControls controls = this.items[newPrimary.Id];
						controls.Item.SubItems[1].Text = "Primary";
						controls.Node.Text = this.GetServerTreeName(newPrimary);
					}
				}

				// Call the selected item change event to update the buttons.
				this.OnServerSelectionChanged(this, null);

				// Log the change.
				this.log.Add(this.crawler.Log.Add(
					LogEventLevel.Verbose,
					LogEventType.Information,
					ControlServers.logSource,
					"Primary database server has changed from \'{0}\' to \'{1}\'.",
					new object[] {
						oldPrimary != null ? oldPrimary.Id : string.Empty,
						newPrimary != null ? newPrimary.Id : string.Empty
					}));
			}
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
			this.ShowMessage(Resources.ServerAdd_48, "Adding a new database server...");

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
			// If there are no selected items, do nothing.
			if (this.listView.SelectedItems.Count == 0) return;

			// Get the selected server.
			DbServer server = this.crawler.Servers[this.listView.SelectedItems[0].Tag as string];

			// If there are more than one server, and the selected server is a primary server ask the user to change the primary.
			if(this.crawler.Servers.IsPrimary(server) && (this.crawler.Servers.Count > 1))
			{
				MessageBox.Show(
					this,
					"Change the primary database server before removing the current server.",
					"Cannot Remove Primary Database Server",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return;
			}

			// Ask the user to confirm removing the server.
			if (DialogResult.Yes == MessageBox.Show(
				this,
				"Are you sure you want to remove the selected server?",
				"Confirm Removing Database Server",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2))
			{
				// Try removing the server asynchronously. The server will be removed only after the connection to the server is closed.
				try
				{
					// Show a message to the user.
					this.ShowMessage(
						Resources.ServerRemove_48,
						string.Format("Removing the database server with ID \'{0}\'.\r\nThe server will be removed only after the current connection to the server is closed.", server.Id)
						);
					// Begin an asynchronous remove of the database server.
					this.crawler.Servers.RemoveAsync(server, this.OnRemoveComplete);
				}
				catch (Exception exception)
				{
					// Display a message if an exception occurs.
					MessageBox.Show(
						this,
						exception.Message,
						"Database Server Removal Failed",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
			}
		}

		/// <summary>
		/// A callback function for when the removal operation completed, either successfully or unsuccessfully.
		/// </summary>
		/// <param name="state">The asynchronous state.</param>
		private void OnRemoveComplete(DbServerAsyncState state)
		{
			// Call the method on the UI thread.
			if (this.InvokeRequired) this.Invoke(new DbServerCallback(this.OnRemoveComplete), new object[] { state });
			else
			{
				// Hide the message.
				this.HideMessage();
				// If the exception is not null, display an error message to the user.
				if (state.Exception != null)
				{
					MessageBox.Show(
						this,
						state.Exception.Message,
						"Database Server Removal Failed",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
			}
		}

		/// <summary>
		/// An event handler called when changing the primary server.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnMakePrimary(object sender, EventArgs e)
		{
			// If there are no selected items, do nothing.
			if (this.listView.SelectedItems.Count == 0) return;

			// Ask the user to confirm changing the primary server.
			if (DialogResult.Yes == MessageBox.Show(
				this,
				"Are you sure you want to change the primary database server? Database information will not be copied.",
				"Confirm Primary Server Change",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2))
			{
				// Get the server.
				DbServer server = this.crawler.Servers[this.listView.SelectedItems[0].Tag as string];
				// Change the primary server.
				this.crawler.Servers.SetPrimary(server);
			}
		}

		/// <summary>
		/// An event handler called when connecting to a database server.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnConnect(object sender, EventArgs e)
		{
			// If there are no selected items, do nothing.
			if (this.listView.SelectedItems.Count == 0) return;

			// Get the selected server.
			DbServer server = this.crawler.Servers[this.listView.SelectedItems[0].Tag as string];

			// Connect asynchronously to the database server.
			server.OpenAsync(this.OnConnected);

			// 
		}

		private void OnConnected(DbServerAsyncState asyncState)
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
			this.menuItemPrimary.Enabled = this.buttonPrimary.Enabled;
			this.menuItemConnect.Enabled = this.buttonConnect.Enabled;
			this.menuItemDisconnect.Enabled = this.buttonDisconnect.Enabled;
		}

		/// <summary>
		/// An event handler called when displaying the properties of a database server.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnProperties(object sender, EventArgs e)
		{
			if (this.listView.SelectedItems.Count == 0) return;

			// Get the server.
			DbServer server = this.crawler.Servers[this.listView.SelectedItems[0].Tag as string];

			// Show the properties dialog.
			this.formProperties.ShowDialog(this, server, this.crawler.Servers.IsPrimary(server));
		}

		/// <summary>
		/// An event handler called when the user clicks on a list view item.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnMouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if (this.listView.FocusedItem != null)
				{
					if (this.listView.FocusedItem.Bounds.Contains(e.Location))
					{
						this.contextMenu.Show(this.listView, e.Location);
					}
				}
			}
		}

		/// <summary>
		/// An event handler called when the user changes the password.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnChangePassword(object sender, EventArgs e)
		{

		}
	}
}
