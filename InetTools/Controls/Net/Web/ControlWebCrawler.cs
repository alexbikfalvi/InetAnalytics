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
using System.Windows.Forms;
using System.Xml.Linq;
using DotNetApi;
using DotNetApi.Windows.Controls;
using DotNetApi.Web;
using InetAnalytics;
using InetCrawler.Tools;

namespace InetTools.Controls.Net.Web
{
	/// <summary>
	/// A class representing the control for the web crawler tool.
	/// </summary>
	public partial class ControlWebCrawler : NotificationControl
	{

		private readonly IToolApi api;
		private readonly object sync = new object();
		private readonly AsyncWebRequest request = new AsyncWebRequest();

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		/// <param name="api">The tools API.</param>
		public ControlWebCrawler(IToolApi api)
		{
			// Initialize the component.
			this.InitializeComponent();
			
			// Set the API.
			this.api = api;
		}

		// Private methods.

		/// <summary>
		/// An event handler called when a request has started.
		/// </summary>
		private void OnRequestStarted()
		{
			// Set the controls enabled state.
			this.buttonStart.Enabled = false;
			this.buttonStop.Enabled = true;
			this.textBoxUrl.Enabled = false;
		}

		/// <summary>
		/// An event handler called when a request has finished.
		/// </summary>
		private void OnRequestFinished()
		{
			// Set the controls enabled state.
			this.buttonStart.Enabled = true;
			this.buttonStop.Enabled = false;
			this.textBoxUrl.Enabled = true;
		}

		/// <summary>
		/// An event handler called when the user clicks on the start button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStart(object sender, EventArgs e)
		{
			// Call the request started event handler.
			this.OnRequestStarted();

			lock (this.sync)
			{
				try
				{
					//// Clear the ranking lists.
					//this.listView.Items.Clear();
					//this.alexaRanking.Clear();
					//// Disable the export button.
					//this.buttonExport.Enabled = false;
					
					//// Get the selected country.
					//AlexaCountryInfo info = this.alexaCountries[this.comboBoxCountries.SelectedIndex];
					//// Get the number of pages to download.
					//int pages = int.Parse(this.comboBoxPages.SelectedItem as string);
					
					//// Show a message.
					//this.ShowMessage(
					//	Properties.Resources.GlobeClock_48,
					//	"Alexa Request",
					//	"Updating the Alexa ranking...");
					
					//// Create a new request state.
					//AlexaRequestState state = new AlexaRequestState(info, pages);
					//// Begin a new ranking request.
					//this.OnStartRankingRequest(state);
				}
				catch (Exception exception)
				{
					// Call the request finished event handler.
					this.OnRequestFinished();
					// Show a message.
					this.ShowMessage(
						Resources.GlobeError_48,
						"Alexa Request",
						"Updating the Alexa ranking failed.{0}{1}".FormatWith(Environment.NewLine, exception.Message),
						false,
						(int)this.api.Config.MessageCloseDelay.TotalMilliseconds);
				}
			}
		}

		///// <summary>
		///// Begins a new ranking request with the specified state.
		///// </summary>
		///// <param name="state">The request state.</param>
		//private void OnStartRankingRequest(AlexaRequestState state)
		//{
		//	// Create the URL.
		//	Uri uri = new Uri("{0}{1};{2}".FormatWith(ControlWebCrawler.urlAlexa, state.Country.Url, state.Page));
		//	// Begin a new web request.
		//	this.result = this.request.Begin(uri, this.OnCallbackRanking, state);
		//}

		///// <summary>
		///// A method called when receiving the web response.
		///// </summary>
		///// <param name="result">The result of the asynchronous operation.</param>
		//private void OnCallbackRanking(AsyncWebResult result)
		//{
		//	// Set the result to null.
		//	lock (this.sync)
		//	{
		//		this.result = null;
		//	}

		//	try
		//	{
		//		// The received data.
		//		string data = null;

		//		// Complete the web request.
		//		this.request.End(result, out data);

		//		// Parse the list of Alexa countries.
		//		this.OnParseAlexaRanking(data);

		//		// Get the request state.
		//		AlexaRequestState state = result.AsyncState as AlexaRequestState;

		//		// If the request state is not null, and there are more pages.
		//		if ((null != state) && (++state.Page < state.Pages))
		//		{
		//			// Begin a new ranking request.
		//			this.OnStartRankingRequest(state);
		//		}
		//		else
		//		{
		//			// Show a message.
		//			this.ShowMessage(
		//				Properties.Resources.GlobeSuccess_48,
		//				"Alexa Request",
		//				"Updating the Alexa ranking completed successfully.",
		//				false,
		//				(int)this.api.Config.MessageCloseDelay.TotalMilliseconds,
		//				(object[] parameters) =>
		//				{
		//					// Call the request finished event handler.
		//					this.OnRequestFinished();
		//					// Update the ranking list.
		//					this.OnUpdateRanking(state.Country);
		//				});
		//		}
		//	}
		//	catch (Exception exception)
		//	{
		//		// Show a message.
		//		this.ShowMessage(
		//			Properties.Resources.GlobeError_48,
		//			"Alexa Request",
		//			"Updating the Alexa ranking failed.{0}{1}".FormatWith(Environment.NewLine, exception.Message),
		//			false,
		//			(int)this.api.Config.MessageCloseDelay.TotalMilliseconds,
		//			(object[] parameters) =>
		//			{
		//				// Call the request finished event handler.
		//				this.OnRequestFinished();
		//			});
		//	}
		//}

		/// <summary>
		/// An event handler called when the user clicks on the stop button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStop(object sender, EventArgs e)
		{
			//// Set the controls enabled state.
			//this.buttonStop.Enabled = false;

			//lock (this.sync)
			//{
			//	// If the request result is not null.
			//	if (null != this.result)
			//	{
			//		// Cancel the asynchronous operation.
			//		this.request.Cancel(this.result);
			//		// Set the result to null.
			//		this.result = null;
			//	}
			//}
		}

		///// <summary>
		///// An event handler called when refreshing the list of Alexa countries.
		///// </summary>
		///// <param name="sender">The sender object.</param>
		///// <param name="e">The event arguments.</param>
		//private void OnRefreshCountries(object sender, EventArgs e)
		//{
		//	// Call the request started event handler.
		//	this.OnRequestStarted();

		//	lock (this.sync)
		//	{
		//		try
		//		{
		//			// Clear the countries list.
		//			this.comboBoxCountries.Items.Clear();
		//			// Show a message.
		//			this.ShowMessage(
		//				Properties.Resources.GlobeClock_48,
		//				"Alexa Request",
		//				"Updating the list of Alexa ranking countries...");
		//			// Begin a new web request.
		//			this.result = this.request.Begin(new Uri(ControlWebCrawler.urlAlexa + ControlWebCrawler.urlAlexaCountries), this.OnCallbackRefreshCountries, null);
		//		}
		//		catch (Exception exception)
		//		{
		//			// Call the request finished event handler.
		//			this.OnRequestFinished();
		//			// Show a message.
		//			this.ShowMessage(
		//				Properties.Resources.GlobeError_48,
		//				"Alexa Request",
		//				"Updating the list of Alexa ranking countries failed.{0}{1}".FormatWith(Environment.NewLine, exception.Message),
		//				false,
		//				(int)this.api.Config.MessageCloseDelay.TotalMilliseconds);
		//		}
		//	}
		//}

		///// <summary>
		///// A method called when receiving the web response.
		///// </summary>
		///// <param name="result">The result of the asynchronous operation.</param>
		//private void OnCallbackRefreshCountries(AsyncWebResult result)
		//{
		//	// Set the result to null.
		//	lock (this.sync)
		//	{
		//		this.result = null;
		//	}

		//	try
		//	{
		//		// The received data.
		//		string data = null;
				
		//		// Complete the web request.
		//		this.request.End(result, out data);
				
		//		// Parse the list of Alexa countries.
		//		this.OnParseAlexaCountries(data);

		//		// Show a message.
		//		this.ShowMessage(
		//			Properties.Resources.GlobeSuccess_48,
		//			"Alexa Request",
		//			"Updating the list of Alexa ranking countries completed successfully.",
		//			false,
		//			(int)this.api.Config.MessageCloseDelay.TotalMilliseconds,
		//			(object[] parameters) =>
		//			{
		//				// Call the request finished event handler.
		//				this.OnRequestFinished();
		//				// Update the list of countries.
		//				this.OnUpdateCountries();
		//			});
		//	}
		//	catch (Exception exception)
		//	{
		//		// Show a message.
		//		this.ShowMessage(
		//			Properties.Resources.GlobeError_48,
		//			"Alexa Request",
		//			"Updating the list of Alexa ranking countries failed.{0}{1}".FormatWith(Environment.NewLine, exception.Message),
		//			false,
		//			(int)this.api.Config.MessageCloseDelay.TotalMilliseconds,
		//			(object[] parameters) =>
		//			{
		//				// Call the request finished event handler.
		//				this.OnRequestFinished();
		//			});
		//	}
		//}

		///// <summary>
		///// Updates the current list of countries.
		///// </summary>
		//private void OnUpdateCountries()
		//{
		//	lock (this.sync)
		//	{
		//		// Update the list of countries.
		//		foreach (AlexaCountryInfo info in this.alexaCountries)
		//		{
		//			this.comboBoxCountries.Items.Add(info.Name);
		//		}
		//	}
		//	// Select the first index.
		//	this.comboBoxCountries.SelectedIndex = 0;
		//}

		///// <summary>
		///// Updates the Alexa ranking.
		///// </summary>
		///// <param name="country">The country.</param>
		//private void OnUpdateRanking(AlexaCountryInfo country)
		//{
		//	lock (this.sync)
		//	{
		//		// Set the ranking timestamp and country.
		//		this.alexaRankingTimestamp = DateTime.Now;
		//		this.alexaRankingCountry = country;
		//		// Update the list of sites.
		//		foreach (AlexaRankingInfo info in this.alexaRanking)
		//		{
		//			// Create a new item.
		//			ListViewItem item = new ListViewItem(new string[] { info.Rank.ToString(), info.Site });
		//			item.Tag = info;
		//			item.ImageIndex = 0;
		//			// Add the item to the list.
		//			this.listView.Items.Add(item);
		//		}
		//		// Enable the export button.
		//		this.buttonExport.Enabled = this.alexaRanking.Count > 0;
		//	}
		//}

		///// <summary>
		///// Parses the list of Alexa countries.
		///// </summary>
		///// <param name="data">The data.</param>
		//private void OnParseAlexaCountries(string data)
		//{
		//	// Create an HTML document for the list of Alexa countries.
		//	HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
		//	// Load the HTML data.
		//	html.LoadHtml(data);
		//	// Parse the countries node.
		//	HtmlAgilityPack.HtmlNode node = html.GetElementbyId("topsites-countries").Element("div").Element("div");

		//	// Synchronize access.
		//	lock (this.sync)
		//	{
		//		// Clear the countries list.
		//		this.alexaCountries.Clear();
		//		// Add the global ranking.
		//		this.alexaCountries.Add(new AlexaCountryInfo("(Global)", ControlWebCrawler.urlAlexaGlobal));
		//		// For all unnumbered list chilren.
		//		foreach (HtmlAgilityPack.HtmlNode nodeUl in node.Elements("ul"))
		//		{
		//			// For all list elements.
		//			foreach (HtmlAgilityPack.HtmlNode nodeLi in nodeUl.Elements("li"))
		//			{
		//				// Get the link element.
		//				HtmlAgilityPack.HtmlNode nodeA = nodeLi.Element("a");
		//				// Create a new Alexa country information.
		//				AlexaCountryInfo info = new AlexaCountryInfo(nodeA.InnerText, nodeA.GetAttributeValue("href", null));
		//				// Add the information to the list.
		//				this.alexaCountries.Add(info);
		//			}
		//		}
		//	}
		//}

		///// <summary>
		///// Parses the list of Alexa ranking.
		///// </summary>
		///// <param name="data">The data.</param>
		//private void OnParseAlexaRanking(string data)
		//{
		//	// Create an HTML document for the list of Alexa countries.
		//	HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
		//	// Load the HTML data.
		//	html.LoadHtml(data);

		//	// The root node.
		//	HtmlAgilityPack.HtmlNode node;

		//	// Parse the countries node.
		//	if (null != (node = html.GetElementbyId("topsites-global")))
		//	{
		//		this.OnParseAlexaRanking(node);
		//	}
		//	else if (null != (node = html.GetElementbyId("topsites-countries")))
		//	{
		//		this.OnParseAlexaRanking(node);
		//	}
		//}

		///// <summary>
		///// Parses the Alexa ranking.
		///// </summary>
		///// <param name="node">The inner HTML node.</param>
		//private void OnParseAlexaRanking(HtmlAgilityPack.HtmlNode node)
		//{
		//	lock (this.sync)
		//	{
		//		// For all ranking elements.
		//		foreach (HtmlAgilityPack.HtmlNode nodeLi in node.Element("div").Element("ul").Elements("li"))
		//		{
		//			HtmlAgilityPack.HtmlNode nodeRank = nodeLi.Elements("div").Where((HtmlAgilityPack.HtmlNode child) =>
		//			{
		//				return child.GetAttributeValue("class", null) == "count";
		//			}).FirstOrDefault();
		//			HtmlAgilityPack.HtmlNode nodeSite = nodeLi.Elements("div").Where((HtmlAgilityPack.HtmlNode child) =>
		//			{
		//				return child.GetAttributeValue("class", null) == "desc-container";
		//			}).FirstOrDefault().Element("h2").Element("a");

		//			// Create a new ranking information.
		//			AlexaRankingInfo info = new AlexaRankingInfo(
		//				int.Parse(nodeRank.InnerText),
		//				nodeSite.InnerText,
		//				nodeSite.GetAttributeValue("href", null)
		//				);
		//			// Add the information to the ranking list.
		//			this.alexaRanking.Add(info);
		//		}
		//	}
		//}

		///// <summary>
		///// An event handler called when the user exports the data.
		///// </summary>
		///// <param name="sender">The sender object.</param>
		///// <param name="e">The event arguments.</param>
		//private void OnExport(object sender, EventArgs e)
		//{
		//	// Show the save file dialog.
		//	if (this.saveFileDialog.ShowDialog(this) == DialogResult.OK)
		//	{
		//		lock (this.sync)
		//		{
		//			// Create an XML element for the ranking.
		//			XElement xml = new XElement("AlexaTopSites",
		//				new XAttribute("Country", this.alexaRankingCountry.Name),
		//				new XAttribute("Timestamp", this.alexaRankingTimestamp));
		//			// Add all elements.
		//			foreach (AlexaRankingInfo info in this.alexaRanking)
		//			{
		//				xml.Add(new XElement("Site",
		//					new XAttribute("Rank", info.Rank),
		//					new XAttribute("Site", info.Site)));
		//			}
		//			// Create an XML document.
		//			XDocument doc = new XDocument(xml);
		//			// Export the data to the file.
		//			doc.Save(this.saveFileDialog.FileName);
		//		}
		//	}
		//}
	}
}
