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
	public sealed class AtomMediaContent : Atom
	{
		private AtomMediaContent() { }

		public static AtomMediaContent Parse(XElement element, XmlNamespace top)
		{
			AtomMediaContent atom = new AtomMediaContent();
			XAttribute attr;
			XmlNamespace ns = new XmlNamespace(element, top);

			// Mandatory attributes
			atom.Url = new Uri(element.Attribute(XName.Get("url")).Value);
			atom.YtFormat = element.Attribute(XName.Get("format", ns["yt"])).Value;

			// Optional attributes
			atom.Type = (attr = element.Attribute(XName.Get("type"))) != null ? attr.Value : null;
			atom.Duration = (attr = element.Attribute(XName.Get("duration"))) != null ? (int?)int.Parse(attr.Value) : null;
			atom.IsDefault = (attr = element.Attribute(XName.Get("isDefault"))) != null ? (bool?)bool.Parse(attr.Value) : null;
			atom.YtName = (attr = element.Attribute(XName.Get("name", ns["yt"]))) != null ? attr.Value : null;

			return atom;
		}

		// Mandatory attributes
		public Uri Url { get; set; }
		public string Type { get; set; }
		public string Expression { get; set; }
		public int? Duration { get; set; }
		public string YtFormat { get; set; }
		public string YtName { get; set; }

		// Optional attributes
		public bool? IsDefault { get; set; }
	}
}
