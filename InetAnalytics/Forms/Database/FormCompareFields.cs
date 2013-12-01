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
using InetAnalytics.Controls;
using InetCrawler.Database;
using DotNetApi.Windows;
using DotNetApi.Windows.Forms;

namespace InetAnalytics.Forms.Database
{
	/// <summary>
	/// A form dialog compare a table field with database information.
	/// </summary>
	public partial class FormCompareFields : ThreadSafeForm
	{
		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormCompareFields()
		{
			InitializeComponent();

			// Set the font.
			Window.SetFont(this);
		}

		/// <summary>
		/// Opens the dialog and compares a database field with the information received from a database server.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="field">The database field.</param>
		/// <param name="name">The field name.</param>
		/// <param name="type">The field type.</param>
		/// <param name="length">The field length.</param>
		/// <param name="precision">The field precision.</param>
		/// <param name="scale">The field scale.</param>
		/// <param name="nullable">The field is nullable.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(
			IWin32Window owner,
			DbField field,
			string name,
			string type,
			int length,
			int precision,
			int scale,
			bool? nullable)
		{
			// Set the control.
			this.control.Compare(field, name, type, length, precision, scale, nullable);
			// Open the dialog.
			return base.ShowDialog(owner);
		}
	}
}
