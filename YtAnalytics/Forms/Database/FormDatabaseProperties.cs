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
using YtCrawler.Database;
using YtCrawler.Database.Data;
using DotNetApi;
using DotNetApi.Windows;

namespace YtAnalytics.Forms.Database
{
	/// <summary>
	/// A form dialog displaying a log event.
	/// </summary>
	public partial class FormDatabaseProperties : Form
	{
		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormDatabaseProperties()
		{
			InitializeComponent();

			// Set the font.
			Window.SetFont(this);
		}

		/// <summary>
		/// Shows the form as a dialog and the specified database.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="database">The database.</param>
		/// <param name="isSelected">Indicates if the database is selected.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, DbObjectDatabase database, bool isSelected)
		{
			// If the server is null, do nothing.
			if (null == database) return DialogResult.Abort;

			// Set the server.
			this.control.Database = database;
			this.control.IsSelected = isSelected;
			// Set the title.
			this.Text = "{0} Database Properties".FormatWith(database.Name);
			// Open the dialog.
			return base.ShowDialog(owner);
		}
	}
}
