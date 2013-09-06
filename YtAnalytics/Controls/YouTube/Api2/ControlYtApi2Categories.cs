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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YtApi.Api.V2;
using YtApi.Api.V2.Data;
using YtCrawler;
using YtCrawler.Log;
using YtAnalytics.Controls;
using DotNetApi;
using DotNetApi.Web;
using DotNetApi.Windows.Controls;

namespace YtAnalytics.Controls.YouTube.Api2
{
	/// <summary>
	/// A class representing the control to browse the video entry in the YouTube API version 2.
	/// </summary>
	public partial class ControlYtApi2Categories : NotificationControl
	{
		private static string logSource = "APIv2 Categories";

		private Crawler crawler;

		private IAsyncResult asyncResult = null;

		/// <summary>
		/// Creates a new instance of the control.
		/// </summary>
		public ControlYtApi2Categories()
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
			// Set the crawler.
			this.crawler = crawler;

			// Update the list of categories.
			this.OnUpdateList();
		}

		// Private methods.

		/// <summary>
		/// An event handler called when the user refreshes the categories list.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnRefresh(object sender, EventArgs e)
		{
			// Show a message to alert the user.
			this.ShowMessage(Resources.GlobeClock_48, "Video Categories", "Refreshing the list of YouTube categories...");
			// Disable the refresh button.
			this.buttonRefresh.Enabled = false;
			// Enable the cancel button.
			this.buttonCancel.Enabled = true;
			try
			{
				// Begin an asynchronous refresh of the YouTube categories.
				this.asyncResult = this.crawler.Categories.BeginRefresh((AsyncWebResult asyncResult) =>
					{
						try
						{
							// Complete the asynchronous request.
							this.crawler.Categories.EndRefresh(asyncResult);
							// Update the message that the operation completed successfully.
							this.ShowMessage(
								Resources.GlobeSuccess_48,
								"Video Categories",
								"Refreshing the list of YouTube categories completed successfully.",
								false,
								(int)CrawlerStatic.ConsoleMessageCloseDelay.TotalMilliseconds,
								this.OnUpdateList
								);
							// Log
							this.log.Add(this.crawler.Log.Add(
								LogEventLevel.Verbose,
								LogEventType.Success,
								ControlYtApi2Categories.logSource,
								"The list of YouTube categories was updated successfully."));
						}
						catch (Exception exception)
						{
							// Update the message that the operation failed.
							this.ShowMessage(
								Resources.GlobeError_48,
								"Video Categories",
								"Refreshing the list of YouTube categories failed.{0}{1}".FormatWith(Environment.NewLine, exception.Message),
								false
								);
							// Log
							this.log.Add(this.crawler.Log.Add(
								LogEventLevel.Important,
								LogEventType.Error,
								ControlYtApi2Categories.logSource,
								"Updating the list of YouTube categories failed. {0}",
								new object[] { exception.Message },
								exception));
						}
						finally
						{
							// Set the asynchronous result to null.
							this.asyncResult = null;
							// Delay the closing of the user message.
							Thread.Sleep(CrawlerStatic.ConsoleMessageCloseDelay);
							// Hide the progress message.
							this.HideMessage((object[] parameters) =>
							{
								this.buttonRefresh.Enabled = true;
								this.buttonCancel.Enabled = false;
							});
						}
					});
			}
			catch (Exception exception)
			{				
				// Update the message that the operation failed.
				this.ShowMessage(
					Resources.GlobeError_48,
					"Video Categories",
					"Refreshing the list of YouTube categories failed.{0}{1}".FormatWith(Environment.NewLine, exception.Message),
					false
					);
				// Wait on the thread pool to finish the refresh operation.
				ThreadPool.QueueUserWorkItem((object state) =>
					{
						// Delay the closing of the user message.
						Thread.Sleep(CrawlerStatic.ConsoleMessageCloseDelay);
						// Hide the progress message.
						this.HideMessage((object[] parameters) =>
						{
							this.buttonRefresh.Enabled = true;
							this.buttonCancel.Enabled = false;
						});
					});
			}
		}

		/// <summary>
		/// Cancels the current asynchronous operation.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCancel(object sender, EventArgs e)
		{
			// If the asynchronous result is null, do nothing.
			if (null != this.asyncResult) return;
			// Else, cancel the refresh.
			this.crawler.Categories.Cancel(this.asyncResult);
			// Disable the cancel button.
			this.buttonCancel.Enabled = false;
		}

		/// <summary>
		/// An event handler called when updating the list of video categories.
		/// </summary>
		/// <param name="parameters">The task parameters.</param>
		private void OnUpdateList(object[] parameters = null)
		{
			// Clear the list view.
			this.listView.Items.Clear();
			// Add the categories to the list view.
			foreach (YouTubeCategory category in this.crawler.Categories)
			{
				// Create a new list item.
				ListViewItem item = new ListViewItem(new string[] {
					category.Term,
					category.Label,
					category.IsAssignable ? "Yes" : "No",
					category.IsDeprecated ? "Yes" : "No"
				});
				item.ImageIndex = 0;
				item.Tag = category;
				// Add the item to the list.
				this.listView.Items.Add(item);
			}
		}

		/// <summary>
		/// An event handler called when the selected category has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelectedCategoryChanged(object sender, EventArgs e)
		{
			// If there are no selected items, set the category to null.
			if (this.listView.SelectedItems.Count == 0)
			{
				this.controlCategory.Catergory = null;
			}
			// Else, set the current category.
			else
			{
				this.controlCategory.Catergory = this.listView.SelectedItems[0].Tag as YouTubeCategory;
			}
		}
	}
}
