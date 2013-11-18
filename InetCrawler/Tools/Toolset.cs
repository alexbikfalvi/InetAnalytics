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

namespace InetCrawler.Tools
{
	/// <summary>
	/// An interface for a toolset.
	/// </summary>
	public abstract class Toolset
	{
		// Properties.
		/// <summary>
		/// Gets the list of tools.
		/// </summary>
		public abstract Type[] Tools { get; }
		
		// Methods.

		/// <summary>
		/// Checks the current class is has the toolset attribute.
		/// </summary>
		/// <returns><b>True</b> if the class has the toolset attribute, or <b>false</b> otherwise.</returns>
		public bool IsToolset()
		{
			// Get the toolset attributes.
			return this.GetType().GetCustomAttributes(typeof(ToolsetInfoAttribute), false).Length > 0;
		}

		/// <summary>
		/// Gets the toolset information attribute.
		/// </summary>
		/// <returns>The toolset information attribute, or <b>null</b> if the attribute is missing.</returns>
		public ToolsetInfoAttribute GetToolsetInfo()
		{
			// Get the attributes.
			object[] attributes = this.GetType().GetCustomAttributes(typeof(ToolsetInfoAttribute), false);
			// Return the first attribute.
			return attributes.Length > 0 ? attributes[0] as ToolsetInfoAttribute : null;
		}

		/// <summary>
		/// Creates a tool instance for the specified identifier.
		/// </summary>
		/// <param name="info">The tool information.</param>
		/// <returns>The tool instance.</returns>
		//Tool Create(ToolInfo info);
	}
}
