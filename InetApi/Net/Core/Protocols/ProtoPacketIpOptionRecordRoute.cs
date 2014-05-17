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
	[Serializable]
	public sealed class ProtoPacketIpOptionRecordRoute : ProtoPacketIpOption
	{
		public const byte maxSize = 9;

		/// <summary>
		/// Private constructor.
		/// </summary>
		/// <param name="buffer">The buffer from which to read the packet.</param>
		/// <param name="index">The buffer index.</param>
		/// <param name="length">The length.</param>
		private ProtoPacketIpOptionRecordRoute(byte[] buffer, ref int index, int length)
			: base(OptionType.RecordRoute)
		{
			int idx = index;

			// Validate the type.
			if (buffer[idx++] != (byte)this.Type) throw new ProtoException("Invalid Record Route option type.");
			// Get the length.
			byte optionLength = buffer[idx++];
			// Get the pointer.
			this.Pointer = buffer[idx++];
			// Get the route data.
			this.RouteData = new IPAddress[(optionLength - 3) >> 2];
			for (int counter = 0; counter < this.RouteData.Length; counter++)
			{
				this.RouteData[counter] = new IPAddress(new byte[] {
					buffer[idx++],
					buffer[idx++],
					buffer[idx++],
					buffer[idx++]
				});
			}

			// Validate the option length.
			if (optionLength != this.OptionLength) throw new ProtoException("Invalid Record Route option length.");
			
			// Set the index.
			index += optionLength;
		}

		/// <summary>
		/// Creates a new IP version 4 traceroute option instance.
		/// </summary>
		/// <param name="size">The size of the option route table.</param>
		public ProtoPacketIpOptionRecordRoute(byte size)
			: base(OptionType.RecordRoute)
		{
			// Validate the arguments.
			if (size > 9) throw new ArgumentException("The maximum size is 9.");

			this.RouteData = new IPAddress[size];
			this.Pointer = 4;
		}

		#region Public properties

		/// <summary>
		/// The packet length.
		/// </summary>
		public override ushort Length { get { return (byte)(3 + (this.RouteData.Length << 2)); } }
		/// <summary>
		/// Total length of the option in bytes.
		/// </summary>
		public byte OptionLength { get { return (byte)(this.Length & 0xFF); } }
		/// <summary>
		/// The pointer into the route data indicates the byte which begins the next area to store a route address. The pointer is relative to this option.
		/// </summary>
		public byte Pointer { get; private set; }
		/// <summary>
		/// A recorded route is composed of a series of internet addresses.
		/// </summary>
		public IPAddress[] RouteData { get; private set; }

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

			// Write the type.
			buffer[index++] = (byte)this.Type;
			// Write the length.
			buffer[index++] = this.OptionLength;
			// Write the pointer.
			buffer[index++] = this.Pointer;
			// Zero the remaining bytes.
			for (int idx = 0; idx < this.RouteData.Length; idx++)
			{
				if (this.RouteData[idx] != null)
				{
					byte[] address = this.RouteData[idx].GetAddressBytes();
					buffer[index++] = address[0];
					buffer[index++] = address[1];
					buffer[index++] = address[2];
					buffer[index++] = address[3];
				}
				else
				{
					buffer[index++] = 0;
					buffer[index++] = 0;
					buffer[index++] = 0;
					buffer[index++] = 0;
				}
			}

			// Return the new index.
			return index;
		}

		#endregion

		#region Static methods

		/// <summary>
		/// Parses a record-route header from the specified buffer at the given index.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <param name="index">The index.</param>
		/// <param name="length">The length.</param>
		/// <returns>The packet.</returns>
		public new static ProtoPacketIpOptionRecordRoute Parse(byte[] buffer, ref int index, int length)
		{
			return new ProtoPacketIpOptionRecordRoute(buffer, ref index, length);
		}

		#endregion
	}
}
