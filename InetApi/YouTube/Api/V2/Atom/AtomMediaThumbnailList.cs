/* 
 * Copyright (C) 2012-2013 Alex Bikfalvi
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
using DotNetApi.Xml;

namespace InetApi.YouTube.Api.V2.Atom
{
	/// <summary>
	/// A class representing a list of media:thumbnail atoms.
	/// </summary>
	public sealed class AtomMediaThumbnailList : IEnumerable<AtomMediaThumbnail>
	{
		private readonly List<AtomMediaThumbnail> links = new List<AtomMediaThumbnail>();

		/// <summary>
		/// Private constructor.
		/// </summary>
		/// <param name="elements">The XML elements.</param>
		private AtomMediaThumbnailList(IEnumerable<XElement> elements)
		{
			foreach (XElement element in elements)
			{
				this.links.Add(AtomMediaThumbnail.Parse(element, true));
			}
		}

		// Public mehods.

		/// <summary>
		/// Parses the enumeration of XML elements into an atom list.
		/// </summary>
		/// <param name="elements">The XML elements.</param>
		/// <returns>The atom list.</returns>
		public static AtomMediaThumbnailList Parse(IEnumerable<XElement> elements)
		{
			// If the elements are null, throw an exception.
			if (null == elements) throw new ArgumentNullException("elements");

			// Return a new atom instance.
			return new AtomMediaThumbnailList(elements);
		}

		/// <summary>
		/// Parses the children XML elements into an atom list.
		/// </summary>
		/// <param name="element">The parent XML element.</param>
		/// <returns>The atom list.</returns>
		public static AtomMediaThumbnailList ParseChildren(XElement element)
		{
			// Parse the children elements.
			return AtomMediaThumbnailList.Parse(element.Elements(AtomMediaThumbnail.xmlPrefix, AtomMediaThumbnail.xmlName));
		}

		/// <summary>
		/// Returns the enumerator for the list of categories.
		/// </summary>
		/// <returns>The enumerator.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		/// <summary>
		/// Returns the enumerator for the list of categories.
		/// </summary>
		/// <returns>The enumerator.</returns>
		public IEnumerator<AtomMediaThumbnail> GetEnumerator()
		{
			return this.links.GetEnumerator();
		}
	}
}
