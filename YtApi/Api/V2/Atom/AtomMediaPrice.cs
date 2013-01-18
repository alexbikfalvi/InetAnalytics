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
	public sealed class AtomMediaPrice : Atom
	{
		private AtomMediaPrice() { }

		public static AtomMediaPrice Parse(XElement element, XmlNamespace top)
		{
			AtomMediaPrice atom = new AtomMediaPrice();
			XmlNamespace ns = new XmlNamespace(element, top);

			atom.Type = element.Attribute(XName.Get("type")).Value;
			atom.Price = decimal.Parse(element.Attribute(XName.Get("price")).Value);
			atom.Currency = element.Attribute(XName.Get("currency")).Value;
			atom.YtDuration = TimeSpan.Parse(element.Attribute(XName.Get("duration",ns["yt"])).Value);

			return atom;
		}

		public string Type { get; set; }
		public decimal Price { get; set; }
		public string Currency { get; set; }
		public TimeSpan YtDuration { get; set; }
	}
}
