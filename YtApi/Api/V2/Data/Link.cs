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
using YtApi.Api.V2.Atom;

namespace YtApi.Api.V2.Data
{
    /// <summary>
    /// A YouTube data link.
    /// </summary>
	[Serializable]
	public sealed class Link
	{
		private AtomLink atom;

		/// <summary>
		/// Creates a new link object based on an atom instance.
		/// </summary>
		/// <param name="atom"></param>
		public Link(AtomLink atom)
		{
			this.atom = atom;
		}

		public string Rel { get { return this.atom.Rel; } }
		public string Type { get { return this.atom.Type; } }
		public Uri Href { get { return this.atom.Href; } }
		public bool? HasEntries { get { return this.atom.YtHasEntries; } }
	}
}
