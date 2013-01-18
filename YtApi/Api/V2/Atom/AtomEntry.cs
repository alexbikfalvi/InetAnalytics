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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace YtApi.Api.V2.Atom
{
	/// <summary>
	/// Represents the base class of an atom entry.
	/// </summary>
	[Serializable]
	public abstract class AtomEntry : Atom
	{
		protected AtomEntry() { }

		public static void Parse(XElement element, AtomEntry atom, XmlNamespace top)
		{
			XmlNamespace ns = new XmlNamespace(element, top);

			atom.Id = AtomId.Parse(element.Element(XName.Get("id", ns["xmlns"])));
			atom.Link = new List<AtomLink>();
			foreach (XElement child in element.Elements(XName.Get("link", ns["xmlns"])))
				atom.Link.Add(AtomLink.Parse(child, ns));
		}

		public AtomId Id { get; set; }
		public List<AtomLink> Link { get; set; }
	}
}
