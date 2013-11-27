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
using InetTools.Tools.CdnFinder;

namespace InetTools.Forms
{
	/// <summary>
	/// A form displaying a settings for the CDN Finder tool.
	/// </summary>
	public partial class FormCdnFinderSettings : Form
	{
		private CdnFinderConfig config = null;

		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormCdnFinderSettings()
		{
			this.InitializeComponent();
		}

		// Public method.

		/// <summary>
		/// Shows the dialog with the specified title and text.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="config">The CDN Finder configuration.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, CdnFinderConfig config)
		{
			// Set the properties.
			this.numericUpDownTimeout.Value = config.Timeout;

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

			// Save the changes.
			this.config.Timeout = (int)this.numericUpDownTimeout.Value;
		}
	}
}
