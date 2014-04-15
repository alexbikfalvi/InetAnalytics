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
			Security = 2,
			/// <summary>
			/// Loose Source Route (RFC 791)
			/// </summary>
			[Description("Loose Source Route")]
			LooseSourceRoute = 3,
			/// <summary>
			/// Timestamp (RFC 781, RFC 791)
			/// </summary>
			[Description("Timestamp")]
			Timestamp = 4,
			/// <summary>
			/// Extended Security (RFC 1108)
			/// </summary>
			[Description("Extended Security")]
			ExtendedSecurity = 5,
			/// <summary>
			/// Commercial Security
			/// </summary>
			[Description("Commercial Security")]
			CommercialSecurity = 6,
			/// <summary>
			/// Record Route (RFC 791)
			/// </summary>
			[Description("Record Route")]
			RecordRoute = 7,
			/// <summary>
			/// Stream Identifier (RFC 791, RFC 1122)
			/// </summary>
			[Description("Stream Identifier")]
			StreamIdentifier = 8,
			/// <summary>
			/// Strict Source Route (RFC 791)
			/// </summary>
			[Description("Strict Source Route")]
			StrictSourceRoute = 9,
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
			ExperimentalFlowControl = 13,
			/// <summary>
			/// Experimental Access Control
			/// </summary>
			[Description("Experimental Access Control")]
			ExperimentalAccessControl = 14,
			/// <summary>
			/// ENCODE
			/// </summary>
			[Description("ENCODE")]
			Encode = 15,
			/// <summary>
			/// IMI Traffic Descriptor
			/// </summary>
			[Description("IMI Traffic Descriptor")]
			ImiTrafficDescriptor = 16,
			/// <summary>
			/// Extended Internet Protocol (RFC 1385)
			/// </summary>
			[Description("Extended Internet Protocol")]
			ExtendedInternetProtocol = 17,
			/// <summary>
			/// Traceroute (RFC 1393)
			/// </summary>
			[Description("Traceroute")]
			Traceroute = 18,
			/// <summary>
			/// Address Extension (RFC 1475)
			/// </summary>
			[Description("Address Extension")]
			AddressExtension = 19,
			/// <summary>
			/// Router Alert (RFC 2113)
			/// </summary>
			[Description("Router Alert")]
			RouterAlert = 20,
			/// <summary>
			/// Selective Directed Broadcast Mode (RFC 1770)
			/// </summary>
			[Description("Selective Directed Broadcast Mode")]
			SelectiveDirectedBroadcastMode = 21,
			/// <summary>
			/// Dynamic Packet State
			/// </summary>
			[Description("Dynamic Packet State")]
			DynamicPacketState = 23,
			/// <summary>
			/// Upstream Multicast Packet
			/// </summary>
			[Description("Upstream Multicast Packet")]
			UpstreamMulticastPacket = 24,
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
	}
}
