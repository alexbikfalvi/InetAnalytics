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
			this.Stale = false;
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

		#region Internal properties

		/// <summary>
		/// Gets or sets whether the information for this record is stale.
		/// </summary>
		internal bool Stale { get; set; }

		#endregion

		#region Public methods

		/// <summary>
		/// Compares two unicast network address information objects for equality.
		/// </summary>
		/// <param name="left">The left unicast network address information.</param>
		/// <param name="right">The right unicast network address information.</param>
		/// <returns><b>True</b> if the two unicast network address information are equal, <b>false</b> otherwise.</returns>
		public static bool operator ==(UnicastNetworkAddressInformation left, UnicastNetworkAddressInformation right)
		{
			return left.Equals(right);
		}

		/// <summary>
		/// Compares two unicast network address information objects for inequality.
		/// </summary>
		/// <param name="left">The left unicast network address information.</param>
		/// <param name="right">The right unicast network address information.</param>
		/// <returns><b>True</b> if the two unicast network address information are different, <b>false</b> otherwise.</returns>
		public static bool operator !=(UnicastNetworkAddressInformation left, UnicastNetworkAddressInformation right)
		{
			return !(left.Equals(right));
		}

		/// <summary>
		/// Compares two objects for equality.
		/// </summary>
		/// <param name="obj">The object to compare.</param>
		/// <returns><b>True</b> if the two objects are equal, <b>false</b> otherwise.</returns>
		public override bool Equals(object obj)
		{
			if (null == obj) return false;
			if (!(obj is UnicastNetworkAddressInformation)) return false;
			UnicastNetworkAddressInformation info = obj as UnicastNetworkAddressInformation;
			return (this.Interface == info.Interface) && (this.UnicastInformation == info.UnicastInformation);
		}

		/// <summary>
		/// Gets the hash code for the current object.
		/// </summary>
		/// <returns>The hash code.</returns>
		public override int GetHashCode()
		{
			return this.Interface.GetHashCode() ^ this.Information.Address.GetHashCode();
		}

		#endregion
	}
}
