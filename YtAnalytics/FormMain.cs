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
		private TreeNode treeNodeBrowserApi2VideoFeeds;
		private TreeNode treeNodeBrowserApi2VideoFeedsEntry;
		private TreeNode treeNodeBrowserApi2VideoFeedsStandard;
		private TreeNode treeNodeBrowserApi2VideoFeedsVideos;
		private TreeNode treeNodeBrowserApi2VideoFeedsRelated;
		private TreeNode treeNodeBrowserApi2VideoFeedsResponses;
		private TreeNode treeNodeBrowserApi2VideoFeedsFavorites;
		private TreeNode treeNodeBrowserApi2VideoFeedsPlaylist;
		private TreeNode treeNodeBrowserApi2UserPlaylists;
		private TreeNode treeNodeBrowserApi2UserSubscriptions;
		private TreeNode treeNodeBrowserApi2VideoComments;
		private TreeNode treeNodeBrowserApi2UserProfile;
		private TreeNode treeNodeBrowserApi2UserContacts;
		private TreeNode treeNodeBrowserApi2Categories;

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
		private ControlYtApi2VideoFeeds controlYtApi2VideoFeeds = new ControlYtApi2VideoFeeds();
		private ControlYtApi2VideoEntry controlYtApi2VideoEntry = new ControlYtApi2VideoEntry();
		private ControlYtApi2StandardFeed controlYtApi2StandardFeed = new ControlYtApi2StandardFeed();
		private ControlYtApi2VideosFeed controlYtApi2VideosFeed = new ControlYtApi2VideosFeed();
		private ControlYtApi2GeneralVideosFeed controlYtApi2RelatedVideosFeed = new ControlYtApi2GeneralVideosFeed();
		private ControlYtApi2GeneralVideosFeed controlYtApi2ResponseVideosFeed = new ControlYtApi2GeneralVideosFeed();
		private ControlYtApi3 controlYtApi3 = new ControlYtApi3();
		private ControlWeb controlWeb = new ControlWeb();
		private ControlWebStatistics controlWebStatistics = new ControlWebStatistics();
		private ControlSettings controlSettings = new ControlSettings();
		private ControlLog controlLog = new ControlLog();
		private ControlComments controlComments = new ControlComments();
		private ControlCommentsVideos controlCommentsVideos = new ControlCommentsVideos();

		// Forms.
		private FormAbout formAbout = new FormAbout();

		// Image indices.
		private static int imageServerBrowse = 0;
		private static int imageFolderClosedXml = 1;
		private static int imageFolderOpenXml = 2;
		private static int imageFileXml = 3;
		private static int imageFileVideo = 4;
		private static int imageFileUser = 5;
		private static int imageGlobeBrowse = 6;
		private static int imageFileGraphLine = 7;
		private static int imageCategories = 8;
		private static int imageComments = 9;
		private static int imageCommentVideo = 10;

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
			this.treeNodeBrowserApi2VideoFeedsEntry = new TreeNode("Video entry", imageFileVideo, imageFileVideo);
			this.treeNodeBrowserApi2VideoFeedsStandard = new TreeNode("Standard feeds", imageFileXml, imageFileXml);
			this.treeNodeBrowserApi2VideoFeedsVideos = new TreeNode("Videos feed", imageFileXml, imageFileXml);
			this.treeNodeBrowserApi2VideoFeedsRelated = new TreeNode("Related videos feed", imageFileXml, imageFileXml);
			this.treeNodeBrowserApi2VideoFeedsResponses = new TreeNode("Response videos feed", imageFileXml, imageFileXml);
			this.treeNodeBrowserApi2VideoFeedsFavorites = new TreeNode("User favorites feed", imageFileXml, imageFileXml);
			this.treeNodeBrowserApi2VideoFeedsPlaylist = new TreeNode("Playlist feed", imageFileXml, imageFileXml);
			this.treeNodeBrowserApi2VideoFeeds = new TreeNode("Video feeds", imageFolderClosedXml, imageFolderOpenXml,
				new TreeNode[] {
					this.treeNodeBrowserApi2VideoFeedsEntry,
					this.treeNodeBrowserApi2VideoFeedsStandard,
					this.treeNodeBrowserApi2VideoFeedsVideos,
					this.treeNodeBrowserApi2VideoFeedsRelated,
					this.treeNodeBrowserApi2VideoFeedsResponses,
					this.treeNodeBrowserApi2VideoFeedsFavorites,
					this.treeNodeBrowserApi2VideoFeedsPlaylist
				});
			this.treeNodeBrowserApi2UserPlaylists = new TreeNode("User's playlists feed", imageFileXml, imageFileXml);
			this.treeNodeBrowserApi2UserSubscriptions = new TreeNode("User's subscription feed", imageFileXml, imageFileXml);
			this.treeNodeBrowserApi2VideoComments = new TreeNode("Video comments feed", imageFileXml, imageFileXml);
			this.treeNodeBrowserApi2UserProfile = new TreeNode("User profile entry", imageFileUser, imageFileUser);
			this.treeNodeBrowserApi2UserContacts = new TreeNode("User's contacts feed", imageFileXml, imageFileXml);
			this.treeNodeBrowserApi2Categories = new TreeNode("Categories", imageCategories, imageCategories);
			this.treeNodeBrowserApi2 = new TreeNode("YouTube API version 2", imageServerBrowse, imageServerBrowse,
				new TreeNode[] {
					this.treeNodeBrowserApi2VideoFeeds,
					this.treeNodeBrowserApi2UserProfile,
					this.treeNodeBrowserApi2UserPlaylists,
					this.treeNodeBrowserApi2UserSubscriptions,
					this.treeNodeBrowserApi2VideoComments,
					this.treeNodeBrowserApi2UserContacts,
					this.treeNodeBrowserApi2Categories
				});

			this.treeNodeBrowserApi3Videos = new TreeNode("Videos", imageFileXml, imageFileXml);
			this.treeNodeBrowserApi3 = new TreeNode("YouTube API version 3", imageServerBrowse, imageServerBrowse,
				new TreeNode[] {
					this.treeNodeBrowserApi3Videos
				});

			this.treeNodeBrowserWebVideos = new TreeNode("Videos", imageFileGraphLine, imageFileGraphLine);
			this.treeNodeBrowserWeb = new TreeNode("YouTube Web", imageGlobeBrowse, imageGlobeBrowse,
				new TreeNode[] {
					this.treeNodeBrowserWebVideos
				});

			this.treeNodeSettings = new TreeNode("Settings", 0, 0);

			this.treeNodeCommentsVideos = new TreeNode("Videos", imageCommentVideo, imageCommentVideo);
			this.treeNodeComments = new TreeNode("Comments", imageComments, imageComments,
				new TreeNode[] {
					this.treeNodeCommentsVideos
				});

			// Add the panel controls to the split container.
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2VideoFeeds);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi3);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2VideoEntry);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2StandardFeed);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2VideosFeed);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2RelatedVideosFeed);
			this.splitContainer.Panel2.Controls.Add(this.controlYtApi2ResponseVideosFeed);
			this.splitContainer.Panel2.Controls.Add(this.controlWeb);
			this.splitContainer.Panel2.Controls.Add(this.controlWebStatistics);
			this.splitContainer.Panel2.Controls.Add(this.controlSettings);
			this.splitContainer.Panel2.Controls.Add(this.controlLog);
			this.splitContainer.Panel2.Controls.Add(this.controlComments);
			this.splitContainer.Panel2.Controls.Add(this.controlCommentsVideos);

			// Add the panel controls as tags.
			this.treeNodeBrowserApi2.Tag = this.controlYtApi2;
			this.treeNodeBrowserApi2VideoFeeds.Tag = this.controlYtApi2VideoFeeds;
			this.treeNodeBrowserApi2VideoFeedsEntry.Tag = this.controlYtApi2VideoEntry;
			this.treeNodeBrowserApi2VideoFeedsStandard.Tag = this.controlYtApi2StandardFeed;
			this.treeNodeBrowserApi2VideoFeedsVideos.Tag = this.controlYtApi2VideosFeed;
			this.treeNodeBrowserApi2VideoFeedsRelated.Tag = this.controlYtApi2RelatedVideosFeed;
			this.treeNodeBrowserApi2VideoFeedsResponses.Tag = this.controlYtApi2ResponseVideosFeed;
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
			this.controlYtApi2VideoEntry.Initialize(this.crawler);
			this.controlYtApi2StandardFeed.Initialize(this.crawler);
			this.controlYtApi2VideosFeed.Initialize(this.crawler);
			this.controlYtApi2RelatedVideosFeed.Initialize(this.crawler, new GeneralVideosFeedEventHandler(YouTubeUri.GetRelatedVideosFeed), "APIv2 Related Videos Feed");
			this.controlYtApi2ResponseVideosFeed.Initialize(this.crawler, new GeneralVideosFeedEventHandler(YouTubeUri.GetResponseVideosFeed), "APIv2 Response Videos Feed");
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
			this.controlYtApi2.ClickVideoFeeds += new EventHandler(this.BrowserApi2VideoFeedsClick);
			this.controlYtApi2.ClickUserPlaylistsFeed += new EventHandler(this.BrowserApi2UserPlaylistsClick);
			this.controlYtApi2.ClickUserSubscriptionsFeed += new EventHandler(this.BrowserApi2UserSubscriptionsClick);
			this.controlYtApi2.ClickVideoCommentsFeed += new EventHandler(this.BrowserApi2VideoCommentsClick);
			this.controlYtApi2.ClickUserProfileEntry += new EventHandler(this.BrowserApi2UserProfileClick);
			this.controlYtApi2.ClickUserContactsFeed += new EventHandler(this.BrowserApi2UserContactsClick);
			this.controlYtApi2.ClickCategories += new EventHandler(this.BrowserApi2CategoriesClick);

			this.controlYtApi2VideoFeeds.ClickStandardFeed += new EventHandler(this.BrowserApi2VideoFeedsStandardClick);
			this.controlYtApi2VideoFeeds.ClickVideosFeed += new EventHandler(this.BrowserApi2VideoFeedsVideosClick);
			this.controlYtApi2VideoFeeds.ClickRelatedVideosFeed += new EventHandler(this.BrowserApi2VideoFeedsRelatedClick);
			this.controlYtApi2VideoFeeds.ClickVideoResponsesFeed += new EventHandler(this.BrowserApi2VideoFeedsResponsesClick);
			this.controlYtApi2VideoFeeds.ClickUserFavoritesFeed += new EventHandler(this.BrowserApi2VideoFeedsFavoritesClick);
			this.controlYtApi2VideoFeeds.ClickPlaylistFeed += new EventHandler(this.BrowserApi2VideoFeedsPlaylistClick);
			this.controlYtApi2VideoFeeds.ClickVideoEntry += new EventHandler(this.BrowserApi2VideoFeedsEntryClick);

			this.controlWeb.ClickVideoStatistics += new EventHandler(this.BrowserWebVideosClick);

			this.controlComments.ClickVideos += new EventHandler(this.BrowserCommentsVideosClick);

			this.controlYtApi2VideoEntry.ViewVideoRelatedInApiV2 += this.delegateViewVideoApiV2Related;
			this.controlYtApi2VideoEntry.ViewVideoResponsesInApiV2 += this.delegateViewVideoApiV2Responses;
			this.controlYtApi2VideoEntry.ViewVideoInWeb += this.delegateViewVideoWeb;
			this.controlYtApi2VideoEntry.Comment += this.delegateAddVideoComment;

			this.controlYtApi2StandardFeed.ViewVideoInApiV2 += this.delegateViewVideoApiV2;
			this.controlYtApi2StandardFeed.ViewVideoRelatedInApiV2 += this.delegateViewVideoApiV2Related;
			this.controlYtApi2StandardFeed.ViewVideoResponsesInApiV2 += this.delegateViewVideoApiV2Responses;
			this.controlYtApi2StandardFeed.ViewVideoInApiV3 += this.delegateViewVideoApiV3;
			this.controlYtApi2StandardFeed.ViewVideoInWeb += this.delegateViewVideoWeb;
			this.controlYtApi2StandardFeed.Comment += this.delegateAddVideoComment;

			this.controlYtApi2VideosFeed.ViewVideoInApiV2 += this.delegateViewVideoApiV2;
			this.controlYtApi2VideosFeed.ViewVideoRelatedInApiV2 += this.delegateViewVideoApiV2Related;
			this.controlYtApi2VideosFeed.ViewVideoResponsesInApiV2 += this.delegateViewVideoApiV2Responses;
			this.controlYtApi2VideosFeed.ViewVideoInApiV3 += this.delegateViewVideoApiV3;
			this.controlYtApi2VideosFeed.ViewVideoInWeb += this.delegateViewVideoWeb;
			this.controlYtApi2VideosFeed.Comment += this.delegateAddVideoComment;

			this.controlYtApi2RelatedVideosFeed.ViewVideoInApiV2 += this.delegateViewVideoApiV2;
			this.controlYtApi2RelatedVideosFeed.ViewVideoRelatedInApiV2 += this.delegateViewVideoApiV2Related;
			this.controlYtApi2RelatedVideosFeed.ViewVideoResponsesInApiV2 += this.delegateViewVideoApiV2Responses;
			this.controlYtApi2RelatedVideosFeed.ViewVideoInApiV3 += this.delegateViewVideoApiV3;
			this.controlYtApi2RelatedVideosFeed.ViewVideoInWeb += this.delegateViewVideoWeb;
			this.controlYtApi2RelatedVideosFeed.Comment += this.delegateAddVideoComment;

			this.controlYtApi2ResponseVideosFeed.ViewVideoInApiV2 += this.delegateViewVideoApiV2;
			this.controlYtApi2ResponseVideosFeed.ViewVideoRelatedInApiV2 += this.delegateViewVideoApiV2Related;
			this.controlYtApi2ResponseVideosFeed.ViewVideoResponsesInApiV2 += this.delegateViewVideoApiV2Responses;
			this.controlYtApi2ResponseVideosFeed.ViewVideoInApiV3 += this.delegateViewVideoApiV3;
			this.controlYtApi2ResponseVideosFeed.ViewVideoInWeb += this.delegateViewVideoWeb;
			this.controlYtApi2ResponseVideosFeed.Comment += this.delegateAddVideoComment;

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

		private void BrowserApi2VideoFeedsClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2VideoFeeds;
		}

		private void BrowserApi2UserPlaylistsClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2UserPlaylists;
		}

		private void BrowserApi2UserSubscriptionsClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2UserSubscriptions;
		}

		private void BrowserApi2VideoCommentsClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2VideoComments;
		}

		private void BrowserApi2UserProfileClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2UserProfile;
		}

		private void BrowserApi2UserContactsClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2UserContacts;
		}

		private void BrowserApi2CategoriesClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2Categories;
		}

		private void BrowserApi2VideoFeedsEntryClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2VideoFeedsEntry;
		}

		private void BrowserApi2VideoFeedsStandardClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2VideoFeedsStandard;
		}

		private void BrowserApi2VideoFeedsVideosClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2VideoFeedsVideos;
		}

		private void BrowserApi2VideoFeedsRelatedClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2VideoFeedsRelated;
		}

		private void BrowserApi2VideoFeedsResponsesClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2VideoFeedsResponses;
		}

		private void BrowserApi2VideoFeedsFavoritesClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2VideoFeedsFavorites;
		}

		private void BrowserApi2VideoFeedsPlaylistClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2VideoFeedsPlaylist;
		}

		private void BrowserWebVideosClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserWebVideos;
		}

		private void BrowserCommentsVideosClick(object sender, EventArgs e)
		{
			this.sideMenu.SelectedItem = this.sideMenuComments;
			this.controlPanelComments.SelectedNode = this.treeNodeCommentsVideos;
		}

		private void ViewVideoInApiV2(Video video)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2VideoFeedsEntry;
			this.controlYtApi2VideoEntry.View(video);
		}

		private void ViewRelatedVideosInApiV2(Video video)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2VideoFeedsRelated;
			this.controlYtApi2RelatedVideosFeed.View(video);
		}

		private void ViewResponseVideosInApiV2(Video video)
		{
			this.sideMenu.SelectedItem = this.sideMenuBrowse;
			this.controlPanelBrowser.SelectedNode = this.treeNodeBrowserApi2VideoFeedsResponses;
			this.controlYtApi2ResponseVideosFeed.View(video);
		}

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
