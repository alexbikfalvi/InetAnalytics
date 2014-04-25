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

namespace InetApi.Net.Core
{
	/// <summary>
	/// A structure representing the statistics for a multipath traceroute.
	/// </summary>
	public struct MultipathTracerouteStatistics
	{
		/// <summary>
		/// The statistics state.
		/// </summary>
		public enum StatisticsState
		{
			Unknown = 0,
			Completed = 1,
			Unreachable = 2
		}

		/// <summary>
		/// The statistics state.
		/// </summary>
		public StatisticsState State { get; internal set; }
		/// <summary>
		/// The maximum time-to-live.
		/// </summary>
		public byte MaximumTimeToLive { get; internal set; }
	}
}
