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
using System.Net.Sockets;

namespace InetApi.Net.Core.Protocols
{
	/// <summary>
	/// A class representing an IP version 4 traceroute option.
	/// </summary>
	public sealed class ProtoPacketIpOptionTraceroute : ProtoPacketIpOption
	{
		private const byte length = 12;

		private readonly byte[] originatorAddress;

		/// <summary>
		/// Creates a new IP version 4 traceroute option instance.
		/// </summary>
		/// <param name="identifier">The identifier.</param>
		/// <param name="outboundHopCount">The outboud hop count.</param>
		/// <param name="returnHopCount">The return hop count.</param>
		/// <param name="originatorAddress">The originator address.</param>
		public ProtoPacketIpOptionTraceroute(short identifier, short outboundHopCount, short returnHopCount, IPAddress originatorAddress)
			: base(OptionType.Traceroute)
		{
			// Validate the arguments.
			if (originatorAddress.AddressFamily != AddressFamily.InterNetwork) throw new ArgumentException("The originator address is not valid.");

			this.Identifier = identifier;
			this.OutboundHopCount = outboundHopCount;
			this.ReturnHopCount = returnHopCount;
			this.OriginatorAddress = originatorAddress;

			this.originatorAddress = originatorAddress.GetAddressBytes();
		}

		#region Public properties

		/// <summary>
		/// The packet length.
		/// </summary>
		public override ushort Length { get { return ProtoPacketIpOptionTraceroute.length; } }
		/// <summary>
		/// An arbitrary number used by the originator of the outbound packet to identify the ICMP Traceroute messages. It is NOT related to the ID number in the IP header.
		/// </summary>
		public short Identifier { get; set; }
		/// <summary>
		/// The number of routers through which the outbound packet has passed. This field is not incremented by the outbound packet's destination.
		/// </summary>
		public short OutboundHopCount { get; set; }
		/// <summary>
		/// The number of routers through which the return packet has passed. This field is not incremented by the return packet's destination.
		/// </summary>
		public short ReturnHopCount { get; set; }
		/// <summary>
		/// The IP address of the originator of the outbound packet. This is needed so routers can know where to send the ICMP Traceroute message for return packets. It is also needed for outbound packets which have a Source Route option.
		/// </summary>
		public IPAddress OriginatorAddress { get; set; }

		#endregion

		#region Public methods

		/// <summary>
		/// Writes the current packet to the buffer at the specified index.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <param name="index">The index.</param>
		/// <param name="args">Protocol specific arguments.</param>
		/// <returns>The new index, after the packet has been written.</returns>
		public override int Write(byte[] buffer, int index, params object[] args)
		{
			// Validate the buffer.
			if (index + ProtoPacketIpOptionTraceroute.length > buffer.Length) throw new IndexOutOfRangeException("The buffer is too small.");

			// Write the type.
			buffer[index++] = (byte)this.Type;
			// Write the length.
			buffer[index++] = ProtoPacketIpOptionTraceroute.length;
			// Write the identifier.
			buffer[index++] = (byte)(this.Identifier >> 8);
			buffer[index++] = (byte)(this.Identifier & 0xFF);
			// Write the outbound hop count.
			buffer[index++] = (byte)(this.OutboundHopCount >> 8);
			buffer[index++] = (byte)(this.OutboundHopCount & 0xFF);
			// Write the return hop count.
			buffer[index++] = (byte)(this.ReturnHopCount >> 8);
			buffer[index++] = (byte)(this.ReturnHopCount & 0xFF);
			// Write the originator address.
			buffer[index++] = this.originatorAddress[0];
			buffer[index++] = this.originatorAddress[1];
			buffer[index++] = this.originatorAddress[2];
			buffer[index++] = this.originatorAddress[3];

			// Return the new index.
			return index;
		}

		#endregion
	}
}
