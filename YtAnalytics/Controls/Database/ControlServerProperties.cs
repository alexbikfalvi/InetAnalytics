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
using System.Drawing;
using System.Security;
using System.Windows.Forms;
using DotNetApi.Windows.Controls;
using YtCrawler.Database;

namespace YtAnalytics.Controls.Database
{
	/// <summary>
	/// Displays the information of a database server.
	/// </summary>
	public partial class ControlServerProperties : ThreadSafeControl
	{
		private DbServer server;
		private static Image[] images = {
											Resources.ServerDown_32,
											Resources.ServerUp_32,
											Resources.ServerWarning_32,
											Resources.ServerBusy_32,
											Resources.ServerBusy_32
										};

		/// <summary>
		/// Creates a new log event control instance.
		/// </summary>
		public ControlServerProperties()
		{
			InitializeComponent();
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the current database server.
		/// </summary>
		public DbServer Server
		{
			get { return this.server; }
			set
			{
				// Save the old value.
				DbServer old = this.server;
				// Set the new server.
				this.server = value;
				// Call the event handler.
				this.OnServerSet(old, value);
			}
		}
		/// <summary>
		/// Gets or sets whether this is the primary database server.
		/// </summary>
		public bool IsPrimary
		{
			get { return this.checkBoxPrimary.Checked; }
			set { this.checkBoxPrimary.Checked = value; }
		}
		/// <summary>
		/// Gets the new server name.
		/// </summary>
		public string ServerName { get { return this.textBoxName.Text; } }
		/// <summary>
		/// Gets the new server data source.
		/// </summary>
		public string DataSource { get { return this.textBoxDataSource.Text; } }
		/// <summary>
		/// Gets the new server username.
		/// </summary>
		public string Username { get { return this.textBoxUsername.Text; } }
		/// <summary>
		/// Gets the new server password.
		/// </summary>
		public SecureString Password { get { return this.textBoxPassword.SecureText; } }

		// Public events.

		/// <summary>
		/// An event raised when the server configuration has changed.
		/// </summary>
		public event EventHandler ConfigurationChanged;

		// Public methods.

		/// <summary>
		/// Call this method to update the state of the database server.
		/// </summary>
		/// <param name="server">The database server.</param>
		public void StateChanged(DbServer server)
		{
			// If the server is different from the current one, do nothing.
			if (server != this.server) return;
			// Else, update the state.
			this.pictureBox.Image = ControlServerProperties.images[(int)server.State];
		}
		
		// Protected methods.

		/// <summary>
		/// An event handler called when a new database server has been set.
		/// </summary>
		/// <param name="oldServer">The old server.</param>
		/// <param name="newServer">The new server.</param>
		protected virtual void OnServerSet(DbServer oldServer, DbServer newServer)
		{
			// If the server has not changed, do nothing.
			if (oldServer == newServer) return;

			if (newServer == null)
			{
				this.labelTitle.Text = "No server selected";
				this.tabControl.Visible = false;
			}
			else
			{
				this.labelTitle.Text = newServer.Name;
				this.textBoxName.Text = newServer.Name;
				this.textBoxId.Text = newServer.Id;
				this.textBoxType.Text = DbServers.ServerTypeNames[(int)newServer.Type];
				this.textBoxDataSource.Text = newServer.DataSource;
				this.textBoxUsername.Text = newServer.Username;
				this.textBoxPassword.SecureText = newServer.Password;
				this.textBoxDateCreated.Text = newServer.DateCreated.ToString();
				this.textBoxDateModified.Text = newServer.DateModified.ToString();
				this.pictureBox.Image = ControlServerProperties.images[(int)newServer.State];
				this.tabControl.Visible = true;
			}
			this.tabControl.SelectedTab = this.tabPageGeneral;
			if (this.Focused)
			{
				this.textBoxName.Select();
				this.textBoxName.SelectionStart = 0;
				this.textBoxName.SelectionLength = 0;
			}
		}

		/// <summary>
		/// An event handler called when the configuration changes.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		protected virtual void OnChanged(object sender, EventArgs e)
		{
			// Update the title.
			this.labelTitle.Text = this.textBoxName.Text;
			// Raise the configuration changed event.
			if (this.ConfigurationChanged != null) this.ConfigurationChanged(sender, e);
		}
	}
}
