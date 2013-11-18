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
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using DotNetApi.Windows.Controls;
using InetAnalytics.Controls.Comments;
using InetAnalytics.Events;
using InetApi.YouTube.Api.V2;
using InetApi.YouTube.Api.V2.Data;
using InetCrawler;
using InetCrawler.Events;
using InetCrawler.Log;

namespace InetAnalytics.Controls.YouTube.Api2
{
	/// <summary>
	/// A class representing the control to browse the video entry in the YouTube API version 2.
	/// </summary>
	public partial class ControlYtApi2Video : ThreadSafeControl
	{
		private static readonly string logSource = "APIv2 Video Entry";

		private Crawler crawler;
		private YouTubeRequestVideo request;
		private IAsyncResult result;

		/// <summary>
		/// Creates a new instance of the control.
		/// </summary>
		public ControlYtApi2Video()
		{
			// Initialize component.
			InitializeComponent();

			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;
		}

		// Public methods.

		/// <summary>
		/// Initializes the control with a crawler instance.
		/// </summary>
		/// <param name="crawler">The crawler instance.</param>
		public void Initialize(Crawler crawler)
		{
			this.crawler = crawler;
			this.request = new YouTubeRequestVideo(this.crawler.YouTube.Settings);
		}

		/// <summary>
		/// Opens the specified video object.
		/// </summary>
		/// <param name="video">The video.</param>
		public void Open(Video video)
		{
			if (!this.textBox.Enabled) return;
			this.controlVideo.Video = video;
			if (null == video) return;
			this.textBox.Text = video.Id;
			this.buttonView.Enabled = true;
			this.buttonComment.Enabled = true;
			this.menuItemAuthor.Enabled = video.Author != null;
		}

		// Private methods.

		/// <summary>
		/// Starts an asynchronous request for a video entry.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStart(object sender, EventArgs e)
		{
			// Validate the input.
			if (string.Empty == this.textBox.Text)
			{
				this.log.Add(this.crawler.Log.Add(
					LogEventLevel.Verbose,
					LogEventType.Stop,
					ControlYtApi2Video.logSource,
					"The video ID text box cannot be empty."));
				return;
			}

			// Change the controls state.
			this.buttonStart.Enabled = false;
			this.buttonStop.Enabled = true;
			this.textBox.Enabled = false;
			this.buttonView.Enabled = false;
			this.buttonComment.Enabled = false;

			// Log
			this.log.Add(this.crawler.Log.Add(
				LogEventLevel.Verbose,
				LogEventType.Information,
				ControlYtApi2Video.logSource,
				"Started request for video ID \'{0}\'.",
				new object[] { this.textBox.Text }));

			try
			{
				// Begin the request.
				this.result = this.request.Begin(this.textBox.Text, this.Callback);
			}
			catch (Exception exception)
			{
				// Set the video to null.
				this.controlVideo.Video = null;
				// Log the request result.
				this.log.Add(this.crawler.Log.Add(
					LogEventLevel.Important,
					LogEventType.Error,
					ControlYtApi2Video.logSource,
					"The request for video ID \'{0}\' failed. {1}",
					new object[] { this.textBox.Text, exception.Message},
					exception));
			}
		}

		/// <summary>
		/// Cancels an asynchronous request for a video entry.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStop(object sender, EventArgs e)
		{
			this.request.Cancel(this.result);
		}

		/// <summary>
		/// Processes the response of an asynchronous request for a video entry.
		/// </summary>
		/// <param name="result">The asynchronous result.</param>
		private void Callback(IAsyncResult result)
		{
			// Execute the code on the UI thread.
			this.Invoke(() =>
				{
					try
					{
						// Complete the request
						Video video = this.request.End(result);

						this.controlVideo.Video = video;
						this.buttonView.Enabled = true;
						this.buttonComment.Enabled = true;
						this.menuItemAuthor.Enabled = this.controlVideo.Video.Author != null;

						// Log
						this.log.Add(this.crawler.Log.Add(
							LogEventLevel.Verbose,
							LogEventType.Success,
							ControlYtApi2Video.logSource,
							"The request for video ID \'{0}\' completed successfully.",
							new object[] { this.textBox.Text }));
					}
					catch (WebException exception)
					{
						// Set the video to null.
						this.controlVideo.Video = null;
						// Log the request result.
						if (exception.Status == WebExceptionStatus.RequestCanceled)
							this.log.Add(this.crawler.Log.Add(
								LogEventLevel.Verbose,
								LogEventType.Canceled,
								ControlYtApi2Video.logSource,
								"The request for video ID \'{0}\' has been canceled.",
								new object[] { this.textBox.Text }));
						else
							this.log.Add(this.crawler.Log.Add(
								LogEventLevel.Important,
								LogEventType.Error,
								ControlYtApi2Video.logSource,
								"The request for video ID \'{0}\' failed. {1}",
								new object[] { this.textBox.Text, exception.Message },
								exception));
					}
					catch (Exception exception)
					{
						// Set the video to null.
						this.controlVideo.Video = null;
						// Log the request result.
						this.log.Add(this.crawler.Log.Add(
							LogEventLevel.Important,
							LogEventType.Error,
							ControlYtApi2Video.logSource,
							"The request for video ID \'{0}\' failed. {1}",
							new object[] { this.textBox.Text, exception.Message },
							exception));
					}
					finally
					{
						this.buttonStart.Enabled = true;
						this.buttonStop.Enabled = false;
						this.textBox.Enabled = true;
					}
				});
		}

		/// <summary>
		/// The event handler for when the user input has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnInputChanged(object sender, EventArgs e)
		{
			this.buttonStart.Enabled = !string.IsNullOrWhiteSpace(this.textBox.Text);
		}

		/// <summary>
		/// An event handler called when the user selects to open the author.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnViewAuthorClick(object sender, EventArgs e)
		{
			if (null == this.controlVideo.Video) return;
			if (null == this.controlVideo.Video.Author) return;
			this.crawler.Events.OpenYouTubeUser(this.controlVideo.Video.Author.UserId);
		}

		/// <summary>
		/// An event handler called when the user selects to open the video comments.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnViewCommentsClick(object sender, EventArgs e)
		{
			if (null == this.controlVideo.Video) return;
			this.crawler.Events.OpenYouTubeVideoComment(this.controlVideo.Video.Id);
		}

		/// <summary>
		/// An event handler called when the user selects to open the related videos.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnViewRelatedVideosClick(object sender, EventArgs e)
		{
			if (null == this.controlVideo.Video) return;
			this.crawler.Events.OpenYouTubeRelatedVideos(this.controlVideo.Video);
		}

		/// <summary>
		/// An event handler called when the user selects to open the response videos.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnViewResponseVideosClick(object sender, EventArgs e)
		{
			if (null == this.controlVideo.Video) return;
			this.crawler.Events.OpenYouTubeResponseVideos(this.controlVideo.Video);
		}

		/// <summary>
		/// An event handler called when the user selects to open the web statistics.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnWebStatisticsClick(object sender, EventArgs e)
		{
			if (null == this.controlVideo.Video) return;
			this.crawler.Events.OpenYouTubeWebVideo(this.controlVideo.Video);
		}

		/// <summary>
		/// An event handler called when the user selects to open the video in YouYube.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnOpenYouTubeClick(object sender, EventArgs e)
		{
			if (null == this.controlVideo.Video) return;
			// Open the video link in the browser.
			Process.Start(YouTubeUri.GetYouTubeVideoLink(this.controlVideo.Video.Id));
		}

		/// <summary>
		/// An event handler called when the user adds a comment for this video.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCommentClick(object sender, EventArgs e)
		{
			if (null == this.controlVideo.Video) return;
			this.crawler.Events.CommentYouTubeVideo(this.controlVideo.Video.Id);
		}

		/// <summary>
		/// An event handler called to view the user profile.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnViewProfile(object sender, EventArgs e)
		{
			this.crawler.Events.OpenYouTubeUser(this.controlVideo.Video.Author.UserId);
		}
	}
}
