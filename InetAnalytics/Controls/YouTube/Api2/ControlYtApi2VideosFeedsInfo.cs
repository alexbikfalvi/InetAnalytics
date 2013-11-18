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
using InetCrawler;

namespace InetAnalytics.Controls.YouTube.Api2
{
	/// <summary>
	/// A class displaying the list of feeds for the YouTube API version 2.
	/// </summary>
	public partial class ControlYtApi2VideosFeedsInfo : ThemeControl
	{
		private Crawler crawler;

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

		// Public methods.

		/// <summary>
		/// Initializes the control.
		/// </summary>
		/// <param name="crawler">The crawler.</param>
		public void Initialize(Crawler crawler)
		{
			// Set the crawler.
			this.crawler = crawler;
			// Enable the control.
			this.Enabled = true;
		}

		// Private methods.

		/// <summary>
		/// The event handler for the user selection of the video link.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnVideoClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.crawler.Events.SelectYouTubeVideo();
		}

		/// <summary>
		/// The event handler for the user selection of the video comments link.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnVideoCommentsClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.crawler.Events.SelectYouTubeVideoComments();
		}

		/// <summary>
		/// The event handler for the user selection of the search feed link.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSearchFeedClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.crawler.Events.SelectYouTubeSearchFeed();
		}

		/// <summary>
		/// The event handler for the user selection of the standard feed link.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStandardFeedClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.crawler.Events.SelectYouTubeStandardFeed();
		}

		/// <summary>
		/// The event handler for the user selection of the related videos feed link.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRelatedVideosFeedClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.crawler.Events.SelectYouTubeRelatedVideosFeed();
		}

		/// <summary>
		/// The event handler for the user selection of the response videos feed link.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnResponseVideosFeedClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.crawler.Events.SelectYouTubeResponseVideosFeed();
		}
	}
}
