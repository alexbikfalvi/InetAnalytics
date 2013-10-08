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

namespace YtAnalytics.Forms
{
	/// <summary>
	/// A form displaying a text dialog.
	/// </summary>
	public partial class FormText : Form
	{
		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormText()
		{
			this.InitializeComponent();
		}

		// Public method.

		/// <summary>
		/// Shows the dialog with the specified title and text.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="title">The title.</param>
		/// <param name="text">The text.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, string title, string text)
		{
			// Set the title.
			this.Text = title;
			// Set the text.
			this.textBox.Text = text;
			// Call the base class method.
			return base.ShowDialog(owner);
		}

		// Private methods.

		/// <summary>
		/// An event handler called when the user clicks the close button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnClose(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
