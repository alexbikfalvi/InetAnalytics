﻿/* 
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
	public sealed class AtomLink : Atom
	{
		private AtomLink() { }

		public static AtomLink Parse(XElement element, XmlNamespace top)
		{
			AtomLink atom = new AtomLink();
			XAttribute attr;
			XmlNamespace ns = new XmlNamespace(element, top);

			// Mandatory attributes
			atom.Rel = element.Attribute(XName.Get("rel")).Value;
			atom.Type = element.Attribute(XName.Get("type")).Value;
			atom.Href = new Uri(element.Attribute(XName.Get("href")).Value);

			// Optional attributes
			atom.YtHasEntries = (attr = element.Attribute(XName.Get("hasEntries", ns["yt"]))) != null ? (bool?)bool.Parse(attr.Value) : null;

			return atom;
		}

		public string Rel { get; set; }
		public string Type { get; set; }
		public Uri Href { get; set; }
		public bool? YtHasEntries { get; set; }
	}
}
