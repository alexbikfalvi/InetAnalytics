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
using System.Collections;
using System.Collections.Generic;
using InetApi.YouTube.Api.V2.Atom;

namespace InetApi.YouTube.Api.V2.Data
{
	/// <summary>
	/// A class that represents a thumbnail list.
	/// </summary>
	public sealed class ThumbnailList : IEnumerable<Thumbnail>
	{
		private readonly List<Thumbnail> list = new List<Thumbnail>();

		/// <summary>
		/// Creates a new thumbnail list based on a collection of atoms.
		/// </summary>
		/// <param name="atoms">A collection of thumbnail atoms.</param>
		public ThumbnailList(IEnumerable<AtomMediaThumbnail> atoms)
		{
			foreach (AtomMediaThumbnail atom in atoms)
			{
				this.list.Add(new Thumbnail(atom));
			}
		}

		// Public properties.

		/// <summary>
		/// Gets the thumbnail at the specified index.
		/// </summary>
		/// <param name="index">The thumbnail index.</param>
		/// <returns>The thumbnail.</returns>
		public Thumbnail this[int index] { get { return this.list[index]; } }
		/// <summary>
		/// Gets the number of thumbnail objects.
		/// </summary>
		public int Count { get { return this.list.Count; } }

		// Public methods.

		/// <summary>
		/// Returns the enumerator for the list of categories.
		/// </summary>
		/// <returns>The enumerator.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		/// <summary>
		/// Returns the enumerator for the list of categories.
		/// </summary>
		/// <returns>The enumerator.</returns>
		public IEnumerator<Thumbnail> GetEnumerator()
		{
			return this.list.GetEnumerator();
		}
	}
}
