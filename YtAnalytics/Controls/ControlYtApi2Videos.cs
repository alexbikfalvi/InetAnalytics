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
	public partial class ControlYtApi2Videos : UserControl
	{
		/// <summary>
		/// Creates a new instance of the control.
		/// </summary>
		public ControlYtApi2Videos()
		{
			// Initialize component.
			InitializeComponent();

			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;
		}

		/// <summary>
		/// An event raised when the user selects the video entry link.
		/// </summary>
		public event EventHandler ClickVideoEntry;
		/// <summary>
		/// An event raised when the user selects the standard feed link.
		/// </summary>
		public event EventHandler ClickStandardFeed;
		/// <summary>
		/// An event raised when the user selects the videos feed link.
		/// </summary>
		public event EventHandler ClickVideosFeed;
		/// <summary>
		/// An event raised when the user selects the related videos feed link.
		/// </summary>
		public event EventHandler ClickRelatedVideosFeed;
		/// <summary>
		/// An event raised when the user selects the video responses feed link.
		/// </summary>
		public event EventHandler ClickVideoResponsesFeed;
		/// <summary>
		/// An event raised when the user selects the user favorites feed link.
		/// </summary>
		public event EventHandler ClickUserFavoritesFeed;
		/// <summary>
		/// An event raised when the user selects the playlist feed link.
		/// </summary>
		public event EventHandler ClickPlaylistFeed;

		/// <summary>
		/// The event handler for the user selection of the standard feed link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void StandardFeedClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.ClickStandardFeed) this.ClickStandardFeed(this, e);
		}

		/// <summary>
		/// The event handler for the user selection of the videos feed link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void VideosFeedClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.ClickVideosFeed) this.ClickVideosFeed(this, e);
		}

		/// <summary>
		/// The event handler for the user selection of the related videos feed link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void RelatedVideosFeedClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.ClickRelatedVideosFeed) this.ClickRelatedVideosFeed(this, e);
		}

		/// <summary>
		/// The event handler for the user selection of the video responses feed link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void VideoResponsesFeedClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.ClickVideoResponsesFeed) this.ClickVideoResponsesFeed(this, e);
		}

		/// <summary>
		/// The event handler for the user selection of the user favorites feed link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void UserFavoritesFeedClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.ClickUserFavoritesFeed) this.ClickUserFavoritesFeed(this, e);
		}

		/// <summary>
		/// The event handler for the user selection of the playlist feed link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void PlaylistFeedClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.ClickPlaylistFeed) this.ClickPlaylistFeed(this, e);
		}

		/// <summary>
		/// The event handler for the user selection of the video entry link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void VideoEntryClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.ClickVideoEntry) this.ClickVideoEntry(this, e);
		}
	}
}
