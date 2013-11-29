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

namespace InetTools.Tools.CdnFinder
{
	/// <summary>
	/// A class representing the configuration for the CDN Finder tool.
	/// </summary>
	public sealed class CdnFinderConfig
	{
		private readonly IToolApi api;

		/// <summary>
		/// Creates a new CDN Finder configuration instance.
		/// </summary>
		/// <param name="api">The tools API.</param>
		public CdnFinderConfig(IToolApi api)
		{
			this.api = api;
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the server URL.
		/// </summary>
		public string ServerUrl
		{
			get { return this.api.Key.GetString("ServerUrl", string.Empty); }
			set { this.api.Key.SetString("ServerUrl", value); }
		}
		/// <summary>
		/// Gets or sets the connection timeout.
		/// </summary>
		public int Timeout
		{
			get { return this.api.Key.GetInteger("Timeout", 600000); }
			set { this.api.Key.SetInteger("Timeout", value); }
		}
		/// <summary>
		/// Gets or sets whether the connection uses automatic redirection.
		/// </summary>
		public bool AutoRedirect
		{
			get { return this.api.Key.GetBoolean("AutoRedirect", true); }
			set { this.api.Key.SetBoolean("AutoRedirect", value); }
		}
		/// <summary>
		/// Gets or sets the protocol.
		/// </summary>
		public string Protocol
		{
			get { return this.api.Key.GetString("Protocol", "http"); }
			set { this.api.Key.SetString("Protocol", value); }
		}
		/// <summary>
		/// Gets or sets the site URL subdomains.
		/// </summary>
		public string[] Subdomains
		{
			get { return this.api.Key.GetMultiString("Subdomains", new string[] { "www" }); }
			set { this.api.Key.SetMultiString("Subdomains", value); }
		}
	}
}
