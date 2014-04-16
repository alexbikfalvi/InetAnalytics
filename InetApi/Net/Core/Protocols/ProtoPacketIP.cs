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
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace InetApi.Net.Core.Protocols
{
	/// <summary>
	/// A class representing an IP version 4 packet.
	/// </summary>
	public sealed class ProtoPacketIp : ProtoPacket
	{
		/// <summary>
		/// An enumeration containing the list of protocols.
		/// </summary>
		public enum Protocols
		{
			/// <summary>
			/// IPv6 Hop-by-Hop Option. RFC 2460
			/// </summary>
			HopOpt = 0,
			/// <summary>
			/// Internet Control Message Protocol. RFC 792
			/// </summary>
			Icmp = 1,
			/// <summary>
			/// IGMP for user Authentication Protocol.
			/// </summary>
 			Igap = 2,
			/// <summary>
			/// Internet Group Management Protocol
			/// </summary>
			Igmp = 2,
			/// <summary>
			/// Router-port Group Management Protocol. RFC 1112
			/// </summary>
			Rgmp = 2,
			/// <summary>
			/// Gateway to Gateway Protocol. RFC 823
			/// </summary>
			Ggp = 3,
			/// <summary>
			/// IP in IP encapsulation. RFC 2003
			/// </summary>
			Ip = 4,
			/// <summary>
			/// Internet Stream Protocol. RFC 1190, RFC 1819
			/// </summary>
			St = 5,
			/// <summary>
			/// Transmission Control Protocol. RFC 793
			/// </summary>
			Tcp = 6,
			/// <summary>
			/// Core Based Trees
			/// </summary>
			Cbt = 7,
			/// <summary>
			/// Exterior Gateway Protocol. RFC 888
			/// </summary>
			Egp = 8,
			/// <summary>
			/// Interior Gateway Routing Protocol.
			/// </summary>
			Igrp = 9,
			/// <summary>
			/// BBN RCC Monitoring.
			/// </summary>
			Bbn = 10,
			/// <summary>
			/// Network Voice Protocol. RFC 741
			/// </summary>
			Nvp = 11,
			Pup = 12,
			Argus = 13,
			/// <summary>
			/// Emission Control Protocol.
			/// </summary>
			Emcon = 14,
			/// <summary>
			/// Cross Net Debugger. IEN 158
			/// </summary>
			Xnet = 15,
			Chaos = 16,
			/// <summary>
			/// User Datagram Protocol. RFC 768
			/// </summary>
			Udp = 17,
			/// <summary>
			/// Transport Multiplexing Protocol. IEN 90
			/// </summary>
			TMux = 18,
			/// <summary>
			/// DCN Measurement Subsystems.
			/// </summary>
			Dcn = 19,
			/// <summary>
			/// Host Monitoring Protocol. RFC 869
			/// </summary>
			Hmp = 20,
			PacketRadioMeasurement = 21,
			XeroxNsIdp = 22,
			Trunk1 = 23,
			Trunk2 = 24,
			Leaf1 = 25,
			Leaf2 = 26,
			/// <summary>
			/// Reliable Data Protocol. RFC 908
			/// </summary>
			Rdp = 27,
			/// <summary>
			/// Internet Reliable Transaction Protocol. RFC 938
			/// </summary>
			Irtp = 28,
			/// <summary>
			/// ISO Transport Protocol Class 4. RFC 905
			/// </summary>
			Iso = 29,
			/// <summary>
			/// Network Block Transfer.
			/// </summary>
			NetBlt = 30,
			/// <summary>
			/// MFE Network Services Protocol.
			/// </summary>
			Mfe = 31,
			/// <summary>
			/// MERIT Internodal Protocol.
			/// </summary>
			Merit = 32,
			/// <summary>
			/// Datagram Congestion Control Protocol.
			/// </summary>
			Dccp = 33,
			/// <summary>
			/// Third Party Connect Protocol.
			/// </summary>
			Tpcp = 34,
			/// <summary>
			/// Inter-Domain Policy Routing Protocol.
			/// </summary>
			Idpr = 35,
			/// <summary>
			/// Xpress Transfer Protocol.
			/// </summary>
			Xtp = 36,
			/// <summary>
			/// Datagram Delivery Protocol.
			/// </summary>
			Ddp = 37,
			/// <summary>
			/// Control Message Transport Protocol.
			/// </summary>
			Cmtp = 38,
			/// <summary>
			/// TP++ Transport Protocol.
			/// </summary>
			Tppp = 39,
			/// <summary>
			/// IL Transport Protocol.
			/// </summary>
			Iltp = 40,
			/// <summary>
			/// IPv6 over IPv4. RFC 2473
			/// </summary>
			Ipv6 = 41,
			/// <summary>
			/// Source Demand Routing Protocol.
			/// </summary>
			Sdrp = 42,
			/// <summary>
			/// IPv6 Routing header.
			/// </summary>
			Ip6RoutingHeader = 43,
			/// <summary>
			/// IPv6 Fragment header.
			/// </summary>
			Ip6FragmentHeader = 44,
			/// <summary>
			/// Inter-Domain Routing Protocol.
			/// </summary>
			Idrp = 45,
			/// <summary>
			/// Reservation Protocol.
			/// </summary>
			Rsvp = 46,
			/// <summary>
			/// General Routing Encapsulation.
			/// </summary>
			Gre = 47,
			/// <summary>
			/// Dynamic Source Routing Protocol.
			/// </summary>
			Dsr = 48,
			Bna = 49,
			/// <summary>
			/// Encapsulating Security Payload.
			/// </summary>
			Esp = 50,
			/// <summary>
			/// Authentication Header.
			/// </summary>
			Ah = 51,
			/// <summary>
			/// Integrated Net Layer Security TUBA.
			/// </summary>
			Inlsp = 52,
			/// <summary>
			/// IP with Encryption.
			/// </summary>
			Swipe = 53,
			/// <summary>
			/// NBMA Address Resolution Protocol.
			/// </summary>
			Narp = 54,
			/// <summary>
			/// Minimal Encapsulation Protocol.
			/// </summary>
			Mep = 55,
			/// <summary>
			/// Transport Layer Security Protocol using Kryptonet key management.
			/// </summary>
			Tlsp = 56,
			Skip = 57,
			/// <summary>
			/// Internet Control Message Protocol for IPv6.
			/// </summary>
			Icmp6 = 58,
			/// <summary>
			/// Multicast Listener Discovery.
			/// </summary>
			Mld = 58,
			/// <summary>
			/// IPv6 No Next Header.
			/// </summary>
			Ip6NoNextHeader = 59,
			/// <summary>
			/// IPv6 Destination Options.
			/// </summary>
			Ip6DestinationOptions = 60,
			AnyHostInternalProtocol = 61,
			Cftp = 62,
			AnyLocalNetwork = 63
		}

		private static ushort defaultIdentification;
		private const byte version = 4;
		private const byte timeToLive = 128;

		private byte headerLength = 5;
		private ushort optionsLength = 0;
		private ushort length;

		private readonly byte[] srcAddress;
		private readonly byte[] dstAddress;

		/// <summary>
		/// Static constructor.
		/// </summary>
		static ProtoPacketIp()
		{
			Random random = new Random();
			ProtoPacketIp.defaultIdentification = (ushort)(random.Next() & 0xFFFF);
		}

		/// <summary>
		/// Creates a new IP version 4 packet.
		/// </summary>
		/// <param name="sourceAddress">The source address.</param>
		/// <param name="destinationAddress">The destination address.</param>
		public ProtoPacketIp(IPAddress sourceAddress, IPAddress destinationAddress)
		{
			if (null == sourceAddress) throw new ArgumentNullException("srcAddress");
			if (null == destinationAddress) throw new ArgumentNullException("dstAddress");
			if (sourceAddress.AddressFamily != AddressFamily.InterNetwork) throw new ArgumentException("The source address is not valid.");
			if (destinationAddress.AddressFamily != AddressFamily.InterNetwork) throw new ArgumentException("The destination address is not valid.");

			this.DifferentiatedServices = 0;
			this.Identification = ProtoPacketIp.defaultIdentification++;
			this.DontFragment = false;
			this.MoreFragments = false;
			this.FragmentOffset = 0;
			this.TimeToLive = ProtoPacketIp.timeToLive;
			this.Protocol = 0;
			this.SourceAddress = sourceAddress;
			this.DestinationAddress = destinationAddress;
			this.Options = null;
			this.Payload = null;

			this.srcAddress = sourceAddress.GetAddressBytes();
			this.dstAddress = destinationAddress.GetAddressBytes();

			this.length = this.HeaderLength;
		}

		/// <summary>
		/// Creates a new IP version 4 packet.
		/// </summary>
		/// <param name="sourceAddress">The source address.</param>
		/// <param name="destinationAddress">The destination address.</param>
		/// <param name="payload">The payload.</param>
		public ProtoPacketIp(IPAddress sourceAddress, IPAddress destinationAddress, ProtoPacketIpPayload payload)
		{
			if (null == sourceAddress) throw new ArgumentNullException("srcAddress");
			if (null == destinationAddress) throw new ArgumentNullException("dstAddress");
			if (null == payload) throw new ArgumentNullException("payload");
			if (sourceAddress.AddressFamily != AddressFamily.InterNetwork) throw new ArgumentException("The source address is not valid.");
			if (destinationAddress.AddressFamily != AddressFamily.InterNetwork) throw new ArgumentException("The destination address is not valid.");

			this.DifferentiatedServices = 0;
			this.Identification = ProtoPacketIp.defaultIdentification++;
			this.DontFragment = false;
			this.MoreFragments = false;
			this.FragmentOffset = 0;
			this.TimeToLive = ProtoPacketIp.timeToLive;
			this.Protocol = (byte)payload.Protocol;
			this.SourceAddress = sourceAddress;
			this.DestinationAddress = destinationAddress;
			this.Options = null;
			this.Payload = payload;

			this.srcAddress = sourceAddress.GetAddressBytes();
			this.dstAddress = destinationAddress.GetAddressBytes();

			// Validate the length.
			if (this.HeaderLength + payload.Length > 65520) throw new ArgumentException("The packet length exceeds 65520 bytes.");

			// Compute the length.
			this.length = (ushort)(this.HeaderLength + payload.Length);
		}

		/// <summary>
		/// Creates a new IP version 4 packet.
		/// </summary>
		/// <param name="sourceAddress">The source address.</param>
		/// <param name="destinationAddress">The destination address.</param>
		/// <param name="payload">The payload.</param>
		/// <param name="options">The protocol options.</param>
		public ProtoPacketIp(IPAddress sourceAddress, IPAddress destinationAddress, ProtoPacketIpPayload payload, params ProtoPacketIpOption[] options)
		{
			if (null == sourceAddress) throw new ArgumentNullException("srcAddress");
			if (null == destinationAddress) throw new ArgumentNullException("dstAddress");
			if (null == payload) throw new ArgumentNullException("payload");
			if (sourceAddress.AddressFamily != AddressFamily.InterNetwork) throw new ArgumentException("The source address is not valid.");
			if (destinationAddress.AddressFamily != AddressFamily.InterNetwork) throw new ArgumentException("The destination address is not valid.");

			this.DifferentiatedServices = 0;
			this.Identification = ProtoPacketIp.defaultIdentification++;
			this.DontFragment = false;
			this.MoreFragments = false;
			this.FragmentOffset = 0;
			this.TimeToLive = ProtoPacketIp.timeToLive;
			this.Protocol = (byte)payload.Protocol;
			this.SourceAddress = sourceAddress;
			this.DestinationAddress = destinationAddress;
			this.Options = options;
			this.Payload = payload;

			this.srcAddress = sourceAddress.GetAddressBytes();
			this.dstAddress = destinationAddress.GetAddressBytes();

			// Compute the options length.
			foreach (ProtoPacketIpOption option in this.Options)
			{
				this.optionsLength += option.Length;
			}

			// Validate the options length.
			if (this.optionsLength > 40) throw new ArgumentException("The options length cannot exceed 40 bytes.");

			// Compute the header length.
			this.headerLength += (byte)((this.optionsLength & 0x3) != 0 ? (this.optionsLength >> 2) + 1 : this.optionsLength >> 2);

			// Validate the length.
			if (this.headerLength + payload.Length > 65520) throw new ArgumentException("The packet length exceeds 65520 bytes.");

			// Compute the length.
			this.length = (ushort)(this.HeaderLength + payload.Length);
		}

		#region Public properties

		/// <summary>
		/// Gets the packet length in bytes.
		/// </summary>
		public override ushort Length { get { return this.length; } }
		/// <summary>
		/// Specifies the format of the IP packet header.
		/// </summary>
		public byte Version { get { return ProtoPacketIp.version; } }
		/// <summary>
		/// Specifies the length of the IP packet header in 32 bit words. The minimum value for a valid header is 5.
		/// </summary>
		public ushort HeaderLength { get { return (ushort)(this.headerLength << 2); } }
		/// <summary>
		/// This field is defined in RFC 2474 and obsoletes the TOS field.
		/// </summary>
		public byte DifferentiatedServices { get; set; }
		/// <summary>
		/// Used to identify the fragments of one datagram from those of another. The originating protocol module of an internet datagram sets the identification field to a value that must be unique for that source-destination pair and protocol for the time the datagram will be active in the internet system. The originating protocol module of a complete datagram clears the MF bit to zero and the Fragment Offset field to zero.
		/// </summary>
		public ushort Identification { get; private set; }
		/// <summary>
		/// Controls the fragmentation of the datagram.
		/// </summary>
		public bool DontFragment { get; private set; }
		/// <summary>
		/// Indicates if the datagram contains additional fragments.
		/// </summary>
		public bool MoreFragments { get; private set; }
		/// <summary>
		/// Used to direct the reassembly of a fragmented datagram.
		/// </summary>
		public ushort FragmentOffset { get; private set; }
		/// <summary>
		/// A timer field used to track the lifetime of the datagram. When the TTL field is decremented down to zero, the datagram is discarded.
		/// </summary>
		public byte TimeToLive { get; set; }
		/// <summary>
		/// This field specifies the next encapsulated protocol.
		/// </summary>
		public byte Protocol { get; private set; }
		/// <summary>
		/// IP address of the sender.
		/// </summary>
		public IPAddress SourceAddress { get; private set; }
		/// <summary>
		/// IP address of the intended receiver.
		/// </summary>
		public IPAddress DestinationAddress { get; private set; }
		/// <summary>
		/// The IP options.
		/// </summary>
		public ProtoPacketIpOption[] Options { get; private set; }
		/// <summary>
		/// The IP payload.
		/// </summary>
		public ProtoPacketIpPayload Payload { get; private set; }

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
			if (index + this.length > buffer.Length) throw new IndexOutOfRangeException("The buffer is too small.");

			int idx = index;

			// Write the version (7..4) and header length (3..0)
			buffer[idx++] = (byte)(((ProtoPacketIp.version & 0xF) << 4) | (this.headerLength & 0xF));
			// Write the DSCP (7..2) and ECN (1..0)
			buffer[idx++] = this.DifferentiatedServices;
			// Write the packet length.
			buffer[idx++] = (byte)(this.length >> 8);
			buffer[idx++] = (byte)(this.length & 0xFF);
			// Write the packet identification.
			buffer[idx++] = (byte)(this.Identification >> 8);
			buffer[idx++] = (byte)(this.Identification & 0xFF);
			// Write the flags: reserved (7) DF (6) MF (5) and fragment offset.
			buffer[idx++] = (byte)((this.DontFragment ? 1 << 6 : 0) | (this.MoreFragments ? 1 << 5 : 0) | ((this.FragmentOffset >> 8) & 0x1F));
			buffer[idx++] = (byte)(this.FragmentOffset & 0xFF);
			// Write the time-to-live.
			buffer[idx++] = this.TimeToLive;
			buffer[idx++] = this.Protocol;
			// Set the checksum to zero.
			buffer[idx++] = 0;
			buffer[idx++] = 0;
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

			// If there are options, add the options.
			if (null != this.Options)
			{
				foreach (ProtoPacketIpOption option in this.Options)
				{
					idx = option.Write(buffer, idx);
				}
				while (idx < index + this.HeaderLength)
				{
					buffer[idx++] = 0;
				}
			}

			// Compute the header checksum.
			int checksum = 0;
			for (int idxSum = index, len = index + this.HeaderLength - 1; idxSum < index + this.HeaderLength; idxSum += 2)
			{
				checksum += (buffer[idxSum] << 8) | (idxSum < len ? buffer[idxSum + 1] : 0);
			}
			checksum = ~(((checksum >> 16) + (checksum & 0xFFFF)) & 0xFFFF);
			buffer[index + 10] = (byte)((checksum >> 8) & 0xFF);
			buffer[index + 11] = (byte)(checksum & 0xFF);

			// Write the payload.
			if (null != this.Payload) this.Payload.Write(buffer, idx);

			return index + this.length;
		}

		#endregion
	}
}
