/* 
 * Copyright (C) 2013 Alex Bikfalvi
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
using System.Net.NetworkInformation;

namespace InetApi.Net.Core
{
	/// <summary>
	/// A class representing a network interface extension.
	/// </summary>
	public class NetworkInterfaceEx
	{
		private readonly NetworkInterface iface;

		/// <summary>
		/// Creates a new extended network interface instance.
		/// </summary>
		/// <param name="iface">The network interface.</param>
		public NetworkInterfaceEx(NetworkInterface iface)
		{
			this.iface = iface;
		}

		// Public properties.

		/// <summary>
		/// Gets the network interface identifier.
		/// </summary>
		public string Id { get { return this.iface.Id; } }

		// Public methods.

		/// <summary>
		/// Converts to extended network interface to a string.
		/// </summary>
		/// <returns>The string.</returns>
		public override string ToString()
		{
			return this.iface.Name;
		}
	}
}
