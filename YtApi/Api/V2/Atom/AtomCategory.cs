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
	public sealed class AtomCategory : Atom
	{
		private AtomCategory() { }

		public static AtomCategory Parse(XElement element)
		{
			AtomCategory atom = new AtomCategory();
			XAttribute attr;

			// Mandatory attributes
			atom.Scheme = new Uri(element.Attribute(XName.Get("scheme")).Value);
			atom.Term = element.Attribute(XName.Get("term")).Value;

			// Optional attributes
			atom.Label = (attr = element.Attribute(XName.Get("label"))) != null ? attr.Value : null;

			return atom;
		}

		public Uri Scheme { get; set; }
		public string Term { get; set; }
		public string Label { get; set; }
	}
}
