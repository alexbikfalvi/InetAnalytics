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
	public sealed class AtomYtMaterial : Atom
	{
		private AtomYtMaterial() { }

		public static AtomYtMaterial Parse(XElement element)
		{
			AtomYtMaterial atom = new AtomYtMaterial();

			atom.Description = element.Attribute(XName.Get("description")).Value;
			atom.Name = element.Attribute(XName.Get("name")).Value;
			atom.Type = element.Attribute(XName.Get("type")).Value;
			atom.Url = element.Attribute(XName.Get("url")).Value;

			return atom;
		}

		public string Description { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public string Url { get; set; }
	}
}
