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
using System.Security;

namespace InetApi.YouTube.Api.V2
{
	/// <summary>
	/// A class representing the settings for a YouTube API request.
	/// </summary>
	public class YouTubeSettings
	{
		private SecureString key;

		/// <summary>
		/// Settings to make requests to the YouTube API.
		/// </summary>
		/// <param name="key">The developer key.</param>
		public YouTubeSettings(SecureString key)
		{
			this.key = key;
		}

		/// <summary>
		/// Returns the developer key.
		/// </summary>
		public SecureString Key { get { return this.key; } }
	}
}
