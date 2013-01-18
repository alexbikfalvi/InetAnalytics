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
	public sealed class AtomMediaThumbnail : Atom
	{
		private AtomMediaThumbnail() { }

		public static AtomMediaThumbnail Parse(XElement element, XmlNamespace top)
		{
			AtomMediaThumbnail atom = new AtomMediaThumbnail();
			XmlNamespace ns = new XmlNamespace(element, top);
			XAttribute attr;

			// Mandatory attributes
			atom.Url = new Uri(element.Attribute(XName.Get("url")).Value);
			atom.Height = int.Parse(element.Attribute(XName.Get("height")).Value);
			atom.Width = int.Parse(element.Attribute(XName.Get("width")).Value);

			// Optional attributes
			atom.Time = (attr = element.Attribute(XName.Get("time"))) != null ? TimeSpan.Parse(attr.Value) as TimeSpan? : null;
			atom.YtName = (attr = element.Attribute(XName.Get("name", ns["yt"]))) != null ? attr.Value : null;

			return atom;
		}

		public Uri Url { get; set; }
		public int Height { get; set; }
		public int Width { get; set; }
		public TimeSpan? Time { get; set; }
		public string YtName { get; set; }
	}
}
