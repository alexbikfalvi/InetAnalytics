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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YtAnalytics.Controls;
using YtCrawler.Database;
using DotNetApi.Windows;

namespace YtAnalytics.Forms
{
	public delegate void PasswordChangedEventHandler(string oldPassword, string newPassword, object state);

	/// <summary>
	/// A form dialog displaying an exception.
	/// </summary>
	public partial class FormChangePassword : Form
	{
		// UI formatter.
		private Formatting formatting = new Formatting();

		private string oldPassword;
		private object state;

		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormChangePassword()
		{
			InitializeComponent();

			// Set the font.
			this.formatting.SetFont(this);
		}

		// Public events.

		/// <summary>
		/// An event raised when a new comment was added.
		/// </summary>
		public event PasswordChangedEventHandler PasswordChanged;

		// Public methods.

		/// <summary>
		/// Shows the change password dialog with the specified old password and user state.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="oldPassword">The old password.</param>
		/// <param name="state">The user state.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, String oldPassword, object state = null)
		{
			// Save the old password.
			this.oldPassword = oldPassword;
			// Save the user state.
			this.state = state;
			// Clear the control settings.
			this.control.Clear();
			// Select the control.
			this.control.Select();
			// Show the dialog.
			return base.ShowDialog(owner);
		}

		// Private methods.

		/// <summary>
		/// An event handler called when the user clicks on the change button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnChangeClick(object sender, EventArgs e)
		{
			// Check that the old password matches.
			if (this.oldPassword != this.control.Old)
			{
				// Display a warning message to the user.
				MessageBox.Show(
					this,
					"The old password is incorrect.",
					"Cannot Change Password",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return;
			}
			// Check that the new password matched.
			if (this.control.New != this.control.Confirm)
			{
				// Display a warning message to the user.
				MessageBox.Show(
					this,
					"The new and confirmed passwords do not match.",
					"Cannot Change Password",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return;
			}
			// Raise the add event.
			if (this.PasswordChanged != null) this.PasswordChanged(this.control.Old, this.control.New, this.state);
			// Close the dialog.
			this.Close();
		}

		/// <summary>
		/// An event handler called when the user input has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnInputChanged(object sender, EventArgs e)
		{
			this.buttonChange.Enabled =
				(this.control.Old != string.Empty) &&
				(this.control.New != string.Empty) &&
				(this.control.Confirm != string.Empty);
		}
	}
}
