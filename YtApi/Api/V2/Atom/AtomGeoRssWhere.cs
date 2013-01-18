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
	[Serializable]
	public sealed class AtomGeoRssWhere : Atom
	{
		private AtomGeoRssWhere() { }

		public static AtomGeoRssWhere Parse(XElement element, XmlNamespace top)
		{
			AtomGeoRssWhere atom = new AtomGeoRssWhere();
			XmlNamespace ns = new XmlNamespace(element, top);

			atom.GmlPoint = AtomGmlPoint.Parse(element.Element(XName.Get("Point", ns["gml"])), ns);

			return atom;
		}

		public AtomGmlPoint GmlPoint { get; set; }
	}
}
