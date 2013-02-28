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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YtCrawler;

namespace YtCrawler.Comments
{
	/// <summary>
	/// A class that stores all user comments.
	/// </summary>
	public class Comments
	{
		private CrawlerConfig config;

		private CommentsList commentsVideos;
		private CommentsList commentsUsers;
		private CommentsList commentsPlaylists;

		/// <summary>
		/// Creates a new comments instance.
		/// </summary>
		/// <param name="config">A crawler configuration object.</param>
		public Comments(CrawlerConfig config)
		{
			// Set the configuration.
			this.config = config;

			// Create the videos comments.
			this.commentsVideos = new CommentsList(this.config.CommentsVideosFileName);

			// Create the users comments.
			this.commentsUsers = new CommentsList(this.config.CommentsUsersFileName);

			// Create the playlists comments.
			this.commentsPlaylists = new CommentsList(this.config.CommentsPlaylistsFileName);
		}

		/// <summary>
		/// Saves the current comments to file.
		/// </summary>
		public void Save()
		{
			this.commentsVideos.Save(this.config.CommentsVideosFileName);
		}

		/// <summary>
		/// Returns the videos comments.
		/// </summary>
		public CommentsList Videos { get { return this.commentsVideos; } }

		/// <summary>
		/// Returns the users comments.
		/// </summary>
		public CommentsList Users { get { return this.commentsUsers; } }

		/// <summary>
		/// Returns the playlist comments.
		/// </summary>
		public CommentsList Playlists { get { return this.commentsPlaylists; } }
	}
}
