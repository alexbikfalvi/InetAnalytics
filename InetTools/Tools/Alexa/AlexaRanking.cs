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
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace InetTools.Tools.Alexa
{
	/// <summary>
	/// A class representing the Alexa ranking.
	/// </summary>
	public sealed class AlexaRanking : List<AlexaRank>
	{
		/// <summary>
		/// Creates a new Alexa ranking.
		/// </summary>
		public AlexaRanking()
		{
		}

		// Public properties.

		/// <summary>
		/// Gets the ranking timestamp.
		/// </summary>
		public DateTime Timestamp { get; private set; }
		/// <summary>
		/// Gets the ranking country.
		/// </summary>
		public AlexaCountry Country { get; private set; }

		// Public methods.

		/// <summary>
		/// Parses the specified HTML data and add the result to the ranking list.
		/// </summary>
		/// <param name="data">The Alexa data.</param>
		/// <param name="country">The country.</param>
		public void Parse(string data, AlexaCountry country)
		{
			// Create an HTML document for the list of Alexa countries.
			HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
			// Load the HTML data.
			html.LoadHtml(data);

			// The root node.
			HtmlAgilityPack.HtmlNode node;

			// Parse the countries node.
			if (null != (node = html.GetElementbyId("topsites-global")))
			{
				this.Parse(node);
			}
			else if (null != (node = html.GetElementbyId("topsites-countries")))
			{
				this.Parse(node);
			}

			// Set the timestamp.
			this.Timestamp = DateTime.Now;
			// Set the country.
			this.Country = country;
		}

		/// <summary>
		/// Loads an Alexa ranking from the specified XML file.
		/// </summary>
		/// <param name="fileName">The file name.</param>
		/// <returns>The Alexa ranking.</returns>
		public static AlexaRanking Load(string fileName)
		{
			// Create a new ranking.
			AlexaRanking ranking = new AlexaRanking();

			// Open the XML document.
			XDocument xml = XDocument.Load(fileName);

			// Check the file.
			if (xml.Root.Name != "AlexaTopSites") throw new IOException("The XML file does not match the Alexa ranking format.");

			// Parse the country.
			ranking.Country = bool.Parse(xml.Root.Attribute("Global").Value) ? 
				AlexaCountry.Global :
				new AlexaCountry(xml.Root.Attribute("CountryName").Value, xml.Root.Attribute("CountryUrl").Value);
			// Parse the timestamp.
			ranking.Timestamp = DateTime.Parse(xml.Root.Attribute("Timestamp").Value);
			
			// Parse the ranking.
			foreach (XElement element in xml.Root.Elements("Rank"))
			{
				ranking.Add(new AlexaRank(
					int.Parse(element.Attribute("Position").Value),
					element.Attribute("Site").Value,
					element.Attribute("Url").Value
					));
			}

			// Return the ranking.
			return ranking;
		}

		/// <summary>
		/// Saves the ranking to the specified XML file.
		/// </summary>
		/// <param name="fileName">The file name.</param>
		public void SaveXml(string fileName)
		{
			// Create an XML element for the ranking.
			XElement xml = new XElement("AlexaTopSites",
				new XAttribute("Global", this.Country.IsGlobal),
				new XAttribute("CountryName", this.Country.Name),
				new XAttribute("CountryUrl", this.Country.Url),
				new XAttribute("CountryCode", this.Country.Code),
				new XAttribute("Timestamp", this.Timestamp));
			// Add all elements.
			foreach (AlexaRank rank in this)
			{
				xml.Add(new XElement("Rank",
					new XAttribute("Position", rank.Position),
					new XAttribute("Site", rank.Site),
					new XAttribute("Url", rank.Url)));
			}
			// Create an XML document.
			XDocument doc = new XDocument(xml);
			// Export the data to the file.
			doc.Save(fileName);
		}

		/// <summary>
		/// Saves the ranking to the specified text file.
		/// </summary>
		/// <param name="fileName">The file name.</param>
		public void SaveText(string fileName)
		{
			// Create a new file.
			using (StreamWriter file = new StreamWriter(fileName, false))
			{
				// Add all elements.
				foreach (AlexaRank rank in this)
				{
					file.WriteLine(rank.Site);
				}
			}
		}

		// Private methods.

		/// <summary>
		/// Parses the Alexa ranking.
		/// </summary>
		/// <param name="node">The inner HTML node.</param>
		private void Parse(HtmlAgilityPack.HtmlNode node)
		{
			// For all ranking elements.
			foreach (HtmlAgilityPack.HtmlNode nodeLi in node.Element("div").Element("ul").Elements("li"))
			{
				HtmlAgilityPack.HtmlNode nodeRank = nodeLi.Elements("div").Where((HtmlAgilityPack.HtmlNode child) =>
				{
					return child.GetAttributeValue("class", null) == "count";
				}).FirstOrDefault();
				HtmlAgilityPack.HtmlNode nodeSite = nodeLi.Elements("div").Where((HtmlAgilityPack.HtmlNode child) =>
				{
					return child.GetAttributeValue("class", null) == "desc-container";
				}).FirstOrDefault().Element("h2").Element("a");

				// Create a new ranking information.
				AlexaRank rank = new AlexaRank(
					int.Parse(nodeRank.InnerText),
					nodeSite.InnerText,
					nodeSite.GetAttributeValue("href", null)
					);
				// Add the information to the ranking list.
				this.Add(rank);
			}
		}
	}
}
