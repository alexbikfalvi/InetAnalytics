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
	public sealed class PlanetLab : IDisposable
	{
		private CrawlerConfig config;

		private PlList<PlSite> sites = new PlList<PlSite>();
		private PlList<PlSlice> slices = new PlList<PlSlice>();

		/// <summary>
		/// Creates anew PlanetLab configuration with the specified configuration.
		/// </summary>
		/// <param name="config">The crawler configuration.</param>
		public PlanetLab(CrawlerConfig config)
		{
			// Set the crawler configuration.
			this.config = config;

			try
			{
				// Load the PlanetLab sites configuration.
				this.sites.LoadFromFile(this.config.PlanetLabConfig.SitesFileName);
			}
			catch { }
		}

		// Public properties.

		/// <summary>
		/// Gets the collection of PlanetLab sites.
		/// </summary>
		public PlList<PlSite> Sites { get { return this.sites; } }
		/// <summary>
		/// Gets the collection of PlanetLab slices.
		/// </summary>
		public PlList<PlSlice> Slices { get { return this.slices; } }

		// Public methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			try
			{
				// Save the PlanetLab configuration.
				this.Sites.SaveToFile(this.config.PlanetLabConfig.SitesFileName);
			}
			catch { }
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}
	}
}
