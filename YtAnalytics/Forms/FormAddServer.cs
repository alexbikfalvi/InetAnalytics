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
using YtAnalytics.Controls;
using YtCrawler.Comments;
using DotNetApi.Windows;

namespace YtAnalytics.Forms
{
	/// <summary>
	/// A form dialog displaying an exception.
	/// </summary>
	public partial class FormAddServer : Form
	{
		// UI formatter.
		private Formatting formatting = new Formatting();

		private Comment.CommentType type;

		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormAddServer()
		{
			InitializeComponent();

			// Set the font.
			this.formatting.SetFont(this);
		}

		/// <summary>
		/// An event raised when a new comment was added.
		/// </summary>
		public event AddCommentEventHandler CommentAdded;

		/// <summary>
		/// Shows the add comment dialog, for the specified object ID and user.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="obj">The object ID.</param>
		/// <param name="user">The user.</param>
		public void ShowDialog(IWin32Window owner, string obj, string user)
		{
//			this.control.Item = obj;
//			this.control.User = user;
//			this.control.Text = string.Empty;
			base.ShowDialog(owner);
		}

		/// <summary>
		/// An event handler called when the user clicks on the add button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAddClick(object sender, EventArgs e)
		{
			// Raise the add event.
			//if (this.CommentAdded != null) this.CommentAdded(
			//	new Comment(this.CommentType, DateTime.Now, this.control.Item, this.control.User, this.control.Text)
			//	);
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
				(this.control.ServerName != string.Empty) &&
				(this.control.DataSource != string.Empty) &&
				(this.control.Username != string.Empty) &&
				(this.control.Password != string.Empty);
		}
	}
}
