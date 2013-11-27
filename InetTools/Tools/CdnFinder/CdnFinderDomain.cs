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
	/// A class representing the CDN Finder domain information.
	/// </summary>
	public sealed class CdnFinderDomain
	{
		private readonly List<CdnFinderResource> resources = new List<CdnFinderResource>();

		/// <summary>
		/// Creates a new domain instance.
		/// </summary>
		/// <param name="domain">The domain name.</param>
		public CdnFinderDomain(string domain)
		{
			this.Domain = domain;
		}

		// Public properties.

		/// <summary>
		/// Gets whether the domain was processed successfully.
		/// </summary>
		public bool Success { get; private set; }
		/// <summary>
		/// Gets the domain name.
		/// </summary>
		public string Domain { get; private set; }
		/// <summary>
		/// Gets the asset CDN name.
		/// </summary>
		public string AssetCdn { get; private set; }
		/// <summary>
		/// Gets the base CDN name.
		/// </summary>
		public string BaseCdn { get; private set; }
		/// <summary>
		/// Gets the collection of resources for this domain.
		/// </summary>
		public ICollection<CdnFinderResource> Resources { get { return this.resources; } }

		// Public methods.

		public static CdnFinderDomain Parse(XElement element)
		{
			// Create a new domain object.
			CdnFinderDomain domain = new CdnFinderDomain(element.Element("domain").Value);

			XElement status = element.Element("status");
			if ((null != status) && (status.Value.ToLower().Equals("failure")))
			{
				// Set success to false.
				domain.Success = false;
			}
			else
			{
				// Set success to true.
				domain.Success = true;
				// Parse the properties.
				domain.AssetCdn = element.Element("assetcdn").Value;
				domain.BaseCdn = element.Element("basecdn").Value;
				// Parse the domain resources.
				foreach (XElement child in element.Elements("resource"))
				{
					domain.resources.Add(CdnFinderResource.Parse(child));
				}
			}
			// Return the domain object.
			return domain;
		}
	}
}
