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
using System.Net.NetworkInformation;

namespace InetCommon.Net
{
	/// <summary>
	/// A class representing the information for a unicast network address.
	/// </summary>
	public sealed class UnicastNetworkAddressInformation : NetworkAddressInformation
	{
		/// <summary>
		/// Creates a new unicast network address information instance.
		/// </summary>
		/// <param name="iface">The network interface.</param>
		/// <param name="information">The address information.</param>
		public UnicastNetworkAddressInformation(NetworkInterface iface, UnicastIPAddressInformation information)
			: base(iface)
		{
			this.UnicastInformation = information;
		}

		#region Public properties

		/// <summary>
		/// Gets the address information.
		/// </summary>
		public override IPAddressInformation Information { get { return this.UnicastInformation; } }
		/// <summary>
		/// Gets the information for the unicast IP address.
		/// </summary>
		public UnicastIPAddressInformation UnicastInformation { get; private set; }

		#endregion
	}
}
