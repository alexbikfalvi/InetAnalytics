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
using YtCrawler.Comments;
using DotNetApi.Windows;

namespace YtAnalytics.Forms
{
	/// <summary>
	/// A form dialog displaying an HTTP header.
	/// </summary>
	public partial class FormHttpHeader : Form
	{
		// UI formatter.
		private Formatting formatting = new Formatting();

		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormHttpHeader()
		{
			InitializeComponent();

			// Set the font.
			this.formatting.SetFont(this);
		}

		/// <summary>
		/// Shows the form as a dialog and the specified HTTP header information.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="header">The HTTP header.</param>
		/// <param name="value">The HTTP header value.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, string header, string value)
		{
			// Set the header information.
			this.control.Header = header;
			this.control.Value = value;
			
			// Open the dialog.
			return base.ShowDialog(owner);
		}
	}
}
