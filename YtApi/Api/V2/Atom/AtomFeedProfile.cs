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
	/// <summary>
	/// A class representing a profile feed atom.
	/// </summary>
	[Serializable]
	public sealed class AtomFeedProfile : AtomFeed
	{
		private AtomFeedProfile() { }

		/// <summary>
		/// Parse an XML string into an profile feed atom.
		/// </summary>
		/// <param name="data">The XML string.</param>
		/// <returns>The profile feed atom.</returns>
		public static AtomFeedProfile Parse(string data)
		{
			XElement element = XDocument.Parse(data).Root;
			XmlNamespace ns = new XmlNamespace(element);

			AtomFeedProfile atom = new AtomFeedProfile();

			try
			{
				AtomFeed.Parse(element, atom, ns);

				atom.Entry = new List<AtomEntry>();
				atom.EntryFailure = new List<AtomException>();
				foreach (XElement child in element.Elements(XName.Get("entry", ns["xmlns"])))
				{
					try
					{
						// Add the profile atom to the entries list, when parsed successfully.
						atom.Entry.Add(AtomEntryProfile.Parse(child, ns));
					}
					catch (AtomException exception)
					{
						// Otherwise, add the exception to entry failure list.
						atom.EntryFailure.Add(exception);
					}
				}
			}
			catch (Exception exception)
			{
				throw new AtomException("Cannot parse the profile feed.", element, ns, exception);
			}

			return atom;
		}
	}
}
