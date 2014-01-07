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
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Windows.Controls;
using InetAnalytics.Controls.Database;
using InetApi.YouTube.Api.V2;
using InetCrawler;
using InetCrawler.Database.Data;
using InetCrawler.Spider;

namespace InetAnalytics.Controls.Spiders
{
	/// <summary>
	/// A control class for a YouTube API version 2 standard feed.
	/// </summary>
	public partial class ControlSpiderStandardFeeds : ControlBaseSql
	{
		//private string logSource = @"Spider\Standard Feeds";

		// Private variables.

		private Crawler crawler;

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
			this.crawler.Spiders.StandardFeeds.StateChanged += this.OnSpiderStateChanged;
			this.crawler.Spiders.StandardFeeds.CrawlStarted += this.OnSpiderCrawlStarted;
			this.crawler.Spiders.StandardFeeds.CrawlFinished += this.OnSpiderCrawlFinished;
			this.crawler.Spiders.StandardFeeds.FeedsCrawlStarted += this.OnFeedsCrawlStarted;
			this.crawler.Spiders.StandardFeeds.FeedsCrawlFinished += this.OnFeedsCrawlFinished;
			this.crawler.Spiders.StandardFeeds.FeedCrawlStarted += this.OnFeedCrawlStarted;
			this.crawler.Spiders.StandardFeeds.FeedCrawlFinished += this.OnFeedCrawlFinished;

			// Initialize the progress list box and checked list.
			for (int index = 0; index < YouTubeUri.StandardFeedNames.Length; index++)
			{
				// Get whether the feed is selected.
				bool selected = this.crawler.Spiders.StandardFeeds.GetFeedSelected(InetApi.YouTube.Api.V2.YouTube.StandardFeeds[index]);
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
		/// <param name="sender">The sender object.</param>
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
					"An error occurred while crawling the standard feeds. {0}".FormatWith(exception.Message),
					"Spider Crawl Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Cancels an asynchronous request for the selected video feed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
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
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSpiderStateChanged(object sender, SpiderEventArgs e)
		{
			// Execute the code on the UI thread.
			this.Invoke(() =>
				{
					// Change the button state.
					this.buttonStart.Enabled = e.Spider.State == Spider.CrawlState.Stopped;
					this.buttonStop.Enabled = e.Spider.State == Spider.CrawlState.Running;
					this.buttonFeeds.Enabled = e.Spider.State == Spider.CrawlState.Stopped;
				});
		}

		/// <summary>
		/// An event handler called when the spider crawl has started.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSpiderCrawlStarted(object sender, SpiderEventArgs e)
		{
			// Execute the code on the UI thread.
			this.Invoke(() =>
				{
					// Set the progress.
					//this.progressBox.Progress.Reset();
					//this.progressBar.Value = 0;
					//this.labelProgress.Text = "Started.";
				});
		}

		/// <summary>
		/// An event handler called when the spider crawl has finished.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSpiderCrawlFinished(object sender, SpiderEventArgs e)
		{
			// Execute the code on the UI thread.
			this.Invoke(() =>
				{
					// Set the prgress.
					//this.progressBar.Value = this.progressBar.Maximum;
					//this.labelProgress.Text = "Finished.";
				});
		}

		/// <summary>
		/// An event handler called when the spider began crawling the standard feeds.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnFeedsCrawlStarted(object sender, SpiderInfoEventArgs<SpiderStandardFeeds.CrawlInfo> e)
		{
			// Execute the code on the UI thread.
			this.Invoke(() =>
				{
					// Set the progress bar.
					//this.progressBar.Maximum = feeds.Count;
					//this.labelProgress.Text = "Crawling {0} standard feeds.".FormatWith(feeds.Count);
					// Suspend the list box progress events.
					this.progressListBox.SuspendProgressEvents();
					// Reset the progress items count.
					foreach (ProgressItem item in this.progressItems)
					{
						item.Progress.Count = 0;
					}
					// Update the progress list box.
					foreach (KeyValuePair<string, DbObjectStandardFeed> feed in e.Info.Feeds)
					{
						// Increment the progress count for each feed.
						this.progressItems[feed.Value.FeedId].Progress.Count++;
					}
					// Resume the list box progress events.
					this.progressListBox.ResumeProgressEvents();
				});
		}

		/// <summary>
		/// An event handler called when the spider finished crawling the standard feeds.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnFeedsCrawlFinished(object sender, SpiderInfoEventArgs<SpiderStandardFeeds.CrawlInfo> e)
		{
			// Execute the code on the UI thread.
			this.Invoke(() =>
				{
					// Set the progress bar.
					//this.progressBar.Value = feeds.Count;
					//this.labelProgress.Text = "Crawling {0} standard feeds finished.".FormatWith(feeds.Count);
				});
		}

		/// <summary>
		/// An event handler called when the spider starts crawling a standard feed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnFeedCrawlStarted(object sender, SpiderInfoEventArgs<SpiderStandardFeeds.FeedStartedInfo> e)
		{
			// Execute the code on the UI thread.
			this.Invoke(() =>
				{
					// Update the progress label.
					//this.labelProgress.Text = "Crawling feed {0} of {1} started.".FormatWith(index, count);			
				});
		}

		/// <summary>
		/// An event handler called when the spider finishes crawling a standard feed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnFeedCrawlFinished(object sender, SpiderInfoEventArgs<SpiderStandardFeeds.FeedFinishedInfo> e)
		{
			// Execute the code on the UI thread.
			this.Invoke(() =>
				{
				});
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
			this.crawler.Spiders.StandardFeeds.SetFeedSelected(InetApi.YouTube.Api.V2.YouTube.StandardFeeds[e.Index], e.NewValue == CheckState.Checked);
			
			// Refresh the progress list box.
			this.progressListBox.Refresh();
		}
	}
}
