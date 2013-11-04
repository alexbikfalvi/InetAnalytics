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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using HtmlAgilityPack;
using DotNetApi;
using DotNetApi.Xml;

namespace InetApi.YouTube.Ajax
{
	/// <summary>
	/// A class representing YouTube Ajax video statistics.
	/// </summary>
	[Serializable]
	public class AjaxVideoStatistics
	{
		/// <summary>
		/// Creates an uninitialized video statistics object.
		/// </summary>
		protected AjaxVideoStatistics()
		{
			this.ReturnCode = 0;
			this.ViewsCount = null;
			this.CommentsCount = null;
			this.FavoritesCount = null;
			this.LikesCount = null;
			this.DislikesCount = null;
			this.ViewsHistory = null;
			this.CommentsHistory = null;
			this.FavoritesHistory = null;
			this.LikesHistory = null;
			this.DislikesHistory = null;
		}

		/// <summary>
		/// Parses the string argument to a video statistics object.
		/// </summary>
		/// <param name="data">The XML data string.</param>
		/// <returns>The video statistics object.</returns>
		public static AjaxVideoStatistics Parse(string data)
		{
			// Create a new video statistics object
			AjaxVideoStatistics statistics = new AjaxVideoStatistics();
			// Parse the root
			statistics.ParseRoot(XDocument.Parse(data));
			return statistics;
		}

		/// <summary>
		/// The return code corresponding to the AJAX request.
		/// </summary>
		public int ReturnCode { get; private set; }
		/// <summary>
		/// The views count.
		/// </summary>
		public int? ViewsCount { get; private set; }
		/// <summary>
		/// The comments count.
		/// </summary>
		public int? CommentsCount { get; private set; }
		/// <summary>
		/// The favorites count.
		/// </summary>
		public int? FavoritesCount { get; private set; }
		/// <summary>
		/// The likes count.
		/// </summary>
		public int? LikesCount { get; private set; }
		/// <summary>
		/// The dislikes count.
		/// </summary>
		public int? DislikesCount { get; private set; }
		/// <summary>
		/// The view history.
		/// </summary>
		public AjaxViewsHistory ViewsHistory { get; private set; }
		/// <summary>
		/// The comments history.
		/// </summary>
		public AjaxHistory CommentsHistory { get; private set; }
		/// <summary>
		/// The favorites history.
		/// </summary>
		public AjaxHistory FavoritesHistory { get; private set; }
		/// <summary>
		/// The likes history.
		/// </summary>
		public AjaxHistory LikesHistory { get; private set; }
		/// <summary>
		/// The dislikes history.
		/// </summary>
		public AjaxHistory DislikesHistory { get; private set; }


		private void ParseRoot(XDocument xml)
		{
			// For all root children.
			foreach (XElement element in xml.Root.Elements())
			{
				switch (element.Name.ToString().ToLower())
				{
					case "html_content": this.ParseHtmlContent(element); break;
					case "return_code": this.ParseReturnCode(element); break;
					default: throw new AjaxParsingException("Invalid XML element \"{0}\" while parsing the data string.".FormatWith(element.Name.ToString()), element.ToString());
				}
			}
		}

		private void ParseHtmlContent(XElement element)
		{
			HtmlDocument doc = new HtmlDocument();
			StringBuilder stringBuilder = new StringBuilder();
			StringWriter stringWriter  = new StringWriter(stringBuilder);

			doc.LoadHtml(element.Value);
			doc.OptionOutputAsXml = true;
			doc.Save(stringWriter);
			
			XDocument htmlContent = XDocument.Parse(stringBuilder.ToString());

			// For all DIV elements in the HTML content.
			foreach (XElement div in htmlContent.Descendants(XName.Get("div")))
			{
				// Get the element CLASS attribute.
				XAttribute attribute = div.Attribute(XName.Get("class"));

				// If the element has a CLASS attribute.
				if (null != attribute)
				{
					switch (attribute.Value)
					{
						case "stats-big-chart": this.ParseHtmlStatsBigChart(div); break;
						case "stats-views": this.ParseHtmlStatsViews(div); break;
						case "stats-discovery-events": this.ParseHtmlStatsDiscoveryEvents(div); break;
						case "stats-engagement": this.ParseHtmlStatsEngagement(div); break;
						case "stats-audience": this.ParseHtmlStatsAudience(div); break;
						case "watch-actions-stats": this.ParseHtmlOther(div); break;
					}
				}
			}
		}

		private void ParseReturnCode(XElement element)
		{
			this.ReturnCode = element.Value.ToInt();
		}

		/// <summary>
		/// Parses the view count history.
		/// </summary>
		/// <param name="element">The DIV element.</param>
		private void ParseHtmlStatsBigChart(XElement element)
		{
			// Search all IMG child elements.
			foreach (XElement img in element.Elements(XName.Get("img")))
			{
				// Get the element CLASS attribute.
				XAttribute attribute = img.Attribute(XName.Get("class"));

				// If the element has a CLASS attribute.
				if (null != attribute)
				{
					switch (attribute.Value)
					{
						case "stats-big-chart-expanded":
							this.ViewsHistory = AjaxViewsHistory.Parse(img.Attribute(XName.Get("src")).Value);
							break;
					}
				}
			}
		}

		private void ParseHtmlStatsViews(XElement element)
		{
			// Search for the first H3 element.
			XElement header = element.Element(XName.Get("h3"));
			try { this.ViewsCount = int.Parse(header.Value, NumberStyles.AllowThousands); }
			catch (FormatException) { this.ViewsCount = null; }
		}

		private void ParseHtmlStatsDiscoveryEvents(XElement element)
		{
			// Search all DT child elements.
			IEnumerable<XElement> dts = element.Descendants(XName.Get("dt"));
			// Search all DD child elements.
			IEnumerable<XElement> dds = element.Descendants(XName.Get("dd"));

			if (dts.Count() != dds.Count())
				throw new AjaxParsingException("Cannot parse discovery events statistics: different number of \"dt\" ({0}) and \"dd\" ({1}) elements in the HTML response.".FormatWith(dts.Count(), dds.Count()), element.ToString());

			// For all elements in the list.
			for (int index = 0; index < dts.Count(); index++)
			{
				XElement dt = dts.ElementAt(index);
				XElement dd = dds.ElementAt(index);

				// Check the DT element.
				if (dt.Attribute(XName.Get("class")).Value != "stats-label")
					throw new AjaxParsingException("Cannot parse discovery events statistics: the value of the \"dt\" element \"class\" attribute must be \"stats-label\", but is \"{0}\".".FormatWith(dt.Attribute(XName.Get("class")).Value), element.ToString());
				// Check the DD element.
				if (dd.Attribute(XName.Get("class")).Value != "event")
					throw new AjaxParsingException("Cannot parse discovery events statistics: the value of the \"dd\" element \"class\" attrobute must be \"event\", but is \"{0}\".".FormatWith(dd.Attribute(XName.Get("class")).Value), element.ToString());

				// Parse the discovery event.
				this.ParseHtmlStatsDiscoveryEvent(dt.Value, dd);
			}
		}

		private void ParseHtmlStatsDiscoveryEvent(string name, XElement dd)
		{
			try
			{
				// Get the P child elements.
				foreach (XElement p in dd.Elements(XName.Get("p")))
				{
					// If the P element has no attributes.
					if (p.Attributes().Count() == 0)
					{
						if (p.Elements(XName.Get("span")).Count() == 0)
						{
							try
							{
								// If the P element has no SPAN child elements, create a new discovery event, and add it to the views history.
								this.ViewsHistory.AddViewsDiscoveryEvent(
									AjaxViewsHistoryDiscoveryEvent.Create(
									name,
									p.Value
									));
							}
							catch (AjaxException exception)
							{
								// If an exception occurred, add the exception to the views history.
								this.ViewsHistory.AddViewsDiscoveryEventException(new AjaxParsingException("Cannot parse statistics discovery event.", exception, p.ToString()));
							}
						}
						else
						{
							string description = null;
							XElement extra = null;

							// For all SPAN elements.
							foreach (XElement span in p.Elements(XName.Get("span")))
							{
								// If the SPAN element has no attributes.
								if (span.Attributes().Count() == 0)
								{
									description = span.Value;
								}
								// If the SPAN element has a CLASS attribute set to "extra".
								if (span.Attribute(XName.Get("class")) != null)
								{
									if (span.Attribute(XName.Get("class")).Value == "extra")
									{
										extra = span;
									}
								}
							}

							try
							{
								// Create a new discovery event, and add it to the views history.
								this.ViewsHistory.AddViewsDiscoveryEvent(
									AjaxViewsHistoryDiscoveryEvent.Create(
									name,
									description,
									extra
									));
							}
							catch (AjaxException exception)
							{
								// If an exception occurred, add the exception to the views history.
								this.ViewsHistory.AddViewsDiscoveryEventException(new AjaxParsingException("Cannot parse statistics discovery event.", exception, p.ToString()));
							}
						}
					}
				}
			}
			catch (Exception exception)
			{
				throw new AjaxParsingException("Cannot parse discovery events statistics: an exception occurred while parsing XML string \"{0}\".".FormatWith(dd.ToString()), exception, dd.ToString());
			}
		}

		private void ParseHtmlStatsEngagement(XElement element)
		{
		}

		private void ParseHtmlStatsAudience(XElement element)
		{
		}

		private void ParseHtmlOther(XElement element)
		{
			XElement el = element.Element(XName.Get("p"));
			if (null != el)
			{
				if (Regex.IsMatch(el.Value.ToLower(), "public.+statistics.+have.+been.+disabled"))
					throw new AjaxRequestException(AjaxRequestExceptionType.PublicStatisticsDisabled);
				else if (Regex.IsMatch(el.Value.ToLower(), "no.+statistics.+available.+yet"))
					throw new AjaxRequestException(AjaxRequestExceptionType.NotAvailableYet);
			}
		}
	}
}
