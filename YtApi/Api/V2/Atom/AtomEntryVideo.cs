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
	/// <summary>
	/// A class representing a video entry.
	/// </summary>
	[Serializable]
	public sealed class AtomEntryVideo : AtomEntry
	{
		private AtomEntryVideo() { }

		/// <summary>
		/// Parses an XML string into a video entry atom.
		/// </summary>
		/// <param name="data">The XML string.</param>
		/// <returns>The video entry atom.</returns>
		public static AtomEntryVideo Parse(string data)
		{
			return AtomEntryVideo.Parse(XDocument.Parse(data).Root);
		}

		/// <summary>
		/// Parses an XML entry element into a video entry atom.
		/// </summary>
		/// <param name="element">The XML element.</param>
		/// <returns>The video entry atom.</returns>
		public static AtomEntryVideo Parse(XElement element, XmlNamespace top = null)
		{
			AtomEntryVideo atom = new AtomEntryVideo();
			XmlNamespace ns = new XmlNamespace(element, top);
			XElement el;

			try
			{
				AtomEntry.Parse(element, atom, ns);

				atom.Published = (el = element.Element(XName.Get("published", ns["xmlns"]))) != null ? AtomPublished.Parse(el) : null;
				atom.Updated = AtomUpdated.Parse(element.Element(XName.Get("updated", ns["xmlns"])));
				atom.Category = new List<AtomCategory>();
				foreach (XElement child in element.Elements(XName.Get("category", ns["xmlns"])))
					atom.Category.Add(AtomCategory.Parse(child));
				atom.Title = AtomTitle.Parse(element.Element(XName.Get("title", ns["xmlns"])));
				atom.Content = (el = element.Element(XName.Get("content", ns["xmlns"]))) != null ? AtomContent.Parse(el) : null;
				atom.Author = (el = element.Element(XName.Get("author", ns["xmlns"]))) != null ? AtomAuthor.Parse(el, ns) : null;
				atom.MediaGroup = (el = element.Element(XName.Get("group", ns["media"]))) != null ? AtomMediaGroup.Parse(el, ns) : null;
				atom.YtStatistics = (el = element.Element(XName.Get("statistics", ns["yt"]))) != null ? AtomYtStatistics.Parse(el) : null;
				atom.GdComments = (el = element.Element(XName.Get("comments", ns["gd"]))) != null ? AtomGdComments.Parse(el, ns) : null;
				atom.GdRating = (el = element.Element(XName.Get("rating", ns["gd"]))) != null ? AtomGdRating.Parse(el) : null;
				atom.YtRating = (el = element.Element(XName.Get("rating", ns["yt"]))) != null ? AtomYtRating.Parse(el) : null;
				atom.YtLocation = (el = element.Element(XName.Get("location", ns["yt"]))) != null ? AtomYtLocation.Parse(el) : null;
				atom.YtRecorded = (el = element.Element(XName.Get("recorded", ns["yt"]))) != null ? AtomYtRecorded.Parse(el) : null;
				atom.YtAccessControl = new List<AtomYtAccessControl>();
				foreach (XElement child in element.Elements(XName.Get("accessControl", ns["yt"])))
					atom.YtAccessControl.Add(AtomYtAccessControl.Parse(child));
				atom.YtAvailability = (el = element.Element(XName.Get("availability", ns["yt"]))) != null ? AtomYtAvailability.Parse(el) : null;
				atom.YtEpisode = (el = element.Element(XName.Get("episode", ns["yt"]))) != null ? AtomYtEpisode.Parse(el) : null;
				atom.YtFavoriteId = (el = element.Element(XName.Get("favoriteId", ns["yt"]))) != null ? AtomYtFavoriteId.Parse(el) : null;
				atom.YtFirstReleased = (el = element.Element(XName.Get("firstReleased", ns["yt"]))) != null ? AtomYtFirstReleased.Parse(el) : null;
				atom.YtMaterial = new List<AtomYtMaterial>();
				foreach (XElement child in element.Elements(XName.Get("material", ns["yt"])))
					atom.YtMaterial.Add(AtomYtMaterial.Parse(child));
				atom.GeoRssWhere = (el = element.Element(XName.Get("where", ns["geoRss"]))) != null ? AtomGeoRssWhere.Parse(el, ns) : null;
				atom.AppControl = (el = element.Element(XName.Get("control", ns["app"]))) != null ? AtomAppControl.Parse(el, ns) : null;
			}
			catch (Exception exception)
			{
				throw new AtomException("Cannot parse video entry.", element, ns, exception);
			}

			return atom;
		}

		public AtomPublished Published { get; set; }
		public AtomUpdated Updated { get; set; }
		public List<AtomCategory> Category { get; set; }
		public AtomTitle Title { get; set; }
		public AtomContent Content { get; set; }
		public AtomAuthor Author { get; set; }
		public AtomMediaGroup MediaGroup { get; set; }
		public AtomYtStatistics YtStatistics { get; set; }
		public AtomGdComments GdComments { get; set; }
		public AtomGdRating GdRating { get; set; }
		public AtomYtRating YtRating { get; set; }
		public AtomYtLocation YtLocation { get; set; }
		public AtomYtRecorded YtRecorded { get; set; }
		public List<AtomYtAccessControl> YtAccessControl { get; set; }
		public AtomYtAvailability YtAvailability { get; set; }
		public AtomYtEpisode YtEpisode { get; set; }
		public AtomYtFavoriteId YtFavoriteId { get; set; }
		public AtomYtFirstReleased YtFirstReleased { get; set; }
		public List<AtomYtMaterial> YtMaterial { get; set; }
		public AtomGeoRssWhere GeoRssWhere { get; set; }
		public AtomAppControl AppControl { get; set; }
	}
}
