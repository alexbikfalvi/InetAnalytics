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

		// Private variables.

		private Crawler crawler = null;

		private Mutex mutex = new Mutex();
		private SshClient sshClient = null;
		private ConnectionInfo sshConnectionInfo = null;
		private byte[] sshKey = null;

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

			try
			{
				// Create a new connection info.
				if (this.radioPasswordAuthentication.Checked)
				{
					// Create a password connection info.
					this.sshConnectionInfo = new PasswordConnectionInfo(this.textBoxServer.Text, this.textBoxUsername.Text, this.secureTextBoxPassword.SecureText.ConvertToUnsecureString());
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
							this.sshConnectionInfo = new PrivateKeyConnectionInfo(this.textBoxServer.Text, this.textBoxUsername.Text, keyFile);
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

			// Change the controls state to connecting.
			this.buttonConnect.Enabled = false;
			this.buttonDisconnect.Enabled = false;
			this.tabControl.Enabled = false;

			// Connect to the SSH server on the thread pool.
			//Thre
		}

		/// <summary>
		/// An event handler called when disconnecting from the SSH server.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnDisconnect(object sender, EventArgs e)
		{

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
