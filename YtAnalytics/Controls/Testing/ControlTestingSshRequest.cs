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
using DotNetApi.Security;
using DotNetApi.Windows.Controls;
using YtCrawler;
using YtCrawler.Log;

namespace YtAnalytics.Controls.Testing
{
	/// <summary>
	/// A control class for testing secure shell.
	/// </summary>
	public partial class ControlTestingSshRequest : ThreadSafeControl
	{
		private static string logSource = "Testing Secure Shell";

		// Private variables.

		private Crawler crawler = null;

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
			this.textBoxServer.Text = this.crawler.Testing.SshRequest.Server;
			this.textBoxUsername.Text = this.crawler.Testing.SshRequest.Username;
			this.secureTextBoxPassword.SecureText = this.crawler.Testing.SshRequest.Password;
			this.textBoxKey.Text = this.crawler.Testing.SshRequest.Key.ConvertToUnsecureString();
			
			this.radioPasswordAuthentication.Checked = this.crawler.Testing.SshRequest.AuthenticationPassword;
			this.radioKeyAuthentication.Checked = this.crawler.Testing.SshRequest.AuthenticationKey;
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
			this.crawler.Testing.SshRequest.Key = this.textBoxKey.Text.ConvertToSecureString();

			this.crawler.Testing.SshRequest.AuthenticationPassword = this.radioPasswordAuthentication.Checked;
			this.crawler.Testing.SshRequest.AuthenticationKey = this.radioKeyAuthentication.Checked;

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
			this.buttonConnect.Enabled = !string.IsNullOrEmpty(this.textBoxServer.Text);
		}

		/// <summary>
		/// An event handler called when connecting to the SSH server.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnConnect(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// An event handler called when disconnecting from the SSH server.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnDisconnect(object sender, EventArgs e)
		{

		}
	}
}
