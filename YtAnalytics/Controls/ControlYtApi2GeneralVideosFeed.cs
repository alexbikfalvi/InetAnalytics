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
using YtCrawler;
using YtApi;
using YtApi.Api.V2;
using YtApi.Api.V2.Atom;
using YtApi.Api.V2.Data;
using YtCrawler.Log;

namespace YtAnalytics.Controls
{
	public delegate Uri GeneralVideosFeedEventHandler(string video, int? startIndex, int? maxResults);


	/// <summary>
	/// A control class for a YouTube API version 2 standard feed.
	/// </summary>
	public partial class ControlYtApi2GeneralVideosFeed : UserControl
	{
		private string logSource;

		// Private variables.

		private Crawler crawler;
		private ControlMessage message = new ControlMessage();
		private Uri uri = null;
		private YouTubeRequestVideoFeed request;
		private IAsyncResult result;
		private Feed<Video> feed = null;

		private ShowMessageEventHandler delegateShowMessage;
		private HideMessageEventHandler delegateHideMessage;

		private static YouTubeStandardFeed[] feeds = new YouTubeStandardFeed[] {
			YouTubeStandardFeed.TopRated,
			YouTubeStandardFeed.TopFavories,
			YouTubeStandardFeed.MostShared,
			YouTubeStandardFeed.MostPopular,
			YouTubeStandardFeed.MostRecent,
			YouTubeStandardFeed.MostDiscussed,
			YouTubeStandardFeed.MostResponsed,
			YouTubeStandardFeed.RecentlyFeatured,
			YouTubeStandardFeed.TrendingVideos
		};
		private static YouTubeTimeId[] times = new YouTubeTimeId[] {
			YouTubeTimeId.AllTime,
			YouTubeTimeId.Today,
			YouTubeTimeId.ThisWeek,
			YouTubeTimeId.ThisMonth
		};

		private GeneralVideosFeedEventHandler delegateFeed = null;

		// Public declarations

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlYtApi2GeneralVideosFeed()
		{
			// Add the message control.
			this.Controls.Add(this.message);

			// Initialize component.
			InitializeComponent();

			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;

			// Delegates.
			this.delegateShowMessage = new ShowMessageEventHandler(this.ShowMessage);
			this.delegateHideMessage = new HideMessageEventHandler(this.HideMessage);
		}

		/// <summary>
		/// Initializes the control with a crawler object.
		/// </summary>
		/// <param name="crawler">The crawler object.</param>
		public void Initialize(Crawler crawler, GeneralVideosFeedEventHandler delegateFeed, string logSource)
		{
			// Save the parameters.
			this.crawler = crawler;
			this.delegateFeed = delegateFeed;
			this.logSource = logSource;
			this.request = new YouTubeRequestVideoFeed(this.crawler.Settings);
		
			// Enable the control
			this.Enabled = true;
		}

		// Public events.

		/// <summary>
		/// View the video information using the version 2 API.
		/// </summary>
		public event ViewVideoEventHandler ViewVideoInApiV2;
		/// <summary>
		/// View the related videos using the version 2 API.
		/// </summary>
		public event ViewVideoEventHandler ViewVideoRelatedInApiV2;
		/// <summary>
		/// View the response videos using the version 2 API.
		/// </summary>
		public event ViewVideoEventHandler ViewVideoResponsesInApiV2;
		/// <summary>
		/// View the video information using the version 3 API.
		/// </summary>
		public event ViewVideoEventHandler ViewVideoInApiV3;
		/// <summary>
		/// View the video statistics using the web.
		/// </summary>
		public event ViewVideoEventHandler ViewVideoInWeb;
		/// <summary>
		/// An event handler called when the user adds a new comment.
		/// </summary>
		public event AddVideoCommentEventHandler Comment;

		// Public methods.

		/// <summary>
		/// Opens the specified video.
		/// </summary>
		/// <param name="video">The video.</param>
		public void View(Video video)
		{
			if (null == video) return;
			if (!this.textBoxVideo.Enabled) return;
			this.textBoxVideo.Text = video.Id;
			this.Start(null, null);
		}

		// Private methods.

		/// <summary>
		/// Shows an alerting message on top of the control.
		/// </summary>
		/// <param name="image">The message icon.</param>
		/// <param name="text">The message text.</param>
		/// <param name="progress">The visibility of the progress bar.</param>
		private void ShowMessage(Image image, string text, bool progress = true)
		{
			// Invoke the function on the UI thread.
			if (this.InvokeRequired)
				this.Invoke(this.delegateShowMessage, new object[] { image, text, progress });
			else
			{
				// Show the message.
				this.message.Show(image, text, progress);
				// Disable the control.
				this.panel.Enabled = false;
			}
		}

		/// <summary>
		/// Hides the alerting message.
		/// </summary>
		private void HideMessage()
		{
			// Invoke the function on the UI thread.
			if (this.InvokeRequired)
				this.Invoke(this.delegateHideMessage);
			else
			{
				// Hide the message.
				this.message.Hide();
				// Enable the control.
				this.panel.Enabled = true;
			}
		}

		/// <summary>
		/// An event handler for when the search text has changed.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void SearchChanged(object sender, EventArgs e)
		{
			if (this.textBoxVideo.Text != string.Empty)
			{
				this.buttonStart.Enabled = true;
				this.uri = this.delegateFeed(
					this.textBoxVideo.Text,
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
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OpenLink(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(this.linkLabel.Text);
		}

		/// <summary>
		/// Starts an asynchronous request for the selected video feed.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void Start(object sender, EventArgs e)
		{
			// Change the controls state.
			this.buttonStart.Enabled = false;
			this.buttonStop.Enabled = true;
			this.textBoxVideo.Enabled = false;

			// Log
			this.log.Add(this.crawler.Log.Add(
				LogEventLevel.Verbose,
				LogEventType.Information,
				this.logSource,
				"Started request for the related videos feed of the video \'{0}\'.",
				new object[] { this.textBoxVideo.Text, this.linkLabel.Text }));

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
					"The request for the related videos feed of the video \'{0}\' failed. {1}",
					new object[] { this.textBoxVideo.Text, exception.Message, this.linkLabel.Text },
					exception));
			}
		}

		/// <summary>
		/// Cancels an asynchronous request for the selected video feed.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void Stop(object sender, EventArgs e)
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
			if (this.InvokeRequired)
				this.Invoke(new AsyncCallback(this.Callback), new object[] { result });
			else
			{
				try
				{
					// Complete the request
					this.feed = this.request.End(result);

					// Add the new items to the list view.
					foreach (Video video in feed.Entries)
					{
						this.videoList.Add(video);
					}

					// Update the page information.
					this.videoList.CountStart = feed.Entries.Count > 0 ? feed.SearchStartIndex : 0;
					this.videoList.CountPerPage = feed.Entries.Count;
					this.videoList.CountTotal = feed.SearchTotalResults;

					// Set the navigation buttons state.
					this.videoList.Previous = feed.Links.Previous != null;
					this.videoList.Next = feed.Links.Next != null;

					// Compute the event type.
					LogEventType eventType = (this.feed.FailuresAtom.Count == 0) && (this.feed.FailuresEntry.Count == 0) ?
						LogEventType.Success : LogEventType.SuccessWarning;
					string eventMessage = eventType == LogEventType.Success ?
						"The request for the related videos feed of the video \'{0}\' completed successfully." :
						"The request for the related videos feed of the video \'{0}\' completed partially successfully. However, some errors have occurred.";

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
						new object[] { this.textBoxVideo.Text, this.linkLabel.Text },
						null,
						subevents));
				}
				catch (WebException exception)
				{
					if (exception.Status == WebExceptionStatus.RequestCanceled)
						this.log.Add(this.crawler.Log.Add(
							LogEventLevel.Verbose,
							LogEventType.Canceled,
							this.logSource,
							"The request for the related videos feed of the video \'{0}\' has been canceled.",
							new object[] { this.textBoxVideo.Text, this.linkLabel.Text }));
					else
						this.log.Add(this.crawler.Log.Add(
							LogEventLevel.Important,
							LogEventType.Error,
							this.logSource,
							"The request for the related videos feed of the video \'{0}\' failed. {1}",
							new object[] { this.textBoxVideo.Text, exception.Message, this.linkLabel.Text },
							exception));
				}
				catch (Exception exception)
				{
					this.log.Add(this.crawler.Log.Add(
						LogEventLevel.Important,
						LogEventType.Error,
						this.logSource,
						"The request for the related videos feed of the video \'{0}\' failed. {1}",
						new object[] { this.textBoxVideo.Text, exception.Message, this.linkLabel.Text },
						exception));
				}
				finally
				{
					this.buttonStart.Enabled = true;
					this.buttonStop.Enabled = false;
					this.textBoxVideo.Enabled = true;
				}
			}
		}

		/// <summary>
		/// An event handler called when the selected video has changed.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void VideoSelectedChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			// Change the enabled state of the view video button.
			this.checkBoxView.Enabled = this.videoList.SelectedItem != null;
		}

		/// <summary>
		/// An event handler for the visualization of a video entry menu.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void ViewVideo(object sender, EventArgs e)
		{
			if(this.checkBoxView.Checked)
				this.viewMenu.Show(this.checkBoxView, 0, this.checkBoxView.Height);
		}

		/// <summary>
		/// An event handler called when the video entry menu was closed.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void ViewMenuClosed(object sender, ToolStripDropDownClosedEventArgs e)
		{
			this.checkBoxView.Checked = false;
		}

		/// <summary>
		/// An event handler called when the user selects the option to view the video entry
		/// in the YouTube API version 2.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void ViewApiV2(object sender, EventArgs e)
		{
			if (this.ViewVideoInApiV2 != null) this.ViewVideoInApiV2(this.videoList.SelectedItem.Tag as Video);
		}

		/// <summary>
		/// An event handler called when the user selects the option to view the related videos
		/// in the YouTube API version 2.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void ViewApiV2Related(object sender, EventArgs e)
		{
			if (this.ViewVideoRelatedInApiV2 != null) this.ViewVideoRelatedInApiV2(this.videoList.SelectedItem.Tag as Video);
		}

		/// <summary>
		/// An event handler called when the user selects the option to view the response videos
		/// in the YouTube API version 2.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void ViewApiV2Responses(object sender, EventArgs e)
		{
			if (this.ViewVideoResponsesInApiV2 != null) this.ViewVideoResponsesInApiV2(this.videoList.SelectedItem.Tag as Video);
		}

		/// <summary>
		/// An event handler called when the user selects the option to view the video entry
		/// in the YouTube API version 3.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void ViewApiV3(object sender, EventArgs e)
		{
			if (this.ViewVideoInApiV3 != null) this.ViewVideoInApiV3(this.videoList.SelectedItem.Tag as Video);
		}

		/// <summary>
		/// An event handler called when the user selects the option to view the video statistics
		/// in the YouTube web.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void ViewWeb(object sender, EventArgs e)
		{
			if (this.ViewVideoInWeb != null) this.ViewVideoInWeb(this.videoList.SelectedItem.Tag as Video);
		}

		/// <summary>
		/// An event handler called when the user selects the option to open the video in YouTube in
		/// a browser.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OpenYouTube(object sender, EventArgs e)
		{
			// Get the video;
			Video video = this.videoList.SelectedItem.Tag as Video;
			// Open the video link in the browser.
			Process.Start(YouTubeUri.GetYouTubeLink(video.Id));
		}

		/// <summary>
		/// An event handler called when the user adds a comment to a video.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnComment(object sender, EventArgs e)
		{
			if (this.Comment != null) this.Comment((this.videoList.SelectedItem.Tag as Video).Id);
		}

		/// <summary>
		/// An event handler called when the user navigates to the previous page in the feed list.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void NavigatePrevious(object sender, EventArgs e)
		{
			// If the current feed is null, disable the button and return.
			if ((null == this.feed) || (null == this.feed.Links.Previous))
			{
				this.videoList.Previous = false;
				return;
			}
			// Copy the URL.
			this.uri = this.feed.Links.Previous;
			// Set the link label.
			this.linkLabel.Text = this.uri.AbsoluteUri;
			// Clear the feed.
			this.feed = null;
			// Clear the video list.
			this.videoList.Clear();
			// Start a new request.
			this.Start(sender, e);
		}

		/// <summary>
		/// An event handler called when the user navigates to the next page in the feed list.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void NavigateNext(object sender, EventArgs e)
		{
			// If the current feed is null, disable the button and return.
			if ((null == this.feed) || (null == this.feed.Links.Next))
			{
				this.videoList.Next = false;
				return;
			}
			// Copy the URL.
			this.uri = this.feed.Links.Next;
			// Set the link label.
			this.linkLabel.Text = this.uri.AbsoluteUri;
			// Clear the feed.
			this.feed = null;
			// Clear the video list.
			this.videoList.Clear();
			// Start a new request.
			this.Start(sender, e);
		}

		/// <summary>
		/// An event handler called when the user selects to view the video properties.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void ViewProperties(object sender, EventArgs e)
		{
			this.videoList.ShowProperties();
		}
	}
}
