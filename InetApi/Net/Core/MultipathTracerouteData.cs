/* 
 * Copyright (C) 2014 Alex Bikfalvi
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
using System.Net;

namespace InetApi.Net.Core
{
	/// <summary>
	/// A structure representing the multipath traceroute data.
	/// </summary>
	public struct MultipathTracerouteData
	{
		#region Public properties

		/// <summary>
		/// The host address.
		/// </summary>
		public IPAddress HostAddress { get; internal set; }
		/// <summary>
		/// The local address.
		/// </summary>
		public IPAddress LocalAddress { get; internal set; }
		/// <summary>
		/// The remote address.
		/// </summary>
		public IPAddress RemoteAddress { get; internal set; }
		/// <summary>
		/// The time-to-live.
		/// </summary>
		public byte TimeToLive { get; internal set; }
		/// <summary>
		/// The flow attempt.
		/// </summary>
		public byte Attempt { get; internal set; }
		/// <summary>
		/// The request timestamp.
		/// </summary>
		public DateTime RequestTimestamp { get; internal set; }
		/// <summary>
		/// The response timestamp.
		/// </summary>
		public DateTime ResponseTimestamp { get; internal set; }

		#endregion
	}
}
