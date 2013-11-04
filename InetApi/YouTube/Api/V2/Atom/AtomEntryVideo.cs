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
using System.Xml.Linq;
using DotNetApi.Xml;

namespace InetApi.YouTube.Api.V2.Atom
{
	/// <summary>
	/// A class representing a video entry.
	/// </summary>
	[Serializable]
	public sealed class AtomEntryVideo : AtomEntry
	{
		/// <summary>
		/// Private constructor.
		/// </summary>
		/// <param name="element">The XML element.</param>
		private AtomEntryVideo(XElement element)
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
				this.MediaGroup = AtomMediaGroup.ParseChild(element, false);
				this.YtStatistics = AtomYtStatistics.ParseChild(element, false);
				this.GdComments = AtomGdComments.ParseChild(element, false);
				this.GdRating = AtomGdRating.ParseChild(element, false);
				this.YtRating = AtomYtRating.ParseChild(element, false);
				this.YtLocation = AtomYtLocation.ParseChild(element, false);
				this.YtRecorded = AtomYtRecorded.ParseChild(element, false);
				this.YtAccessControlList = AtomYtAccessControlList.ParseChildren(element);
				this.YtAvailability = AtomYtAvailability.ParseChild(element, false);
				this.YtEpisode = AtomYtEpisode.ParseChild(element, false);
				this.YtFavoriteId = AtomYtFavoriteId.ParseChild(element, false);
				this.YtFirstReleased = AtomYtFirstReleased.ParseChild(element, false);
				this.YtMaterials = AtomYtMaterialList.ParseChildren(element);
				this.GeoRssWhere = AtomGeoRssWhere.ParseChild(element, false);
				this.AppControl = AtomAppControl.ParseChild(element, false);
			}
			catch (Exception exception)
			{
				throw new AtomException("Cannot parse video entry.", element, exception);
			}
		}

		// Public methods.

		/// <summary>
		/// Parses an XML string into a video entry atom.
		/// </summary>
		/// <param name="data">The XML string.</param>
		/// <returns>The video entry atom.</returns>
		public static AtomEntryVideo Parse(string data)
		{
			return AtomEntryVideo.Parse(XDocument.Parse(data).Root, true);
		}

		/// <summary>
		/// Parses the XML element into a new atom instance.
		/// </summary>
		/// <param name="element">The XML element.</param>
		/// <param name="mandatory">Specified whether this element is mandatory.</param>
		/// <returns>The atom instance.</returns>
		public static AtomEntryVideo Parse(XElement element, bool mandatory)
		{
			// If the element is null.
			if (null == element)
			{
				// If the element is mandatory, throw an exception.
				if (mandatory) throw new ArgumentNullException("element");
				else return null;
			}

			// Return a new atom instance.
			return new AtomEntryVideo(element);
		}

		/// <summary>
		/// Parses the first child XML element into a new atom instance.
		/// </summary>
		/// <param name="element">The parent XML element.</param>
		/// <param name="mandatory">Specified whether this element is mandatory.</param>
		/// <returns>The atom instance.</returns>
		public static AtomEntryVideo ParseChild(XElement element, bool mandatory)
		{
			// If the element is null, throw an exception.
			if (null == element) throw new ArgumentNullException("element");

			try
			{
				// Parse the children for the first element.
				return AtomEntryVideo.Parse(element.Element(AtomEntryVideo.xmlPrefix, AtomEntryVideo.xmlName), mandatory);
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
		public AtomMediaGroup MediaGroup { get; private set; }
		public AtomYtStatistics YtStatistics { get; private set; }
		public AtomGdComments GdComments { get; private set; }
		public AtomGdRating GdRating { get; private set; }
		public AtomYtRating YtRating { get; private set; }
		public AtomYtLocation YtLocation { get; private set; }
		public AtomYtRecorded YtRecorded { get; private set; }
		public AtomYtAccessControlList YtAccessControlList { get; private set; }
		public AtomYtAvailability YtAvailability { get; private set; }
		public AtomYtEpisode YtEpisode { get; private set; }
		public AtomYtFavoriteId YtFavoriteId { get; private set; }
		public AtomYtFirstReleased YtFirstReleased { get; private set; }
		public AtomYtMaterialList YtMaterials { get; private set; }
		public AtomGeoRssWhere GeoRssWhere { get; private set; }
		public AtomAppControl AppControl { get; private set; }
	}
}
