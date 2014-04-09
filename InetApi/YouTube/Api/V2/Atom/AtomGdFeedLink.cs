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
using System.Xml.Linq;
using DotNetApi.Xml;
using InetCommon.Web;

namespace InetApi.YouTube.Api.V2.Atom
{
	/// <summary>
	/// A class representing a gd:feedLink atom.
	/// </summary>
	[Serializable]
	public sealed class AtomGdFeedLink : Atom
	{
		internal const string xmlPrefix = "gd";
		internal const string xmlName = "feedLink";

		/// <summary>
		/// Private constructor.
		/// </summary>
		/// <param name="element">The XML element.</param>
		private AtomGdFeedLink(XElement element)
			: base(xmlPrefix, xmlName, element)
		{
			XAttribute attr;

			// Mandatory attributes.
			this.Rel = element.Attribute("rel").Value;
			this.Href = element.Attribute("href").Value.ToUri();

			// Optional attributes.
			this.CountHint = (attr = element.Attribute("countHint")) != null ? attr.Value.ToInt() as int? : null;
		}

		// Public methods.

		/// <summary>
		/// Parses the XML element into a new atom instance.
		/// </summary>
		/// <param name="element">The XML element.</param>
		/// <param name="mandatory">Specified whether this element is mandatory.</param>
		/// <returns>The atom instance.</returns>
		public static AtomGdFeedLink Parse(XElement element, bool mandatory)
		{
			// If the element is null.
			if (null == element)
			{
				// If the element is mandatory, throw an exception.
				if (mandatory) throw new ArgumentNullException("element");
				else return null;
			}

			// Return a new atom instance.
			return new AtomGdFeedLink(element);
		}

		/// <summary>
		/// Parses the first child XML element into a new atom instance.
		/// </summary>
		/// <param name="element">The parent XML element.</param>
		/// <param name="mandatory">Specified whether this element is mandatory.</param>
		/// <returns>The atom instance.</returns>
		public static AtomGdFeedLink ParseChild(XElement element, bool mandatory)
		{
			// If the element is null, throw an exception.
			if (null == element) throw new ArgumentNullException("element");

			try
			{
				// Parse the children for the first element.
				return AtomGdFeedLink.Parse(element.Element(AtomGdFeedLink.xmlPrefix, AtomGdFeedLink.xmlName), mandatory);
			}
			catch (Exception exception)
			{
				// Throw a new atom exception.
				throw exception is AtomException ? exception : new AtomException("An error occurred while parsing the children of an XML element.", element, exception);
			}
		}

		// Properties.

		// Attributes.
		public string Rel { get; private set; }
		public Uri Href { get; private set; }
		public int? CountHint { get; private set; }
	}
}
