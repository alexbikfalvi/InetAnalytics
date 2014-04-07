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
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;
using DotNetApi.Windows.Controls;
using InetCommon.Log;
using InetCommon.Net;

namespace InetTraceroute.Controls
{
	/// <summary>
	/// A control showing the current local interfaces.
	/// </summary>
	public partial class ControlAddresses : ThreadSafeControl
	{
		private static readonly string logSource = "Network";

		private Config config;

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlAddresses()
		{
			// Initialize the component.
			this.InitializeComponent();

			//Set the network addresses event handler.
			NetworkAddresses.UnicastAddressesChanged += this.OnNetworkAddressesChanged;

			// Update the list of addresses.
			this.OnUpdate();
		}

		#region Public methods
		
		/// <summary>
		/// Initializes the control.
		/// </summary>
		/// <param name="config">The configuration.</param>
		public void Initialize(Config config)
		{
			// Set the configuration.
			this.config = config;

			// Enable the control.
			this.Enabled = true;
		}

		#endregion

		#region Private methods

		/// <summary>
		/// An event handler called when the network addresses have changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNetworkAddressesChanged(object sender, EventArgs e)
		{
			// Update the current addresses.
			this.OnUpdate();

			// Add an event.
			/*this.controlLog.Add(new LogEvent(
				LogEventLevel.Verbose,
				LogEventType.Information,
				DateTime.Now,
				ControlAddresses.logSource,
				"The local network configuration has changed."));*/
		}

		private void OnUpdate()
		{
			// Clear the current addresses.
			this.listView.Items.Clear();

			lock (NetworkAddresses.Sync)
			{
				// Update the current addresses.
				foreach (UnicastNetworkAddressInformation info in NetworkAddresses.Unicast)
				{
					if ((info.Interface.OperationalStatus == OperationalStatus.Up) && 
						(info.UnicastInformation.Address.AddressFamily == AddressFamily.InterNetwork || info.UnicastInformation.Address.AddressFamily == AddressFamily.InterNetworkV6) &&
						!info.UnicastInformation.IsTransient &&
						info.UnicastInformation.IsDnsEligible)
					{
						ListViewItem item = new ListViewItem(new string[] {
							info.Information.Address.ToString(),
							info.Information.Address.AddressFamily.ToString(),
							info.Interface.Name
						});
						item.ImageIndex = 0;
						item.Checked = info.Selected;
						this.listView.Items.Add(item);
					}
					else
					{
						info.Selected = false;
					}
				}
			}
		}

		#endregion
	}
}
