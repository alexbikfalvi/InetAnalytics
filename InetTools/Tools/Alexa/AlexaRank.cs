/* 
 * Copyright (C) 2013 Alex Bikfalvi
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

namespace InetTools.Tools.Alexa
{
	/// <summary>
	/// A structure representing the Alexa ranking information.
	/// </summary>
	public struct AlexaRank
	{
		/// <summary>
		/// Creates a new ranking information structure.
		/// </summary>
		/// <param name="position">The rank position.</param>
		/// <param name="site">The site name.</param>
		/// <param name="url">The URL path.</param>
		public AlexaRank(int position, string site, string url)
			: this()
		{
			this.Position = position;
			this.Site = site;
			this.Url = url;
		}

		/// <summary>
		/// Gets the ranking position.
		/// </summary>
		public int Position { get; private set; }
		/// <summary>
		/// Gets the site name.
		/// </summary>
		public string Site { get; private set; }
		/// <summary>
		/// Gets the URL path.
		/// </summary>
		public string Url { get; private set; }
	}
}
