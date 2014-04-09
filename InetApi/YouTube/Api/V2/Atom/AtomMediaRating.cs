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
	/// A class representing a media:rating atom.
	/// </summary>
	[Serializable]
	public sealed class AtomMediaRating : Atom
	{
		internal const string xmlPrefix = "media";
		internal const string xmlName = "rating";

		/// <summary>
		/// Private constructor.
		/// </summary>
		/// <param name="element">The XML element.</param>
		private AtomMediaRating(XElement element)
			: base(xmlPrefix, xmlName, element)
		{
			// Mandatory attributes
			this.Scheme = element.Attribute("scheme").Value;

			// Optional attributes
			this.Country = this.Scheme.Equals("http://gdata.youtube.com/schemas/2007#mediarating") ? element.Attribute("country").Value : null;

			// Value
			this.Value = element.Value;
		}

		// Public methods.

		/// <summary>
		/// Parses the XML element into a new atom instance.
		/// </summary>
		/// <param name="element">The XML element.</param>
		/// <param name="mandatory">Specified whether this element is mandatory.</param>
		/// <returns>The atom instance.</returns>
		public static AtomMediaRating Parse(XElement element, bool mandatory)
		{
			// If the element is null.
			if (null == element)
			{
				// If the element is mandatory, throw an exception.
				if (mandatory) throw new ArgumentNullException("element");
				else return null;
			}

			// Return a new atom instance.
			return new AtomMediaRating(element);
		}

		/// <summary>
		/// Parses the first child XML element into a new atom instance.
		/// </summary>
		/// <param name="element">The parent XML element.</param>
		/// <param name="mandatory">Specified whether this element is mandatory.</param>
		/// <returns>The atom instance.</returns>
		public static AtomMediaRating ParseChild(XElement element, bool mandatory)
		{
			// If the element is null, throw an exception.
			if (null == element) throw new ArgumentNullException("element");

			try
			{
				// Parse the children for the first element.
				return AtomMediaRating.Parse(element.Element(AtomMediaRating.xmlPrefix, AtomMediaRating.xmlName), mandatory);
			}
			catch (Exception exception)
			{
				// Throw a new atom exception.
				throw exception is AtomException ? exception : new AtomException("An error occurred while parsing the children of an XML element.", element, exception);
			}
		}

		// Properties.

		// Mandatory attributes.
		public string Scheme { get; private set; }

		// Optional attributes.
		public string Country { get; private set; }

		// Value.
		public string Value { get; private set; }
	}
}
