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
using System.Windows.Forms;
using YtCrawler.Database.Data;
using DotNetApi;
using DotNetApi.Windows;

namespace YtAnalytics.Forms.Database
{
	/// <summary>
	/// A form dialog displaying a database object.
	/// </summary>
	public partial class FormObjectProperties : Form
	{
		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormObjectProperties()
		{
			InitializeComponent();

			// Set the font.
			Window.SetFont(this);
		}

		/// <summary>
		/// Shows the form as a dialog with the specified object.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="obj">The database object to display.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, DbObject obj)
		{
			// Select the server an table.
			this.control.Object = obj;
			// Set the dialog name.
			this.Text = "{0} Object Properties".FormatWith(obj.GetName());
			// Open the dialog.
			return base.ShowDialog(owner);
		}
	}
}
