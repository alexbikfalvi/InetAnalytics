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
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YtApi.Api.V2;
using YtApi.Api.V2.Data;
using YtCrawler;
using YtCrawler.Database;
using YtCrawler.Log;
using YtAnalytics.Controls;

namespace YtAnalytics.Controls
{
	public delegate void AddServerEventHandler(DbServer server);

	/// <summary>
	/// A class representing the control to browse the video entry in the YouTube API version 2.
	/// </summary>
	public partial class ControlServers : UserControl
	{
		private static string logSource = "Database Servers";

		private Crawler crawler;

		/// <summary>
		/// Creates a new instance of the control.
		/// </summary>
		public ControlServers()
		{
			// Initialize component.
			InitializeComponent();

			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;
		}

		/// <summary>
		/// Initializes the control with a crawler instance.
		/// </summary>
		/// <param name="crawler">The crawler instance.</param>
		public void Initialize(Crawler crawler)
		{
			// Set the crawler.
			this.crawler = crawler;

			// Reload the servers list.
			this.Reload();

			/*
			this.log.Add(this.crawler.Log.Add(
				LogEventLevel.Verbose,
				LogEventType.Stop,
				ControlServers.logSource,
				"The video ID text box cannot be empty."));
			*/
		}

		/// <summary>
		/// Reloads the servers list.
		/// </summary>
		public void Reload()
		{
			// Add all the servers in the configuration.
			/*foreach (DbServer server in this.crawler.Servers)
			{
				// Create a new server item.
				ListViewItem item = new ListViewItem(new object[] {
					server.Name,
					server.IsPrimary ? "Primary" : "Backup",
					server.ConnectionState,
					string.Empty
				});

			}*/
		}
	}
}
