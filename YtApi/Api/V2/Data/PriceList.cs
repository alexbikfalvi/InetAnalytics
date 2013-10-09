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
using System.Collections;
using System.Collections.Generic;
using YtApi.Api.V2.Atom;

namespace YtApi.Api.V2.Data
{
	/// <summary>
	/// A YouTube media price list.
	/// </summary>
	public sealed class PriceList : IEnumerable<Price>
	{
		private readonly List<Price> list = new List<Price>();

		/// <summary>
		/// Creates a new price list, based on a collection of atom objects.
		/// </summary>
		/// <param name="atoms">The enumeration of media price atoms.</param>
		public PriceList(IEnumerable<AtomMediaPrice> atoms)
		{
			foreach (AtomMediaPrice atom in atoms)
				this.list.Add(new Price(atom));
		}

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
		public IEnumerator<Price> GetEnumerator()
		{
			return this.list.GetEnumerator();
		}
	}
}
