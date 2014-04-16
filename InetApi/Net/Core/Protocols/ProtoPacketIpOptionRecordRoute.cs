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
	/// A class representing an IP version 4 record-route option.
	/// </summary>
	public sealed class ProtoPacketIpOptionRecordRoute : ProtoPacketIpOption
	{
		private byte length;

		/// <summary>
		/// Creates a new IP version 4 traceroute option instance.
		/// </summary>
		/// <param name="size">The size of the option route table.</param>
		public ProtoPacketIpOptionRecordRoute(byte size)
			: base(OptionType.RecordRoute)
		{
			// Validate the arguments.
			if (size > 9) throw new ArgumentException("The maximum size is 9.");

			this.length = (byte)(3 + (size << 2));
			this.Size = size;
			this.Pointer = 4;
		}

		#region Public properties

		/// <summary>
		/// The packet length.
		/// </summary>
		public override ushort Length { get { return this.length; } }
		/// <summary>
		/// The pointer into the route data indicates the byte which begins the next area to store a route address. The pointer is relative to this option.
		/// </summary>
		public byte Pointer { get; private set; }
		/// <summary>
		/// The size of the route record.
		/// </summary>
		public byte Size { get; private set; }

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

			// Write the type.
			buffer[index++] = (byte)this.Type;
			// Write the length.
			buffer[index++] = this.length;
			// Write the pointer.
			buffer[index++] = this.Pointer;
			// Zero the remaining bytes.
			for (int idx = 0; idx < this.Size << 2; idx++)
			{
				buffer[index++] = 0;
			}

			// Return the new index.
			return index;
		}

		#endregion
	}
}
