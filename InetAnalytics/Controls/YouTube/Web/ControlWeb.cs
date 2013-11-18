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

namespace InetAnalytics.Controls.YouTube.Web
{
	/// <summary>
	/// A control that displays the feed types available in the YouTube API version 2.
	/// </summary>
	public partial class ControlWeb : ThemeControl
	{
		private Crawler crawler; 

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlWeb()
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
		/// An event handler called when the user selects the video feeds link.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnVideoStatisticsClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.crawler.Events.SelectYouTubeWebVideos();
		}
	}
}
