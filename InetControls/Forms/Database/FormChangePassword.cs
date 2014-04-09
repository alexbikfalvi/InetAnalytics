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
using System.Security;
using System.Windows.Forms;
using InetCommon.Database;
using InetControls.Controls;
using InetControls.Events;
using DotNetApi.Security;
using DotNetApi.Windows;
using DotNetApi.Windows.Forms;

namespace InetControls.Forms.Database
{
	/// <summary>
	/// A form dialog displaying a dialog allowing the user to change the database password.
	/// </summary>
	public partial class FormChangePassword : ThreadSafeForm
	{
		private SecureString oldPassword;
		private object state;

		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormChangePassword()
		{
			// Initialize the component.
			this.InitializeComponent();

			// Set the font.
			Window.SetFont(this);
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
		public DialogResult ShowDialog(IWin32Window owner, SecureString oldPassword, object state = null)
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
		/// Shows the form.
		/// </summary>
		private new void Show()
		{
			base.Show();
		}

		/// <summary>
		/// Shows the form.
		/// </summary>
		/// <param name="owner">The owner.</param>
		private new void Show(IWin32Window owner)
		{
			base.Show(owner);
		}

		/// <summary>
		/// Shows the dialog.
		/// </summary>
		/// <returns>The dialog result.</returns>
		private new DialogResult ShowDialog()
		{
			return base.ShowDialog();
		}

		/// <summary>
		/// Shows the dialog.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <returns>The dialog result.</returns>
		private new DialogResult ShowDialog(IWin32Window owner)
		{
			return base.ShowDialog(owner);
		}

		/// <summary>
		/// An event handler called when the user clicks on the change button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnChangeClick(object sender, EventArgs e)
		{
			// Check that the old password matches.
			if (!this.oldPassword.IsEqual(this.control.Old))
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
			if (!this.control.New.IsEqual(this.control.Confirm))
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
			if (this.PasswordChanged != null) this.PasswordChanged(this, new PasswordChangedEventArgs(this.control.Old, this.control.New, this.state));
			// Set the dialog result.
			this.DialogResult = DialogResult.OK;
		}

		/// <summary>
		/// An event handler called when the user input has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnInputChanged(object sender, EventArgs e)
		{
			this.buttonChange.Enabled =
				(!this.control.Old.IsEmpty()) &&
				(!this.control.New.IsEmpty()) &&
				(!this.control.Confirm.IsEmpty());
		}
	}
}
