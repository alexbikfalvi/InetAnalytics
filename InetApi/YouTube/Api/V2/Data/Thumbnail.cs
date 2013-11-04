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
using InetApi.YouTube.Api.V2.Atom;

namespace InetApi.YouTube.Api.V2.Data
{
	/// <summary>
	/// A class that represents a thumbnail.
	/// </summary>
	[Serializable]
	public sealed class Thumbnail
	{
		AtomMediaThumbnail atom;

		/// <summary>
		/// Creates a new thumbnail object based on an atom instance.
		/// </summary>
		/// <param name="atom"></param>
		public Thumbnail(AtomMediaThumbnail atom)
		{
			this.atom = atom;
		}

		/// <summary>
		/// The thumbail URL. It cannot be null.
		/// </summary>
		public Uri Url { get { return this.atom.Url; } }

		/// <summary>
		/// The thumbnail width. It can be null.
		/// </summary>
		public int? Width { get { return this.atom.Width; } }

		/// <summary>
		/// The thumbnail height. It can be null.
		/// </summary>
		public int? Height { get { return this.atom.Height; } }

		/// <summary>
		/// The timestamp at which the thumbnail was taken. It can be null.
		/// </summary>
		public TimeSpan? Time { get { return this.atom.Time; } }

		/// <summary>
		/// The thumbnail name. It can be null.
		/// </summary>
		public string Name { get { return this.atom.YtName; } }
	}
}
