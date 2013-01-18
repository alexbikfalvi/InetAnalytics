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
	public sealed class AtomAuthor : Atom
	{
		private AtomAuthor() { }

		public static AtomAuthor Parse(XElement element, XmlNamespace top)
		{
			AtomAuthor atom = new AtomAuthor();
			XmlNamespace ns = new XmlNamespace(element, top);
			XElement el;

			// Mandatory elements
			atom.Name = AtomName.Parse(element.Element(XName.Get("name", ns["xmlns"])));

			// Optional elements
			atom.Uri = (el = element.Element(XName.Get("uri", ns["xmlns"]))) != null ? AtomUri.Parse(el) : null;
			atom.YtUserId = (el = element.Element(XName.Get("userId", ns["yt"]))) != null ? AtomYtUserId.Parse(el) : null;

			return atom;
		}

		public AtomName Name { get; set; }
		public AtomUri Uri { get; set; }
		public AtomYtUserId YtUserId { get; set; }
	}
}
