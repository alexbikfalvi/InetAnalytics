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

namespace YtAnalytics.Controls
{
	/// <summary>
	/// A class displaying the list of feeds for the YouTube API version 2.
	/// </summary>
	public partial class ControlYtApi2UserFeedsInfo : ThreadSafeControl
	{
		/// <summary>
		/// Creates a new instance of the control.
		/// </summary>
		public ControlYtApi2UserFeedsInfo()
		{
			// Initialize component.
			InitializeComponent();

			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;
		}

		/// <summary>
		/// An event raised when the user selects the user link.
		/// </summary>
		public event EventHandler UserClick;
		/// <summary>
		/// An event raised when the user selects the uploads feed link.
		/// </summary>
		public event EventHandler UploadsFeedClick;
		/// <summary>
		/// An event raised when the user selects the favorites feed link.
		/// </summary>
		public event EventHandler FavoritesFeedClick;
		/// <summary>
		/// An event raised when the user selects the user playlists feed link.
		/// </summary>
		public event EventHandler PlaylistsFeedClick;
		/// <summary>
		/// An event raised when the user selects the playlist videos feed link.
		/// </summary>
		public event EventHandler PlaylistFeedClick;

		/// <summary>
		/// The event handler for the user selection of the video link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnUserClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.UserClick) this.UserClick(this, e);
		}

		/// <summary>
		/// The event handler for the user selection of the uploads feed link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnUploadsFeedClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.UploadsFeedClick) this.UploadsFeedClick(this, e);
		}

		/// <summary>
		/// The event handler for the user selection of the favorites feed link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnFavoritesFeedClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.FavoritesFeedClick) this.FavoritesFeedClick(this, e);
		}

		/// <summary>
		/// The event handler for the user selection of the user playlists feed link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnPlaylistsFeedClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.PlaylistsFeedClick) this.PlaylistsFeedClick(this, e);
		}

		/// <summary>
		/// The event handler for the user selection of the playlist feed link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnPlaylistFeedClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.PlaylistFeedClick) this.PlaylistFeedClick(this, e);
		}
	}
}
