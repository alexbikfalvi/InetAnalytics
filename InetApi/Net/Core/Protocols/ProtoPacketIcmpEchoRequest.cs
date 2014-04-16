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
	/// A class representing an ICMP version 4 packet of echo request type.
	/// </summary>
	public sealed class ProtoPacketIcmpEchoRequest : ProtoPacketIcmp
	{
		private readonly ushort length;

		/// <summary>
		/// Creates a new ICMP echo request packet.
		/// </summary>
		/// <param name="identifier">The identifier.</param>
		/// <param name="sequence">The sequence number.</param>
		/// <param name="data">The data.</param>
		public ProtoPacketIcmpEchoRequest(ushort identifier, ushort sequence, byte[] data)
			: base(IcmpType.EchoRequest)
		{
			// Validate the data.
			if (null == data) throw new ArgumentNullException("data");
			if (data.Length > 65492) throw new ArgumentException("The maximum data size of an ICMP packet is 65492 bytes.");

			this.Identifier = identifier;
			this.Sequence = sequence;
			this.Data = data;

			this.length = (ushort)(8 + data.Length);
		}

		#region Public properties

		/// <summary>
		/// Gets the packet length in bytes.
		/// </summary>
		public override ushort Length { get { return this.length; } }
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
		public byte[] Data { get; private set; }

		#endregion

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
			for (int idxData = 0; idxData < this.Data.Length;)
			{
				buffer[idx++] = this.Data[idxData++];
			}

			// Compute the checksum.
			int checksum = 0;
			for (int idxSum = index, len = index + this.length - 1; idxSum < index + this.length; idxSum += 2)
			{
				checksum += (buffer[idxSum] << 8) | (idxSum < len ? buffer[idxSum + 1] : 0);
			}
			checksum = ~(((checksum >> 16) + (checksum & 0xFFFF)) & 0xFFFF);
			buffer[index + 2] = (byte)((checksum >> 8) & 0xFF);
			buffer[index + 3] = (byte)(checksum & 0xFF);

			// Return the new index.
			return idx;
		}
	}
}
