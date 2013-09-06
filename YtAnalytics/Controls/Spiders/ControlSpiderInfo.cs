﻿/* 
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

namespace YtAnalytics.Controls.Spiders
{
	/// <summary>
	/// A class displaying the list of feeds for the YouTube API version 2.
	/// </summary>
	public partial class ControlSpiderInfo : ThreadSafeControl
	{
		/// <summary>
		/// Creates a new instance of the control.
		/// </summary>
		public ControlSpiderInfo()
		{
			// Initialize component.
			InitializeComponent();

			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;
		}

		// Public events.

		/// <summary>
		/// An event raised when the user selects the standard feeds spider link.
		/// </summary>
		public event EventHandler StandardFeedsClick;

		// Private methods.

		/// <summary>
		/// The event handler for the user selection of the standard feeds spider link.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStandardFeedsClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.StandardFeedsClick) this.StandardFeedsClick(this, e);
		}
	}
}
