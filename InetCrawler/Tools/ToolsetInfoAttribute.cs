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

namespace InetCrawler.Tools
{
	/// <summary>
	/// A class representing the toolset information attribute.
	/// </summary>
	public sealed class ToolsetInfoAttribute : Attribute
	{
		/// <summary>
		/// Creates a new toolset information structure.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="major">The toolset major version.</param>
		/// <param name="minor">The toolset minor version.</param>
		/// <param name="build">The toolset build version.</param>
		/// <param name="revision">The toolset revision version.</param>
		/// <param name="name">The toolset name.</param>
		/// <param name="description">The toolset description.</param>
		/// <param name="product">The product.</param>
		/// <param name="author">The author.</param>
		public ToolsetInfoAttribute(string id, int major, int minor, int build, int revision, string name, string description, string product, string author)
		{
			this.Id = new ToolId(new Guid(id), new Version(major, minor, build, revision));
			this.Name = name;
			this.Description = description;
			this.Product = product;
			this.Author = author;
		}

		/// <summary>
		/// Gets the toolset identifier.
		/// </summary>
		public ToolId Id { get; private set; }
		/// <summary>
		/// Gets the tool or toolset name.
		/// </summary>
		public string Name { get; private set; }
		/// <summary>
		/// Gets the tool or toolset description.
		/// </summary>
		public string Description { get; private set; }
		/// <summary>
		/// Gets the tool product.
		/// </summary>
		public string Product { get; private set; }
		/// <summary>
		/// Gets the tool author.
		/// </summary>
		public string Author { get; private set; }
	}
}
