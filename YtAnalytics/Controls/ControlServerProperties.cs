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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YtCrawler.Database;

namespace YtAnalytics.Controls
{
	/// <summary>
	/// Displays the information of a log event.
	/// </summary>
	public partial class ControlServerProperties : UserControl
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
		/// Gets or sets the current log event.
		/// </summary>
		public DbServer Server
		{
			get { return this.server; }
			set
			{
				this.server = value;
				if (value == null)
				{
					this.labelTitle.Text = string.Empty;
					this.tabControl.Visible = false;
				}
				else
				{
					this.labelTitle.Text = value.Name;
					this.textBoxName.Text = value.Name;
					this.textBoxId.Text = value.Id;
					this.textBoxType.Text = DbServers.ServerTypeNames[(int)value.Type];
					this.textBoxDataSource.Text = value.DataSource;
					this.textBoxUsername.Text = value.Username;
					this.textBoxPassword.Text = value.Password;
					this.tabControl.Visible = true;
					this.pictureBox.Image = ControlServerProperties.images[(int)value.State];
				}
				this.tabControl.SelectedTab = this.tabPageGeneral;
				this.textBoxName.Select();
				this.textBoxName.SelectionStart = 0;
				this.textBoxName.SelectionLength = 0;
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
		public string Password { get { return this.textBoxPassword.Text; } }

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

		/// <summary>
		/// An event handler called when the configuration changes.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnChanged(object sender, EventArgs e)
		{
			// Update the title.
			this.labelTitle.Text = this.textBoxName.Text;
			// Raise the configuration changed event.
			if (this.ConfigurationChanged != null) this.ConfigurationChanged(sender, e);
		}
	}
}
