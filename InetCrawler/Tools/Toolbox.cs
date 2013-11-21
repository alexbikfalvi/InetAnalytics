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
using InetCrawler.Log;
using InetCrawler.Tools;

namespace InetCrawler.Tools
{
	/// <summary>
	/// A class representing the Internet Analytics toolbox.
	/// </summary>
	public sealed class Toolbox : IEnumerable<Tool>
	{
		private readonly Logger log;
		private readonly IToolApi api;

		private readonly object sync = new object();

		private readonly RegistryKey key;
		private readonly Dictionary<Guid, ToolsetConfig> toolsets = new Dictionary<Guid, ToolsetConfig>();

		/// <summary>
		/// Creates a new toolbox instance.
		/// </summary>
		/// <param name="log">The log.</param>
		/// <param name="api">The tools API.</param>
		/// <param name="rootKey">The root registry key.</param>
		/// <param name="path">The registry path.</param>
		public Toolbox(Logger log, IToolApi api, RegistryKey rootKey, string path)
		{
			// Check the arguments.
			if (null == log) throw new ArgumentNullException("log");
			if (null == api) throw new ArgumentNullException("api");
			if (null == rootKey) throw new ArgumentNullException("rootKey");
			if (null == path) throw new ArgumentNullException("path");

			// Set the log.
			this.log = log;
			// Set the tool API.
			this.api = api;
			// Open a registry key for the toolbox.
			if (null == (this.key = rootKey.OpenSubKey(path, RegistryKeyPermissionCheck.ReadWriteSubTree)))
			{
				this.key = rootKey.CreateSubKey(path, RegistryKeyPermissionCheck.ReadWriteSubTree);
			}

			// Load the configuration.
			this.OnLoadConfiguration();
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
				foreach (ToolsetConfig toolset in this.toolsets.Values)
				{
					// Remove the event handlers.
					toolset.ToolAdded -= this.OnToolAdded;
					toolset.ToolRemoved -= this.OnToolRemoved;
					// Dispose the toolset configuration.
					toolset.Dispose();
				}
			}
			// Close the registry key.
			this.key.Close();
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		public IEnumerator<Tool> GetEnumerator()
		{
			return new ToolboxEnumerator(this.toolsets.Values);
		}

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
			lock (this.sync)
			{
				// The toolset configuratin.
				ToolsetConfig config = null;
				// Check if there exists a toolset configuration for the specified toolset.
				if (!this.toolsets.TryGetValue(toolset.Info.Id, out config))
				{
					// Create the toolset configuration.
					config = new ToolsetConfig(this.api, this.key, fileName, toolset);
					// Add the configuration to the toolset list.
					this.toolsets.Add(toolset.Info.Id, config);
					// Add the configuration event handlers.
					config.ToolAdded += this.OnToolAdded;
					config.ToolRemoved += this.OnToolRemoved;
				}
				// Add the tools to the toolset configuration.
				config.Add(tools);
			}
		}

		/// <summary>
		/// Loads the toolbox configuration.
		/// </summary>
		public void OnLoadConfiguration()
		{
			lock (this.sync)
			{
				// For all subkeys of the toolbox key.
				foreach (string id in this.key.GetSubKeyNames())
				{
					try
					{
						// Create a toolset for the repective key.
						ToolsetConfig config = new ToolsetConfig(this.api, this.key, id);

						// Add the toolset configuration.
						this.toolsets.Add(config.Toolset.Info.Id, config);
					}
					catch (Exception exception)
					{
						// If an exception occurred, log an event.
						this.log.Add(
							LogEventLevel.Important,
							LogEventType.Error,
							"Toolbox",
							"An error occurred while loading the configuration for the toolset {0}.",
							new object[] { id },
							exception);
					}
				}
			}
		}

		/// <summary>
		/// Saves the toolbox configuration.
		/// </summary>
		public void OnSaveConfiguration()
		{

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
