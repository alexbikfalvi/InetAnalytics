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
using System.Linq;
using System.Reflection;
using Microsoft.Win32;
using DotNetApi;
using InetCommon.Database;
using InetCommon.Log;
using InetCommon.Tools;

namespace InetCommon.Tools
{
	/// <summary>
	/// A class representing the Internet Analytics toolbox.
	/// </summary>
	public sealed class Toolbox : IEnumerable<Tool>
	{
		private static readonly string logSource = "Toolbox";

		private readonly IDbApplication config;

		private readonly object sync = new object();

		private readonly RegistryKey key;
		private readonly Dictionary<ToolId, ToolsetConfig> toolsets = new Dictionary<ToolId, ToolsetConfig>();

		private IEnumerable<Tool> tools = null;
		private IOrderedEnumerable<Tool> orderedTools = null;

		/// <summary>
		/// Creates a new toolbox instance.
		/// </summary>
		/// <param name="config">The configuration.</param>
		/// <param name="rootKey">The root registry key.</param>
		/// <param name="path">The registry path.</param>
		public Toolbox(IDbApplication config, RegistryKey rootKey, string path)
		{
			// Check the arguments.
			if (null == config) throw new ArgumentNullException("api");
			if (null == rootKey) throw new ArgumentNullException("rootKey");
			if (null == path) throw new ArgumentNullException("path");

			// Set the configuration.
			this.config = config;
			// Open a registry key for the toolbox.
			if (null == (this.key = rootKey.OpenSubKey(path, RegistryKeyPermissionCheck.ReadWriteSubTree)))
			{
				this.key = rootKey.CreateSubKey(path, RegistryKeyPermissionCheck.ReadWriteSubTree);
			}

			// Load the configuration toolsets.
			lock (this.sync)
			{
				// Load the registry configuration.
				foreach (string subKey in this.key.GetSubKeyNames())
				{
					// Get the tool identifier for this key.
					ToolId toolsetId;
					// Try and parse the tool identifier.
					if (!ToolId.TryParse(subKey, out toolsetId)) continue;

					lock (this.sync)
					{
						// If the toolset has already been loaded to the toolbox, skip to the next toolset.
						if (this.toolsets.ContainsKey(toolsetId)) continue;

						try
						{
							// Create a toolset for the repective key.
							ToolsetConfig toolsetConfig = new ToolsetConfig(this.config, this.key, toolsetId);

							// Add the toolset configuration.
							this.toolsets.Add(toolsetId, toolsetConfig);

							// Add the configuration event handlers.
							toolsetConfig.ToolAdded += this.OnToolAdded;
							toolsetConfig.ToolRemoved += this.OnToolRemoved;
						}
						catch (Exception exception)
						{
							// If an exception occurred, log an event.
							this.config.Log.Add(
								LogEventLevel.Important,
								LogEventType.Error,
								Toolbox.logSource,
								"An error occurred while loading the configuration for the toolset {0}.",
								new object[] { toolsetId },
								exception);
						}
					}
				}
			}
		}

		// Public events.

		/// <summary>
		/// An event raised when a tool was added to the toolbox.
		/// </summary>
		public event ToolEventHandler ToolAdded;
		/// <summary>
		/// An event raised when a tool was removed from the toolbox.
		/// </summary>
		public event ToolEventHandler ToolRemoved;

		// Public methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Dispose the toolsets.
			lock (this.sync)
			{
				// For all toolset configurations.
				foreach (ToolsetConfig toolsetConfig in this.toolsets.Values)
				{
					// Remove the event handlers.
					toolsetConfig.ToolAdded -= this.OnToolAdded;
					toolsetConfig.ToolRemoved -= this.OnToolRemoved;
					// Dispose the toolset configuration.
					toolsetConfig.Dispose();
				}
			}
			// Close the registry key.
			this.key.Close();
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Returns the generic enumerator for the toolbox.
		/// </summary>
		/// <returns>The enumerator.</returns>
		public IEnumerator<Tool> GetEnumerator()
		{
			lock (this.sync)
			{
				// Unordered tools list.
				this.tools = new ToolboxEnumerable(this.toolsets.Values);
				// Order the tools list.
				this.orderedTools = Enumerable.OrderBy<Tool, string>(this.tools, selector => selector.Info.Name);
				// Return the ordered list enumerator.
				return this.orderedTools.GetEnumerator();
			}
		}

		/// <summary>
		/// Returns the non-generic enumerator for the toolbox.
		/// </summary>
		/// <returns>The enumerator.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
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
					return Activator.CreateInstance(type, new object[] { type.FullName }) as Toolset;
				}
			}
			// Else, throw an exception.
			throw new ToolException("Cannot find an Internet Analytics toolset in the specified library.");
		}

		/// <summary>
		/// Adds the specified toolset and tools to the toolbox.
		/// </summary>
		/// <param name="fileName">The library file name.</param>
		/// <param name="toolset">The toolset.</param>
		/// <param name="tools">The tools.</param>
		public void Add(string fileName, Toolset toolset, ToolId[] tools)
		{
			lock (this.sync)
			{
				// The toolset configuratin.
				ToolsetConfig toolsetConfig = null;
				// Check if there exists a toolset configuration for the specified toolset.
				if (!this.toolsets.TryGetValue(toolset.Info.Id, out toolsetConfig))
				{
					// Create the toolset configuration.
					toolsetConfig = new ToolsetConfig(this.config, this.key, fileName, toolset);
					// Add the configuration to the toolset list.
					this.toolsets.Add(toolset.Info.Id, toolsetConfig);
					// Add the configuration event handlers.
					toolsetConfig.ToolAdded += this.OnToolAdded;
					toolsetConfig.ToolRemoved += this.OnToolRemoved;
				}
				// Add the tools to the toolset configuration.
				toolsetConfig.Add(tools);
			}
		}

		/// <summary>
		/// Removes the specified tool from the toolbox.
		/// </summary>
		/// <param name="tool">The tool.</param>
		public void Remove(Tool tool)
		{
			lock (this.sync)
			{
				// The toolset configuration.
				ToolsetConfig toolsetConfig;
				// Get the toolset configuration for this tool.
				if (this.toolsets.TryGetValue(tool.Toolset.Id, out toolsetConfig))
				{
					// Remove the tool from the toolset configuration.
					if (toolsetConfig.Remove(tool))
					{
						// Remove the configuration event handlers.
						toolsetConfig.ToolAdded -= this.OnToolAdded;
						toolsetConfig.ToolRemoved -= this.OnToolRemoved;
						// If the toolset is empty, remove the toolset.
						this.toolsets.Remove(toolsetConfig.Toolset.Info.Id);
						// Close the toolset and delete its configuration.
						ToolsetConfig.Delete(toolsetConfig, this.key);
					}
				}
			}
		}

		/// <summary>
		/// Finds the tool with the specified identifier and version.
		/// </summary>
		/// <param name="guid">The tool identifier.</param>
		/// <param name="version">The tool version.</param>
		/// <returns>The tool or <b>null</b> if the tool does not exist.</returns>
		public Tool GetTool(Guid guid, Version version)
		{
			return this.FirstOrDefault(tool => (tool.Info.Id.Guid == guid) && (tool.Info.Id.Version == version));
		}

		// Private methods.

		/// <summary>
		/// An event handler called when a tool was added to a toolset.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnToolAdded(object sender, ToolEventArgs e)
		{
			// Raise the tool added event.
			if (null != this.ToolAdded) this.ToolAdded(sender, e);
		}

		/// <summary>
		/// An event handler called when a tool was removed from a toolset.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnToolRemoved(object sender, ToolEventArgs e)
		{
			// Raise the tool removed event.
			if (null != this.ToolRemoved) this.ToolRemoved(sender, e);
		}
	}
}
