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
					this.tabControl.Visible = true;

					if (value.GetType() == typeof(CommentVideo))
					{
						CommentVideo comment = value as CommentVideo;
						this.labelTitle.Text = string.Format("Comment for video {0}", comment.Video);
						this.labelObject.Text = "&Video:";
						this.textBoxObject.Text = comment.Video;
						this.pictureBox.Image = Resources.CommentVideo_32;
					}
					else
					{
						this.labelTitle.Text = string.Format("Comment");
						this.labelObject.Text = "&Object:";
						this.textBoxObject.Text = string.Empty;
						this.pictureBox.Image = Resources.Comment_32;
					}
				}
				this.comment = value;
			}
		}
	}
}
