/* 
 * Copyright (C) 2012 Alex Bikfalvi
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
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Windows.Controls;
using InetAnalytics.Forms;
using InetCrawler.Comments;

namespace InetAnalytics.Controls.Net
{
	/// <summary>
	/// Displays the information of a network interface.
	/// </summary>
	public partial class ControlNetworkInterfaceProperties : ThreadSafeControl
	{
		private NetworkInterface iface = null;

		/// <summary>
		/// Creates a new network interface control instance.
		/// </summary>
		public ControlNetworkInterfaceProperties()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Gets or sets the current network interface.
		/// </summary>
		public NetworkInterface Interface
		{
			get { return this.iface; }
			set
			{
				// Save the old value.
				NetworkInterface old = this.iface;
				// Set the new value.
				this.iface = value;
				// Call the event handler.
				this.OnNetworkInterfaceSet(old, value);
			}
		}

		// Protected methods.

		/// <summary>
		/// An event handler called when a new network interface has been set.
		/// </summary>
		/// <param name="oldInterface">The old network interface.</param>
		/// <param name="newInterface">The new network interface.</param>
		protected virtual void OnNetworkInterfaceSet(NetworkInterface oldInterface, NetworkInterface newInterface)
		{
			// If the comment has not changed, do nothing.
			if (oldInterface == newInterface) return;

			if (null == newInterface)
			{
				this.labelTitle.Text = "No network interface selected";
				this.tabControl.Visible = false;
			}
			else
			{
				this.labelTitle.Text = newInterface.Name;

				// General.

				this.textBoxName.Text = newInterface.Name;
				this.textBoxType.Text = newInterface.NetworkInterfaceType.ToString();
				this.textBoxStatus.Text = newInterface.OperationalStatus.ToString();
				this.textBoxDescription.Text = newInterface.Description;
				this.textBoxSpeed.Text = newInterface.Speed.BitRateToString();
				this.textBoxId.Text = newInterface.Id;

				this.checkBoxReceiveOnly.Checked = newInterface.IsReceiveOnly;
				this.checkBoxSupportsMulticast.Checked = newInterface.SupportsMulticast;

				// IP addresses.

				IPInterfaceProperties ipProperties = newInterface.GetIPProperties();

				this.listBoxUnicastAddresses.Items.Clear();
				this.listBoxMulticastAddresses.Items.Clear();
				this.listBoxAnycastAddresses.Items.Clear();
				this.listBoxGatewayAddresses.Items.Clear();

				foreach (UnicastIPAddressInformation info in ipProperties.UnicastAddresses)
				{
					this.listBoxUnicastAddresses.Items.Add(ControlNetworkInterfaceProperties.IpAddressToString(info.Address, info.IPv4Mask));
				}
				foreach (MulticastIPAddressInformation info in ipProperties.MulticastAddresses)
				{
					this.listBoxMulticastAddresses.Items.Add(info.Address);
				}
				foreach (IPAddressInformation info in ipProperties.AnycastAddresses)
				{
					this.listBoxAnycastAddresses.Items.Add(info.Address);
				}
				foreach (GatewayIPAddressInformation info in ipProperties.GatewayAddresses)
				{
					this.listBoxGatewayAddresses.Items.Add(info.Address);
				}

				this.tabControl.Visible = true;

				// IP servers.

				this.listBoxDnsServers.Items.Clear();
				this.listBoxDhcpServers.Items.Clear();
				this.listBoxWinsServers.Items.Clear();

				foreach (IPAddress address in ipProperties.DnsAddresses)
				{
					this.listBoxDnsServers.Items.Add(address);
				}
				foreach (IPAddress address in ipProperties.DhcpServerAddresses)
				{
					this.listBoxDhcpServers.Items.Add(address);
				}
				foreach (IPAddress address in ipProperties.WinsServersAddresses)
				{
					this.listBoxWinsServers.Items.Add(address);
				}

				this.textBoxDnsSuffix.Text = ipProperties.DnsSuffix;

				this.checkBoxDnsEnabled.Checked = ipProperties.IsDnsEnabled;
				this.checkBoxDynamicDns.Checked = ipProperties.IsDynamicDnsEnabled;
			}
			this.tabControl.SelectedTab = this.tabPageGeneral;
			if (this.Focused)
			{
				this.textBoxName.Select();
				this.textBoxName.SelectionStart = 0;
				this.textBoxName.SelectionLength = 0;
			}
		}

		// Private methods.

		/// <summary>
		/// Converts the specified IP address and mask information to string.
		/// </summary>
		/// <param name="address">The IP address.</param>
		/// <param name="mask">The address mask.</param>
		/// <returns>The string representation.</returns>
		private static string IpAddressToString(IPAddress address, IPAddress mask)
		{
			return mask != null ? address.ToString() : "{0} / {1}".FormatWith(address, mask);
		}
	}
}
