/* 
 * Copyright (C) 2013 Alex Bikfalvi
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
using DotNetApi;
using DotNetApi.Windows.Controls;
using InetCommon.Database;
using InetControls.Events;
using InetControls.Forms.Database;

namespace InetControls.Controls.Database
{
	/// <summary>
	/// A generic control that allows a background database operation.
	/// </summary>
	public abstract class ControlBase : NotificationControl
	{
		private readonly FormChangePassword formChangePassword = new FormChangePassword();

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlBase()
		{
			// Add the event handler to the change password form.
			this.formChangePassword.PasswordChanged += this.OnPasswordChanged;
		}

		// Protected methods.

		/// <summary>
		/// A method called when started connecting to the database server.
		/// </summary>
		/// <param name="server">The database server.</param>
		protected virtual void OnConnectStarted(DbServer server) { }
		/// <summary>
		/// A method called when connecting to the database has succeeded.
		/// </summary>
		/// <param name="server">The database server.</param>
		protected virtual void OnConnectSucceeded(DbServer server) { }
		/// <summary>
		/// A method called when connecting to the database has failed.
		/// </summary>
		/// <param name="server">The database server.</param>
		protected virtual void OnConnectFailed(DbServer server) { }
		/// <summary>
		/// A method called when started disconnecting from the database server.
		/// </summary>
		/// <param name="server">The database server.</param>
		protected virtual void OnDisconnectStarted(DbServer server) { }
		/// <summary>
		/// A method called when disconnecting from the database has succeeded.
		/// </summary>
		/// <param name="server">The database server.</param>
		protected virtual void OnDisconnectSucceeded(DbServer server) { }
		/// <summary>
		/// A method called when disconnecting from the database has failed.
		/// </summary>
		/// <param name="server">The database server.</param>
		protected virtual void OnDisconnectFailed(DbServer server) { }

		/// <summary>
		/// Connects to the current database.
		/// </summary>
		/// <param name="server">The database server.</param>
		/// <param name="userState">The user state.</param>
		protected void DatabaseConnect(DbServer server, object userState = null)
		{
			// Call the connecting method.
			this.OnConnectStarted(server);
			// Show a connecting message.
			this.ShowMessage(Resources.Connect_48, "Database", "Connecting to the database server \'{0}\'...".FormatWith(server.Name));
			try
			{
				// Connect asynchronously to the database server.
				server.Open(this.DatabaseConnected, userState);
			}
			catch (Exception exception)
			{
				// If an exception occurs, hide the connecting message.
				this.HideMessage();
				// Call the on connect failed method.
				this.OnConnectFailed(server);
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
		/// Disconnects from the current database.
		/// </summary>
		/// <param name="server">The database server.</param>
		protected void DatabaseDisconnect(DbServer server)
		{
			// Call the disconnecting method.
			this.OnDisconnectStarted(server);
			// Show a connecting message.
			this.ShowMessage(Resources.Disconnect_48, "Database", "Disconnecting from the database server \'{0}\'...".FormatWith(server.Name));
			try
			{
				// Connect asynchronously to the database server.
				server.Close(this.DatabaseDisconnected);
			}
			catch (Exception exception)
			{
				// If an exception occurs, hide the connecting message.
				this.HideMessage();
				// Call the on disconnect failed method.
				this.OnDisconnectFailed(server);
				// Display an error message box to the user.
				MessageBox.Show(
					this,
					"Disconnecting from the database server \'{0}\' failed. {1}".FormatWith(server.Name, exception.Message),
					"Disconnecting from Database Failed",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
					);
			}
		}

		/// <summary>
		/// Changes the password of the specified database server.
		/// </summary>
		/// <param name="server">The database server.</param>
		protected void DatabaseChangePassword(DbServer server)
		{
			// Change the password for the selected server.
			this.formChangePassword.ShowDialog(this, server.Password, server);
		}

		/// <summary>
		/// Executes a database query.
		/// </summary>
		/// <param name="server">The database server.</param>
		/// <param name="query">The database query.</param>
		protected abstract void DatabaseQuery(DbServer server, DbQuery query);

		// Private methods.

		/// <summary>
		/// A callback method called when a connection to a server has completed.
		/// </summary>
		/// <param name="asyncState">The asynchronous state.</param>
		private void DatabaseConnected(DbServerAsyncState asyncState)
		{
			// Execute the code on the UI thread.
			this.Invoke(() =>
			{
				// Hide the connecting message.
				this.HideMessage();
				// Check if an exception occurred.
				if (asyncState.Exception != null)
				{
					// Call the event handler.
					this.OnConnectFailed(asyncState.Server);
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
									this.DatabaseChangePassword(asyncState.Server);
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
									this.DatabaseChangePassword(asyncState.Server);
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
					// Call the event handler.
					this.OnConnectSucceeded(asyncState.Server);
					// If there exists a user asynchronous state.
					if (asyncState.AsyncState != null)
					{
						// If the user state is a database query.
						if (asyncState.AsyncState is DbQuerySql)
						{
							// Execute the database query.
							this.DatabaseQuery(asyncState.Server, asyncState.AsyncState as DbQuery);
						}
					}
				}
			});
		}

		/// <summary>
		/// A callback method called when a disconnection from a server has completed.
		/// </summary>
		/// <param name="asyncState">The asynchronous state.</param>
		private void DatabaseDisconnected(DbServerAsyncState asyncState)
		{
			// Execute the code on the UI thread.
			this.Invoke(() =>
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
					// Call the event handler.
					this.OnDisconnectFailed(asyncState.Server);
				}
				else
				{
					// Call the event handler.
					this.OnDisconnectSucceeded(asyncState.Server);
				}
			});
		}

		/// <summary>
		/// An event handler called when the user changes the password for a database server.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnPasswordChanged(object sender, PasswordChangedEventArgs e)
		{
			// Get the database server.
			DbServer server = e.State as DbServer;
			// Show a password changing message.
			this.ShowMessage(Resources.Connect_48, "Database", "Changing the password for the database server \'{0}\'...".FormatWith(server.Name));
			try
			{
				// Change the password asynchronously of the database server.
				server.ChangePassword(e.NewPassword, this.OnPasswordChangeCompleted);
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
			// Execute the code on the UI thread.
			this.Invoke(() =>
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
			});
		}
	}
}
