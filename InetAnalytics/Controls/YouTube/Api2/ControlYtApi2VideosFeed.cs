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
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Windows.Controls;
using InetAnalytics.Controls.Comments;
using InetAnalytics.Events;
using InetApi.YouTube;
using InetApi.YouTube.Api.V2;
using InetApi.YouTube.Api.V2.Atom;
using InetApi.YouTube.Api.V2.Data;
using InetCrawler;
using InetCrawler.Events;
using InetCrawler.Log;

namespace InetAnalytics.Controls.YouTube.Api2
{
	public delegate Uri VideosFeedEventHandler(string video, int? startIndex, int? maxResults);

	/// <summary>
	/// A control class for a YouTube API version 2 standard feed.
	/// </summary>
	public partial class ControlYtApi2VideosFeed : ThreadSafeControl
	{
		private string logSource;

		// Private variables.

		private Crawler crawler;
		private Uri uri = null;
		private YouTubeRequestFeed<Video> request;
		private IAsyncResult result;
		private Feed<Video> feed = null;

		private readonly object sync = new object();

		private VideosFeedEventHandler delegateFeed = null;

		private string feedName = null;
		private string objectName = null;

		// Public declarations

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlYtApi2VideosFeed()
		{
			// Initialize component.
			InitializeComponent();

			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;
		}

		/// <summary>
		/// Initializes the control with a crawler object.
		/// </summary>
		/// <param name="crawler">The crawler object.</param>
		/// <param name="delegateFeed">The feed event handler.</param>
		/// <param name="idName">The ID name.</param>
		/// <param name="feedName">The feed name.</param>
		/// <param name="objectName">The object name.</param>
		/// <param name="logSource">The log source.</param>
		public void Initialize(Crawler crawler, VideosFeedEventHandler delegateFeed, string idName, string feedName, string objectName, string logSource)
		{
			// Save the parameters.
			this.crawler = crawler;
			this.delegateFeed = delegateFeed;
			this.labelId.Text = idName;
			this.feedName = feedName;
			this.objectName = objectName;
			this.logSource = logSource;
			this.request = new YouTubeRequestFeed<Video>(this.crawler.Settings);
		
			// Enable the control
			this.Enabled = true;
		}

		// Public methods.

		/// <summary>
		/// Opens the specified ID.
		/// </summary>
		/// <param name="video">The ID.</param>
		public void View(string id)
		{
			if (!this.textBoxId.Enabled) return;
			this.textBoxId.Text = id;
			this.OnStart(null, null);
		}

		// Private methods.

		/// <summary>
		/// An event handler for when the search text has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSearchChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(this.textBoxId.Text))
			{
				this.buttonStart.Enabled = true;
				this.uri = this.delegateFeed(
					this.textBoxId.Text,
					1,
					this.videoList.VideosPerPage);
				this.linkLabel.Text = this.uri.AbsoluteUri;
			}
			else
			{
				this.buttonStart.Enabled = false;
				this.uri = null;
				this.linkLabel.Text = string.Empty;
			}
		}

		/// <summary>
		/// An event handler raised when the user selects the current feed link.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnOpenLink(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(this.linkLabel.Text);
		}

		/// <summary>
		/// Starts an asynchronous request for the selected video feed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStart(object sender, EventArgs e)
		{
			// Change the controls state.
			this.buttonStart.Enabled = false;
			this.buttonStop.Enabled = true;
			this.textBoxId.Enabled = false;

			// Log
			this.log.Add(this.crawler.Log.Add(
				LogEventLevel.Verbose,
				LogEventType.Information,
				this.logSource,
				"Started request for the {0} of the {1} \'{{0}}\'.".FormatWith(this.feedName, this.objectName),
				new object[] { this.textBoxId.Text, this.linkLabel.Text }));

			// Clear the list view.
			this.videoList.Clear();

			try
			{
				// Begin the request.
				this.result = this.request.Begin(this.uri, this.Callback);
			}
			catch (Exception exception)
			{
				this.log.Add(this.crawler.Log.Add(
					LogEventLevel.Important,
					LogEventType.Error,
					this.logSource,
					"The request for the {0} of the {1} \'{{0}}\' failed. {{1}}".FormatWith(this.feedName, this.objectName),
					new object[] { this.textBoxId.Text, exception.Message, this.linkLabel.Text },
					exception));
			}
		}

		/// <summary>
		/// Cancels an asynchronous request for the selected video feed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStop(object sender, EventArgs e)
		{
			// Cancel the request.
			this.request.Cancel(this.result);
			// Disable the stop button.
			this.buttonStop.Enabled = false;
		}

		/// <summary>
		/// Completes an asynchronous request for the selected video feed.
		/// </summary>
		/// <param name="result">The asynchronous result.</param>
		private void Callback(IAsyncResult result)
		{
			// Execute the code on the UI thread.
			this.Invoke(() =>
				{
					try
					{
						lock (this.sync)
						{
							// Complete the request
							this.feed = this.request.End(result);

							// Add the new items to the list view.
							this.videoList.Add(feed.Entries, feed.Entries.Count > 0 ? feed.SearchStartIndex : 0, feed.Entries.Count, feed.SearchTotalResults);

							// Set the navigation buttons state.
							this.videoList.PreviousEnabled = feed.Links.Previous != null;
							this.videoList.NextEnabled = feed.Links.Next != null;

							// Compute the event type.
							LogEventType eventType = (this.feed.FailuresAtom.Count == 0) && (this.feed.FailuresEntry.Count == 0) ?
								LogEventType.Success : LogEventType.SuccessWarning;
							string eventMessage = eventType == LogEventType.Success ?
								"The request for the {0} of the {1} \'{{0}}\' completed successfully.".FormatWith(this.feedName, this.objectName) :
								"The request for the {0} of the {1} \'{{0}}\' completed partially successfully. However, some errors have occurred.".FormatWith(this.feedName, this.objectName);

							// If there are failures, create a new subevent list.
							List<LogEvent> subevents = null;
							if ((this.feed.FailuresAtom.Count != 0) || (this.feed.FailuresEntry.Count != 0))
							{
								subevents = new List<LogEvent>();
								foreach (AtomException exception in this.feed.FailuresAtom)
								{
									subevents.Add(new LogEvent(
										LogEventLevel.Important,
										LogEventType.Error,
										DateTime.MinValue,
										this.logSource,
										"Parsing of YouTube API version 2 atom XML failed.",
										null,
										exception));
								}
								foreach (YouTubeAtomException exception in this.feed.FailuresEntry)
								{
									subevents.Add(new LogEvent(
										LogEventLevel.Important,
										LogEventType.Error,
										DateTime.MinValue,
										this.logSource,
										"Converting atom to YouTube API version 2 video entry failed.",
										null,
										exception));
								}
							}

							// Log
							this.log.Add(this.crawler.Log.Add(
								LogEventLevel.Verbose,
								eventType,
								this.logSource,
								eventMessage,
								new object[] { this.textBoxId.Text, this.linkLabel.Text },
								null,
								subevents));
						}
					}
					catch (WebException exception)
					{
						if (exception.Status == WebExceptionStatus.RequestCanceled)
							this.log.Add(this.crawler.Log.Add(
								LogEventLevel.Verbose,
								LogEventType.Canceled,
								this.logSource,
								"The request for the {0} of the {1} \'{{0}}\' has been canceled.".FormatWith(this.feedName, this.objectName),
								new object[] { this.textBoxId.Text, this.linkLabel.Text }));
						else
							this.log.Add(this.crawler.Log.Add(
								LogEventLevel.Important,
								LogEventType.Error,
								this.logSource,
								"The request for the {0} of the {1} \'{{0}}\' failed. {{1}}".FormatWith(this.feedName, this.objectName),
								new object[] { this.textBoxId.Text, exception.Message, this.linkLabel.Text },
								exception));
					}
					catch (Exception exception)
					{
						this.log.Add(this.crawler.Log.Add(
							LogEventLevel.Important,
							LogEventType.Error,
							this.logSource,
							"The request for the {0} of the {1} \'{{0}}\' failed. {{1}}".FormatWith(this.feedName, this.objectName),
							new object[] { this.textBoxId.Text, exception.Message, this.linkLabel.Text },
							exception));
					}
					finally
					{
						this.buttonStart.Enabled = true;
						this.buttonStop.Enabled = false;
						this.textBoxId.Enabled = true;
					}
				});
		}

		/// <summary>
		/// An event handler called when the selected video has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnVideoSelectedChanged(object sender, EventArgs e)
		{
			// Change the enabled state of the view video button.
			this.checkBoxView.Enabled = this.videoList.SelectedItem != null;
			if (this.videoList.SelectedItem != null)
				this.menuItemApiV2Author.Enabled = (this.videoList.SelectedItem.Tag as Video).Author != null;
			else
				this.menuItemApiV2Author.Enabled = false;
		}

		/// <summary>
		/// An event handler for the visualization of a video entry menu.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnViewVideo(object sender, EventArgs e)
		{
			if (this.checkBoxView.Checked)
			{
				this.viewMenu.Show(this.checkBoxView, 0, this.checkBoxView.Height);
			}
		}

		/// <summary>
		/// An event handler called when the video entry menu was closed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnViewMenuClosed(object sender, ToolStripDropDownClosedEventArgs e)
		{
			this.checkBoxView.Checked = false;
		}

		/// <summary>
		/// An event handler called when the user selects the option to view the video entry
		/// in the YouTube API version 2.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnViewApiV2Video(object sender, EventArgs e)
		{
			this.crawler.OpenYouTubeVideo(this.videoList.SelectedItem.Tag as Video);
		}

		/// <summary>
		/// An event handler called when the user selects the option to view the author entry
		/// in the YouTube API version 2.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnViewApiV2Author(object sender, EventArgs e)
		{
			Video video = this.videoList.SelectedItem.Tag as Video;
			this.crawler.OpenYouTubeUser(video.Author.UserId);
		}

		/// <summary>
		/// An event handler called when the user selects the option to view the related videos
		/// in the YouTube API version 2.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnViewApiV2Related(object sender, EventArgs e)
		{
			this.crawler.OpenYouTubeRelatedVideos(this.videoList.SelectedItem.Tag as Video);
		}

		/// <summary>
		/// An event handler called when the user selects the option to view the response videos
		/// in the YouTube API version 2.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnViewApiV2Responses(object sender, EventArgs e)
		{
			this.crawler.OpenYouTubeResponseVideos(this.videoList.SelectedItem.Tag as Video);
		}

		/// <summary>
		/// An event handler called when the user selects the option to view the video statistics
		/// in the YouTube web.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnViewWeb(object sender, EventArgs e)
		{
			this.crawler.OpenYouTubeWebVideo(this.videoList.SelectedItem.Tag as Video);
		}

		/// <summary>
		/// An event handler called when the user selects the option to open the video in YouTube in
		/// a browser.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnOpenYouTube(object sender, EventArgs e)
		{
			// Get the video;
			Video video = this.videoList.SelectedItem.Tag as Video;
			// Open the video link in the browser.
			Process.Start(YouTubeUri.GetYouTubeVideoLink(video.Id));
		}

		/// <summary>
		/// An event handler called when the user adds a comment to a video.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnComment(object sender, EventArgs e)
		{
			this.crawler.CommentYouTubeVideo((this.videoList.SelectedItem.Tag as Video).Id);
		}

		/// <summary>
		/// An event handler called when the user navigates to the previous page in the feed list.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNavigatePrevious(object sender, EventArgs e)
		{
			lock (this.sync)
			{
				// If the current feed is null, disable the button and return.
				if ((null == this.feed) || (null == this.feed.Links.Previous))
				{
					this.videoList.PreviousEnabled = false;
					return;
				}
				// Copy the URL.
				this.uri = this.feed.Links.Previous;
				// Set the link label.
				this.linkLabel.Text = this.uri.AbsoluteUri;
				// Clear the feed.
				this.feed = null;
			}
			// Clear the video list.
			this.videoList.Clear();
			// Start a new request.
			this.OnStart(sender, e);
		}

		/// <summary>
		/// An event handler called when the user navigates to the next page in the feed list.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNavigateNext(object sender, EventArgs e)
		{
			lock (this.sync)
			{
				// If the current feed is null, disable the button and return.
				if ((null == this.feed) || (null == this.feed.Links.Next))
				{
					this.videoList.NextEnabled = false;
					return;
				}
				// Copy the URL.
				this.uri = this.feed.Links.Next;
				// Set the link label.
				this.linkLabel.Text = this.uri.AbsoluteUri;
				// Clear the feed.
				this.feed = null;
			}
			// Clear the video list.
			this.videoList.Clear();
			// Start a new request.
			this.OnStart(sender, e);
		}

		/// <summary>
		/// An event handler called when the user clicks on the find next button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnFindNext(object sender, EventArgs e)
		{
			lock (this.sync)
			{
				// If the feed or the start index are null, disable the button and result.
				if ((null == this.feed) && (!this.feed.SearchStartIndex.HasValue))
				{
					this.videoList.FindNextEnabled = false;
					return;
				}

				// Compute the next start index.
				int startIndex = this.feed.SearchStartIndex.Value + this.feed.Entries.Count;

				// Compute the URI.
				this.uri = this.delegateFeed(
					this.textBoxId.Text,
					startIndex,
					this.videoList.VideosPerPage);
				// Set the link label.
				this.linkLabel.Text = this.uri.AbsoluteUri;
				// Clear the feed.
				this.feed = null;
			}
			// Clear the video list.
			this.videoList.Clear();
			// Start a new request.
			this.OnStart(sender, e);
		}

		/// <summary>
		/// An event handler called when the user clicks on the find previous button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnFindPrevious(object sender, EventArgs e)
		{
			lock (this.sync)
			{
				// If the feed or the start index are null, disable the button and result.
				if ((null == this.feed) && (!this.feed.SearchStartIndex.HasValue))
				{
					this.videoList.FindPreviousEnabled = false;
					return;
				}

				// Compute the next start index.
				int startIndex = this.feed.SearchStartIndex.Value > this.videoList.VideosPerPage + 1 ? this.feed.SearchStartIndex.Value - this.videoList.VideosPerPage : 1;

				// Compute the URI.
				this.uri = this.delegateFeed(
					this.textBoxId.Text,
					startIndex,
					this.videoList.VideosPerPage);
				// Set the link label.
				this.linkLabel.Text = this.uri.AbsoluteUri;
				// Clear the feed.
				this.feed = null;
			}
			// Clear the video list.
			this.videoList.Clear();
			// Start a new request.
			this.OnStart(sender, e);
		}

		/// <summary>
		/// An event handler called when the user selects to view the video properties.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnViewProperties(object sender, EventArgs e)
		{
			this.videoList.ShowProperties();
		}

		/// <summary>
		/// An event handler called when the user selects the view profile.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnViewProfile(object sender, StringEventArgs e)
		{
			this.crawler.OpenYouTubeUser(e.Value);
		}
	}
}
