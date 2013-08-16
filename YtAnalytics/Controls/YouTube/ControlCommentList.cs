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
using YtAnalytics.Forms;
using YtApi.Api.V2.Data;

namespace YtAnalytics.Controls.YouTube
{
	/// <summary>
	/// A control to display a list of comments.
	/// </summary>
	public partial class ControlCommentList : ThreadSafeControl
	{
		private int? countStart = null;
		private int? countPerPage = null;
		private int? countTotal = null;
		private string pageBegin;
		private string pageEnd;
		private string pageTotal;
		private static int[] commentsPerPageInt = new int[] { 10, 25, 50 };
		private static object[] commentsPerPageObject = new object[] { 10, 25, 50 };

		/// <summary>
		/// Constructor.
		/// </summary>
		public ControlCommentList()
		{
			// Initialize the component.
			InitializeComponent();

			// Set the component defaults.
			this.comboBoxCommentsPerPage.Items.AddRange(ControlCommentList.commentsPerPageObject);
			this.comboBoxCommentsPerPage.SelectedIndex = 1;

			this.pageBegin = this.countStart != null ? this.countStart.ToString() : "?";
			this.pageEnd = (this.countStart != null) && (this.countPerPage != null) ? this.PageEnd(this.countStart ?? -1, this.countPerPage ?? -1).ToString() : "?";
			this.pageTotal = this.countTotal != null ? this.countTotal.ToString() : "?";

			this.labelPage.Text = "{0} - {1} of {2}".FormatWith(this.pageBegin, this.pageEnd, this.pageTotal);
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
		/// An event raised when the number of comments per page has changed.
		/// </summary>
		public event EventHandler CommentsPerPageChanged;


		/// <summary>
		/// Gets or sets the start comments count. 
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
		/// Gets or sets the comments per page count.
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
		/// Gets or sets the total comments count.
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
		/// Gets the number of comments per page.
		/// </summary>
		public int CommentsPerPage { get { return ControlCommentList.commentsPerPageInt[this.comboBoxCommentsPerPage.SelectedIndex]; } }

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
		/// Adds a new comment to the list.
		/// </summary>
		/// <param name="comment">The comment.</param>
		public void Add(Comment comment)
		{
			ListViewItem item = new ListViewItem(
				new string[] {
					comment.Published != null ? comment.Published.Value.ToString() : comment.Updated.ToString(),
					comment.Author != null ? comment.Author.UserId : string.Empty,
					comment.Title
				},
				0);
			item.Tag = comment;

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
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnPreviousClick(object sender, EventArgs e)
		{
			if (this.PreviousClick != null) this.PreviousClick(sender, e);
		}

		/// <summary>
		/// An event handler called when the user clicks on the next button.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNextClick(object sender, EventArgs e)
		{
			if (this.NextClick != null) this.NextClick(sender, e);
		}

		/// <summary>
		/// An event handler called when the item selection has changed.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			this.controlComment.Comment = (this.listView.SelectedItems.Count != 0) ? this.listView.SelectedItems[0].Tag as Comment : null;
		}

		/// <summary>
		/// An event handler called when the number of comments per page has changed.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCommentsPerPageChanged(object sender, EventArgs e)
		{
			if (this.CommentsPerPageChanged != null) this.CommentsPerPageChanged(sender, e);
		}
	}
}
