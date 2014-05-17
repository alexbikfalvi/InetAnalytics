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
	/// A class representing an ICMP version 4 packet of echo reply type.
	/// </summary>
	[Serializable]
	public sealed class ProtoPacketIcmpEchoReply : ProtoPacketIcmp
	{
		/// <summary>
		/// Private constructor.
		/// </summary>
		/// <param name="buffer">The buffer from which to read the packet.</param>
		/// <param name="index">The buffer index.</param>
		/// <param name="length">The data length.</param>
		/// <param name="args">Protocol specific arguments.</param>
		private ProtoPacketIcmpEchoReply(byte[] buffer, ref int index, int length)
			: base(IcmpType.EchoReply)
		{
			int idx = index;

			// Validate the type.
			if (buffer[idx++] != this.Type) throw new ProtoException("Invalid ICMP echo reply type.");
			// Validate the code.
			if (buffer[idx++] != this.Code) throw new ProtoException("Invalid ICMP echo reply code.");

			// Set the checksum.
			this.Checksum = (ushort)((buffer[idx++] << 8) | buffer[idx++]);
			// Set whether the checksum is valid.
			this.IsChecksumValid = ProtoPacket.ChecksumOneComplement16Bit(buffer, index, length - index) == 0;

			// Validate the checksum.
			if (!ProtoPacketIcmp.IgnoreChecksum && !this.IsChecksumValid)
				throw new ProtoException("Invalid ICMP checksum.");

			// Set the identifier.
			this.Identifier = (ushort)((buffer[idx++] << 8) | buffer[idx++]);
			// Set the sequence.
			this.Sequence = (ushort)((buffer[idx++] << 8) | buffer[idx++]);

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
		/// Creates a new ICMP echo reply packet.
		/// </summary>
		/// <param name="identifier">The identifier.</param>
		/// <param name="sequence">The sequence number.</param>
		/// <param name="data">The data.</param>
		public ProtoPacketIcmpEchoReply(ushort identifier, ushort sequence, byte[] data)
			: base(IcmpType.EchoReply)
		{
			// Validate the data.
			if (null == data) throw new ArgumentNullException("data");
			if (data.Length > 65492) throw new ArgumentException("The maximum data size of an ICMP packet is 65492 bytes.");

			this.Identifier = identifier;
			this.Sequence = sequence;
			this.Data = data;
		}

		#region Public properties

		/// <summary>
		/// Gets the packet length in bytes.
		/// </summary>
		public override ushort Length { get { return (ushort)(8 + (null != this.Data ? this.Data.Length : 0)); } }
		/// <summary>
		/// Cleared to 0.
		/// </summary>
		public override byte Code { get { return 0; } }
		/// <summary>
		/// This field is used to help match echo requests to the associated reply.
		/// </summary>
		public ushort Identifier { get; set; }
		/// <summary>
		/// This field is used to help match echo requests to the associated reply.
		/// </summary>
		public ushort Sequence { get; set; }
		/// <summary>
		/// Implementation specific data.
		/// </summary>
		public byte[] Data { get; set; }

		#endregion

		#region Public methods

		/// <summary>
		/// Gets the packet information as a string.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("ICMP ECHO-REPLY Length: {0} Type: {1} Code: {2} Checksum: {3:X4} ({4}) Identifier: 0x{5:X4} Sequence: 0x{6:X4} Data: {7}",
				this.Length,
				this.Type,
				this.Code,
				this.Checksum,
				this.IsChecksumValid ? "ok" : "fail",
				this.Identifier,
				this.Sequence,
				this.Data.Length);
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
			// Write the identifier.
			buffer[idx++] = (byte)(this.Identifier >> 8);
			buffer[idx++] = (byte)(this.Identifier & 0xFF);
			// Write the sequence.
			buffer[idx++] = (byte)(this.Sequence >> 8);
			buffer[idx++] = (byte)(this.Sequence & 0xFF);

			// Write the data.
			if (null != this.Data)
			{
				Array.Copy(this.Data, 0, buffer, idx, this.Data.Length);
				idx += this.Data.Length;
			}

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
		/// Parses an ICMP echo reply packet from the specified buffer at the given index.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <param name="index">The index.</param>
		/// <param name="length">The length.</param>
		/// <returns>The packet.</returns>
		public new static ProtoPacketIcmpEchoReply Parse(byte[] buffer, ref int index, int length)
		{
			return new ProtoPacketIcmpEchoReply(buffer, ref index, length);
		}

		#endregion
	}
}
