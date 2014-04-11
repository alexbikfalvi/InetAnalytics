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
using System.Net.Sockets;
using System.Windows.Forms;
using DotNetApi.Windows.Controls;
using InetCommon.Net;

namespace InetTraceroute.Controls
{
	/// <summary>
	/// A control showing the current local interfaces.
	/// </summary>
	public partial class ControlAddresses : ThreadSafeControl
	{
		private static string[] addressFamilyName = {
														"Unspecified",
														"Unix",
														"IP version 4",
														"ARPANET IMP",
														"PUP",
														"MIT CHAOS",
														"IPX / SPX",
														"Xerox NS",
														"OSI",
														"European Computer Manufacturers Association (ECMA)",
														"DataKit",
														"CCITT",
														"IBM SNA",
														"DECnet",
														"Direct data-link",
														"LAT",
														"NSC Hyperchannel",
														"AppleTalk",
														"NetBios",
														"VoiceView",
														"FireFox",
														"Banyan",
														"ATM",
														"IP version 6",
														"Microsoft cluster",
														"IEEE 1284.4",
														"IrDA",
														"Network Designers OSI",
														"Max"
													};

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlAddresses()
		{
			// Initialize the component.
			this.InitializeComponent();

			// Set the network addresses changed event handler.
			NetworkAddresses.NetworkAddressesChanged += this.OnRefresh;

			// Update the list of interface addresses.
			this.OnRefresh(this, EventArgs.Empty);
		}

		#region Private methods

		/// <summary>
		/// Refreshes the list of interface addresses.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRefresh(object sender, EventArgs e)
		{
			// Clear the list of addresses.
			this.listView.Items.Clear();

			// Synchronize access.
			lock (NetworkAddresses.Sync)
			{
				// Update the list of addresses.
				foreach (UnicastNetworkAddressInformation info in NetworkAddresses.Unicast)
				{
					// Select only the not transient and DNS eligible addresses.
					if (!info.Information.IsTransient &&
						info.Information.IsDnsEligible &&
						((info.Information.Address.AddressFamily == AddressFamily.InterNetwork) || (info.Information.Address.AddressFamily == AddressFamily.InterNetworkV6)))
					{
						// Create a new list view item.
						ListViewItem item = new ListViewItem(new string[] {
							info.Information.Address.ToString(),
							ControlAddresses.addressFamilyName[(int)info.Information.Address.AddressFamily],
							info.Interface.Name
						});
						item.ImageIndex = 0;
						item.Checked = info.Selected;
						item.Tag = info;
						this.listView.Items.Add(item);
					}
					else
					{
						// Otherwise, disable the interface.
						info.Selected = false;
					}
				}
			}
		}

		/// <summary>
		/// An event handler called when the checked state of an item has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnItemChecked(object sender, ItemCheckedEventArgs e)
		{
			// Get the address information.
			UnicastNetworkAddressInformation info = e.Item.Tag as UnicastNetworkAddressInformation;

			// Set the selection state.
			info.Selected = e.Item.Checked;
		}

		#endregion
	}
}
