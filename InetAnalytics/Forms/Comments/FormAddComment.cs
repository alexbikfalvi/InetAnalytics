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
using System.Windows.Forms;
using InetAnalytics.Controls.Comments;
using InetAnalytics.Events;
using InetCrawler.Comments;
using DotNetApi.Windows;
using DotNetApi.Windows.Forms;

namespace InetAnalytics.Forms.Comments
{
	/// <summary>
	/// A form dialog displaying a comment.
	/// </summary>
	public partial class FormAddComment : ThreadSafeForm
	{
		private CrawlerComment.CommentType type;

		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormAddComment()
		{
			InitializeComponent();

			// Set the font.
			Window.SetFont(this);
		}

		/// <summary>
		/// Gets or sets the comment type.
		/// </summary>
		public CrawlerComment.CommentType CommentType
		{
			get { return this.type; }
			set
			{
				switch (value)
				{
					case CrawlerComment.CommentType.Video: this.Text = "Add Video Comment"; break;
					case CrawlerComment.CommentType.User: this.Text = "Add User Comment"; break;
					case CrawlerComment.CommentType.Playlist: this.Text = "Add Playlist Comment"; break;
				}
				this.control.Type = value;
				this.type = value;
			}
		}

		/// <summary>
		/// An event raised when a new comment was added.
		/// </summary>
		public event CommentEventHandler CommentAdded;

		/// <summary>
		/// Shows the add comment dialog, for the specified object ID and user.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="obj">The object ID.</param>
		/// <param name="user">The user.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, string obj, string user)
		{
			this.control.Item = obj;
			this.control.User = user;
			this.control.Text = string.Empty;
			this.control.Select();
			return base.ShowDialog(owner);
		}

		/// <summary>
		/// An event handler called when the user clicks on the add button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAddClick(object sender, EventArgs e)
		{
			// Raise the add event.
			if (this.CommentAdded != null) this.CommentAdded(this, new CommentEventArgs(
				new CrawlerComment(this.CommentType, DateTime.Now, this.control.Item, this.control.User, this.control.Text)));
			// Close the dialog.
			this.Close();
		}

		/// <summary>
		/// An event handler called when the user input has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnInputChanged(object sender, EventArgs e)
		{
			this.buttonAdd.Enabled =
				!string.IsNullOrWhiteSpace(this.control.Item) &&
				!string.IsNullOrWhiteSpace(this.control.User) &&
				!string.IsNullOrWhiteSpace(this.control.Text);
		}
	}
}
