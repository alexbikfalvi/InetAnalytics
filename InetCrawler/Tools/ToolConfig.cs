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
using Microsoft.Win32;

namespace InetCrawler.Tools
{
	/// <summary>
	/// A class representing the tool configuration.
	/// </summary>
	public sealed class ToolConfig : IDisposable
	{
		private readonly RegistryKey key;

		private readonly Tool tool;

		/// <summary>
		/// Creates a new tool configuration instance.
		/// </summary>
		/// <param name="api">The tool API.</param>
		/// <param name="toolset">The toolset.</param>
		/// <param name="rootKey">The root registry key.</param>
		/// <param name="id">The tool identifier.</param>
		public ToolConfig(CrawlerApi api, Toolset toolset, RegistryKey rootKey, ToolId id)
		{

		}

		// Public properties.

		/// <summary>
		/// Gets the tool.
		/// </summary>
		public Tool Tool { get { return this.tool; } }

		// Public methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}
	}
}
