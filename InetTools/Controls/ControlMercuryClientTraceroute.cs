/* 
 * Copyright (C) 2013 Alex Bikfalvi
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
using DotNetApi;
using DotNetApi.Windows.Controls;
using InetTools.Tools.Mercury;

namespace InetTools.Controls
{
	/// <summary>
	/// A control that displys the tarceroute information.
	/// </summary>
	public partial class ControlMercuryClientTraceroute : ThreadSafeControl
	{
		// Creates a new control instance.
		public ControlMercuryClientTraceroute()
		{
			this.InitializeComponent();
		}
		

		// Public method.

		/// <summary>
		/// Clears the site information.
		/// </summary>
		public void Clear()
		{
			this.labelTitle.Text = "No traceroute";
			this.textBoxSource.Text = string.Empty;
			this.textBoxDestination.Text = string.Empty;
			this.textBoxMaxHops.Text = string.Empty;
			this.textBoxPacketSize.Text = string.Empty;
			this.listViewHops.Items.Clear();
		}

		/// <summary>
		/// Sets the specified traceroute information.
		/// </summary>
		/// <param name="traceroute">The site.</param>
		public void Set(MercuryTraceroute traceroute)
		{
			// Clear the information.
			this.Clear();

			if (null != traceroute)
			{
				this.labelTitle.Text = @"{0} → {1}".FormatWith(traceroute.SourceIp, traceroute.DestinationIp);
				this.textBoxSource.Text = string.IsNullOrWhiteSpace(traceroute.SourceHostname) ? traceroute.SourceIp.ToString() : "{0} ({1})".FormatWith(traceroute.SourceHostname, traceroute.SourceIp);
				this.textBoxDestination.Text = string.IsNullOrWhiteSpace(traceroute.DestinationHostname) ? traceroute.DestinationIp.ToString() : "{0} ({1})".FormatWith(traceroute.DestinationHostname, traceroute.DestinationIp);
				this.textBoxMaxHops.Text = traceroute.MaximumHops.HasValue ? traceroute.MaximumHops.Value.ToString() : "(not set)";
				this.textBoxPacketSize.Text = traceroute.PacketSize.HasValue ? traceroute.PacketSize.Value.ToString() : "(not set)";
				foreach (MercuryTracerouteHop hop in traceroute.Hops)
				{
					ListViewItem item = new ListViewItem(new string[] {
						hop.Number.ToString(),
						hop.Address != null ? hop.Address.ToString() : "(not set)",
						hop.Hostname != null ? hop.Hostname : "(not set)",
						hop.AutonomousSystems != null ? hop.AutonomousSystems.ToExtendedString() : "(not set)",
						hop.Rtt != null ? hop.Rtt.ToExtendedString() : "(not set)"
						});
					item.ImageIndex = hop.Address != null ? 0 : 1;
					item.Tag = 
					this.listViewHops.Items.Add(item);
				}
			}
		}
	}
}
