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
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Drawing;
using DotNetApi.Windows;
using DotNetApi.Windows.Controls;
using DotNetApi.Windows.Forms;
using DotNetApi.Windows.Themes;
using Microsoft.Win32;
using InetAnalytics.Controls;
using InetAnalytics.Controls.Comments;
using InetAnalytics.Controls.Database;
using InetAnalytics.Controls.Tools;
using InetAnalytics.Controls.Log;
using InetAnalytics.Controls.Spiders;
using InetAnalytics.Controls.PlanetLab;
using InetAnalytics.Controls.YouTube;
using InetAnalytics.Controls.YouTube.Api2;
using InetAnalytics.Controls.YouTube.Api3;
using InetAnalytics.Controls.YouTube.Web;
using InetApi.YouTube.Api.V2;
using InetApi.YouTube.Api.V2.Data;
using InetCommon.Net;
using InetCommon.Events;
using InetCommon.Status;
using InetCrawler;
using InetCrawler.Events;

namespace InetAnalytics.Forms
{
	public partial class FormMain : ThreadSafeForm
	{
		// Crawler.
		private Crawler crawler;

		// Theme.
		private readonly ThemeSettings themeSettings;

		// Tree view nodes.
		private TreeNode treeNodePlanetLab;
		private TreeNode treeNodePlanetLabSites;
		private TreeNode treeNodePlanetLabNodes;
		private TreeNode treeNodePlanetLabSlices;

		private TreeNode treeNodeDatabaseServers;

		private TreeNode treeNodeToolboxInfo;

		private TreeNode treeNodeSpidersLocal;
		private TreeNode treeNodeSpiderStandardFeeds;

		private TreeNode treeNodeYouTubeApi2;
		private TreeNode treeNodeYouTubeApi2VideosFeedsInfo;
		private TreeNode treeNodeYouTubeApi2Video;
		private TreeNode treeNodeYouTubeApi2VideoComments;
		private TreeNode treeNodeYouTubeApi2SearchFeed;
		private TreeNode treeNodeYouTubeApi2StandardFeed;
		private TreeNode treeNodeYouTubeApi2RelatedVideosFeed;
		private TreeNode treeNodeYouTubeApi2ResponseVideosFeed;
		private TreeNode treeNodeYouTubeApi2UserFeedsInfo;
		private TreeNode treeNodeYouTubeApi2User;
		private TreeNode treeNodeYouTubeApi2UploadsFeed;
		private TreeNode treeNodeYouTubeApi2FavoritesFeed;
		private TreeNode treeNodeYouTubeApi2Playlists;
		private TreeNode treeNodeYouTubeApi2PlaylistFeed;
		private TreeNode treeNodeYouTubeApi2VideoCategories;
		private TreeNode treeNodeYouTubeApi3;
		private TreeNode treeNodeYouTubeApi3Videos;
		private TreeNode treeNodeYouTubeWeb;
		private TreeNode treeNodeYouTubeWebVideos;

		private TreeNode treeNodeTasksInfo;
		private TreeNode treeNodeTasksAll;
		private TreeNode treeNodeTasksScheduled;
		private TreeNode treeNodeTasksRunning;

		private TreeNode treeNodeSettings;

		private TreeNode treeNodeComments;
		private TreeNode treeNodeCommentsVideos;
		private TreeNode treeNodeCommentsUsers;
		private TreeNode treeNodeCommentsPlaylists;

		// Panel control.
		private Control controlPanel = null;

		// Panel controls.

		private readonly ControlPlanetLabInfo controlPlanetLab = new ControlPlanetLabInfo();
		private readonly ControlSites controlPlanetLabSites = new ControlSites();
		private readonly ControlNodes controlPlanetLabNodes = new ControlNodes();
		private readonly ControlSlices controlPlanetLabSlices = new ControlSlices();

		private readonly ControlServersSql controlDatabaseServers = new ControlServersSql();

		private readonly ControlToolboxInfo controlToolboxInfo = new ControlToolboxInfo();

		private readonly ControlSpiderInfo controlSpiderInfo = new ControlSpiderInfo();
		private readonly ControlSpiderStandardFeeds controlSpiderStandardFeeds = new ControlSpiderStandardFeeds();

		private readonly ControlYtApi2Info controlYtApi2 = new ControlYtApi2Info();
		private readonly ControlYtApi2VideosFeedsInfo controlYtApi2VideosFeedsInfo = new ControlYtApi2VideosFeedsInfo();
		private readonly ControlYtApi2Video controlYtApi2Video = new ControlYtApi2Video();
		private readonly ControlYtApi2CommentsFeed controlYtApi2CommentsFeed = new ControlYtApi2CommentsFeed();
		private readonly ControlYtApi2Search controlYtApi2Search = new ControlYtApi2Search();
		private readonly ControlYtApi2StandardFeed controlYtApi2StandardFeed = new ControlYtApi2StandardFeed();
		private readonly ControlYtApi2VideosFeed controlYtApi2RelatedFeed = new ControlYtApi2VideosFeed();
		private readonly ControlYtApi2VideosFeed controlYtApi2ResponseFeed = new ControlYtApi2VideosFeed();
		private readonly ControlYtApi2UserFeedsInfo controlYtApi2UserFeedInfo = new ControlYtApi2UserFeedsInfo();
		private readonly ControlYtApi2Profile controlYtApi2Profile = new ControlYtApi2Profile();
		private readonly ControlYtApi2VideosFeed controlYtApi2UploadsFeed = new ControlYtApi2VideosFeed();
		private readonly ControlYtApi2PlaylistsFeed controlYtApi2PlaylistsFeed = new ControlYtApi2PlaylistsFeed();
		private readonly ControlYtApi2VideosFeed controlYtApi2PlaylistFeed = new ControlYtApi2VideosFeed();
		private readonly ControlYtApi2VideosFeed controlYtApi2FavoritesFeed = new ControlYtApi2VideosFeed();
		private readonly ControlYtApi2Categories controlYtApi2Categories = new ControlYtApi2Categories();
		private readonly ControlYtApi3Info controlYtApi3 = new ControlYtApi3Info();
		private readonly ControlWeb controlYtWeb = new ControlWeb();
		private readonly ControlWebStatistics controlYtWebStatistics = new ControlWebStatistics();

		private readonly ControlSettings controlSettings = new ControlSettings();

		private readonly ControlLog controlLog = new ControlLog();

		private readonly ControlCommentsInfo controlCommentsInfo = new ControlCommentsInfo();
		private readonly ControlComments controlCommentsVideos = new ControlComments();
		private readonly ControlComments controlCommentsUsers = new ControlComments();
		private readonly ControlComments controlCommentsPlaylists = new ControlComments();

		// Forms.
		private readonly FormAbout formAbout = new FormAbout();

		// Delegates.
		private readonly EventHandler actionNetworkStatusChanged;
		private readonly EventHandler actionNetworkStatusChecked;

		// Status.

		private ApplicationStatus.StatusType status = ApplicationStatus.StatusType.Unknown;

		/// <summary>
		/// Constructor for main form window.
		/// </summary>
		public FormMain(Crawler crawler)
		{
			// Initialize the component.
			this.InitializeComponent();

			// Get the theme settings.
			this.themeSettings = ToolStripManager.Renderer is ThemeRenderer ? (ToolStripManager.Renderer as ThemeRenderer).Settings : ThemeSettings.Default;

			// Initialize the crawler
			this.crawler = crawler;

			// Create the tree view items.
			this.treeNodePlanetLabSites = new TreeNode("Sites",
				this.imageList.Images.IndexOfKey("FolderClosedGlobe"),
				this.imageList.Images.IndexOfKey("FolderOpenGlobe"));
			this.treeNodePlanetLabNodes = new TreeNode("Nodes",
				this.imageList.Images.IndexOfKey("FolderClosedGlobe"),
				this.imageList.Images.IndexOfKey("FolderOpenGlobe"));
			this.treeNodePlanetLabSlices = new TreeNode("Slices",
				this.imageList.Images.IndexOfKey("FolderClosedGlobe"),
				this.imageList.Images.IndexOfKey("FolderOpenGlobe"));
			this.treeNodePlanetLab = new TreeNode("PlanetLab",
				this.imageList.Images.IndexOfKey("ServersGlobe"),
				this.imageList.Images.IndexOfKey("ServersGlobe"),
				new TreeNode[] {
					this.treeNodePlanetLabSites,
					this.treeNodePlanetLabNodes,
					this.treeNodePlanetLabSlices
				});

			this.treeNodeToolboxInfo = new TreeNode("Toolbox",
				this.imageList.Images.IndexOfKey("ServerToolbox"),
				this.imageList.Images.IndexOfKey("ServerToolbox")
				);

			this.treeNodeDatabaseServers = new TreeNode("Servers",
				this.imageList.Images.IndexOfKey("ServersDatabase"),
				this.imageList.Images.IndexOfKey("ServersDatabase"));

			this.treeNodeSpiderStandardFeeds = new TreeNode("Standard feeds",
				this.imageList.Images.IndexOfKey("Cube"),
				this.imageList.Images.IndexOfKey("Cube"));
			this.treeNodeSpidersLocal = new TreeNode("Local spiders",
				this.imageList.Images.IndexOfKey("ServerCube"),
				this.imageList.Images.IndexOfKey("ServerCube"),
				new TreeNode[] {
					this.treeNodeSpiderStandardFeeds
				});

			this.treeNodeYouTubeApi2VideoComments = new TreeNode("Comments",
				this.imageList.Images.IndexOfKey("FolderClosedComment"),
				this.imageList.Images.IndexOfKey("FolderOpenComment"));
			this.treeNodeYouTubeApi2Video = new TreeNode("Video",
				this.imageList.Images.IndexOfKey("FileVideo"),
				this.imageList.Images.IndexOfKey("FileVideo"),
				new TreeNode[] {
					this.treeNodeYouTubeApi2VideoComments
				});
			this.treeNodeYouTubeApi2SearchFeed = new TreeNode("Search",
				this.imageList.Images.IndexOfKey("FolderClosedVideo"),
				this.imageList.Images.IndexOfKey("FolderOpenVideo"));
			this.treeNodeYouTubeApi2StandardFeed = new TreeNode("Standard feeds",
				this.imageList.Images.IndexOfKey("FolderClosedVideo"),
				this.imageList.Images.IndexOfKey("FolderOpenVideo"));
			this.treeNodeYouTubeApi2RelatedVideosFeed = new TreeNode("Related videos feed",
				this.imageList.Images.IndexOfKey("FolderClosedVideo"),
				this.imageList.Images.IndexOfKey("FolderOpenVideo"));
			this.treeNodeYouTubeApi2ResponseVideosFeed = new TreeNode("Response videos feed",
				this.imageList.Images.IndexOfKey("FolderClosedVideo"),
				this.imageList.Images.IndexOfKey("FolderOpenVideo"));
			this.treeNodeYouTubeApi2VideosFeedsInfo = new TreeNode("Global videos",
				this.imageList.Images.IndexOfKey("FolderClosedVideo"),
				this.imageList.Images.IndexOfKey("FolderOpenVideo"),
				new TreeNode[] {
					this.treeNodeYouTubeApi2Video,
					this.treeNodeYouTubeApi2SearchFeed,
					this.treeNodeYouTubeApi2StandardFeed,
					this.treeNodeYouTubeApi2RelatedVideosFeed,
					this.treeNodeYouTubeApi2ResponseVideosFeed
				});
			this.treeNodeYouTubeApi2UploadsFeed = new TreeNode("Uploads feed",
				this.imageList.Images.IndexOfKey("FolderClosedVideo"),
				this.imageList.Images.IndexOfKey("FolderOpenVideo"));
			this.treeNodeYouTubeApi2PlaylistFeed = new TreeNode("Playlist feed",
				this.imageList.Images.IndexOfKey("FolderClosedVideo"),
				this.imageList.Images.IndexOfKey("FolderOpenVideo"));
			this.treeNodeYouTubeApi2Playlists = new TreeNode("Playlists",
				this.imageList.Images.IndexOfKey("FolderClosedPlayBlue"),
				this.imageList.Images.IndexOfKey("FolderOpenPlayBlue"),
				new TreeNode[] {
					this.treeNodeYouTubeApi2PlaylistFeed
				});
			this.treeNodeYouTubeApi2FavoritesFeed = new TreeNode("Favorites feed",
				this.imageList.Images.IndexOfKey("FolderClosedVideo"),
				this.imageList.Images.IndexOfKey("FolderOpenVideo"));
			this.treeNodeYouTubeApi2User = new TreeNode("User",
				this.imageList.Images.IndexOfKey("FileUser"),
				this.imageList.Images.IndexOfKey("FileUser"),
				new TreeNode[] {
					this.treeNodeYouTubeApi2UploadsFeed,
					this.treeNodeYouTubeApi2FavoritesFeed,
					this.treeNodeYouTubeApi2Playlists
				});
			this.treeNodeYouTubeApi2UserFeedsInfo = new TreeNode("User videos",
				this.imageList.Images.IndexOfKey("FolderClosedUser"),
				this.imageList.Images.IndexOfKey("FolderOpenUser"),
				new TreeNode[] {
					this.treeNodeYouTubeApi2User
				});
			this.treeNodeYouTubeApi2VideoCategories = new TreeNode("Video categories",
				this.imageList.Images.IndexOfKey("Categories"),
				this.imageList.Images.IndexOfKey("Categories"));
			this.treeNodeYouTubeApi2 = new TreeNode("YouTube API version 2",
				this.imageList.Images.IndexOfKey("ServerBrowse"),
				this.imageList.Images.IndexOfKey("ServerBrowse"),
				new TreeNode[] {
					this.treeNodeYouTubeApi2VideosFeedsInfo,
					this.treeNodeYouTubeApi2UserFeedsInfo,
					this.treeNodeYouTubeApi2VideoCategories
				});
			this.treeNodeYouTubeApi3Videos = new TreeNode("Videos",
				this.imageList.Images.IndexOfKey("FolderClosedVideo"),
				this.imageList.Images.IndexOfKey("FolderOpenVideo"));
			this.treeNodeYouTubeApi3 = new TreeNode("YouTube API version 3",
				this.imageList.Images.IndexOfKey("ServerBrowse"),
				this.imageList.Images.IndexOfKey("ServerBrowse"),
				new TreeNode[] {
					this.treeNodeYouTubeApi3Videos
				});
			this.treeNodeYouTubeWebVideos = new TreeNode("Videos",
				this.imageList.Images.IndexOfKey("FileGraphLine"),
				this.imageList.Images.IndexOfKey("FileGraphLine"));
			this.treeNodeYouTubeWeb = new TreeNode("YouTube Web",
				this.imageList.Images.IndexOfKey("GlobeBrowse"),
				this.imageList.Images.IndexOfKey("GlobeBrowse"),
				new TreeNode[] {
					this.treeNodeYouTubeWebVideos
				});

			this.treeNodeTasksRunning = new TreeNode("Running tasks",
				this.imageList.Images.IndexOfKey("FolderClosedPlayGreen"),
				this.imageList.Images.IndexOfKey("FolderOpenPlayGreen"));
			this.treeNodeTasksScheduled = new TreeNode("Scheduled tasks",
				this.imageList.Images.IndexOfKey("FolderClosedClock"),
				this.imageList.Images.IndexOfKey("FolderOpenClock"));
			this.treeNodeTasksAll = new TreeNode("All tasks",
				this.imageList.Images.IndexOfKey("FolderClosedTask"),
				this.imageList.Images.IndexOfKey("FolderOpenTask"));
			this.treeNodeTasksInfo = new TreeNode("Tasks",
				this.imageList.Images.IndexOfKey("ServerTask"),
				this.imageList.Images.IndexOfKey("ServerTask"),
				new TreeNode[] {
					this.treeNodeTasksRunning,
					this.treeNodeTasksScheduled,
					this.treeNodeTasksAll
				});

			this.treeNodeSettings = new TreeNode("Settings",
				this.imageList.Images.IndexOfKey("Settings"),
				this.imageList.Images.IndexOfKey("Settings"));

			this.treeNodeCommentsVideos = new TreeNode("Videos",
				this.imageList.Images.IndexOfKey("CommentVideo"),
				this.imageList.Images.IndexOfKey("CommentVideo"));
			this.treeNodeCommentsUsers = new TreeNode("Users",
				this.imageList.Images.IndexOfKey("CommentUser"),
				this.imageList.Images.IndexOfKey("CommentUser"));
			this.treeNodeCommentsPlaylists = new TreeNode("Playlists",
				this.imageList.Images.IndexOfKey("CommentPlay"),
				this.imageList.Images.IndexOfKey("CommentPlay"));
			this.treeNodeComments = new TreeNode("Comments",
				this.imageList.Images.IndexOfKey("Comments"),
				this.imageList.Images.IndexOfKey("Comments"),
				new TreeNode[] {
					this.treeNodeCommentsVideos,
					this.treeNodeCommentsUsers,
					this.treeNodeCommentsPlaylists
				});

			// Add the panel controls to the split container.
			this.splitContainer.Panel2.Controls.Add(this.controlPlanetLab);
			this.splitContainer.Panel2.Controls.Add(this.controlPlanetLabSites);
			this.splitContainer.Panel2.Controls.Add(this.controlPlanetLabNodes);
			this.splitContainer.Panel2.Controls.Add(this.controlPlanetLabSlices);
			this.splitContainer.Panel2.Controls.Add(this.controlDatabaseServers);
			this.splitContainer.Panel2.Controls.Add(this.controlToolboxInfo);
			this.splitContainer.Panel2.Controls.Add(this.controlSpiderInfo);
			this.splitContainer.Panel2.Controls.Add(this.controlSpiderStandardFeeds);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2VideosFeedsInfo);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2Video);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2CommentsFeed);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2StandardFeed);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2Search);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2RelatedFeed);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2ResponseFeed);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2UserFeedInfo);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2Profile);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2UploadsFeed);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2PlaylistsFeed);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2FavoritesFeed);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2PlaylistFeed);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2Categories);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi3);
			this.splitContainer.Panel2.Controls.Add(this.controlYtWeb);
			this.splitContainer.Panel2.Controls.Add(this.controlYtWebStatistics);
			this.splitContainer.Panel2.Controls.Add(this.controlSettings);
			this.splitContainer.Panel2.Controls.Add(this.controlLog);
			this.splitContainer.Panel2.Controls.Add(this.controlCommentsInfo);
			this.splitContainer.Panel2.Controls.Add(this.controlCommentsVideos);
			this.splitContainer.Panel2.Controls.Add(this.controlCommentsUsers);
			this.splitContainer.Panel2.Controls.Add(this.controlCommentsPlaylists);

			// Add the panel controls as tags.
			this.treeNodePlanetLab.Tag = this.controlPlanetLab;
			this.treeNodePlanetLabSites.Tag = this.controlPlanetLabSites;
			this.treeNodePlanetLabNodes.Tag = this.controlPlanetLabNodes;
			this.treeNodePlanetLabSlices.Tag = this.controlPlanetLabSlices;

			this.treeNodeDatabaseServers.Tag = this.controlDatabaseServers;

			this.treeNodeToolboxInfo.Tag = this.controlToolboxInfo;

			this.treeNodeSpidersLocal.Tag = this.controlSpiderInfo;
			this.treeNodeSpiderStandardFeeds.Tag = this.controlSpiderStandardFeeds;

			this.treeNodeYouTubeApi2.Tag = this.controlYtApi2;
			this.treeNodeYouTubeApi2VideosFeedsInfo.Tag = this.controlYtApi2VideosFeedsInfo;
			this.treeNodeYouTubeApi2Video.Tag = this.controlYtApi2Video;
			this.treeNodeYouTubeApi2VideoComments.Tag = this.controlYtApi2CommentsFeed;
			this.treeNodeYouTubeApi2SearchFeed.Tag = this.controlYtApi2Search;
			this.treeNodeYouTubeApi2StandardFeed.Tag = this.controlYtApi2StandardFeed;
			this.treeNodeYouTubeApi2RelatedVideosFeed.Tag = this.controlYtApi2RelatedFeed;
			this.treeNodeYouTubeApi2ResponseVideosFeed.Tag = this.controlYtApi2ResponseFeed;
			this.treeNodeYouTubeApi2UserFeedsInfo.Tag = this.controlYtApi2UserFeedInfo;
			this.treeNodeYouTubeApi2User.Tag = this.controlYtApi2Profile;
			this.treeNodeYouTubeApi2UploadsFeed.Tag = this.controlYtApi2UploadsFeed;
			this.treeNodeYouTubeApi2Playlists.Tag = this.controlYtApi2PlaylistsFeed;
			this.treeNodeYouTubeApi2FavoritesFeed.Tag = this.controlYtApi2FavoritesFeed;
			this.treeNodeYouTubeApi2PlaylistFeed.Tag = this.controlYtApi2PlaylistFeed;
			this.treeNodeYouTubeApi2VideoCategories.Tag = this.controlYtApi2Categories;
			this.treeNodeYouTubeApi3.Tag = this.controlYtApi3;
			this.treeNodeYouTubeWeb.Tag = this.controlYtWeb;
			this.treeNodeYouTubeWebVideos.Tag = this.controlYtWebStatistics;

			this.treeNodeSettings.Tag = this.controlSettings;
			this.controlSideLog.Tag = this.controlLog;
			this.treeNodeComments.Tag = this.controlCommentsInfo;
			this.treeNodeCommentsVideos.Tag = this.controlCommentsVideos;
			this.treeNodeCommentsUsers.Tag = this.controlCommentsUsers;
			this.treeNodeCommentsPlaylists.Tag = this.controlCommentsPlaylists;

			// Add the tree nodes to the side panel tree views.
			this.controlSidePlanetLab.Nodes.Add(this.treeNodePlanetLab);
			this.controlSideToolbox.Nodes.Add(this.treeNodeToolboxInfo);
			this.controlSideDatabase.Nodes.Add(this.treeNodeDatabaseServers);
			this.controlSideSpiders.Nodes.Add(this.treeNodeSpidersLocal);
			this.controlSideYouTube.Nodes.AddRange(
				new TreeNode[] {
					this.treeNodeYouTubeApi2,
					this.treeNodeYouTubeApi3,
					this.treeNodeYouTubeWeb
				});
			this.controlSideTasks.Nodes.Add(this.treeNodeTasksInfo);
			this.controlSideConfiguration.Nodes.Add(this.treeNodeSettings);
			this.controlSideComments.Nodes.Add(this.treeNodeComments);

			// Set the status event handler.
			this.crawler.Status.MessageChanged += this.OnStatusMessageChanged;
			this.crawler.Status.LockChanged += this.OnStatusLockChanged;

			// Set the crawler event handlers.

			this.crawler.Events.PageSelected += this.OnPageSelected;

			this.crawler.Events.PlanetLabSitesSelected += this.OnPlanetLabSitesSelected;
			this.crawler.Events.PlanetLabNodesSelected += this.OnPlanetLabNodesSelected;
			this.crawler.Events.PlanetLabSlicesSelected += this.OnPlanetLabSlicesSelected;

			this.crawler.Events.YouTubeVideoFeedsSelected += this.OnYouTubeApiV2VideosFeedsInfoSelected;
			this.crawler.Events.YouTubeUserFeedsSelected += this.OnYouTubeApiV2UserFeedsInfoSelected;
			this.crawler.Events.YouTubeCategoriesSelected += this.OnYouTubeApi2VideoCategoriesSelected;

			this.crawler.Events.YouTubeVideoSelected += this.OnYouTubeApiV2VideoSelected;
			this.crawler.Events.YouTubeVideoCommentsSelected += this.OnYouTubeApiV2VideoCommentsSelected;
			this.crawler.Events.YouTubeSearchFeedSelected += this.OnYouTubeApiV2SearchFeedSelected;
			this.crawler.Events.YouTubeStandardFeedSelected += this.OnYouTubeApiV2StandardFeedSelected;
			this.crawler.Events.YouTubeRelatedVideosFeedSelected += this.OnYouTubeApiV2RelatedVideosFeedSelected;
			this.crawler.Events.YouTubeResponseVideosFeedSelected += this.OnYouTubeApiV2ResponseVideosFeedSelected;

			this.crawler.Events.YouTubeUserSelected += this.OnYouTubeApiV2UserSelected;
			this.crawler.Events.YouTubeUploadsFeedSelected += this.OnYouTubeApiV2UserUploadsSelected;
			this.crawler.Events.YouTubeFavoritesFeedSelected += this.OnYouTubeApiV2UserFavoritesSelected;
			this.crawler.Events.YouTubePlaylistsFeedSelected += this.OnYouTubeApiV2UserPlaylistsSelected;
			this.crawler.Events.YouTubePlaylistFeedSelected += this.OnYouTubeApiV2PlaylistVideosSelected;

			this.crawler.Events.YouTubeApiV2VideoOpened += this.OnYouTubeApiV2VideoOpened;
			this.crawler.Events.YouTubeApiV2VideoCommentOpened += this.OnYouTubeApiV2VideoCommentOpened;
			this.crawler.Events.YouTubeApiV2RelatedVideosOpened += this.OnYouTubeApiV2RelatedVideosOpened;
			this.crawler.Events.YouTubeApiV2ResponseVideosOpened += this.OnYouTubeApiV2ResponseVideosOpened;

			this.crawler.Events.YouTubeApiV2UserOpened += this.OnYouTubeApiV2AuthorOpened;
			this.crawler.Events.YouTubeApiV2UserUploadsOpened += this.OnYouTubeApiV2UserUploadsOpened;
			this.crawler.Events.YouTubeApiV2UserFavoritesOpened += this.OnYouTubeApiV2UserFavoritesOpened;
			this.crawler.Events.YouTubeApiV2UserPlaylistsOpened += this.OnYouTubeApiV2UserPlaylistsOpened;

			this.crawler.Events.YouTubeApiV2PlaylistOpened += this.OnYouTubeApiV2PlaylistOpened;

			this.crawler.Events.YouTubeWebVideosSelected += this.OnYouTubeWebVideosSelected;
			this.crawler.Events.YouTubeWebVideoOpened += this.OnYouTubeWebVideoOpened;

			this.crawler.Events.CommentsYouTubeVideosSelected += this.OnYouTubeCommentsVideosSelected;
			this.crawler.Events.CommentsYouTubeUsersSelected += this.OnYouTubeCommentsUsersSelected;
			this.crawler.Events.CommentsYouTubePlaylistsSelected += this.OnYouTubeCommentsPlaylistsSelected;

			this.crawler.Events.YouTubeVideoCommented += this.OnYouTubeVideoCommented;
			this.crawler.Events.YouTubeUserCommented += this.OnYouTubeUserCommented;
			this.crawler.Events.YouTubePlaylistCommented += this.OnYouTubePlaylistCommented;

			this.crawler.Events.SpiderStandardFeedsSelected += this.OnSpiderStandardFeedsSelected;

			// Initialize the controls.
			this.controlPlanetLab.Initialize(this.crawler);
			this.controlPlanetLabSites.Initialize(this.crawler);
			this.controlPlanetLabNodes.Initialize(this.crawler);
			this.controlPlanetLabSlices.Initialize(this.crawler, this.treeNodePlanetLabSlices, this.splitContainer.Panel2.Controls);
			this.controlDatabaseServers.Initialize(this.crawler, this.treeNodeDatabaseServers, this.splitContainer.Panel2.Controls, this.imageList);
			this.controlToolboxInfo.Initialize(this.crawler, this.treeNodeToolboxInfo, this.splitContainer.Panel2.Controls);
			this.controlSpiderStandardFeeds.Initialize(this.crawler);
			this.controlYtApi2.Initialize(this.crawler);
			this.controlYtApi2VideosFeedsInfo.Initialize(this.crawler);
			this.controlYtApi2Video.Initialize(this.crawler);
			this.controlYtApi2CommentsFeed.Initialize(this.crawler);
			this.controlYtApi2StandardFeed.Initialize(this.crawler);
			this.controlYtApi2Search.Initialize(this.crawler);
			this.controlYtApi2RelatedFeed.Initialize(this.crawler, new VideosFeedEventHandler(YouTubeUri.GetRelatedVideosFeed), "&Video:", "related videos feed", "video", "APIv2 Related Videos Feed");
			this.controlYtApi2ResponseFeed.Initialize(this.crawler, new VideosFeedEventHandler(YouTubeUri.GetResponseVideosFeed), "&Video:", "response videos feed", "video", "APIv2 Response Videos Feed");
			this.controlYtApi2UserFeedInfo.Initailize(this.crawler);
			this.controlYtApi2Profile.Initialize(this.crawler);
			this.controlYtApi2PlaylistsFeed.Initialize(this.crawler);
			this.controlYtApi2UploadsFeed.Initialize(this.crawler, new VideosFeedEventHandler(YouTubeUri.GetUploadsFeed), "&User:", "uploads video feed", "user", "APIv2 Uploads Videos Feed");
			this.controlYtApi2FavoritesFeed.Initialize(this.crawler, new VideosFeedEventHandler(YouTubeUri.GetFavoritesFeed), "&User:", "favorites video feed", "user", "APIv2 Favorites Videos Feed");
			this.controlYtApi2PlaylistFeed.Initialize(this.crawler, new VideosFeedEventHandler(YouTubeUri.GetPlaylistFeed), "&Playlist:", "playlist video feed", "user", "APIv2 Playlist Videos Feed");
			this.controlYtApi2Categories.Initialize(this.crawler);
			this.controlYtWeb.Initialize(this.crawler);
			this.controlYtWebStatistics.Initialize(this.crawler);
			this.controlSettings.Initialize(this.crawler);
			this.controlLog.Initialize(this.crawler.Config, this.crawler.Log);
			this.controlCommentsVideos.Initialize(this.crawler.Comments.Videos, InetCrawler.Comments.CrawlerComment.CommentType.Video);
			this.controlCommentsUsers.Initialize(this.crawler.Comments.Users, InetCrawler.Comments.CrawlerComment.CommentType.User);
			this.controlCommentsPlaylists.Initialize(this.crawler.Comments.Playlists, InetCrawler.Comments.CrawlerComment.CommentType.Playlist);

			// Set the selected control.
			this.controlPanel = this.labelNotAvailable;

			// Initialize the side controls.
			this.controlSidePlanetLab.Initialize();
			this.controlSideToolbox.Initialize();
			this.controlSideDatabase.Initialize();
			this.controlSideSpiders.Initialize();
			this.controlSideYouTube.Initialize();
			this.controlSideTasks.Initialize();
			this.controlSideLog.Initialize();
			this.controlSideConfiguration.Initialize();
			this.controlSideComments.Initialize();

			// Configure the side menu with the last saved configuration.
			this.sideMenu.VisibleItems = this.crawler.Config.ConsoleSideMenuVisibleItems;
			this.sideMenu.SelectedIndex = this.crawler.Config.ConsoleSideMenuSelectedItem;
			if (this.sideMenu.SelectedItem.HasControl && this.sideMenu.SelectedItem.Control.HasSelected())
			{
				this.sideMenu.SelectedItem.Control.SetSelected(this.crawler.Config.ConsoleSideMenuSelectedNode);
			}

			// Create the network status event handler.
			this.actionNetworkStatusChanged = new EventHandler(this.OnNetworkStatusChanged);
			this.actionNetworkStatusChecked = new EventHandler(this.OnNetworkStatusChecked);
			// Set the network availability event handler.
			Crawler.Network.NetworkChanged += this.actionNetworkStatusChanged;
			Crawler.Network.NetworkChecked += this.actionNetworkStatusChecked;
			// Update the network status.
			this.OnNetworkStatusChanged(this, EventArgs.Empty);

			// Set the font.
			Window.SetFont(this);
		}

		// Protected methods.

		/// <summary>
		/// An event handler called when the form is being closed.
		/// </summary>
		/// <param name="e">The event arguments.</param>
		protected override void OnClosing(CancelEventArgs e)
		{
			// Check the status is locked.
			if (this.crawler.Status.IsLocked)
			{
				// Show a message.
				MessageBox.Show(
					this,
					"The Internet Analytics is running one or more background operations. You must stop them before closing the program.",
					"Internet Analytics Background",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				// Cancel the closing request.
				e.Cancel = true;
				// Return.
				return;
			}
			// Save the configuration.
			this.crawler.Config.ConsoleSideMenuVisibleItems = this.sideMenu.VisibleItems;
			this.crawler.Config.ConsoleSideMenuSelectedItem = this.sideMenu.SelectedIndex ?? 0;
			if (this.sideMenu.SelectedItem.HasControl)
			{
				this.crawler.Config.ConsoleSideMenuSelectedNode = this.sideMenu.SelectedItem.Control.GetSelected();
			}
			// Call the base class event handler.
			base.OnClosing(e);
		}

		// Private methods.

		/// <summary>
		/// An event handler called when the selected side menu log has changed.
		/// </summary>
		/// <param name="item">The side menu item.</param>
		private void OnSideMenuSelectLog(SideMenuItem item)
		{
			// Refresh the log.
			this.controlLog.DateChanged(this, new DateRangeEventArgs(this.controlSideLog.Calendar.SelectionStart, this.controlSideLog.Calendar.SelectionEnd));
		}

		/// <summary>
		/// An event handler called when the right panel control selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnControlChanged(object sender, ControlChangedEventArgs e)
		{
			// If the selected control has not changed, do nothing.
			if (e.Control == this.controlPanel) return;

			// If there exists a current control.
			if (null != this.controlPanel)
			{
				// Hide the current control.
				this.controlPanel.Hide();
			}

			// If the control is not null.
			if (null != e.Control)
			{
				// Show the control.
				e.Control.Show();
				// Activate the control status.
				this.crawler.Status.Activate(e.Control);
				// Set the selected control.
				this.controlPanel = e.Control;
			}
			else
			{
				// Display the default message.
				this.labelNotAvailable.Show();
				// Set the selected control.
				this.controlPanel = this.labelNotAvailable;
			}
		}

		/// <summary>
		/// An event handler called when changing the status message.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStatusMessageChanged(object sender, ApplicationStatusMessageEventArgs e)
		{
			// Call the code on the UI thread.
			this.Invoke(() =>
				{
					if (e.Message.HasValue)
					{
						// If the status type has changed.
						if (e.Message.Value.Type != this.status)
						{
							// Update the status.
							switch (e.Message.Value.Type)
							{
								case ApplicationStatus.StatusType.Ready:
									this.statusStrip.BackColor = this.themeSettings.ColorTable.StatusStripReadyBackground;
									this.statusLabelLeft.ForeColor = this.themeSettings.ColorTable.StatusStripReadyText;
									this.statusLabelRight.ForeColor = this.themeSettings.ColorTable.StatusStripReadyText;
									this.statusLabelConnection.ForeColor = this.themeSettings.ColorTable.StatusStripReadyText;
									this.statusLabelRun.ForeColor = this.themeSettings.ColorTable.StatusStripReadyText;
									break;
								case ApplicationStatus.StatusType.Normal:
									this.statusStrip.BackColor = this.themeSettings.ColorTable.StatusStripNormalBackground;
									this.statusLabelLeft.ForeColor = this.themeSettings.ColorTable.StatusStripNormalText;
									this.statusLabelRight.ForeColor = this.themeSettings.ColorTable.StatusStripNormalText;
									this.statusLabelConnection.ForeColor = this.themeSettings.ColorTable.StatusStripNormalText;
									this.statusLabelRun.ForeColor = this.themeSettings.ColorTable.StatusStripNormalText;
									break;
								case ApplicationStatus.StatusType.Busy:
									this.statusStrip.BackColor = this.themeSettings.ColorTable.StatusStripBusyBackground;
									this.statusLabelLeft.ForeColor = this.themeSettings.ColorTable.StatusStripBusyText;
									this.statusLabelRight.ForeColor = this.themeSettings.ColorTable.StatusStripBusyText;
									this.statusLabelConnection.ForeColor = this.themeSettings.ColorTable.StatusStripBusyText;
									this.statusLabelRun.ForeColor = this.themeSettings.ColorTable.StatusStripBusyText;
									break;
							}
							// Set the new status.
							this.status = e.Message.Value.Type;
						}
						this.statusLabelLeft.Image = e.Message.Value.LeftImage;
						this.statusLabelLeft.Text = e.Message.Value.LeftText;
						this.statusLabelRight.Image = e.Message.Value.RightImage;
						this.statusLabelRight.Text = e.Message.Value.RightText;
					}
					else
					{
						this.statusStrip.BackColor = this.themeSettings.ColorTable.StatusStripReadyBackground;
						this.statusLabelLeft.ForeColor = this.themeSettings.ColorTable.StatusStripReadyText;
						this.statusLabelRight.ForeColor = this.themeSettings.ColorTable.StatusStripReadyText;
						this.statusLabelConnection.ForeColor = this.themeSettings.ColorTable.StatusStripReadyText;
						this.statusLabelRun.ForeColor = this.themeSettings.ColorTable.StatusStripReadyText;
						this.statusLabelLeft.Image = Resources.Information_16;
						this.statusLabelLeft.Text = "Ready.";
						this.statusLabelRight.Image = null;
						this.statusLabelRight.Text = null;
						this.status = ApplicationStatus.StatusType.Ready;
					}
				});
		}

		/// <summary>
		/// An event handler called when the status lock has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStatusLockChanged(object sender, EventArgs e)
		{
			this.Invoke(() =>
				{
					// Get the number of locks.
					int count = this.crawler.Status.LockCount;
					// Update the lock information.
					if (count > 0)
					{
						this.statusLabelRun.Text = "{0} background task{1}".FormatWith(count, count.PluralSuffix());
						this.statusLabelRun.Image = Resources.RunConcurrentStart_16;
					}
					else
					{
						this.statusLabelRun.Text = "No background tasks";
						this.statusLabelRun.Image = Resources.RunConcurrentStop_16;
					}
				});
		}

		/// <summary>
		/// An event handler called when a page is selected.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnPageSelected(object sender, PageSelectionEventArgs e)
		{
			if (e.Node.TreeView != null)
			{
				e.Node.TreeView.SelectedNode = e.Node;
			}
		}

		/// <summary>
		/// An event handler called when the user selects the PlanetLab sites page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnPlanetLabSitesSelected(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemPlanetLab;
			this.controlSidePlanetLab.SelectedNode = this.treeNodePlanetLabSites;
		}

		/// <summary>
		/// An event handler called when the user selects the PlanetLab nodes page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnPlanetLabNodesSelected(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemPlanetLab;
			this.controlSidePlanetLab.SelectedNode = this.treeNodePlanetLabNodes;
		}

		/// <summary>
		/// An event handler called when the user selects the PlanetLab slices page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnPlanetLabSlicesSelected(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemPlanetLab;
			this.controlSidePlanetLab.SelectedNode = this.treeNodePlanetLabSlices;
		}

		/// <summary>
		/// An event handler called when the user selects the YouTube APIv2 videos feeds information page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeApiV2VideosFeedsInfoSelected(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2VideosFeedsInfo;
		}

		/// <summary>
		/// An event handler called when the user selects the YouTube APIv2 user feeds information page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeApiV2UserFeedsInfoSelected(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2UserFeedsInfo;
		}

		/// <summary>
		/// An event handler called when the user selects the video categories page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeApi2VideoCategoriesSelected(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2VideoCategories;
		}

		/// <summary>
		/// An event handler called when the user selects the video page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeApiV2VideoSelected(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2Video;
		}

		/// <summary>
		/// An event handler called when the user selects the video comments page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeApiV2VideoCommentsSelected(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2VideoComments;
		}

		/// <summary>
		/// An event handler called when the user selects the search feed page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeApiV2SearchFeedSelected(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2SearchFeed;
		}

		/// <summary>
		/// An event handler called when the user selects the standard feed page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeApiV2StandardFeedSelected(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2StandardFeed;
		}

		/// <summary>
		/// An event handler called when user selects the related videos feed page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeApiV2RelatedVideosFeedSelected(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2RelatedVideosFeed;
		}

		/// <summary>
		/// An event handler called when the user selects the response videos feed page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeApiV2ResponseVideosFeedSelected(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2ResponseVideosFeed;
		}

		/// <summary>
		/// An event handler called when the user selects the user page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeApiV2UserSelected(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2User;
		}

		/// <summary>
		/// An event handler called when the user selects the user uploads page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeApiV2UserUploadsSelected(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2UploadsFeed;
		}

		/// <summary>
		/// An event handler called when the user selects the user favorites page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeApiV2UserFavoritesSelected(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2FavoritesFeed;
		}

		/// <summary>
		/// An event handler called when the user selects the user playlists page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeApiV2UserPlaylistsSelected(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2Playlists;
		}

		/// <summary>
		/// An event handler called when the user selects the playlist videos page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeApiV2PlaylistVideosSelected(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2PlaylistFeed;
		}

		/// <summary>
		/// An event handler called when the user selects the web videos page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeWebVideosSelected(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeWebVideos;
		}

		/// <summary>
		/// An event handler called when the user selects the videos comments page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeCommentsVideosSelected(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemComments;
			this.controlSideComments.SelectedNode = this.treeNodeCommentsVideos;
		}

		/// <summary>
		/// An event handler called when the user selects the users comments page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeCommentsUsersSelected(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemComments;
			this.controlSideComments.SelectedNode = this.treeNodeCommentsUsers;
		}

		/// <summary>
		/// An event handler called when the user selects the playlists comments page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeCommentsPlaylistsSelected(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemComments;
			this.controlSideComments.SelectedNode = this.treeNodeCommentsPlaylists;
		}

		/// <summary>
		/// An event handler called when the user selects to view video in APIv2 page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeApiV2VideoOpened(object sender, VideoEventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2Video;
			this.controlYtApi2Video.Open(e.Video);
		}

		/// <summary>
		/// An event handler called when the user selects to view video comment in APIv2 page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeApiV2VideoCommentOpened(object sender, StringEventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2VideoComments;
			this.controlYtApi2CommentsFeed.View(e.Value);
		}

		/// <summary>
		/// An event handler called when the user selects to view related videos in APIv2 page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeApiV2RelatedVideosOpened(object sender, VideoEventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2RelatedVideosFeed;
			this.controlYtApi2RelatedFeed.View(e.Video.Id);
		}

		/// <summary>
		/// An event handler called when the user selects to view response videos in APIv2 page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeApiV2ResponseVideosOpened(object sender, VideoEventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2ResponseVideosFeed;
			this.controlYtApi2ResponseFeed.View(e.Video.Id);
		}

		/// <summary>
		/// An event handler called when the user selects to view user in APIv2 page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeApiV2AuthorOpened(object sender, StringEventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2User;
			this.controlYtApi2Profile.View(e.Value);
		}

		/// <summary>
		/// An event handler called when the user selects to view uploaded videos in APIv2 page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeApiV2UserUploadsOpened(object sender, ProfileEventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2UploadsFeed;
			this.controlYtApi2UploadsFeed.View(e.Profile.Id);
		}

		/// <summary>
		/// An event handler called when the user selects to view favorited videos page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeApiV2UserFavoritesOpened(object sender, ProfileEventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2FavoritesFeed;
			this.controlYtApi2FavoritesFeed.View(e.Profile.Id);
		}

		/// <summary>
		/// An event handler called when the user selects the playlists page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeApiV2UserPlaylistsOpened(object sender, ProfileEventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2Playlists;
			this.controlYtApi2PlaylistsFeed.View(e.Profile.Id);
		}

		/// <summary>
		/// An event handler called when the user selects the playlist page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeApiV2PlaylistOpened(object sender, StringEventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2PlaylistFeed;
			this.controlYtApi2PlaylistFeed.View(e.Value);
		}

		/// <summary>
		/// An event handler called when the user selects to view video web information page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeWebVideoOpened(object sender, VideoEventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeWebVideos;
			this.controlYtWebStatistics.View(e.Video.Id);
		}

		/// <summary>
		/// An event handler called when the user selects the video comment page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeVideoCommented(object sender, StringEventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemComments;
			this.controlSideComments.SelectedNode = this.treeNodeCommentsVideos;
			this.controlCommentsVideos.AddComment(e.Value);
		}

		/// <summary>
		/// An event handler called when the user selects the user comment page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubeUserCommented(object sender, StringEventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemComments;
			this.controlSideComments.SelectedNode = this.treeNodeCommentsUsers;
			this.controlCommentsUsers.AddComment(e.Value);
		}

		/// <summary>
		/// An event handler called when the user selects the playlist comment page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnYouTubePlaylistCommented(object sender, StringEventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemComments;
			this.controlSideComments.SelectedNode = this.treeNodeCommentsPlaylists;
			this.controlCommentsPlaylists.AddComment(e.Value);
		}

		/// <summary>
		/// An event handler called when the user selects the standard feeds spider page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSpiderStandardFeedsSelected(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemSpiders;
			this.controlSideSpiders.SelectedNode = this.treeNodeSpiderStandardFeeds;
		}

		/// <summary>
		/// An event handler called when the user selects the exit menu item.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnExit(object sender, EventArgs e)
		{
			// Close the main window.
			this.Close();
		}

		/// <summary>
		/// Opens the about form.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OpenAboutForm(object sender, EventArgs e)
		{
			// Show the about dialog.
			this.formAbout.ShowDialog(this);
		}

		/// <summary>
		/// An event handler called when the log date has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnLogDateChanged(object sender, DateRangeEventArgs e)
		{
			// Update the log.
			this.controlLog.DateChanged(sender, e);
		}

		/// <summary>
		/// An event handler called when the log is refreshed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnLogDateRefresh(object sender, DateRangeEventArgs e)
		{
			// Refresh the log.
			this.controlLog.DateRefresh(sender, e);
		}

		/// <summary>
		/// An event handler called when the network status has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNetworkStatusChanged(object sender, EventArgs e)
		{
			// Call the method on the UI thread.
			if (this.InvokeRequired) this.Invoke(this.actionNetworkStatusChanged, new object[] { sender, e });
			else
			{
				// Update the connecton status label.
				switch (Crawler.Network.IsInternetAvailable)
				{
					case NetworkStatus.AvailabilityStatus.Unknown:
						this.statusLabelConnection.Image = Resources.ConnectionQuestion_16;
						this.statusLabelConnection.Text = "Connectivity unknown";
						break;
					case NetworkStatus.AvailabilityStatus.Success:
						this.statusLabelConnection.Image = Resources.ConnectionSuccess_16;
						this.statusLabelConnection.Text = "Connected to Internet";
						break;
					case NetworkStatus.AvailabilityStatus.Warning:
						this.statusLabelConnection.Image = Resources.ConnectionWarning_16;
						this.statusLabelConnection.Text = "Connected to local network";
						break;
					case NetworkStatus.AvailabilityStatus.Fail:
						this.statusLabelConnection.Image = Resources.ConnectionError_16;
						this.statusLabelConnection.Text = "Not connected";
						break;
				}
			}
		}

		/// <summary>
		/// An event handler called when the network status has been checked.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNetworkStatusChecked(object sender, EventArgs e)
		{
			// Call the method on the UI thread.
			this.Invoke(() =>
				{
					// If the tooltip is visible.
					if (this.toolTipNetworkStatus.Visible)
					{
						// Hide the tooltip.
						this.OnNetworkStatusLeave(sender, e);
						// Show the tooltip.
						this.OnNetworkStatusEnter(sender, e);
					}
				});
		}

		/// <summary>
		/// Shows the network status tooltip.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNetworkStatusEnter(object sender, EventArgs e)
		{
			// Compute the tooltip location.
			Point location = new Point(this.ClientRectangle.Right, this.ClientRectangle.Bottom);
			// Show the tooltip.
			this.toolTipNetworkStatus.Show(this, location, ContentAlignment.BottomRight);
		}

		/// <summary>
		/// Hides the network status tooltip.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNetworkStatusLeave(object sender, EventArgs e)
		{
			// Hide the tooltip.
			this.toolTipNetworkStatus.Hide(this);
		}
	}
}
