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
	/// A class representing an ICMP version 4 packet.
	/// </summary>
	public abstract class ProtoPacketIcmp : ProtoPacket
	{
		/// <summary>
		/// An enumeration representing the ICMP packet type.
		/// </summary>
		public enum Type
		{
			EchoReply = 0,
			DestinationUnreachable = 3,
			SourceQuench = 4,
			Redirect = 5,
			EchoRequest = 8,
			RouterAdvertisement = 9,
			RouterSolicitation = 10,
			TimeExceeded = 11,
			ParameterProblem = 12,
			TimestampRequest = 13,
			TimestampReply = 14,
			[Obsolete]
			InformationRequest = 15,
			[Obsolete]
			InformationReply = 16,
			AddressMaskRequest = 17,
			AddressMaskReply = 18,
			Traceroute = 30
		}

		private readonly Type type;

		/// <summary>
		/// Creates an ICMP packet of the specified type.
		/// </summary>
		/// <param name="type">The packet type.</param>
		protected ProtoPacketIcmp(Type type)
		{
			this.type = type;
		}

		#region Public properties

		/// <summary>
		/// Gets the ICMP packet type.
		/// </summary>
		//public Type Type { get { return this.type; } }

		#endregion
	}
}
