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
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Win32;
using DotNetApi;
using InetCrawler.Tools;

namespace InetCrawler.Tools
{
	/// <summary>
	/// A class representing the Internet Analytics toolbox.
	/// </summary>
	public sealed class Toolbox
	{
		private readonly IToolApi api;

		private readonly object sync = new object();

		private readonly RegistryKey key;
		private readonly Dictionary<Guid, ToolsetConfig> toolsets = new Dictionary<Guid, ToolsetConfig>();

		/// <summary>
		/// Creates a new toolbox instance.
		/// </summary>
		/// <param name="api">The tools API.</param>
		/// <param name="rootKey">The root registry key.</param>
		/// <param name="path">The registry path.</param>
		public Toolbox(IToolApi api, RegistryKey rootKey, string path)
		{
			// Set the tool API.
			this.api = api;
			// Open a registry key for the toolbox.
			if (null == (this.key = rootKey.OpenSubKey(path, RegistryKeyPermissionCheck.ReadWriteSubTree)))
			{
				this.key = rootKey.CreateSubKey(path, RegistryKeyPermissionCheck.ReadWriteSubTree);
			}
		}

		// Public methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Dispose the toolsets.
			lock (this.sync)
			{
				foreach (ToolsetConfig toolset in this.toolsets.Values)
				{
					toolset.Dispose();
				}
			}
			// Close the registry key.
			this.key.Close();
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Opens a toolset from the specified file.
		/// </summary>
		/// <param name="fileName">The file name.</param>
		/// <returns>The toolset.</returns>
		public Toolset Open(string fileName)
		{
			// Load the file as an assembly.
			Assembly assembly = Assembly.LoadFrom(fileName);

			// Search the assembly for a toolset type.
			foreach (Type type in assembly.GetExportedTypes())
			{
				// If the type is a toolset.
				if (Toolset.IsToolset(type))
				{
					// Create a new instance.
					return Activator.CreateInstance(type, new object[] { this.api, type.FullName }) as Toolset;
				}
			}
			// Else, throw an exception.
			throw new NotSupportedException("Cannot find an Internet Analytics toolset in the specified library.");
		}

		/// <summary>
		/// Adds the specified toolset and tools to the toolbox.
		/// </summary>
		/// <param name="fileName">The library file name.</param>
		/// <param name="toolset">The toolset.</param>
		/// <param name="tools">The tools.</param>
		public void Add(string fileName, Toolset toolset, Type[] tools)
		{
			// Get the toolset information.
			ToolsetInfoAttribute info = toolset.GetToolsetInfo();

			// Create the toolset configuration.
			ToolsetConfig config = new ToolsetConfig(this.key, fileName, toolset, tools);
			
			lock (this.sync)
			{
				// Add the configuration to the toolset list.
				this.toolsets.Add(info.Id, config);
			}
		}

		/// <summary>
		/// Loads the toolbox configuration.
		/// </summary>
		public void LoadConfiguration()
		{

		}

		/// <summary>
		/// Saves the toolbox configuration.
		/// </summary>
		public void SaveConfiguration()
		{

		}
	}
}
