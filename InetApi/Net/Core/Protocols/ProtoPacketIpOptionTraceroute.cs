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

namespace InetApi.Net.Core.Protocols
{
	/// <summary>
	/// A class representing an IP version 4 traceroute option.
	/// </summary>
	public sealed class ProtoPacketIpOptionTraceroute : ProtoPacketIpOption
	{
		/// <summary>
		/// Creates a new IP version 4 traceroute option instance.
		/// </summary>
		/// <param name="identifier">The identifier.</param>
		/// <param name="outboundHopCount">The outboud hop count.</param>
		/// <param name="returnHopCount">The return hop count.</param>
		/// <param name="originatorAddress">The originator address.</param>
		public ProtoPacketIpOptionTraceroute(short identifier, byte outboundHopCount, byte returnHopCount, IPAddress originatorAddress)
			: base(OptionType.Traceroute)
		{

		}

		#region Public properties

		/// <summary>
		/// The identifier.
		/// </summary>
		public short Identifier { get; private set; }

		#endregion
	}
}
