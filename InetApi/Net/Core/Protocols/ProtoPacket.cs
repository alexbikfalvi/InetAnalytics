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
	/// The base class for a protocol packet.
	/// </summary>
	public abstract class ProtoPacket
	{
		#region Public properties

		/// <summary>
		/// Gets the packet length in bytes.
		/// </summary>
		public abstract ushort Length { get; }

		#endregion

		#region Public methods

		/// <summary>
		/// Writes the current packet to the buffer at the specified index.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <param name="index">The index.</param>
		/// <param name="args">Protocol specific arguments.</param>
		/// <returns>The new index, after the packet has been written.</returns>
		public abstract int Write(byte[] buffer, int index, params object[] args);

		#endregion

		#region Static methods

		/// <summary>
		/// Computes the one's complement 16 bit checksum.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <param name="start">The start index.</param>
		/// <param name="length">The length.</param>
		/// <returns>The checksum.</returns>
		public static ushort ChecksumOneComplement16Bit(byte[] buffer, int start, int length)
		{
			int checksum = 0;
			for (int index = start, len = start + length - 1; index < start + length; index += 2)
			{
				checksum += (buffer[index] << 8) | (index < len ? buffer[index + 1] : 0);
			}
			return (ushort)~(((checksum >> 16) + (checksum & 0xFFFF)) & 0xFFFF);
		}

		/// <summary>
		/// Computes the one's complement 16 bit checksum.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <param name="start">The start index.</param>
		/// <param name="length">The length.</param>
		/// <param name="data">Data to include in the checksum.</param>
		/// <returns>The checksum.</returns>
		public static ushort ChecksumOneComplement16Bit(byte[] buffer, int start, int length, params ushort[] data)
		{
			int checksum = 0;
			for (int index = start, len = start + length - 1; index < start + length; index += 2)
			{
				checksum += (buffer[index] << 8) | (index < len ? buffer[index + 1] : 0);
			}
			foreach (ushort word in data)
			{
				checksum += word;
			}
			return (ushort)~(((checksum >> 16) + (checksum & 0xFFFF)) & 0xFFFF);
		}

		#endregion
	}
}
