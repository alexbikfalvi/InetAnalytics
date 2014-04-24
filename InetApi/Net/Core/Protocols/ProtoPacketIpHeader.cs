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
	/// A class representing an IP version 4 packet header.
	/// </summary>
	public class ProtoPacketIpHeader : ProtoPacket
	{
		protected const ushort maximumLength = 65520;
		protected const byte minimumHeaderLength = 20;
		protected const byte maximumOptionsLength = 40;

		protected const byte version = 4;
		protected const byte timeToLive = 128;

		private static ushort defaultIdentification;

		private byte headerLength = 5;
		private ushort optionsLength = 0;

		private readonly byte[] srcAddress;
		private readonly byte[] dstAddress;

		/// <summary>
		/// Static constructor.
		/// </summary>
		static ProtoPacketIpHeader()
		{
			Random random = new Random();
			ProtoPacketIpHeader.defaultIdentification = (ushort)(random.Next() & 0xFFFF);
		}

		/// <summary>
		/// Private constructor.
		/// </summary>
		/// <param name="buffer">The buffer from which to read the packet.</param>
		/// <param name="index">The buffer index.</param>
		/// <param name="length">The data length.</param>
		/// <param name="filters">The list of filters.</param>
		/// <param name="validate">If <b>true</b>, validate the packet length.</param>
		protected ProtoPacketIpHeader(byte[] buffer, ref int index, int length, bool validate)
		{
			// Validate the packet.
			if (buffer[index] >> 4 != ProtoPacketIpHeader.version) throw new ProtoException("Invalid IP version 4 version.");

			int idx = index;

			// Set the header length (3..0).
			this.headerLength = (byte)(buffer[idx++] & 0xF);
			// Set the differentiated services.
			this.DifferentiatedServices = buffer[idx++];

			// Validate the length.
			if (validate && (ushort)((buffer[idx] << 8) | buffer[idx + 1]) != length - index)
				throw new ProtoException("Invalid IP version 4 length.");
			idx += 2;

			// Set the packet identification.
			this.Identification = (ushort)((buffer[idx++] << 8) | buffer[idx++]);
			// Set the flags.
			this.DontFragment = ((buffer[idx] >> 6) & 0x1) != 0;
			this.MoreFragments = ((buffer[idx] >> 5) & 0x1) != 0;
			// Set the fragment offset.
			this.FragmentOffset = (ushort)(((buffer[idx++] & 0x1F) << 8) | buffer[idx++]);
			// Set the time-to-live.
			this.TimeToLive = buffer[idx++];
			// Set the protocol.
			this.Protocol = buffer[idx++];
			// Set the header checksum.
			this.HeaderChecksum = (ushort)((buffer[idx++] << 8) | buffer[idx++]);
			// Set whether the checksum is valid.
			this.IsHeaderChecksumValid = ProtoPacket.ChecksumOneComplement16Bit(buffer, index, this.HeaderLength) == 0;

			// Validate the checksum.
			if (!ProtoPacketIpHeader.IgnoreChecksum && !this.IsHeaderChecksumValid)
				throw new ProtoException("Invalid IP version 4 checksum.");

			// Set the source address.
			this.srcAddress = new byte[] { buffer[idx++], buffer[idx++], buffer[idx++], buffer[idx++] };
			this.SourceAddress = new IPAddress(this.srcAddress);
			// Write the destination address.
			this.dstAddress = new byte[] { buffer[idx++], buffer[idx++], buffer[idx++], buffer[idx++] };
			this.DestinationAddress = new IPAddress(this.dstAddress);

			// Parse the options.
			List<ProtoPacketIpOption> options = new List<ProtoPacketIpOption>();
			while (idx < index + this.HeaderLength)
			{
				// Parse the option.
				ProtoPacketIpOption option = ProtoPacketIpOption.Parse(buffer, ref idx, this.HeaderLength - ProtoPacketIpHeader.minimumHeaderLength);
				// Add the option.
				if (null != option) options.Add(option);
			}

			// Set the options.
			this.Options = options.ToArray();

			// Set the index to the index plus the header length.
			index = index + this.HeaderLength;
		}

		/// <summary>
		/// Creates a new IP version 4 packet.
		/// </summary>
		/// <param name="sourceAddress">The source address.</param>
		/// <param name="destinationAddress">The destination address.</param>
		public ProtoPacketIpHeader(IPAddress sourceAddress, IPAddress destinationAddress)
		{
			if (null == sourceAddress) throw new ArgumentNullException("srcAddress");
			if (null == destinationAddress) throw new ArgumentNullException("dstAddress");
			if (sourceAddress.AddressFamily != AddressFamily.InterNetwork) throw new ArgumentException("The source address is not valid.");
			if (destinationAddress.AddressFamily != AddressFamily.InterNetwork) throw new ArgumentException("The destination address is not valid.");

			this.DifferentiatedServices = 0;
			this.Identification = ProtoPacketIpHeader.defaultIdentification++;
			this.DontFragment = false;
			this.MoreFragments = false;
			this.FragmentOffset = 0;
			this.TimeToLive = ProtoPacketIpHeader.timeToLive;
			this.Protocol = 0;
			this.HeaderChecksum = 0;
			this.IsHeaderChecksumValid = false;
			this.SourceAddress = sourceAddress;
			this.DestinationAddress = destinationAddress;
			this.Options = null;

			this.srcAddress = sourceAddress.GetAddressBytes();
			this.dstAddress = destinationAddress.GetAddressBytes();
		}

		/// <summary>
		/// Creates a new IP version 4 packet.
		/// </summary>
		/// <param name="sourceAddress">The source address.</param>
		/// <param name="destinationAddress">The destination address.</param>
		/// <param name="options">The protocol options.</param>
		public ProtoPacketIpHeader(IPAddress sourceAddress, IPAddress destinationAddress, params ProtoPacketIpOption[] options)
		{
			if (null == sourceAddress) throw new ArgumentNullException("srcAddress");
			if (null == destinationAddress) throw new ArgumentNullException("dstAddress");
			if (sourceAddress.AddressFamily != AddressFamily.InterNetwork) throw new ArgumentException("The source address is not valid.");
			if (destinationAddress.AddressFamily != AddressFamily.InterNetwork) throw new ArgumentException("The destination address is not valid.");

			this.DifferentiatedServices = 0;
			this.Identification = ProtoPacketIpHeader.defaultIdentification++;
			this.DontFragment = false;
			this.MoreFragments = false;
			this.FragmentOffset = 0;
			this.TimeToLive = ProtoPacketIpHeader.timeToLive;
			this.HeaderChecksum = 0;
			this.IsHeaderChecksumValid = false;
			this.SourceAddress = sourceAddress;
			this.DestinationAddress = destinationAddress;
			this.Options = options;

			this.srcAddress = sourceAddress.GetAddressBytes();
			this.dstAddress = destinationAddress.GetAddressBytes();

			// Compute the options length.
			foreach (ProtoPacketIpOption option in this.Options)
			{
				this.optionsLength += option.Length;
			}

			// Validate the options length.
			if (this.optionsLength > ProtoPacketIpHeader.maximumOptionsLength) throw new ArgumentException("The options length cannot exceed " + ProtoPacketIpHeader.maximumOptionsLength + " bytes.");

			// Compute the header length.
			this.headerLength += (byte)((this.optionsLength & 0x3) != 0 ? (this.optionsLength >> 2) + 1 : this.optionsLength >> 2);
		}

		#region Public properties

		/// <summary>
		/// Gets the packet length in bytes.
		/// </summary>
		public override ushort Length { get { return this.HeaderLength; } }
		/// <summary>
		/// Specifies the format of the IP packet header.
		/// </summary>
		public byte Version { get { return ProtoPacketIpHeader.version; } }
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
		public ushort Identification { get; set; }
		/// <summary>
		/// Controls the fragmentation of the datagram.
		/// </summary>
		public bool DontFragment { get; set; }
		/// <summary>
		/// Indicates if the datagram contains additional fragments.
		/// </summary>
		public bool MoreFragments { get; set; }
		/// <summary>
		/// Used to direct the reassembly of a fragmented datagram.
		/// </summary>
		public ushort FragmentOffset { get; set; }
		/// <summary>
		/// A timer field used to track the lifetime of the datagram. When the TTL field is decremented down to zero, the datagram is discarded.
		/// </summary>
		public byte TimeToLive { get; set; }
		/// <summary>
		/// This field specifies the next encapsulated protocol.
		/// </summary>
		public byte Protocol { get; protected set; }
		/// <summary>
		/// The header checksum.
		/// </summary>
		public ushort HeaderChecksum { get; private set; }
		/// <summary>
		/// Indicates whether the header checksum is correct.
		/// </summary>
		public bool IsHeaderChecksumValid { get; private set; }
		/// <summary>
		/// IP address of the sender.
		/// </summary>
		public IPAddress SourceAddress { get; private set; }
		/// <summary>
		/// IP address of the intended receiver.
		/// </summary>
		public IPAddress DestinationAddress { get; private set; }
		/// <summary>
		/// IP address of the sender.
		/// </summary>
		public byte[] SourceAddressBytes { get { return this.srcAddress; } }
		/// <summary>
		/// IP address of the intended receiver.
		/// </summary>
		public byte[] DestinationAddressBytes { get { return this.dstAddress; } }
		/// <summary>
		/// The IP options.
		/// </summary>
		public ProtoPacketIpOption[] Options { get; private set; }

		#endregion

		#region Static properties

		/// <summary>
		/// Indicates whether the protocol ignores the checksum calculation.
		/// </summary>
		public static bool IgnoreChecksum { get; set; }

		#endregion

		#region Public methods

		/// <summary>
		/// Gets the packet information as a string.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("IPv4 HEADER Src: {0} Dst: {1} Length: {2} Identifier: 0x{3:X4} TTL: {4} Protocol: {5} Checksum: 0x{6:X4} ({7})",
				this.SourceAddress,
				this.DestinationAddress,
				this.HeaderLength,
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
			// Validate the buffer.
			if (index + this.Length > buffer.Length) throw new IndexOutOfRangeException("The buffer is too small.");

			int idx = index;

			// Write the version (7..4) and header length (3..0)
			buffer[idx++] = (byte)(((ProtoPacketIpHeader.version & 0xF) << 4) | (this.headerLength & 0xF));
			// Write the DSCP (7..2) and ECN (1..0)
			buffer[idx++] = this.DifferentiatedServices;
			// Write the packet length.
			buffer[idx++] = (byte)(this.Length >> 8);
			buffer[idx++] = (byte)(this.Length & 0xFF);
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
			ushort checksum = ProtoPacket.ChecksumOneComplement16Bit(buffer, index, this.HeaderLength);
			buffer[index + 10] = (byte)((checksum >> 8) & 0xFF);
			buffer[index + 11] = (byte)(checksum & 0xFF);

			return index + this.HeaderLength;
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
		public static ProtoPacketIpHeader Parse(byte[] buffer, ref int index, int length)
		{
			// Create the packet.
			return new ProtoPacketIpHeader(buffer, ref index, length, false);
		}

		#endregion
	}
}
