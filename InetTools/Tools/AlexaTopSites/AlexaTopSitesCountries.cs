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

namespace InetTools.Tools.AlexaTopSites
{
	/// <summary>
	/// A class representing the list of Alexa countries.
	/// </summary>
	public sealed class AlexaTopSitesCountries : List<AlexaTopSitesCountry>
	{
		/// <summary>
		/// Creates a new countries instance.
		/// </summary>
		public AlexaTopSitesCountries()
		{
		}

		// Public properties.

		/// <summary>
		/// Gets the countries timestamp.
		/// </summary>
		public DateTime Timestamp { get; private set; }

		// Public methods.

		/// <summary>
		/// Parses the specified HTML data and add the result to the list of countries.
		/// </summary>
		/// <param name="data">The Alexa data.</param>
		public void Parse(string data)
		{
			// Create an HTML document for the list of Alexa countries.
			HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
			// Load the HTML data.
			html.LoadHtml(data);
			// Parse the countries node.
			HtmlAgilityPack.HtmlNode node = html.GetElementbyId("topsites-countries").Element("div").Element("div");

			// Clear the countries list.
			this.Clear();
			// Add the global ranking.
			//this.Add(new Country("(Global)", ControlAlexaTopSites.urlAlexaGlobal));
			// For all unnumbered list children.
			foreach (HtmlAgilityPack.HtmlNode nodeUl in node.Elements("ul"))
			{
				// For all list elements.
				foreach (HtmlAgilityPack.HtmlNode nodeLi in nodeUl.Elements("li"))
				{
					// Get the link element.
					HtmlAgilityPack.HtmlNode nodeA = nodeLi.Element("a");
					// Create a new Alexa country information.
					AlexaTopSitesCountry country = new AlexaTopSitesCountry(nodeA.InnerText, nodeA.GetAttributeValue("href", null));
					// Add the information to the list.
					this.Add(country);
				}
			}
		}
	}
}
