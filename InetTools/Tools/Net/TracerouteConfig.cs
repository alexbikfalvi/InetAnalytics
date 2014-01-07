/* 
 * Copyright (C) 2013-2014 Alex Bikfalvi
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

namespace InetTools.Tools.Net
{
	/// <summary>
	/// A class representing the configuration for the Internet traceroute tool.
	/// </summary>
	public sealed class TracerouteConfig
	{
		private readonly IToolApi api;

		/// <summary>
		/// Creates a new web client configuration instance.
		/// </summary>
		/// <param name="api">The tools API.</param>
		public TracerouteConfig(IToolApi api)
		{
			this.api = api;
		}

		// Public properties.

		/// <summary>
		/// Gets the tool API.
		/// </summary>
		public IToolApi Api { get { return this.api; } }

		/// <summary>
		/// Gets or sets the traceroute destination.
		/// </summary>
		public string Destination
		{
			get { return this.api.Key.GetString("Destination", string.Empty); }
			set { this.api.Key.SetString("Destination", value != null ? value : string.Empty); }
		}

		/// <summary>
		/// Gets or sets whether any name resolution is performed automatically.
		/// </summary>
		public bool AutomaticNameResolution
		{
			get { return this.api.Key.GetBoolean("AutomaticNameResolution", false); }
			set { this.api.Key.SetBoolean("AutomaticNameResolution", value); }
		}

		/// <summary>
		/// Gets or sets the maximum number of hops for the traceroute.
		/// </summary>
		public byte MaximumHops
		{
			get { return (byte)this.api.Key.GetInteger("MaximumHops", 30); }
			set { this.api.Key.SetInteger("MaximumHops", value); }
		}

		/// <summary>
		/// Gets or sets the maximum number of attempts per hop.
		/// </summary>
		public byte MaximumAttempts
		{
			get { return (byte)this.api.Key.GetInteger("MaximumAttempts", 3); }
			set { this.api.Key.SetInteger("MaximumAttempts", value); }
		}

		/// <summary>
		/// Gets or sets the maximum number of failed consecutive hops.
		/// </summary>
		public byte MaximumFailedHops
		{
			get { return (byte)this.api.Key.GetInteger("MaximumFailedHops", 10); }
			set { this.api.Key.SetInteger("MaximumFailedHops", value); }
		}

		/// <summary>
		/// Gets or sets whether the traceroute for a hop stops after the first success.
		/// </summary>
		public bool StopHopOnSuccess
		{
			get { return this.api.Key.GetBoolean("StopHopOnSuccess", false); }
			set { this.api.Key.SetBoolean("StopHopOnSuccess", value); }
		}

		/// <summary>
		/// Gets or sets whether the traceroute stops after the maximum number of consecututive failed hops was reached.
		/// </summary>
		public bool StopTracerouteOnFail
		{
			get { return this.api.Key.GetBoolean("StopTracerouteOnFail", false); }       
			set { this.api.Key.SetBoolean("StopTracerouteOnFail", value); }
		}

		/// <summary>
		/// Gets the local network interface.
		/// </summary>
		public string NetworkInterface
		{
			get { return this.api.Key.GetString("NetworkInterface", string.Empty); }
			set { this.api.Key.SetString("NetworkInterface", value); }
		}
	}
}
