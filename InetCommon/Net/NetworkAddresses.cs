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
using System.Linq;
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

		private static object sync = new object();

		/// <summary>
		/// Static constructor.
		/// </summary>
		static NetworkAddresses()
		{
			// Set the event handlers.
			NetworkChange.NetworkAddressChanged += NetworkAddresses.OnNetworkAddressChanged;

			// Update the list of local addresses.
			NetworkAddresses.OnUpdate();
		}

		#region Public events

		/// <summary>
		/// An event raised when the local network has changed.
		/// </summary>
		public static event EventHandler NetworkAddressesChanged;

		#endregion

		#region Public properties

		/// <summary>
		/// Gets the synchronization object.
		/// </summary>
		public static object Sync { get { return NetworkAddresses.sync; } }
		/// <summary>
		/// Gets the collection of unicast information.
		/// </summary>
		public static IEnumerable<UnicastNetworkAddressInformation> Unicast { get { return NetworkAddresses.unicastInformation; } }

		#endregion

		#region Private methods

		/// <summary>
		/// A method called when the network address has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private static void OnNetworkAddressChanged(object sender, EventArgs e)
		{
			// Update the list of local addresses.
			NetworkAddresses.OnUpdate();
			// Raise an event.
			if (NetworkAddresses.NetworkAddressesChanged != null) NetworkAddresses.NetworkAddressesChanged(null, EventArgs.Empty);
		}

		/// <summary>
		/// Updates the network information.
		/// </summary>
		private static void OnUpdate()
		{
			lock (NetworkAddresses.sync)
			{
				// Set the information for all addresses to stale.
				NetworkAddresses.unicastInformation.ForEach(info => info.Stale = true);

				// For all network interfaces.
				foreach (NetworkInterface iface in NetworkInterface.GetAllNetworkInterfaces())
				{
					// Get the IP properties.
					IPInterfaceProperties ipProperties = iface.GetIPProperties();

					// For all unicast IP addresses.
					foreach (UnicastIPAddressInformation info in ipProperties.UnicastAddresses)
					{
						// Find the corresponding address information.
						UnicastNetworkAddressInformation information = NetworkAddresses.unicastInformation.FirstOrDefault(inf => inf.Information.Address == info.Address);

						// If there exists an address information.
						if (null != information)
						{
							// If the information has changed.
							if (information.Interface != iface || information.UnicastInformation != info)
							{
								// Update the information.
								information.Interface = iface;
								information.UnicastInformation = info;
							}

							// Set the information as not stale.
							information.Stale = false;
						}
						else
						{
							// Create a new address information.
							information = new UnicastNetworkAddressInformation(iface, info);

							// Add the address information to the list.
							NetworkAddresses.unicastInformation.Add(information);
						}
					}
				}

				// Remove the stale address information records.
				NetworkAddresses.unicastInformation.RemoveAll(info => info.Stale);

				// Order the address information records.
				NetworkAddresses.unicastInformation.OrderBy(info => info.Information.Address);
			}
		}

		#endregion
	}
}
