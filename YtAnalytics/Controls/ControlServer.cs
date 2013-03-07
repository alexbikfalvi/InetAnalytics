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
using System.Threading.Tasks;
using System.Windows.Forms;
using YtApi.Api.V2;
using YtApi.Api.V2.Data;
using YtCrawler;
using YtCrawler.Database;
using YtCrawler.Log;
using YtAnalytics.Controls;
using YtAnalytics.Forms;
using DotNetApi.Windows;

namespace YtAnalytics.Controls
{
	/// <summary>
	/// A class representing the control to browse the video entry in the YouTube API version 2.
	/// </summary>
	public partial class ControlServer : UserControl
	{
		private static string logSource = "Database/";

		// UI formatter.
		private Formatting formatting = new Formatting();

		private Crawler crawler;
		private DbServer server;

		private ControlMessage message = new ControlMessage();

		private ShowMessageEventHandler delegateShowMessage;
		private HideMessageEventHandler delegateHideMessage;

		private FormServerProperties formProperties = new FormServerProperties();
		private FormChangePassword formChangePassword = new FormChangePassword();

		private TreeNode treeNode = null;

		private static Image[] images = {
											Resources.ServerDown_48,
											Resources.ServerUp_48,
											Resources.ServerWarning_48,
											Resources.ServerBusy_48,
											Resources.ServerBusy_48
										};

		/// <summary>
		/// Creates a new instance of the control.
		/// </summary>
		public ControlServer()
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
			this.treeNode.Tag = this;

			// Add the event handlers for the database server.
			this.server.ServerChanged += OnServerChanged;
			this.server.StateChanged += OnServerStateChanged;
			this.crawler.Servers.ServerPrimaryChanged += this.OnPrimaryServerChanged;

			// Add the event handler to the change password form.
			this.formChangePassword.PasswordChanged += OnPasswordChanged;

			// Initialize the contols.
			this.OnServerChanged(this.server);
			this.OnServerStateChanged(this.server, null);

			// Add the event handler for the database server log.
			this.server.EventLogged += OnEventLogged;
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
			}
		}

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
			// Show a connecting message.
			this.ShowMessage(Resources.Connect_48, string.Format("Connecting to the database server \'{0}\'...", this.server.Name)); 
			try
			{
				// Connect asynchronously to the database server.
				this.server.Open(this.OnConnected);
			}
			catch (Exception exception)
			{
				// If an exception occurs, hide the connecting message.
				this.HideMessage();
				// Display an error message box to the user.
				MessageBox.Show(
					this,
					string.Format("Connecting to the database server \'{0}\' failed. {1}", this.server.Name, exception.Message),
					"Connecting to Database Failed",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
					);
			}
		}

		/// <summary>
		/// A callback method called when a connection to a server has completed.
		/// </summary>
		/// <param name="asyncState">The asynchronous state.</param>
		private void OnConnected(DbServerAsyncState asyncState)
		{
			// Call the method on the UI thread.
			if (this.InvokeRequired) this.Invoke(new DbServerCallback(this.OnConnected), new object[] { asyncState });
			else
			{
				// Hide the connecting message.
				this.HideMessage();
				// Check if an exception occurred.
				if (asyncState.Exception != null)
				{
					// If this a database exception.
					if (asyncState.Exception.IsDb)
					{
						// Check the error type.
						switch (asyncState.Exception.DbType)
						{
							case DbException.Type.LoginPasswordExpired:
								if (DialogResult.Yes == MessageBox.Show(
									this,
									string.Format("The login password for the database server \'{0}\' has expired. Do you wish to change the password now?", asyncState.Server.Name),
									"Login Password Expired",
									MessageBoxButtons.YesNo,
									MessageBoxIcon.Question,
									MessageBoxDefaultButton.Button2
									))
								{
									// Change password.
									this.OnChangePassword(null, null);
								}
								break;
							case DbException.Type.LoginPasswordMustChange:
								if (DialogResult.Yes == MessageBox.Show(
									this,
									string.Format("To connect to the database server \'{0}\' you must change the password before the first login. Do you wish to change the password now?", asyncState.Server.Name),
									"Must Change Password",
									MessageBoxButtons.YesNo,
									MessageBoxIcon.Question,
									MessageBoxDefaultButton.Button2
									))
								{
									// Change password.
									this.OnChangePassword(null, null);
								}
								break;
							default:
								// Display an error message.
								MessageBox.Show(
									this,
									string.Format("Connecting to the database server \'{0}\' failed. {1}", asyncState.Server.Name, asyncState.Exception.DbMessage),
									"Connecting to Database Failed",
									MessageBoxButtons.OK,
									MessageBoxIcon.Error
									);
								break;
						}
					}
					else
					{
						// Display an error message.
						MessageBox.Show(
							this,
							string.Format("Connecting to the database server \'{0}\' failed. {1}", asyncState.Server.Name, asyncState.Exception.Message),
							"Connecting to Database Failed",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error
							);
					}
				}
				// Else, do nothing.
			}
		}

		/// <summary>
		/// An event handler called when disconnecting from a database server.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnDisconnect(object sender, EventArgs e)
		{
			// Show a connecting message.
			this.ShowMessage(Resources.Connect_48, string.Format("Disconnecting from the database server \'{0}\'...", this.server.Name));
			try
			{
				// Connect asynchronously to the database server.
				this.server.Close(this.OnDisconnected);
			}
			catch (Exception exception)
			{
				// If an exception occurs, hide the connecting message.
				this.HideMessage();
				// Display an error message box to the user.
				MessageBox.Show(
					this,
					string.Format("Disconnecting from the database server \'{0}\' failed. {1}", this.server.Name, exception.Message),
					"Disconnecting from Database Failed",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
					);
			}
		}

		/// <summary>
		/// A callback method called when a disconnection to a server has completed.
		/// </summary>
		/// <param name="asyncState">The asynchronous state.</param>
		private void OnDisconnected(DbServerAsyncState asyncState)
		{
			// Call the method on the UI thread.
			if (this.InvokeRequired) this.Invoke(new DbServerCallback(this.OnDisconnected), new object[] { asyncState });
			else
			{
				// Hide the connecting message.
				this.HideMessage();
				// Check if an exception occurred.
				if (asyncState.Exception != null)
				{
					// If this a database exception.
					if (asyncState.Exception.IsDb)
					{
						// Display a database error message.
						MessageBox.Show(
							this,
							string.Format("Connecting to the database server \'{0}\' failed. {1}", asyncState.Server.Name, asyncState.Exception.DbMessage),
							"Connecting to Database Failed",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error
							);
					}
					else
					{
						// Display a generic error message.
						MessageBox.Show(
							this,
							string.Format("Connecting to the database server \'{0}\' failed. {1}", asyncState.Server.Name, asyncState.Exception.Message),
							"Connecting to Database Failed",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error
							);
					}
				}
				// Else, do nothing.
			}
		}

		/// <summary>
		/// An event handler called when the user changes the password.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnChangePassword(object sender, EventArgs e)
		{
			// Change the password for the selected server.
			this.formChangePassword.ShowDialog(this, this.server.Password, this.server);
		}

		/// <summary>
		/// An event handler called when the user changes the password for a database server.
		/// </summary>
		/// <param name="oldPassword">The old password.</param>
		/// <param name="newPassword">The new password.</param>
		/// <param name="state">The user state.</param>
		private void OnPasswordChanged(string oldPassword, string newPassword, object state)
		{
			// Get the server.
			DbServer server = state as DbServer;
			// Show a password changing message.
			this.ShowMessage(Resources.Connect_48, string.Format("Changing the password for the database server \'{0}\'...", server.Name));
			try
			{
				// Change the password asynchronously of the database server.
				server.ChangePassword(newPassword, this.OnPasswordChangeCompleted);
			}
			catch (Exception exception)
			{
				// If an exception occurs, hide the connecting message.
				this.HideMessage();
				// Display an error message box to the user.
				MessageBox.Show(
					this,
					string.Format("Connecting to the database server \'{0}\' failed. {1}", server.Name, exception.Message),
					"Connecting to Database Failed",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
					);
			}			
		}

		/// <summary>
		/// A callback method called when changing the password of a server completed.
		/// </summary>
		/// <param name="asyncState"></param>
		private void OnPasswordChangeCompleted(DbServerAsyncState asyncState)
		{
			// Call the method on the UI thread.
			if (this.InvokeRequired) this.Invoke(new DbServerCallback(this.OnPasswordChangeCompleted), new object[] { asyncState });
			else
			{
				// Hide the connecting message.
				this.HideMessage();
				// Check if an exception occurred.
				if (asyncState.Exception != null)
				{
					// If this a database exception.
					if (asyncState.Exception.IsDb)
					{
						// Display a database error message.
						MessageBox.Show(
							this,
							string.Format("Connecting to the database server \'{0}\' failed. {1}", asyncState.Server.Name, asyncState.Exception.DbMessage),
							"Connecting to Database Failed",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error
							);
					}
					else
					{
						// Display a generic error message.
						MessageBox.Show(
							this,
							string.Format("Connecting to the database server \'{0}\' failed. {1}", asyncState.Server.Name, asyncState.Exception.Message),
							"Connecting to Database Failed",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error
							);
					}
				}
				// Else, show a notification message.
				else
				{
					MessageBox.Show(
						this,
						"The database server password has been changed successfully.",
						"Server Password Changed",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information);
				}
			}
		}

		/// <summary>
		/// An event handler called when displaying the properties of a database server.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnProperties(object sender, EventArgs e)
		{
			// Show the properties dialog.
			this.formProperties.ShowDialog(this, this.server, this.crawler.Servers.IsPrimary(server));
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
	}
}
