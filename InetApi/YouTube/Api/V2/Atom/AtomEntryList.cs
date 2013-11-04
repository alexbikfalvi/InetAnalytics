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

namespace InetApi.YouTube.Api.V2.Atom
{
	/// <summary>
	/// A class representing a list of entry atom objects.
	/// </summary>
	public class AtomEntryList : IEnumerable<AtomEntry>
	{
		private readonly List<AtomEntry> list = new List<AtomEntry>();

		public AtomEntryList() { }

		// Public methods.

		/// <summary>
		/// Adds a new item to the list.
		/// </summary>
		/// <param name="item">The entry item.</param>
		public void Add(AtomEntry item)
		{
			this.list.Add(item);
		}

		/// <summary>
		/// Returns the enumerator for the list of entries.
		/// </summary>
		/// <returns>The enumerator.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		/// <summary>
		/// Returns the enumerator for the list of entries.
		/// </summary>
		/// <returns>The enumerator.</returns>
		public IEnumerator<AtomEntry> GetEnumerator()
		{
			return this.list.GetEnumerator();
		}
	}
}
