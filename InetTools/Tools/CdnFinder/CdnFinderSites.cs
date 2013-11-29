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
using System.Xml.Linq;

namespace InetTools.Tools.CdnFinder
{
	/// <summary>
	/// A class representing the list of CDN Finder sites.
	/// </summary>
	public sealed class CdnFinderSites : IEnumerable<CdnFinderSite>
	{
		private readonly List<CdnFinderSite> sites = new List<CdnFinderSite>();

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
				sites.sites.Add(CdnFinderSite.Parse(child));
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
	}
}
