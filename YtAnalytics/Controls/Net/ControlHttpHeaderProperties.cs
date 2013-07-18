/* 
 * Copyright (C) 2012 Alex Bikfalvi
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
using DotNetApi.Web.Http;
using DotNetApi.Windows.Controls;

namespace YtAnalytics.Controls.Net
{
	/// <summary>
	/// Displays the information of an HTTP header.
	/// </summary>
	public partial class ControlHttpHeader : ThreadSafeControl
	{
		private HttpHeader header;

		/// <summary>
		/// Creates a new HTTP header control instance.
		/// </summary>
		public ControlHttpHeader()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Gets or sets the HTTP header information.
		/// </summary>
		public HttpHeader Header
		{
			get { return this.header; }
			set
			{
				// Save the old header value.
				HttpHeader old = this.header;
				// Set the new header value.
				this.header = value;
				// Call the event handler.
				this.OnHeaderSet(old, value);
			}
		}

		// Protected methods.

		/// <summary>
		/// An event handler called when a new header has been set.
		/// </summary>
		/// <param name="oldHeader">The old header.</param>
		/// <param name="newHeader">The new header.</param>
		protected virtual void OnHeaderSet(HttpHeader oldHeader, HttpHeader newHeader)
		{
			// If the old and new headers are equal, do nothing.
			if (oldHeader == newHeader) return;

			this.labelHeader.Text = this.header.Name;
			this.textBoxValue.Text = this.header.Value;

			this.tabControl.SelectedTab = this.tabPageValue;
			if (this.Focused)
			{
				this.textBoxValue.Select();
				this.textBoxValue.SelectionStart = 0;
				this.textBoxValue.SelectionLength = 0;
			}
		}
	}
}
