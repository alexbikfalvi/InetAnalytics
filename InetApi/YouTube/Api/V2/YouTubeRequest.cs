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
using System.Globalization;
using InetApi.YouTube.Api.V2.Atom;
using InetApi.YouTube.Api.V2.Data;
using DotNetApi;
using DotNetApi.Security;
using DotNetApi.Web;

namespace InetApi.YouTube.Api.V2
{
	/// <summary>
	/// Class representing a request for a YouTube video data.
	/// </summary>
	public class YouTubeRequest : AsyncWebRequest
	{
		private YouTubeSettings settings;

		/// <summary>
		/// Conversion class for an asynchronous operation returning a string.
		/// </summary>
		public class StringRequestFunction : IAsyncFunction<string>
		{
			/// <summary>
			/// Returns a string for the received asynchronous data.
			/// </summary>
			/// <param name="data">The data string.</param>
			/// <returns>The data string.</returns>
			public string GetResult(string data)
			{
				return data;
			}
		}

		private StringRequestFunction funcConvert = new StringRequestFunction();

		/// <summary>
		/// A request to the YouTube API.
		/// </summary>
		/// <param name="settings">The request settings.</param>
		public YouTubeRequest(YouTubeSettings settings)
		{
			this.settings = settings;
		}

		/// <summary>
		/// Begins an asynchronous request for a YouTube resource.
		/// </summary>
		/// <param name="uri">The feed URI.</param>
		/// <param name="callback">The callback delegate.</param>
		/// <param name="state">The user state.</param>
		/// <returns>An asynchronous result object.</returns>
		public new IAsyncResult Begin(Uri uri, AsyncWebRequestCallback callback, object state = null)
		{
			// Create the asynchronous state.
			AsyncWebResult asyncState = AsyncWebRequest.Create(uri, callback, state);

			// Set the request headers.
			if (null != this.settings) asyncState.Request.Headers.Add("X-GData-Key", "key={0}".FormatWith(this.settings.Key.ConvertToUnsecureString()));

			// Set the accepted language to the current culture.
			asyncState.Request.Headers["Accept-Language"] = CultureInfo.CurrentCulture.Name;

			// Begin the request.
			return this.Begin(asyncState);
		}

		/// <summary>
		/// Ends the asynchronus request.
		/// </summary>
		/// <param name="result">The asynchronous result.</param>
		/// <param name="state">The request state.</param>
		/// <returns>The request result.</returns>
		public string End(IAsyncResult result, out object state)
		{
			// Get the asynchronous result.
			AsyncWebResult asyncResult = result as AsyncWebResult;

			// Set the user state
			state = asyncResult.AsyncState;

			// Determine the encoding of the received response
			return this.End<string>(result, this.funcConvert);
		}
	}
}
