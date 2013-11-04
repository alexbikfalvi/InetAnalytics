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
	/// A class representing the user like rating.
	/// </summary>
	[Serializable]
	public sealed class UserRatingLike
	{
		private AtomYtRating atom;

		/// <summary>
		/// Creates a new user rating object, based on an atom instance.
		/// </summary>
		/// <param name="atom">The atom instance.</param>
		public UserRatingLike(AtomYtRating atom)
		{
			this.atom = atom;
		}

		public int NumLikes { get { return this.atom.NumLikes; } }
		public int NumDislikes { get { return this.atom.NumDislikes; } }
	}
}
