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
using DotNetApi;
using DotNetApi.Web;

namespace YtApi.Ajax
{
	public class AjaxRequestStatistics : AjaxRequest
	{
		private static string uriScheme = "http";
		private static string uriHost = "www.youtube.com";
		private static int uriPort = -1;
		private static string uriPath = "insight_ajax";
		private static string uriFragment = "?action_get_statistics_and_data=1&v={0}";
		public static CultureInfo culture = new CultureInfo("en-US");

		private AjaxRequestStatisticsFunction func = new AjaxRequestStatisticsFunction();

		/// <summary>
		/// Conversion class for an asynchronous operation returning an XML document.
		/// </summary>
		public class AjaxRequestStatisticsFunction : IAsyncFunction<AjaxVideoStatistics>
		{
			/// <summary>
			/// Returns an XML document for the received asynchronous data.
			/// </summary>
			/// <param name="data">The data string.</param>
			/// <returns>A video statistics object.</returns>
			public AjaxVideoStatistics GetResult(string data)
			{
				return AjaxVideoStatistics.Parse(data);
			}
		}

		/// <summary>
		/// Begins an asynchronous request for a video statistics entry.
		/// </summary>
		/// <param name="id">The video ID.</param>
		/// <param name="callback">The callback function handling the asynchronous response.</param>
		/// <param name="userState">The user state.</param>
		/// <returns>The result of the asynchronous operation.</returns>
		public IAsyncResult Begin(string id, AsyncWebRequestCallback callback, object userState = null)
		{
			// Create the URI of the new request.
			UriBuilder uriBuilder = new UriBuilder(
				AjaxRequestStatistics.uriScheme,
				AjaxRequestStatistics.uriHost,
				AjaxRequestStatistics.uriPort,
				AjaxRequestStatistics.uriPath,
				AjaxRequestStatistics.uriFragment.FormatWith(id)
				);

			// Create the state of the asynchronous request
			AsyncWebResult asyncState = AsyncWebRequest.Create(uriBuilder.Uri, callback, userState);

			// Set the headers
			asyncState.Request.Accept = "text/html, application/xhtml+xml";
			asyncState.Request.Headers.Add("Accept-Language", AjaxRequestStatistics.culture.Name);

			// Begin the asynchronous request.
			return this.Begin(asyncState);
		}

		/// <summary>
		/// Completes the asynchronous operation and returns the received data as an XML document.
		/// </summary>
		/// <param name="result">The asynchronous result.</param>
		/// <returns>An XML document representing the data received during the asynchronous operation.</returns>
		public new AjaxVideoStatistics End(IAsyncResult result)
		{
			// Get the asynchronous result.
			AsyncWebResult asyncResult = (AsyncWebResult)result;

			// Determine the encoding of the received response
			return this.End<AjaxVideoStatistics>(result, this.func);
		}
	}
}
