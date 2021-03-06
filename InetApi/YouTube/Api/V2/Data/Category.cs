﻿/* 
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
    /// A YouTube category.
    /// </summary>
	[Serializable]
	public sealed class Category
	{
		private Uri scheme;
		private string term;
		private string label;

		/// <summary>
		/// Creates a category object based on a category atom instance.
		/// </summary>
		/// <param name="atom">The atom instance.</param>
		public Category(AtomCategory atom)
		{
			this.scheme = atom.Scheme;
			this.term = atom.Term;
			this.label = atom.Label;
		}

		/// <summary>
		/// Creates a category object based on a media category atom instance.
		/// </summary>
		/// <param name="atom">The atom instance.</param>
		public Category(AtomMediaCategory atom)
		{
			this.scheme = atom.Scheme;
			this.term = atom.Value;
			this.label = atom.Label;
		}

		public Uri Scheme { get { return this.scheme; } }
		public string Term { get { return this.term; } }
		public string Label { get { return this.label; } }
	}
}
