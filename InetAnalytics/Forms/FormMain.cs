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
using DotNetApi.Windows;
using DotNetApi.Windows.Controls;
using DotNetApi.Windows.Themes;
using Microsoft.Win32;
using InetAnalytics.Controls;
using InetAnalytics.Controls.Comments;
using InetAnalytics.Controls.Database;
using InetAnalytics.Controls.Log;
using InetAnalytics.Controls.Spiders;
using InetAnalytics.Controls.PlanetLab;
using InetAnalytics.Controls.Testing;
using InetAnalytics.Controls.YouTube;
using InetAnalytics.Controls.YouTube.Api2;
using InetAnalytics.Controls.YouTube.Api3;
using InetAnalytics.Controls.YouTube.Web;
using InetAnalytics.Events;
using InetApi.YouTube.Api.V2;
using InetApi.YouTube.Api.V2.Data;
using InetCrawler;
using InetCrawler.Status;

namespace InetAnalytics.Forms
{
	public partial class FormMain : Form
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

		private TreeNode treeNodeTestingWebRequest;
		private TreeNode treeNodeTestingSshRequest;

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

		private readonly ControlServers controlDatabaseServers = new ControlServers();

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

		private readonly ControlTestingWebRequest controlTestingWebRequest = new ControlTestingWebRequest();
		private readonly ControlTestingSshRequest controlTestingSshRequest = new ControlTestingSshRequest();

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
				this.imageList.Images.IndexOfKey("FolderClosedPlay"),
				this.imageList.Images.IndexOfKey("FolderOpenPlay"),
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

			this.treeNodeTestingWebRequest = new TreeNode("Web request",
				this.imageList.Images.IndexOfKey("TestGlobeGoto"),
				this.imageList.Images.IndexOfKey("TestGlobeGoto"));
			this.treeNodeTestingSshRequest = new TreeNode("Secure shell",
				this.imageList.Images.IndexOfKey("TestConnectGoto"),
				this.imageList.Images.IndexOfKey("TestConnectGoto"));

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
			this.splitContainer.Panel2.Controls.Add(this.controlTestingWebRequest);
			this.splitContainer.Panel2.Controls.Add(this.controlTestingSshRequest);
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

			this.treeNodeTestingWebRequest.Tag = this.controlTestingWebRequest;
			this.treeNodeTestingSshRequest.Tag = this.controlTestingSshRequest;

			this.treeNodeSettings.Tag = this.controlSettings;
			this.controlSideLog.Tag = this.controlLog;
			this.treeNodeComments.Tag = this.controlCommentsInfo;
			this.treeNodeCommentsVideos.Tag = this.controlCommentsVideos;
			this.treeNodeCommentsUsers.Tag = this.controlCommentsUsers;
			this.treeNodeCommentsPlaylists.Tag = this.controlCommentsPlaylists;

			// Add the tree nodes to the side panel tree views.
			this.controlSidePlanetLab.Nodes.Add(this.treeNodePlanetLab);
			this.controlSideDatabase.Nodes.Add(this.treeNodeDatabaseServers);
			this.controlSideSpiders.Nodes.Add(this.treeNodeSpidersLocal);
			this.controlSideYouTube.Nodes.AddRange(
				new TreeNode[] {
					this.treeNodeYouTubeApi2,
					this.treeNodeYouTubeApi3,
					this.treeNodeYouTubeWeb
				});
			this.controlSideTesting.Nodes.AddRange(
				new TreeNode[] {
					this.treeNodeTestingWebRequest,
					this.treeNodeTestingSshRequest
				});
			this.controlSideConfiguration.Nodes.Add(this.treeNodeSettings);
			this.controlSideComments.Nodes.Add(this.treeNodeComments);

			// Set the control event handlers.
			this.crawler.Status.Message += this.OnStatusMessage;

			this.controlPlanetLab.ClickSites += this.PlanetLabSitesClick;
			this.controlPlanetLab.ClickSlices += this.PlanetLabSlicesClick;
			this.controlPlanetLabSlices.SliceAdded += this.PlanetLabSliceAdded;
			this.controlPlanetLabSlices.SliceRemoved += this.PlanetLabSliceRemoved;

			this.controlYtApi2.VideosGlobalClick += this.YouTubeApi2VideosFeedsInfoClick;
			this.controlYtApi2.VideosUserClick += this.YouTubeApi2UserFeedsInfoClick;
			this.controlYtApi2.CategoriesClick += this.YouTubeApi2VideoCategoriesClick;

			this.controlYtApi2VideosFeedsInfo.VideoClick += this.YouTubeApi2VideoClick;
			this.controlYtApi2VideosFeedsInfo.VideoCommentsClick += this.YouTubeApi2VideoCommentsClick;
			this.controlYtApi2VideosFeedsInfo.SearchFeedClick += this.YouTubeApi2SearchFeedClick;
			this.controlYtApi2VideosFeedsInfo.StandardFeedClick += this.YouTubeApi2StandardFeedClick;
			this.controlYtApi2VideosFeedsInfo.RelatedVideosFeedClick += this.YouTubeApi2RelatedVideosFeedClick;
			this.controlYtApi2VideosFeedsInfo.ResponseVideosFeedClick += this.YouTubeApi2ResponseVideosFeedClick;

			this.controlYtApi2Video.ViewVideoCommentsInApiV2 += this.ViewVideoCommentsInApiV2;
			this.controlYtApi2Video.ViewAuthorInApiV2 += this.ViewApiV2User;
			this.controlYtApi2Video.ViewVideoRelatedInApiV2 += this.ViewRelatedVideosInApiV2;
			this.controlYtApi2Video.ViewVideoResponsesInApiV2 += this.ViewResponseVideosInApiV2;
			this.controlYtApi2Video.ViewVideoInWeb += this.ViewVideoInWeb;
			this.controlYtApi2Video.Comment += this.OnCommentVideo;

			this.controlYtApi2StandardFeed.ViewVideoInApiV2 += this.ViewVideoInApiV2;
			this.controlYtApi2StandardFeed.ViewAuthorInApiV2 += this.ViewApiV2User;
			this.controlYtApi2StandardFeed.ViewRelatedVideosInApiV2 += this.ViewRelatedVideosInApiV2;
			this.controlYtApi2StandardFeed.ViewResponseVideosInApiV2 += this.ViewResponseVideosInApiV2;
			this.controlYtApi2StandardFeed.ViewVideoInWeb += this.ViewVideoInWeb;
			this.controlYtApi2StandardFeed.Comment += this.OnCommentVideo;

			this.controlYtApi2Search.ViewVideoInApiV2 += this.ViewVideoInApiV2;
			this.controlYtApi2Search.ViewAuthorInApiV2 += this.ViewApiV2User;
			this.controlYtApi2Search.ViewRelatedVideosInApiV2 += this.ViewRelatedVideosInApiV2;
			this.controlYtApi2Search.ViewResponseVideosInApiV2 += this.ViewResponseVideosInApiV2;
			this.controlYtApi2Search.ViewVideoInWeb += this.ViewVideoInWeb;
			this.controlYtApi2Search.Comment += this.OnCommentVideo;

			this.controlYtApi2RelatedFeed.ViewVideoInApiV2 += this.ViewVideoInApiV2;
			this.controlYtApi2RelatedFeed.ViewAuthorInApiV2 += this.ViewApiV2User;
			this.controlYtApi2RelatedFeed.ViewRelatedVideosInApiV2 += this.ViewRelatedVideosInApiV2;
			this.controlYtApi2RelatedFeed.ViewResponseVideosInApiV2 += this.ViewResponseVideosInApiV2;
			this.controlYtApi2RelatedFeed.ViewVideoInWeb += this.ViewVideoInWeb;
			this.controlYtApi2RelatedFeed.Comment += this.OnCommentVideo;

			this.controlYtApi2ResponseFeed.ViewVideoInApiV2 += this.ViewVideoInApiV2;
			this.controlYtApi2ResponseFeed.ViewRelatedVideosInApiV2 += this.ViewRelatedVideosInApiV2;
			this.controlYtApi2ResponseFeed.ViewResponseVideosInApiV2 += this.ViewResponseVideosInApiV2;
			this.controlYtApi2ResponseFeed.ViewAuthorInApiV2 += this.ViewApiV2User;
			this.controlYtApi2ResponseFeed.ViewVideoInWeb += this.ViewVideoInWeb;
			this.controlYtApi2ResponseFeed.Comment += this.OnCommentVideo;

			this.controlYtApi2UserFeedInfo.UserClick += this.YouTubeApi2UserClick;
			this.controlYtApi2UserFeedInfo.UploadsFeedClick += this.YouTubeApi2UserUploadsClick;
			this.controlYtApi2UserFeedInfo.FavoritesFeedClick += this.YouTubeApi2UserFavoritesClick;
			this.controlYtApi2UserFeedInfo.PlaylistsFeedClick += this.YouTubeApi2UserPlaylistsClick;
			this.controlYtApi2UserFeedInfo.PlaylistFeedClick += this.YouTubeApi2PlaylistVideosClick;

			this.controlYtApi2Profile.ViewUserUploadsInApiV2 += this.ViewApiV2UploadedVideos;
			this.controlYtApi2Profile.ViewUserFavoritesInApiV2 += this.ViewApiV2FavoritedVideos;
			this.controlYtApi2Profile.ViewUserPlaylistsInApiV2 += this.ViewApiV2Playlists;
			this.controlYtApi2Profile.Comment += this.OnCommentUser;

			this.controlYtApi2UploadsFeed.ViewVideoInApiV2 += this.ViewVideoInApiV2;
			this.controlYtApi2UploadsFeed.ViewAuthorInApiV2 += this.ViewApiV2User;
			this.controlYtApi2UploadsFeed.ViewRelatedVideosInApiV2 += this.ViewRelatedVideosInApiV2;
			this.controlYtApi2UploadsFeed.ViewResponseVideosInApiV2 += this.ViewResponseVideosInApiV2;
			this.controlYtApi2UploadsFeed.ViewVideoInWeb += this.ViewVideoInWeb;
			this.controlYtApi2UploadsFeed.Comment += this.OnCommentVideo;

			this.controlYtApi2FavoritesFeed.ViewVideoInApiV2 += this.ViewVideoInApiV2;
			this.controlYtApi2FavoritesFeed.ViewAuthorInApiV2 += this.ViewApiV2User;
			this.controlYtApi2FavoritesFeed.ViewRelatedVideosInApiV2 += this.ViewRelatedVideosInApiV2;
			this.controlYtApi2FavoritesFeed.ViewResponseVideosInApiV2 += this.ViewResponseVideosInApiV2;
			this.controlYtApi2FavoritesFeed.ViewVideoInWeb += this.ViewVideoInWeb;
			this.controlYtApi2FavoritesFeed.Comment += this.OnCommentVideo;

			this.controlYtApi2PlaylistsFeed.ViewPlaylistAuthorInApiV2 += this.ViewApiV2User;
			this.controlYtApi2PlaylistsFeed.ViewPlaylistVideosInApiV2 += this.ViewApiV2Playlist;
			this.controlYtApi2PlaylistsFeed.Comment += this.OnCommentPlaylist;

			this.controlYtApi2PlaylistFeed.ViewVideoInApiV2 += this.ViewVideoInApiV2;
			this.controlYtApi2PlaylistFeed.ViewRelatedVideosInApiV2 += this.ViewRelatedVideosInApiV2;
			this.controlYtApi2PlaylistFeed.ViewResponseVideosInApiV2 += this.ViewResponseVideosInApiV2;
			this.controlYtApi2PlaylistFeed.ViewAuthorInApiV2 += this.ViewApiV2User;
			this.controlYtApi2PlaylistFeed.ViewVideoInWeb += this.ViewVideoInWeb;
			this.controlYtApi2PlaylistFeed.Comment += this.OnCommentVideo;

			this.controlYtWeb.ClickVideoStatistics += this.YouTubeWebVideosClick;

			this.controlYtWebStatistics.Comment += this.OnCommentVideo;

			this.controlSpiderInfo.StandardFeedsClick += this.YouTubeSpiderStandardFeedsClick;

			this.controlCommentsInfo.ClickVideos += this.YouTubeCommentsVideosClick;
			this.controlCommentsInfo.ClickUsers += this.YouTubeCommentsUsersClick;
			this.controlCommentsInfo.ClickPlaylists += this.YouTubeCommentsPlaylistsClick;

			// Initialize the controls.
			this.controlPlanetLab.Initialize(this.crawler);
			this.controlPlanetLabSites.Initialize(this.crawler);
			this.controlPlanetLabNodes.Initialize(this.crawler);
			this.controlPlanetLabSlices.Initialize(this.crawler, this.treeNodePlanetLabSlices, this.splitContainer.Panel2.Controls, this.imageList);
			this.controlDatabaseServers.Initialize(this.crawler, this.treeNodeDatabaseServers, this.splitContainer.Panel2.Controls, this.imageList);
			this.controlSpiderStandardFeeds.Initialize(this.crawler);
			this.controlYtApi2Video.Initialize(this.crawler);
			this.controlYtApi2CommentsFeed.Initialize(this.crawler);
			this.controlYtApi2StandardFeed.Initialize(this.crawler);
			this.controlYtApi2Search.Initialize(this.crawler);
			this.controlYtApi2RelatedFeed.Initialize(this.crawler, new VideosFeedEventHandler(YouTubeUri.GetRelatedVideosFeed), "&Video:", "related videos feed", "video", "APIv2 Related Videos Feed");
			this.controlYtApi2ResponseFeed.Initialize(this.crawler, new VideosFeedEventHandler(YouTubeUri.GetResponseVideosFeed), "&Video:", "response videos feed", "video", "APIv2 Response Videos Feed");
			this.controlYtApi2Profile.Initialize(this.crawler);
			this.controlYtApi2PlaylistsFeed.Initialize(this.crawler);
			this.controlYtApi2UploadsFeed.Initialize(this.crawler, new VideosFeedEventHandler(YouTubeUri.GetUploadsFeed), "&User:", "uploads video feed", "user", "APIv2 Uploads Videos Feed");
			this.controlYtApi2FavoritesFeed.Initialize(this.crawler, new VideosFeedEventHandler(YouTubeUri.GetFavoritesFeed), "&User:", "favorites video feed", "user", "APIv2 Favorites Videos Feed");
			this.controlYtApi2PlaylistFeed.Initialize(this.crawler, new VideosFeedEventHandler(YouTubeUri.GetPlaylistFeed), "&Playlist:", "playlist video feed", "user", "APIv2 Playlist Videos Feed");
			this.controlYtApi2Categories.Initialize(this.crawler);
			this.controlTestingWebRequest.Initialize(this.crawler);
			this.controlTestingSshRequest.Initialize(this.crawler);
			this.controlSettings.Initialize(this.crawler);
			this.controlYtWebStatistics.Initialize(this.crawler);
			this.controlLog.Initialize(this.crawler.Config, this.crawler.Log);
			this.controlCommentsVideos.Initialize(this.crawler.Comments.Videos, InetCrawler.Comments.Comment.CommentType.Video);
			this.controlCommentsUsers.Initialize(this.crawler.Comments.Users, InetCrawler.Comments.Comment.CommentType.User);
			this.controlCommentsPlaylists.Initialize(this.crawler.Comments.Playlists, InetCrawler.Comments.Comment.CommentType.Playlist);

			// Set the selected control.
			this.controlPanel = this.labelNotAvailable;

			// Initialize the side controls.
			this.controlSidePlanetLab.Initialize();
			this.controlSideDatabase.Initialize();
			this.controlSideSpiders.Initialize();
			this.controlSideYouTube.Initialize();
			this.controlSideTesting.Initialize();
			this.controlSideLog.Initialize();
			this.controlSideConfiguration.Initialize();
			this.controlSideComments.Initialize();

			// Configure the side menu with the last saved configuration.
			this.sideMenu.VisibleItems = this.crawler.Config.ConsoleSideMenuVisibleItems;
			this.sideMenu.SelectedIndex = this.crawler.Config.ConsoleSideMenuSelectedItem;
			if (this.sideMenu.SelectedItem.Control.HasSelected())
			{
				this.sideMenu.SelectedItem.Control.SetSelected(this.crawler.Config.ConsoleSideMenuSelectedNode);
			}

			// Create the network status changed event handler.
			this.actionNetworkStatusChanged = new EventHandler(this.OnNetworkStatusChanged);
			// Set the network availability event handler.
			Crawler.Network.NetworkChanged += this.actionNetworkStatusChanged;
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
			// Save the configuration.
			this.crawler.Config.ConsoleSideMenuVisibleItems = this.sideMenu.VisibleItems;
			this.crawler.Config.ConsoleSideMenuSelectedItem = this.sideMenu.SelectedIndex ?? 0;
			this.crawler.Config.ConsoleSideMenuSelectedNode = this.sideMenu.SelectedItem.Control.GetSelected();
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
		private void OnStatusMessage(object sender, StatusMessageEventArgs e)
		{
			this.statusStrip.BackColor = this.themeSettings.ColorTable.StatusStripNormalBackground;
			this.statusLabelLeft.ForeColor = this.themeSettings.ColorTable.StatusStripNormalText;
			this.statusLabelRight.ForeColor = this.themeSettings.ColorTable.StatusStripNormalText;
			this.statusLabelConnection.ForeColor = this.themeSettings.ColorTable.StatusStripNormalText;
			if (e.Message.HasValue)
			{
				this.statusLabelLeft.Image = e.Message.Value.LeftImage;
				this.statusLabelLeft.Text = e.Message.Value.LeftText;
				this.statusLabelRight.Image = e.Message.Value.RightImage;
				this.statusLabelRight.Text = e.Message.Value.RightText;
			}
			else
			{
				this.statusLabelLeft.Image = null;
				this.statusLabelLeft.Text = null;
				this.statusLabelRight.Image = null;
				this.statusLabelRight.Text = null;
			}
		}

		/// <summary>
		/// An event handler called when the user selects the PlanetLab sites page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void PlanetLabSitesClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemPlanetLab;
			this.controlSidePlanetLab.SelectedNode = this.treeNodePlanetLabSites;
		}

		/// <summary>
		/// An event handler called when the user selects the PlanetLab slices page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void PlanetLabSlicesClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemPlanetLab;
			this.controlSidePlanetLab.SelectedNode = this.treeNodePlanetLabSlices;
		}

		/// <summary>
		/// An event handler called when the a PlanetLab slice control was added.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void PlanetLabSliceAdded(object sender, ControlEventArgs<ControlSlice> e)
		{
			// Add the console selected event handler to the control.
			e.Control.ConsoleSelected += this.PlanetLabConsoleSelected;
		}

		/// <summary>
		/// An event handler called when a PlanetLab slice control was removed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void PlanetLabSliceRemoved(object sender, ControlEventArgs<ControlSlice> e)
		{
			// Remove the console selected event handler from the control.
			e.Control.ConsoleSelected -= this.PlanetLabConsoleSelected;
		}

		/// <summary>
		/// An event handler called when a PlanetLab console is selected.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void PlanetLabConsoleSelected(object sender, PageSelectionEventArgs e)
		{
			this.controlSidePlanetLab.SelectedNode = e.Node;
		}

		/// <summary>
		/// An event handler called when the user selects the videos feeds information page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void YouTubeApi2VideosFeedsInfoClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2VideosFeedsInfo;
		}

		/// <summary>
		/// An event handler called when the user selects the user feeds information page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void YouTubeApi2UserFeedsInfoClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2UserFeedsInfo;
		}

		/// <summary>
		/// An event handler called when the user selects the video categories page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void YouTubeApi2VideoCategoriesClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2VideoCategories;
		}

		/// <summary>
		/// An event handler called when the user selects the video page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void YouTubeApi2VideoClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2Video;
		}

		/// <summary>
		/// An event handler called when the user selects the video comments page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void YouTubeApi2VideoCommentsClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2VideoComments;
		}

		/// <summary>
		/// An event handler called when the user selects the search feed page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void YouTubeApi2SearchFeedClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2SearchFeed;
		}

		/// <summary>
		/// An event handler called when the user selects the standard feed page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void YouTubeApi2StandardFeedClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2StandardFeed;
		}

		/// <summary>
		/// An event handler called when user selects the related videos feed page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void YouTubeApi2RelatedVideosFeedClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2RelatedVideosFeed;
		}

		/// <summary>
		/// An event handler called when the user selects the response videos feed page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void YouTubeApi2ResponseVideosFeedClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2ResponseVideosFeed;
		}

		/// <summary>
		/// An event handler called when the user selects the user page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void YouTubeApi2UserClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2User;
		}

		/// <summary>
		/// An event handler called when the user selects the user uploads page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void YouTubeApi2UserUploadsClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2UploadsFeed;
		}

		/// <summary>
		/// An event handler called when the user selects the user favorites page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void YouTubeApi2UserFavoritesClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2FavoritesFeed;
		}

		/// <summary>
		/// An event handler called when the user selects the user playlists page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void YouTubeApi2UserPlaylistsClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2Playlists;
		}

		/// <summary>
		/// An event handler called when the user selects the playlist videos page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void YouTubeApi2PlaylistVideosClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2PlaylistFeed;
		}

		/// <summary>
		/// An event handler called when the user selects the web videos page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void YouTubeWebVideosClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeWebVideos;
		}

		/// <summary>
		/// An event handler called when the user selects the standard feeds spider page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void YouTubeSpiderStandardFeedsClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemSpiders;
			this.controlSideSpiders.SelectedNode = this.treeNodeSpiderStandardFeeds;
		}

		/// <summary>
		/// An event handler called when the user selects the videos comments page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void YouTubeCommentsVideosClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemComments;
			this.controlSideComments.SelectedNode = this.treeNodeCommentsVideos;
		}

		/// <summary>
		/// An event handler called when the user selects the users comments page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void YouTubeCommentsUsersClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemComments;
			this.controlSideComments.SelectedNode = this.treeNodeCommentsUsers;
		}

		/// <summary>
		/// An event handler called when the user selects the playlists comments page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void YouTubeCommentsPlaylistsClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemComments;
			this.controlSideComments.SelectedNode = this.treeNodeCommentsPlaylists;
		}

		/// <summary>
		/// An event handler called when the user selects to view video in APIv2 page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void ViewVideoInApiV2(object sender, VideoEventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemYouTube;
			this.controlSideYouTube.SelectedNode = this.treeNodeYouTubeApi2Video;
			this.controlYtApi2Video.View(e.Video);
		}

		/// <summary>
		/// An event handler called when the user selects to view video comment in APIv2 page.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void ViewVideoCommentsInApiV2(object sender, StringEventArgs e)
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
		private void ViewRelatedVideosInApiV2(object sender, VideoEventArgs e)
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
		private void ViewResponseVideosInApiV2(object sender, VideoEventArgs e)
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
		private void ViewApiV2User(object sender, StringEventArgs e)
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
		private void ViewApiV2UploadedVideos(object sender, ProfileEventArgs e)
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
		private void ViewApiV2FavoritedVideos(object sender, ProfileEventArgs e)
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
		private void ViewApiV2Playlists(object sender, ProfileEventArgs e)
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
		private void ViewApiV2Playlist(object sender, StringEventArgs e)
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
		private void ViewVideoInWeb(object sender, VideoEventArgs e)
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
		private void OnCommentVideo(object sender, StringEventArgs e)
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
		private void OnCommentUser(object sender, StringEventArgs e)
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
		private void OnCommentPlaylist(object sender, StringEventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuItemComments;
			this.controlSideComments.SelectedNode = this.treeNodeCommentsPlaylists;
			this.controlCommentsPlaylists.AddComment(e.Value);
		}

		/// <summary>
		/// An event handler called when the user selects the exit menu item.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnExit(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Opens the about form.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OpenAboutForm(object sender, EventArgs e)
		{
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
					case CrawlerNetwork.AvailabilityStatus.Unknown:
						this.statusLabelConnection.Image = Resources.ConnectionQuestion_16;
						this.statusLabelConnection.Text = "Connectivity unknown";
						break;
					case CrawlerNetwork.AvailabilityStatus.Success:
						this.statusLabelConnection.Image = Resources.ConnectionSuccess_16;
						this.statusLabelConnection.Text = "Connected to Internet";
						break;
					case CrawlerNetwork.AvailabilityStatus.Warning:
						this.statusLabelConnection.Image = Resources.ConnectionWarning_16;
						this.statusLabelConnection.Text = "Connected to local network";
						break;
					case CrawlerNetwork.AvailabilityStatus.Fail:
						this.statusLabelConnection.Image = Resources.ConnectionError_16;
						this.statusLabelConnection.Text = "Not connected";
						break;
				}
				// Set the label tooltip.
				this.statusLabelConnection.ToolTipText = "ICMP connectivity: {0}{1}HTTP connectivity: {2}{3}HTTPS connectivity: {4}{5}{6}Connectivity last checked at {7}".FormatWith(
					Crawler.Network.IsInternetIcmpAvailable ? "Yes" : "No",
					Environment.NewLine,
					Crawler.Network.IsInternetHttpAvailable ? "Yes" : "No",
					Environment.NewLine,
					Crawler.Network.IsInternetHttpsAvailable ? "Yes" : "No",
					Environment.NewLine,
					Environment.NewLine,
					Crawler.Network.InternetAvailableLastUpdated.ToLongTimeString());
			}
		}
	}
}
