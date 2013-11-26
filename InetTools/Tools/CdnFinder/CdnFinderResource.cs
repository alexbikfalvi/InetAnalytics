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
	/// A class representing a CDN Finder resource.
	/// </summary>
	public sealed class CdnFinderResource
	{
		public readonly List<string> cnames = new List<string>();

		/// <summary>
		/// Creates a new resource object for the specified hostname.
		/// </summary>
		/// <param name="hostname">The hostname.</param>
		public CdnFinderResource(string hostname)
		{
			this.Hostname = hostname;
		}

		// Public properties.

		/// <summary>
		/// Gets the resources count.
		/// </summary>
		public int Count { get; private set; }
		/// <summary>
		/// Gets the resources size in bytes.
		/// </summary>
		public int Size { get; private set; }
		/// <summary>
		/// Gets the guessed CDN from header.
		/// </summary>
		public string HeaderGuess { get; private set; }
		/// <summary>
		/// Gets whether this is a base resource.
		/// </summary>
		public bool IsBase { get; private set; }
		/// <summary>
		/// Gets the resource hostname.
		/// </summary>
		public string Hostname { get; private set; }
		/// <summary>
		/// Gets the list of CNAME records.
		/// </summary>
		public IEnumerable<string> CNames { get { return this.cnames; } }
		/// <summary>
		/// Gets the CDN name.
		/// </summary>
		public string Cdn { get; private set; }

		// Public methods.

		/// <summary>
		/// Parses the object from the specified XML element.
		/// </summary>
		/// <param name="element">The XML element.</param>
		public static CdnFinderResource Parse(XElement element)
		{
			// Create a new resource object.
			CdnFinderResource resource = new CdnFinderResource(element.Element("hostname").Value);
			// Parse the properties.
			resource.Count = int.Parse(element.Element("count").Value);
			resource.Size = int.Parse(element.Element("bytes").Value);
			resource.IsBase = bool.Parse(element.Element("isbase").Value);
			resource.Cdn = element.Element("cdn").Value;
			// Parse the CNAME records.
			foreach (XElement child in element.Elements("cnames"))
			{
				resource.cnames.Add(child.Value);
			}
			// Return the object.
			return resource;
		}
	}
}
