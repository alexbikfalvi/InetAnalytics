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

namespace YtApi.Api.V2.Atom
{
	/// <summary>
	/// A class representing a playlist entry atom.
	/// </summary>
	[Serializable]
	public class AtomEntryPlaylist : AtomEntry
	{
		/// <summary>
		/// Private constructor.
		/// </summary>
		/// <param name="element">The XML element.</param>
		private AtomEntryPlaylist(XElement element)
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
				this.Summary = AtomSummary.ParseChild(element, false);
				this.YtPlaylistId = AtomYtPlaylistId.ParseChild(element, true);
				this.YtCountHint = AtomYtCountHint.ParseChild(element, true);
			}
			catch (Exception exception)
			{
				throw new AtomException("Cannot parse playlist entry.", element, exception);
			}
		}

		/// <summary>
		/// Parses an XML string into a comment entry atom.
		/// </summary>
		/// <param name="data">The XML string.</param>
		/// <returns>The comment entry atom.</returns>
		public static AtomEntryPlaylist Parse(string data)
		{
			return AtomEntryPlaylist.Parse(XDocument.Parse(data).Root, true);
		}

		/// <summary>
		/// Parses the XML element into a new atom instance.
		/// </summary>
		/// <param name="element">The XML element.</param>
		/// <param name="mandatory">Specified whether this element is mandatory.</param>
		/// <returns>The atom instance.</returns>
		public static AtomEntryPlaylist Parse(XElement element, bool mandatory)
		{
			// If the element is null.
			if (null == element)
			{
				// If the element is mandatory, throw an exception.
				if (mandatory) throw new ArgumentNullException("element");
				else return null;
			}

			// Return a new atom instance.
			return new AtomEntryPlaylist(element);
		}

		/// <summary>
		/// Parses the first child XML element into a new atom instance.
		/// </summary>
		/// <param name="element">The parent XML element.</param>
		/// <param name="mandatory">Specified whether this element is mandatory.</param>
		/// <returns>The atom instance.</returns>
		public static AtomEntryPlaylist ParseChild(XElement element, bool mandatory)
		{
			// If the element is null, throw an exception.
			if (null == element) throw new ArgumentNullException("element");

			try
			{
				// Parse the children for the first element.
				return AtomEntryPlaylist.Parse(element.Element(AtomEntryPlaylist.xmlPrefix, AtomEntryPlaylist.xmlName), mandatory);
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
		public AtomSummary Summary { get; private set; }
		public AtomYtPlaylistId YtPlaylistId { get; private set; }
		public AtomYtCountHint YtCountHint { get; private set; }
	}
}
