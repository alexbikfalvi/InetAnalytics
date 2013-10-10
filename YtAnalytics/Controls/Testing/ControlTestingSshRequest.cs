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
using System.Drawing;
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
		private static readonly string logSource = "Secure Shell";

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

		/// <summary>
		/// An event handler called when connecting to an SSH server.
		/// </summary>
		/// <param name="info">The connection info.</param>
		protected override void OnConnecting(ConnectionInfo info)
		{
			// Change the controls enabled state.
			this.OnDisableControls();
			// Change the buttons enabled state.
			this.buttonConnect.Enabled = false;
			// Update the status bar.
			this.status.Send("Connecting to the SSH server \'{0}\'".FormatWith(info.Host), Resources.ServerBusy_16);
			// Log
			this.log.Add(this.crawler.Log.Add(
				LogEventLevel.Verbose,
				LogEventType.Information,
				ControlTestingSshRequest.logSource,
				"Connecting to the SSH server \'{0}\'.",
				new object[] { info.Host }));
		}

		/// <summary>
		/// An event handler called when connecting to an SSH server succeeded.
		/// </summary>
		/// <param name="info">The connection info.</param>
		protected override void OnConnectSucceeded(ConnectionInfo info)
		{
			// Change the buttons enabled state.
			this.buttonDisconnect.Enabled = true;
			// Update the status bar.
			this.status.Send("Connected to the SSH server \'{0}\'".FormatWith(info.Host), Resources.ServerSuccess_16);
			// Enable the console.
			this.OnEnableConsole();
			// Log
			this.log.Add(this.crawler.Log.Add(
				LogEventLevel.Verbose,
				LogEventType.Success,
				ControlTestingSshRequest.logSource,
				"Connected to the SSH server \'{0}\'.",
				new object[] { info.Host }));
		}

		/// <summary>
		/// An event handler called when connecting to an SSH server failed.
		/// </summary>
		/// <param name="info">The connection info.</param>
		/// <param name="exception">The exception.</param>
		protected override void OnConnectFailed(ConnectionInfo info, Exception exception)
		{
			// Change the controls enabled state.
			this.OnEnableControls();
			// Change the buttons enabled state.
			this.buttonConnect.Enabled = true;
			// Update the status bar.
			this.status.Send("Connecting to the SSH server \'{0}\' failed".FormatWith(info.Host), Resources.ServerError_16);
			// Log
			this.log.Add(this.crawler.Log.Add(
				LogEventLevel.Verbose,
				LogEventType.Error,
				ControlTestingSshRequest.logSource,
				"Connecting to the SSH server \'{0}\' failed.",
				new object[] { info.Host }));
		}

		/// <summary>
		/// An event handler called when disconnecting from an SSH server.
		/// </summary>
		/// <param name="info">The connection info.</param>
		protected override void OnDisconnecting(ConnectionInfo info)
		{
			// Change the buttons enabled state.
			this.buttonDisconnect.Enabled = false;
			// Update the status bar.
			this.status.Send("Disconnecting from the SSH server \'{0}\'".FormatWith(info.Host), Resources.ServerBusy_16);
			// Log
			this.log.Add(this.crawler.Log.Add(
				LogEventLevel.Verbose,
				LogEventType.Information,
				ControlTestingSshRequest.logSource,
				"Disconnecting from the SSH server \'{0}\'.",
				new object[] { info.Host }));
		}

		/// <summary>
		/// An event handler called when disconnected from an SSH server.
		/// </summary>
		/// <param name="info">The connection info.</param>
		protected override void OnDisconnected(ConnectionInfo info)
		{
			// Update the status bar.
			this.status.Send("Disconnected.", Resources.Server_16);
			// Log
			this.log.Add(this.crawler.Log.Add(
				LogEventLevel.Verbose,
				LogEventType.Success,
				ControlTestingSshRequest.logSource,
				"Disconnected from the SSH server \'{0}\'.",
				new object[] { info.Host }));

			// Change the controls enabled state.
			this.OnEnableControls();
			// Change the buttons enabled state.
			this.buttonConnect.Enabled = true;

			// Disable the console.
			this.OnDisableConsole();
		}

		/// <summary>
		/// An event handler called when an error occurres on an SSH server connection.
		/// </summary>
		/// <param name="info">The connection info.</param>
		/// <param name="exception">The error exception.</param>
		protected override void OnErrorOccurred(ConnectionInfo info, Exception exception)
		{
			// Log
			this.log.Add(this.crawler.Log.Add(
				LogEventLevel.Important,
				LogEventType.Error,
				ControlTestingSshRequest.logSource,
				"The client connected to the SSH server \'{0}\' received an error. {1}",
				new object[] { info.Host, exception.Message }));
		}

		/// <summary>
		/// An event handler called when receiving a key from the remote host.
		/// </summary>
		/// <param name="info">The connection info.</param>
		/// <param name="args">The event arguments.</param>
		protected override void OnHostKeyReceived(ConnectionInfo info, HostKeyEventArgs args)
		{
			// Log
			this.log.Add(this.crawler.Log.Add(
				LogEventLevel.Verbose,
				LogEventType.Information,
				ControlTestingSshRequest.logSource,
				"The client connected to the SSH server \'{0}\' received key \'{1}\' of {2} bits. Key: {3}. Fingerprint: {4}.",
				new object[] { info.Host, args.HostKeyName, args.KeyLength, args.HostKey, args.FingerPrint }));
		}

		/// <summary>
		/// An event handler called when the client begins executing a command.
		/// </summary>
		/// <param name="command">The command.</param>
		protected override void OnCommandBegin(SshCommand command)
		{
			// Begin the command.
			this.console.BeginCommand(command.CommandText);
		}

		/// <summary>
		/// An event handler called when the client receives data for an executing command.
		/// </summary>
		/// <param name="command">The command.</param>
		/// <param name="data">The received data.</param>
		protected override void OnCommandData(SshCommand command, string data)
		{
			// Set the exception message as a result argument.
			this.console.AppendText(data, Color.LightGray);
		}

		/// <summary>
		/// An event handler called when a client command completed successfully.
		/// </summary>
		/// <param name="command">The command.</param>
		/// <param name="result">The result.</param>
		protected override void OnCommandSucceeded(SshCommand command, string result)
		{
			// Set the exception message as a result argument.
			this.console.AppendText(result, Color.LightGray);
			this.console.AppendText("SUCCESS", Color.Lime);
			this.console.AppendText(" Code: {0}.{1}", command.ExitStatus, Environment.NewLine);
			// Call the command complete event handler.
			this.console.EndCommand();
		}

		/// <summary>
		/// An event handler called when a client command has failed.
		/// </summary>
		/// <param name="command">The command.</param>
		/// <param name="error">The error.</param>
		protected override void OnCommandFailed(SshCommand command, string error)
		{
			// Set the exception message as a result argument.
			if (!string.IsNullOrWhiteSpace(error))
			{
				this.console.AppendText(error, Color.LightGray);
			} 
			this.console.AppendText("FAIL", Color.Red);
			this.console.AppendText(" Code: {0}.", command.ExitStatus);
			this.console.AppendText(Environment.NewLine);
			// Call the command complete event handler.
			this.console.EndCommand();
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
			this.tabControl.SelectedTab = this.tabPageConsole;
			this.console.Enable("{0}@{1}>".FormatWith(this.Info.Username, this.Info.Host));
		}

		/// <summary>
		/// Disables the console controls.
		/// </summary>
		private void OnDisableConsole()
		{
			this.console.Disable();
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
				// If the number of executing commands is greater than zero, do nothing.
				if (this.Commands.Count > 0) return;
			}
			finally
			{
				this.Commands.Unlock();
			}

			// Else, get the command text.
			string text = this.console.Command;
			try
			{
				// Begin the command.
				this.BeginCommand(text);
			}
			catch (Exception exception)
			{
				// If the client has not disconnected.
				if (this.Info != null)
				{
					// Show the error.
					this.console.AppendText("{0}@{1}> {2}{3}Command failed.{4}",
						this.Info.Username,
						this.Info.Host,
						text,
						Environment.NewLine,
						exception.Message);
				}
			}
		}

		/// <summary>
		/// An event handler called when the user cancels a command.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCancelCommand(object sender, EventArgs e)
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
				}
			}
			finally
			{
				this.Commands.Unlock();
			}
		}
	}
}
