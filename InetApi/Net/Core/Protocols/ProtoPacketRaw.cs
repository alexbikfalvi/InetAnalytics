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
	/// A class representing a raw protocol.
	/// </summary>
	[Serializable]
	public sealed class ProtoPacketRaw : ProtoPacketIpPayload
	{
		/// <summary>
		/// Private constructor.
		/// </summary>
		/// <param name="buffer">The buffer from which to read the packet.</param>
		/// <param name="index">The buffer index.</param>
		/// <param name="length">The length.</param>
		private ProtoPacketRaw(byte[] buffer, ref int index, int length)
			: base(ProtoPacketIp.Protocols.Reserved)
		{
			this.Data = new byte[length - index];
			Array.Copy(buffer, index, this.Data, 0, this.Data.Length);
			index += this.Data.Length;
		}

		/// <summary>
		/// Creates a new raw data packet from the specified data.
		/// </summary>
		/// <param name="data">The data.</param>
		public ProtoPacketRaw(byte[] data)
			: base(ProtoPacketIp.Protocols.Reserved)
		{
			this.Data = data;
		}

		#region Public properties

		/// <summary>
		/// Gets the packet length in bytes.
		/// </summary>
		public override ushort Length { get { return (ushort)this.Data.Length; } }
		/// <summary>
		/// The protocol data.
		/// </summary>
		public byte[] Data { get; private set; }

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

			// Write the data.
			Array.Copy(this.Data, 0, buffer, index, this.Length);

			// Return the new index.
			return index + this.Length;
		}

		#endregion

		#region Static methods

		/// <summary>
		/// Parses a raw packet from the specified buffer at the given index.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <param name="index">The index.</param>
		/// <param name="length">The length.</param>
		/// <returns>The packet.</returns>
		public static ProtoPacketRaw Parse(byte[] buffer, ref int index, int length)
		{
			// Create the packet.
			return new ProtoPacketRaw(buffer, ref index, length);
		}

		#endregion
	}
}
