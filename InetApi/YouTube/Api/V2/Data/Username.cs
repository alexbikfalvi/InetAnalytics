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
using InetApi.YouTube.Api.V2.Atom;

namespace InetApi.YouTube.Api.V2.Data
{
	/// <summary>
	/// A class describing a username.
	/// </summary>
	[Serializable]
	public sealed class Username
	{
		private AtomYtUsername atom;

		/// <summary>
		/// Creates a username object based on an atom instance.
		/// </summary>
		/// <param name="atom">The atom instance.</param>
		public Username(AtomYtUsername atom)
		{
			this.atom = atom;
		}

		/// <summary>
		/// Returns the username ID.
		/// </summary>
		public string Id { get { return this.atom.Value; } }

		/// <summary>
		/// Returns the username display name.
		/// </summary>
		public string Display { get { return this.atom.Display; } }
	}
}
