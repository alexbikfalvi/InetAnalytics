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
using YtApi.Api.V2.Atom;

namespace YtApi.Api.V2.Data
{
	/// <summary>
	/// A class that represents a YouTube comment.
	/// </summary>
	[Serializable]
	public sealed class Comment : Entry
	{
		private AtomEntryComment atom;

		private Author author;

		/// <summary>
		/// Creates a new comment entry from an atom instance.
		/// </summary>
		/// <param name="atom">The atom instance.</param>
		/// <returns>A comment object.</returns>
		public override Entry Create(YtApi.Api.V2.Atom.Atom atom)
		{
			return new Comment(atom as AtomEntryComment);
		}

		/// <summary>
		/// Creates an undefined comment object.
		/// </summary>
		public Comment() { }

		/// <summary>
		/// Creates a comment object based on an atom instance. 
		/// </summary>
		/// <param name="atom">The atom instance.</param>
		public Comment(AtomEntryComment atom)
		{
			this.atom = atom;

			this.author = this.atom.Author != null ? new Author(this.atom.Author) : null;
		}

		/// <summary>
		/// Creates a corresponding atom feed from the specified data string.
		/// </summary>
		/// <param name="data">The data string.</param>
		/// <returns>The atom feed.</returns>
		public override AtomFeed CreateFeed(string data)
		{
			return AtomFeedComment.Parse(data);
		}

		/// <summary>
		/// Returns the atom corresponding to this comment.
		/// </summary>
		public AtomEntryComment Atom { get { return this.atom; } }

		/// <summary>
		/// Returns the Atom ID of the comment object (usually an URL of type "http://gdata.youtube.com/feeds/api/videos/<videoID>/comments/<commentID>").
		/// </summary>
		public string AtomId { get { return this.atom.Id.Value; } }

		/// <summary>
		/// The date/time of comment publication. It can be null.
		/// </summary>
		public DateTime? Published { get { return this.atom.Published != null ? this.atom.Published.Value as DateTime? : null; } }

		/// <summary>
		/// The date/time when the comment entry was last updated. It cannot be null.
		/// </summary>
		public DateTime Updated { get { return this.atom.Updated.Value; } }

		/// <summary>
		/// The comment title. It cannot be null.
		/// </summary>
		public string Title { get { return this.atom.Title.Value; } }

		/// <summary>
		/// The comment content. It can be null.
		/// </summary>
		public string Content { get { return this.atom.Content != null ? this.atom.Content.Value : null; } }

		/// <summary>
		/// The video author. It can be null.
		/// </summary>
		public Author Author { get { return this.author; } }

		/// <summary>
		/// Indicates whether the comment was marked as spam.
		/// </summary>
		public bool Spam { get { return this.atom.YtSpam; } }

		/// <summary>
		/// The video ID for this comment. It can be null.
		/// </summary>
		public string VideoId { get { return this.atom.YtVideoId != null ? this.atom.YtVideoId.Value : null; } }
	}
}
