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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetApi.Windows.Controls;
using YtAnalytics.Controls.Database;
using YtApi;
using YtApi.Api.V2;
using YtApi.Api.V2.Atom;
using YtApi.Api.V2.Data;
using YtCrawler;
using YtCrawler.Database.Data;
using YtCrawler.Spider;

namespace YtAnalytics.Controls.Spiders
{
	/// <summary>
	/// A control class for a YouTube API version 2 standard feed.
	/// </summary>
	public partial class ControlSpiderStandardFeeds : ControlDatabase
	{
		private string logSource = "Spider\\Standard Feeds";

		// Private variables.

		private Crawler crawler;

		private SpiderEventHandler delegateSpiderStateChanged;
		private SpiderEventHandler delegateSpiderCrawlStarted;
		private SpiderEventHandler delegateSpiderCrawlFinished;
		private SpiderStandardFeedsStartedEventHandler delegateSpiderFeedsStarted;
		private SpiderStandardFeedsEventHandler delegateSpiderFeedStarted;
		private SpiderStandardFeedsEventHandler delegateSpiderFeedFinished;

		// Public declarations

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlSpiderStandardFeeds()
		{
			// Initialize component.
			InitializeComponent();

			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;

			// Create the delegates.
			this.delegateSpiderStateChanged = new SpiderEventHandler(this.OnSpiderStateChanged);
			this.delegateSpiderCrawlStarted = new SpiderEventHandler(this.OnSpiderCrawlStarted);
			this.delegateSpiderCrawlFinished = new SpiderEventHandler(this.OnSpiderCrawlFinished);
			this.delegateSpiderFeedsStarted = new SpiderStandardFeedsStartedEventHandler(this.OnSpiderCrawlFeedsStarted);
			this.delegateSpiderFeedStarted = new SpiderStandardFeedsEventHandler(this.OnSpiderCrawlFeedStarted);
			this.delegateSpiderFeedFinished = new SpiderStandardFeedsEventHandler(this.OnSpiderCrawlFeedFinished);
		}

		/// <summary>
		/// Initializes the control with a crawler object.
		/// </summary>
		/// <param name="crawler">The crawler object.</param>
		public void Initialize(Crawler crawler)
		{
			// Save the parameters.
			this.crawler = crawler;
		
			// Enable the control.
			this.Enabled = true;

			// Set the button enabled state.
			this.buttonStart.Enabled = this.crawler.Spiders.StandardFeeds.State == Spider.CrawlState.Stopped;
			this.buttonStop.Enabled = this.crawler.Spiders.StandardFeeds.State == Spider.CrawlState.Running;

			// Create the event handlers.
			this.crawler.Spiders.StandardFeeds.StateChanged += this.delegateSpiderStateChanged;
			this.crawler.Spiders.StandardFeeds.CrawlStarted += this.delegateSpiderCrawlStarted;
			this.crawler.Spiders.StandardFeeds.CrawlFinished += this.delegateSpiderCrawlFinished;
			this.crawler.Spiders.StandardFeeds.CrawlFeedsStarted += this.delegateSpiderFeedsStarted;
			this.crawler.Spiders.StandardFeeds.CrawlFeedStarted += this.delegateSpiderFeedStarted;
			this.crawler.Spiders.StandardFeeds.CrawlFeedFinished += this.delegateSpiderFeedFinished;
		}

		// Private methods.

		/// <summary>
		/// Starts an asynchronous request for the selected video feed.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStart(object sender, EventArgs e)
		{
			// Change the controls state.
			this.buttonStart.Enabled = false;
			
			try
			{
				// Begin crawling.
				this.crawler.Spiders.StandardFeeds.BeginCrawl((Spider spider, SpiderAsyncResult asyncResult) =>
					{
					});
			}
			catch (Exception exception)
			{
				// Catch all exceptions.
				MessageBox.Show(
					this,
					string.Format("An error occurred while crawling the standard feeds. {0}", exception.Message),
					"Spider Crawl Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Cancels an asynchronous request for the selected video feed.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStop(object sender, EventArgs e)
		{
			// Disable the stop button.
			this.buttonStop.Enabled = false;
			// Stop the crawling.
		}

		/// <summary>
		/// An event handler called when the spider state has changed.
		/// </summary>
		/// <param name="spider">The spider.</param>
		private void OnSpiderStateChanged(Spider spider)
		{
			// Call this method on the UI thread.
			if (this.InvokeRequired)
			{
				this.Invoke(this.delegateSpiderStateChanged, new object[] { spider });
				return;
			}
			// Change the button state.
			this.buttonStart.Enabled = spider.State == Spider.CrawlState.Stopped;
			this.buttonStop.Enabled = spider.State == Spider.CrawlState.Running;
		}

		/// <summary>
		/// An event handler called when the spider crawl has started.
		/// </summary>
		/// <param name="spider">The spider.</param>
		private void OnSpiderCrawlStarted(Spider spider)
		{
			// Call this method on the UI thread.
			if (this.InvokeRequired)
			{
				this.Invoke(this.delegateSpiderCrawlStarted, new object[] { spider });
				return;
			}
			// Set the progress.
			this.progressBar.Value = 0;
			this.labelProgress.Text = "Started.";
		}

		/// <summary>
		/// An event handler called when the spider crawl has finished.
		/// </summary>
		/// <param name="spider">The spider.</param>
		private void OnSpiderCrawlFinished(Spider spider)
		{
			// Call this method on the UI thread.
			if (this.InvokeRequired)
			{
				this.Invoke(this.delegateSpiderCrawlFinished, new object[] { spider });
				return;
			}
			// Set the prgress.
			this.progressBar.Value = this.progressBar.Maximum;
			this.labelProgress.Text = "Finished.";
		}

		/// <summary>
		/// An event handler called when the spider began crawling the standard feeds.
		/// </summary>
		/// <param name="spider">The spider.</param>
		/// <param name="feeds">The list of standard feed objects.</param>
		private void OnSpiderCrawlFeedsStarted(Spider spider, IDictionary<string, DbObjectStandardFeed> feeds)
		{
			// Call this method on the UI thread.
			if (this.InvokeRequired)
			{
				this.Invoke(this.delegateSpiderFeedsStarted, new object[] { spider, feeds });
				return;
			}
			// Set the progress bar.
			this.progressBar.Maximum = feeds.Count;
			this.labelProgress.Text = string.Format("Crawling {0} standard feeds.", feeds.Count);
			// Clear the list view.
			//this.listView.Items.Clear();
			// Add the feeds to the list view.
			foreach (KeyValuePair<string, DbObjectStandardFeed> feed in feeds)
			{
				ListViewItem item = new ListViewItem(new string[] {
					YtApi.Api.V2.YouTubeUri.StandardFeedNames[feed.Value.FeedId],
					YtApi.Api.V2.YouTubeUri.TimeNames[feed.Value.TimeId],
					feed.Value.Category,
					feed.Value.Region
				});
				item.ImageKey = "FeedQuestion";
				//this.listView.Items.Add(item);
			}
		}

		/// <summary>
		/// An event handler called when the spider starts crawling a standard feed.
		/// </summary>
		/// <param name="spider">The spider.</param>
		/// <param name="obj">The standard feed object.</param>
		private void OnSpiderCrawlFeedStarted(Spider spider, DbObjectStandardFeed obj)
		{
			// Call this method on the UI thread.
			if (this.InvokeRequired)
			{
				this.Invoke(this.delegateSpiderFeedStarted, new object[] { spider, obj });
				return;
			}
		}

		private void OnSpiderCrawlFeedFinished(Spider spider, DbObjectStandardFeed obj)
		{
			// Call this method on the UI thread.
			if (this.InvokeRequired)
			{
				this.Invoke(this.delegateSpiderFeedFinished, new object[] { spider, obj });
				return;
			}
		}
	}
}
