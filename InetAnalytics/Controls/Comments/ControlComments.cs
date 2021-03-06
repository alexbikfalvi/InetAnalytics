﻿/* 
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
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Windows.Controls;
using InetAnalytics.Events;
using InetAnalytics.Forms.Comments;
using InetCrawler;
using InetCrawler.Comments;

namespace InetAnalytics.Controls.Comments
{
	/// <summary>
	/// A control displaying a list of comments.
	/// </summary>
	public partial class ControlComments : ThreadSafeControl
	{
		private CrawlerCommentsList comments;

		private readonly FormAddComment formAdd = new FormAddComment();
		private readonly FormCommentProperties formComment = new FormCommentProperties();

		private static readonly string[] commentTypeHeader = { "Video", "User", "Playlist" };
		private static readonly string[] commentTypeTitle = { "Video Comments", "User Comments", "Playlist Comments" };


		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlComments()
		{
			InitializeComponent();
			// Default settings.
			this.Dock = DockStyle.Fill;
			this.Visible = false;
			//this.formAdd.CommentAdded += new CommentEventHandler(this.OnCommentAdded);
		}

		/// <summary>
		/// Initializes the control.
		/// </summary>
		/// <param name="comments">A crawler object.</param>
		public void Initialize(CrawlerCommentsList comments, CrawlerComment.CommentType commentType)
		{
			this.comments = comments;
			this.formAdd.CommentType = commentType;
			this.Enabled = true;

			if ((int)commentType < commentTypeHeader.Length)
			{
				this.columnHeaderItem.Text = ControlComments.commentTypeHeader[(int)commentType];
				this.panelComments.Title = ControlComments.commentTypeTitle[(int)commentType];
			}

			// Populate the comments list.
			foreach (CrawlerComment comment in this.comments)
			{
				// Add a new list view item.
				ListViewItem item = new ListViewItem(new string[] { comment.Time.ToString(), comment.Item, comment.User, comment.Text }, 0);
				item.Tag = comment;
				this.listView.Items.Add(item);
			}

			this.buttonExport.Enabled = this.listView.Items.Count > 0;
		}

		/// <summary>
		/// Opens the dialog to add a new comment.
		/// </summary>
		/// <param name="video">The video.</param>
		public void AddComment(string video)
		{
			if (this.formAdd.ShowDialog(this, video, Environment.UserName) == DialogResult.OK)
			{
				this.OnAddComment(this.formAdd.Comment);
			}
		}

		// Private methods.

		/// <summary>
		/// An event handler called when a new comment is added.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAdd(object sender, EventArgs e)
		{
			if (this.formAdd.ShowDialog(this, string.Empty, Environment.UserName) == DialogResult.OK)
			{
				this.OnAddComment(this.formAdd.Comment);
			}
		}

		/// <summary>
		/// An event handler called when a comment is removed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRemove(object sender, EventArgs e)
		{
			// If there is no item selected, do nothing.
			if (this.listView.SelectedItems.Count == 0) return;

			// Get the selected item.
			ListViewItem item = this.listView.SelectedItems[0];
			// Get the item comment.
			CrawlerComment comment = item.Tag as CrawlerComment;

			try
			{
				// Remove the comment.
				this.comments.RemoveComment(comment);
				// Remove the item.
				this.listView.Items.Remove(item);
			}
			catch (Exception exception)
			{
				MessageBox.Show(
					"Cannot remove the comment. {0}".FormatWith(exception.Message),
					"Cannot Remove Comment",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			this.buttonExport.Enabled = this.listView.Items.Count > 0;
		}

		/// <summary>
		/// An event handler called when a new comment has been added.
		/// </summary>
		/// <param name="comment">The comment.</param>
		private void OnAddComment(CrawlerComment comment)
		{
			try
			{
				// Add the comment to the comments list.
				this.comments.AddComment(comment);

				// Add a new list view item.
				ListViewItem item = new ListViewItem(new string[] { comment.Time.ToString(), comment.Item, comment.User, comment.Text }, 0);
				item.Tag = comment;
				this.listView.Items.Add(item);

				this.buttonExport.Enabled = true;
			}
			catch (Exception exception)
			{
				MessageBox.Show(
					"Cannot add the comment. {0}".FormatWith(exception.Message),
					"Cannot Add Comment",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// An event handler called when the event selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCommentSelectionChanged(object sender, EventArgs e)
		{
			if (this.listView.SelectedItems.Count != 0)
			{
				this.buttonRemove.Enabled = true;
				this.buttonView.Enabled = true;
				this.controlComment.Comment = this.listView.SelectedItems[0].Tag as CrawlerComment;
			}
			else
			{
				this.buttonRemove.Enabled = false;
				this.buttonView.Enabled = false;
				this.controlComment.Comment = null;
			}
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
		/// An event handler called when the user opens a comment.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnViewComment(object sender, EventArgs e)
		{
			// If there are no selected items, do nothing.
			if (this.listView.SelectedItems.Count == 0) return;

			// Open a dialog with the selected comment.
			this.formComment.ShowDialog(this, this.listView.SelectedItems[0].Tag as CrawlerComment);
		}

		/// <summary>
		/// Imports comments from a specified file.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnImport(object sender, EventArgs e)
		{
			// If the user selects a file.
			if (this.openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					int countAdded;
					int countIgnored;
					// Try import the comments.
					ICollection<CrawlerComment> comments = this.comments.Import(this.openFileDialog.FileName, out countAdded, out countIgnored);
					// Add the comments to the list.
					if (null != comments)
					{
						// Populate the comments list.
						foreach (CrawlerComment comment in comments)
						{
							// Add a new list view item.
							ListViewItem item = new ListViewItem(new string[] { comment.Time.ToString(), comment.Item, comment.User, comment.Text }, 0);
							item.Tag = comment;
							this.listView.Items.Add(item);
						}
					}
					// Show a message.
					MessageBox.Show(
						"Import complete. {0} comments added, {1} comments ignored.".FormatWith(countAdded, countIgnored),
						"Import Complete",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information);
				}
				catch (Exception exception)
				{
					// Show a message.
					MessageBox.Show(
						"Import failed. {0}".FormatWith(exception.Message),
						"Import Failed",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
				this.buttonExport.Enabled = this.listView.Items.Count > 0;
			}
		}

		/// <summary>
		/// Exports comments to a specified file.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnExport(object sender, EventArgs e)
		{
			// If the user selects a file.
			if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					// Save the comments.
					this.comments.Save(this.saveFileDialog.FileName);
				}
				catch (Exception exception)
				{
					// Show an error message.
					MessageBox.Show(this, "Cannot save the comments to file. {0}".FormatWith(exception.Message), "Cannot Save File", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}
