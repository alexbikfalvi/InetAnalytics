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
using System.Xml.Linq;

namespace YtApi.Api.V2.Atom
{
	/// <summary>
	/// A class representing a playlist entry.
	/// </summary>
	[Serializable]
	public class AtomEntryPlaylist : AtomEntry
	{
		private AtomEntryPlaylist() { }

		/// <summary>
		/// Parses an XML string into a comment entry atom.
		/// </summary>
		/// <param name="data">The XML string.</param>
		/// <returns>The comment entry atom.</returns>
		public static AtomEntryPlaylist Parse(string data)
		{
			return AtomEntryPlaylist.Parse(XDocument.Parse(data).Root);
		}

		/// <summary>
		/// Parses an XML entry element into a comment entry atom.
		/// </summary>
		/// <param name="element">The XML element.</param>
		/// <returns>The comment entry atom.</returns>
		public static AtomEntryPlaylist Parse(XElement element, XmlNamespace top = null)
		{
			AtomEntryPlaylist atom = new AtomEntryPlaylist();
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
				atom.Summary = (el = element.Element(XName.Get("summary", ns["xmlns"]))) != null ? AtomSummary.Parse(el) : null;
				atom.YtPlaylistId = AtomYtPlaylistId.Parse(element.Element(XName.Get("playlistId", ns["yt"])));
				atom.YtCountHint = AtomYtCountHint.Parse(element.Element(XName.Get("countHint", ns["yt"])));
			}
			catch (Exception exception)
			{
				throw new AtomException("Cannot parse playlist entry.", element, ns, exception);
			}

			return atom;
		}

		public AtomPublished Published { get; set; }
		public AtomUpdated Updated { get; set; }
		public List<AtomCategory> Category { get; set; }
		public AtomTitle Title { get; set; }
		public AtomContent Content { get; set; }
		public AtomAuthor Author { get; set; }
		public AtomSummary Summary { get; set; }
		public AtomYtPlaylistId YtPlaylistId { get; set; }
		public AtomYtCountHint YtCountHint { get; set; }
	}
}
