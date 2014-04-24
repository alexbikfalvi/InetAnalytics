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
using System.Net.Sockets;

namespace InetApi.Net.Core
{
	/// <summary>
	/// A class representing the multipath traceroute settings.
	/// </summary>
	public sealed class MultipathTracerouteSettings
	{
		/// <summary>
		/// Creates a new instance of the multipath traceroute settings.
		/// </summary>
		public MultipathTracerouteSettings()
		{
			this.AttemptsPerFlow = 5;
			this.FlowCount = 5;
			this.MinimumHops = 1;
			this.MaximumHops = 32;
			this.MaximumUnknownHops = 10;
			this.AttemptDelay = 1000;
			this.HopTimeout = 3000;
			this.DataLength = 32;
		}

		#region Public properties

		/// <summary>
		/// Gets or sets the number of attempts per flow.
		/// </summary>
		public byte AttemptsPerFlow { get; set; }
		/// <summary>
		/// Gets or sets the number of flows.
		/// </summary>
		public byte FlowCount { get; set; }
		/// <summary>
		/// Gets or sets the minimum hops.
		/// </summary>
		public byte MinimumHops { get; set; }
		/// <summary>
		/// Gets or sets the maximum hops.
		/// </summary>
		public byte MaximumHops { get; set; }
		/// <summary>
		/// Gets or sets the number of unknown hops after which the traceroute will end.
		/// </summary>
		public byte MaximumUnknownHops { get; set; }
		/// <summary>
		/// Gets or sets the delay between attempts in milliseconds.
		/// </summary>
		public int AttemptDelay { get; set; }
		/// <summary>
		/// Gets or sets the hop timeout in milliseconds.
		/// </summary>
		public int HopTimeout { get; set; }
		/// <summary>
		/// Gets or sets the ICMP packet data length.
		/// </summary>
		public int DataLength { get; set; }

		#endregion
	}
}
