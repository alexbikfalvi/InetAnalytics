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
	public sealed class AtomYtStatistics : Atom
	{
		private AtomYtStatistics() { }

		public static AtomYtStatistics Parse(XElement element)
		{
			AtomYtStatistics atom = new AtomYtStatistics();
			XAttribute attr;

			// Mandatory attributes
			atom.ViewCount = int.Parse(element.Attribute(XName.Get("viewCount")).Value);

			// Optional attributes
			atom.VideoWatchCount = (attr = element.Attribute(XName.Get("videoWatchCount"))) != null ? (int?)int.Parse(attr.Value) : null;
			atom.SubscriberCount = (attr = element.Attribute(XName.Get("subscriberCount"))) != null ? (int?)int.Parse(attr.Value) : null;
			atom.LastWebAccess = (attr = element.Attribute(XName.Get("lastWebAccess"))) != null ? (DateTime?)DateTime.Parse(attr.Value) : null;
			atom.FavoriteCount = (attr = element.Attribute(XName.Get("favoriteCount"))) != null ? (int?)int.Parse(attr.Value) : null;
			atom.TotalUploadViews = (attr = element.Attribute(XName.Get("totalUploadViews"))) != null ? (int?)int.Parse(attr.Value) : null;

			return atom;
		}

		public int ViewCount { get; set; }
		public int? VideoWatchCount { get; set; }
		public int? SubscriberCount { get; set; }
		public DateTime? LastWebAccess { get; set; }
		public int? FavoriteCount { get; set; }
		public int? TotalUploadViews { get; set; }
	}
}
