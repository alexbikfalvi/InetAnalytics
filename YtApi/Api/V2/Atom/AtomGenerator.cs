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
	public sealed class AtomGenerator : Atom
	{
		private AtomGenerator() { }

		public static AtomGenerator Parse(XElement element)
		{
			AtomGenerator atom = new AtomGenerator();

			// Attributes
			atom.Version = element.Attribute(XName.Get("version")).Value;
			atom.Uri = new Uri(element.Attribute(XName.Get("uri")).Value);

			// Value
			atom.Value = element.Value;

			return atom;
		}

		public string Version { get; set; }
		public Uri Uri { get; set; }

		public string Value { get; set; }
	}
}
