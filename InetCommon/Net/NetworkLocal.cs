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
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;

namespace InetCommon.Net
{
	/// <summary>
	/// A class with information about the local network.
	/// </summary>
	public static class NetworkLocal
	{
		/// <summary>
		/// Static constructor.
		/// </summary>
		static NetworkLocal()
		{
			// Set the event handlers.
			NetworkChange.NetworkAddressChanged += NetworkLocal.OnNetworkAddressChanged;
		}

		#region Public events

		/// <summary>
		/// An event raised when the local network has changed.
		/// </summary>
		public static event NetworkLocalChangedEventHandler Changed;

		#endregion

		#region Private methods

		/// <summary>
		/// A method called when the network address has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private static void OnNetworkAddressChanged(object sender, EventArgs e)
		{
			// Raise a network changed event.
			if (null != NetworkLocal.Changed) NetworkLocal.Changed(null, null);
		}

		/// <summary>
		/// Updates the current list of local addresses.
		/// </summary>
		private static void OnUpdateAdresses()
		{
			// For all network interfaces.
			foreach (NetworkInterface iface in NetworkInterface.GetAllNetworkInterfaces())
			{
				if (iface.OperationalStatus == OperationalStatus.Up)
				{
					IPInterfaceProperties ipProperties = iface.GetIPProperties();

					foreach (UnicastIPAddressInformation info in ipProperties.UnicastAddresses)
					{
						info.
					}
				}
			}
		}

		#endregion
	}
}
