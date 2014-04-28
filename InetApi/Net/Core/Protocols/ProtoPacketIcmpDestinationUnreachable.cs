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

namespace InetApi.Net.Core.Protocols
{
	/// <summary>
	/// A class representing an ICMP version 4 packet of destination unreachable type.
	/// </summary>
	public sealed class ProtoPacketIcmpDestinationUnreachable : ProtoPacketIcmp
	{
		/// <summary>
		/// The codes for destination unreachable.
		/// </summary>
		public enum DestinationUnreachableCode
		{
			/// <summary>
			/// Network unreachable error. RFC 792
			/// </summary>
			NetworkUnreachable = 0,
			/// <summary>
			/// Host unreachable error. RFC 792
			/// </summary>
			HostUnreachable = 1,
			/// <summary>
			/// Protocol unreachable error. Sent when the designated transport protocol is not supported. RFC 792
			/// </summary>
			ProtocolUnreachable = 2,
			/// <summary>
			/// Port unreachable error. Sent when the designated transport protocol is unable to demultiplex the datagram but has no protocol mechanism to inform the sender. RFC 792
			/// </summary>
			PortUnreachable = 3,
			/// <summary>
			/// The datagram is too big. Packet fragmentation is required but the DF bit in the IP header is set. RFC 792
			/// </summary>
			DatagramTooBig = 4,
			/// <summary>
			/// Source route failed error. RFC 792
			/// </summary>
			SourceRouteFailed = 5,
			/// <summary>
			/// Destination network unknown error. RFC 1122
			/// </summary>
			DestinationNetworkUnknown = 6,
			/// <summary>
			/// Destination host unknown error. RFC 1122
			/// </summary>
			DestinationHostUnknown = 7,
			/// <summary>
			/// Source host isolated error. Obsolete. RFC 1122
			/// </summary>
			[Obsolete]
			SourceHostIsolatedError = 8,
			/// <summary>
			/// The destination network is administratively prohibited. RFC 1122
			/// </summary>
			DestinationNetworkProhibited = 9,
			/// <summary>
			/// The destination host is administratively prohibited. RFC 1122
			/// </summary>
			DestinationHostProhibited = 10,
			/// <summary>
			/// The network is unreachable for Type Of Service.	RFC 1122
			/// </summary>
			NetworkUnreachableTos = 11,
			/// <summary>
			/// The host is unreachable for Type Of Service. RFC 1122
			/// </summary>
			HostUnreachableTos = 12,
			/// <summary>
			/// Communication Administratively Prohibited. This is generated if a router cannot forward a packet due to administrative filtering. RFC 1812
			/// </summary>
			CommunicationProhibitedc = 13,
			/// <summary>
			/// Host precedence violation. Sent by the first hop router to a host to indicate that a requested precedence is not permitted for the particular combination of source/destination host or network, upper layer protocol, and source/destination port. RFC 1812
			/// </summary>
			HostPrecedenceViolation = 14,
			/// <summary>
			/// Precedence cutoff in effect. The network operators have imposed a minimum level of precedence required for operation, the datagram was sent with a precedence below this level.
			/// </summary>
			PrecedenceCutoff = 15
		}

		private readonly byte code;

		/// <summary>
		/// Private constructor.
		/// </summary>
		/// <param name="buffer">The buffer from which to read the packet.</param>
		/// <param name="index">The buffer index.</param>
		/// <param name="length">The data length.</param>
		/// <param name="args">Protocol specific arguments.</param>
		private ProtoPacketIcmpDestinationUnreachable(byte[] buffer, ref int index, int length)
			: base(IcmpType.DestinationUnreachable)
		{
			int idx = index;

			// Validate the type.
			if (buffer[idx++] != this.Type) throw new ProtoException("Invalid ICMP destination unreachable type.");

			// Set the code.
			this.code = buffer[idx++];
			// Set the checksum.
			this.Checksum = (ushort)((buffer[idx++] << 8) | buffer[idx++]);
			// Set whether the checksum is valid.
			this.IsChecksumValid = ProtoPacket.ChecksumOneComplement16Bit(buffer, index, length - index) == 0;

			// Validate the checksum.
			if (!ProtoPacketIcmp.IgnoreChecksum && !this.IsChecksumValid)
				throw new ProtoException("Invalid ICMP checksum.");

			// Skip the unused bytes.
			idx += 2;

			// Set the next hop MTU.
			this.NextHopMtu = (ushort)((buffer[idx++] << 8) | buffer[idx++]);

			// Parse the IP header.
			this.IpHeader = ProtoPacketIpHeader.Parse(buffer, ref idx, length - idx);

			// Set the IP payload.
			this.IpPayload = new byte[8];
			Array.Copy(buffer, idx, this.IpPayload, 0, 8);

			// Set the index.
			index = idx;
		}

		#region Public properties

		/// <summary>
		/// Gets the packet length in bytes.
		/// </summary>
		public override ushort Length { get { return (ushort)(16 + this.IpHeader.HeaderLength); } }
		/// <summary>
		/// Cleared to 0.
		/// </summary>
		public override byte Code { get { return this.code; } }
		/// <summary>
		/// For use when the code is set to 4 (Datagram too big).
		/// </summary>
		public ushort NextHopMtu { get; private set; }
		/// <summary>
		/// The internet header.
		/// </summary>
		public ProtoPacketIpHeader IpHeader { get; private set; }
		/// <summary>
		/// The first 64 bits of the original datagram's data.
		/// </summary>
		public byte[] IpPayload { get; private set; }

		#endregion

		#region Public methods

		/// <summary>
		/// Gets the packet information as a string.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("ICMP DESTINATION-UNREACHABLE Length: {0} Type: {1} Code: {2} Checksum: {3:X4} ({4}) NextHopMtu: {5:X4}",
				this.Length,
				this.Type,
				this.Code,
				this.Checksum,
				this.IsChecksumValid ? "ok" : "fail",
				this.NextHopMtu);
		}

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
			if (index + this.Length > buffer.Length) throw new IndexOutOfRangeException("The buffer is too small.");

			int idx = index;

			// Write the type.
			buffer[idx++] = this.Type;
			// Write the code.
			buffer[idx++] = this.Code;
			// Set the checksum to zero.
			buffer[idx++] = 0;
			buffer[idx++] = 0;
			// Skip the next two bytes.
			idx += 2;
			// Write the next hop MTU.
			buffer[idx++] = (byte)(this.NextHopMtu >> 8);
			buffer[idx++] = (byte)(this.NextHopMtu & 0xFF);

			// Write the IP header.
			idx = this.IpHeader.Write(buffer, idx);

			// Write the IP payload.
			Array.Copy(this.IpPayload, 0, buffer, idx, 8);

			// Compute the checksum.
			ushort checksum = ProtoPacket.ChecksumOneComplement16Bit(buffer, index, this.Length);
			buffer[index + 2] = (byte)((checksum >> 8) & 0xFF);
			buffer[index + 3] = (byte)(checksum & 0xFF);

			// Return the new index.
			return idx;
		}

		#endregion

		#region Static methods

		/// <summary>
		/// Parses an ICMP destination unreachable packet from the specified buffer at the given index.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <param name="index">The index.</param>
		/// <param name="length">The length.</param>
		/// <returns>The packet.</returns>
		public new static ProtoPacketIcmpDestinationUnreachable Parse(byte[] buffer, ref int index, int length)
		{
			return new ProtoPacketIcmpDestinationUnreachable(buffer, ref index, length);
		}

		#endregion
	}
}
