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
	/// A class that represents a YouTube playlist.
	/// </summary>
	[Serializable]
	public sealed class Playlist : Entry
	{
		private AtomEntryPlaylist atom;

		private Author author;

		/// <summary>
		/// Creates a new playlist entry from an atom instance.
		/// </summary>
		/// <param name="atom">The atom instance.</param>
		/// <returns>A playlist object.</returns>
		public override Entry Create(YtApi.Api.V2.Atom.Atom atom)
		{
			return new Playlist(atom as AtomEntryPlaylist);
		}

		/// <summary>
		/// Creates an undefined playlist object.
		/// </summary>
		public Playlist() { }

		/// <summary>
		/// Creates a playlist object based on an atom instance. 
		/// </summary>
		/// <param name="atom">The atom instance.</param>
		public Playlist(AtomEntryPlaylist atom)
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
			return AtomFeedPlaylist.Parse(data);
		}

		/// <summary>
		/// Returns the atom corresponding to this playlist.
		/// </summary>
		public AtomEntryPlaylist Atom { get { return this.atom; } }

		/// <summary>
		/// Returns the Atom ID of the playlist object.
		/// </summary>
		public string AtomId { get { return this.atom.Id.Value; } }

		/// <summary>
		/// Returns the playlist ID. It cannot be null.
		/// </summary>
		public string Id { get { return this.atom.YtPlaylistId.Value; } }

		/// <summary>
		/// The date/time of playlist publication. It can be null.
		/// </summary>
		public DateTime? Published { get { return this.atom.Published != null ? this.atom.Published.Value as DateTime? : null; } }

		/// <summary>
		/// The date/time when the playlist entry was last updated. It cannot be null.
		/// </summary>
		public DateTime Updated { get { return this.atom.Updated.Value; } }

		/// <summary>
		/// The playlist title. It cannot be null.
		/// </summary>
		public string Title { get { return this.atom.Title.Value; } }

		/// <summary>
		/// The playlist content. It can be null.
		/// </summary>
		public string Content { get { return this.atom.Content != null ? this.atom.Content.Value : null; } }

		/// <summary>
		/// The video author. It can be null.
		/// </summary>
		public Author Author { get { return this.author; } }

		/// <summary>
		/// The profile summary. It can be null.
		/// </summary>
		public string Summary { get { return this.atom.Summary != null ? this.atom.Summary.Value : null; } }

		/// <summary>
		/// The count hint.
		/// </summary>
		public int CountHint { get { return this.atom.YtCountHint.Value; } }
	}
}
