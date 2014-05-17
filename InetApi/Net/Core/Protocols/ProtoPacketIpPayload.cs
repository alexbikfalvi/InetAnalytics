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
	/// A class representing an IP payload packet.
	/// </summary>
	[Serializable]
	public abstract class ProtoPacketIpPayload : ProtoPacket
	{
		/// <summary>
		/// Creates a new payload packet instance.
		/// </summary>
		/// <param name="protocol">The protocol.</param>
		public ProtoPacketIpPayload(ProtoPacketIp.Protocols protocol)
		{
			this.Protocol = protocol;
		}

		#region Public properties

		/// <summary>
		/// The protocol number.
		/// </summary>
		public ProtoPacketIp.Protocols Protocol { get; private set; }

		#endregion
	}
}
