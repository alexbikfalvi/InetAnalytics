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
using System.Xml.Linq;
using DotNetApi.Xml;

namespace InetApi.YouTube.Api.V2.Atom
{
	/// <summary>
	/// A class representing a user entry.
	/// </summary>
	[Serializable]
	public sealed class AtomEntryProfile : AtomEntry
	{
		/// <summary>
		/// Private constructor.
		/// </summary>
		/// <param name="element">The XML element.</param>
		private AtomEntryProfile(XElement element)
			: base(element)
		{
			try
			{
				this.Published = AtomPublished.ParseChild(element, false);
				this.Updated = AtomUpdated.ParseChild(element, true);
				this.Categories = AtomCategoryList.ParseChildren(element);
				this.Title = AtomTitle.ParseChild(element, true);
				this.Content = AtomContent.ParseChild(element, false);
				this.Author = AtomAuthor.ParseChild(element, false);
				this.YtAboutMe = AtomYtAboutMe.ParseChild(element, false);
				this.YtAge = AtomYtAge.ParseChild(element, false);
				this.YtBooks = AtomYtBooks.ParseChild(element, false);
				this.YtCompany = AtomYtCompany.ParseChild(element, false);
				this.YtFirstName = AtomYtFirstName.ParseChild(element, false);
				this.YtGender = AtomYtGender.ParseChild(element, false);
				this.YtHobbies = AtomYtHobbies.ParseChild(element, false);
				this.YtHometown = AtomYtHometown.ParseChild(element, false);
				this.YtLastName = AtomYtLastName.ParseChild(element, false);
				this.YtLocation = AtomYtLocation.ParseChild(element, false);
				this.YtMaxUploadDuration = AtomYtMaxUploadDuration.ParseChild(element, false);
				this.YtMovies = AtomYtMovies.ParseChild(element, false);
				this.YtMusic = AtomYtMusic.ParseChild(element, false);
				this.YtOccupation = AtomYtOccupation.ParseChild(element, false);
				this.YtSchool = AtomYtSchool.ParseChild(element, false);
				this.YtUserId = AtomYtUserId.ParseChild(element, false);
				this.YtUserName = AtomYtUsername.ParseChild(element, false);
				this.YtStatistics = AtomYtStatistics.ParseChild(element, false);
				this.Summary = AtomSummary.ParseChild(element, false);
				this.MediaThumbnail = AtomMediaThumbnail.ParseChild(element, false);
				this.GdFeedLinks = AtomGdFeedLinkList.ParseChildren(element);
			}
			catch (Exception exception)
			{
				throw new AtomException("Cannot parse user entry.", element, exception);
			}
		}

		/// <summary>
		/// Parses an XML string into a user entry atom.
		/// </summary>
		/// <param name="data">The XML string.</param>
		/// <returns>The user entry atom.</returns>
		public static AtomEntryProfile Parse(string data)
		{
			return AtomEntryProfile.Parse(XDocument.Parse(data).Root, true);
		}

		/// <summary>
		/// Parses the XML element into a new atom instance.
		/// </summary>
		/// <param name="element">The XML element.</param>
		/// <param name="mandatory">Specified whether this element is mandatory.</param>
		/// <returns>The atom instance.</returns>
		public static AtomEntryProfile Parse(XElement element, bool mandatory)
		{
			// If the element is null.
			if (null == element)
			{
				// If the element is mandatory, throw an exception.
				if (mandatory) throw new ArgumentNullException("element");
				else return null;
			}

			// Return a new atom instance.
			return new AtomEntryProfile(element);
		}

		/// <summary>
		/// Parses the first child XML element into a new atom instance.
		/// </summary>
		/// <param name="element">The parent XML element.</param>
		/// <param name="mandatory">Specified whether this element is mandatory.</param>
		/// <returns>The atom instance.</returns>
		public static AtomEntryProfile ParseChild(XElement element, bool mandatory)
		{
			// If the element is null, throw an exception.
			if (null == element) throw new ArgumentNullException("element");

			try
			{
				// Parse the children for the first element.
				return AtomEntryProfile.Parse(element.Element(AtomEntryProfile.xmlPrefix, AtomEntryProfile.xmlName), mandatory);
			}
			catch (Exception exception)
			{
				// Throw a new atom exception.
				throw exception is AtomException ? exception : new AtomException("An error occurred while parsing the children of an XML element.", element, exception);
			}
		}

		// Properties.

		// Elements.
		public AtomPublished Published { get; private set; }
		public AtomUpdated Updated { get; private set; }
		public AtomCategoryList Categories { get; private set; }
		public AtomTitle Title { get; private set; }
		public AtomContent Content { get; private set; }
		public AtomAuthor Author { get; private set; }
		public AtomYtAboutMe YtAboutMe { get; private set; }
		public AtomYtAge YtAge { get; private set; }
		public AtomYtBooks YtBooks { get; private set; }
		public AtomYtCompany YtCompany { get; private set; }
		public AtomYtFirstName YtFirstName { get; private set; }
		public AtomYtGender YtGender { get; private set; }
		public AtomYtHobbies YtHobbies { get; private set; }
		public AtomYtHometown YtHometown { get; private set; }
		public AtomYtLastName YtLastName { get; private set; }
		public AtomYtLocation YtLocation { get; private set; }
		public AtomYtMaxUploadDuration YtMaxUploadDuration { get; private set; }
		public AtomYtMovies YtMovies { get; private set; }
		public AtomYtMusic YtMusic { get; private set; }
		public AtomYtOccupation YtOccupation { get; private set; }
		public AtomYtSchool YtSchool { get; private set; }
		public AtomYtUserId YtUserId { get; private set; }
		public AtomYtUsername YtUserName { get; private set; }
		public AtomYtStatistics YtStatistics { get; private set; }
		public AtomSummary Summary { get; private set; }
		public AtomMediaThumbnail MediaThumbnail { get; private set; }
		public AtomGdFeedLinkList GdFeedLinks { get; private set; }
	}
}
