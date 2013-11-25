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
using DotNetApi;
using InetCrawler.Log;

namespace InetCrawler.Tools
{
	/// <summary>
	/// A class representing the tool configuration.
	/// </summary>
	public sealed class ToolConfig : IDisposable
	{
		private static readonly string logSourceToolset = @"Toolbox\{0}";
		private static readonly string logSourceTool = @"Toolbox\{0}\{1}";

		private readonly CrawlerApi api;
		private readonly Toolset toolset;

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
			// Validate the arguments.
			if (null == api) throw new ArgumentNullException("api");
			if (null == toolset) throw new ArgumentNullException("toolset");
			if (null == rootKey) throw new ArgumentNullException("rootKey");

			// Set the parameters.
			this.api = api;
			this.toolset = toolset;

			// Get the tool type.
			Type type = this.toolset[id];

			// Check the type is not null.
			if (null == type) throw new ToolException("Cannot create a tool because the tool identifier {0} was not found in the toolset {1}.".FormatWith(id, this.toolset.Info.Id), this.toolset.Info);

			// Open or create the registry key for this tool.
			if (null == (this.key = rootKey.OpenSubKey(id.ToString(), RegistryKeyPermissionCheck.ReadWriteSubTree)))
			{
				this.key = rootKey.CreateSubKey(id.ToString(), RegistryKeyPermissionCheck.ReadWriteSubTree);
			}

			// Get the tool info.
			ToolInfoAttribute info = Tool.GetToolInfo(type);

			// Create the tool API.
			ToolApi toolApi = new ToolApi(api, this.toolset.Info, info, this.key);

			try
			{
				// Create the tool instance.
				this.tool = Activator.CreateInstance(type, new object[] { toolApi, this.toolset.Info }) as Tool;
			}
			catch (Exception exception)
			{
				// Log the exception.
				api.Log.Add(
					LogEventLevel.Important,
					LogEventType.Error,
					ToolConfig.logSourceTool.FormatWith(toolset.Info.Id, id),
					"Loading the tool of type {0} from the toolset {1} failed.",
					new object[] { type.FullName, this.toolset.Info.Id },
					exception);
				
				// Close the registry key.
				this.key.Close();
				
				// Throw an exception.
				throw new ToolException("Cannot create an instance of the tool {0} from the toolset {1}.".FormatWith(id, this.toolset.Info.Id), exception, this.toolset.Info, info);
			}
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
			// Dispose the tool object.
			this.tool.Dispose();
			// Close the registry key.
			this.key.Close();
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Deletes the specified tool configuration.
		/// </summary>
		/// <param name="tool">The tool.</param>
		/// <param name="rootKey">The root registry key.</param>
		public static void Delete(ToolConfig tool, RegistryKey rootKey)
		{
			// Save the tool identifier.
			ToolId id = tool.tool.Info.Id;
			// Close the toolset.
			tool.Dispose();
			// Delete the registry key.
			rootKey.DeleteSubKeyTree(id.ToString());
		}
	}
}
