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
using System.Net.NetworkInformation;

namespace InetCommon.Net
{
	/// <summary>
	/// A class representing a network unicast local address.
	/// </summary>
	public class NetworkLocalIPAddress : NetworkLocalAddress
	{
		/// <summary>
		/// Protected constructor.
		/// </summary>
		/// <param name="address">The IP address.</param>
		/// <param name="iface">The local interface.</param>
		/// <param name="ipProperties">The IP properties.</param>
		protected NetworkLocalIPAddress(IPAddress address, NetworkInterface iface, IPInterfaceProperties ipProperties)
			: base(address, iface)
		{
			this.IPProperties = ipProperties;
		}

		#region

		/// <summary>
		/// Gets the IP properties for this interface.
		/// </summary>
		public IPInterfaceProperties IPProperties { get; private set; }

		#endregion
	}
}
