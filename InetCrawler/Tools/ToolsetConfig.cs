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
using Microsoft.Win32;
using DotNetApi;
using DotNetApi.Windows;
using InetCrawler.Tools;

namespace InetCrawler.Tools
{
	/// <summary>
	/// A class representing the toolset configuration.
	/// </summary>
	public sealed class ToolsetConfig : IDisposable
	{
		private readonly RegistryKey key;

		private readonly string fileName;
		private readonly Toolset toolset;

		private readonly Dictionary<ToolId, Tool> tools = new Dictionary<ToolId, Tool>();

		/// <summary>
		/// Creates a new toolset configuration instance.
		/// </summary>
		/// <param name="rootKey">The root registry key.</param>
		/// <param name="fileName">The library file name.</param>
		/// <param name="toolset">The toolset.</param>
		/// <param name="tools">The list of tools.</param>
		public ToolsetConfig(RegistryKey rootKey, string fileName, Toolset toolset, Type[] tools)
		{
			// Check the arguments.
			if (null == rootKey) throw new ArgumentNullException("rootKey");
			if (null == fileName) throw new ArgumentNullException("fileName");
			if (null == toolset) throw new ArgumentNullException("toolset");

			// Set the toolset parameters.
			this.fileName = fileName;
			this.toolset = toolset;

			// Get the toolset information.
			ToolsetInfoAttribute toolsetInfo = this.toolset.GetToolsetInfo();
			
			// If the toolset information is null, throw an exception.
			if (null == toolsetInfo) throw new InvalidOperationException("Cannot create a toolset configuration because the toolset does not have a toolset attribute.");

			// Open a registry key for the toolbox.
			if (null == (this.key = rootKey.OpenSubKey("{0}".FormatWith(toolsetInfo.Id), RegistryKeyPermissionCheck.ReadWriteSubTree)))
			{
				this.key = rootKey.CreateSubKey("{0}".FormatWith(toolsetInfo.Id), RegistryKeyPermissionCheck.ReadWriteSubTree);
			}

			// Create the list of tools identifiers.
			string[] toolsConfig = new string[tools.Length];

			// Create the tools.
			for (int index = 0; index < tools.Length; index++)
			{
				// Get the tool info.
				ToolInfoAttribute toolInfo = Tool.GetToolInfo(tools[index]);
				// If the type does not have a tool information, skip the type.
				if (null == toolInfo) continue;

				//try
				//{
					// Create the tool instance.
					Tool tool = Activator.CreateInstance(tools[index]) as Tool;
				//}

				// Set the tool identifier.
				toolsConfig[index] = "{0},{1}".FormatWith(toolInfo.Id.Guid.ToString(), toolInfo.Id.Version.ToString());
			}

			// Save the toolset configuration.
			this.key.SetString("FileName", this.fileName);
			this.key.SetString("TypeName", this.toolset.Name);
			this.key.SetString("Id", toolsetInfo.Id.ToString());
			this.key.SetString("Version", toolsetInfo.Version.ToString());
			this.key.SetMultiString("Tools", toolsConfig);
		}


		/// <summary>
		/// Creates a new toolset configuration instance from the registry configuration.
		/// </summary>
		/// <param name="rootKey">The root registry key.</param>
		/// <param name="id">The toolset identifier.</param>
		public ToolsetConfig(RegistryKey rootKey, string id)
		{

		}

		// Public methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Close the registry key.
			this.key.Close();
			// Suppress the finalzer.
			GC.SuppressFinalize(this);
		}
	}
}
