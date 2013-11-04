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
using InetApi.YouTube.Api.V2.Atom;

namespace InetApi.YouTube.Api.V2.Data
{
	public sealed class Feed<T> where T : Entry, new()
	{
		private AtomFeed atom;

		private CategoryList categories;
		private LinkList links;
		private List<T> entries;
		private YouTubeAtomExceptionList exceptionsEntry;
		private AtomExceptionList exceptionsEntryAtom;
		private Author author;

		/// <summary>
		/// Creates a new video feed object based on an atom instance.
		/// </summary>
		/// <param name="atom">The atom instance.</param>
		public Feed(AtomFeed atom) 
		{
			this.atom = atom;

			this.categories = new CategoryList(this.atom.Categories);

			this.links = new LinkList(this.atom.Links);

            this.author = new Author(this.atom.Author);

			this.entries = new List<T>();
			this.exceptionsEntry = new YouTubeAtomExceptionList();
			foreach (AtomEntry entry in this.atom.Entries)
			{
				// Try to add a new feed entry.
				try
				{
					using (T obj = new T())
					{
						this.entries.Add(obj.Create(entry) as T);
					}
				}
				catch (Exception exception)
				{
					// If parsing the atom fails, add the atom and the exception to the failure list.
					this.exceptionsEntry.Add(new YouTubeAtomException("Cannot parse the entry atom.", exception, entry));
				}
			}
			this.exceptionsEntryAtom = this.atom.Failures;
		}

		/// <summary>
		/// The feed ID. It cannot be null.
		/// </summary>
		public string Id { get { return this.atom.Id.Value; } }

		/// <summary>
		/// The date/time when the feed was last updated. It cannot be null.
		/// </summary>
		public DateTime Updated { get { return this.atom.Updated.Value; } }

		/// <summary>
		/// A list of categories to which the feed belongs. It cannot be null, but the list may be empty.
		/// </summary>
		public CategoryList Categories { get { return this.categories; } }

		/// <summary>
		/// The feed title. It cannot be null.
		/// </summary>
		public string Title { get { return this.atom.Title.Value; } }

		/// <summary>
		/// The feed subtitle. It can be null.
		/// </summary>
		public string Subtitle { get { return this.atom.Subtitle.Value; } }

		/// <summary>
		/// The feed logo. It can be null.
		/// </summary>
		public string Logo { get { return this.atom.Logo.Value; } }

		/// <summary>
		/// A list of links relevant to the feed. It cannot be null, but the list may be empty.
		/// </summary>
		public LinkList Links { get { return this.links; } }

		/// <summary>
		/// The author of the feed. It can be null.
		/// </summary>
		public Author Author { get { return this.author; } }

		/// <summary>
		/// The number of items per page for the entries in the feed. It can be null.
		/// </summary>
		public int? SearchItemsPerPage { get { return this.atom.OpenSearchItemsPerPage != null ? this.atom.OpenSearchItemsPerPage.Value as int? : null; } }

		/// <summary>
		/// The start index for the entries in the feed. It can be null.
		/// </summary>
		public int? SearchStartIndex { get { return this.atom.OpenSearchStartIndex != null ? this.atom.OpenSearchStartIndex.Value as int? : null; } }
		
		/// <summary>
		/// The number of total entries for the feed. It can be null.
		/// </summary>
		public int? SearchTotalResults { get { return this.atom.OpenSearchTotalResults != null ? this.atom.OpenSearchTotalResults.Value as int? : null; } }

		/// <summary>
		/// The collection of feed entries. It cannot be null, but the collection may be empty.
		/// </summary>
		public ICollection<T> Entries { get { return this.entries; } }

		/// <summary>
		/// The collection of feed entries that could not be parsed from the corresponding atom.
		/// In cannot be null, but the collection may be empty.
		/// </summary>
		public YouTubeAtomExceptionList FailuresEntry { get { return this.exceptionsEntry; } }

		/// <summary>
		/// The collection of exceptions for 
		/// </summary>
		public AtomExceptionList FailuresAtom { get { return this.exceptionsEntryAtom; } }
	}
}
