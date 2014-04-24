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
	/// A class representing an ICMP version 4 packet.
	/// </summary>
	public abstract class ProtoPacketIcmp : ProtoPacketIpPayload
	{
		/// <summary>
		/// An enumeration representing the ICMP packet type.
		/// </summary>
		public enum IcmpType
		{
			/// <summary>
			/// Echo reply. RFC 792
			/// </summary>
			EchoReply = 0,
			/// <summary>
			/// Destination unreachable. RFC 792
			/// </summary>
			DestinationUnreachable = 3,
			/// <summary>
			/// Source quench. RFC 792
			/// </summary>
			SourceQuench = 4,
			/// <summary>
			/// Redirect. RFC 792
			/// </summary>
			Redirect = 5,
			/// <summary>
			/// Echo request. RFC 792
			/// </summary>
			EchoRequest = 8,
			/// <summary>
			/// Router advertisement. RFC 1256
			/// </summary>
			RouterAdvertisement = 9,
			/// <summary>
			/// Router solicitation. RFC 1256
			/// </summary>
			RouterSolicitation = 10,
			/// <summary>
			/// Time exceeded. RFC 792
			/// </summary>
			TimeExceeded = 11,
			/// <summary>
			/// Parameter problem. RFC 792
			/// </summary>
			ParameterProblem = 12,
			/// <summary>
			/// Timestamp request. RFC 792
			/// </summary>
			TimestampRequest = 13,
			/// <summary>
			/// Timestamp reply. RFC 792
			/// </summary>
			TimestampReply = 14,
			/// <summary>
			/// Information request. Obsolete. RFC 792
			/// </summary>
			[Obsolete]
			InformationRequest = 15,
			/// <summary>
			/// Information reply. Obsolete. RFC 792
			/// </summary>
			[Obsolete]
			InformationReply = 16,
			/// <summary>
			/// Address mask request. RFC 950
			/// </summary>
			AddressMaskRequest = 17,
			/// <summary>
			/// Address mask reply. RFC 950
			/// </summary>
			AddressMaskReply = 18,
			/// <summary>
			/// Traceroute. RFC 1393
			/// </summary>
			Traceroute = 30,
			/// <summary>
			/// Conversion error. RFC 1475
			/// </summary>
			ConversionError = 31,
			/// <summary>
			/// Mobile Host Redirect.
			/// </summary>
			MobileHostRedirect = 32,
			/// <summary>
			/// IPv6 Where-Are-You.
			/// </summary>
			Ipv6WhereAreYou = 33,
			/// <summary>
			/// IPv6 I-Am-Here.
			/// </summary>
			Ipv6IAmHere = 34,
			/// <summary>
			/// Mobile Registration Request.
			/// </summary>
			MobileRegistrationRequest = 35,
			/// <summary>
			/// Mobile Registration Reply.
			/// </summary>
			MobileRegistrationReply = 36,
			/// <summary>
			/// Domain Name request. RFC 1788
			/// </summary>
			DomainNameRequest = 37,
			/// <summary>
			/// Domain Name reply. RFC 1788
			/// </summary>
			DomainNameReply = 38,
			/// <summary>
			/// SKIP Algorithm Discovery Protocol.
			/// </summary>
			SkipAlgorithmDiscoveryProtocol = 39
		}

		/// <summary>
		/// Creates an ICMP packet of the specified type.
		/// </summary>
		/// <param name="type">The packet type.</param>
		protected ProtoPacketIcmp(IcmpType type)
			: base(ProtoPacketIp.Protocols.Icmp)
		{
			this.Type = (byte)type;
		}

		#region Public properties

		/// <summary>
		/// Specifies the format of the ICMP message.
		/// </summary>
		public byte Type { get; private set; }
		/// <summary>
		/// Further qualifies the ICMP message. 
		/// </summary>
		public abstract byte Code { get; }
		/// <summary>
		/// Checksum that covers the ICMP message.
		/// </summary>
		public ushort Checksum { get; protected set; }
		/// <summary>
		/// Indicates whether the checksum is valid.
		/// </summary>
		public bool IsChecksumValid { get; protected set; }

		#endregion

		#region Static properties

		/// <summary>
		/// Indicates whether the protocol ignores the checksum calculation.
		/// </summary>
		public static bool IgnoreChecksum { get; set; }

		#endregion

		#region Static methods

		/// <summary>
		/// Parses an ICMP packet from the specified buffer at the given index.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <param name="index">The index.</param>
		/// <param name="length">The data length.</param>
		/// <returns>The packet.</returns>
		public static ProtoPacketIcmp Parse(byte[] buffer, ref int index, int length)
		{
			// Get the protocol type.
			switch ((IcmpType)buffer[index])
			{
				case IcmpType.EchoRequest: return ProtoPacketIcmpEchoRequest.Parse(buffer, ref index, length);
				case IcmpType.EchoReply: return ProtoPacketIcmpEchoReply.Parse(buffer, ref index, length);
				default: throw new ProtoException("Unknown ICMP type.");
			}
		}

		#endregion
	}
}
