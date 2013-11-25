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

namespace InetTools.Tools.AlexaTopSites
{
	/// <summary>
	/// A structure representing the Alexa country information.
	/// </summary>
	public struct AlexaTopSitesCountry
	{
		/// <summary>
		/// Creates a new country information structure.
		/// </summary>
		/// <param name="name">The country name.</param>
		/// <param name="url">The URL path.</param>
		public AlexaTopSitesCountry(string name, string url)
			: this()
		{
			this.Name = name;
			this.Url = url;
		}

		/// <summary>
		/// Gets the country name.
		/// </summary>
		public string Name { get; private set; }
		/// <summary>
		/// Gets the country code.
		/// </summary>
		public string Code { get; private set; }
		/// <summary>
		/// Gets the URL path.
		/// </summary>
		public string Url { get; private set; }
	}
}
