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

namespace YtApi.Api.V2.Atom
{
	/// <summary>
	/// A class representing a list of atom exceptions.
	/// </summary>
	public class AtomExceptionList : IEnumerable<AtomException>
	{
		private readonly List<AtomException> list = new List<AtomException>();

		public AtomExceptionList() { }

		// Public properties.

		/// <summary>
		/// Gets the number of atoms in the list.
		/// </summary>
		public int Count { get { return this.list.Count; } }

		// Public methods.

		/// <summary>
		/// Adds a new atom exception to the list.
		/// </summary>
		/// <param name="exception">The atom exception.</param>
		public void Add(AtomException exception)
		{
			this.list.Add(exception);
		}

		/// <summary>
		/// Returns the enumerator for the list of atom exceptions.
		/// </summary>
		/// <returns>The enumerator.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		/// <summary>
		/// Returns the enumerator for the list of atom exceptions.
		/// </summary>
		/// <returns>The enumerator.</returns>
		public IEnumerator<AtomException> GetEnumerator()
		{
			return this.list.GetEnumerator();
		}
	}
}
