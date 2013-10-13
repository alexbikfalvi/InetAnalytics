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
using System.Data.SqlClient;
using System.Net;
using System.Security;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using YtApi.Api.V2;
using YtApi.Api.V2.Data;
using YtCrawler;
using YtCrawler.Database;
using YtCrawler.Log;
using YtAnalytics.Controls;
using YtAnalytics.Forms.Database;
using DotNetApi;
using DotNetApi.Windows;
using DotNetApi.Windows.Controls;

namespace YtAnalytics.Controls.Database
{
	/// <summary>
	/// A class representing the control to browse the video entry in the YouTube API version 2.
	/// </summary>
	public partial class ControlServerQuery : NotificationControl
	{
		private delegate void ResultAction(DbDataRaw table, int recordsAffected);
		private delegate void ExceptionAction(Exception exception);

		private Crawler crawler;
		private DbServer server;

		private readonly FormChangePassword formChangePassword = new FormChangePassword();

		// Database command.
		DbCommand command = null;

		/// <summary>
		/// Creates a new instance of the control.
		/// </summary>
		public ControlServerQuery()
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
		public void Initialize(Crawler crawler, DbServer server)
		{
			// Set the crawler.
			this.crawler = crawler;
			// Set the server.
			this.server = server;

			// Add the event handlers for the database server.
			this.server.StateChanged += this.OnServerStateChanged;

			// Initialize the contols.
			this.OnServerStateChanged(this.server, null);

		}

		// Private methods.

		/// <summary>
		/// An event handler called when the state of a server connection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnServerStateChanged(object sender, DbServerStateEventArgs e)
		{
			// Call the method on the UI thread.
			if (this.InvokeRequired) this.Invoke(new DbServerStateEventHandler(this.OnServerStateChanged), new object[] { sender, e });
			else
			{
				this.buttonConnect.Enabled =
					(this.server.State == DbServer.ServerState.Disconnected) ||
					(this.server.State == DbServer.ServerState.Failed);
				this.buttonDisconnect.Enabled = this.server.State == DbServer.ServerState.Connected;
			}
		}

		/// <summary>
		/// An event handler called when connecting to a database server.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnConnect(object sender, EventArgs e)
		{
			// Disable the tool strip.
			this.toolStrip.Enabled = false;
			// Show a connecting message.
			this.ShowMessage(Resources.Connect_48, "Database Server", "Connecting to the database server \'{0}\'...".FormatWith(this.server.Name)); 
			try
			{
				// Connect asynchronously to the database server.
				this.server.Open(this.OnConnected);
			}
			catch (Exception exception)
			{
				// Enable the tool strip.
				this.toolStrip.Enabled = true;
				// If an exception occurs, hide the connecting message.
				this.HideMessage();
				// Display an error message box to the user.
				MessageBox.Show(
					this,
					"Connecting to the database server \'{0}\' failed. {1}".FormatWith(this.server.Name, exception.Message),
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
				// Enable the tool strip.
				this.toolStrip.Enabled = true;
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
									"The login password for the database server \'{0}\' has expired. Do you wish to change the password now?".FormatWith(asyncState.Server.Name),
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
									"To connect to the database server \'{0}\' you must change the password before the first login. Do you wish to change the password now?".FormatWith(asyncState.Server.Name),
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
									"Connecting to the database server \'{0}\' failed. {1}".FormatWith(asyncState.Server.Name, asyncState.Exception.DbMessage),
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
							"Connecting to the database server \'{0}\' failed. {1}".FormatWith(asyncState.Server.Name, asyncState.Exception.Message),
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
						if (asyncState.AsyncState is EventHandler)
						{
							// Get the event handler.
							EventHandler handler = asyncState.AsyncState as EventHandler;
							// Call the event handler.
							handler(this, EventArgs.Empty);
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
			this.ShowMessage(Resources.Disconnect_48, "Database Server", "Disconnecting from the database server \'{0}\'...".FormatWith(this.server.Name));
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
					"Disconnecting from the database server \'{0}\' failed. {1}".FormatWith(this.server.Name, exception.Message),
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
							"Connecting to the database server \'{0}\' failed. {1}".FormatWith(asyncState.Server.Name, asyncState.Exception.DbMessage),
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
							"Connecting to the database server \'{0}\' failed. {1}".FormatWith(asyncState.Server.Name, asyncState.Exception.Message),
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
		private void OnPasswordChanged(SecureString oldPassword, SecureString newPassword, object state)
		{
			// Get the server.
			DbServer server = state as DbServer;
			// Show a password changing message.
			this.ShowMessage(Resources.Connect_48, "Database", "Changing the password for the database server \'{0}\'...".FormatWith(server.Name));
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
					"Connecting to the database server \'{0}\' failed. {1}".FormatWith(server.Name, exception.Message),
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
							"Connecting to the database server \'{0}\' failed. {1}".FormatWith(asyncState.Server.Name, asyncState.Exception.DbMessage),
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
							"Connecting to the database server \'{0}\' failed. {1}".FormatWith(asyncState.Server.Name, asyncState.Exception.Message),
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
		/// An event handler called when the current query has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnQueryChanged(object sender, EventArgs e)
		{
			// Set the enabled state of the start button.
			this.buttonStart.Enabled = !string.IsNullOrWhiteSpace(this.codeBox.Text);
		}

		/// <summary>
		/// An event handler called when the user clicks on the start query button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStart(object sender, EventArgs e)
		{
			// Call this handler on the UI thread.
			if (this.InvokeRequired)
			{
				this.Invoke(new EventHandler(this.OnStart), new object[] { sender, e });
				return;
			}

			// If the database server is not connected, first connect to the database.
			if (this.server.State != DbServer.ServerState.Connected)
			{
				// Show a connecting message.
				this.ShowMessage(Resources.Connect_48, "Database", "Connecting to the database server \'{0}\'...".FormatWith(this.server.Name));
				try
				{
					// Connect asynchronously to the database server, and add this method as a handler.
					this.server.Open(this.OnConnected, new EventHandler(this.OnStart));
				}
				catch (Exception exception)
				{
					// If an exception occurs, hide the connecting message.
					this.HideMessage();
					// Display an error message box to the user.
					MessageBox.Show(
						this,
						"Connecting to the database server \'{0}\' failed. {1}".FormatWith(this.server.Name, exception.Message),
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
				// Clear the result table.
				this.dataGrid.Rows.Clear();
				this.dataGrid.Columns.Clear();
				// Disable the start button.
				this.buttonStart.Enabled = false;
				// Enable the stop button.
				this.buttonStop.Enabled = true;
				// Disable the query code box.
				this.codeBox.Enabled = false;
				// Set the command to null.
				this.command = null;
				// Show a connecting message.
				this.ShowMessage(Resources.DatabaseBusy_48, "Database", "Executing query on the database server \'{0}\'...".FormatWith(this.server.Name));
				// Create the command.
				this.command = this.server.CreateCommand(DbQuery.Create(this.codeBox.Text));
				// Execute the command.
				command.ExecuteReader((DbAsyncResult commandResult, DbReader reader) =>
				{
					try
					{
						// Throw the command exception, if any.
						if (commandResult.Exception != null) throw commandResult.Exception;
						// Read the results table.
						reader.Read(null, (DbAsyncResult readerResult, DbDataRaw result) =>
						{
							try
							{
								// Throw the reader exception, if any.
								if (readerResult.Exception != null)
								{
									reader.Close();
									throw readerResult.Exception;
								}
								// Get the number of records affected.
								int recordsAffected = reader.RecordsAffected;
								// Close the reader.
								reader.Close();
								// Dispose and reset the command.
								this.command.Dispose();
								this.command = null;
								// Show a success message.
								this.ShowMessage(Resources.DatabaseSuccess_48, "Database", "Executing query on the database server \'{0}\' completed successfully.".FormatWith(this.server.Name), false);
								// Wait.
								Thread.Sleep(CrawlerStatic.ConsoleMessageCloseDelay);
								// Hide the message.
								this.HideMessage();
								// Call the completion method.
								this.OnQuerySuccess(result, recordsAffected);
							}
							catch (Exception exception)
							{
								// Dispose and reset the command.
								this.command.Dispose();
								this.command = null;
								// Show an error message.
								this.ShowMessage(Resources.DatabaseError_48, "Database", "Executing query on the database server \'{0}\' failed.".FormatWith(this.server.Name), false);
								// Log the event.
								this.server.LogEvent(
									LogEventLevel.Important,
									LogEventType.Error,
									"Executing query on the database server \'{0}\' failed. {1}",
									new object[] { this.server.Name, exception.Message },
									exception);
								// Wait.
								Thread.Sleep(CrawlerStatic.ConsoleMessageCloseDelay);
								// Hide the message.
								this.HideMessage();
								// Call the completion method.
								this.OnQueryFail(exception);
							}
						});
					}
					catch (Exception exception)
					{
						// Dispose and reset the command.
						this.command.Dispose();
						this.command = null;
						// Show an error message.
						this.ShowMessage(Resources.DatabaseError_48, "Database", "Executing query on the database server \'{0}\' failed.".FormatWith(this.server.Name), false);
						// Log the event.
						this.server.LogEvent(
							LogEventLevel.Important,
							LogEventType.Error,
							"Executing query on the database server \'{0}\' failed. {1}",
							new object[] { this.server.Name, exception.Message },
							exception);
						// Wait.
						Thread.Sleep(CrawlerStatic.ConsoleMessageCloseDelay);
						// Hide the message.
						this.HideMessage();
						// Call the completion method.
						this.OnQueryFail(exception);
					}
				});
			}
			catch (Exception exception)
			{
				// Dispose and reset the command.
				this.command.Dispose();
				this.command = null;
				// Show an error message.
				this.ShowMessage(Resources.DatabaseError_48, "Database", "Executing query on the database server \'{0}\' failed.".FormatWith(this.server.Name), false);
				// Log the event.
				this.server.LogEvent(
					LogEventLevel.Important,
					LogEventType.Error,
					"Executing query on the database server \'{0}\' failed. {1}",
					new object[] { this.server.Name, exception.Message },
					exception);
				// Wait.
				Thread.Sleep(CrawlerStatic.ConsoleMessageCloseDelay);
				// Hide the message.
				this.HideMessage();
				// Call the completion method.
				this.OnQueryFail(exception);
			}
		}

		/// <summary>
		/// An event handler called when the query completed successfully.
		/// </summary>
		/// <param name="table">The data table.</param>
		/// <param name="recordsAffected">The number of records affected by the query.</param>
		private void OnQuerySuccess(DbDataRaw table, int recordsAffected)
		{
			// Call this method on the UI thread.
			if (this.InvokeRequired) this.Invoke(new ResultAction(this.OnQuerySuccess), new object[] { table, recordsAffected });
			else
			{
				// Enable the start button.
				this.buttonStart.Enabled = true;
				// Disable the stop button.
				this.buttonStop.Enabled = false;
				// Disable the query code box.
				this.codeBox.Enabled = true;
				// Display the table data.
				
				// If the table has any data.
				if (table.HasData)
				{
					// Add the table columns.
					foreach (string column in table.ColumnNames)
					{
						this.dataGrid.Columns.Add(column, column);
					}
					// Add the table rows.
					for (int row = 0; row < table.RowCount; row++)
					{
						this.dataGrid.Rows.Add(table.GetRow(row));
					}

					// Update the status box.
					this.statusLabel.Text = "Query completed successfully: {0} {1} of data fetched.".FormatWith(table.RowCount.ToString(), table.RowCount == 1 ? "row" : "rows");
				}
				else
				{
					if (recordsAffected >= 0) this.statusLabel.Text = "Query completed successfully: {0} data records changed.".FormatWith(recordsAffected);
					else this.statusLabel.Text = "Query completed successfully.";
				}
				this.statusLabel.Image = Resources.Success_16;
			}
		}

		/// <summary>
		/// An event handler called when the query failed.
		/// </summary>
		/// <param name="exception">The exception.</param>
		private void OnQueryFail(Exception exception)
		{
			// Call this method on the UI thread.
			if (this.InvokeRequired) this.Invoke(new ExceptionAction(this.OnQueryFail), new object[] { exception });
			else
			{
				// Enable the start button.
				this.buttonStart.Enabled = true;
				// Disable the stop button.
				this.buttonStop.Enabled = false;
				// Disable the query code box.
				this.codeBox.Enabled = true;
				// Update the status box.
				this.statusLabel.Text = "Query failed. {0}".FormatWith(exception.Message);
				this.statusLabel.Image = Resources.Error_16;
			}
		}

		/// <summary>
		/// An event handler called when formatting the data in a table cell.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			// If the value is null, do nothing.
			if (e.Value == null) return;
			// If the value is a byte array, update the cell value with the corresponding string.
			if (e.Value is byte[])
			{
				StringBuilder builder = new StringBuilder("0x");
				foreach(byte value in e.Value as byte[])
				{
					builder.AppendFormat("{0:X2}", value);
				}
				this.dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = builder.ToString();
			}
		}

		/// <summary>
		/// An event handler called when the user cancels an ongoing SQL command.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStop(object sender, EventArgs e)
		{
			// If the current command is null, do nothing.
			if (null == this.command) return;
			// Otherwise, cancel the command.
			this.command.Cancel();
			// Disable the stop button.
			this.buttonStop.Enabled = false;
		}
	}
}
