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
using System.Linq;
using System.Text;
using YtApi.Api.V2.Atom;

namespace YtApi.Api.V2.Data
{
	/// <summary>
	/// A class that represents a thumbnail.
	/// </summary>
	public class Thumbnail
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
		/// The thumbnail width.
		/// </summary>
		public int Width { get { return this.atom.Width; } }

		/// <summary>
		/// The thumbnail height.
		/// </summary>
		public int Height { get { return this.atom.Height; } }

		/// <summary>
		/// The timestamp at which the thumbnail was taken. It can be null.
		/// </summary>
		public TimeSpan? Time { get { return this.atom.Time; } }

		/// <summary>
		/// The thumbnail name. It can be null.
		/// </summary>
		public string Name { get { return this.atom.YtName; } }
	}

	/// <summary>
	/// A class that represents a thumbnail list.
	/// </summary>
	public class ThumbnailList : List<Thumbnail>
	{
		/// <summary>
		/// Creates a new thumbnail list based on a collection of atoms.
		/// </summary>
		/// <param name="atoms">A collection of thumbnail atoms.</param>
		public ThumbnailList(ICollection<AtomMediaThumbnail> atoms)
			: base(atoms.Count)
		{
			foreach (AtomMediaThumbnail atom in atoms)
			{
				this.Add(new Thumbnail(atom));
			}
		}
	}
}
