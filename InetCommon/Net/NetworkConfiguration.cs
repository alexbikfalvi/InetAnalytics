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
using System.Net.Sockets;

namespace InetCommon.Net
{
	/// <summary>
	/// A class with information about the local network configuration.
	/// </summary>
	public class NetworkConfiguration
	{
		private static readonly List<UnicastNetworkAddressInformation> unicastInformation = new List<UnicastNetworkAddressInformation>();

		private static object sync = new object();

		/// <summary>
		/// Static constructor.
		/// </summary>
		static NetworkConfiguration()
		{
			// Set the event handlers.
			NetworkChange.NetworkAddressChanged += NetworkConfiguration.OnNetworkAddressChanged;

			// Update the list of local addresses.
			NetworkConfiguration.OnUpdate();
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
		public static object Sync { get { return NetworkConfiguration.sync; } }
		/// <summary>
		/// Gets the collection of unicast information.
		/// </summary>
		public static IEnumerable<UnicastNetworkAddressInformation> Unicast { get { return NetworkConfiguration.unicastInformation; } }

		#endregion

		#region Public methods

		/// <summary>
		/// Gets the network interfaces with the specified operational status.
		/// </summary>
		/// <param name="status">The operational status.</param>
		/// <returns>The array of network interfaces.</returns>
		public static NetworkInterface[] GetNetworkInterfaces(OperationalStatus status)
		{
			return NetworkInterface.GetAllNetworkInterfaces().Where(iface => iface.OperationalStatus == status).ToArray();
		}

		/// <summary>
		/// Gets the network interfaces that have unicast IP addresses.
		/// </summary>
		/// <returns>The array of network interfaces.</returns>
		public static NetworkInterface[] GetNetworkInterfacesWithUnicastAddresses()
		{
			return NetworkInterface.GetAllNetworkInterfaces().Where(iface =>  iface.OperationalStatus == OperationalStatus.Up ? NetworkConfiguration.GetLocalUnicastAddress(iface) != null : false).ToArray();
		}

		/// <summary>
		/// Returns a local unicast IP address.
		/// </summary>
		/// <returns>The IP address.</returns>
		public static IPAddress GetLocalUnicastAddress()
		{
			// For all network interfaces.
			foreach (NetworkInterface iface in NetworkInterface.GetAllNetworkInterfaces().Where(i => i.OperationalStatus == OperationalStatus.Up))
			{
				IPAddress address = NetworkConfiguration.GetLocalUnicastAddress(iface);
				if (address != null) return address;
			}
			// Return null.
			return null;
		}

		/// <summary>
		/// Returns a local unicast IP address.
		/// </summary>
		/// <param name="addressFamily">The address family.</param>
		/// <returns>The IP address.</returns>
		public static IPAddress GetLocalUnicastAddress(AddressFamily addressFamily)
		{
			// For all network interfaces.
			foreach (NetworkInterface iface in NetworkInterface.GetAllNetworkInterfaces().Where(i => i.OperationalStatus == OperationalStatus.Up))
			{
				IPAddress address = NetworkConfiguration.GetLocalUnicastAddress(iface, addressFamily);
				if (address != null) return address;
			}
			// Return null.
			return null;
		}

		/// <summary>
		/// Returns a local unicast IP address for the specified network interface.
		/// </summary>
		/// <param name="iface">The network interface.</param>
		/// <returns>The IP address.</returns>
		public static IPAddress GetLocalUnicastAddress(NetworkInterface iface)
		{
			// Get the IP properties.
			IPInterfaceProperties ipProperties = iface.GetIPProperties();
			// Get the unicast IP address information.
			UnicastIPAddressInformation information = ipProperties.UnicastAddresses.Where(info => info.IsDnsEligible).FirstOrDefault();
			// Return null.
			return information != null ? information.Address : null;
		}

		/// <summary>
		/// Returns a local unicast IP address for the specified network interface.
		/// </summary>
		/// <param name="iface">The network interface.</param>
		/// <param name="addressFamily">The address family.</param>
		/// <returns>The IP address.</returns>
		public static IPAddress GetLocalUnicastAddress(NetworkInterface iface, AddressFamily addressFamily)
		{
			// Get the IP properties.
			IPInterfaceProperties ipProperties = iface.GetIPProperties();
			// Get the unicast IP address information.
			UnicastIPAddressInformation information = ipProperties.UnicastAddresses.Where(info => info.IsDnsEligible && info.Address.AddressFamily == addressFamily).FirstOrDefault();
			// Return null.
			return information != null ? information.Address : null;
		}

		/// <summary>
		/// Returns a DNS server from the local configuration.
		/// </summary>
		/// <returns>The DNS server IP address.</returns>
		public static IPAddress GetDnsServer()
		{
			// For all network interfaces.
			foreach (NetworkInterface iface in NetworkInterface.GetAllNetworkInterfaces().Where(i => i.GetIPProperties().DnsAddresses.Count > 0))
			{
				return iface.GetIPProperties().DnsAddresses[0];
			}
			return null;
		}

		/// <summary>
		/// Returns a DNS server for the specified interface.
		/// </summary>
		/// <param name="iface">The interface.</param>
		/// <returns>The DNS server IP address.</returns>
		public static IPAddress GetDnsServer(NetworkInterface iface)
		{
			return iface.GetIPProperties().DnsAddresses.FirstOrDefault();
		}

		/// <summary>
		/// Returns the list of DNS server for the specified interface.
		/// </summary>
		/// <param name="iface">The interface.</param>
		/// <returns>The list of DNS server IP addresses.</returns>
		public static IPAddress[] GetDnsServers(NetworkInterface iface)
		{
			return iface.GetIPProperties().DnsAddresses.ToArray();
		}

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
			NetworkConfiguration.OnUpdate();
			// Raise an event.
			if (NetworkConfiguration.NetworkAddressesChanged != null) NetworkConfiguration.NetworkAddressesChanged(null, EventArgs.Empty);
		}

		/// <summary>
		/// Updates the network information.
		/// </summary>
		private static void OnUpdate()
		{
			lock (NetworkConfiguration.sync)
			{
				// Set the information for all addresses to stale.
				NetworkConfiguration.unicastInformation.ForEach(info => info.Stale = true);

				// For all network interfaces.
				foreach (NetworkInterface iface in NetworkInterface.GetAllNetworkInterfaces())
				{
					// Get the IP properties.
					IPInterfaceProperties ipProperties = iface.GetIPProperties();

					// For all unicast IP addresses.
					foreach (UnicastIPAddressInformation info in ipProperties.UnicastAddresses)
					{
						// Find the corresponding address information.
						UnicastNetworkAddressInformation information = NetworkConfiguration.unicastInformation.FirstOrDefault(inf => inf.Information.Address == info.Address);

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
							NetworkConfiguration.unicastInformation.Add(information);
						}
					}
				}

				// Remove the stale address information records.
				NetworkConfiguration.unicastInformation.RemoveAll(info => info.Stale);

				// Order the address information records.
				NetworkConfiguration.unicastInformation.OrderBy(info => info.Information.Address);
			}
		}

		#endregion
	}
}
