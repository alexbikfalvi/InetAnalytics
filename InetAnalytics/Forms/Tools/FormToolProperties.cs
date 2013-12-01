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
using DotNetApi;
using DotNetApi.Windows;
using DotNetApi.Windows.Forms;
using InetCrawler.Tools;

namespace InetAnalytics.Forms.Tools
{
	/// <summary>
	/// A form dialog displaying a tool information.
	/// </summary>
	public partial class FormToolProperties : ThreadSafeForm
	{
		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormToolProperties()
		{
			InitializeComponent();

			// Set the font.
			Window.SetFont(this);
		}

		/// <summary>
		/// Shows the form as a dialog and the specified tool.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="tool">The tool.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, Tool tool)
		{
			// If the tool is null, do nothing.
			if (null == tool) return DialogResult.Abort;

			// Set the tool.
			this.tool.Tool = tool;
			// Set the title.
			this.Text = "{0} Properties".FormatWith(this.tool.Title);
			// Open the dialog.
			return base.ShowDialog(owner);
		}
	}
}
