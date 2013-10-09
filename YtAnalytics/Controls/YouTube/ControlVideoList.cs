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
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Windows.Controls;
using YtAnalytics.Controls.YouTube.Api2;
using YtAnalytics.Events;
using YtAnalytics.Forms;
using YtApi.Api.V2.Data;

namespace YtAnalytics.Controls.YouTube
{
	/// <summary>
	/// A control to display a list of videos.
	/// </summary>
	public partial class ControlVideoList : ThreadSafeControl
	{
		private int? countStart = null;
		private int? countPerPage = null;
		private int? countTotal = null;
		private string pageBegin;
		private string pageEnd;
		private string pageTotal;
		private static readonly int[] videosPerPageInt = new int[] { 10, 25, 50 };
		private static readonly object[] videosPerPageObject = new object[] { 10, 25, 50 };

		private readonly FormVideo formVideo = new FormVideo();

		private ContextMenuStrip contextMenu = null;

		/// <summary>
		/// Constructor.
		/// </summary>
		public ControlVideoList()
		{
			// Initialize the component.
			InitializeComponent();

			// Set the component defaults.
			this.comboBoxVideosPerPage.Items.AddRange(ControlVideoList.videosPerPageObject);
			this.comboBoxVideosPerPage.SelectedIndex = 1;

			this.pageBegin = this.countStart != null ? this.countStart.ToString() : "?";
			this.pageEnd = (this.countStart != null) && (this.countPerPage != null) ? this.PageEnd(this.countStart ?? -1, this.countPerPage ?? -1).ToString() : "?";
			this.pageTotal = this.countTotal != null ? this.countTotal.ToString() : "?";

			this.labelPage.Text = "{0} - {1} of {2}".FormatWith(this.pageBegin, this.pageEnd, this.pageTotal);

			this.formVideo.ViewProfile += this.OnViewProfile;
		}

		/// <summary>
		/// An event raised when the user clicks on the previous page button.
		/// </summary>
		public event EventHandler PreviousClick;
		/// <summary>
		/// An event raised when the user clicks on the next page button.
		/// </summary>
		public event EventHandler NextClick;
		/// <summary>
		/// An event raised when the video selection has changed.
		/// </summary>
		public event EventHandler VideoSelectionChanged;
		/// <summary>
		/// An event raised when the number of videos per page has changed.
		/// </summary>
		public event EventHandler VideosPerPageChanged;
		/// <summary>
		/// An event raised to view the user profile.
		/// </summary>
		public event StringEventHandler ViewProfile;

		/// <summary>
		/// Gets or sets the start video count. 
		/// </summary>
		public int? CountStart
		{
			get { return this.countStart; }
			set
			{
				this.countStart = value;

				this.pageBegin = this.countStart != null ? this.countStart.ToString() : "?";
				this.pageEnd = (this.countStart != null) && (this.countPerPage != null) ? this.PageEnd(this.countStart ?? -1, this.countPerPage ?? -1).ToString() : "?";

				this.labelPage.Text = "{0} - {1} of {2}".FormatWith(this.pageBegin, this.pageEnd, this.pageTotal);
			}
		}

		/// <summary>
		/// Gets or sets the videos per page count.
		/// </summary>
		public int? CountPerPage
		{
			get { return this.countPerPage; }
			set
			{
				this.countPerPage = value;
				
				this.pageBegin = this.countStart != null ? this.countStart.ToString() : "?";
				this.pageEnd = (this.countStart != null) && (this.countPerPage != null) ? this.PageEnd(this.countStart ?? -1, this.countPerPage ?? -1).ToString() : "?";

				this.labelPage.Text = "{0} - {1} of {2}".FormatWith(this.pageBegin, this.pageEnd, this.pageTotal);
			}
		}

		/// <summary>
		/// Gets or sets the total videos count.
		/// </summary>
		public int? CountTotal
		{
			get { return this.countTotal; }
			set
			{
				this.countTotal = value;

				this.pageTotal = this.countTotal != null ? this.countTotal.ToString() : "?";

				this.labelPage.Text = "{0} - {1} of {2}".FormatWith(this.pageBegin, this.pageEnd, this.pageTotal);
			}
		}

		/// <summary>
		/// Gets the number of videos per page.
		/// </summary>
		public int VideosPerPage { get { return ControlVideoList.videosPerPageInt[this.comboBoxVideosPerPage.SelectedIndex]; } }

		/// <summary>
		/// Gets the first selected item or null, if no items are selected.
		/// </summary>
		public ListViewItem SelectedItem
		{
			get { return this.listView.SelectedItems.Count > 0 ? this.listView.SelectedItems[0] : null; }
		}

		/// <summary>
		/// Gets or sets the enabled state of the previous button.
		/// </summary>
		public bool Previous
		{
			get { return this.buttonPrevious.Enabled; }
			set { this.buttonPrevious.Enabled = value; }
		}

		/// <summary>
		/// Gets or sets the enabled state of the next button.
		/// </summary>
		public bool Next
		{
			get { return this.buttonNext.Enabled; }
			set { this.buttonNext.Enabled = value; }
		}

		/// <summary>
		/// Gets or sets the video context menu.
		/// </summary>
		public ContextMenuStrip VideoContextMenu
		{
			get { return this.contextMenu; }
			set { this.contextMenu = value; }
		}

		/// <summary>
		/// Adds a new video to the list.
		/// </summary>
		/// <param name="video">The video.</param>
		public void Add(Video video)
		{
			ListViewItem item = new ListViewItem(
				new string[] { video.Id, video.Title, video.Published != null ? video.Published.ToString() : string.Empty, video.Duration != null ? video.Duration.ToString() : string.Empty },
				0);
			item.Tag = video;

			this.listView.Items.Add(item);
		}

		/// <summary>
		/// Clears all video items from the list.
		/// </summary>
		public void Clear()
		{
			this.listView.Items.Clear();
			this.buttonNext.Enabled = false;
			this.buttonPrevious.Enabled = false;
			if (this.VideoSelectionChanged != null) this.VideoSelectionChanged(this, null);
		}

		/// <summary>
		/// Opens the properties dialog for the selected video.
		/// </summary>
		public void ShowProperties()
		{
			if (this.listView.SelectedItems.Count != 0)
				this.formVideo.ShowDialog(this, this.listView.SelectedItems[0].Tag as Video);
		}

		/// <summary>
		/// Computes the end index.
		/// </summary>
		/// <param name="countStart">The start index.</param>
		/// <param name="countPerPage">The count per page.</param>
		/// <returns>The end index.</returns>
		private int PageEnd(int countStart, int countPerPage)
		{
			return countPerPage > 0 ? countStart + countPerPage - 1 : countStart;
		}

		/// <summary>
		/// An event handler called when the user clicks on the previous button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnPreviousClick(object sender, EventArgs e)
		{
			if (this.PreviousClick != null) this.PreviousClick(sender, e);
		}

		/// <summary>
		/// An event handler called when the user clicks on the next button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNextClick(object sender, EventArgs e)
		{
			if (this.NextClick != null) this.NextClick(sender, e);
		}

		/// <summary>
		/// An event handler called when the item selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (this.VideoSelectionChanged != null) this.VideoSelectionChanged(sender, e);
		}

		/// <summary>
		/// An event handler called when the number of videos per page has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnVideoPerPageChanged(object sender, EventArgs e)
		{
			if (this.VideosPerPageChanged != null) this.VideosPerPageChanged(sender, e);
		}

		/// <summary>
		/// An event handler called when an item is activated.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnItemActivate(object sender, EventArgs e)
		{
			if (this.listView.SelectedItems.Count != 0)
				this.formVideo.ShowDialog(this, this.listView.SelectedItems[0].Tag as Video);
		}

		/// <summary>
		/// An event handler called when the user mouse clicks the control.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnMouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if (this.listView.FocusedItem != null)
				{
					if (this.listView.FocusedItem.Bounds.Contains(e.Location))
					{
						this.contextMenu.Show(this.listView, e.Location);
					}
				}
			}
		}

		/// <summary>
		/// An event handler called to view the user profile.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		void OnViewProfile(object sender, StringEventArgs e)
		{
			if (this.ViewProfile != null) this.ViewProfile(sender, e);
		}
	}
}
