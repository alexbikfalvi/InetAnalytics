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
using DotNetApi.Windows;
using InetCrawler.Tools;
using InetCrawler.Log;

namespace InetCrawler.Tools
{
	/// <summary>
	/// A class representing the toolset configuration.
	/// </summary>
	public sealed class ToolsetConfig : IDisposable, IEnumerable<ToolConfig>
	{
		private static readonly string logSource = @"Toolbox\{0}";

		private readonly CrawlerApi api;
		private readonly RegistryKey key;

		private readonly string fileName;
		private readonly Toolset toolset;

		private readonly object sync = new object();
		private readonly Dictionary<ToolId, ToolConfig> tools = new Dictionary<ToolId, ToolConfig>();

		/// <summary>
		/// Creates a new toolset configuration instance without tools.
		/// </summary>
		/// <param name="api">The crawler API.</param>
		/// <param name="rootKey">The root registry key.</param>
		/// <param name="fileName">The library file name.</param>
		/// <param name="toolset">The toolset.</param>
		public ToolsetConfig(CrawlerApi api, RegistryKey rootKey, string fileName, Toolset toolset)
		{
			// Check the arguments.
			if (null == api) throw new ArgumentNullException("api");
			if (null == rootKey) throw new ArgumentNullException("rootKey");
			if (null == fileName) throw new ArgumentNullException("fileName");
			if (null == toolset) throw new ArgumentNullException("toolset");

			// Set the toolset parameters.
			this.api = api;
			this.fileName = fileName;
			this.toolset = toolset;

			// Open a registry key for the toolset.
			if (null == (this.key = rootKey.OpenSubKey(this.toolset.Info.Id.ToString(), RegistryKeyPermissionCheck.ReadWriteSubTree)))
			{
				this.key = rootKey.CreateSubKey(this.toolset.Info.Id.ToString(), RegistryKeyPermissionCheck.ReadWriteSubTree);
			}

			// Save the toolset configuration.
			this.key.SetString("FileName", this.fileName);
			this.key.SetString("TypeName", this.toolset.Name);
			this.key.SetString("Id", this.toolset.Info.Id.Guid.ToString());
			this.key.SetString("Version", this.toolset.Info.Id.Version.ToString());
		}

		/// <summary>
		/// Creates a new toolset configuration for the specified toolset.
		/// </summary>
		/// <param name="api">The tool API.</param>
		/// <param name="rootKey">The root registry key.</param>
		/// <param name="toolset">The toolset.</param>
		public ToolsetConfig(CrawlerApi api, RegistryKey rootKey, Toolset toolset)
		{
			// Check the arguments.
			if (null == api) throw new ArgumentNullException("api");
			if (null == rootKey) throw new ArgumentNullException("rootKey");
			if (null == toolset) throw new ArgumentNullException("toolset");

			// Set the toolset parameters.
			this.api = api;
			this.toolset = toolset;

			// Open a registry key for the toolset.
			if (null == (this.key = rootKey.OpenSubKey(this.toolset.Info.Id.ToString(), RegistryKeyPermissionCheck.ReadWriteSubTree)))
			{
				this.key = rootKey.CreateSubKey(this.toolset.Info.Id.ToString(), RegistryKeyPermissionCheck.ReadWriteSubTree);
			}

			// Save the toolset configuration.
			this.key.SetString("TypeName", this.toolset.Name);
			this.key.SetString("Id", this.toolset.Info.Id.Guid.ToString());
			this.key.SetString("Version", this.toolset.Info.Id.Version.ToString());
		}

		/// <summary>
		/// Creates a new toolset configuration instance from the registry configuration.
		/// </summary>
		/// <param name="api">The tool API.</param>
		/// <param name="rootKey">The root registry key.</param>
		/// <param name="id">The toolset identifier.</param>
		public ToolsetConfig(CrawlerApi api, RegistryKey rootKey, ToolId id)
		{
			// Check the arguments.
			if (null == api) throw new ArgumentNullException("api");
			if (null == rootKey) throw new ArgumentNullException("rootKey");

			// Set the toolset parameters.
			this.api = api;

			// Open the registry key for the toolset.
			if (null == (this.key = rootKey.OpenSubKey(id.ToString(), RegistryKeyPermissionCheck.ReadWriteSubTree)))
			{
				throw new ToolException("Cannot create the toolset configuration because the registry key is not accessible.");
			}

			// Load the toolset configuration.
			this.fileName = this.key.GetString("FileName", null);
			string toolsetType = this.key.GetString("TypeName", null);
			string toolsetId = this.key.GetString("Id", null);
			string toolsetVersion = this.key.GetString("Version", null);

			// Open the toolset from the specified library.
			Assembly assembly = Assembly.LoadFrom(this.fileName);

			// Get the toolset type.
			Type type = assembly.GetType(toolsetType, true);

			// If the type is a toolset.
			if (Toolset.IsToolset(type))
			{
				// Create a new toolset instance.
				this.toolset = Activator.CreateInstance(type, new object[] { type.FullName }) as Toolset;
			}
			else
			{
				throw new ToolException("Cannot create the toolset configuration because the specified type is not a toolset.");
			}

			// For all subkeys of the toolset key.
			foreach (string subKey in this.key.GetSubKeyNames())
			{
				// Get the tool identifier for this key.
				ToolId toolId;
				// Try and parse the tool identifier.
				if (!ToolId.TryParse(subKey, out toolId)) continue;

				// Add the tool to the toolset.
				this.OnAdd(toolId);
			}
		}

		// Public events.

		/// <summary>
		/// An event raised when a tool was added.
		/// </summary>
		public event ToolEventHandler ToolAdded;
		/// <summary>
		/// An event raised when a tool was removed.
		/// </summary>
		public event ToolEventHandler ToolRemoved;

		// Public properties.

		/// <summary>
		/// Gets the toolset.
		/// </summary>
		public Toolset Toolset { get { return this.toolset; } }

		// Public methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Dispose the current tools.
			foreach (ToolConfig tool in this.tools.Values)
			{
				tool.Dispose();
			}
			// Close the registry key.
			this.key.Close();
			// Suppress the finalzer.
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Gets the enumerator for the current toolset.
		/// </summary>
		/// <returns>The enumerator.</returns>
		public IEnumerator<ToolConfig> GetEnumerator()
		{
			return this.tools.Values.GetEnumerator();
		}

		/// <summary>
		/// Gets the enumerator for the current toolset.
		/// </summary>
		/// <returns>The enumerator.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		/// <summary>
		/// Adds the specified collection of tools to the toolset.
		/// </summary>
		/// <param name="tools">The tools.</param>
		public void Add(ToolId[] tools)
		{
			lock (this.sync)
			{
				// For all tool identifiers.
				foreach (ToolId id in tools)
				{
					// Add the tool.
					this.OnAdd(id);
				}
			}
		}

		/// <summary>
		/// Removes the specified tool from the toolset configuration.
		/// </summary>
		/// <param name="tool">The tool.</param>
		/// <returns><b>True</b> if the toolset is empty and can be unloaded, <b>false</b> otherwise.</returns>
		public bool Remove(Tool tool)
		{
			lock (this.sync)
			{
				// The tool configuration.
				ToolConfig config;
				// If the toolset contains the tool.
				if (this.tools.TryGetValue(tool.Info.Id, out config))
				{
					// Remove the tool from the toolset.
					this.tools.Remove(tool.Info.Id);
					// Close the tool and remove its configuration.
					ToolConfig.Delete(config, this.key);
					// Raise a tool removed event.
					if (null != this.ToolRemoved) this.ToolRemoved(this, new ToolEventArgs(tool));
				}
			}
			// Return whether the toolset is empty.
			return this.tools.Count == 0;
		}

		/// <summary>
		/// Deletes the specified toolset configuration.
		/// </summary>
		/// <param name="toolset">The toolset.</param>
		/// <param name="rootKey">The root registry key.</param>
		public static void Delete(ToolsetConfig toolset, RegistryKey rootKey)
		{
			// Save the toolset identifier.
			ToolId id = toolset.toolset.Info.Id;
			// Close the toolset.
			toolset.Dispose();
			// Delete the registry configuration.
			rootKey.DeleteSubKeyTree(id.ToString());
		}

		// Private methods.

		/// <summary>
		/// Saves the toolset configuration.
		/// </summary>
		//private void OnSaveConfiguration()
		//{
		//	// Create the list of tools identifiers.
		//	string[] toolsConfig = new string[this.tools.Values.Count];

		//	int index = 0;
		//	// For all tools.
		//	foreach (Tool tool in this.tools.Values)
		//	{
		//		// Set the tool identifier.
		//		toolsConfig[index++] = "{0},{1}".FormatWith(tool.Info.Id.Guid.ToString(), tool.Info.Id.Version.ToString());
		//	}
		//	// Save the configuration to the registry.
		//	this.key.SetMultiString("Tools", toolsConfig);
		//}

		/// <summary>
		/// Adds the tool with the specified identifier to the toolset.
		/// </summary>
		/// <param name="toolId">The tool identifier.</param>
		/// <returns><b>True</b> if the tool was added to the toolset, <b>false</b> if the tool already existed or could not be loaded.</returns>
		private bool OnAdd(ToolId toolId)
		{
			lock (this.sync)
			{
				// If the tool has already been loaded to the toolset, skip to the next tool.
				if (this.tools.ContainsKey(toolId)) return false;

				try
				{
					// Create the tool configuration.
					ToolConfig tool = new ToolConfig(this.api, this.toolset, this.key, toolId);

					// Add the tool configuration.
					this.tools.Add(tool.Tool.Info.Id, tool);

					// Raise the tool added event.
					if (null != this.ToolAdded) this.ToolAdded(this, new ToolEventArgs(tool.Tool));

					// Return true.
					return true;
				}
				catch (Exception exception)
				{
					// Log the exception.
					this.api.Log.Add(
						LogEventLevel.Important,
						LogEventType.Error,
						ToolsetConfig.logSource.FormatWith(this.toolset.Info.Id),
						"Loading the tool {0} from the toolset {1} failed.",
						new object[] { toolId, this.toolset.Info.Id },
						exception);

					// Return false.
					return false;
				}
			}
		}
	}
}
