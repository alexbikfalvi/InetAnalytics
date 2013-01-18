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
using System.Threading.Tasks;

namespace YtApi.Api.V2
{
	/// <summary>
	/// Represents an exception that occurs while parsing YouTube data.
	/// </summary>
	public class YouTubeAtomException : YouTubeException
	{
		private YtApi.Api.V2.Atom.Atom atom;

		/// <summary>
		/// Creates a new exception instance.
		/// </summary>
		/// <param name="message">The exception message.</param>
		/// <param name="innerException">The inner exception.</param>
		/// <param name="atom">The atom.</param>
		public YouTubeAtomException(string message, Exception innerException, YtApi.Api.V2.Atom.Atom atom)
			: base(message, innerException)
		{
			this.atom = atom;
		}

		/// <summary>
		/// Gets the atom that generated the exception.
		/// </summary>
		public YtApi.Api.V2.Atom.Atom Atom { get { return this.atom; } }
	}
}
