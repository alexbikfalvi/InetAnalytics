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

namespace YtApi.Api.V2.Atom
{
	/// <summary>
	/// Represents the base class of an entry atom.
	/// </summary>
	[Serializable]
	public abstract class AtomEntry : Atom
	{
		internal const string xmlPrefix = null;
		internal const string xmlName = "entry";

		/// <summary>
		/// Creates a new atom instance.
		/// </summary>
		/// <param name="element">The XML element.</param>
		protected AtomEntry(XElement element)
			: base(xmlPrefix, xmlName, element)
		{
			// Set the elements.
			this.Id = AtomId.ParseChild(element, true);
			this.Links = AtomLinkList.ParseChildren(element);
		}

		// Properties.

		// Elements.
		public AtomId Id { get; private set; }
		public AtomLinkList Links { get; private set; }
	}
}
