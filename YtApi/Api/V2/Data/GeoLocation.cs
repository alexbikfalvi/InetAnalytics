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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YtApi.Api.V2.Atom;

namespace YtApi.Api.V2.Data
{
	/// <summary>
	/// Identifies a geographic location.
	/// </summary>
	public class GeoLocation
	{
		private double latitude;
		private double longitude;

		private static char[] locationSeparator = { ' ' };

		/// <summary>
		/// Creates a new geographical location object based on an atom instance.
		/// </summary>
		/// <param name="atom"></param>
		public GeoLocation(AtomGeoRssWhere atom)
		{
			if (null == atom.GmlPoint) throw new YouTubeException("Cannot create a new geo location object: the atom object must have a \"gml:point\" child element.");
			if (null == atom.GmlPoint.GmlPos) throw new YouTubeException("Cannot create a new geo location object: the atom object must have a \"gml:pos\" child element.");

			// Get the location tokens
			string[] tokens = atom.GmlPoint.GmlPos.Value.Split(GeoLocation.locationSeparator, StringSplitOptions.RemoveEmptyEntries); 

			// Check the number of tokens is two
			if (2 != tokens.Length) throw new YouTubeException(string.Format("Cannot create a new geo location object: the \"gml:pos\" must have two numbers separated by space: \"{0}\".", atom.GmlPoint.GmlPos.Value));

			// Convert the values
			try
			{
				this.latitude = double.Parse(tokens[0]);
				this.longitude = double.Parse(tokens[1]);
			}
			catch (Exception exception)
			{
				throw new YouTubeException(string.Format("Cannot create a new geo location object: the \"gml:pos\" must have two numbers separated by space: \"{0}\".", atom.GmlPoint.GmlPos.Value), exception);
			}
		}

		public double Latitude { get { return this.latitude; } }
		public double Longitude { get { return this.longitude; } }
	}
}
