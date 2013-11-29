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
using System.Collections.Generic;
using System.Xml.Linq;

namespace InetTools.Tools.CdnFinder
{
	/// <summary>
	/// A class representing the CDN Finder site information.
	/// </summary>
	public sealed class CdnFinderSite
	{
		private readonly List<CdnFinderResource> resources = new List<CdnFinderResource>();

		/// <summary>
		/// Creates a new site instance.
		/// </summary>
		/// <param name="site">The site name.</param>
		public CdnFinderSite(string site)
		{
			this.Site = site;
		}

		// Public properties.

		/// <summary>
		/// Gets whether the site was processed successfully.
		/// </summary>
		public bool Success { get; private set; }
		/// <summary>
		/// Gets the site name.
		/// </summary>
		public string Site { get; private set; }
		/// <summary>
		/// Gets the asset CDN name.
		/// </summary>
		public string AssetCdn { get; private set; }
		/// <summary>
		/// Gets the base CDN name.
		/// </summary>
		public string BaseCdn { get; private set; }
		/// <summary>
		/// Gets the collection of resources for this site.
		/// </summary>
		public ICollection<CdnFinderResource> Resources { get { return this.resources; } }

		// Public methods.

		public static CdnFinderSite Parse(XElement element)
		{
			// Create a new site object.
			CdnFinderSite site = new CdnFinderSite(element.Element("domain").Value);

			XElement status = element.Element("status");
			if ((null != status) && (status.Value.ToLower().Equals("failure")))
			{
				// Set success to false.
				site.Success = false;
			}
			else
			{
				// Set success to true.
				site.Success = true;
				// Parse the properties.
				site.AssetCdn = element.Element("assetcdn").Value;
				site.BaseCdn = element.Element("basecdn").Value;
				// Parse the site resources.
				foreach (XElement child in element.Elements("resource"))
				{
					site.resources.Add(CdnFinderResource.Parse(child));
				}
			}
			// Return the site object.
			return site;
		}
	}
}
