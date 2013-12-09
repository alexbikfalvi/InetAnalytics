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
using System.Collections.Generic;
using System.Net;

namespace InetTools.Tools.Mercury
{
	/// <summary>
	/// A class that represents a Mercury traceroute.
	/// </summary>
	public sealed class MercuryTraceroute
	{
		public string sourceHostname;
		public IPAddress sourceIp;
		public string destinationHostname;
		public IPAddress destinationIp;
		public readonly List<MercuryTracerouteHop> hops = new List<MercuryTracerouteHop>();

		/// <summary>
		/// Creates a new traceroute instance by parsing the specified data.
		/// </summary>
		/// <param name="data"></param>
		public MercuryTraceroute(string data)
		{

		}
	}
}
