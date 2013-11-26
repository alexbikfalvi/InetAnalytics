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
	/// A class representing the list of CDN Finder domains.
	/// </summary>
	public sealed class CdnFinderDomains : IEnumerable<CdnFinderDomain>
	{
		private readonly List<CdnFinderDomain> domains = new List<CdnFinderDomain>();

		/// <summary>
		/// Creates a new empty domains list.
		/// </summary>
		public CdnFinderDomains()
		{
		}

		// Public properties.

		/// <summary>
		/// Gets the number of domains in the collection.
		/// </summary>
		public int Count { get { return this.domains.Count; } }

		// Public methods.

		/// <summary>
		/// Returns the generic enumerator for the current domains collection.
		/// </summary>
		/// <returns>The enumerator.</returns>
		public IEnumerator<CdnFinderDomain> GetEnumerator()
		{
			return this.domains.GetEnumerator();
		}

		/// <summary>
		/// Returns the non-generic enumerator for the current domains collection.
		/// </summary>
		/// <returns>The enumerator.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		/// <summary>
		/// Parses a new domains list from the specified XML element.
		/// </summary>
		/// <param name="element">The XML element.</param>
		/// <returns>The domains list.</returns>
		public static CdnFinderDomains Parse(XElement element)
		{
			// Create a new domains object.
			CdnFinderDomains domains = new CdnFinderDomains();
			// Parse all domains.
			foreach (XElement child in element.Elements("domains"))
			{
				domains.domains.Add(CdnFinderDomain.Parse(child));
			}
			// Return the domains list.
			return domains;
		}

		/// <summary>
		/// Parses the specified string into a new domains list.
		/// </summary>
		/// <param name="data">The strinf corresponding to the CDN finder XML format.</param>
		/// <returns>The domains list.</returns>
		public static CdnFinderDomains Parse(string data)
		{
			// Create the XML document.
			XDocument xml = XDocument.Parse(data);
			// Parse the document.
			return CdnFinderDomains.Parse(xml.Root);
		}
	}
}
