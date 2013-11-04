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
using InetApi.YouTube.Api.V2.Data;
using DotNetApi.Web;

namespace InetApi.YouTube.Api.V2
{
	/// <summary>
	/// A class representing an asynchronous request for a video entry.
	/// </summary>
	public class YouTubeRequestProfile : YouTubeRequest
	{
		/// <summary>
		/// Conversion class for an asynchronous operation returning a video.
		/// </summary>
		public class ProfileRequestFunction : IAsyncFunction<Profile>
		{
			public Profile GetResult(string data)
			{
				// Parse the string data.
				return new Profile(AtomEntryProfile.Parse(data));
			}
		}

		private ProfileRequestFunction funcConvert = new ProfileRequestFunction();

		/// <summary>
		/// A request to the YouTube API for a video.
		/// </summary>
		/// <param name="settings">The request settings.</param>
		public YouTubeRequestProfile(YouTubeSettings settings)
			: base(settings)
		{
		}

		/// <summary>
		/// Begins an asynchronous request for a video.
		/// </summary>
		/// <param name="id">The YouTube profile ID.</param>
		/// <param name="callback">The callback function.</param>
		/// <param name="state">The user state.</param>
		/// <returns>The result of the asynchronous operation</returns>
		public IAsyncResult Begin(string id, AsyncWebRequestCallback callback, object state = null)
		{
			return base.Begin(
				YouTubeUri.GetProfileEntry(id),
				callback,
				state
				);
		}

		/// <summary>
		/// Ends an asynchronous request for a video.
		/// </summary>
		/// <param name="result">The asynchronous result.</param>
		/// <param name="state">The user state.</param>
		/// <returns>The profile object.</returns>
		public new Profile End(IAsyncResult result, out object state)
		{
			return this.funcConvert.GetResult(base.End(result, out state));
		}

		/// <summary>
		/// Ends an asynchronous request for a video.
		/// </summary>
		/// <param name="result">The asynchronous result.</param>
		/// <returns>The profile object.</returns>
		public new Profile End(IAsyncResult result)
		{
			object state;
			return this.funcConvert.GetResult(base.End(result, out state));
		}
	}
}
