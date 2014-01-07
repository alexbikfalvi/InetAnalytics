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
using System.Reflection;
using InetCrawler.Tools;
using InetTools.Tools;

namespace InetTools
{
	/// <summary>
	/// The main class for the standard toolset library.
	/// </summary>
	[ToolsetInfo(
		"1FA6DD5F-F500-4920-85A4-72A2D46AC08D",
		1, 0, 0, 0,
		"Internet Analytics Toolbox",
		"The standard toolset for the Internet Analytics toolbox.",
		"Internet Analytics",
		"Alex Bikfalvi"
		)]
	public sealed class StandardToolset : Toolset
	{
		private static Type[] tools = new Type[] {
			typeof(ToolAlexaTopSites),
			typeof(ToolCdnFinder),
			typeof(ToolMercuryClient),
			typeof(ToolMercuryAnalytics),
			typeof(ToolTraceroute),
			typeof(ToolSshClient),
			typeof(ToolWebClient)
		};

		/// <summary>
		/// Creates a new standard toolset.
		/// </summary>
		/// <param name="name">The toolset name.</param>
		public StandardToolset(string name)
			: base(name)
		{
			foreach (Type tool in StandardToolset.tools)
			{
				this.Add(tool);
			}
		}
	}
}
