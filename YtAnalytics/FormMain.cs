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
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using YtAnalytics.Controls;
using YtApi.Api.V2;
using YtApi.Api.V2.Data;
using YtCrawler;
using DotNetApi.Windows;
using DotNetApi.Windows.Controls;

namespace YtAnalytics
{
	public partial class FormMain : Form
	{
		// Crawler.
		private Crawler crawler;

		// UI formatter.
		private Formatting formatting = new Formatting();

		// Side menu items.
		private SideMenuItem sideMenuBrowse;
		private SideMenuItem sideMenuConfiguration;
		private SideMenuItem sideMenuLog;
		private SideMenuItem sideMenuComments;

		// Tree view nodes.
		private TreeNode treeNodeBrowserApi2;
		private TreeNode treeNodeBrowserApi2VideosGlobal;
		private TreeNode treeNodeBrowserApi2Video;
		private TreeNode treeNodeBrowserApi2VideoComments;
		private TreeNode treeNodeBrowserApi2SearchFeed;
		private TreeNode treeNodeBrowserApi2StandardFeed;
		private TreeNode treeNodeBrowserApi2RelatedVideosFeed;
		private TreeNode treeNodeBrowserApi2ResponseVideosFeed;
		private TreeNode treeNodeBrowserApi2VideosUser;
		private TreeNode treeNodeBrowserApi2User;
		private TreeNode treeNodeBrowserApi2Contacts;
		private TreeNode treeNodeBrowserApi2Playlists;
		private TreeNode treeNodeBrowserApi2FavoritesFeed;
		private TreeNode treeNodeBrowserApi2PlaylistFeed;
		private TreeNode treeNodeBrowserApi2VideoCategories;

		private TreeNode treeNodeBrowserApi3;
		private TreeNode treeNodeBrowserApi3Videos;

		private TreeNode treeNodeBrowserWeb;
		private TreeNode treeNodeBrowserWebVideos;

		private TreeNode treeNodeSettings;

		private TreeNode treeNodeComments;
		private TreeNode treeNodeCommentsVideos;

		// Side control.
		private Control controlSideSelected = null;

		// Panel control.
		private Control controlPanelSelected = null;

		// Panel controls.
		private ControlYtApi2 controlYtApi2 = new ControlYtApi2();
		private ControlYtApi2VideosGlobal controlYtApi2Videos = new ControlYtApi2VideosGlobal();
		private ControlYtApi2Video controlYtApi2Video = new ControlYtApi2Video();
		private ControlYtApi2Search controlYtApi2Search = new ControlYtApi2Search();
		private ControlYtApi2StandardFeed controlYtApi2FeedStandard = new ControlYtApi2StandardFeed();
		private ControlYtApi2GeneralVideosFeed controlYtApi2FeedRelated = new ControlYtApi2GeneralVideosFeed();
		private ControlYtApi2GeneralVideosFeed controlYtApi2FeedResponse = new ControlYtApi2GeneralVideosFeed();
		private ControlYtApi3 controlYtApi3 = new ControlYtApi3();
		private ControlWeb controlWeb = new ControlWeb();
		private ControlWebStatistics controlWebStatistics = new ControlWebStatistics();
		private ControlSettings controlSettings = new ControlSettings();
		private ControlLog controlLog = new ControlLog();
		private ControlComments controlComments = new ControlComments();
		private ControlCommentsVideos controlCommentsVideos = new ControlCommentsVideos();

		// Forms.
		private FormAbout formAbout = new FormAbout();

		// Delegates
		private ViewVideoEventHandler delegateViewVideoApiV2;
		private ViewVideoEventHandler delegateViewVideoApiV2Related;
		private ViewVideoEventHandler delegateViewVideoApiV2Responses;
		private ViewVideoEventHandler delegateViewVideoApiV3;
		private ViewVideoEventHandler delegateViewVideoWeb;
		private AddVideoCommentEventHandler delegateAddVideoComment;

		/// <summary>
		/// Constructor for main form window.
		/// </summary>
		public FormMain()
		{
			InitializeComponent();

			// Initialize the crawler
			this.crawler = new Crawler("HKEY_CURRENT_USER\\Software\\Alex Bikfalvi\\YtAnalytics");

			// Create the tree view items.
			this.treeNodeBrowserApi2VideoComments = new TreeNode("Comments",
				this.imageList.Images.IndexOfKey("FolderClosedComment"),
				this.imageList.Images.IndexOfKey("FolderOpenComment"));
			this.treeNodeBrowserApi2Video = new TreeNode("Video",
				this.imageList.Images.IndexOfKey("FileVideo"),
				this.imageList.Images.IndexOfKey("FileVideo"),
				new TreeNode[] {
					this.treeNodeBrowserApi2VideoComments
				});
			this.treeNodeBrowserApi2SearchFeed = new TreeNode("Search",
				this.imageList.Images.IndexOfKey("FolderClosedVideo"),
				this.imageList.Images.IndexOfKey("FolderOpenVideo"));
			this.treeNodeBrowserApi2StandardFeed = new TreeNode("Standard feeds",
				this.imageList.Images.IndexOfKey("FolderClosedVideo"),
				this.imageList.Images.IndexOfKey("FolderOpenVideo"));
			this.treeNodeBrowserApi2RelatedVideosFeed = new TreeNode("Related videos feed",
				this.imageList.Images.IndexOfKey("FolderClosedVideo"),
				this.imageList.Images.IndexOfKey("FolderOpenVideo"));
			this.treeNodeBrowserApi2ResponseVideosFeed = new TreeNode("Response videos feed",
				this.imageList.Images.IndexOfKey("FolderClosedVideo"),
				this.imageList.Images.IndexOfKey("FolderOpenVideo"));
			this.treeNodeBrowserApi2VideosGlobal = new TreeNode("Global videos",
				this.imageList.Images.IndexOfKey("FolderClosedVideo"),
				this.imageList.Images.IndexOfKey("FolderOpenVideo"),
				new TreeNode[] {
					this.treeNodeBrowserApi2Video,
					this.treeNodeBrowserApi2SearchFeed,
					this.treeNodeBrowserApi2StandardFeed,
					this.treeNodeBrowserApi2RelatedVideosFeed,
					this.treeNodeBrowserApi2ResponseVideosFeed
				});

			this.treeNodeBrowserApi2Contacts = new TreeNode("Contacts",
				this.imageList.Images.IndexOfKey("FolderClosedUser"),
				this.imageList.Images.IndexOfKey("FolderOpenUser"));
			this.treeNodeBrowserApi2Playlists = new TreeNode("Playlists",
				this.imageList.Images.IndexOfKey("FolderClosedPlay"),
				this.imageList.Images.IndexOfKey("FolderOpenPlay"));
			this.treeNodeBrowserApi2User = new TreeNode("User",
				this.imageList.Images.IndexOfKey("FileUser"),
				this.imageList.Images.IndexOfKey("FileUser"),
				new TreeNode[] {
					this.treeNodeBrowserApi2Contacts,
					this.treeNodeBrowserApi2Playlists
				});
			this.treeNodeBrowserApi2FavoritesFeed = new TreeNode("Favorites feed",
				this.imageList.Images.IndexOfKey("FolderClosedVideo"),
				this.imageList.Images.IndexOfKey("FolderOpenVideo"));
			this.treeNodeBrowserApi2PlaylistFeed = new TreeNode("Playlist feed",
				this.imageList.Images.IndexOfKey("FolderClosedVideo"),
				this.imageList.Images.IndexOfKey("FolderOpenVideo"));
			this.treeNodeBrowserApi2VideosUser = new TreeNode("User videos",
				this.imageList.Images.IndexOfKey("FolderClosedUser"),
				this.imageList.Images.IndexOfKey("FolderOpenUser"),
				new TreeNode[] {
					this.treeNodeBrowserApi2User,
					this.treeNodeBrowserApi2FavoritesFeed,
					this.treeNodeBrowserApi2PlaylistFeed
				});

			this.treeNodeBrowserApi2VideoCategories = new TreeNode("Video categories",
				this.imageList.Images.IndexOfKey("Categories"),
				this.imageList.Images.IndexOfKey("Categories"));

			this.treeNodeBrowserApi2 = new TreeNode("YouTube API version 2",
				this.imageList.Images.IndexOfKey("ServerBrowse"),
				this.imageList.Images.IndexOfKey("ServerBrowse"),
				new TreeNode[] {
					this.treeNodeBrowserApi2VideosGlobal,
					this.treeNodeBrowserApi2VideosUser,
					this.treeNodeBrowserApi2VideoCategories
				});

			this.treeNodeBrowserApi3Videos = new TreeNode("Videos",
				this.imageList.Images.IndexOfKey("FolderClosedVideo"),
				this.imageList.Images.IndexOfKey("FolderOpenVideo"));
			this.treeNodeBrowserApi3 = new TreeNode("YouTube API version 3",
				this.imageList.Images.IndexOfKey("ServerBrowse"),
				this.imageList.Images.IndexOfKey("ServerBrowse"),
				new TreeNode[] {
					this.treeNodeBrowserApi3Videos
				});

			this.treeNodeBrowserWebVideos = new TreeNode("Videos",
				this.imageList.Images.IndexOfKey("FileGraphLine"),
				this.imageList.Images.IndexOfKey("FileGraphLine"));
			this.treeNodeBrowserWeb = new TreeNode("YouTube Web",
				this.imageList.Images.IndexOfKey("GlobeBrowse"),
				this.imageList.Images.IndexOfKey("GlobeBrowse"),
				new TreeNode[] {
					this.treeNodeBrowserWebVideos
				});

			this.treeNodeSettings = new TreeNode("Settings", 0, 0);

			this.treeNodeCommentsVideos = new TreeNode("Videos",
				this.imageList.Images.IndexOfKey("CommentVideo"),
				this.imageList.Images.IndexOfKey("CommentVideo"));
			this.treeNodeComments = new TreeNode("Comments",
				this.imageList.Images.IndexOfKey("Comments"),
				this.imageList.Images.IndexOfKey("Comments"),
				new TreeNode[] {
					this.treeNodeCommentsVideos
				});



			// Add the panel controls to the split container.
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2Videos);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi3);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2Video);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2FeedStandard);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2Search);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2FeedRelated);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2FeedResponse);
			this.splitContainer.Panel2.Controls.Add(this.controlWeb);
			this.splitContainer.Panel2.Controls.Add(this.controlWebStatistics);
			this.splitContainer.Panel2.Controls.Add(this.controlSettings);
			this.splitContainer.Panel2.Controls.Add(this.controlLog);
			this.splitContainer.Panel2.Controls.Add(this.controlComments);
			this.splitContainer.Panel2.Controls.Add(this.controlCommentsVideos);

			// Add the panel controls as tags.
			this.treeNodeBrowserApi2.Tag = this.controlYtApi2;
			this.treeNodeBrowserApi2VideosGlobal.Tag = this.controlYtApi2Videos;
			this.treeNodeBrowserApi2Video.Tag = this.controlYtApi2Video;
			this.treeNodeBrowserApi2SearchFeed.Tag = this.controlYtApi2Search;
			this.treeNodeBrowserApi2StandardFeed.Tag = this.controlYtApi2FeedStandard;
			this.treeNodeBrowserApi2RelatedVideosFeed.Tag = this.controlYtApi2FeedRelated;
			this.treeNodeBrowserApi2ResponseVideosFeed.Tag = this.controlYtApi2FeedResponse;
			this.treeNodeBrowserApi2VideosUser.Tag = null;
			this.treeNodeBrowserApi2User.Tag = null;
			this.treeNodeBrowserApi2Contacts.Tag = null;
			this.treeNodeBrowserApi2Playlists.Tag = null;
			this.treeNodeBrowserApi2FavoritesFeed.Tag = null;
			this.treeNodeBrowserApi2PlaylistFeed.Tag = null;
			
			this.treeNodeBrowserApi2VideoCategories.Tag = null;

			this.treeNodeBrowserApi3.Tag = this.controlYtApi3;
			this.treeNodeBrowserWeb.Tag = this.controlWeb;
			this.treeNodeBrowserWebVideos.Tag = this.controlWebStatistics;
			this.treeNodeSettings.Tag = this.controlSettings;
			this.controlPanelLog.Tag = this.controlLog;
			this.treeNodeComments.Tag = this.controlComments;
			this.treeNodeCommentsVideos.Tag = this.controlCommentsVideos;

			// Add the tree nodes to the side panel tree views.
			this.controlPanelBrowser.AddRange(
				new TreeNode[] {
					this.treeNodeBrowserApi2,
					this.treeNodeBrowserApi3,
					this.treeNodeBrowserWeb
				});
			this.controlPanelConfiguration.Add(this.treeNodeSettings);
			this.controlPanelComments.Add(this.treeNodeComments);

			// Create the side menu items
			this.sideMenuBrowse = this.sideMenu.AddItem(
				"Browser",
				Resources.ServersBrowse_16,
				Resources.ServersBrowse_32,
				this.SideMenuSelect,
				this.controlPanelBrowser
				);
			this.sideMenuConfiguration = this.sideMenu.AddItem(
				"Configuration",
				Resources.ConfigurationSettings_16,
				Resources.ConfigurationSettings_32,
				this.SideMenuSelect,
				this.controlPanelConfiguration
				);
			this.sideMenuLog = this.sideMenu.AddItem(
				"Log",
				Resources.Log_16,
				Resources.Log_32,
				this.SideMenuSelectLog,
				this.controlPanelLog
				);
			this.sideMenuComments = this.sideMenu.AddItem(
				"Comments",
				Resources.Comments_16,
				Resources.Comments_32,
				this.SideMenuSelect,
				this.controlPanelComments
				);

			// Initialize the controls.
			this.controlYtApi2Video.Initialize(this.crawler);
			this.controlYtApi2FeedStandard.Initialize(this.crawler);
			this.controlYtApi2Search.Initialize(this.crawler);
			this.controlYtApi2FeedRelated.Initialize(this.crawler, new GeneralVideosFeedEventHandler(YouTubeUri.GetRelatedVideosFeed), "APIv2 Related Videos Feed");
			this.controlYtApi2FeedResponse.Initialize(this.crawler, new GeneralVideosFeedEventHandler(YouTubeUri.GetResponseVideosFeed), "APIv2 Response Videos Feed");
			this.controlSettings.Initialize(this.crawler);
			this.controlWebStatistics.Initialize(this.crawler);
			this.controlLog.Initialize(this.crawler);
			this.controlCommentsVideos.Initialize(this.crawler);

			// Create the delegates.
			this.delegateViewVideoApiV2 = new ViewVideoEventHandler(this.ViewVideoInApiV2);
			this.delegateViewVideoApiV2Related = new ViewVideoEventHandler(this.ViewRelatedVideosInApiV2);
			this.delegateViewVideoApiV2Responses = new ViewVideoEventHandler(this.ViewResponseVideosInApiV2);
			this.delegateViewVideoApiV3 = new ViewVideoEventHandler(this.ViewVideoInApiV3);
			this.delegateViewVideoWeb = new ViewVideoEventHandler(this.ViewVideoInWeb);
			this.delegateAddVideoComment = new AddVideoCommentEventHandler(this.CommentVideo);

			// Set the control events.
			this.controlYtApi2.VideosGlobalClick += this.BrowserApi2VideosGlobalClick;
			this.controlYtApi2.VideosUserClick += this.BrowserApi2VideosUserClick;
			this.controlYtApi2.CategoriesClick += this.BrowserApi2CategoriesClick;

			this.controlYtApi2Videos.VideoClick += this.BrowserApi2VideoClick;
			this.controlYtApi2Videos.VideoCommentsClick += this.BrowserApi2VideoCommentsClick;
			this.controlYtApi2Videos.SearchFeedClick += this.BrowserApi2SearchFeedClick;
			this.controlYtApi2Videos.StandardFeedClick += this.BrowserApi2StandardFeedClick;
			this.controlYtApi2Videos.RelatedVideosFeedClick += this.BrowserApi2RelatedVideosFeedClick;
			this.controlYtApi2Videos.ResponseVideosFeedClick += this.BrowserApi2ResponseVideosFeedClick;

			this.controlWeb.ClickVideoStatistics += new EventHandler(this.BrowserWebVideosClick);

			this.controlComments.ClickVideos += new EventHandler(this.BrowserCommentsVideosClick);

			this.controlYtApi2Video.ViewVideoRelatedInApiV2 += this.delegateViewVideoApiV2Related;
			this.controlYtApi2Video.ViewVideoResponsesInApiV2 += this.delegateViewVideoApiV2Responses;
			this.controlYtApi2Video.ViewVideoInWeb += this.delegateViewVideoWeb;
			this.controlYtApi2Video.Comment += this.delegateAddVideoComment;

			this.controlYtApi2FeedStandard.ViewVideoInApiV2 += this.delegateViewVideoApiV2;
			this.controlYtApi2FeedStandard.ViewVideoRelatedInApiV2 += this.delegateViewVideoApiV2Related;
			this.controlYtApi2FeedStandard.ViewVideoResponsesInApiV2 += this.delegateViewVideoApiV2Responses;
			this.controlYtApi2FeedStandard.ViewVideoInApiV3 += this.delegateViewVideoApiV3;
			this.controlYtApi2FeedStandard.ViewVideoInWeb += this.delegateViewVideoWeb;
			this.controlYtApi2FeedStandard.Comment += this.delegateAddVideoComment;

			this.controlYtApi2Search.ViewVideoInApiV2 += this.delegateViewVideoApiV2;
			this.controlYtApi2Search.ViewVideoRelatedInApiV2 += this.delegateViewVideoApiV2Related;
			this.controlYtApi2Search.ViewVideoResponsesInApiV2 += this.delegateViewVideoApiV2Responses;
			this.controlYtApi2Search.ViewVideoInApiV3 += this.delegateViewVideoApiV3;
			this.controlYtApi2Search.ViewVideoInWeb += this.delegateViewVideoWeb;
			this.controlYtApi2Search.Comment += this.delegateAddVideoComment;

			this.controlYtApi2FeedRelated.ViewVideoInApiV2 += this.delegateViewVideoApiV2;
			this.controlYtApi2FeedRelated.ViewVideoRelatedInApiV2 += this.delegateViewVideoApiV2Related;
			this.controlYtApi2FeedRelated.ViewVideoResponsesInApiV2 += this.delegateViewVideoApiV2Responses;
			this.controlYtApi2FeedRelated.ViewVideoInApiV3 += this.delegateViewVideoApiV3;
			this.controlYtApi2FeedRelated.ViewVideoInWeb += this.delegateViewVideoWeb;
			this.controlYtApi2FeedRelated.Comment += this.delegateAddVideoComment;

			this.controlYtApi2FeedResponse.ViewVideoInApiV2 += this.delegateViewVideoApiV2;
			this.controlYtApi2FeedResponse.ViewVideoRelatedInApiV2 += this.delegateViewVideoApiV2Related;
			this.controlYtApi2FeedResponse.ViewVideoResponsesInApiV2 += this.delegateViewVideoApiV2Responses;
			this.controlYtApi2FeedResponse.ViewVideoInApiV3 += this.delegateViewVideoApiV3;
			this.controlYtApi2FeedResponse.ViewVideoInWeb += this.delegateViewVideoWeb;
			this.controlYtApi2FeedResponse.Comment += this.delegateAddVideoComment;

			this.controlWebStatistics.Comment += this.delegateAddVideoComment;

			// Selected control
			this.controlPanelSelected = this.labelNotAvailable;

			// Set the font.
			this.formatting.SetFont(this);
		}

		/// <summary>
		/// An event handler called when the selected side menu item has changed.
		/// </summary>
		/// <param name="item">The side menu item.</param>
		private void SideMenuSelect(SideMenuItem item)
		{
			// If the tag of the menu item is not null.
			if (null != item.Tag)
			{
				// Convert the tag to a control.
				ControlSide control = item.Tag as ControlSide;

				// If the selected control is different from the new control.
				if (control != this.controlSideSelected)
				{
					// If the current selected side control is not null.
					if (null != this.controlSideSelected)
					{
						// Hide that control.
						this.controlSideSelected.Hide();
					}
					// Show the control.
					control.Show();
					// Focus on the control.
					control.Select();
					// Set the selected side control.
					this.controlSideSelected = control;
				}
			}
		}

		private void SideMenuSelectLog(SideMenuItem item)
		{
			// Select the side menu item.
			this.SideMenuSelect(item);
			// Refresh the log.
			this.controlLog.DateChanged(this, new DateRangeEventArgs(this.controlPanelLog.Calendar.SelectionStart, this.controlPanelLog.Calendar.SelectionEnd));
		}

		/// <summary>
		/// An event handler called when the right panel control selection has changed.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnControlChanged(object sender, ControlEventArgs e)
		{
			// If the selected control has not changed, do nothing.
			if (e.Control == this.controlPanelSelected) return;

			// Hide the current selected control.
			if (null != this.controlPanelSelected)
			{
				this.controlPanelSelected.Hide();
			}

			// If the tree node tag is not null.
			if (null != e.Control)
			{
				// Show the control.
				e.Control.Show();
				// Set the selected control.
				this.controlPanelSelected = e.Control;
			}
			else
			{
				// Display the default message.
				this.labelNotAvailable.Show();
				// Set the selected control.
				this.controlPanelSelected = this.labelNotAvailable;
			}
		}

		private void BrowserApi2VideosGlobalClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2VideosGlobal;
		}

		private void BrowserApi2VideosUserClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2VideosUser;
		}

		private void BrowserApi2CategoriesClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2VideoCategories;
		}

		private void BrowserApi2VideoClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2Video;
		}

		private void BrowserApi2VideoCommentsClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2VideoComments;
		}

		private void BrowserApi2SearchFeedClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2SearchFeed;
		}

		private void BrowserApi2StandardFeedClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2StandardFeed;
		}

		private void BrowserApi2RelatedVideosFeedClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2RelatedVideosFeed;
		}

		private void BrowserApi2ResponseVideosFeedClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2ResponseVideosFeed;
		}

		private void BrowserWebVideosClick(object sender, EventArgs e)
		{
			//this.sideMenu.SelectedItem = this.sideMenuBrowse;
			//this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserWebVideos;
		}

		private void BrowserCommentsVideosClick(object sender, EventArgs e)
		{
			//this.sideMenu.SelectedItem = this.sideMenuComments;
			//this.controlPanelComments.SelectedNode = this.treeNodeCommentsVideos;
		}

		private void ViewVideoInApiV2(Video video)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2Video;
			this.controlYtApi2Video.View(video);
		}

		private void ViewRelatedVideosInApiV2(Video video)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2RelatedVideosFeed;
			this.controlYtApi2FeedRelated.View(video);
		}

		private void ViewResponseVideosInApiV2(Video video)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2ResponseVideosFeed;
			this.controlYtApi2FeedResponse.View(video);
		}

		private void ViewUserInApiV2(string user)
		{
		}

		//private void ViewUserInApiV2(User user)
		//{
		//}

		//private void ViewPlaylistsInApiV2(User user)
		//{
		//}

		//private void ViewContactsInApiV2(User user)
		//{
		//}

		//private void ViewFavoritesFeedInApiV2(User user)
		//{
		//}

		//private void ViewPlaylistFeedInApiV2(Playlist playlist)
		//{
		//}

		private void ViewVideoInApiV3(Video video)
		{
			MessageBox.Show(this, "Option not implemented.", "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}

		private void ViewVideoInWeb(Video video)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserWebVideos;
			this.controlWebStatistics.View(video.Id);
		}

		private void CommentVideo(string video)
		{
			this.sideMenu.SelectedItem = this.sideMenuComments;
			this.controlPanelComments.SelectedNode = this.treeNodeCommentsVideos;
			this.controlCommentsVideos.AddComment(video);
		}

		/// <summary>
		/// Closes the current window and the application.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void Close(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Opens the about form.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OpenAboutForm(object sender, EventArgs e)
		{
			this.formAbout.ShowDialog(this);
		}

		/// <summary>
		/// An event handler called when the main form has been closed.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnFormClosed(object sender, FormClosedEventArgs e)
		{
			// Close the crawler.
			this.crawler.Close();
		}

		/// <summary>
		/// An event handler called when the log date has changed.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnLogDateChanged(object sender, DateRangeEventArgs e)
		{
			// Update the log.
			this.controlLog.DateChanged(sender, e);
		}

		// private void TestApi(object sender, EventArgs e)
	   // {
	   //	 ytService.Key = FormMain.apiKey;
	   //	 this.videosResource = new VideosResource(this.ytService, new NullAuthenticator());
	   //	 this.list = this.videosResource.List("MlMj3VEYBMA", "snippet");

	   //	 try
	   //	 {
	   //		 IAsyncResult result = this.list.BeginFetch(new AsyncCallback(this.CallbackApi), this);
	   //	 }
	   //	 catch (GoogleApiRequestException exception)
	   //	 {
	   //		 this.textBoxResults.AppendText(exception.Message);
	   //	 }
	   // }

	   // private void CallbackApi(IAsyncResult result)
	   // {
	   //	 if (this.InvokeRequired)
	   //	 {
	   //		 this.Invoke(new AsyncCallback(this.CallbackApi), new object[] { result });
	   //	 }
	   //	 else
	   //	 {
	   //		 try
	   //		 {
	   //			 VideoListResponse response = this.list.EndFetch(result);

	   //			 foreach (Google.Apis.Youtube.v3.Data.Video video in response.Items)
	   //			 {
	   //				 this.textBoxResults.AppendText("ID: " + video.Id + "\r\n");
	   //				 this.textBoxResults.AppendText("Etag: " + video.ETag + "\r\n");
	   //				 this.textBoxResults.AppendText("Title: " + video.Snippet.Title + "\r\n");
	   //			 }
	   //		 }
	   //		 catch (GoogleApiRequestException exception)
	   //		 {
	   //			 this.textBoxResults.AppendText(exception.Message);
	   //		 }
	   //	 }
	   //}

	   // private void TestAjax(object sender, EventArgs e)
	   // {
	   //	 try
	   //	 {
	   //		 IAsyncResult result = this.ajaxRequest.Begin("MlMj3VEYBMA", this.CallbackAjax);
	   //	 }
	   //	 catch (Exception exception)
	   //	 {
	   //		 this.textBoxResults.AppendText(exception.Message);
	   //	 }
	   // }

	   // private void CallbackAjax(IAsyncResult result)
	   // {
	   //	 if (this.InvokeRequired)
	   //	 {
	   //		 this.Invoke(new AsyncCallback(this.CallbackAjax), new object[] { result });
	   //	 }
	   //	 else
	   //	 {
	   //		 try
	   //		 {
	   //			 YtApi.Ajax.AjaxVideoStatistics statistics = this.ajaxRequest.End(result);

	   //			 // Serialize the statistics object
	   //			 BinaryFormatter formatter = new BinaryFormatter();
	   //			 MemoryStream streamWrite = new MemoryStream();
	   //			 formatter.Serialize(streamWrite, statistics);

	   //			 string data = Convert.ToBase64String(streamWrite.ToArray());

	   //			 MemoryStream streamRead = new MemoryStream();
	   //			 byte[] bytes = Convert.FromBase64String(data);
	   //			 streamRead.Write(bytes, 0, bytes.Length);

	   //			 streamRead.Seek(0, SeekOrigin.Begin);

	   //			 YtApi.Ajax.AjaxVideoStatistics stat = (YtApi.Ajax.AjaxVideoStatistics)formatter.Deserialize(streamRead);

	   //			 this.textBoxResults.AppendText(data);
	   //		 }
	   //		 catch (Exception exception)
	   //		 {
	   //			 this.textBoxResults.AppendText(exception.GetType().ToString() + " " + exception.Message);
	   //		 }
	   //	 }
	   // }

	   // private void TestCrawl(object sender, EventArgs e)
	   // {
	   //	 try
	   //	 {
	   //		 IAsyncResult result = this.ytRequest.Begin(new Uri("https://gdata.youtube.com/feeds/api/standardfeeds/most_popular"), this.CallbackCrawl);
	   //	 }
	   //	 catch (Exception exception)
	   //	 {
	   //		 this.textBoxResults.AppendText(exception.Message);
	   //	 }
	   // }

	   // private void CallbackCrawl(IAsyncResult result)
	   // {
	   //	 if (this.InvokeRequired)
	   //	 {
	   //		 this.Invoke(new AsyncCallback(this.CallbackCrawl), new object[] { result });
	   //	 }
	   //	 else
	   //	 {
	   //		 try
	   //		 {
	   //			 Feed<YtApi.Api.V2.Data.Video> feed = this.ytRequest.EndFeedVideo(result);
	   //		 }
	   //		 catch (Exception exception)
	   //		 {
	   //			 this.textBoxResults.AppendText(exception.GetType().ToString() + " " + exception.Message);
	   //		 }
	   //	 }
	   // }

	   // private void TestCategories(object sender, EventArgs e)
	   // {
	   //	 try
	   //	 {
	   //		 this.textBoxResults.AppendText("Categories refresh started...\r\n");
	   //		 IAsyncResult result = this.ytCategories.BeginRefresh(this.CallbackCategories, null);
	   //	 }
	   //	 catch (YouTubeException exception)
	   //	 {
	   //		 this.textBoxResults.AppendText(exception.GetType().ToString() + " " + exception.Message);
	   //	 }
	   // }

	   // private void CallbackCategories(IAsyncResult result)
	   // {
	   //	 if (this.InvokeRequired)
	   //	 {
	   //		 this.Invoke(new AsyncCallback(this.CallbackCategories), new object[] { result });
	   //	 }
	   //	 else
	   //	 {
	   //		 try
	   //		 {
	   //			 this.ytCategories.EndRefresh(result);
	   //			 this.textBoxResults.AppendText("Categories refresh completed.\r\n");
	   //		 }
	   //		 catch (Exception exception)
	   //		 {
	   //			 this.textBoxResults.AppendText(exception.GetType().ToString() + " " + exception.Message);
	   //		 }
	   //	 }
	   // }
	}
}
