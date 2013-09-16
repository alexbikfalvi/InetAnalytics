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
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.IO;
using DotNetApi.Security;
using YtAnalytics.Controls.Net.Ssh;
using YtCrawler;
using YtCrawler.Log;
using YtCrawler.Status;
using YtCrawler.Testing;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace YtAnalytics.Controls.Testing
{
	/// <summary>
	/// A control class for testing secure shell.
	/// </summary>
	public sealed partial class ControlTestingSshRequest : ControlSsh
	{
		private delegate void CommandResultEventHandler(SshCommand command, string result);
		private delegate void CommandCompleteEventHandler(SshCommand command);

		private static string logSource = "Testing Secure Shell";

		// Private variables.

		private Crawler crawler = null;
		private StatusHandler status = null;

		private byte[] sshKey = null;
		
		private bool configurationChanged = false;

		private CommandResultEventHandler delegateCommandResult;
		private CommandCompleteEventHandler delegateCommandComplete;

		// Public declarations

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlTestingSshRequest()
		{
			// Initialize component.
			InitializeComponent();

			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;

			// Create the delegates.
			this.delegateCommandResult = new CommandResultEventHandler(this.OnCommandResult);
			this.delegateCommandComplete = new CommandCompleteEventHandler(this.OnCommandComplete);
		}

		// Public methods.

		/// <summary>
		/// Initialized the control with the specified crawler.
		/// </summary>
		/// <param name="crawler">The crawler.</param>
		public void Initialize(Crawler crawler)
		{
			// Set the crawler.
			this.crawler = crawler;

			// Get the crawler status.
			this.status = this.crawler.Status.GetHandler(this);
			this.status.Send("Disconnected.", Resources.Server_16);

			// Enable the control.
			this.Enabled = true;

			// Load the settings.
			this.OnLoad();
		}

		// Protected methods.

		protected override void OnConnecting()
		{
			base.OnConnecting();
		}

		protected override void OnConnected()
		{
			base.OnConnected();
		}

		/// <summary>
		/// An event handler called when disconnecting from an SSH server.
		/// </summary>
		protected override void OnDisconnecting()
		{
			// Call the base class method.
			base.OnDisconnecting();

			// Change the buttons enabled state.
			this.buttonDisconnect.Enabled = false;
		}

		/// <summary>
		/// An event handler called when disconnected from an SSH server.
		/// </summary>
		protected override void OnDisconnected()
		{
			// Call the base class method.
			base.OnDisconnected();
			
			// Update the status bar.
			this.status.Send("Disconnected.", Resources.Server_16);

			// Change the controls enabled state.
			this.OnEnableControls();
			// Change the buttons enabled state.
			this.buttonConnect.Enabled = true;

			// Disable the console.
			this.OnDisableConsole();
		}

		// Private methods.

		/// <summary>
		/// Loads the current settings from the registry.
		/// </summary>
		private void OnLoad()
		{
			// Load the SSH key.
			this.sshKey = this.crawler.Testing.SshRequest.Key;

			this.textBoxServer.Text = this.crawler.Testing.SshRequest.Server;
			this.textBoxUsername.Text = this.crawler.Testing.SshRequest.Username;
			this.secureTextBoxPassword.SecureText = this.crawler.Testing.SshRequest.Password;
			this.textBoxKey.Text = this.sshKey != null ? Encoding.UTF8.GetString(this.sshKey).Replace("\n", Environment.NewLine) : string.Empty;
			
			this.radioPasswordAuthentication.Checked = this.crawler.Testing.SshRequest.Authentication == TestingSshRequest.AuthenticationType.Password;
			this.radioKeyAuthentication.Checked = this.crawler.Testing.SshRequest.Authentication == TestingSshRequest.AuthenticationType.Key;

			// Initialize the authentication controls.
			this.OnAuthenticationChanged(this, EventArgs.Empty);

			// Disable the save and undo buttons.
			this.buttonSave.Enabled = false;
			this.buttonUndo.Enabled = false;
		}

		/// <summary>
		/// Saves the current settings to the registry.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSave(object sender, EventArgs e)
		{
			this.crawler.Testing.SshRequest.Server = this.textBoxServer.Text;
			this.crawler.Testing.SshRequest.Username = this.textBoxUsername.Text;
			this.crawler.Testing.SshRequest.Password = this.secureTextBoxPassword.SecureText;
			this.crawler.Testing.SshRequest.Key = this.sshKey;

			this.crawler.Testing.SshRequest.Authentication = this.radioPasswordAuthentication.Checked ? TestingSshRequest.AuthenticationType.Password : TestingSshRequest.AuthenticationType.Key;

			// Disable the save and undo buttons.
			this.buttonSave.Enabled = false;
			this.buttonUndo.Enabled = false;
		}

		/// <summary>
		/// Undoes the current changes to the configuration.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnUndo(object sender, EventArgs e)
		{
			// Reload the settings.
			this.OnLoad();

			// Disable the save and undo buttons.
			this.buttonSave.Enabled = false;
			this.buttonUndo.Enabled = false;
		}

		/// <summary>
		/// An event handler called when the authentication has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAuthenticationChanged(object sender, EventArgs e)
		{
			// Change the controls enabled state.
			this.labelPassword.Enabled = this.radioPasswordAuthentication.Checked;
			this.secureTextBoxPassword.Enabled = this.radioPasswordAuthentication.Checked;
			this.labelKey.Enabled = this.radioKeyAuthentication.Checked;
			this.textBoxKey.Enabled = this.radioKeyAuthentication.Checked;
			this.buttonLoadKey.Enabled = this.radioKeyAuthentication.Checked;

			// Enable the save and undo buttons.
			this.buttonSave.Enabled = true;
			this.buttonUndo.Enabled = true;
		}

		/// <summary>
		/// An event handler called when the settings have changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnChanged(object sender, EventArgs e)
		{
			// Enable the save and undo buttons.
			this.buttonSave.Enabled = true;
			this.buttonUndo.Enabled = true;
			// Enable the connect button if the server is set.
			this.buttonConnect.Enabled = !string.IsNullOrWhiteSpace(this.textBoxServer.Text);
		}

		/// <summary>
		/// An event handler called when connecting to the SSH server.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnConnect(object sender, EventArgs e)
		{
			// If the username is empty, show a message and return.
			if (string.IsNullOrWhiteSpace(this.textBoxUsername.Text))
			{
				MessageBox.Show("The user name cannot be empty.", "Cannot Connect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// The connection info.
			ConnectionInfo connectionInfo = null;

			try
			{
				// Create a new connection info.
				if (this.radioPasswordAuthentication.Checked)
				{
					lock (this.Sync)
					{
						// Create a password connection info.
						connectionInfo = new PasswordConnectionInfo(this.textBoxServer.Text, this.textBoxUsername.Text, this.secureTextBoxPassword.SecureText.ConvertToUnsecureString());
					}
				}
				else if (this.radioKeyAuthentication.Checked)
				{
					// If the private key is null, show a message and return.
					if (null == this.sshKey)
					{
						MessageBox.Show("The key cannot be empty for the selected authentication method.", "Cannot Connect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
					// Create a memory stream with the key data.
					using (MemoryStream memoryStream = new MemoryStream(this.sshKey))
					{
						// Create the private key file.
						using (PrivateKeyFile keyFile = new PrivateKeyFile(memoryStream))
						{
							lock (this.Sync)
							{
								// Create a key connection info.
								connectionInfo = new PrivateKeyConnectionInfo(this.textBoxServer.Text, this.textBoxUsername.Text, keyFile);
							}
						}
					}
				}
				else
				{
					// If no authentication type is selected, do nothing.
					MessageBox.Show("You must select a method of authentication.", "Cannot Connect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
			}
			catch (Exception exception)
			{
				// Show an error dialog if an exception is thrown.
				MessageBox.Show("Cannot connect to the SSH server. {0}".FormatWith(exception.Message), "Cannot Connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			try
			{
			}
			catch (SshException exception)
			{
			}

			// Change the controls enabled state.
			this.OnDisableControls();
			// Change the buttons enabled state.
			this.buttonConnect.Enabled = false;

			// Show a connecting message.
			this.ShowMessage(Resources.ServerBusy_32, "Connecting", "Connecting to the SSH server \'{0}\'".FormatWith(connectionInfo.Host));
			// Update the status bar.
			this.status.Send("Connecting to the SSH server \'{0}\'".FormatWith(connectionInfo.Host), Resources.ServerBusy_16);

			// Connect to the SSH server on the thread pool.
			ThreadPool.QueueUserWorkItem((object state) =>
				{
					try
					{
						lock (this.Sync)
						{
							// Change the client state to connecting.
							this.State = ClientState.Connecting;
						}

						// Connect to the server.
						this.sshClient.Connect();

						lock (this.Sync)
						{
							// Change the client state to connected.
							this.State = ClientState.Connected;

							// Create the client stream.
							//this.sshClient.CreateShellStream("Shell", 160, 160, 
						}

						// Show a success message.
						this.ShowMessage(Resources.ServerSuccess_32, "Connecting Succeeded", "Connecting to the SSH sever \'{0}\' completed successfully.".FormatWith(connectionInfo.Host), false, (int)CrawlerStatic.ConsoleMessageCloseDelay.TotalMilliseconds, (object[] parameters) =>
							{
								// Change the buttons enabled state.
								this.buttonDisconnect.Enabled = true;
								// Update the status bar.
								this.status.Send("Connected to the SSH server \'{0}\'".FormatWith(connectionInfo.Host), Resources.ServerSuccess_16);
								// Enable the console.
								this.OnEnableConsole();
							});
					}
					catch (Exception exception)
					{
						// Change the client state and dispose of the current client.
						lock (this.Sync)
						{
							this.State = ClientState.Disconnected;

							this.sshClient.Dispose();
							this.sshClient = null;
						}
						// Show a success message.
						this.ShowMessage(Resources.ServerError_32, "Connecting Failed", "Connecting to the SSH sever \'{0}\' failed. {1}".FormatWith(connectionInfo.Host, exception.Message), false, (int)CrawlerStatic.ConsoleMessageCloseDelay.TotalMilliseconds, (object[] parameters) =>
							{
								// Change the controls enabled state.
								this.OnEnableControls();
								// Change the buttons enabled state.
								this.buttonConnect.Enabled = true;
								// Update the status bar.
								this.status.Send("Connecting to the SSH server \'{0}\' failed".FormatWith(connectionInfo.Host), Resources.ServerError_16);
							});
					}
				});
		}

		/// <summary>
		/// An event handler called when disconnecting from the SSH server.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnDisconnect(object sender, EventArgs e)
		{
			lock (this.Sync)
			{
				// If the client is not connected, show a message and return.
				if (this.State != ClientState.Connected)
				{
					MessageBox.Show("Cannot disconnect from the SSH server because the client is not connected.", "Cannot Disconnect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				try
				{
					// Disconnect the current client.
					this.sshClient.Disconnect();
				}
				catch (Exception)
				{
				}

				// Call the disconnected event handler.
				this.OnDisconnected();
			}
		}

		/// <summary>
		/// Sets the controls, except the request control buttons, to the disabled state.
		/// </summary>
		private void OnDisableControls()
		{
			// Save the enabled state.
			this.configurationChanged = this.buttonSave.Enabled;

			// Disable the controls.
			this.textBoxServer.Enabled = false;

			this.buttonImport.Enabled = false;
			this.buttonExport.Enabled = false;

			this.buttonSave.Enabled = false;
			this.buttonUndo.Enabled = false;

			this.textBoxUsername.Enabled = false;
			this.radioPasswordAuthentication.Enabled = false;
			this.radioKeyAuthentication.Enabled = false;
			this.labelPassword.Enabled = false;
			this.labelKey.Enabled = false;
			this.secureTextBoxPassword.Enabled = false;
			this.textBoxKey.Enabled = false;
			this.buttonLoadKey.Enabled = false;
		}

		/// <summary>
		/// Sets the controls, except the request control buttons, to the enabled state.
		/// </summary>
		private void OnEnableControls()
		{
			// Enable the controls.
			this.textBoxServer.Enabled = true;

			this.buttonImport.Enabled = true;
			this.buttonExport.Enabled = true;

			this.buttonSave.Enabled = this.configurationChanged;
			this.buttonUndo.Enabled = this.configurationChanged;

			this.textBoxUsername.Enabled = true;
			this.radioPasswordAuthentication.Enabled = true;
			this.radioKeyAuthentication.Enabled = true;
			this.labelPassword.Enabled = this.radioPasswordAuthentication.Checked;
			this.labelKey.Enabled = this.radioKeyAuthentication.Checked;
			this.secureTextBoxPassword.Enabled = this.radioPasswordAuthentication.Checked;
			this.textBoxKey.Enabled = this.radioKeyAuthentication.Checked;
			this.buttonLoadKey.Enabled = this.radioKeyAuthentication.Checked;
		}

		/// <summary>
		/// Enables the console controls.
		/// </summary>
		private void OnEnableConsole()
		{
			lock (this.Sync)
			{
				// If the current client is null, do nothing.
				if (null == this.sshClient) return;
				// If the current client is not connected, do nothing.
				if (!this.sshClient.IsConnected) return;
				// Else, set the console prompt.
				this.labelConsole.Text = "{0}@{1}>".FormatWith(this.sshClient.ConnectionInfo.Username, this.sshClient.ConnectionInfo.Host);
			}

			this.tabControl.SelectedTab = this.tabPageConsole;
			this.textBoxConsole.Enabled = true;
			this.textBoxConsole.Select();
		}

		/// <summary>
		/// Disables the console controls.
		/// </summary>
		private void OnDisableConsole()
		{
			this.textAreaConsole.Clear();
			this.textBoxConsole.Clear();
			this.textBoxConsole.Enabled = false;
			this.labelConsole.Text = ">";
			this.tabControl.SelectedTab = this.tabPageAuthentication;
		}

		/// <summary>
		/// An event handler called when loading the data from a file.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnLoadKey(object sender, EventArgs e)
		{
			// Set the dialog filer.
			this.openFileDialog.Filter = "All files (*.*)|*.*";
			// Open the dialog.
			if (this.openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					// Open the file.
					using (FileStream fileStream = new FileStream(this.openFileDialog.FileName, FileMode.Open))
					{
						// Get the key data.
						this.sshKey = fileStream.ReadToEnd();
						// Set the key data as a string to the text box.
						this.textBoxKey.Text = this.sshKey != null ? Encoding.UTF8.GetString(this.sshKey).Replace("\n", Environment.NewLine) : string.Empty;
					}
				}
				catch (Exception exception)
				{
					// Show an error dialog if an exception is thrown.
					MessageBox.Show("Could not open the RSA key file. {0}".FormatWith(exception.Message), "Cannot Open File", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		/// <summary>
		/// An event handler called when the SSH command has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCommandChanged(object sender, EventArgs e)
		{
			// Update the execution button enabled state.
			this.buttonCommand.Enabled = !string.IsNullOrWhiteSpace(this.textBoxConsole.Text);
		}

		/// <summary>
		/// An event handler called when the user enters an SSH command.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnEnterCommand(object sender, KeyEventArgs e)
		{
			// Process the command only when the enter key is pressed.
			if ((e.KeyCode == Keys.Enter) && (!string.IsNullOrWhiteSpace(this.textBoxConsole.Text)))
			{
				// Execute the command.
				this.OnBeginCommand(sender, e);
			}
		}

		/// <summary>
		/// An event handler called when the user clicks on the execute command button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnExecuteCommand(object sender, EventArgs e)
		{
			lock (this.Sync)
			{
				// If the current command is null.
				if (null == this.sshCommand)
				{
					// Begin the command.
					this.OnBeginCommand(sender, e);
				}
				else
				{
					// Stop the asynchronous command.
					this.sshCommand.CancelAsync();
				}
			}
		}

		/// <summary>
		/// An event handler called when executing an SSH command.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnBeginCommand(object sender, EventArgs e)
		{
			lock (this.Sync)
			{
				// If the current client is null, do nothing.
				if (null == this.sshClient) return;
				// If the current client is not connected, do nothing.
				if (!this.sshClient.IsConnected) return;
				// If the current command is not null, do nothing.
				if (null != this.sshCommand) return;

				// Create a new command for the current text.
				SshCommand command = this.sshClient.CreateCommand(this.textBoxConsole.Text);
				// Set the current command.
				this.sshCommand = command;
				// Delete and disable the command text box.
				this.textBoxConsole.Clear();
				this.textBoxConsole.Enabled = false;
				// Change the execute button image.
				this.buttonCommand.Image = Resources.PlayStop_16;
				this.buttonCommand.Enabled = true;
				// Add the command to the text area.
				this.textAreaConsole.AppendText("{0}@{1}> {2}{3}".FormatWith(
					this.sshClient.ConnectionInfo.Username,
					this.sshClient.ConnectionInfo.Host,
					command.CommandText,
					Environment.NewLine));

				try
				{
					// Execute the command asynchronously.
					IAsyncResult asyncResult = command.BeginExecute(this.OnEndCommand, command);
					// Get the command data.
					ThreadPool.QueueUserWorkItem((object state) =>
						{
							// Create the result arguments.
							object[] args = new object[] { command, null };
							// Read the command data.
							using (StreamReader reader = new StreamReader(command.OutputStream))
							{
								// While the command is not completed.
								while (!asyncResult.IsCompleted)
								{
									// Read all current data in a string.
									string result = reader.ReadToEnd();
									// If the string null or empty, continue.
									if (string.IsNullOrEmpty(result)) continue;
									// Set the current result as a result argument.
									args[1] = result;
									// Invoke the command result event handler.
									this.Invoke(this.delegateCommandResult, args);
								}
							}
						});
				}
				catch (Exception exception)
				{
					// Show the error.
					this.textAreaConsole.AppendText("{0}@{1}> {2}{3}Command failed.{4}".FormatWith(
						this.sshClient.ConnectionInfo.Username,
						this.sshClient.ConnectionInfo.Host,
						command.CommandText,
						Environment.NewLine,
						exception.Message));
				}
			}
		}

		/// <summary>
		/// An callback method called when completing an asynchronous SSH command.
		/// </summary>
		/// <param name="asyncResult">The asynchronous result.</param>
		private void OnEndCommand(IAsyncResult asyncResult)
		{
			// Get the command.
			SshCommand command = asyncResult.AsyncState as SshCommand;
			// Create the result arguments.
			object[] args = new object[] { command, null };

			try
			{
				// End the command execution.
				string result = command.EndExecute(asyncResult);
				// Set the current result as a result argument.
				args[1] = result;
				// Invoke the command result event handler.
				this.Invoke(this.delegateCommandResult, args);
			}
			catch (Exception exception)
			{
				// Set the exception message as a result argument.
				args[1] = "Command failed. {0}".FormatWith(exception.Message);
				// Invoke the command result event handler.
				this.Invoke(this.delegateCommandResult, args);
			}
			// Complete the command.
			this.Invoke(this.delegateCommandComplete, new object[] { command });
		}

		/// <summary>
		/// An event handler called when receving a new result for an SSH command.
		/// </summary>
		/// <param name="command">The command.</param>
		/// <param name="result">The result.</param>
		private void OnCommandResult(SshCommand command, string result)
		{
			// Add the command result.
			lock(this.Sync)
			{
				this.textAreaConsole.AppendText(result);
			}
		}

		/// <summary>
		/// An event handler called when an SSH command completes successfully.
		/// </summary>
		/// <param name="command">The command.</param>
		private void OnCommandComplete(SshCommand command)
		{
			lock (this.Sync)
			{
				this.buttonCommand.Image = Resources.PlayStart_16;
				this.buttonCommand.Enabled = false;
				this.textBoxConsole.Enabled = true;
				this.textBoxConsole.Select();

				// Set the current SSH command to null.
				this.sshCommand = null;
				// Dispose the command.
				command.Dispose();
			}
		}
	}
}
