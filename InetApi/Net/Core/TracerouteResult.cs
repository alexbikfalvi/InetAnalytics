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
using System.Net.NetworkInformation;
using DotNetApi.Async;

namespace InetApi.Net.Core
{
	/// <summary>
	/// A class representing the traceroute result.
	/// </summary>
	public class TracerouteResult : AsyncResult
	{
		private long minRtt = long.MaxValue;
		private long maxRtt = long.MinValue;
		private long sumRtt = 0;
		private int countRtt = 0;

		/// <summary>
		/// Creates a new traceroute result instance.
		/// </summary>
		/// <param name="state">The user state.</param>
		public TracerouteResult(object state)
			: base(state)
		{

		}

		// Public properties.

		/// <summary>
		/// Gets or sets the ICMP timeout.
		/// </summary>
		public int Timeout { get; set; }
		/// <summary>
		/// Gets or sets whether the ICMP don't fragment bit is set.
		/// </summary>
		public bool DontFragment { get; set; }
		/// <summary>
		/// Gets the current time-to-live.
		/// </summary>
		public int CurrentTtl { get; protected set; }
		/// <summary>
		/// Gets the index of the current attempt.
		/// </summary>
		public int CurrentAttempt { get; protected set; }
		/// <summary>
		/// Gets whether the last TTL was successful in at least one attempt.
		/// </summary>
		public bool TtlSuccess { get; protected set; }
		/// <summary>
		/// Gets the number of last failed TTL.
		/// </summary>
		public int LastFailedTtlCount { get; protected set; }
		/// <summary>
		/// Gets the last reply.
		/// </summary>
		public PingReply LastReply { get; protected set; }
		/// <summary>
		/// Gets the last exception.
		/// </summary>
		public Exception LastException { get; protected set; }
		/// <summary>
		/// Gets whether the last request completed successfully.
		/// </summary>
		public bool IsSuccess { get; protected set; }
		/// <summary>
		/// Gets whether the traceroute was canceled.
		/// </summary>
		public bool IsCanceled { get; protected set; }
		/// <summary>
		/// Gets the traceroute success count per attempt.
		/// </summary>
		public int SuccessCount { get; protected set; }
		/// <summary>
		/// Gets the traceroute error count per attempt.
		/// </summary>
		public int ErrorCount { get; protected set; }
		/// <summary>
		/// Gets the minimum round-trip time.
		/// </summary>
		public long RoundtripTimeMinimum { get { return this.countRtt > 0 ? this.minRtt : -1; } }
		/// <summary>
		/// Gets the minimum round-trip time.
		/// </summary>
		public long RoundtripTimeMaximum { get { return this.countRtt > 0 ? this.maxRtt : -1; } }
		/// <summary>
		/// Gets the average round-trip time.
		/// </summary>
		public double RoundtripTimeAverage { get { return this.countRtt > 0 ? (double)this.sumRtt / this.countRtt : -1; } }
		/// <summary>
		/// Gets the number of round-trip time samples.
		/// </summary>
		public double RoundtripTimeCount { get { return this.countRtt; } }

		// Protected methods.

		/// <summary>
		/// Adds the specified round-trip time.
		/// </summary>
		/// <param name="rtt">The round-trip time.</param>
		protected void AddRoundtripTime(long rtt)
		{
			this.sumRtt += rtt;
			this.countRtt++;
			if (rtt > this.maxRtt) this.maxRtt = rtt;
			if (rtt < this.minRtt) this.minRtt = rtt;
		}

		/// <summary>
		/// Resets the round-trip time information.
		/// </summary>
		protected void ResetRoundtripTime()
		{
			this.minRtt = long.MaxValue;
			this.maxRtt = long.MinValue;
			this.sumRtt = 0;
			this.countRtt = 0;
		}
	}
}
