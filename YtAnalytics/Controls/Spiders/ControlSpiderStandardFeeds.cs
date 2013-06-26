/* 
 * Copyright (C) 2012-2013 Alex Bikfalvi
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
		//private string logSource = "Spider\\Standard Feeds";

		// Private variables.

		private Crawler crawler;

		private SpiderEventHandler delegateSpiderStateChanged;
		private SpiderEventHandler delegateSpiderCrawlStarted;
		private SpiderEventHandler delegateSpiderCrawlFinished;
		private SpiderStandardFeedsStartedEventHandler delegateSpiderFeedsStarted;
		private SpiderStandardFeedsEventHandler delegateSpiderFeedStarted;
		private SpiderStandardFeedsEventHandler delegateSpiderFeedFinished;

		private IAsyncResult crawlResult = null;

		private ProgressItem[] progressItems = new ProgressItem[YouTubeUri.StandardFeedNames.Length];

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

			// Initialize the progress list box.
			for (int index = 0; index < YouTubeUri.StandardFeedNames.Length; index++)
			{
				// Initialize the progress item.
				progressItems[index] = new ProgressItem(YouTubeUri.StandardFeedNames[index], this.progressLegend);
				// Set the default progress.
				progressItems[index].Progress.Default = this.progressLegend.Items.Count - 1;
			}
			this.progressListBox.Items.AddRange(this.progressItems);
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
			this.buttonFeeds.Enabled = this.crawler.Spiders.StandardFeeds.State == Spider.CrawlState.Stopped;

			// Create the event handlers.
			this.crawler.Spiders.StandardFeeds.StateChanged += this.delegateSpiderStateChanged;
			this.crawler.Spiders.StandardFeeds.CrawlStarted += this.delegateSpiderCrawlStarted;
			this.crawler.Spiders.StandardFeeds.CrawlFinished += this.delegateSpiderCrawlFinished;
			this.crawler.Spiders.StandardFeeds.CrawlFeedsStarted += this.delegateSpiderFeedsStarted;
			this.crawler.Spiders.StandardFeeds.CrawlFeedStarted += this.delegateSpiderFeedStarted;
			this.crawler.Spiders.StandardFeeds.CrawlFeedFinished += this.delegateSpiderFeedFinished;

			// Initialize the progress list box and checked list.
			for (int index = 0; index < YouTubeUri.StandardFeedNames.Length; index++)
			{
				// Get whether the feed is selected.
				bool selected = this.crawler.Spiders.StandardFeeds.GetFeedSelected(YtApi.Api.V2.YouTube.StandardFeeds[index]);
				// Initialize the progress item.
				progressItems[index].Enabled = selected;
				// Initialize the checked item.
				this.checkedListFeeds.AddItem(
					index,
					YouTubeUri.StandardFeedNames[index],
					selected ? CheckState.Checked : CheckState.Unchecked);
			}
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
			this.buttonFeeds.Enabled = false;

			try
			{
				// Begin crawling.
				this.crawlResult = this.crawler.Spiders.StandardFeeds.BeginCrawl((Spider spider, SpiderAsyncResult asyncResult) =>
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
			this.crawler.Spiders.StandardFeeds.CancelCrawl(this.crawlResult);
			// Set the crawl result to null.
			this.crawlResult = null;
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
			this.buttonFeeds.Enabled = spider.State == Spider.CrawlState.Stopped;
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
			// Suspend the list box progress events.
			this.progressListBox.SuspendProgressEvents();
			// Reset the progress items count.
			foreach (ProgressItem item in this.progressItems)
			{
				item.Progress.Count = 0;
			}
			// Update the progress list box.
			foreach (KeyValuePair<string, DbObjectStandardFeed> feed in feeds)
			{
				// Increment the progress count for each feed.
				this.progressItems[feed.Value.FeedId].Progress.Count++;
			}
			// Resume the list box progress events.
			this.progressListBox.ResumeProgressEvents();
		}

		/// <summary>
		/// An event handler called when the spider starts crawling a standard feed.
		/// </summary>
		/// <param name="spider">The spider.</param>
		/// <param name="feeds">The list of standard feeds.</param>
		/// <param name="obj">The standard feed object.</param>
		/// <param name="index">The feed index.</param>
		private void OnSpiderCrawlFeedStarted(Spider spider, IDictionary<string, DbObjectStandardFeed> feeds, DbObjectStandardFeed obj, int index)
		{
			// Call this method on the UI thread.
			if (this.InvokeRequired)
			{
				this.Invoke(this.delegateSpiderFeedStarted, new object[] { spider, feeds, obj, index });
				return;
			}

			// Update the progress label.
			this.labelProgress.Text = string.Format("Crawling feed {0} of {1}.", index, feeds.Count);			
		}

		/// <summary>
		/// An event handler called when the spider finishes crawling a standard feed.
		/// </summary>
		/// <param name="spider">The spider.</param>
		/// <param name="feeds">The list of standard feeds.</param>
		/// <param name="obj">The standard feed object.</param>
		/// <param name="index">The feed index.</param>
		private void OnSpiderCrawlFeedFinished(Spider spider, IDictionary<string, DbObjectStandardFeed> feeds, DbObjectStandardFeed obj, int index)
		{
			// Call this method on the UI thread.
			if (this.InvokeRequired)
			{
				this.Invoke(this.delegateSpiderFeedFinished, new object[] { spider, feeds, obj, index });
				return;
			}

			// Update the progress item corresponding to this feed.
			this.progressItems[obj.FeedId].Progress.Change(0);
			// Update the progress bar.
			this.progressBar.Value++;
		}

		/// <summary>
		/// An event handler called when the user changes the checked state of a standard feed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnFeedCheck(object sender, ItemCheckEventArgs e)
		{
			// If the checked item index is outside the bounds of the progress list box items, do nothing.
			if (e.Index >= this.progressListBox.Items.Count) return;

			// Update the enabled state of the corresponding progress item.
			this.progressListBox.Items[e.Index].Enabled = e.NewValue == CheckState.Checked;

			// Save the state in the spider configuration.
			this.crawler.Spiders.StandardFeeds.SetFeedSelected(YtApi.Api.V2.YouTube.StandardFeeds[e.Index], e.NewValue == CheckState.Checked);
			
			// Refresh the progress list box.
			this.progressListBox.Refresh();
		}
	}
}
