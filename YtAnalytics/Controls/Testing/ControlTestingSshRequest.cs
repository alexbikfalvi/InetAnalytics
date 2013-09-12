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
using DotNetApi.Windows.Controls;
using YtCrawler;
using YtCrawler.Log;
using YtCrawler.Testing;
using Renci.SshNet;

namespace YtAnalytics.Controls.Testing
{
	/// <summary>
	/// A control class for testing secure shell.
	/// </summary>
	public partial class ControlTestingSshRequest : NotificationControl
	{
		private static string logSource = "Testing Secure Shell";

		// Connection state.
		private enum State
		{
			Disconnected = 0,
			Connecting = 1,
			Connected = 2,
			Disconnecting = 3
		}

		// Private variables.

		private Crawler crawler = null;

		private readonly object sshSync = new object();
		private State sshState = State.Disconnected;
		private SshClient sshClient = null;
		private ConnectionInfo sshConnectionInfo = null;
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

			// Enable the control.
			this.Enabled = true;

			// Load the settings.
			this.OnLoad();
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

			// If the client is not disconnected, show a message and return.
			lock (this.sshSync)
			{
				if (this.sshState != State.Disconnected)
				{
					MessageBox.Show("Cannot connect to the SSH server because the client is not disconnected.", "Cannot Connect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
			}

			try
			{
				// Create a new connection info.
				if (this.radioPasswordAuthentication.Checked)
				{
					lock (this.sshSync)
					{
						// Create a password connection info.
						this.sshConnectionInfo = new PasswordConnectionInfo(this.textBoxServer.Text, this.textBoxUsername.Text, this.secureTextBoxPassword.SecureText.ConvertToUnsecureString());
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
							lock (this.sshSync)
							{
								// Create a key connection info.
								this.sshConnectionInfo = new PrivateKeyConnectionInfo(this.textBoxServer.Text, this.textBoxUsername.Text, keyFile);
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

				lock (this.sshSync)
				{
					// Create the SSH client.
					this.sshClient = new SshClient(this.sshConnectionInfo);
				}
			}
			catch (Exception exception)
			{
				// Show an error dialog if an exception is thrown.
				MessageBox.Show("Cannot connect to the SSH server. {0}".FormatWith(exception.Message), "Cannot Connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Change the controls enabled state.
			this.OnDisableControls();
			// Change the buttons enabled state.
			this.buttonConnect.Enabled = false;

			// Show a connecting message.
			this.ShowMessage(Resources.ServerBusy_32, "Connecting", "Connecting to the SSH server \'{0}\'".FormatWith(this.sshConnectionInfo.Host));

			// Connect to the SSH server on the thread pool.
			ThreadPool.QueueUserWorkItem((object state) =>
				{
					try
					{
						// Change the client state.
						lock (this.sshSync)
						{
							this.sshState = State.Connecting;
						}

						// Connect to the server.
						this.sshClient.Connect();

						// Change the client state.
						lock (this.sshSync)
						{
							this.sshState = State.Connected;
						}

						// Show a success message.
						this.ShowMessage(Resources.ServerSuccess_32, "Connecting Succeeded", "Connecting to the SSH sever \'{0}\' completed successfully.".FormatWith(this.sshConnectionInfo.Host), false, (int)CrawlerStatic.ConsoleMessageCloseDelay.TotalMilliseconds, (object[] parameters) =>
							{
								// Change the buttons enabled state.
								this.buttonDisconnect.Enabled = true;
							});
					}
					catch (Exception exception)
					{
						// Change the client state and dispose of the current client.
						lock (this.sshSync)
						{
							this.sshState = State.Disconnected;

							this.sshClient.Dispose();
							this.sshClient = null;
						}
						// Show a success message.
						this.ShowMessage(Resources.ServerError_32, "Connecting Failed", "Connecting to the SSH sever \'{0}\' failed. {1}".FormatWith(this.sshConnectionInfo.Host, exception.Message), false, (int)CrawlerStatic.ConsoleMessageCloseDelay.TotalMilliseconds, (object[] parameters) =>
							{
								// Change the controls enabled state.
								this.OnEnableControls();
								// Change the buttons enabled state.
								this.buttonConnect.Enabled = true;
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
			lock (this.sshSync)
			{
				// If the client is not connected, show a message and return.
				if (this.sshState != State.Connected)
				{
					MessageBox.Show("Cannot disconnect from the SSH server because the client is not connected.", "Cannot Disconnect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				// Disconnect the current client.
				this.sshClient.Disconnect();

				// Change the controls enabled state.
				this.OnEnableControls();
				// Change the buttons enabled state.
				this.buttonConnect.Enabled = true;
				this.buttonDisconnect.Enabled = false;
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

			this.tabControl.Enabled = false;
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

			this.tabControl.Enabled = true;
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
	}
}
