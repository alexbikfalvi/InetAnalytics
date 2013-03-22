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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YtCrawler.Comments;
using DotNetApi.Windows;

namespace YtAnalytics.Forms
{
	/// <summary>
	/// A form dialog displaying a log event.
	/// </summary>
	public partial class FormComment : Form
	{
		// UI formatter.
		private Formatting formatting = new Formatting();

		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormComment()
		{
			InitializeComponent();

			// Set the font.
			this.formatting.SetFont(this);
		}

		/// <summary>
		/// Shows the form as a dialog and the specified comment.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="comment">The comment.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, Comment comment)
		{
			// If the comment is null, do nothing.
			if (null == comment) return DialogResult.Abort;

			// Set the comment.
			this.control.Comment = comment;
			// Set the title.
			switch (comment.Type)
			{
				case Comment.CommentType.Video:
					this.Text = string.Format("Comment for Video {0} Properties", comment.Item);
					break;
				case Comment.CommentType.User:
					this.Text = string.Format("Comment for User {0} Properties", comment.Item);
					break;
				case Comment.CommentType.Playlist:
					this.Text = string.Format("Comment for Playlist {0} Properties", comment.Item);
					break;
				default:
					this.Text = string.Format("Comment for Item {0} Properties", comment.Item);
					break;
			}
			// Open the dialog.
			return base.ShowDialog(owner);
		}
	}
}
