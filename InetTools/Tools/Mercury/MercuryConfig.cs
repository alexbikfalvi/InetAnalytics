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
using DotNetApi.Windows;
using InetCrawler.Tools;

namespace InetTools.Tools.Mercury
{
	/// <summary>
	/// A class representing the configuration for the Mercury client tool.
	/// </summary>
	public sealed class MercuryConfig
	{
		private readonly IToolApi api;

		/// <summary>
		/// Creates a new Mercury client configuration instance.
		/// </summary>
		/// <param name="api">The tools API.</param>
		public MercuryConfig(IToolApi api)
		{
			this.api = api;
		}

		// Public properties.

		/// <summary>
		/// Gets the tool API.
		/// </summary>
		public IToolApi Api { get { return this.api; } }

		/// <summary>
		/// Gets or sets the server URL to upload a session.
		/// </summary>
		public string UploadSessionUrl
		{
			get { return this.api.Key.GetString("UploadSessionUrl", "http://mercury.upf.edu/mercury/api/traceroute/addTracerouteSession"); }
			set { this.api.Key.SetString("UploadSessionUrl", value); }
		}

		/// <summary>
		/// Gets or sets the server URL to upload a traceroute.
		/// </summary>
		public string UploadTracerouteUrl
		{
			get { return this.api.Key.GetString("UploadTracerouteUrl", "http://mercury.upf.edu/mercury/api/traceroute/uploadTrace"); }
			set { this.api.Key.SetString("UploadTracerouteUrl", value); }
		}
	}
}
