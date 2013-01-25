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
using YtApi.Api.V2.Atom;

namespace YtApi.Api.V2.Data
{
    /// <summary>
    /// A YouTube data link.
    /// </summary>
	[Serializable]
	public sealed class Link
	{
		private AtomLink atom;

		/// <summary>
		/// Creates a new link object based on an atom instance.
		/// </summary>
		/// <param name="atom"></param>
		public Link(AtomLink atom)
		{
			this.atom = atom;
		}

		public string Rel { get { return this.atom.Rel; } }
		public string Type { get { return this.atom.Type; } }
		public Uri Href { get { return this.atom.Href; } }
		public bool? HasEntries { get { return this.atom.YtHasEntries; } }
	}

    /// <summary>
    /// A YouYube data link list.
    /// </summary>
    public class LinkList : List<Link>
    {
		private Uri previous = null;
		private Uri next = null;

        /// <summary>
        /// Creates a link list based on a collection of atom objects.
        /// </summary>
        /// <param name="atoms"></param>
        public LinkList(ICollection<AtomLink> atoms)
            : base(atoms.Count)
        {
			foreach (AtomLink atom in atoms)
			{
				this.Add(new Link(atom));
				switch (atom.Rel.ToLower())
				{
					case "previous": this.previous = atom.Href; break;
					case "next": this.next = atom.Href; break;
				}	
			}
        }

		/// <summary>
		/// Returns the previous link.
		/// </summary>
		public Uri Previous { get { return this.previous; } }
		/// <summary>
		/// Returns the next link.
		/// </summary>
		public Uri Next { get { return this.next; } }
    }
}
