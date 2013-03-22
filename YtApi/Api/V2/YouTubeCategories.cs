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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Win32;
using DotNetApi.Web;

namespace YtApi.Api.V2
{
	/// <summary>
	/// A set of YouTube categories.
	/// </summary>
	public sealed class YouTubeCategories : IDisposable, IEnumerable<YouTubeCategory>
	{
		private List<YouTubeCategory> categories = new List<YouTubeCategory>();
		private YouTubeRequest request = new YouTubeRequest(null);

		private object state = null;
		private AsyncWebRequestCallback callback = null;

		private XDocument xml = null;

		private string xmlnsApp = null;
		private string xmlnsAtom = null;
		private string xmlnsYt = null;

		private string[] categoryLabels = new string[0];

		private string fileName;

		/// <summary>
		/// Creates a list of YouTube categories, and reads the list from the specified registry keys.
		/// </summary>
		/// <param name="fileName">The file where the local categories list is stored.</param>
		public YouTubeCategories(string fileName)
		{
			// Set the file name.
			this.fileName = fileName;

			// Read the categories from the file.
			this.ReadFromFile();
		}

		// Public properties.

		/// <summary>
		/// Returns the number of categories.
		/// </summary>
		public int Count { get { return this.categories.Count; } }
		/// <summary>
		/// Returns the category at a specified index.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <returns>The YouTube category.</returns>
		public YouTubeCategory this[int index] { get { return this.categories[index]; } }
		/// <summary>
		/// Returns the category at a specified label.
		/// </summary>
		/// <param name="label">The label.</param>
		/// <returns>The YouTube category.</returns>
		public YouTubeCategory this[string label] { get { return this.categories[Array.IndexOf(this.categoryLabels, label)]; } }
		/// <summary>
		/// Returns the list of category labels.
		/// </summary>
		public string[] CategoryLabels { get { return this.categoryLabels; } }
		/// <summary>
		/// Returns <b>true</b> if the categories list is empty, or <b>false</b> otherwise.
		/// </summary>
		public bool IsEmpty { get { return this.categories.Count == 0; } }

		// Public methods.

		/// <summary>
		/// Returns the enumerator for the list of categories.
		/// </summary>
		/// <returns>The enumerator.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		/// <summary>
		/// Returns the enumerator for the list of categories.
		/// </summary>
		/// <returns>The enumerator.</returns>
		public IEnumerator<YouTubeCategory> GetEnumerator()
		{
			return this.categories.GetEnumerator();
		}

		/// <summary>
		/// Begins an asynchronous refresh operation.
		/// </summary>
		/// <param name="callback">The callback function.</param>
		/// <param name="state">The user state.</param>
		/// <returns>The asynchronous result.</returns>
		public IAsyncResult BeginRefresh(AsyncWebRequestCallback callback, object state = null)
		{
			if(null == this.callback)
			{
				// Save the callback function and the user state.
				this.callback = callback;
				this.state = state;
				// Begin the request.
				return this.request.Begin(YouTubeUri.UriCategories, (AsyncWebResult result) =>
					{
						// If no exception was thrown, complete the request
						if (null == result.Exception)
						{
							try
							{
								// Parse the string data.
								this.Parse(this.request.End(result, out state));
							}
							catch (Exception exception)
							{
								result.Exception = exception;
							}
						}

						// Call the callback function
						if (this.callback != null)
						{
							this.callback(result);
						}

						// Reset the callback and state
						this.callback = null;
						this.state = null;
					});
			}
			else
			{
				throw new YouTubeException("Cannot begin a new refresh request, until a previous one completes.");
			}
		}

		/// <summary>
		/// Completes an asynchronous refresh operation.
		/// </summary>
		/// <param name="result">The asynchronous result.</param>
		/// <returns>The user state.</returns>
		public object EndRefresh(IAsyncResult result)
		{
			// Get the asynchronous result.
			AsyncWebResult asyncResult = result as AsyncWebResult;

			// If an exception was thrown during the asynchronous operation.
			if (null != asyncResult.Exception)
			{
				// Rethrow the exception.
				throw asyncResult.Exception;
			}

			// Return the user state
			return asyncResult.AsyncState;
		}

		/// <summary>
		/// Cancels the current asynchronous operation.
		/// </summary>
		/// <param name="asyncResult">The asynchronous result.</param>
		public void Cancel(IAsyncResult asyncResult)
		{
			this.request.Cancel(asyncResult);
		}

		/// <summary>
		/// Create a list of categories based on XML data.
		/// </summary>
		/// <param name="data">The XML data.</param>
		public void Parse(string data)
		{
			// Parse the XML data, and create the XML document.
			this.xml = XDocument.Parse(data);
			// Parse the document.
			this.Parse();
		}

		/// <summary>
		/// Reads the list of YouTube categories from file.
		/// </summary>
		public void ReadFromFile()
		{
			try
			{
				// Read the file, and create the XML document.
				this.xml = XDocument.Load(this.fileName);
				// Parse the document.
				this.Parse();
			}
			catch (Exception)
			{
				// Clear the categories list, if cannot read from the file.
				this.categories.Clear();
				this.categoryLabels = null;
			}
		}

		/// <summary>
		/// Saves the list of YouTube categories to file.
		/// </summary>
		public void SaveToFile()
		{
			// If the XML document is not null, save the XML document at the specified file.
			if (null != this.xml)
			{
				this.xml.Save(fileName, SaveOptions.None);
			}
		}

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Save the categories to the file.
			this.SaveToFile();
		}

		// Private methods.

		/// <summary>
		/// Parses the current XML document into the list of YouTube categories.
		/// </summary>
		private void Parse()
		{
			if (null == this.xml) return;

			// Get the XML namespaces
			this.xmlnsApp = this.xml.Root.Attribute(XName.Get("app", XNamespace.Xmlns.NamespaceName)).Value;
			this.xmlnsAtom = this.xml.Root.Attribute(XName.Get("atom", XNamespace.Xmlns.NamespaceName)).Value;
			this.xmlnsYt = this.xml.Root.Attribute(XName.Get("yt", XNamespace.Xmlns.NamespaceName)).Value;

			// Check the root element name
			if ((this.xml.Root.Name.LocalName != "categories") || (this.xml.Root.Name.NamespaceName != this.xmlnsApp))
				throw new YouTubeException("Invalid categories XML file");

			// Parse the categories
			this.categories.Clear();
			foreach (XElement element in this.xml.Root.Elements(XName.Get("category", this.xmlnsAtom)))
			{
				this.categories.Add(YouTubeCategory.Parse(element, this.xmlnsYt));
			}

			// Create the list of category labels.
			this.categoryLabels = new string[this.categories.Count];
			for (int index = 0; index < this.categories.Count; index++)
				this.categoryLabels[index] = this.categories[index].Label;
		}
	}
}
