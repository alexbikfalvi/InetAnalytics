﻿/* 
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
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Windows;
using DotNetApi.Windows.Forms;
using InetCommon.Database;

namespace InetAnalytics.Forms.Database
{
	/// <summary>
	/// A form dialog displaying a log event.
	/// </summary>
	public partial class FormRelationshipProperties : ThreadSafeForm
	{
		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormRelationshipProperties()
		{
			// Initialize the component.
			this.InitializeComponent();

			// Set the font.
			Window.SetFont(this);
		}

		/// <summary>
		/// Shows the form as a dialog with the specified database table.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="server">The database server.</param>
		/// <param name="table">The database relationship.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, DbServerSql server, IRelationship relationship)
		{
			// If the table is null, do nothing.
			if (null == relationship) return DialogResult.Abort;
			// Set the control relationsip.
			this.control.Relationship = relationship;
			// Set the form title.
			this.Text = "{0} Relationship Properties".FormatWith(this.control.Title);
			// Disable the apply button.
			this.buttonApply.Enabled = false;
			// Open the dialog.
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
		/// An event handler called when the configuration has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnConfigurationChanged(object sender, EventArgs e)
		{
			this.buttonApply.Enabled = true;
		}

		/// <summary>
		/// An event handler called when the user clicks on the OK button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnOk(object sender, EventArgs e)
		{
			// Save the configuration and exit.
			this.OnApply(sender, e);
		}

		/// <summary>
		/// An event handler called when the user clicks on the Apply button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnApply(object sender, EventArgs e)
		{
			// Save the configuration and disable the button.
			this.buttonApply.Enabled = false;
		}
	}
}
