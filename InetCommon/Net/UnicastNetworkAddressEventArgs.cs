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

namespace InetCommon.Net
{
	/// <summary>
	/// A delegate for event raised when a local network address has changed.
	/// </summary>
	/// <param name="sender">The sender object.</param>
	/// <param name="e">The event arguments.</param>
	public delegate void UnicastNetworkAddressEventHandler(object sender, UnicastNetworkAddressEventArgs e);

	/// <summary>
	/// A class representing the event arguments for the change of a local unicast network address.
	/// </summary>
	public class UnicastNetworkAddressEventArgs : NetworkAddressEventArgs
	{
		/// <summary>
		/// Creates a new network address event arguments instance.
		/// </summary>
		/// <param name="information">The address information.</param>
		public UnicastNetworkAddressEventArgs(UnicastNetworkAddressInformation information)
		{
			this.Information = information;
		}

		#region Public properties

		/// <summary>
		/// Gets the unicast network address information.
		/// </summary>
		public UnicastNetworkAddressInformation Information { get; private set; }

		#endregion
	}
}
