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
	public sealed class AtomMediaCredit : Atom
	{
		private AtomMediaCredit() { }

		public static AtomMediaCredit Parse(XElement element, XmlNamespace top)
		{
			AtomMediaCredit atom = new AtomMediaCredit();
			XAttribute attr;
			XmlNamespace ns = new XmlNamespace(element, top);

			// Mandatory attributes
			atom.Role = element.Attribute(XName.Get("role")).Value;
			atom.Scheme = element.Attribute(XName.Get("scheme")).Value;

			// Optional attributes
			atom.YtDisplay = (attr = element.Attribute(XName.Get("display", ns["yt"]))) != null ? attr.Value : null;
			atom.YtType = (attr = element.Attribute(XName.Get("type", ns["yt"]))) != null ? attr.Value : null;

			// Value
			atom.Value = element.Value;

			return atom;
		}

		// Mandatory attributes
		public string Role { get; set; }
		public string Scheme { get; set; }
		public string YtDisplay { get; set; }

		// Optional attributes
		public string YtType { get; set; }

		// Value
		public string Value { get; set; }
	}
}
