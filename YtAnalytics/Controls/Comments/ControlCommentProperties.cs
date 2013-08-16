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
using YtCrawler.Comments;

namespace YtAnalytics.Controls.Comments
{
	/// <summary>
	/// Displays the information of a user comment.
	/// </summary>
	public partial class ControlCommentProperties : ThreadSafeControl
	{
		private Comment comment = null;

		/// <summary>
		/// Creates a new comment control instance.
		/// </summary>
		public ControlCommentProperties()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Gets or sets the current comment.
		/// </summary>
		public Comment Comment
		{
			get { return this.comment; }
			set
			{
				// Save the old value.
				Comment old = this.comment;
				// Set the new value.
				this.comment = value;
				// Call the event handler.
				this.OnCommentSet(old, value);
			}
		}

		// Protected methods.

		/// <summary>
		/// An event handler called when a new comment has been set.
		/// </summary>
		/// <param name="oldComment">The old comment.</param>
		/// <param name="newComment">The new comment.</param>
		protected virtual void OnCommentSet(Comment oldComment, Comment newComment)
		{
			// If the comment has not changed, do nothing.
			if (oldComment == newComment) return;

			if (null == newComment)
			{
				this.labelTitle.Text = "No comment selected";
				this.pictureBox.Image = Resources.Comment_32;
				this.tabControl.Visible = false;
			}
			else
			{
				this.textBoxTime.Text = newComment.Time.ToString();
				this.textBoxUser.Text = newComment.User;
				this.textBoxGuid.Text = newComment.Guid.ToString();
				this.textBoxText.Text = newComment.Text;
				this.textBoxObject.Text = newComment.Item;
				this.tabControl.Visible = true;

				switch (newComment.Type)
				{
					case Comment.CommentType.Video:
						this.labelTitle.Text = "Comment for video {0}".FormatWith(newComment.Item);
						this.labelObject.Text = "&Video:";
						this.pictureBox.Image = Resources.CommentVideo_32;
						break;
					case Comment.CommentType.User:
						this.labelTitle.Text = "Comment for user {0}".FormatWith(newComment.Item);
						this.labelObject.Text = "&User:";
						this.pictureBox.Image = Resources.CommentUser_32;
						break;
					case Comment.CommentType.Playlist:
						this.labelTitle.Text = "Comment for playlist {0}".FormatWith(newComment.Item);
						this.labelObject.Text = "&Playlist:";
						this.pictureBox.Image = Resources.CommentPlay_32;
						break;
					default:
						this.labelTitle.Text = "Comment for item {0}".FormatWith(newComment.Item);
						this.labelObject.Text = "&Item:";
						this.pictureBox.Image = Resources.Comment_32;
						break;
				}
			}
			this.tabControl.SelectedTab = this.tabPageGeneral;
			if (this.Focused)
			{
				this.textBoxTime.Select();
				this.textBoxTime.SelectionStart = 0;
				this.textBoxTime.SelectionLength = 0;
			}
		}
	}
}
