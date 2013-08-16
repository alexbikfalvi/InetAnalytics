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
using DotNetApi;
using DotNetApi.Xml;

namespace YtApi.Api.V2.Atom
{
	/// <summary>
	/// Base class for an atom object.
	/// </summary>
	[Serializable]
	public abstract class Atom
	{
		/// <summary>
		/// Creates a new atom instance.
		/// </summary>
		/// <param name="xmlPrefix">The XML prefix.</param>
		/// <param name="xmlName">The XML name.</param>
		/// <param name="element">The XML element.</param>
		protected Atom(string xmlPrefix, string xmlName, XElement element)
		{
			// Check the XML element name.
			if (!element.HasName(xmlPrefix, xmlName))
			{
				bool b = element.HasName(xmlPrefix, xmlName);
				throw new AtomException("XML element name mismatch. Current name is \'{0}:{1}\'. Expected name is \'{2}:{3}\'".FormatWith(
					element.GetPrefixOfNamespace(element.Name.Namespace), element.Name.LocalName, xmlPrefix, xmlName), element);
			}
		}
	}
}
