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
using PlanetLab.Api;

namespace YtCrawler.PlanetLab
{
	/// <summary>
	/// A class representing the PlanetLab configuration.
	/// </summary>
	public class PlanetLab
	{
		private PlSites sites = new PlSites();

		/// <summary>
		/// Creates anew PlanetLab configuration with the specified configuration.
		/// </summary>
		/// <param name="config">The crawler configuration.</param>
		public PlanetLab(CrawlerConfig config)
		{
		}

		/// <summary>
		/// Gets the collection of Planet-Lab sites.
		/// </summary>
		public PlSites Sites { get { return this.sites; } }
	}
}
