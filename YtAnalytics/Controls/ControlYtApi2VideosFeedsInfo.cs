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

namespace YtAnalytics.Controls
{
	/// <summary>
	/// A class displaying the list of feeds for the YouTube API version 2.
	/// </summary>
	public partial class ControlYtApi2VideosFeedsInfo : UserControl
	{
		/// <summary>
		/// Creates a new instance of the control.
		/// </summary>
		public ControlYtApi2VideosFeedsInfo()
		{
			// Initialize component.
			InitializeComponent();

			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;
		}

		/// <summary>
		/// An event raised when the user selects the video link.
		/// </summary>
		public event EventHandler VideoClick;
		/// <summary>
		/// An event raised when the user selects the video comments link.
		/// </summary>
		public event EventHandler VideoCommentsClick;
		/// <summary>
		/// An event raised when the user selects the videos feed link.
		/// </summary>
		public event EventHandler SearchFeedClick;
		/// <summary>
		/// An event raised when the user selects the standard feed link.
		/// </summary>
		public event EventHandler StandardFeedClick;
		/// <summary>
		/// An event raised when the user selects the related videos feed link.
		/// </summary>
		public event EventHandler RelatedVideosFeedClick;
		/// <summary>
		/// An event raised when the user selects the response videos feed link.
		/// </summary>
		public event EventHandler ResponseVideosFeedClick;

		/// <summary>
		/// The event handler for the user selection of the video link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnVideoClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.VideoClick) this.VideoClick(this, e);
		}

		/// <summary>
		/// The event handler for the user selection of the video comments link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnVideoCommentsClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.VideoCommentsClick) this.VideoCommentsClick(this, e);
		}

		/// <summary>
		/// The event handler for the user selection of the search feed link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSearchFeedClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.SearchFeedClick) this.SearchFeedClick(this, e);
		}

		/// <summary>
		/// The event handler for the user selection of the standard feed link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStandardFeedClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.StandardFeedClick) this.StandardFeedClick(this, e);
		}

		/// <summary>
		/// The event handler for the user selection of the related videos feed link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRelatedVideosFeedClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.RelatedVideosFeedClick) this.RelatedVideosFeedClick(this, e);
		}

		/// <summary>
		/// The event handler for the user selection of the response videos feed link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnResponseVideosFeedClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.ResponseVideosFeedClick) this.ResponseVideosFeedClick(this, e);
		}
	}
}
