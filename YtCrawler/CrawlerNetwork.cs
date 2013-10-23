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
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Timers;

namespace YtCrawler
{
	/// <summary>
	/// A class used to collect network information.
	/// </summary>
	public sealed class CrawlerNetwork
	{
		private static readonly string internetIcmpHost = "8.8.8.8";
		private static readonly string internetHttpHost = "http://www.google.com";
		private const double timerInterval = 10000.0;
		
		private bool internetAvailable = false;
		private readonly Timer timer = new Timer(CrawlerNetwork.timerInterval);
		private readonly Ping ping = new Ping();
		private readonly WebClient web = new WebClient();

		/// <summary>
		/// Creates a new crawler network instance.
		/// </summary>
		public CrawlerNetwork()
		{
			// Set the network change event handlers.
			NetworkChange.NetworkAddressChanged += this.OnNetworkAddressChanged;
			NetworkChange.NetworkAvailabilityChanged += this.OnNetworkAvailabilityChanged;

			// Create the network availability timer.
			this.timer.Elapsed += this.OnTimerElapsed;
			this.timer.Enabled = true;
		}

		// Public properties.

		/// <summary>
		/// Returns whether the network connection is available.
		/// </summary>
		public bool IsNetworkAvaialable { get { return NetworkInterface.GetIsNetworkAvailable(); } }

		/// <summary>
		/// Returns whether the internet is available.
		/// </summary>
		public bool IsInternetAvailable { get { return this.internetAvailable; } }

		// Public events.

		/// <summary>
		/// An event raised when the network status has changed.
		/// </summary>
		public event EventHandler NetworkChanged;

		// Private methods.

		/// <summary>
		/// A method called when the network address has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNetworkAddressChanged(object sender, EventArgs e)
		{
			// Raise the network changed event.
			if (null != this.NetworkChanged) this.NetworkChanged(sender, e);
		}

		/// <summary>
		/// A method called when the network availability has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
		{
			// Raise the network changed event.
			if (null != this.NetworkChanged) this.NetworkChanged(sender, e);
		}

		/// <summary>
		/// An event handler called when the timer has elapsed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnTimerElapsed(object sender, ElapsedEventArgs e)
		{
			// Update the network availability.
			this.OnUpdateInternetAvialability();
		}

		/// <summary>
		/// Updates the Internet avialability.
		/// </summary>
		private void OnUpdateInternetAvialability()
		{
			bool available;

			// Check the ICMP connectivity.
			if (!(available = this.OnUpdateInternetAvailabilityIcmp()))
			{
				// Check the HTTP connectivity.
				available = this.OnUpdateInternetAvailabilityHttp();
			}

			// If the availability has changed.
			if (this.internetAvailable != available)
			{
				// Change the Internet availability.
				this.internetAvailable = available;
				// Raise the event.
				if (null != this.NetworkChanged) this.NetworkChanged(this, EventArgs.Empty);
			}
		}

		private bool OnUpdateInternetAvailabilityIcmp()
		{
			try
			{
				// Ping the default host.
				PingReply reply = this.ping.Send(CrawlerNetwork.internetIcmpHost);
				return reply.Status == IPStatus.Success;
			}
			catch { }
			return false;
		}

		private bool OnUpdateInternetAvailabilityHttp()
		{
			try
			{
				// Open an HTTP connection to the default host.
				using (Stream stream = this.web.OpenRead(CrawlerNetwork.internetHttpHost))
				{
					return true;
				}
			}
			catch { }
			return false;
		}
	}
}
