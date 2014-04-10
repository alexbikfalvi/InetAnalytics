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
using System.Windows.Forms;
using DotNetApi.Windows.Controls;
using InetCommon.Net;

namespace InetTraceroute.Controls
{
	/// <summary>
	/// A control showing the current local interfaces.
	/// </summary>
	public partial class ControlInterfaces : ThreadSafeControl
	{
		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlInterfaces()
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
					if (!info.Information.IsTransient && info.Information.IsDnsEligible)
					{
						// Create a new list view item.
						ListViewItem item = new ListViewItem(new string[] {
							info.Information.Address.ToString(),
							info.Information.Address.AddressFamily.ToString(),
							info.Interface.Name
						});
						item.ImageIndex = 0;
						item.Checked = info.Selected;
						item.Tag = info;
						this.listView.Items.Add(item);
					}
				}
			}
		}

		#endregion
	}
}
