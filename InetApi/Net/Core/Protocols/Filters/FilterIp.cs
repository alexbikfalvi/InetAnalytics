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

namespace InetApi.Net.Core.Protocols.Filters
{
	/// <summary>
	/// A class representing a filter for the IP version 4 protocol.
	/// </summary>
	public class FilterIp
	{
		#region Public properties

		/// <summary>
		/// Gets or sets the filter source address.
		/// </summary>
		public IPAddress SourceAddress { get; set; }
		/// <summary>
		/// Gets or sets the filter destination address.
		/// </summary>
		public IPAddress DestinationAddress { get; set; }
		/// <summary>
		/// Gets or sets the filter protocol.
		/// </summary>
		public ProtoPacketIp.Protocols? Protocol { get; set; }

		#endregion

		#region Public methods

		/// <summary>
		/// Verifies if the filter matches the specified IP packet.
		/// </summary>
		/// <param name="ip">The IP packet.</param>
		/// <returns><b>True</b> if the filter matches the packet, <b>false</b> otherwise.</returns>
		public bool Matches(ProtoPacketIp ip)
		{
			if (null != this.SourceAddress ? !this.SourceAddress.Equals(ip.SourceAddress) : false) return false;
			if (null != this.DestinationAddress ? !this.DestinationAddress.Equals(ip.DestinationAddress) : false) return false;
			if (null != this.Protocol ? (byte)this.Protocol != ip.Protocol : false) return false;
			return true;
		}

		/// <summary>
		/// Verifies if the filter matches the specified IP packet.
		/// </summary>
		/// <param name="sourceAddress">The source address.</param>
		/// <param name="destinationAddress">The destination address.</param>
		/// <param name="protocol">The protocol.</param>
		/// <returns><b>True</b> if the filter matches the packet, <b>false</b> otherwise.</returns>
		public bool Matches(IPAddress sourceAddress, IPAddress destinationAddress, byte protocol)
		{
			if (null != this.SourceAddress ? !this.SourceAddress.Equals(sourceAddress) : false) return false;
			if (null != this.DestinationAddress ? !this.DestinationAddress.Equals(destinationAddress) : false) return false;
			if (null != this.Protocol ? (byte)this.Protocol != protocol : false) return false;
			return true;
		}

		#endregion
	}
}
