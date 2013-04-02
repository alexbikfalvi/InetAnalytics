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
using YtApi.Api.V2.Data;

namespace YtAnalytics.Controls.YouTube
{
	/// <summary>
	/// A control that displays a video comment.
	/// </summary>
	public partial class ControlVideoComment : ThreadSafeControl
	{
		private Comment comment;

		// Creates a new control instance.
		public ControlVideoComment()
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
				this.comment = value;

				if (value != null)
				{
					this.labelTitle.Text = value.Title;
					this.textBoxPublished.Text = value.Published != null ? value.Published.ToString() : string.Empty;
					this.textBoxUpdated.Text = value.Updated.ToString();
					this.textBoxAuthor.Text = value.Author != null ? value.Author.UserId : string.Empty;
					this.textBoxComment.Text = value.Content != null ? value.Content : string.Empty;
					this.checkBoxSpam.Checked = value.Spam;
				}
				else
				{
					this.labelTitle.Text = "No comment selected";
					this.textBoxPublished.Text = string.Empty;
					this.textBoxUpdated.Text = string.Empty;
					this.textBoxAuthor.Text = string.Empty;
					this.textBoxComment.Text = string.Empty;
					this.checkBoxSpam.Checked = false;
				}
				this.textBoxPublished.Select();
				this.textBoxPublished.SelectionStart = 0;
				this.textBoxPublished.SelectionLength = 0;
			}
		}
	}
}
