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
	public class AtomEntryUser : AtomEntry
	{
		private AtomEntryUser() { }

		/// <summary>
		/// Parses an XML string into a user entry atom.
		/// </summary>
		/// <param name="data">The XML string.</param>
		/// <returns>The user entry atom.</returns>
		public static AtomEntryUser Parse(string data)
		{
			return AtomEntryUser.Parse(XDocument.Parse(data).Root);
		}

		/// <summary>
		/// Parses an XML entry element into a user entry atom.
		/// </summary>
		/// <param name="element">The XML element.</param>
		/// <returns>The user entry atom.</returns>
		public static AtomEntryUser Parse(XElement element, XmlNamespace top = null)
		{
			AtomEntryUser atom = new AtomEntryUser();
			XmlNamespace ns = new XmlNamespace(element, top);
			XElement el;

			try
			{
				AtomEntry.Parse(element, atom, ns);
			}
			catch (Exception exception)
			{
				throw new AtomException("Cannot parse user entry.", element, ns, exception);
			}

			return atom;
		}
	}
}
