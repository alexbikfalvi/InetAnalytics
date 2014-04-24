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
using InetApi.Net.Core.Protocols.Filters;

namespace InetApi.Net.Core.Protocols
{
	/// <summary>
	/// A class representing an IP version 4 packet.
	/// </summary>
	public sealed class ProtoPacketIp : ProtoPacketIpHeader
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
			AnyLocalNetwork = 63,
			/// <summary>
			/// Reserved.
			/// </summary>
			Reserved = 255
		}

		/// <summary>
		/// Private constructor.
		/// </summary>
		/// <param name="buffer">The buffer from which to read the packet.</param>
		/// <param name="index">The buffer index.</param>
		/// <param name="length">The data length.</param>
		/// <param name="filters">The list of filters.</param>
		private ProtoPacketIp(byte[] buffer, ref int index, int length)
			: base(buffer, ref index, length, true)
		{
			// Parse the payload.
			if (index < length)
			{
				switch ((ProtoPacketIp.Protocols)this.Protocol)
				{
					case Protocols.Icmp: this.Payload = ProtoPacketIcmp.Parse(buffer, ref index, length); break;
					case Protocols.Udp: this.Payload = ProtoPacketUdp.Parse(buffer, ref index, length, this); break;
					default: this.Payload = ProtoPacketRaw.Parse(buffer, ref index, length); break;
				}
			}
		}

		/// <summary>
		/// Creates a new IP version 4 packet.
		/// </summary>
		/// <param name="sourceAddress">The source address.</param>
		/// <param name="destinationAddress">The destination address.</param>
		public ProtoPacketIp(IPAddress sourceAddress, IPAddress destinationAddress)
			: base(sourceAddress, destinationAddress)
		{
			this.Payload = null;
		}

		/// <summary>
		/// Creates a new IP version 4 packet.
		/// </summary>
		/// <param name="sourceAddress">The source address.</param>
		/// <param name="destinationAddress">The destination address.</param>
		/// <param name="payload">The payload.</param>
		public ProtoPacketIp(IPAddress sourceAddress, IPAddress destinationAddress, ProtoPacketIpPayload payload)
			: base(sourceAddress, destinationAddress)
		{
			if (null == payload) throw new ArgumentNullException("payload");

			this.Protocol = (byte)payload.Protocol;
			this.Payload = payload;

			// Validate the length.
			if (this.Length > ProtoPacketIp.maximumLength) throw new ArgumentException("The packet length exceeds " + ProtoPacketIp.maximumLength + " bytes.");
		}

		/// <summary>
		/// Creates a new IP version 4 packet.
		/// </summary>
		/// <param name="sourceAddress">The source address.</param>
		/// <param name="destinationAddress">The destination address.</param>
		/// <param name="payload">The payload.</param>
		/// <param name="options">The protocol options.</param>
		public ProtoPacketIp(IPAddress sourceAddress, IPAddress destinationAddress, ProtoPacketIpPayload payload, params ProtoPacketIpOption[] options)
			: base(sourceAddress, destinationAddress, options)
		{
			if (null == payload) throw new ArgumentNullException("payload");

			this.Protocol = (byte)payload.Protocol;
			this.Payload = payload;

			// Validate the length.
			if (this.Length > ProtoPacketIp.maximumLength) throw new ArgumentException("The packet length exceeds " + ProtoPacketIp.maximumLength + " bytes.");
		}

		#region Public properties

		/// <summary>
		/// Gets the packet length in bytes.
		/// </summary>
		public override ushort Length { get { return (ushort)(this.HeaderLength + (this.Payload != null ? this.Payload.Length : 0)); } }
		/// <summary>
		/// The IP payload.
		/// </summary>
		public ProtoPacketIpPayload Payload { get; private set; }

		#endregion

		#region Public methods

		/// <summary>
		/// Gets the packet information as a string.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("IPv4 Src: {0} Dst: {1} Header: {2} Length: {3} Identifier: 0x{4:X4} TTL: {5} Protocol: {6} Checksum: 0x{7:X4} ({8})",
				this.SourceAddress,
				this.DestinationAddress,
				this.HeaderLength,
				this.Length,
				this.Identification,
				this.TimeToLive,
				this.Protocol,
				this.HeaderChecksum,
				this.IsHeaderChecksumValid ? "ok" : "fail");
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
			// Call the base class method.
			int idx = base.Write(buffer, index, args);

			// Write the payload.
			if (null != this.Payload) this.Payload.Write(buffer, idx, this);

			return index + this.Length;
		}

		#endregion

		#region Static methods

		/// <summary>
		/// Parses an IP packet from the specified buffer at the given index.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <param name="index">The index.</param>
		/// <param name="length">The length.</param>
		/// <returns>The packet.</returns>
		public new static ProtoPacketIp Parse(byte[] buffer, ref int index, int length)
		{
			// Create the packet.
			return new ProtoPacketIp(buffer, ref index, length);
		}

		/// <summary>
		/// Parses an IP packet from the specified buffer at the given index, filtering according to the specified filters.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <param name="index">The index.</param>
		/// <param name="length">The length.</param>
		/// <param name="filters">The list of filters.</param>
		/// <param name="packet">The IP packet or <b>null</b>.</param>
		/// <returns><b>True</b> if th packet was parsed, <b>false</b> otherwise.</returns>
		public static bool ParseFilter(byte[] buffer, ref int index, int length, FilterIp[] filters, out ProtoPacketIp packet)
		{
			// Set the packet to null.
			packet = null;

			// Validate the packet.
			if (buffer[index] >> 4 != ProtoPacketIp.version) return false;

			// Validate the length.
			if ((ushort)((buffer[index + 2] << 8) | buffer[index + 3]) != length - index) return false;

			// Set the protocol.
			byte protocol = buffer[index + 9];

			// Parse the source address.
			IPAddress sourceAddress = new IPAddress(new byte[] { buffer[index + 12], buffer[index + 13], buffer[index + 14], buffer[index + 15] });
			// Parse the destination address.
			IPAddress destinationAddress = new IPAddress(new byte[] { buffer[index + 16], buffer[index + 17], buffer[index + 18], buffer[index + 19] });

			// Try and match the filters.
			bool match = false;
			for (int idx = 0; (idx < filters.Length) && (!match); idx++)
			{
				match = match || filters[idx].Matches(sourceAddress, destinationAddress, protocol); 
			}

			if (!match)
				return false;

			// Parse the packet.
			packet = ProtoPacketIp.Parse(buffer, ref index, length);

			// Return true.
			return true;
		}

		#endregion
	}
}
