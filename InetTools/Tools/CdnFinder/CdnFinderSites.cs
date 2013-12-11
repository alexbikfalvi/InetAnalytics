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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Linq;

namespace InetTools.Tools.CdnFinder
{
	/// <summary>
	/// A class representing the list of CDN Finder sites.
	/// </summary>
	public sealed class CdnFinderSites : IEnumerable<CdnFinderSite>
	{
		private readonly List<CdnFinderSite> sites = new List<CdnFinderSite>();
		private readonly HashSet<string> resources = new HashSet<string>();

		/// <summary>
		/// Creates a new empty sites list.
		/// </summary>
		public CdnFinderSites()
		{
		}

		// Public properties.

		/// <summary>
		/// Gets the number of sites in the collection.
		/// </summary>
		public int Count { get { return this.sites.Count; } }
		/// <summary>
		/// Gets the collection of resources.
		/// </summary>
		public IEnumerable<string> Resources { get { return this.resources; } }

		// Public methods.

		/// <summary>
		/// Returns the generic enumerator for the current sites collection.
		/// </summary>
		/// <returns>The enumerator.</returns>
		public IEnumerator<CdnFinderSite> GetEnumerator()
		{
			return this.sites.GetEnumerator();
		}

		/// <summary>
		/// Returns the non-generic enumerator for the current sites collection.
		/// </summary>
		/// <returns>The enumerator.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		/// <summary>
		/// Parses a new sites list from the specified XML element.
		/// </summary>
		/// <param name="element">The XML element.</param>
		/// <returns>The sites list.</returns>
		public static CdnFinderSites Parse(XElement element)
		{
			// Create a new sites object.
			CdnFinderSites sites = new CdnFinderSites();
			// Parse all sites.
			foreach (XElement child in element.Elements("domains"))
			{
				// Parse the site.
				CdnFinderSite site = CdnFinderSite.Parse(child);
				// Add the site.
				sites.sites.Add(site);
				// Add the site resources.
				foreach (CdnFinderResource resource in site.Resources)
				{
					// If the resources already exists, do nothing.
					if (sites.resources.Contains(resource.Hostname)) continue;
					// Add the resource.
					sites.resources.Add(resource.Hostname);
				}
			}
			// Return the sites list.
			return sites;
		}

		/// <summary>
		/// Parses the specified string into a new sites list.
		/// </summary>
		/// <param name="data">The strinf corresponding to the CDN finder XML format.</param>
		/// <returns>The sites list.</returns>
		public static CdnFinderSites Parse(string data)
		{
			// Create the XML document.
			XDocument xml = XDocument.Parse(data);
			// Parse the document.
			return CdnFinderSites.Parse(xml.Root);
		}

		/// <summary>
		/// Saves the sites information to the specified file.
		/// </summary>
		/// <param name="fileName">The file name.</param>
		public void SaveSites(string fileName)
		{
			//// Create the root XML element.
			//XElement sites = new XElement("Sites");

			//// For all sites.
			//foreach (CdnFinderSite site in this)
			//{
			//	// Create the resources element.
			//	XElement resources = new XElement("Resources");

			//	// For all site resources.
			//	foreach (CdnFinderResource resource in site.Resources)
			//	{
			//		// Create the CNAMEs element.
			//		XElement cnames = new XElement("CNames");

			//		// For all CNAMEs.
			//		foreach (string cname in resource.CNames)
			//		{
			//			cnames.Add(new XElement("CName", cname));
			//		}

			//		// Add the resource element.
			//		resources.Add(new XElement("Resource",
			//			new XAttribute("Hostname", resource.Hostname != null ? resource.Hostname : string.Empty),
			//			new XAttribute("Count", resource.Count),
			//			new XAttribute("Size", resource.Size),
			//			new XAttribute("Cdn", resource.Cdn != null ? resource.Cdn : string.Empty),
			//			new XAttribute("HeaderGuess", resource.HeaderGuess != null ? resource.HeaderGuess : string.Empty),
			//			new XAttribute("IsBase", resource.IsBase),
			//			cnames));
			//	}

			//	// Add the site element.
			//	sites.Add(new XElement("Site",
			//		new XAttribute("Success", site.Success),
			//		new XElement("Name", site.Site),
			//		new XElement("AssetCdn", site.AssetCdn != null ? site.AssetCdn : string.Empty),
			//		new XElement("BaseCdn", site.BaseCdn != null ? site.BaseCdn : string.Empty),
			//		resources
			//		));
			//}

			// Create a new XML document for the sites data.
			XDocument document = new XDocument(
				new XElement("Sites", from site in this select new XElement("Site",
					new XAttribute("Success", site.Success),
					new XElement("Name", site.Site),
					new XElement("AssetCdn", site.AssetCdn != null ? site.AssetCdn : string.Empty),
					new XElement("BaseCdn", site.BaseCdn != null ? site.BaseCdn : string.Empty),
					new XElement("Resources", from resource in site.Resources select new XElement("Resource",
						new XAttribute("Hostname", resource.Hostname != null ? resource.Hostname : string.Empty),
						new XAttribute("Count", resource.Count),
						new XAttribute("Size", resource.Size),
						new XAttribute("Cdn", resource.Cdn != null ? resource.Cdn : string.Empty),
						new XAttribute("HeaderGuess", resource.HeaderGuess != null ? resource.HeaderGuess : string.Empty),
						new XAttribute("IsBase", resource.IsBase),
						new XElement("CNames", from cname in resource.CNames select new XElement("CName", cname))
						))
					))
				);

			// Save the document.
			document.Save(fileName, SaveOptions.None);
		}


		/// <summary>
		/// Saves the resources to the specified text file.
		/// </summary>
		/// <param name="fileName">The file name.</param>
		public void SaveResources(string fileName)
		{
			// Create a new file.
			using (StreamWriter file = new StreamWriter(fileName, false))
			{
				// Add all elements.
				foreach (string resource in this.resources)
				{
					file.WriteLine(resource);
				}
			}
		}
	}
}
