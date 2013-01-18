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
	public class AtomGdRating
	{
		private AtomGdRating() { }

		public static AtomGdRating Parse(XElement element)
		{
			AtomGdRating atom = new AtomGdRating();

			atom.Min = int.Parse(element.Attribute(XName.Get("min")).Value);
			atom.Max = int.Parse(element.Attribute(XName.Get("max")).Value);
			atom.NumRaters = int.Parse(element.Attribute(XName.Get("numRaters")).Value);
			atom.Average = double.Parse(element.Attribute(XName.Get("average")).Value);

			return atom;
		}

		public int Min { get; set; }
		public int Max { get; set; }
		public int NumRaters { get; set; }
		public double Average { get; set; }
	}
}
