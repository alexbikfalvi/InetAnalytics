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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace YtApi.Api.V2.Atom
{
	/// <summary>
	/// A class representing a user's gender.
	/// </summary>
	[Serializable]
	public sealed class AtomYtGender
	{
		private AtomYtGender() { }

		public static AtomYtGender Parse(XElement element)
		{
			AtomYtGender atom = new AtomYtGender();

			switch (element.Value.ToLower())
			{
				case "m": atom.Value = Gender.Male; break;
				case "f": atom.Value = Gender.Female; break;
				default: atom.Value = Gender.Unknown; break;
			}

			return atom;
		}

		public Gender Value { get; set; }
	}

	public enum Gender
	{
		Male = 0,
		Female = 1,
		Unknown = 2
	}
}
