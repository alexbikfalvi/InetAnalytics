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
using System.Xml.Serialization;
using DotNetApi;

namespace InetCrawler.PlanetLab
{
	/// <summary>
	/// A structure representing the identifier of a PlanetLab history run.
	/// </summary>
	public struct PlManagerHistoryId
	{
		/// <summary>
		/// Creates a new PlanetLab manger history ID.
		/// </summary>
		/// <param name="slice">The slice.</param>
		/// <param name="startTime">The start time.</param>
		/// <param name="finishTime">The finish time.</param>
		public PlManagerHistoryId(int slice, DateTime startTime, DateTime finishTime)
			: this()
		{
			this.Slice = slice;
			this.StartTime = startTime;
			this.FinishTime = finishTime;
		}

		// Public properties.

		/// <summary>
		/// Gets the slice.
		/// </summary>
		[XmlAttribute("Slice")]
		public int Slice { get; private set; }
		/// <summary>
		/// Gets the start time.
		/// </summary>
		[XmlAttribute("StartTime")]
		public DateTime StartTime { get; private set; }
		/// <summary>
		/// Gets the finish time.
		/// </summary>
		[XmlAttribute("FinishTime")]
		public DateTime FinishTime { get; private set; }
		/// <summary>
		/// Gets the file name corresponding to this identifier.
		/// </summary>
		public string FileName
		{
			get
			{
				return CrawlerConfig.Static.PlanetLabHistoryRunFileName.FormatWith(
					this.Slice,
					this.StartTime.Year, this.StartTime.Month, this.StartTime.Day, this.StartTime.Hour, this.StartTime.Minute, this.StartTime.Second,
					this.FinishTime.Year, this.FinishTime.Month, this.FinishTime.Day, this.FinishTime.Hour, this.FinishTime.Minute, this.FinishTime.Second
					);
			}
		}

		// Public methods.

		/// <summary>
		/// Converts this history identifier to a string.
		/// </summary>
		/// <returns>The string.</returns>
		public override string ToString()
		{
			return "Started at: {0} - Finished at: {1}".FormatWith(this.StartTime, this.FinishTime);
		}
	}
}
