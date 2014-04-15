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
using DotNetApi;
using DotNetApi.Windows.Controls;
using InetCommon.Log;
using InetCommon.Net;
using InetCommon.Status;

namespace InetTraceroute.Controls
{
	/// <summary>
	/// A control showing the current local interfaces.
	/// </summary>
	public partial class ControlAddresses : ThreadSafeControl
	{
		private static readonly string logSource = "Network Addresses";
		private static readonly string[] addressFamilyName = {
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

		private TracerouteApplication application = null;
		private ApplicationStatusHandler status = null;

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlAddresses()
		{
			// Initialize the component.
			this.InitializeComponent();

			// Set the control properties.
			this.Enabled = false;
		}

		#region Public methods

		/// <summary>
		/// Initializes the control.
		/// </summary>
		/// <param name="application">The application.</param>
		public void Initialize(TracerouteApplication application)
		{
			// Set the application.
			this.application = application;
			// Set the control status.
			this.status = this.application.Status.GetHandler(this);

			// Set the network addresses changed event handler.
			NetworkConfiguration.NetworkAddressesChanged += this.OnRefresh;

			// Enable the control.
			this.Enabled = true;

			// Update the list of interface addresses.
			this.OnRefresh(true);
		}

		#endregion

		#region Private methods

		/// <summary>
		/// Refreshes the list of interface addresses.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRefresh(object sender, EventArgs e)
		{
			this.OnRefresh(false);
		}

		/// <summary>
		/// Refreshes the list of interface addresses.
		/// </summary>
		/// <param name="initialize">If <b>true</b> indicates this is an initial refresh.</param>
		private void OnRefresh(bool initialize)
		{
			// Execute this method on the UI thread.
			this.Invoke(() =>
			{
				// Clear the list of addresses.
				this.listView.Items.Clear();

				// Synchronize access.
				lock (NetworkConfiguration.Sync)
				{
					int count = 0;

					// Update the list of addresses.
					foreach (UnicastNetworkAddressInformation info in NetworkConfiguration.Unicast)
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
							count++;
						}
						else
						{
							// Otherwise, disable the interface.
							info.Selected = false;
						}
					}

					// Log.
					this.controlLog.Add(this.application.Log.Add(
						LogEventLevel.Normal,
						LogEventType.Information,
						ControlAddresses.logSource,
						initialize ? "Local network addresses initialized. {{0}} unicast address{0} available.".FormatWith(count.PluralSuffix("es")) : "Local network addresses have changed. {{0}} unicast address{0} available.".FormatWith(count.PluralSuffix("es")),
						new object[] { count }));
					// Update the status.
					this.status.Send(ApplicationStatus.StatusType.Normal, "{0} unicast address{1}".FormatWith(count, count.PluralSuffix("es")), Resources.NetworkInterface_16);
				}
			});
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
