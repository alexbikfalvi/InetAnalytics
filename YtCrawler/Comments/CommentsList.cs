/* 
 * Copyright (C) 2012-2013 Alex Bikfalvi
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
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace YtCrawler.Comments
{
	/// <summary>
	/// Represents a generic comments list.
	/// </summary>
	/// <typeparam name="T">The comment class.</typeparam>
	public class CommentsList<T> : List<T> where T : Comment, new()
	{
		private XDocument document;
		private HashSet<Guid> set = new HashSet<Guid>();

		/// <summary>
		/// Creates a new comments list instance.
		/// </summary>
		/// <param name="fileName">The file name.</param>
		public CommentsList(string fileName)
		{
			try
			{
				// If the specified file exists.
				if (File.Exists(fileName))
				{
					// Read the XML document from file.
					this.document = XDocument.Load(fileName);
					// Read the comments from the file.
					foreach (XElement element in this.document.Root.Elements("comment"))
					{
						// Create a new comment.
						T comment = new T();
						// Parse the XML element.
						comment.Parse(element);
						// If the GUID does not exist in the set.
						if (!this.set.Contains(comment.Guid))
						{
							// Add the comment to the list.
							this.Add(comment);
							// Add the GUID to the set.
							this.set.Add(comment.Guid);
						}
					}
					return;
				}
			}
			catch (Exception) { } // If an exception occurs, do nothing.

			// If the file does not exist, or the exception occurs.
			this.document = new XDocument(new XElement("comments"));
		}

		/// <summary>
		/// Saves the comment list to file.
		/// </summary>
		/// <param name="fileName">The file name.</param>
		public void Save(string fileName)
		{
			this.document.Save(fileName);
		}

		/// <summary>
		/// Adds a new comment to the list.
		/// </summary>
		/// <param name="comment">The comment.</param>
		/// <returns>Returns <b>true</b> if the comment was added successfully, or <b>false</b> otherwise.</returns>
		public bool AddComment(T comment)
		{
			// If the set already contains the GUID, do nothing.
			if (this.set.Contains(comment.Guid)) return false;
			// Add the XML element to the XML document.
			this.document.Root.Add(comment.Xml);
			// Add the comment to the list.
			this.Add(comment);
			// Add the GUID to the set.
			this.set.Add(comment.Guid);
			return true;
		}

		/// <summary>
		/// Removes a comment from the list.
		/// </summary>
		/// <param name="comment">The comment.</param>
		public void RemoveComment(T comment)
		{
			// Remove the XML element from the XML document.
			comment.Xml.Remove();
			// Remove the comment from the list.
			this.Remove(comment);
			// Remove the GUID from the set.
			this.set.Remove(comment.Guid);
		}

		/// <summary>
		/// Imports comments from a file.
		/// </summary>
		/// <param name="fileName">The file name.</param>
		/// <param name="countAdded">The number of added comments.</param>
		/// <param name="countIgnored">The number of ignored comments.</param>
		/// <returns>The collection of added items.</returns>
		public ICollection<T> Import(string fileName, out int countAdded, out int countIgnored)
		{
			// The list of added items.
			List<T> comments = null;

			countAdded = 0;
			countIgnored = 0;

			// If the specified file exists.
			if (File.Exists(fileName))
			{
				comments = new List<T>();
				// Read the XML document from file.
				this.document = XDocument.Load(fileName);
				// Read the comments from the file.
				foreach (XElement element in this.document.Root.Elements("comment"))
				{
					// Create a new comment.
					T comment = new T();
					// Parse the XML element.
					comment.Parse(element);
					// If the GUID does not exist in the set.
					if (!this.set.Contains(comment.Guid))
					{
						// Add the comment to the list.
						this.Add(comment);
						// Add the GUID to the set.
						this.set.Add(comment.Guid);
						// Add the comment to the output list.
						comments.Add(comment);
						// Increment the counter.
						countAdded++;
					}
					else countIgnored++;
				}
			}
			return comments;
		}
	}
}
