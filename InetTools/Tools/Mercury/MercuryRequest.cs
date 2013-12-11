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
using System.Linq;
using System.Text;
using DotNetApi;
using DotNetApi.Web;
using Newtonsoft.Json.Linq;

namespace InetTools.Tools.Mercury
{
	/// <summary>
	/// A class representing a Mercury request.
	/// </summary>
	public sealed class MercuryRequest : AsyncWebRequest
	{
		/// <summary>
		/// Creates a new CDN Finder request instance.
		/// </summary>
		public MercuryRequest()
		{
		}

		/// <summary>
		/// Begins a new request to the specified Mercury server.
		/// </summary>
		/// <param name="uri">The Mercury server URI.</param>
		/// <param name="traceroute">The traceroute to upload.</param>
		/// <param name="callback">The callback method.</param>
		/// <param name="userState">The user state.</param>
		/// <returns>The result of the asynchronous web operation.</returns>
		public IAsyncResult Begin(Uri uri, MercuryTraceroute traceroute, AsyncWebRequestCallback callback, object userState = null)
		{
			// Create the request state.
			AsyncWebResult asyncState = new AsyncWebResult(uri, callback, userState);

			// Set the request headers.
			asyncState.Request.Method = "POST";
			asyncState.Request.Accept = "text/html,application/xhtml+xml,application/xml";
			asyncState.Request.ContentType = "application/json;charset=UTF-8";

			// Create the traceroute JSON object.
			JObject obj = new JObject(
				new JProperty("srcIp", traceroute.SourceIp != null ? traceroute.SourceIp.ToString() : "none"),
				new JProperty("dstIp", traceroute.DestinationIp.ToString()),
				new JProperty("srcName", traceroute.SourceHostname),
				new JProperty("dstName", traceroute.DestinationHostname),
				new JProperty("hops",
					new JArray(from hop in traceroute.Hops select new JObject(
						new JProperty("id", hop.Number.ToString()),
						new JProperty("ip", hop.Address != null ? hop.Address.ToString() : "none"),
						new JProperty("asn", hop.AutonomousSystems != null ? new JArray(from asn in hop.AutonomousSystems select asn.ToString()) : new JArray()),
						new JProperty("rtt", hop.Rtt != null ? new JArray(from rtt in hop.Rtt select rtt.ToString()) : new JArray())
						)
					)
				));

			// Append the send data.
			asyncState.SendData.Append(obj.ToString(), Encoding.UTF8);

			// Begin the request.
			return base.Begin(asyncState);
		}

		/// <summary>
		/// Completes the web request and returns the result.
		/// </summary>
		/// <param name="result">The result of the asynchronous web operation.</param>
		public new void End(IAsyncResult result)
		{
			// The data.
			string data;

			// Call the base class end method.
			base.End(result, out data);
		}
	}
}
