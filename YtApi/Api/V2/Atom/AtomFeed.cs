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
	public abstract class AtomFeed : Atom
	{
		protected AtomFeed() { }

		protected static void Parse(XElement element, AtomFeed atom, XmlNamespace top)
		{
			XElement el;
			XmlNamespace ns = new XmlNamespace(element, top);

			atom.Id = AtomId.Parse(element.Element(XName.Get("id", ns["xmlns"])));
			atom.Updated = AtomUpdated.Parse(element.Element(XName.Get("updated", ns["xmlns"])));
			atom.Category = new List<AtomCategory>();
			foreach (XElement child in element.Elements(XName.Get("category", ns["xmlns"])))
				atom.Category.Add(AtomCategory.Parse(child));
			atom.Title = AtomTitle.Parse(element.Element(XName.Get("title", ns["xmlns"])));
			atom.Subtitle = (el = element.Element(XName.Get("subtitle", ns["xmlns"]))) != null ? AtomSubtitle.Parse(el) : null;
			atom.Logo = (el = element.Element(XName.Get("logo", ns["xmlns"]))) != null ? AtomLogo.Parse(el) : null;
			atom.Link = new List<AtomLink>();
			foreach (XElement child in element.Elements(XName.Get("link", ns["xmlns"])))
				atom.Link.Add(AtomLink.Parse(child, ns));
			atom.Author = (el = element.Element(XName.Get("author", ns["xmlns"]))) != null ? AtomAuthor.Parse(el, ns) : null;
			atom.Generator = (el = element.Element(XName.Get("generator", ns["xmlns"]))) != null ? AtomGenerator.Parse(el) : null;
			atom.OpenSearchItemsPerPage = (el = element.Element(XName.Get("itemsPerPage", ns["openSearch"]))) != null ? AtomOpenSearchItemsPerPage.Parse(el) : null;
			atom.OpenSearchStartIndex = (el = element.Element(XName.Get("startIndex", ns["openSearch"]))) != null ? AtomOpenSearchStartIndex.Parse(el) : null;
			atom.OpenSearchTotalResults = (el = element.Element(XName.Get("totalResults", ns["openSearch"]))) != null ? AtomOpenSearchTotalResults.Parse(el) : null;
			atom.MediaGroup = (el = element.Element(XName.Get("group", ns["openSearch"]))) != null ? AtomMediaGroup.Parse(el, ns) : null;
			atom.YtMaterial = new List<AtomYtMaterial>();
			foreach (XElement child in element.Elements(XName.Get("material", ns["openSearch"])))
				atom.YtMaterial.Add(AtomYtMaterial.Parse(child));
			atom.BatchOperation = (el = element.Element(XName.Get("operation", ns["openSearch"]))) != null ? AtomBatchOperation.Parse(el) : null;
		}

		public AtomId Id { get; set; }
		public AtomUpdated Updated { get; set; }
		public List<AtomCategory> Category { get; set; }
		public AtomTitle Title { get; set; }
		public AtomSubtitle Subtitle { get; set; }
		public AtomLogo Logo { get; set; }
		public List<AtomLink> Link { get; set; }
		public AtomAuthor Author { get; set; }
		public AtomGenerator Generator { get; set; }
		public AtomOpenSearchItemsPerPage OpenSearchItemsPerPage { get; set; }
		public AtomOpenSearchStartIndex OpenSearchStartIndex { get; set; }
		public AtomOpenSearchTotalResults OpenSearchTotalResults { get; set; }
		public AtomMediaGroup MediaGroup { get; set; }
		public List<AtomYtMaterial> YtMaterial { get; set; }
		public AtomBatchOperation BatchOperation { get; set; }
		public List<AtomEntry> Entry { get; set; }
		public List<AtomException> EntryFailure { get; set; }
	}
}
