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
	/// A class with information about the local network addresses.
	/// </summary>
	public class NetworkAddresses
	{
		private static readonly List<UnicastNetworkAddressInformation> unicastInformation = new List<UnicastNetworkAddressInformation>();
		private static readonly IPAddressCollection unicastAddresses = new IPAddressCollection();

		private static object sync = new object();

		/// <summary>
		/// Static constructor.
		/// </summary>
		static NetworkAddresses()
		{
			// Set the event handlers.
			NetworkChange.NetworkAddressChanged += NetworkAddresses.OnNetworkAddressChanged;
		}

		#region Public events

		/// <summary>
		/// An event raised when the local network has changed.
		/// </summary>
		public static event NetworkLocalChangedEventHandler UnicastAddressesChanged;

		#endregion

		#region Public properties

		/// <summary>
		/// Gets the synchronization object.
		/// </summary>
		public static object Sync { get { return NetworkAddresses.sync; } }
		/// <summary>
		/// Gets the list of unicast addresses.
		/// </summary>
		public static IPAddressCollection UnicastAddresses { get { return NetworkAddresses.unicastAddresses; } }

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
			//if (null != NetworkAddresses.Changed) NetworkAddresses.Changed(null, null);
		}

		/// <summary>
		/// Updates the network information.
		/// </summary>
		private static void OnUpdate()
		{
			//lock (NetworkAddresses.sync)
			//{
			//	// Set the information for all addresses to stale.
			//	NetworkAddresses.unicastInformation.

			//	// Clear the local addresses.
			//	NetworkAddresses.unicastInformation.Clear();
			//	NetworkAddresses.unicastAddresses.Clear();

			//	// For all network interfaces.
			//	foreach (NetworkInterface iface in NetworkInterface.GetAllNetworkInterfaces())
			//	{
			//		// Get the IP properties.
			//		IPInterfaceProperties ipProperties = iface.GetIPProperties();

			//		// For all unicast IP addresses.
			//		foreach (UnicastIPAddressInformation info in ipProperties.UnicastAddresses)
			//		{

			//		}
			//	}
			//}
		}

		#endregion
	}
}
