/* 
 * Copyright (C) 2014 Alex Bikfalvi
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
using DotNetApi.Windows.Controls;
using InetCrawler;
using InetTools.Tools.Mercury;

namespace InetTools.Controls.Mercury
{
	/// <summary>
	/// A control that displays the main control for the Mercury project.
	/// </summary>
	public partial class ControlMercury : ThemeControl
	{
		private readonly MercuryConfig config;

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		/// <param name="config">The mercury configuration.</param>
		public ControlMercury(MercuryConfig config)
		{
			// Initialize component.
			InitializeComponent();

			// Set the configuration.
			this.config = config;

			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;
		}

		// Private methods.

		/// <summary>
		/// An event handler called when the user selects the analyze tool item.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAnalyzeClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			//this.crawler.Events.SelectYouTubeVideoFeeds();
		}

		/// <summary>
		/// An event handler called when the user clicks on the.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnUploadTracerouteClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			//this.crawler.Events.SelectYouTubeUserFeeds();
		}

		/// <summary>
		/// An event handler called when the user selects the categories link.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnUploadRoutingClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			//this.crawler.Events.SelectYouTubeCategories();
		}
	}
}
