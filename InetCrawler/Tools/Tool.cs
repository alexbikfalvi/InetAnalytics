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
using DotNetApi.Windows.Controls;

namespace InetCrawler.Tools
{
	/// <summary>
	/// The base class for an analytics tool.
	/// </summary>
	public abstract class Tool : IDisposable
	{
		private readonly IToolApi api;

		/// <summary>
		/// Creates a new tool instance.
		/// </summary>
		/// <param name="api">The tool API.</param>
		public Tool(IToolApi api)
		{
			// Set the tool API.
			this.api = api;
		}

		// Public properties.

		/// <summary>
		/// Gets the user interface control for this tool.
		/// </summary>
		public abstract ThemeControl Control { get; }

		// Protected properties.

		/// <summary>
		/// Gets the tool API.
		/// </summary>
		protected IToolApi Api { get { return this.api; } }

		// Public static methods.

		/// <summary>
		/// Checks if the specified type is a tool type.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns><b>True</b> if the specified type is a tool attribute, <b>false</b> otherwise.</returns>
		public static bool IsTool(Type type)
		{
			// Check the type inherits the tool class.
			if (type.IsSubclassOf(typeof(Tool)))
			{
				// Check the type has a tool attribute.
				return type.GetCustomAttributes(typeof(ToolInfoAttribute), false).Length > 0;
			}
			else return false;
		}

		/// <summary>
		/// Returns the tool info for the specified type.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns>The tool attribute, or <b>null</b> if the attribute does not exist.</returns>
		public static ToolInfoAttribute GetToolInfo(Type type)
		{
			// Check the type inherits the tool class.
			if (type.IsSubclassOf(typeof(Tool)))
			{
				// Get the tool attributes.
				object[] attributes = type.GetCustomAttributes(typeof(ToolInfoAttribute), false);
				// If there exists a tool attribute.
				return attributes.Length > 0 ? attributes[0] as ToolInfoAttribute : null;
			}
			else return null;
		}

		// Public methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Call the dispose method.
			this.Dispose(true);
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		// Protected methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		/// <param name="disposing">If <b>true</b>, clean both managed and native resources. If <b>false</b>, clean only native resources.</param>
		protected virtual void Dispose(bool disposing)
		{
		}
	}
}
