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
	/// A class that represents a YouTube author.
	/// </summary>
	[Serializable]
	public sealed class Author
	{
		private AtomAuthor atom;

		/// <summary>
		/// Creates a new author object based on an atom instance.
		/// </summary>
		/// <param name="atom"></param>
		public Author(AtomAuthor atom)
		{
			this.atom = atom;
		}

		public string Name { get { return this.atom.Name.Value; } }
		public Uri Uri { get { return this.atom.Uri.Value; } }
		public string UserId { get { return this.atom.YtUserId.Value; } }
	}
}
