﻿/* 
 * Copyright (C) 2013 Alex Bikfalvi
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
using InetCrawler.Comments;

namespace InetAnalytics.Events
{
	/// <summary>
	/// A delegate representing a comment event handler.
	/// </summary>
	/// <param name="sender">The sender object.</param>
	/// <param name="e">The event arguments.</param>
	public delegate void CommentEventHandler(object sender, CommentEventArgs e);

	/// <summary>
	/// A class representing a comment event argument.
	/// </summary>
	public class CommentEventArgs : EventArgs
	{
		/// <summary>
		/// Creates a new event instance.
		/// </summary>
		/// <param name="comment">The comment.</param>
		public CommentEventArgs(CrawlerComment comment)
		{
			this.Comment = comment;
		}

		/// <summary>
		/// Gets the comment.
		/// </summary>
		public CrawlerComment Comment { get; private set; }
	}
}
