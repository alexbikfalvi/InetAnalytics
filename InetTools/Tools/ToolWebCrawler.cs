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
using System.Windows.Forms;
using InetCrawler.Tools;

namespace InetTools.Tools
{
	/// <summary>
	/// Creates a new web crawler tool, which collects information about the content of a web site.
	/// </summary>
	[ToolInfo(
		"BD140334-43D9-4853-A124-ACA4FD799034",
		1, 0, 0, 0,
		"Web Content Crawler",
		"A tool that organizes the content of a web site according to the content source."
		)]
	public sealed class ToolWebCrawler : Tool
	{
		/// <summary>
		/// Creates a new tool instance.
		/// </summary>
		/// <param name="api">The tool API.</param>
		/// <param name="toolset">The toolset information.</param>
		public ToolWebCrawler(IToolApi api, ToolsetInfoAttribute toolset)
			: base(api, toolset)
		{

		}

		/// <summary>
		/// Gets the user interface control for this tool.
		/// </summary>
		public override Control Control { get { return null; } }
	}
}
