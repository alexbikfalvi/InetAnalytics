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
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YtAnalytics.Forms;
using YtCrawler.Comments;

namespace YtAnalytics.Controls
{
	/// <summary>
	/// Displays the information of a log event.
	/// </summary>
	public partial class ControlComment : UserControl
	{
		private Comment comment = null;

		/// <summary>
		/// Creates a new log event control instance.
		/// </summary>
		public ControlComment()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Gets or sets the current history discovery event.
		/// </summary>
		public Comment Comment
		{
			get { return this.comment; }
			set
			{
				if (null == value)
				{
					this.labelTitle.Text = "No comment.";
					this.pictureBox.Image = Resources.Comment_32;
					this.tabControl.Visible = false;
				}
				else
				{
					this.textBoxTime.Text = value.Time.ToString();
					this.textBoxUser.Text = value.User;
					this.textBoxGuid.Text = value.Guid.ToString();
					this.textBoxText.Text = value.Text;
					this.textBoxObject.Text = value.Item;
					this.tabControl.Visible = true;

					switch (value.Type)
					{
						case Comment.CommentType.Video:
							this.labelTitle.Text = string.Format("Comment for video {0}", value.Item);
							this.labelObject.Text = "&Video:";
							this.pictureBox.Image = Resources.CommentVideo_32;
							break;
						case Comment.CommentType.User:
							this.labelTitle.Text = string.Format("Comment for user {0}", value.Item);
							this.labelObject.Text = "&User:";
							this.pictureBox.Image = Resources.CommentUser_32;
							break;
						case Comment.CommentType.Playlist:
							this.labelTitle.Text = string.Format("Comment for playlist {0}", value.Item);
							this.labelObject.Text = "&Playlist:";
							this.pictureBox.Image = Resources.CommentPlay_32;
							break;
						default:
							this.labelTitle.Text = string.Format("Comment for item {0}", value.Item);
							this.labelObject.Text = "&Item:";
							this.pictureBox.Image = Resources.Comment_32;
							break;
					}
				}
				this.comment = value;
			}
		}
	}
}
