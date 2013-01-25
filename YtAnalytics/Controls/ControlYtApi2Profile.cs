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
using YtCrawler.Log;
using YtAnalytics.Controls;

namespace YtAnalytics.Controls
{
	public delegate void ViewProfileEventHandler(Profile profile);

	/// <summary>
	/// A class representing the control to browse the video entry in the YouTube API version 2.
	/// </summary>
	public partial class ControlYtApi2Profile : UserControl
	{
		private static string logSource = "APIv2 Profile Entry";

		private Crawler crawler;
		private YouTubeRequestProfile request;
		private IAsyncResult result;

		/// <summary>
		/// Creates a new instance of the control.
		/// </summary>
		public ControlYtApi2Profile()
		{
			// Initialize component.
			InitializeComponent();

			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;
		}


		///// <summary>
		///// View the related videos.
		///// </summary>
		//public event ViewProfileEventHandler ViewVideoRelatedInApiV2;
		///// <summary>
		///// View the response videos.
		///// </summary>
		//public event ViewProfileEventHandler ViewVideoResponsesInApiV2;
		///// <summary>
		///// View the video statistics using the web.
		///// </summary>
		//public event ViewVideoEventHandler ViewVideoInWeb;
		///// <summary>
		///// An event handler called when the user adds a new comment.
		///// </summary>
		//public event AddVideoCommentEventHandler Comment;

		/// <summary>
		/// Initializes the control with a crawler instance.
		/// </summary>
		/// <param name="crawler">The crawler instance.</param>
		public void Initialize(Crawler crawler)
		{
			this.crawler = crawler;
			this.request = new YouTubeRequestProfile(this.crawler.Settings);
		}

		/// <summary>
		/// Displays the specified user profile.
		/// </summary>
		/// <param name="profile">The user profile.</param>
		public void View(Profile profile)
		{
			if (!this.textBox.Enabled) return;
			this.controlProfile.Profile = profile;
			if (null == profile) return;
			this.textBox.Text = profile.Id;
			this.buttonView.Enabled = true;
			this.buttonComment.Enabled = true;
		}

		/// <summary>
		/// Begins a query for the specified profile ID.
		/// </summary>
		/// <param name="id">The user profile ID.</param>
		public void View(string id)
		{
			if (!this.textBox.Enabled) return;
			this.textBox.Text = id;
			this.buttonView.Enabled = true;
			this.buttonComment.Enabled = true;
			// Begin the query.
			this.Start(this, null);
		}

		/// <summary>
		/// Starts an asynchronous request for a video entry.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void Start(object sender, EventArgs e)
		{
			// Validate the input.
			if (string.Empty == this.textBox.Text)
			{
				this.log.Add(this.crawler.Log.Add(
					LogEventLevel.Verbose,
					LogEventType.Stop,
					ControlYtApi2Profile.logSource,
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
				ControlYtApi2Profile.logSource,
				"Started request for user profile ID \'{0}\'.",
				new object[] { this.textBox.Text }));

			try
			{
				// Begin the request.
				this.result = this.request.Begin(this.textBox.Text, this.Callback);
			}
			catch (Exception exception)
			{
				this.log.Add(this.crawler.Log.Add(
					LogEventLevel.Important,
					LogEventType.Error,
					ControlYtApi2Profile.logSource,
					"The request for user profile ID \'{0}\' failed. {1}",
					new object[] { this.textBox.Text, exception.Message},
					exception));
			}
		}

		/// <summary>
		/// Cancels an asynchronous request for a video entry.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void Stop(object sender, EventArgs e)
		{
			this.request.Cancel(this.result);
		}

		/// <summary>
		/// Processes the response of an asynchronous request for a video entry.
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
					Profile profile = this.request.End(result);

					this.controlProfile.Profile = profile;
					this.buttonView.Enabled = true;
					this.buttonComment.Enabled = true;

					// Log
					this.log.Add(this.crawler.Log.Add(
						LogEventLevel.Verbose,
						LogEventType.Success,
						ControlYtApi2Profile.logSource,
						"The request for user profile ID \'{0}\' completed successfully.",
						new object[] { this.textBox.Text }));
				}
				catch (WebException exception)
				{
					if (exception.Status == WebExceptionStatus.RequestCanceled)
						this.log.Add(this.crawler.Log.Add(
							LogEventLevel.Verbose,
							LogEventType.Canceled,
							ControlYtApi2Profile.logSource,
							"The request for user profile ID \'{0}\' has been canceled.",
							new object[] { this.textBox.Text }));
					else
						this.log.Add(this.crawler.Log.Add(
							LogEventLevel.Important,
							LogEventType.Error,
							ControlYtApi2Profile.logSource,
							"The request for user profile ID \'{0}\' failed. {1}",
							new object[] { this.textBox.Text, exception.Message },
							exception));
				}
				catch (Exception exception)
				{
					this.log.Add(this.crawler.Log.Add(
						LogEventLevel.Important,
						LogEventType.Error,
						ControlYtApi2Profile.logSource,
						"The request for user profile ID \'{0}\' failed. {1}",
						new object[] { this.textBox.Text, exception.Message },
						exception));
				}
				finally
				{
					this.buttonStart.Enabled = true;
					this.buttonStop.Enabled = false;
					this.textBox.Enabled = true;
				}
			}
		}

		/// <summary>
		/// The event handler for when the user input has changed.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void InputChanged(object sender, EventArgs e)
		{
			this.buttonStart.Enabled = this.textBox.Text != string.Empty;
		}

		///// <summary>
		///// An event handler called when the user selects to open the related videos.
		///// </summary>
		///// <param name="sender">The sender object.</param>
		///// <param name="e">The event arguments.</param>
		private void OnRelatedVideosClick(object sender, EventArgs e)
		{
		//	if (null == this.controlVideo.Video) return;
		//	if (null != this.ViewVideoRelatedInApiV2) this.ViewVideoRelatedInApiV2(this.controlVideo.Video);
		}

		///// <summary>
		///// An event handler called when the user selects to open the response videos.
		///// </summary>
		///// <param name="sender">The sender object.</param>
		///// <param name="e">The event arguments.</param>
		private void OnResponseVideosClick(object sender, EventArgs e)
		{
		//	if (null == this.controlVideo.Video) return;
		//	if (null != this.ViewVideoResponsesInApiV2) this.ViewVideoResponsesInApiV2(this.controlVideo.Video);
		}

		///// <summary>
		///// An event handler called when the user selects to open the web statistics.
		///// </summary>
		///// <param name="sender">The sender object.</param>
		///// <param name="e">The event arguments.</param>
		private void OnWebStatisticsClick(object sender, EventArgs e)
		{
		//	if (null == this.controlVideo.Video) return;
		//	if (null != this.ViewVideoInWeb) this.ViewVideoInWeb(this.controlVideo.Video);
		}

		///// <summary>
		///// An event handler called when the user selects to open the video in YouYube.
		///// </summary>
		///// <param name="sender">The sender object.</param>
		///// <param name="e">The event arguments.</param>
		private void OnOpenYouTubeClick(object sender, EventArgs e)
		{
		//	if (null == this.controlVideo.Video) return;
		//	// Open the video link in the browser.
		//	Process.Start(YouTubeUri.GetYouTubeLink(this.controlVideo.Video.Id));
		}

		///// <summary>
		///// An event handler called when the user adds a comment for this video.
		///// </summary>
		///// <param name="sender">The sender object.</param>
		///// <param name="e">The event arguments.</param>
		private void OnCommentClick(object sender, EventArgs e)
		{
		//	if (null == this.controlVideo.Video) return;
		//	if (null != this.Comment) this.Comment(this.controlVideo.Video.Id);
		}
	}
}
