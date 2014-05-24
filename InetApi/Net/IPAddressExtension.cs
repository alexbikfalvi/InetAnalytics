/* 
 * Copyright (C) 2010-2012 Alexander Reinert
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace InetApi.Net
{
	/// <summary>
	/// Extension class for the <see cref="IPAddress" /> class
	/// </summary>
	public static class IPAddressExtension
	{
		/// <summary>
		/// Reverses the order of the bytes of an IPAddress
		/// </summary>
		/// <param name="ipAddress"> Instance of the IPAddress, that should be reversed </param>
		/// <returns> New instance of IPAddress with reversed address </returns>
		public static IPAddress Reverse(this IPAddress ipAddress)
		{
			if (ipAddress == null)
				throw new ArgumentNullException("ipAddress");

			byte[] addressBytes = ipAddress.GetAddressBytes();
			byte[] res = new byte[addressBytes.Length];

			for (int i = 0; i < res.Length; i++)
			{
				res[i] = addressBytes[addressBytes.Length - i - 1];
			}

			return new IPAddress(res);
		}

		/// <summary>
		/// Gets the network address for a specified IPAddress and netmask
		/// </summary>
		/// <param name="ipAddress"> IPAddress, for that the network address should be returned </param>
		/// <param name="netmask"> Netmask, that should be used </param>
		/// <returns> New instance of IPAddress with the network address assigend </returns>
		public static IPAddress GetNetworkAddress(this IPAddress ipAddress, IPAddress netmask)
		{
			if (ipAddress == null)
				throw new ArgumentNullException("ipAddress");

			if (netmask == null)
				throw new ArgumentNullException("netMask");

			if (ipAddress.AddressFamily != netmask.AddressFamily)
				throw new ArgumentOutOfRangeException("netmask", "Protocoll version of ipAddress and netmask do not match");

			byte[] resultBytes = ipAddress.GetAddressBytes();
			byte[] ipAddressBytes = ipAddress.GetAddressBytes();
			byte[] netmaskBytes = netmask.GetAddressBytes();

			for (int i = 0; i < netmaskBytes.Length; i++)
			{
				resultBytes[i] = (byte) (ipAddressBytes[i] & netmaskBytes[i]);
			}

			return new IPAddress(resultBytes);
		}

		/// <summary>
		/// Gets the network address for a specified IPAddress and netmask
		/// </summary>
		/// <param name="ipAddress"> IPAddress, for that the network address should be returned </param>
		/// <param name="netmask"> Netmask in CIDR format </param>
		/// <returns> New instance of IPAddress with the network address assigend </returns>
		public static IPAddress GetNetworkAddress(this IPAddress ipAddress, int netmask)
		{
			if (ipAddress == null)
				throw new ArgumentNullException("ipAddress");

			if ((ipAddress.AddressFamily == AddressFamily.InterNetwork) && ((netmask < 0) || (netmask > 32)))
				throw new ArgumentException("Netmask have to be in range of 0 to 32 on IPv4 addresses", "netmask");

			if ((ipAddress.AddressFamily == AddressFamily.InterNetworkV6) && ((netmask < 0) || (netmask > 128)))
				throw new ArgumentException("Netmask have to be in range of 0 to 128 on IPv6 addresses", "netmask");

			byte[] ipAddressBytes = ipAddress.GetAddressBytes();

			for (int i = 0; i < ipAddressBytes.Length; i++)
			{
				if (netmask >= 8)
				{
					netmask -= 8;
				}
				else
				{
					if (BitConverter.IsLittleEndian)
					{
						ipAddressBytes[i] &= ReverseBitOrder((byte) ~(255 << netmask));
					}
					netmask = 0;
				}
			}

			return new IPAddress(ipAddressBytes);
		}

		/// <summary>
		/// Returns the reverse lookup address of an IPAddress
		/// </summary>
		/// <param name="ipAddress"> Instance of the IPAddress, that should be used </param>
		/// <returns> A string with the reverse lookup address </returns>
		public static string GetReverseLookupAddress(this IPAddress ipAddress)
		{
			if (ipAddress == null)
				throw new ArgumentNullException("ipAddress");

			StringBuilder res = new StringBuilder();

			byte[] addressBytes = ipAddress.GetAddressBytes();

			if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
			{
				for (int i = addressBytes.Length - 1; i >= 0; i--)
				{
					res.Append(addressBytes[i]);
					res.Append(".");
				}
				res.Append("in-addr.arpa");
			}
			else
			{
				for (int i = addressBytes.Length - 1; i >= 0; i--)
				{
					string hex = addressBytes[i].ToString("x2");
					res.Append(hex[1]);
					res.Append(".");
					res.Append(hex[0]);
					res.Append(".");
				}

				res.Append("ip6.arpa");
			}

			return res.ToString();
		}

		private static readonly IPAddress _ipv4MulticastNetworkAddress = IPAddress.Parse("224.0.0.0");
		private static readonly IPAddress _ipv6MulticastNetworkAddress = IPAddress.Parse("FF00::");

		/// <summary>
		/// Returns a value indicating whether a ip address is a multicast address
		/// </summary>
		/// <param name="ipAddress"> Instance of the IPAddress, that should be used </param>
		/// <returns> true, if the given address is a multicast address; otherwise, false </returns>
		public static bool IsMulticast(this IPAddress ipAddress)
		{
			if (ipAddress == null)
				throw new ArgumentNullException("ipAddress");

			if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
			{
				return ipAddress.GetNetworkAddress(4).Equals(_ipv4MulticastNetworkAddress);
			}
			else
			{
				return ipAddress.GetNetworkAddress(8).Equals(_ipv6MulticastNetworkAddress);
			}
		}

		/// <summary>
		/// Returns the index for the interface which has the ip address assigned
		/// </summary>
		/// <param name="ipAddress"> The ip address to look for </param>
		/// <returns> The index for the interface which has the ip address assigned </returns>
		public static int GetInterfaceIndex(this IPAddress ipAddress)
		{
			if (ipAddress == null)
				throw new ArgumentNullException("ipAddress");

			var interfaceProperty = NetworkInterface.GetAllNetworkInterfaces().Select(n => n.GetIPProperties()).FirstOrDefault(p => p.UnicastAddresses.Any(a => a.Address.Equals(ipAddress)));

			if (interfaceProperty != null)
			{
				if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
				{
					var property = interfaceProperty.GetIPv4Properties();
					if (property != null)
						return property.Index;
				}
				else
				{
					var property = interfaceProperty.GetIPv6Properties();
					if (property != null)
						return property.Index;
				}
			}

			throw new ArgumentOutOfRangeException("ipAddress", "The given ip address is not configured on the local system");
		}

        /// <summary>
        /// Verifies the IP address is a global unicast address.
        /// </summary>
        /// <param name="address">The IP address.</param>
        /// <returns><b>True</b> if the IP is DNS eligible, <b>false</b> otherwise.</returns>
        public static bool IsGlobalUnicastAddress(this IPAddress address)
        {
            if (address.AddressFamily == AddressFamily.InterNetwork)
            {
                byte[] bytes = address.GetAddressBytes();
                uint addr = (uint)((bytes[0] << 24) | (bytes[1] << 16) | (bytes[2] << 8) | bytes[3]);
                if ((addr & 0xFF000000) == 0) return false; // Current network (only valid as source address) 0.0.0.0/8 RFC6890
                else if ((addr & 0xFF000000) == 0x0A000000) return false; // Private network 10.0.0.0/8 RFC1918
                else if ((addr & 0xFFC00000) == 0x64400000) return false; // Shared Address Space 100.64.0.0/12 RFC6598
                else if ((addr & 0xFF000000) == 0x7F000000) return false; // Loopback 127.0.0.0/8 RFC6890
                else if ((addr & 0xFFFF0000) == 0xA9FE0000) return false; // Link-local 169.254.0.0/16 RFC3927
                else if ((addr & 0xFFF00000) == 0xAC100000) return false; // Private network 172.16.0.0/12 RFC1918
                else if ((addr & 0xFFFFFF00) == 0xC0000000) return false; // IETF Protocol Assignments 192.0.0.0/24 RFC6890
                else if ((addr & 0xFFFFFF00) == 0xC0000200) return false; // TEST-NET-1, documentation and examples 192.0.2.0/24 RFC5737
                else if ((addr & 0xFFFFFF00) == 0xC0586300) return false; // IPv6 to IPv4 relay 192.88.99.0/24 RFC3068
                else if ((addr & 0xFFFF0000) == 0xC0A80000) return false; // Private network 192.168.0.0/16 RFC1918
                else if ((addr & 0xFFFE0000) == 0xC6120000) return false; // Network benchmark tests 198.18.0.0/15 RFC2544
                else if ((addr & 0xFFFFFF00) == 0xC6336400) return false; // TEST-NET-2, documentation and examples 198.51.100.0/24 RFC5737
                else if ((addr & 0xFFFFFF00) == 0xCB007100) return false; // TEST-NET-3, documentation and examples 203.0.113.0/24 RFC5737
                else if ((addr & 0xF0000000) == 0xE0000000) return false; // IP multicast (former Class D network) 224.0.0.0/4 RFC5771
                else if ((addr & 0xF0000000) == 0xF0000000) return false; // Reserved (former Class E network) 240.0.0.0/4 RFC1700
                else if (addr == 0xFFFFFFFF) return false; // Broadcast 255.255.255.255
                else return true;
            }
            else if (address.AddressFamily == AddressFamily.InterNetworkV6)
            {
                return (!address.IsIPv6LinkLocal) && (!address.IsIPv6Multicast) &&
                    (!address.IsIPv6SiteLocal) && (!address.IsIPv6Teredo);
            }
            else return false;
        }

		#region Private methods

		/// <summary>
		/// Reverses the bit order for the specified byte value.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result.</returns>
		private static byte ReverseBitOrder(byte value)
		{
			byte result = 0;

			for (int i = 0; i < 8; i++)
			{
				result |= (byte) ((((1 << i) & value) >> i) << (7 - i));
			}

			return result;
		}

		#endregion
	}
}