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
	/// An interface for a toolbox.
	/// </summary>
	public interface IToolbox
	{
		/// <summary>
		/// Gets the toolbox identifier.
		/// </summary>
		public Guid Id;
		/// <summary>
		/// The tool name.
		/// </summary>
		public string ToolboxName;
		/// <summary>
		/// The vendor name.
		/// </summary>
		public string VendorName;
		/// <summary>
		/// The product name.
		/// </summary>
		public string Product;
		/// <summary>
		/// The tool version.
		/// </summary>
		public Version Version;
		/// <summary>
		/// Gets the list of tools.
		/// </summary>
		public ICollection<ITool> Tools;
	}
}
