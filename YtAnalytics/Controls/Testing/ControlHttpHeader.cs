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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetApi.Windows.Controls;

namespace YtAnalytics.Testing
{
	/// <summary>
	/// Displays the information of an HTTP header.
	/// </summary>
	public partial class ControlHttpHeader : ThreadSafeControl
	{

		/// <summary>
		/// Creates a new HTTP header control instance.
		/// </summary>
		public ControlHttpHeader()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Gets or sets the HTTP header.
		/// </summary>
		public string Header
		{
			get { return this.labelHeader.Text; }
			set { this.labelHeader.Text = value; }
		}

		/// <summary>
		/// Gets or sets the HTTP header value.
		/// </summary>
		public string Value
		{
			get { return this.textBoxValue.Text; }
			set { this.textBoxValue.Text = value; }
		}
	}
}
