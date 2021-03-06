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
	/// A form dialog displaying a database field.
	/// </summary>
	public partial class FormFieldProperties : ThreadSafeForm
	{
		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormFieldProperties()
		{
			// Initialize the component.
			this.InitializeComponent();

			// Set the font.
			Window.SetFont(this);
		}

		/// <summary>
		/// Shows the form as a dialog with the specified database field.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="field">The database field.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, DbField field)
		{
			// Select the server an table.
			this.control.Field = field;
			// Set the dialog name.
			this.Text = "{0} Field Properties".FormatWith(field.DisplayName);
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
	}
}
