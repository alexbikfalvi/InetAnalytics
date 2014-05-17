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
using System.ComponentModel;

namespace InetApi.Net.Core.Protocols
{
	/// <summary>
	/// The base class for an IP version 4 option.
	/// </summary>
	[Serializable]
	public abstract class ProtoPacketIpOption : ProtoPacket
	{
		public enum OptionType
		{
			/// <summary>
			/// End of options list (RFC 791)
			/// </summary>
			[Description("End of options list")]
			EndOfOptions = 0,
			/// <summary>
			/// NOP (RFC 791)
			/// </summary>
			[Description("NOP")]
			Nop = 1,
			/// <summary>
			/// Security (RFC 791, RFC 1108)
			/// </summary>
			[Description("Security")]
			Security = 130,
			/// <summary>
			/// Loose Source Route (RFC 791)
			/// </summary>
			[Description("Loose Source Route")]
			LooseSourceRoute = 131,
			/// <summary>
			/// Timestamp (RFC 781, RFC 791)
			/// </summary>
			[Description("Timestamp")]
			Timestamp = 68,
			/// <summary>
			/// Extended Security (RFC 1108)
			/// </summary>
			[Description("Extended Security")]
			ExtendedSecurity = 133,
			/// <summary>
			/// Commercial Security
			/// </summary>
			[Description("Commercial Security")]
			CommercialSecurity = 134,
			/// <summary>
			/// Record Route (RFC 791)
			/// </summary>
			[Description("Record Route")]
			RecordRoute = 7,
			/// <summary>
			/// Stream Identifier (RFC 791, RFC 1122)
			/// </summary>
			[Description("Stream Identifier")]
			StreamIdentifier = 136,
			/// <summary>
			/// Strict Source Route (RFC 791)
			/// </summary>
			[Description("Strict Source Route")]
			StrictSourceRoute = 137,
			/// <summary>
			/// Experimental Measurement
			/// </summary>
			[Description("Experimental Measurement")]
			ExperimentalMeasurement = 10,
			/// <summary>
			/// MTU Probe (RFC 1063)
			/// </summary>
			[Obsolete]
			[Description("MTU Probe")]
			MtuProbe = 11,
			/// <summary>
			/// MTU Reply (RFC 1063)
			/// </summary>
			[Obsolete]
			[Description("MTU Reply")]
			MtuReply = 12,
			/// <summary>
			/// Experimental Flow Control
			/// </summary>
			[Description("Experimental Flow Control")]
			ExperimentalFlowControl = 205,
			/// <summary>
			/// Experimental Access Control
			/// </summary>
			[Description("Experimental Access Control")]
			ExperimentalAccessControl = 142,
			/// <summary>
			/// ENCODE
			/// </summary>
			[Description("ENCODE")]
			Encode = 15,
			/// <summary>
			/// IMI Traffic Descriptor
			/// </summary>
			[Description("IMI Traffic Descriptor")]
			ImiTrafficDescriptor = 144,
			/// <summary>
			/// Extended Internet Protocol (RFC 1385)
			/// </summary>
			[Description("Extended Internet Protocol")]
			ExtendedInternetProtocol = 145,
			/// <summary>
			/// Traceroute (RFC 1393)
			/// </summary>
			[Description("Traceroute")]
			Traceroute = 82,
			/// <summary>
			/// Address Extension (RFC 1475)
			/// </summary>
			[Description("Address Extension")]
			AddressExtension = 147,
			/// <summary>
			/// Router Alert (RFC 2113)
			/// </summary>
			[Description("Router Alert")]
			RouterAlert = 148,
			/// <summary>
			/// Selective Directed Broadcast Mode (RFC 1770)
			/// </summary>
			[Description("Selective Directed Broadcast Mode")]
			SelectiveDirectedBroadcastMode = 149,
			/// <summary>
			/// Dynamic Packet State
			/// </summary>
			[Description("Dynamic Packet State")]
			DynamicPacketState = 150,
			/// <summary>
			/// Upstream Multicast Packet
			/// </summary>
			[Description("Upstream Multicast Packet")]
			UpstreamMulticastPacket = 151,
			/// <summary>
			/// Quick-Start (RFC 4782)
			/// </summary>
			[Description("Quick Start")]
			QuickStart = 25
		}

		/// <summary>
		/// Creates an IP version 4 header option of the specified type.
		/// </summary>
		/// <param name="type"></param>
		protected ProtoPacketIpOption(OptionType type)
		{
			this.Type = type;
		}

		#region Public properties

		/// <summary>
		/// Gets the option type.
		/// </summary>
		public OptionType Type { get; private set; }

		#endregion

		#region Static methods

		/// <summary>
		/// Parses an IP option from the specified buffer at the given index.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <param name="index">The index.</param>
		/// <param name="length">The length.</param>
		/// <returns>The packet.</returns>
		public static ProtoPacketIpOption Parse(byte[] buffer, ref int index, int length)
		{
			// Get the option type.
			switch ((OptionType)buffer[index])
			{
				case OptionType.EndOfOptions: index++; return null;
				case OptionType.RecordRoute: return ProtoPacketIpOptionRecordRoute.Parse(buffer, ref index, length);
				default: throw new ProtoException("Unknown IP option type.");
			}
		}

		#endregion
	}
}
