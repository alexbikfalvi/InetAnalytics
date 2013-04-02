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

namespace YtAnalytics.Controls.YouTube.Api2
{
	/// <summary>
	/// A control that displays the feed types available in the YouTube API version 2.
	/// </summary>
	public partial class ControlYtApi2Info : ThreadSafeControl
	{
		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlYtApi2Info()
		{
			// Initialize component.
			InitializeComponent();
			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;
		}

		/// <summary>
		/// An event raised when the user selects the global videos.
		/// </summary>
		public event EventHandler VideosGlobalClick;
		/// <summary>
		/// An event raised when the user selects the per user videos.
		/// </summary>
		public event EventHandler VideosUserClick;
		/// <summary>
		/// An event raised when the user selects the video categories.
		/// </summary>
		public event EventHandler CategoriesClick;

		/// <summary>
		/// An event handler called when the user selects the global videos link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnVideosGlobalClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.VideosGlobalClick) this.VideosGlobalClick(this, e);
		}

		/// <summary>
		/// An event handler called when the user selects the playlists feed link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnVideosUserClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.VideosUserClick) this.VideosUserClick(this, e);
		}

		/// <summary>
		/// An event handler called when the user selects the categories link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCategoriesClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.CategoriesClick) this.CategoriesClick(this, e);
		}
	}
}
