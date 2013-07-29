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
using System.Xml.Linq;
using DotNetApi.Xml;

namespace YtApi.Api.V2.Atom
{
	/// <summary>
	/// A class representing a feed this.
	/// </summary>
	[Serializable]
	public abstract class AtomFeed : Atom
	{
		internal const string xmlPrefix = null;
		internal const string xmlName = "feed";

		/// <summary>
		/// Creates a new atom instance.
		/// </summary>
		/// <param name="element">The XML element.</param>
		protected AtomFeed(XElement element)
			: base(xmlPrefix, xmlName, element)
		{
			this.Id = AtomId.ParseChild(element, true);
			this.Updated = AtomUpdated.ParseChild(element, true);
			this.Categories = AtomCategoryList.ParseChildren(element);
			this.Title = AtomTitle.ParseChild(element, true);
			this.Subtitle = AtomSubtitle.ParseChild(element, false);
			this.Logo = AtomLogo.ParseChild(element, false);
			this.Links = AtomLinkList.ParseChildren(element);
			this.Author = AtomAuthor.ParseChild(element, false);
			this.Generator = AtomGenerator.ParseChild(element, false);
			this.OpenSearchItemsPerPage = AtomOpenSearchItemsPerPage.ParseChild(element, false);
			this.OpenSearchStartIndex = AtomOpenSearchStartIndex.ParseChild(element, false);
			this.OpenSearchTotalResults = AtomOpenSearchTotalResults.ParseChild(element, false);
			this.MediaGroup = AtomMediaGroup.ParseChild(element, false);
			this.YtMaterials = AtomYtMaterialList.ParseChildren(element);
			this.BatchOperation = AtomBatchOperation.ParseChild(element, false);
			this.Entries = new AtomEntryList();
			this.Failures = new AtomExceptionList();
		}

		// Properties.

		public AtomId Id { get; private set; }
		public AtomUpdated Updated { get; private set; }
		public AtomCategoryList Categories { get; private set; }
		public AtomTitle Title { get; private set; }
		public AtomSubtitle Subtitle { get; private set; }
		public AtomLogo Logo { get; private set; }
		public AtomLinkList Links { get; private set; }
		public AtomAuthor Author { get; private set; }
		public AtomGenerator Generator { get; private set; }
		public AtomOpenSearchItemsPerPage OpenSearchItemsPerPage { get; private set; }
		public AtomOpenSearchStartIndex OpenSearchStartIndex { get; private set; }
		public AtomOpenSearchTotalResults OpenSearchTotalResults { get; private set; }
		public AtomMediaGroup MediaGroup { get; private set; }
		public AtomYtMaterialList YtMaterials { get; private set; }
		public AtomBatchOperation BatchOperation { get; private set; }
		public AtomEntryList Entries { get; private set; }
		public AtomExceptionList Failures { get; private set; }
	}
}
