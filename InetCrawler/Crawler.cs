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
using System.Windows.Forms;
using InetApi.YouTube.Api.V2;
using InetApi.YouTube.Api.V2.Data;
using InetCrawler.Database;
using InetCrawler.Events;
using InetCrawler.Log;
using InetCrawler.Spider;
using InetCrawler.Status;
using InetCrawler.Testing;
using Microsoft.Win32;

namespace InetCrawler
{
	/// <summary>
	/// A class representing the YouTube crawler.
	/// </summary>
	public sealed class Crawler : IDisposable
	{
		private CrawlerConfig config;
		private YouTubeSettings settings;
		private YouTubeCategories categories;
		private Logger log;
		private Status.Status status;
		private Comments.Comments comments;
		private DbServers servers;
		private Spiders spiders;
		private Testing.Testing testing;
		private readonly static CrawlerNetwork network = new CrawlerNetwork();

		/// <summary>
		/// Creates a new crawer global object, based on a configuration from the specified root registry key.
		/// </summary>
		/// <param name="rootKey">The root registry key.</param>
		/// <param name="rootPath">The root registry path.</param>
		public Crawler(RegistryKey rootKey, string rootPath)
		{
			// Read the crawler configuration
			this.config = new CrawlerConfig(rootKey, rootPath);

			// Create the YouTube settings
			this.settings = new YouTubeSettings(this.config.YouTubeV2ApiKey);

			// Create the YouTube categories
			this.categories = new YouTubeCategories(this.config.YouTubeCategoriesFileName);

			// Create the logger.
			this.log = new Logger(this.Config.LogFileName);

			// Create the status.
			this.status = new Status.Status();

			// Create the comments.
			this.comments = new Comments.Comments(this.config);

			// Create the database servers.
			this.servers = new DbServers(this.config);

			// Create the crawler spiders.
			this.spiders = new Spiders(this);

			// Create the crawler testing.
			this.testing = new Testing.Testing(rootKey, rootPath);
		}

		// Public events.

		/// <summary>
		/// An event raised when selecting a page.
		/// </summary>
		public event PageSelectionEventHandler PageSelected;

		/// <summary>
		/// An event raised when selecting the PlanetLab sites.
		/// </summary>
		public event EventHandler PlanetLabSitesSelected;
		/// <summary>
		/// An event raised when selecting the PlanetLab nodes.
		/// </summary>
		public event EventHandler PlanetLabNodesSelected;
		/// <summary>
		/// An event raised when selecting the PlanetLab slices.
		/// </summary>
		public event EventHandler PlanetLabSlicesSelected;
		
		//public event ControlEventHandler PlanetLabSliceAdded;
		//public event ControlEventHandler PlanelLabSliceRemoved;

		/// <summary>
		/// An event raised when selecting the YouTube video feeds page.
		/// </summary>
		public event EventHandler YouTubeVideoFeedsSelected;
		/// <summary>
		/// An event raised when selecting the YouTube user feeds page.
		/// </summary>
		public event EventHandler YouTubeUserFeedsSelected;
		/// <summary>
		/// An event raised when selecting the YouTube categories page.
		/// </summary>
		public event EventHandler YouTubeCategoriesSelected;

		/// <summary>
		/// An event raised when selecting the YouTube video page.
		/// </summary>
		public event EventHandler YouTubeVideoSelected;
		/// <summary>
		/// An event raised when selecting the YouTube video comments page.
		/// </summary>
		public event EventHandler YouTubeVideoCommentsSelected;
		/// <summary>
		/// An event raised when selecting the YouTube search feed page.
		/// </summary>
		public event EventHandler YouTubeSearchFeedSelected;
		/// <summary>
		/// An event raised when selecting the YouTube standard feed page.
		/// </summary>
		public event EventHandler YouTubeStandardFeedSelected;
		/// <summary>
		/// An event raised when selecting the YouTube related videos feed page.
		/// </summary>
		public event EventHandler YouTubeRelatedVideosFeedSelected;
		/// <summary>
		/// An event raised when selecting the YouTube response videos feed page.
		/// </summary>
		public event EventHandler YouTubeResponseVideosFeedSelected;

		/// <summary>
		/// An event raised when selecting the YouTube user profile page.
		/// </summary>
		public event EventHandler YouTubeUserSelected;
		/// <summary>
		/// An event raised when selecting the YouTube user uploads page.
		/// </summary>
		public event EventHandler YouTubeUploadsFeedSelected;
		/// <summary>
		/// An event raised when selecting the YouTube user favorites page.
		/// </summary>
		public event EventHandler YouTubeFavoritesFeedSelected;
		/// <summary>
		/// An event raised when selecting the YouTube user playlists page.
		/// </summary>
		public event EventHandler YouTubePlaylistsFeedSelected;
		/// <summary>
		/// An event raised when selecting the YouTube user playlist page.
		/// </summary>
		public event EventHandler YouTubePlaylistFeedSelected;

		/// <summary>
		/// An event raised when selecting the YouTube videos web page.
		/// </summary>
		public event EventHandler YouTubeWebVideosSelected;

		/// <summary>
		/// An event raised when opening a YouTube APIv2 video.
		/// </summary>
		public event VideoEventHandler YouTubeApiV2VideoOpened;
		/// <summary>
		/// An event raised when opening a YouTube APIv2 video comment.
		/// </summary>
		public event StringEventHandler YouTubeApiV2VideoCommentOpened;
		/// <summary>
		/// An event raised when opening a YouTube APIv2 user.
		/// </summary>
		public event StringEventHandler YouTubeApiV2UserOpened;
		/// <summary>
		/// An event raised when opening a YouTube APIv2 related videos.
		/// </summary>
		public event VideoEventHandler YouTubeApiV2RelatedVideosOpened;
		/// <summary>
		/// An event raised when opening a YouTube APIv2 response videos. 
		/// </summary>
		public event VideoEventHandler YouTubeApiV2ResponseVideosOpened;

		/// <summary>
		/// An event raised when opening the YouTube APIv2 user uploads.
		/// </summary>
		public event ProfileEventHandler YouTubeApiV2UserUploadsOpened;
		/// <summary>
		/// An event raisd when opening the YouTube APIv2 user favorites.
		/// </summary>
		public event ProfileEventHandler YouTubeApiV2UserFavoritesOpened;
		/// <summary>
		/// An event raised when opening the YouTube APIv2 user playlists.
		/// </summary>
		public event ProfileEventHandler YouTubeApiV2UserPlaylistsOpened;

		/// <summary>
		/// An event raised when opening a YouTube APIv2 playlist.
		/// </summary>
		public event StringEventHandler YouTubeApiV2PlaylistOpened;

		/// <summary>
		/// An event raised when opening a YouTube web video.
		/// </summary>
		public event VideoEventHandler YouTubeWebVideoOpened;

		/// <summary>
		/// An event raised when the user selects the video comments.
		/// </summary>
		public event EventHandler CommentsYouTubeVideosSelected;
		/// <summary>
		/// An event raised when the user selects the user comments.
		/// </summary>
		public event EventHandler CommentsYouTubeUsersSelected;
		/// <summary>
		/// An event raised when the user selects the playlist comments.
		/// </summary>
		public event EventHandler CommentsYouTubePlaylistsSelected;

		/// <summary>
		/// An event raised when commenting a YouTube video.
		/// </summary>
		public event StringEventHandler YouTubeVideoCommented;
		/// <summary>
		/// An event raised when commenting a YouTube user.
		/// </summary>
		public event StringEventHandler YouTubeUserCommented;
		/// <summary>
		/// An event raised when commenting a YouTube playlist.
		/// </summary>
		public event StringEventHandler YouTubePlaylistCommented;

		/// <summary>
		/// An event raised when selecting the standard feeds spider.
		/// </summary>
		public event EventHandler SpiderStandardFeedsSelected;

		// Public properties.

		/// <summary>
		/// Returns the crawler configuration.
		/// </summary>
		public CrawlerConfig Config { get { return this.config; } }
		/// <summary>
		/// Returns the YouTube settings.
		/// </summary>
		public YouTubeSettings Settings { get { return this.settings; } }
		/// <summary>
		/// Returns the YouTube categories.
		/// </summary>
		public YouTubeCategories Categories { get { return this.categories; } }
		/// <summary>
		/// Returns the crawler log.
		/// </summary>
		public Logger Log { get { return this.log; } }
		/// <summary>
		/// Returns the crawler status.
		/// </summary>
		public Status.Status Status { get { return this.status; } }
		/// <summary>
		/// Returns the crawler comments.
		/// </summary>
		public Comments.Comments Comments { get { return this.comments; } }
		/// <summary>
		/// Returns the database servers.
		/// </summary>
		public DbServers Servers { get { return this.servers; } }
		/// <summary>
		/// Returns the crawler spiders.
		/// </summary>
		public Spiders Spiders { get { return this.spiders; } }
		/// <summary>
		/// Returns the crawler testing configuration.
		/// </summary>
		public Testing.Testing Testing { get { return this.testing; } }
		/// <summary>
		/// Gets the network information.
		/// </summary>
		public static CrawlerNetwork Network { get { return Crawler.network; } }

		// Public methods.

		/// <summary>
		/// A method called when the object is disposed.
		/// </summary>
		public void Dispose()
		{
			// Call the dispose event handler.
			this.Dispose(true);
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Raises a page selection event.
		/// </summary>
		/// <param name="node">The tree node corresponding to the page.</param>
		public void SelectPage(TreeNode node)
		{
			if (null != this.PageSelected) this.PageSelected(this, new PageSelectionEventArgs(node));
		}
		
		/// <summary>
		/// Raises a PlanetLab sites selected event.
		/// </summary>
		public void SelectPlanetLabSites()
		{
			if (null != this.PlanetLabSitesSelected) this.PlanetLabSitesSelected(this, EventArgs.Empty);
		}

		/// <summary>
		/// Raises a PlanetLab nodes selected event.
		/// </summary>
		public void SelectPlanetLabNodes()
		{
			if (null != this.PlanetLabNodesSelected) this.PlanetLabNodesSelected(this, EventArgs.Empty);
		}

		/// <summary>
		/// Raises a PlanetLab slices selected event.
		/// </summary>
		public void SelectPlanetLabSlices()
		{
			if (null != this.PlanetLabSlicesSelected) this.PlanetLabSlicesSelected(this, EventArgs.Empty);
		}

		/// <summary>
		/// Raises a YouTube video feeds selected event.
		/// </summary>
		public void SelectYouTubeVideoFeeds()
		{
			if (null != this.YouTubeVideoFeedsSelected) this.YouTubeVideoFeedsSelected(this, EventArgs.Empty);
		}

		/// <summary>
		/// Raises a YouTube user feeds selected event.
		/// </summary>
		public void SelectYouTubeUserFeeds()
		{
			if (null != this.YouTubeUserFeedsSelected) this.YouTubeUserFeedsSelected(this, EventArgs.Empty);
		}

		/// <summary>
		/// Raises a YouTube categories selected event.
		/// </summary>
		public void SelectYouTubeCategories()
		{
			if (null != this.YouTubeCategoriesSelected) this.YouTubeCategoriesSelected(this, EventArgs.Empty);
		}

		/// <summary>
		/// Raises a YouTube video selected event.
		/// </summary>
		public void SelectYouTubeVideo()
		{
			if (null != this.YouTubeVideoSelected) this.YouTubeVideoSelected(this, EventArgs.Empty);
		}

		/// <summary>
		/// Raises a YouTube video comments selected event.
		/// </summary>
		public void SelectYouTubeVideoComments()
		{
			if (null != this.YouTubeVideoCommentsSelected) this.YouTubeVideoCommentsSelected(this, EventArgs.Empty);
		}

		/// <summary>
		/// Raises a YouTube search feed selected event.
		/// </summary>
		public void SelectYouTubeSearchFeed()
		{
			if (null != this.YouTubeSearchFeedSelected) this.YouTubeSearchFeedSelected(this, EventArgs.Empty);
		}

		/// <summary>
		/// Raises a YouTube standard feed selected event.
		/// </summary>
		public void SelectYouTubeStandardFeed()
		{
			if (null != this.YouTubeStandardFeedSelected) this.YouTubeStandardFeedSelected(this, EventArgs.Empty);
		}

		/// <summary>
		/// Raises a YouTube related videos feed selected event.
		/// </summary>
		public void SelectYouTubeRelatedVideosFeed()
		{
			if (null != this.YouTubeRelatedVideosFeedSelected) this.YouTubeRelatedVideosFeedSelected(this, EventArgs.Empty);
		}

		/// <summary>
		/// Raises a YouTube response videos feed selected event.
		/// </summary>
		public void SelectYouTubeResponseVideosFeed()
		{
			if (null != this.YouTubeResponseVideosFeedSelected) this.YouTubeResponseVideosFeedSelected(this, EventArgs.Empty);
		}

		/// <summary>
		/// Raises the YouTube user profile selected event.
		/// </summary>
		public void SelectYouTubeUser()
		{
			if (null != this.YouTubeUserSelected) this.YouTubeUserSelected(this, EventArgs.Empty);
		}

		/// <summary>
		/// Raises the YouTube user uploads selected event.
		/// </summary>
		public void SelectYouTubeUploadsFeed()
		{
			if (null != this.YouTubeUploadsFeedSelected) this.YouTubeUploadsFeedSelected(this, EventArgs.Empty);
		}

		/// <summary>
		/// Raises the YouTube user favorites selected event.
		/// </summary>
		public void SelectYouTubeFavoriesFeed()
		{
			if (null != this.YouTubeFavoritesFeedSelected) this.YouTubeFavoritesFeedSelected(this, EventArgs.Empty);
		}

		/// <summary>
		/// Raises the YouTube playlists feed selected event.
		/// </summary>
		public void SelectYouTubePlaylistsFeed()
		{
			if (null != this.YouTubePlaylistsFeedSelected) this.YouTubePlaylistsFeedSelected(this, EventArgs.Empty);
		}

		/// <summary>
		/// Raises the YouTube playlist feed selected event.
		/// </summary>
		public void SelectYouTubePlaylistFeed()
		{
			if (null != this.YouTubePlaylistFeedSelected) this.YouTubePlaylistFeedSelected(this, EventArgs.Empty);
		}

		/// <summary>
		/// Raises the YouTube web video selected event.
		/// </summary>
		public void SelectYouTubeWebVideos()
		{
			if (null != this.YouTubeWebVideosSelected) this.YouTubeWebVideosSelected(this, EventArgs.Empty);
		}

		/// <summary>
		/// Raises a YouTube open video event.
		/// </summary>
		/// <param name="video">The video.</param>
		public void OpenYouTubeVideo(Video video)
		{
			if (null != this.YouTubeApiV2VideoOpened) this.YouTubeApiV2VideoOpened(this, new VideoEventArgs(video));
		}

		/// <summary>
		/// Raises a YouTube open video comment event.
		/// </summary>
		/// <param name="video">The video.</param>
		public void OpenYouTubeVideoComment(string video)
		{
			if (null != this.YouTubeApiV2VideoCommentOpened) this.YouTubeApiV2VideoCommentOpened(this, new StringEventArgs(video));
		}

		/// <summary>
		/// Raises a YouTube open user event.
		/// </summary>
		/// <param name="user">The user.</param>
		public void OpenYouTubeUser(string user)
		{
			if (null != this.YouTubeApiV2UserOpened) this.YouTubeApiV2UserOpened(this, new StringEventArgs(user));
		}

		/// <summary>
		/// Raises a YouTube open related videos event.
		/// </summary>
		/// <param name="video">The video.</param>
		public void OpenYouTubeRelatedVideos(Video video)
		{
			if (null != this.YouTubeApiV2RelatedVideosOpened) this.YouTubeApiV2RelatedVideosOpened(this, new VideoEventArgs(video));
		}

		/// <summary>
		/// Raises a YouTube open response videos event.
		/// </summary>
		/// <param name="video">The video.</param>
		public void OpenYouTubeResponseVideos(Video video)
		{
			if (null != this.YouTubeApiV2ResponseVideosOpened) this.YouTubeApiV2ResponseVideosOpened(this, new VideoEventArgs(video));
		}

		/// <summary>
		/// Raises a YouTube open user uploads event.
		/// </summary>
		/// <param name="profile">The user profile.</param>
		public void OpenYouTubeUserUploads(Profile profile)
		{
			if (null != this.YouTubeApiV2UserUploadsOpened) this.YouTubeApiV2UserUploadsOpened(this, new ProfileEventArgs(profile));
		}

		/// <summary>
		/// Raises a YouTube open user favorites event.
		/// </summary>
		/// <param name="profile">The user profile.</param>
		public void OpenYouTubeUserFavorites(Profile profile)
		{
			if (null != this.YouTubeApiV2UserFavoritesOpened) this.YouTubeApiV2UserFavoritesOpened(this, new ProfileEventArgs(profile));
		}

		/// <summary>
		/// Raises a YouTube open user playlists event.
		/// </summary>
		/// <param name="profile">The user profile.</param>
		public void OpenYouTubeUserPlaylists(Profile profile)
		{
			if (null != this.YouTubeApiV2UserPlaylistsOpened) this.YouTubeApiV2UserPlaylistsOpened(this, new ProfileEventArgs(profile));
		}

		/// <summary>
		/// Raises a YouTube open playlist event.
		/// </summary>
		/// <param name="playlist">The playlist.</param>
		public void OpenYouTubePlaylist(string playlist)
		{
			if (null != this.YouTubeApiV2PlaylistOpened) this.YouTubeApiV2PlaylistOpened(this, new StringEventArgs(playlist));
		}

		/// <summary>
		/// Raises a YouTube open web video.
		/// </summary>
		/// <param name="video">The video.</param>
		public void OpenYouTubeWebVideo(Video video)
		{
			if (null != this.YouTubeWebVideoOpened) this.YouTubeWebVideoOpened(this, new VideoEventArgs(video));
		}

		/// <summary>
		/// Raises the video comments selected event.
		/// </summary>
		public void SelectVideoComments()
		{
			if (null != this.CommentsYouTubeVideosSelected) this.CommentsYouTubeVideosSelected(this, EventArgs.Empty);
		}

		/// <summary>
		/// Raises the user comments selected event.
		/// </summary>
		public void SelectUserComments()
		{
			if (null != this.CommentsYouTubeUsersSelected) this.CommentsYouTubeUsersSelected(this, EventArgs.Empty);
		}

		/// <summary>
		/// Raises the playlist comments selected event.
		/// </summary>
		public void SelectPlaylistComments()
		{
			if (null != this.CommentsYouTubePlaylistsSelected) this.CommentsYouTubePlaylistsSelected(this, EventArgs.Empty);
		}

		/// <summary>
		/// Raises a comment YouTube video event.
		/// </summary>
		/// <param name="video">The video.</param>
		public void CommentYouTubeVideo(string video)
		{
			if (null != this.YouTubeVideoCommented) this.YouTubeVideoCommented(this, new StringEventArgs(video));
		}

		/// <summary>
		/// Raises a comment YouTube user event.
		/// </summary>
		/// <param name="user">The user.</param>
		public void CommentYouTubeUser(string user)
		{
			if (null != this.YouTubeUserCommented) this.YouTubeUserCommented(this, new StringEventArgs(user));
		}

		/// <summary>
		/// Raises a comment YouTube playlist event.
		/// </summary>
		/// <param name="playlist">The playlist.</param>
		public void CommentYouTubePlaylist(string playlist)
		{
			if (null != this.YouTubePlaylistCommented) this.YouTubePlaylistCommented(this, new StringEventArgs(playlist));
		}

		/// <summary>
		/// Raises the standard feeds spider selected event.
		/// </summary>
		public void SelectStandardFeedsSpider()
		{
			if (null != this.SpiderStandardFeedsSelected) this.SpiderStandardFeedsSelected(this, EventArgs.Empty);
		}

		// Private methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		/// <param name="disposing">If <b>true</b>, clean both managed and native resources. If <b>false</b>, clean only native resources.</param>
		private void Dispose(bool disposing)
		{
			// Dispose the current objects.
			if (disposing)
			{
				// Close the database servers.
				this.servers.Dispose();
				// Close the log.
				this.log.Dispose();
				// Close the status.
				this.status.Dispose();
				// Close the comments.
				this.comments.Dispose();
				// Close the YouTube categories.
				this.categories.Dispose();
				// Close the spiders.
				this.spiders.Dispose();
				// Close the configuration.
				this.config.Dispose();
			}
		}
	}
}
