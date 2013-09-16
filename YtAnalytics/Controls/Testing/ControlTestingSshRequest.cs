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
using System.Linq;
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
		private static string logSource = "Testing Secure Shell";

		// Private variables.

		private Crawler crawler = null;
		private StatusHandler status = null;

		private byte[] sshKey = null;
		
		private bool configurationChanged = false;

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
			// Change the controls enabled state.
			this.OnDisableControls();
			// Change the buttons enabled state.
			this.buttonConnect.Enabled = false;
			// Update the status bar.
			this.status.Send("Connecting to the SSH server \'{0}\'".FormatWith(this.Info.Host), Resources.ServerBusy_16);
		}

		protected override void OnConnectSucceeded()
		{
			// Change the buttons enabled state.
			this.buttonDisconnect.Enabled = true;
			// Update the status bar.
			this.status.Send("Connected to the SSH server \'{0}\'".FormatWith(this.Info.Host), Resources.ServerSuccess_16);
			// Enable the console.
			this.OnEnableConsole();
		}

		protected override void OnConnectFailed(Exception exception)
		{
			// Change the controls enabled state.
			this.OnEnableControls();
			// Change the buttons enabled state.
			this.buttonConnect.Enabled = true;
			// Update the status bar.
			this.status.Send("Connecting to the SSH server \'{0}\' failed".FormatWith(this.Info.Host), Resources.ServerError_16);
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

		/// <summary>
		/// An event handler called when an error occurred on an SSH connection.
		/// </summary>
		/// <param name="exception">The exception.</param>
		protected override void OnErrorOccurred(Exception exception)
		{
		}

		/// <summary>
		/// An event handler called when receiving the key from the remote host on a given SSH connection.
		/// </summary>
		/// <param name="args">The arguuments.</param>
		protected override void OnHostKeyReceived(HostKeyEventArgs args)
		{
		}

		/// <summary>
		/// An event handler called when the client begins executing a command.
		/// </summary>
		/// <param name="command">The command.</param>
		protected override void OnCommandBegin(SshCommand command)
		{
			// Delete and disable the command text box.
			this.textBoxConsole.Clear();
			this.textBoxConsole.Enabled = false;
			// Change the execute button image.
			this.buttonCommand.Image = Resources.PlayStop_16;
			this.buttonCommand.Enabled = true;
			// Add the command to the text area.
			this.textAreaConsole.AppendText("{0}@{1}> {2}{3}".FormatWith(this.Info.Username, this.Info.Host, command.CommandText, Environment.NewLine));
		}

		/// <summary>
		/// An event handler called when the client receives data for an executing command.
		/// </summary>
		/// <param name="command">The command.</param>
		/// <param name="data">The received data.</param>
		protected override void OnCommandData(SshCommand command, string data)
		{
			// Set the exception message as a result argument.
			this.textAreaConsole.AppendText(data);
		}

		/// <summary>
		/// An event handler called when a client command completed successfully.
		/// </summary>
		/// <param name="command">The command.</param>
		/// <param name="result">The result.</param>
		protected override void OnCommandSucceeded(SshCommand command, string result)
		{
			// Set the exception message as a result argument.
			this.textAreaConsole.AppendText("{0}{1}Command succeeded with code {2}.{3}".FormatWith(result, Environment.NewLine, command.ExitStatus, Environment.NewLine));
			// Call the command complete event handler.
			this.OnCommandComplete();
		}

		/// <summary>
		/// An event handler called when a client command has failed.
		/// </summary>
		/// <param name="command">The command.</param>
		/// <param name="exception">The exception.</param>
		protected override void OnCommandFailed(SshCommand command, Exception exception)
		{
			// Set the exception message as a result argument.
			this.textAreaConsole.AppendText("Command failed with code {0}. {1}{2}".FormatWith(command.ExitStatus, exception.Message, Environment.NewLine));
			// Call the command complete event handler.
			this.OnCommandComplete();
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
					// Create a password connection info.
					connectionInfo = new PasswordConnectionInfo(this.textBoxServer.Text, this.textBoxUsername.Text, this.secureTextBoxPassword.SecureText.ConvertToUnsecureString());
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
							// Create a key connection info.
							connectionInfo = new PrivateKeyConnectionInfo(this.textBoxServer.Text, this.textBoxUsername.Text, keyFile);
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
				// Connect to the SSH server.
				this.Connect(connectionInfo);
			}
			catch (SshException exception)
			{
				// Show an error dialog if an exception is thrown.
				MessageBox.Show("Cannot connect to the SSH server. {0}".FormatWith(exception.Message), "Cannot Connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}

		/// <summary>
		/// An event handler called when disconnecting from the SSH server.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnDisconnect(object sender, EventArgs e)
		{
			try
			{
				// Disconnect from the SSH server.
				this.Disconnect();
			}
			catch (SshException exception)
			{
				// Show an error dialog if an exception is thrown.
				MessageBox.Show("An error occurred while disconnecting from the SSH server. {0}".FormatWith(exception.Message), "Disconnect Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
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
			// Set the prompt.
			this.labelConsole.Text = "{0}@{1}>".FormatWith(this.Info.Username, this.Info.Host);
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
			// Lock the list of commands.
			this.Commands.Lock();
			try
			{
				// If the number of executing commands is greater than zero.
				if (this.Commands.Count > 0)
				{
					// Cancel the first command.
					this.Commands.First().CancelAsync();
					// Return.
					return;
				}
			}
			finally
			{
				this.Commands.Unlock();
			}

			// Else, begin a new command.
			this.OnBeginCommand(sender, e);
		}

		/// <summary>
		/// An event handler called when executing an SSH command.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnBeginCommand(object sender, EventArgs e)
		{
			// Get the command text.
			string text = this.textBoxConsole.Text;
			try
			{
				// Begin the command.
				this.BeginCommand(text);
			}
			catch (Exception exception)
			{
				// Show the error.
				this.textAreaConsole.AppendText("{0}@{1}> {2}{3}Command failed.{4}".FormatWith(
					this.Info.Username,
					this.Info.Host,
					text,
					Environment.NewLine,
					exception.Message));
			}
		}

		/// <summary>
		/// An event handler called when an SSH command completes.
		/// </summary>
		private void OnCommandComplete()
		{
			this.buttonCommand.Image = Resources.PlayStart_16;
			this.buttonCommand.Enabled = false;
			this.textBoxConsole.Enabled = true;
			this.textBoxConsole.Select();
		}
	}
}
