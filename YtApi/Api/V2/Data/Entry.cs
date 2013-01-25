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
using System.Threading.Tasks;
using YtApi.Api.V2.Atom;

namespace YtApi.Api.V2.Data
{
	/// <summary>
	/// A feed entry.
	/// </summary>
	[Serializable]
	public abstract class Entry : IDisposable
	{
		/// <summary>
		/// Abstract method to create a feed entry based on an atom instance.
		/// </summary>
		/// <param name="atom">The atom instance.</param>
		/// <returns>The feed entry.</returns>
		public abstract Entry Create(YtApi.Api.V2.Atom.Atom atom);

		/// <summary>
		/// Creates a corresponding atom feed from the specified data string.
		/// </summary>
		/// <param name="data">The data string.</param>
		/// <returns>The atom feed.</returns>
		public abstract AtomFeed CreateFeed(string data);

		/// <summary>
		/// Disposes the entry.
		/// </summary>
		public void Dispose() { }
	}
}
