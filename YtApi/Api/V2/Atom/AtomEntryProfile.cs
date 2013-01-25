/* 
 * Copyright (C) 2013 Alex Bikfalvi
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
	/// A class representing a user entry.
	/// </summary>
	[Serializable]
	public sealed class AtomEntryProfile : AtomEntry
	{
		private AtomEntryProfile() { }

		/// <summary>
		/// Parses an XML string into a user entry atom.
		/// </summary>
		/// <param name="data">The XML string.</param>
		/// <returns>The user entry atom.</returns>
		public static AtomEntryProfile Parse(string data)
		{
			return AtomEntryProfile.Parse(XDocument.Parse(data).Root);
		}

		/// <summary>
		/// Parses an XML entry element into a user entry atom.
		/// </summary>
		/// <param name="element">The XML element.</param>
		/// <returns>The user entry atom.</returns>
		public static AtomEntryProfile Parse(XElement element, XmlNamespace top = null)
		{
			AtomEntryProfile atom = new AtomEntryProfile();
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
				atom.YtAboutMe = (el = element.Element(XName.Get("aboutMe", ns["yt"]))) != null ? AtomYtAboutMe.Parse(el) : null;
				atom.YtAge = (el = element.Element(XName.Get("age", ns["yt"]))) != null ? AtomYtAge.Parse(el) : null;
				atom.YtBooks = (el = element.Element(XName.Get("books", ns["yt"]))) != null ? AtomYtBooks.Parse(el) : null;
				atom.YtCompany = (el = element.Element(XName.Get("company", ns["yt"]))) != null ? AtomYtCompany.Parse(el) : null;
				atom.YtFirstName = (el = element.Element(XName.Get("firstName", ns["yt"]))) != null ? AtomYtFirstName.Parse(el) : null;
				atom.YtGender = (el = element.Element(XName.Get("gender", ns["yt"]))) != null ? AtomYtGender.Parse(el) : null;
				atom.YtHobbies = (el = element.Element(XName.Get("hobbies", ns["yt"]))) != null ? AtomYtHobbies.Parse(el) : null;
				atom.YtHometown = (el = element.Element(XName.Get("hometown", ns["yt"]))) != null ? AtomYtHometown.Parse(el) : null;
				atom.YtLastName = (el = element.Element(XName.Get("lastName", ns["yt"]))) != null ? AtomYtLastName.Parse(el) : null;
				atom.YtLocation = (el = element.Element(XName.Get("location", ns["yt"]))) != null ? AtomYtLocation.Parse(el) : null;
				atom.YtMaxUploadDuration = (el = element.Element(XName.Get("maxUploadDuration", ns["yt"]))) != null ? AtomYtMaxUploadDuration.Parse(el) : null;
				atom.YtMovies = (el = element.Element(XName.Get("movies", ns["yt"]))) != null ? AtomYtMovies.Parse(el) : null;
				atom.YtMusic = (el = element.Element(XName.Get("music", ns["yt"]))) != null ? AtomYtMusic.Parse(el) : null;
				atom.YtOccupation = (el = element.Element(XName.Get("occupation", ns["yt"]))) != null ? AtomYtOccupation.Parse(el) : null;
				atom.YtSchool = (el = element.Element(XName.Get("school", ns["yt"]))) != null ? AtomYtSchool.Parse(el) : null;
				atom.YtUserId = (el = element.Element(XName.Get("userId", ns["yt"]))) != null ? AtomYtUserId.Parse(el) : null;
				atom.YtUserName = (el = element.Element(XName.Get("username", ns["yt"]))) != null ? AtomYtUsername.Parse(el) : null;
				atom.YtStatistics = (el = element.Element(XName.Get("statistics", ns["yt"]))) != null ? AtomYtStatistics.Parse(el) : null;
				atom.Summary = (el = element.Element(XName.Get("summary", ns["xmlns"]))) != null ? AtomSummary.Parse(el) : null;
				atom.MediaThumbnail = (el = element.Element(XName.Get("thumbnail", ns["media"]))) != null ? AtomMediaThumbnail.Parse(el, ns) : null;
				atom.GdFeedLink = new List<AtomGdFeedLink>();
				foreach (XElement child in element.Elements(XName.Get("feedLink", ns["gd"])))
					atom.GdFeedLink.Add(AtomGdFeedLink.Parse(child));
			}
			catch (Exception exception)
			{
				throw new AtomException("Cannot parse user entry.", element, ns, exception);
			}

			return atom;
		}

		public AtomPublished Published { get; set; }
		public AtomUpdated Updated { get; set; }
		public List<AtomCategory> Category { get; set; }
		public AtomTitle Title { get; set; }
		public AtomContent Content { get; set; }
		public AtomAuthor Author { get; set; }
		public AtomYtAboutMe YtAboutMe { get; set; }
		public AtomYtAge YtAge { get; set; }
		public AtomYtBooks YtBooks { get; set; }
		public AtomYtCompany YtCompany { get; set; }
		public AtomYtFirstName YtFirstName { get; set; }
		public AtomYtGender YtGender { get; set; }
		public AtomYtHobbies YtHobbies { get; set; }
		public AtomYtHometown YtHometown { get; set; }
		public AtomYtLastName YtLastName { get; set; }
		public AtomYtLocation YtLocation { get; set; }
		public AtomYtMaxUploadDuration YtMaxUploadDuration { get; set; }
		public AtomYtMovies YtMovies { get; set; }
		public AtomYtMusic YtMusic { get; set; }
		public AtomYtOccupation YtOccupation { get; set; }
		public AtomYtSchool YtSchool { get; set; }
		public AtomYtUserId YtUserId { get; set; }
		public AtomYtUsername YtUserName { get; set; }
		public AtomYtStatistics YtStatistics { get; set; }
		public AtomSummary Summary { get; set; }
		public AtomMediaThumbnail MediaThumbnail { get; set; }
		public List<AtomGdFeedLink> GdFeedLink { get; set; }
	}
}
