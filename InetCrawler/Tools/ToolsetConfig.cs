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
	public sealed class ToolsetConfig : IDisposable, IEnumerable<Tool>
	{
		private readonly IToolApi api;
		private readonly RegistryKey key;

		private readonly string fileName;
		private readonly Toolset toolset;

		private readonly object sync = new object();
		private readonly Dictionary<ToolId, Tool> tools = new Dictionary<ToolId, Tool>();

		/// <summary>
		/// Creates a new toolset configuration instance.
		/// </summary>
		/// <param name="api">The tool API.</param>
		/// <param name="rootKey">The root registry key.</param>
		/// <param name="fileName">The library file name.</param>
		/// <param name="toolset">The toolset.</param>
		public ToolsetConfig(IToolApi api, RegistryKey rootKey, string fileName, Toolset toolset)
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

			// Open a registry key for the toolbox.
			if (null == (this.key = rootKey.OpenSubKey("{0},{1}".FormatWith(this.toolset.Info.Id.Guid.ToString(), this.toolset.Info.Id.Version.ToString()), RegistryKeyPermissionCheck.ReadWriteSubTree)))
			{
				this.key = rootKey.CreateSubKey("{0},{1}".FormatWith(this.toolset.Info.Id.Guid.ToString(), this.toolset.Info.Id.Version.ToString()), RegistryKeyPermissionCheck.ReadWriteSubTree);
			}

			// Save the toolset configuration.
			this.key.SetString("FileName", this.fileName);
			this.key.SetString("TypeName", this.toolset.Name);
			this.key.SetString("Id", this.toolset.Info.Id.Guid.ToString());
			this.key.SetString("Version", this.toolset.Info.Id.Version.ToString());
		}


		/// <summary>
		/// Creates a new toolset configuration instance from the registry configuration.
		/// </summary>
		/// <param name="api">The tool API.</param>
		/// <param name="rootKey">The root registry key.</param>
		/// <param name="keyName">The registry key name.</param>
		/// <
		public ToolsetConfig(IToolApi api, RegistryKey rootKey, string keyName)
		{
			// Check the arguments.
			if (null == api) throw new ArgumentNullException("api");
			if (null == rootKey) throw new ArgumentNullException("rootKey");
			if (null == keyName) throw new ArgumentNullException("keyName");

			// Set the toolset parameters.
			this.api = api;

			// Open the registry key for the toolbox.
			if (null == (this.key = rootKey.OpenSubKey(keyName, RegistryKeyPermissionCheck.ReadWriteSubTree)))
			{
				throw new InvalidOperationException("Cannot create the toolset configuration because the registry key is not accessible.");
			}

			// Load the toolset configuration.
			this.fileName = this.key.GetString("FileName", null);
			string toolsetType = this.key.GetString("TypeName", null);
			string toolsetId = this.key.GetString("Id", null);
			string toolsetVersion = this.key.GetString("Version", null);
			string[] toolsetTools = this.key.GetMultiString("Tools", null);

			// Open the toolset from the specified library.
			Assembly assembly = Assembly.LoadFrom(this.fileName);

			// Get the toolset type.
			Type type = assembly.GetType(toolsetType, true);

			// If the type is a toolset.
			if (Toolset.IsToolset(type))
			{
				// Create a new toolset instance.
				this.toolset = Activator.CreateInstance(type, new object[] { this.api, type.FullName }) as Toolset;
			}
			else
			{
				throw new InvalidOperationException("Cannot create the toolset configuration because the specified type is not a toolset.");
			}

			// Load the tools.
			if (null != toolsetTools)
			{
				// For each tool information.
				foreach (string tool in toolsetTools)
				{
					// Split the tool information between identifier and version.
					string[] toolParams = tool.Split(',');
					// If the information does not have exactly two parameters, skip.
					if (2 != toolParams.Length) continue;
					// Get the tool type from the toolset.
					Type toolType = this.toolset[toolParams[0], toolParams[1]];
					// If the tool type is null, skip.
					if (null == toolType) continue;
					// Add the tool to the tools list.
					this.OnAddInternal(toolType);
				}
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
			// Close the registry key.
			this.key.Close();
			// Suppress the finalzer.
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Gets the enumerator for the current toolset.
		/// </summary>
		/// <returns>The enumerator.</returns>
		public IEnumerator<Tool> GetEnumerator()
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
		public void Add(Type[] tools)
		{
			lock (this.sync)
			{
				// Create the tools.
				for (int index = 0; index < tools.Length; index++)
				{
					// The tool.
					Tool tool = null;
					// If adding the tool was successful.
					if (null != (tool = this.OnAddInternal(tools[index])))
					{
						// Raise a tool added event.
						if (null != this.ToolAdded) this.ToolAdded(this, new ToolEventArgs(tool));
					}
				}

				// Save the toolset configuration.
				this.OnSaveConfiguration();
			}
		}

		/// <summary>
		/// Removes the specified tool from the toolset configuration.
		/// </summary>
		/// <param name="tool">The tool.</param>
		/// <returns><b>True</b> if the toolset is empty and can be unloaded, <b>false</b> otherwise.</returns>
		public bool Remove(Tool tool)
		{
			try
			{
				// Remove the tool from the toolset.
				this.tools.Remove(tool.Info.Id);
				// Raise a tool removed event.
				if (null != this.ToolRemoved) this.ToolRemoved(this, new ToolEventArgs(tool));
				// Update the tools configuration.
				this.OnSaveConfiguration();
			}
			finally
			{
				// Dispose the tool.
				tool.Dispose();
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
			// Get the registry key name.
			string keyName = "{0},{1}".FormatWith(toolset.toolset.Info.Id.Guid.ToString(), toolset.toolset.Info.Id.Version.ToString());
			// Close the toolset.
			toolset.Dispose();
			// Delete the registry configuration.
			rootKey.DeleteSubKeyTree(keyName);
		}

		// Private methods.

		/// <summary>
		/// Saves the toolset configuration.
		/// </summary>
		private void OnSaveConfiguration()
		{
			// Create the list of tools identifiers.
			string[] toolsConfig = new string[this.tools.Values.Count];

			int index = 0;
			// For all tools.
			foreach (Tool tool in this.tools.Values)
			{
				// Set the tool identifier.
				toolsConfig[index++] = "{0},{1}".FormatWith(tool.Info.Id.Guid.ToString(), tool.Info.Id.Version.ToString());
			}
			// Save the configuration to the registry.
			this.key.SetMultiString("Tools", toolsConfig);
		}

		/// <summary>
		/// Adds the tool of the specified type from the current toolbox to the tools list. The method does not change the configuration, nor
		/// does it raise a tool added event.
		/// </summary>
		/// <param name="type">The tool type.</param>
		/// <returns>The tool instance if the operation was successful, <b>false</b> otherwise.</returns>
		private Tool OnAddInternal(Type type)
		{
			// Get the tool info.
			ToolInfoAttribute info = Tool.GetToolInfo(type);

			// If the type does not have a tool information, skip the type.
			if (null == info) return null;

			// If the tool has already been loaded to the toolset, do nothing.
			if (this.tools.ContainsKey(info.Id)) return null;

			try
			{
				// Create the tool instance.
				Tool tool = Activator.CreateInstance(type, new object[] { this.api, this.toolset.Info }) as Tool;

				// Add the tool to the tools dictionary.
				this.tools.Add(tool.Info.Id, tool);

				// Return the tool.
				return tool;
			}
			catch (Exception exception)
			{
				// Log the exception.
				this.api.Log(this.toolset, LogEventLevel.Important, LogEventType.Error,
					"Loading the tool of type {0} from the toolset {1} failed.",
					new object[] { type.FullName, this.toolset.Info.Id },
					exception);
			}
			// Return null.
			return null;
		}
	}
}
