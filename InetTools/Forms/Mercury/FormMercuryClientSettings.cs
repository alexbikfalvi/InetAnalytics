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
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;
using DotNetApi.Windows.Forms;
using InetTools.Tools.Mercury;

namespace InetTools.Forms.Mercury
{
	/// <summary>
	/// A form displaying the settings for the Mercury client tool.
	/// </summary>
	public partial class FormMercuryClientSettings : ThreadSafeForm
	{
		private MercuryConfig config = null;

		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormMercuryClientSettings()
		{
			this.InitializeComponent();
		}

		// Public method.

		/// <summary>
		/// Shows the dialog with the specified title and text.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="config">The Mercury client configuration.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, MercuryConfig config)
		{
			// Set the configuration.
			this.config = config;

			// Set the properties.
			this.textBoxSessionUrl.Text = this.config.UploadSessionUrl;
			this.textBoxTracerouteUrl.Text = this.config.UploadTracerouteUrl;
			this.textBoxLocalAddress.Text = this.config.LocalAddress;

			// Reset the buttons.
			this.buttonApply.Enabled = false;

			// Call the base class method.
			return base.ShowDialog(owner);
		}

		// Private methods.

		/// <summary>
		/// An event handler called when the input values has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSettingsChanged(object sender, EventArgs e)
		{
			this.buttonApply.Enabled = true;
		}

		/// <summary>
		/// An event handler called when the user clicks on the OK button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnOkClick(object sender, EventArgs e)
		{
			// If there is no configuration, do nothing.
			if (null == this.config) return;

			// Apply the changes.
			this.OnApplyClick(sender, e);
		}

		/// <summary>
		/// An event handler called when the user clicks on the apply button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnApplyClick(object sender, EventArgs e)
		{
			// Save the changes.
			this.config.UploadSessionUrl = this.textBoxSessionUrl.Text;
			this.config.UploadTracerouteUrl = this.textBoxTracerouteUrl.Text;
			this.config.LocalAddress = this.textBoxLocalAddress.Text;

			// Disable the apply button.
			this.buttonApply.Enabled = false;
		}

		/// <summary>
		/// An event handler called when validating the local address.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnValidateLocalAddress(object sender, CancelEventArgs e)
		{
			// Validate the local IP address.
			IPAddress address;
			if (!IPAddress.TryParse(this.textBoxLocalAddress.Text, out address))
			{
				// If the IP address is not valid, show an error message.
				MessageBox.Show(this, "The local address is not a valid Internet Protocol address.", "Invalid Address", MessageBoxButtons.OK, MessageBoxIcon.Error);
				// Cancel the change.
				e.Cancel = true;
			}
		}
	}
}
