/* 
 * Copyright (C) 2013 Alex Bikfalvi
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
using System.Net;
using System.Text;
using System.Windows.Forms;
using DotNetApi.Web;
using DotNetApi.Windows.Controls;
using YtAnalytics.Forms.Net;
using YtCrawler;
using YtCrawler.Log;

namespace YtAnalytics.Controls.Testing
{
	/// <summary>
	/// A control class for testing secure shell.
	/// </summary>
	public partial class ControlTestingSsh : ThreadSafeControl
	{
		private static string logSource = "Testing Secure Shell";

		// Private variables.

		private Crawler crawler = null;
//		private Uri uri = null;
//		private AsyncWebRequest request = new AsyncWebRequest();
//		private IAsyncResult result = null;

		// Public declarations

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlTestingSsh()
		{
			// Initialize component.
			InitializeComponent();

			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;
		}
		
		// Public methods.

		/// <summary>
		/// Initialized the control with the specified crawler.
		/// </summary>
		/// <param name="crawler">The crawler.</param>
		public void Initialize(Crawler crawler)
		{
			// Set the crawler.
			this.crawler = crawler;

			// Enable the control.
			this.Enabled = true;
		}


	}
}
