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
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotNetApi.Windows.Controls;
using InetApi.YouTube.Api.V2.Data;

namespace InetAnalytics.Controls.YouTube
{
	/// <summary>
	/// A control that displays a video comment.
	/// </summary>
	public partial class ControlCommentProperties : ThreadSafeControl
	{
		private Comment comment;

		// Creates a new control instance.
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
				// Set the new comment.
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
			// If the comment has not changed, do nothinh.
			if (oldComment == newComment) return;

			if (null == newComment)
			{
				this.labelTitle.Text = "No comment selected";
				this.textBoxPublished.Clear();
				this.textBoxUpdated.Clear();
				this.textBoxAuthor.Clear();
				this.textBoxComment.Clear();
				this.checkBoxSpam.Checked = false;
			}
			else
			{
				this.labelTitle.Text = newComment.Title;
				this.textBoxPublished.Text = newComment.Published != null ? newComment.Published.ToString() : string.Empty;
				this.textBoxUpdated.Text = newComment.Updated.ToString();
				this.textBoxAuthor.Text = newComment.Author != null ? newComment.Author.UserId : string.Empty;
				this.textBoxComment.Text = newComment.Content != null ? newComment.Content : string.Empty;
				this.checkBoxSpam.Checked = newComment.Spam;
			}

			if (this.Focused)
			{
				this.textBoxPublished.Select();
				this.textBoxPublished.SelectionStart = 0;
				this.textBoxPublished.SelectionLength = 0;
			}
		}
	}
}
