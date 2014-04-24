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
	/// A class representing a UDP packet.
	/// </summary>
	public sealed class ProtoPacketUdp : ProtoPacketIpPayload
	{
		/// <summary>
		/// Private constructor.
		/// </summary>
		/// <param name="buffer">The buffer from which to read the packet.</param>
		/// <param name="index">The buffer index.</param>
		/// <param name="length">The length.</param>
		/// <param name="args">Protocol specific arguments.</param>
		private ProtoPacketUdp(byte[] buffer, ref int index, int length, params object[] args)
			: base(ProtoPacketIp.Protocols.Udp)
		{
			int idx = index;

			// Set the source port.
			this.SourcePort = (ushort)((buffer[idx++] << 8) | buffer[idx++]);
			// Set the destination port.
			this.DestinationPort = (ushort)((buffer[idx++] << 8) | buffer[idx++]);
			
			// Validate the length.
			ushort udpLength = (ushort)((buffer[idx++] << 8) | buffer[idx++]);
			if (udpLength != length - index)
				throw new ProtoException("Invalid UDP length.");
			// Validate the checksum.
			ushort checksum = (ushort)((buffer[idx++] << 8) | buffer[idx++]);
			// If checksumming is not disabled.
			if (checksum != 0)
			{
				if (args[0] is ProtoPacketIp)
				{
					// If the higher lower layer protocol is IPv4.
					ProtoPacketIp ip = args[0] as ProtoPacketIp;
					// Compute the checksum using the IPv4 pseudo-header.
					checksum = ProtoPacket.ChecksumOneComplement16Bit(buffer, index, udpLength,
						(ushort)((ip.SourceAddressBytes[0] << 8) | ip.SourceAddressBytes[1]),
						(ushort)((ip.SourceAddressBytes[2] << 8) | ip.SourceAddressBytes[3]),
						(ushort)((ip.DestinationAddressBytes[0] << 8) | ip.DestinationAddressBytes[1]),
						(ushort)((ip.DestinationAddressBytes[2] << 8) | ip.DestinationAddressBytes[3]),
						ip.Protocol,
						udpLength);
				}
			}
			if (0 != checksum)
				throw new ProtoException("Invalid UDP checksum.");

			// Write the data.
			if (idx < length)
			{
				this.Data = new byte[length - idx];
				Array.Copy(buffer, idx, this.Data, 0, this.Data.Length);
				idx += this.Data.Length;
			}

			// Set the index.
			index = idx;
		}

		/// <summary>
		/// Creates a new UDP packet instance.
		/// </summary>
		/// <param name="sourcePort">The source port.</param>
		/// <param name="destinationPort">The destination port.</param>
		/// <param name="data">The data.</param>
		public ProtoPacketUdp(ushort sourcePort, ushort destinationPort, byte[] data)
			: base(ProtoPacketIp.Protocols.Udp)
		{
			this.SourcePort = sourcePort;
			this.DestinationPort = destinationPort;
			this.Data = data;
		}

		#region Public properties

		/// <summary>
		/// Gets the packet length in bytes.
		/// </summary>
		public override ushort Length { get { return (ushort)(8 + (this.Data != null ? this.Data.Length : 0)); } }
		/// <summary>
		/// The port number of the sender. Cleared to zero if not used.
		/// </summary>
		public ushort SourcePort { get; set; }
		/// <summary>
		/// The port this packet is addressed to.
		/// </summary>
		public ushort DestinationPort { get; set; }
		/// <summary>
		/// The data.
		/// </summary>
		public byte[] Data { get; set; }

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
			if (index + this.Length > buffer.Length) throw new IndexOutOfRangeException("The buffer is too small.");

			// Validate the arguments.
			if (null == args) throw new ArgumentNullException("args");
			if (args.Length <= 0) throw new ArgumentException("The UDP protocol requires an lower-layer protocol argument (IPv4 or IPv6).");

			int idx = index;

			// Write the source port.
			buffer[idx++] = (byte)(this.SourcePort >> 8);
			buffer[idx++] = (byte)(this.SourcePort & 0xFF);
			// Write the destination port.
			buffer[idx++] = (byte)(this.DestinationPort >> 8);
			buffer[idx++] = (byte)(this.DestinationPort & 0xFF);
			// Write the length.
			buffer[idx++] = (byte)(this.Length >> 8);
			buffer[idx++] = (byte)(this.Length & 0xFF);
			// Write the checksum.
			buffer[idx++] = 0;
			buffer[idx++] = 0;
			// Write the data.
			if (null != this.Data)
			{
				Array.Copy(this.Data, 0, buffer, idx, this.Data.Length);
				idx += this.Data.Length;
			}

			if (args[0] is ProtoPacketIp)
			{
				// If the higher lower layer protocol is IPv4.
				ProtoPacketIp ip = args[0] as ProtoPacketIp;
				// Compute the checksum using the IPv4 pseudo-header.
				ushort checksum = ProtoPacket.ChecksumOneComplement16Bit(buffer, index, this.Length,
					(ushort)((ip.SourceAddressBytes[0] << 8) | ip.SourceAddressBytes[1]),
					(ushort)((ip.SourceAddressBytes[2] << 8) | ip.SourceAddressBytes[3]),
					(ushort)((ip.DestinationAddressBytes[0] << 8) | ip.DestinationAddressBytes[1]),
					(ushort)((ip.DestinationAddressBytes[2] << 8) | ip.DestinationAddressBytes[3]),
					ip.Protocol,
					this.Length);
				checksum = checksum == 0 ? (ushort)0xFFFF : checksum;
				buffer[index + 6] = (byte)((checksum >> 8) & 0xFF);
				buffer[index + 7] = (byte)(checksum & 0xFF);
			}

			return index;
		}

		#endregion

		#region Static methods

		/// <summary>
		/// Parses an UDP packet from the specified buffer at the given index.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <param name="index">The index.</param>
		/// <param name="length">The length.</param>
		/// <param name="args">Protocol specific arguments.</param>
		/// <returns>The packet.</returns>
		public static ProtoPacketUdp Parse(byte[] buffer, ref int index, int length, params object[] args)
		{
			return new ProtoPacketUdp(buffer, ref index, length, args);
		}

		#endregion
	}
}
