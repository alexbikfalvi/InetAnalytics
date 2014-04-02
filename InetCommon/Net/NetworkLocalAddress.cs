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
	/// A class representing a network local address.
	/// </summary>
	public class NetworkLocalAddress
	{
		/// <summary>
		/// Protected constructor.
		/// </summary>
		/// <param name="address">The IP address.</param>
		/// <param name="iface">The interface.</param>
		protected NetworkLocalAddress(IPAddress address, NetworkInterface iface)
		{
			this.Address = address;
			this.Interface = iface;
		}

		#region Public properties

		/// <summary>
		/// Gets the IP address.
		/// </summary>
		public IPAddress Address { get; private set; }
		/// <summary>
		/// Gets the network interface corresponding to this address.
		/// </summary>
		public NetworkInterface Interface { get; private set; }

		#endregion
	}
}
