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
using System.Net;
using System.Windows.Forms;
using DotNetApi.Windows;
using DotNetApi.Windows.Forms;

namespace InetCommon.Forms.Net
{
	/// <summary>
	/// A form dialog to add an HTTP header.
	/// </summary>
	public partial class FormHttpAddRequestHeader : ThreadSafeForm
	{
		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormHttpAddRequestHeader()
		{
			// Initialize the component.
			this.InitializeComponent();

			// Set the font.
			Window.SetFont(this);
		}

		// Public properties.

		/// <summary>
		/// Gets the HTTP request header.
		/// </summary>
		public string Header { get { return this.control.Header; } }
		/// <summary>
		/// Gets the header value.
		/// </summary>
		public string Value { get { return this.control.Value; } }

		// Public methods.

		/// <summary>
		/// Shows the add HTTP request header dialog.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <returns>The dialog result.</returns>
		public new DialogResult ShowDialog(IWin32Window owner)
		{
			this.Text = "Add HTTP Request Header";
			this.buttonAdd.Text = "&Add";
			this.control.Caption = "Add HTTP request header";
			this.control.Header = string.Empty;
			this.control.Value = string.Empty;
			this.control.HeaderEnabled = true;
			this.control.Select();
			return base.ShowDialog(owner);
		}

		/// <summary>
		/// Shows the change HTTP request header dialog.
		/// </summary>
		/// <param name="header">The HTTP header.</param>
		/// <param name="value">The header value.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, string header, string value)
		{
			this.Text = "Change HTTP Request Header";
			this.buttonAdd.Text = "Ch&ange";
			this.control.Caption = "Change HTTP request header";
			this.control.Header = header;
			this.control.Value = value;
			this.control.HeaderEnabled = false;
			this.control.Select();
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
		/// An event handler called when the user input has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnInputChanged(object sender, EventArgs e)
		{
			this.buttonAdd.Enabled = 
				!string.IsNullOrWhiteSpace(this.control.Header) &&
				!string.IsNullOrWhiteSpace(this.control.Value);
		}
	}
}
