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
	/// A control that displays the feed types available in the YouTube API version 2.
	/// </summary>
	public partial class ControlYtApi2 : UserControl
	{
		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlYtApi2()
		{
			// Initialize component.
			InitializeComponent();
			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;
		}

		/// <summary>
		/// An event raised when the user selects the video feeds.
		/// </summary>
		public event EventHandler ClickVideoFeeds;
		/// <summary>
		/// An event raised when the user selects the playlists feed.
		/// </summary>
		public event EventHandler ClickUserPlaylistsFeed;
		/// <summary>
		/// An event raised when the user selects the subscriptions feed.
		/// </summary>
		public event EventHandler ClickUserSubscriptionsFeed;
		/// <summary>
		/// An event raised when the user selects the video comments feed.
		/// </summary>
		public event EventHandler ClickVideoCommentsFeed;
		/// <summary>
		/// An event raised when the user selects the user profile entry.
		/// </summary>
		public event EventHandler ClickUserProfileEntry;
		/// <summary>
		/// An event raised when the user selects the contacts feed.
		/// </summary>
		public event EventHandler ClickUserContactsFeed;
		/// <summary>
		/// An event raised when the user selects the video categories.
		/// </summary>
		public event EventHandler ClickCategories;

		/// <summary>
		/// An event handler called when the user selects the video feeds link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnVideoFeedsClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.ClickVideoFeeds) this.ClickVideoFeeds(this, e);
		}

		/// <summary>
		/// An event handler called when the user selects the playlists feed link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnUserPlaylistsFeedClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.ClickUserPlaylistsFeed) this.ClickUserPlaylistsFeed(this, e);
		}

		/// <summary>
		/// An event handler called when the user selects the subscriptions feed link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnUserSubscriptionsFeedClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.ClickUserSubscriptionsFeed) this.ClickUserSubscriptionsFeed(this, e);
		}

		/// <summary>
		/// An event handler called when the user selects the comments feed link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnVideoCommentsFeedClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.ClickVideoCommentsFeed) this.ClickVideoCommentsFeed(this, e);
		}

		/// <summary>
		/// An event handler called when the user selects the user profile entry link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnUserProfileEntryClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.ClickUserProfileEntry) this.ClickUserProfileEntry(this, e);
		}

		/// <summary>
		/// An event handler called when the user selects the user contacts feed link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnUserContactsFeedClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.ClickUserContactsFeed) this.ClickUserContactsFeed(this, e);
		}

		/// <summary>
		/// An event handler called when the user selects the categories link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCategoriesClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.ClickCategories) this.ClickCategories(this, e);
		}
	}
}
