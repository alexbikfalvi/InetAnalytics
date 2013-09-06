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
using DotNetApi.Windows.Controls;
using YtAnalytics.Controls.Comments;
using YtAnalytics.Events;
using YtAnalytics.Forms.YouTube;
using YtApi;
using YtApi.Api.V2;
using YtApi.Api.V2.Atom;
using YtApi.Api.V2.Data;
using YtCrawler;
using YtCrawler.Log;

namespace YtAnalytics.Controls.YouTube.Api2
{
	/// <summary>
	/// A control class for a YouTube API version 2 standard feed.
	/// </summary>
	public partial class ControlYtApi2PlaylistsFeed : ThreadSafeControl
	{
		private static string logSource = "APIv2 Playlists Feed";

		// Private variables.

		private Crawler crawler;
		private Uri uri = null;
		private YouTubeRequestFeed<Playlist> request;
		private IAsyncResult result;
		private Feed<Playlist> feed = null;

		private FormPlaylistProperties formPlaylist = new FormPlaylistProperties();

		// Public declarations

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlYtApi2PlaylistsFeed()
		{
			// Initialize component.
			InitializeComponent();

			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;
		}

		// Public events.

		/// <summary>
		/// View the playlist author.
		/// </summary>
		public event StringEventHandler ViewPlaylistAuthorInApiV2;
		/// <summary>
		/// View the playlist videos.
		/// </summary>
		public event StringEventHandler ViewPlaylistVideosInApiV2;
		/// <summary>
		/// An event handler called when the user adds a new comment for the current playlist.
		/// </summary>
		public event StringEventHandler Comment;

		// Public methods.

		/// <summary>
		/// Initializes the control with a crawler object.
		/// </summary>
		/// <param name="crawler">The crawler object.</param>
		public void Initialize(Crawler crawler)
		{
			// Save the parameters.
			this.crawler = crawler;
			this.request = new YouTubeRequestFeed<Playlist>(this.crawler.Settings);
		
			// Enable the control
			this.Enabled = true;
		}

		/// <summary>
		/// Opens the playlists feed for the specified user.
		/// </summary>
		/// <param name="id">The user ID.</param>
		public void View(string id)
		{
			if (null == id) return;
			if (!this.textBoxUser.Enabled) return;
			this.textBoxUser.Text = id;
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
			if (this.textBoxUser.Text != string.Empty)
			{
				this.buttonStart.Enabled = true;
				this.uri = YouTubeUri.GetPlaylistsFeed(
					this.textBoxUser.Text,
					1,
					this.playlistsList.PlaylistsPerPage);
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
			this.textBoxUser.Enabled = false;

			// Log
			this.log.Add(this.crawler.Log.Add(
				LogEventLevel.Verbose,
				LogEventType.Information,
				ControlYtApi2PlaylistsFeed.logSource,
				"Started request for the related videos feed of the video \'{0}\'.",
				new object[] { this.textBoxUser.Text, this.linkLabel.Text }));

			// Clear the list view.
			this.playlistsList.Clear();

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
					ControlYtApi2PlaylistsFeed.logSource,
					"The request for the related videos feed of the video \'{0}\' failed. {1}",
					new object[] { this.textBoxUser.Text, exception.Message, this.linkLabel.Text },
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
			if (this.InvokeRequired)
				this.Invoke(new AsyncCallback(this.Callback), new object[] { result });
			else
			{
				try
				{
					// Complete the request
					this.feed = this.request.End(result);

					// Add the new items to the list view.
					foreach (Playlist playlist in feed.Entries)
					{
						this.playlistsList.Add(playlist);
					}

					// Update the page information.
					this.playlistsList.CountStart = feed.Entries.Count > 0 ? feed.SearchStartIndex : 0;
					this.playlistsList.CountPerPage = feed.Entries.Count;
					this.playlistsList.CountTotal = feed.SearchTotalResults;

					// Set the navigation buttons state.
					this.playlistsList.Previous = feed.Links.Previous != null;
					this.playlistsList.Next = feed.Links.Next != null;

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
								ControlYtApi2PlaylistsFeed.logSource,
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
								ControlYtApi2PlaylistsFeed.logSource,
								"Converting atom to YouTube API version 2 video entry failed.",
								null,
								exception));
						}
					}

					// Log
					this.log.Add(this.crawler.Log.Add(
						LogEventLevel.Verbose,
						eventType,
						ControlYtApi2PlaylistsFeed.logSource,
						eventMessage,
						new object[] { this.textBoxUser.Text, this.linkLabel.Text },
						null,
						subevents));
				}
				catch (WebException exception)
				{
					if (exception.Status == WebExceptionStatus.RequestCanceled)
						this.log.Add(this.crawler.Log.Add(
							LogEventLevel.Verbose,
							LogEventType.Canceled,
							ControlYtApi2PlaylistsFeed.logSource,
							"The request for the related videos feed of the video \'{0}\' has been canceled.",
							new object[] { this.textBoxUser.Text, this.linkLabel.Text }));
					else
						this.log.Add(this.crawler.Log.Add(
							LogEventLevel.Important,
							LogEventType.Error,
							ControlYtApi2PlaylistsFeed.logSource,
							"The request for the related videos feed of the video \'{0}\' failed. {1}",
							new object[] { this.textBoxUser.Text, exception.Message, this.linkLabel.Text },
							exception));
				}
				catch (Exception exception)
				{
					this.log.Add(this.crawler.Log.Add(
						LogEventLevel.Important,
						LogEventType.Error,
						ControlYtApi2PlaylistsFeed.logSource,
						"The request for the related videos feed of the video \'{0}\' failed. {1}",
						new object[] { this.textBoxUser.Text, exception.Message, this.linkLabel.Text },
						exception));
				}
				finally
				{
					this.buttonStart.Enabled = true;
					this.buttonStop.Enabled = false;
					this.textBoxUser.Enabled = true;
				}
			}
		}

		/// <summary>
		/// An event handler called when the user navigates to the previous page in the feed list.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNavigatePrevious(object sender, EventArgs e)
		{
			// If the current feed is null, disable the button and return.
			if ((null == this.feed) || (null == this.feed.Links.Previous))
			{
				this.playlistsList.Previous = false;
				return;
			}
			// Copy the URL.
			this.uri = this.feed.Links.Previous;
			// Set the link label.
			this.linkLabel.Text = this.uri.AbsoluteUri;
			// Clear the feed.
			this.feed = null;
			// Clear the video list.
			this.playlistsList.Clear();
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
			// If the current feed is null, disable the button and return.
			if ((null == this.feed) || (null == this.feed.Links.Next))
			{
				this.playlistsList.Next = false;
				return;
			}
			// Copy the URL.
			this.uri = this.feed.Links.Next;
			// Set the link label.
			this.linkLabel.Text = this.uri.AbsoluteUri;
			// Clear the feed.
			this.feed = null;
			// Clear the video list.
			this.playlistsList.Clear();
			// Start a new request.
			this.OnStart(sender, e);
		}

		/// <summary>
		/// An event handler for the visualization of a playlist entry menu.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnViewPlaylist(object sender, EventArgs e)
		{
			if (this.checkBoxView.Checked)
				this.viewMenu.Show(this.checkBoxView, 0, this.checkBoxView.Height);
		}

		/// <summary>
		/// An event handler called when the user selects to view the playlist author.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnViewAuthor(object sender, EventArgs e)
		{
			Playlist playlist = this.playlistsList.SelectedItem.Tag as Playlist;
			if (this.ViewPlaylistAuthorInApiV2 != null) this.ViewPlaylistAuthorInApiV2(this, new StringEventArgs(playlist.Author.UserId));
		}

		/// <summary>
		/// An event handler called when the user selects to view the playlist videos.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnViewVideos(object sender, EventArgs e)
		{
			Playlist playlist = this.playlistsList.SelectedItem.Tag as Playlist;
			if (this.ViewPlaylistVideosInApiV2 != null) this.ViewPlaylistVideosInApiV2(this, new StringEventArgs(playlist.Id));
		}

		/// <summary>
		/// An event handler called when the user selects to view the playlist in YouTube.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnOpenYouTube(object sender, EventArgs e)
		{
			Playlist playlist = this.playlistsList.SelectedItem.Tag as Playlist;
			// Open the user link in the browser.
			Process.Start(YouTubeUri.GetYouTubePlaylistLink(playlist.Id));
		}

		/// <summary>
		/// An event handler called when the user adds a new comment for a playlist.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAddComment(object sender, EventArgs e)
		{
			Playlist playlist = this.playlistsList.SelectedItem.Tag as Playlist;
			if (this.Comment != null) this.Comment(this, new StringEventArgs(playlist.Id));
		}

		/// <summary>
		/// An event handler called when the user opens the playlist properties.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnViewProperties(object sender, EventArgs e)
		{
			this.formPlaylist.ShowDialog(this, this.playlistsList.SelectedItem.Tag as Playlist);
		}

		/// <summary>
		/// An event handler called when the playlist selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelectionChanged(object sender, EventArgs e)
		{
			// Change the enabled state of the view video button.
			this.checkBoxView.Enabled = this.playlistsList.SelectedItem != null;
			if (this.playlistsList.SelectedItem != null)
				this.menuItemApiV2Author.Enabled = (this.playlistsList.SelectedItem.Tag as Playlist).Author != null;
			else
				this.menuItemApiV2Author.Enabled = false;
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
	}
}
