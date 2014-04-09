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
using InetCommon.Web;

namespace InetApi.YouTube.Api.V2.Atom
{
	/// <summary>
	/// A class representing a profile feed atom.
	/// </summary>
	[Serializable]
	public sealed class AtomFeedProfile : AtomFeed
	{
		/// <summary>
		/// Creates a new atom instance.
		/// </summary>
		/// <param name="element">The XML element.</param>
		private AtomFeedProfile(XElement element)
			: base(element)
		{
			try
			{
				foreach (XElement child in element.Elements(AtomEntry.xmlPrefix, AtomEntry.xmlName))
				{
					try
					{
						// Add the profile atom to the entries list, when parsed successfully.
						this.Entries.Add(AtomEntryProfile.Parse(child, true));
					}
					catch (AtomException exception)
					{
						// Otherwise, add the exception to entry failure list.
						this.Failures.Add(exception);
					}
				}
			}
			catch (Exception exception)
			{
				throw new AtomException("Cannot parse the profile feed.", element, exception);
			}
		}

		/// <summary>
		/// Parse an XML string into an profile feed atom.
		/// </summary>
		/// <param name="data">The XML string.</param>
		/// <returns>The profile feed atom.</returns>
		public static AtomFeedProfile Parse(string data)
		{
			return new AtomFeedProfile(XDocument.Parse(data).Root);
		}
	}
}
