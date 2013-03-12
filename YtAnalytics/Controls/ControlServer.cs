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
		private delegate void TableEventHandler(DbData table);
		private delegate void ExceptionEventHandler(Exception exception);

		private static string logSource = "Database";

		// UI formatter.
		private Formatting formatting = new Formatting();

		private Crawler crawler;
		private DbServer server;

		private ControlMessage message = new ControlMessage();

		private ShowMessageEventHandler delegateShowMessage;
		private HideMessageEventHandler delegateHideMessage;

		private FormServerProperties formProperties = new FormServerProperties();
		private FormChangePassword formChangePassword = new FormChangePassword();
		private FormDatabaseProperties formDatabaseProperties = new FormDatabaseProperties();

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

			// Add the event handlers for the database server.
			this.server.ServerChanged += OnServerChanged;
			this.server.StateChanged += OnServerStateChanged;
			this.server.DatabaseChanged += OnDatabaseChanged;
			this.crawler.Servers.ServerPrimaryChanged += this.OnPrimaryServerChanged;

			// Add the event handler to the change password form.
			this.formChangePassword.PasswordChanged += OnPasswordChanged;

			// Initialize the contols.
			this.OnServerChanged(this.server);
			this.OnServerStateChanged(this.server, null);

			// Add the event handler for the database server log.
			this.server.EventLogged += OnEventLogged;

			// Initialize the server database.
			this.OnDatabaseChanged(this.server, null, this.server.Database);
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
		void OnDatabaseChanged(DbServer server, DbDatabase oldDatabase, DbDatabase newDatabase)
		{
			// Update the current database.
			if (newDatabase != null)
			{
				this.textBoxDatabase.Text = string.Format("{0} (ID {1} created on {2})", this.server.Database.Name, this.server.Database.Id, this.server.Database.DateCreate);
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
				DbDatabase db = item.Tag as DbDatabase;
				item.ImageIndex = db.Equals(this.server.Database) ? 1 : 0;
			}
			// Update the select button.
			if (this.listViewDatabases.SelectedItems.Count != 0)
			{
				// Get the item databse.
				DbDatabase db = this.listViewDatabases.SelectedItems[0].Tag as DbDatabase;
				this.buttonDatabaseSelect.Enabled = !db.Equals(this.server.Database);
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
				// Else, process the user state.
				else
				{
					// If there exists a user asynchronous state.
					if (asyncState.AsyncState != null)
					{
						// If the user state is an event handler, call that event handler.
						if (asyncState.AsyncState.GetType() == typeof(EventHandler))
						{
							// Get the event handler.
							EventHandler handler = asyncState.AsyncState as EventHandler;
							// Call the event handler.
							handler(this, null);
						}
					}
				}
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
			this.ShowMessage(Resources.Disconnect_48, string.Format("Disconnecting from the database server \'{0}\'...", this.server.Name));
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
			// Call this handler on the UI thread.
			if (this.InvokeRequired)
			{
				this.Invoke(new EventHandler(this.OnRefreshDatabases), new object[] { sender, e });
				return;
			}

			// If the database server is not connected, first connect to the database.
			if (this.server.State != DbServer.ServerState.Connected)
			{
				// Show a connecting message.
				this.ShowMessage(Resources.Connect_48, string.Format("Connecting to the database server \'{0}\'...", this.server.Name));
				try
				{
					// Connect asynchronously to the database server, and add this method as a handler.
					this.server.Open(this.OnConnected, new EventHandler(this.OnRefreshDatabases));
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
				return;
			}

			// Refresh the list of databases.

			// Create a new database command for the list of server databases.
			try
			{
				// Clear the databases list.
				this.listViewDatabases.Items.Clear();
				// Disable the refresh button.
				this.buttonDatabaseRefresh.Enabled = false;
				// Show a connecting message.
				this.ShowMessage(Resources.DatabaseBusy_48, string.Format("Refreshing the list of databases for the database server \'{0}\'...", this.server.Name));
				using (DbCommand command = this.server.CreateCommand(this.server.QueryDatabases))
				{
					// Execute the command.
					command.ExecuteReader((DbAsyncResult commandResult, DbReader reader) =>
					{
						try
						{
							// Throw the command exception, if any.
							if (commandResult.Exception != null) throw commandResult.Exception;
							// Read the results table.
							reader.Read(null, (DbAsyncResult readerResult, DbData result) =>
							{
								try
								{
									// Throw the reader exception, if any.
									if (readerResult.Exception != null)
									{
										reader.Close();
										throw readerResult.Exception;
									}
									reader.Close();
									// Show a success message.
									this.ShowMessage(Resources.DatabaseSuccess_48, string.Format("Refreshing the list of databases for the database server \'{0}\' completed successfully.", this.server.Name), false);
									// Wait.
									Thread.Sleep(this.crawler.Config.ConsoleMessageCloseDelay);
									// Hide the message.
									this.HideMessage();
									// Call the completion method.
									this.OnRefreshDatabasesSuccess(result);
								}
								catch (Exception exception)
								{
									// Show an error message.
									this.ShowMessage(Resources.DatabaseError_48, string.Format("Refreshing the list of databases for the database server \'{0}\' failed.", this.server.Name), false);
									// Log the event.
									this.server.LogEvent(
										LogEventLevel.Important,
										LogEventType.Error,
										"Refreshing the list of databases for the database server \'{0}\' failed. {1}",
										new object[] { this.server.Name, exception.Message },
										exception);
									// Wait.
									Thread.Sleep(this.crawler.Config.ConsoleMessageCloseDelay);
									// Hide the message.
									this.HideMessage();
									// Call the completion method.
									this.OnRefreshDatabasesFail(exception);
								}
							});
						}
						catch (Exception exception)
						{
							// Show an error message.
							this.ShowMessage(Resources.DatabaseError_48, string.Format("Refreshing the list of databases for the database server \'{0}\' failed.", this.server.Name), false);
							// Log the event.
							this.server.LogEvent(
								LogEventLevel.Important,
								LogEventType.Error,
								"Refreshing the list of databases for the database server \'{0}\' failed. {1}",
								new object[] { this.server.Name, exception.Message },
								exception);
							// Wait.
							Thread.Sleep(this.crawler.Config.ConsoleMessageCloseDelay);
							// Hide the message.
							this.HideMessage();
							// Call the completion method.
							this.OnRefreshDatabasesFail(exception);
						}
					});
				}
			}
			catch (Exception exception)
			{
				// Show an error message.
				this.ShowMessage(Resources.DatabaseError_48, string.Format("Refreshing the list of databases for the database server \'{0}\' failed.", this.server.Name), false);
				// Log the event.
				this.server.LogEvent(
					LogEventLevel.Important,
					LogEventType.Error,
					"Refreshing the list of databases for the database server \'{0}\' failed. {1}",
					new object[] { this.server.Name, exception.Message },
					exception);
				// Wait.
				Thread.Sleep(this.crawler.Config.ConsoleMessageCloseDelay);
				// Hide the message.
				this.HideMessage();
				// Call the completion method.
				this.OnRefreshDatabasesFail(exception);
			}
		}

		/// <summary>
		/// An event handler called when the refresh of server databases completed successfully.
		/// </summary>
		/// <param name="table">The databases table.</param>
		private void OnRefreshDatabasesSuccess(DbData table)
		{
			// Call the method on the UI thread.
			if (this.InvokeRequired) this.Invoke(new TableEventHandler(this.OnRefreshDatabasesSuccess), new object[] { table });
			else
			{
				// Add the databases to the list.
				for (int row = 0; row < table.RowCount; row++)
				{
					// Create the database for this server.
					DbDatabase db = this.server.CreateDatabase(table, row);

					// Add a new list view item.
					ListViewItem item = new ListViewItem(new string[] {
						db.Name,
						db.Id.ToString(),
						db.DateCreate.ToString()
					});
					item.Tag = db;
					item.ImageIndex = db.Equals(this.server.Database) ? 1 : 0;
					this.listViewDatabases.Items.Add(item);
				}
				this.buttonDatabaseRefresh.Enabled = true;
			}
		}

		/// <summary>
		/// An event handler called when the refresh of server databases failed.
		/// </summary>
		/// <param name="exception">The exception.</param>
		private void OnRefreshDatabasesFail(Exception exception)
		{
			// Call the method on the UI thread.
			if (this.InvokeRequired) this.Invoke(new ExceptionEventHandler(this.OnRefreshDatabasesFail), new object[] { exception });
			else
			{
				this.buttonDatabaseRefresh.Enabled = true;
			}
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
				DbDatabase db = this.listViewDatabases.SelectedItems[0].Tag as DbDatabase;
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
			DbDatabase db = this.listViewDatabases.SelectedItems[0].Tag as DbDatabase;

			// Set the database as the current database.
			this.server.Database = db;
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
			DbDatabase db = this.listViewDatabases.SelectedItems[0].Tag as DbDatabase;
			// Show the database properties.
			this.formDatabaseProperties.ShowDialog(this, db, db.Equals(this.server.Database));
		}
	}
}
