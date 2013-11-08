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
using System.Threading;

namespace InetCrawler
{
	/// <summary>
	/// A class used to collect network information.
	/// </summary>
	public sealed class CrawlerNetwork
	{
		/// <summary>
		/// An enumeration representing the availability status.
		/// </summary>
		public enum AvailabilityStatus
		{
			Unknown = 0,
			Success = 1,
			Warning = 2,
			Fail = 3
		}

		private static readonly object sync = new object();

		private bool timerEnabled = true;
		private TimeSpan timerInterval = new TimeSpan(0, 1, 0);

		private string internetIcmpHost = "8.8.8.8";
		private string internetHttpHost = "http://www.google.com";
		private string internetHttpsHost = "https://www.google.com";

		private readonly Timer timer;
		private readonly Ping ping = new Ping();
		private readonly WebClient web = new WebClient();

		private AvailabilityStatus internetAvailable = AvailabilityStatus.Unknown;
		private bool internetAvailableIcmp = false;
		private bool internetAvailableHttp = false;
		private bool internetAvailableHttps = false;
		private DateTime internetAvailableLastUpdated = DateTime.MinValue;

		/// <summary>
		/// Creates a new crawler network instance.
		/// </summary>
		public CrawlerNetwork()
		{
			// Set the network change event handlers.
			NetworkChange.NetworkAddressChanged += this.OnNetworkAddressChanged;
			NetworkChange.NetworkAvailabilityChanged += this.OnNetworkAvailabilityChanged;

			// Create the network timer.
			this.timer = new Timer((object state) =>
				{
					// Synchronize the timer.
					lock (CrawlerNetwork.sync)
					{
						// Check the network availability.
						this.OnUpdateInternetAvialability();
					}
				},
				null, 0, (long)this.timerInterval.TotalMilliseconds);
		}

		// Public properties.

		/// <summary>
		/// Gets or sets whether the timer is enabled.
		/// </summary>
		public bool TimerEnabled
		{
			get { return this.timerEnabled; }
			set { this.OnSetTimerEnabled(value); }
		}
		/// <summary>
		/// Gets or sets the timer interval.
		/// </summary>
		public TimeSpan TimerInterval
		{
			get { return this.timerInterval; }
			set { this.OnSetTimerInterval(value); }
		}
		/// <summary>
		/// Gets or sets the Internet ICMP host.
		/// </summary>
		public string InternetIcmpHost
		{
			get { return this.internetIcmpHost; }
			set { this.internetIcmpHost = value; }
		}
		/// <summary>
		/// Gets or sets the Internet HTTP host.
		/// </summary>
		public string InternetHttpHost
		{
			get { return this.internetHttpHost; }
			set { this.internetHttpHost = value; }
		}
		/// <summary>
		/// Gets or sets the Internet HTTPS host.
		/// </summary>
		public string InternetHttpsHost
		{
			get { return this.internetHttpsHost; }
			set { this.internetHttpsHost = value; }
		}
		/// <summary>
		/// Returns whether the Internet is available.
		/// </summary>
		public AvailabilityStatus IsInternetAvailable { get { return this.internetAvailable; } }
		/// <summary>
		/// Returns whether the Internet ICMP is available.
		/// </summary>
		public bool IsInternetIcmpAvailable { get { return this.internetAvailableIcmp; } }
		/// <summary>
		/// Returns whether the Internet HTTP is available.
		/// </summary>
		public bool IsInternetHttpAvailable { get { return this.internetAvailableHttp; } }
		/// <summary>
		/// Returns whether the Internet HTTPS is available.
		/// </summary>
		public bool IsInternetHttpsAvailable { get { return this.internetAvailableHttps; } }
		/// <summary>
		/// Returns the date-time when the Internet availability was last updated.
		/// </summary>
		public DateTime InternetAvailableLastUpdated { get { return this.internetAvailableLastUpdated; } }

		// Public events.

		/// <summary>
		/// An event raised when the network status has changed.
		/// </summary>
		public event EventHandler NetworkChanged;
		/// <summary>
		/// An event raised when the network status was checked.
		/// </summary>
		public event EventHandler NetworkChecked;

		// Private methods.

		/// <summary>
		/// A method called to set whether the timer is enabled.
		/// </summary>
		/// <param name="enabled"><b>True</b> if the timer is enabled, <b>false</b> otherwise.</param>
		private void OnSetTimerEnabled(bool enabled)
		{
			// Set the timer enabled.
			this.timerEnabled = enabled;
			// Update the timer.
			if (this.timerEnabled)
			{
				this.timer.Change(TimeSpan.FromTicks(0), this.timerInterval);
			}
			else
			{
				this.timer.Change(Timeout.Infinite, Timeout.Infinite);
			}
		}

		/// <summary>
		/// A method called to set the timer interval.
		/// </summary>
		/// <param name="interval">The timer interval.</param>
		private void OnSetTimerInterval(TimeSpan interval)
		{
			// Set the timer interval.
			this.timerInterval = interval;
			// Update the timer.
			if (this.timerEnabled)
			{
				this.timer.Change(TimeSpan.FromTicks(0), this.timerInterval);
			}
			else
			{
				this.timer.Change(Timeout.Infinite, Timeout.Infinite);
			}
		}

		/// <summary>
		/// A method called when the network address has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNetworkAddressChanged(object sender, EventArgs e)
		{
			// Update the Internet availability.

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
		/// Updates the Internet avialability.
		/// </summary>
		private void OnUpdateInternetAvialability()
		{
			// The Internet availability.
			AvailabilityStatus internetAvailable;

			// If the network is available.
			if (NetworkInterface.GetIsNetworkAvailable())
			{
				// Check the ICMP connectivity.
				this.internetAvailableIcmp = this.OnUpdateInternetAvailabilityIcmp();
				// Check the HTTP connectivity.
				this.internetAvailableHttp = this.OnUpdateInternetAvailabilityHttp();
				// Check the HTTPs connectivity.
				this.internetAvailableHttps = this.OnUpdateInternetAvailabilityHttps();
				
				// Update the Internet availability.
				internetAvailable =
					this.internetAvailableIcmp || this.internetAvailableHttp || this.internetAvailableHttps ? AvailabilityStatus.Success : AvailabilityStatus.Warning;
			}
			else
			{
				internetAvailable = AvailabilityStatus.Fail;
			}

			// Set the last updated.
			this.internetAvailableLastUpdated = DateTime.Now;

			// If the availability has changed.
			if (this.internetAvailable != internetAvailable)
			{
				// Change the Internet availability.
				this.internetAvailable = internetAvailable;
				// Raise the event.
				if (null != this.NetworkChanged) this.NetworkChanged(this, EventArgs.Empty);
			}

			// Raise the network checked event.
			if (null != this.NetworkChecked) this.NetworkChecked(this, EventArgs.Empty);
		}

		/// <summary>
		/// A methods that checks the ICMP connnectivity.
		/// </summary>
		/// <returns><b>True</b> if the Internet is available on the specified protocol, <b>false</b> otherwise.</returns>
		private bool OnUpdateInternetAvailabilityIcmp()
		{
			try
			{
				// Ping the default host.
				PingReply reply = this.ping.Send(this.internetIcmpHost);
				return reply.Status == IPStatus.Success;
			}
			catch { }
			return false;
		}

		/// <summary>
		/// A methods that checks the HTTP connnectivity.
		/// </summary>
		/// <returns><b>True</b> if the Internet is available on the specified protocol, <b>false</b> otherwise.</returns>
		private bool OnUpdateInternetAvailabilityHttp()
		{
			try
			{
				// Open an HTTP connection to the default host.
				using (Stream stream = this.web.OpenRead(this.internetHttpHost))
				{
					return true;
				}
			}
			catch { }
			return false;
		}

		/// <summary>
		/// A methods that checks the HTTPS connnectivity.
		/// </summary>
		/// <returns><b>True</b> if the Internet is available on the specified protocol, <b>false</b> otherwise.</returns>
		private bool OnUpdateInternetAvailabilityHttps()
		{
			try
			{
				// Open an HTTPS connection to the default host.
				using (Stream stream = this.web.OpenRead(this.internetHttpsHost))
				{
					return true;
				}
			}
			catch { }
			return false;
		}
	}
}
