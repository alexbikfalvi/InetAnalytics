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
	/// A class representing an IP version 4 packet.
	/// </summary>
	public sealed class ProtoPacketIp : ProtoPacket
	{
		private static short defaultIdentification;
		private const short headerLength = 20;

		private short length;

		private readonly byte[] srcAddress;
		private readonly byte[] dstAddress;

		private short identification = 0;

		private byte dscp = 0;
		private byte ecn = 0;

		private byte dontFragment = 0;
		private byte moreFragments = 0;
		private short fragmentOffset = 0;

		private byte timeToLive = 128;
		private byte protocol = 0;

		private ProtoPacket payload = null;

		/// <summary>
		/// Static constructor.
		/// </summary>
		static ProtoPacketIp()
		{
			Random random = new Random();
			ProtoPacketIp.defaultIdentification = (short)(random.Next() & 0xFFFF);
		}

		/// <summary>
		/// Creates a new IP version 4 packet.
		/// </summary>
		/// <param name="srcAddress">The source address.</param>
		/// <param name="dstAddress">The destination address.</param>
		public ProtoPacketIp(IPAddress srcAddress, IPAddress dstAddress)
		{
			if (null == srcAddress) throw new ArgumentNullException("srcAddress");
			if (null == dstAddress) throw new ArgumentNullException("dstAddress");
			if (srcAddress.AddressFamily != AddressFamily.InterNetwork) throw new ArgumentException("The source address is not valid.");
			if (dstAddress.AddressFamily != AddressFamily.InterNetwork) throw new ArgumentException("The destination address is not valid.");

			this.srcAddress = srcAddress.GetAddressBytes();
			this.dstAddress = dstAddress.GetAddressBytes();
			
			this.identification = ProtoPacketIp.defaultIdentification++;

			this.length = ProtoPacketIp.headerLength;
		}

		#region Public properties

		/// <summary>
		/// Gets the packet length in bytes.
		/// </summary>
		public override short Length { get { return this.length; } }

		#endregion

		#region Public methods

		/// <summary>
		/// Writes the current packet to the buffer at the specified index.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <param name="index">The index.</param>
		/// <returns>The new index, after the packet has been written.</returns>
		public override int Write(byte[] buffer, int index)
		{
			// Validate the buffer.
			if (index + this.length > buffer.Length) throw new IndexOutOfRangeException("The buffer is too small for the IPv4 packet.");

			int idx = index;

			// Write the version (7..4) and header length (3..0)
			buffer[idx++] = 0x45;
			// Write the DSCP (7..2) and ECN (1..0)
			buffer[idx++] = (byte)(((this.dscp & 0x3F) << 2) | (this.ecn & 0x3));
			// Write the packet length.
			buffer[idx++] = (byte)(this.length >> 8);
			buffer[idx++] = (byte)(this.length & 0xFF);
			// Write the packet identification.
			buffer[idx++] = (byte)(this.identification >> 8);
			buffer[idx++] = (byte)(this.identification & 0xFF);
			// Write the flags: reserved (7) DF (6) MF (5)
			buffer[idx++] = (byte)((this.dontFragment << 6) | (this.moreFragments << 5));
			// Write the fragment offset.
			buffer[idx] |= (byte)((this.fragmentOffset >> 8) & 0x1F);
			buffer[idx++] = (byte)(this.fragmentOffset & 0xFF);
			// Write the time-to-live.
			buffer[idx++] = this.timeToLive;
			buffer[idx++] = this.protocol;

			idx += 2;

			// Write the source address.
			buffer[idx++] = this.srcAddress[0];
			buffer[idx++] = this.srcAddress[1];
			buffer[idx++] = this.srcAddress[2];
			buffer[idx++] = this.srcAddress[3];
			// Write the destination address.
			buffer[idx++] = this.dstAddress[0];
			buffer[idx++] = this.dstAddress[1];
			buffer[idx++] = this.dstAddress[2];
			buffer[idx++] = this.dstAddress[3];

			// Compute the header checksum.
			int sum = 0;
			for (int index2 = index; index2 < 20; index2 += 2)
			{
				sum += (buffer[index2] << 8) | buffer[index2 + 1];
			}
			sum = ~(((sum >> 16) + (sum & 0xFFFF)) & 0xFFFF);
			buffer[index + 10] = (byte)((sum >> 8) & 0xFF);
			buffer[index + 11] = (byte)(sum & 0xFF);

			// Write the payload.
			if (null != this.payload) this.payload.Write(buffer, idx);

			return index + this.length;
		}

		#endregion
	}
}
