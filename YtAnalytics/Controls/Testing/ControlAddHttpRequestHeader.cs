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
using System.Collections;
using System.Net;
using System.Windows.Forms;
using DotNetApi.Web;
using DotNetApi.Windows.Controls;

namespace YtAnalytics.Controls.Testing
{
	/// <summary>
	/// A control that receives user input to add an HTTP request header.
	/// </summary>
	public partial class ControlAddHttpRequestHeader : ThreadSafeControl
	{
		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlAddHttpRequestHeader()
		{
			// Initialize the component.
			InitializeComponent();

			// Add the headers to the combo box.
			foreach (DictionaryEntry header in HttpUtils.RequestHeaders)
			{
				this.comboBoxHeader.Items.Add(header.Value as string);
			}
		}

		// Public events.

		/// <summary>
		/// An event raised when the input has changed.
		/// </summary>
		public event EventHandler InputChanged;

		// Public properties.

		/// <summary>
		/// Gets or sets the control caption.
		/// </summary>
		public string Caption
		{
			get { return this.labelCaption.Text; }
			set { this.labelCaption.Text = value; }
		}

		/// <summary>
		/// Gets or sets the HTTP request header.
		/// </summary>
		public string Header
		{
			get { return this.comboBoxHeader.Text; }
			set
			{
				// Reset the selected index.
				this.comboBoxHeader.SelectedIndex = -1;
				// Set the text value.
				this.comboBoxHeader.Text = value;
			}
		}

		/// <summary>
		/// Gets or sets the HTTP request header value.
		/// </summary>
		public string Value
		{
			get { return this.textBoxValue.Text; }
			set { this.textBoxValue.Text = value; }
		}

		/// <summary>
		/// Gets or sets whether the HTTP request header field is enabled.
		/// </summary>
		public bool HeaderEnabled
		{
			get { return this.comboBoxHeader.Enabled; }
			set { this.comboBoxHeader.Enabled = value; }
		}

		// Public methods.

		/// <summary>
		/// Selects the current control.
		/// </summary>
		public new void Select()
		{
			base.Select();
			this.comboBoxHeader.Select();
		}

		/// <summary>
		/// An event handler called when the input has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnInputChanged(object sender, EventArgs e)
		{
			if (this.InputChanged != null) this.InputChanged(sender, e);
		}
	}
}
