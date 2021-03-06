﻿/* 
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
using System.Drawing;
using System.Windows.Forms;
using DotNetApi;

namespace InetCommon.Tools
{
	/// <summary>
	/// The base class for an analytics tool.
	/// </summary>
	public abstract class Tool : IDisposable
	{
		private readonly ToolInfoAttribute info;
		private readonly ToolsetInfoAttribute toolset;
		private readonly IToolApi api;
		private readonly Dictionary<Guid, ToolMethod> methods = new Dictionary<Guid, ToolMethod>();

		/// <summary>
		/// Creates a new tool instance.
		/// </summary>
		/// <param name="api">The tool API.</param>
		/// <param name="toolset">The toolset information.</param>
		public Tool(IToolApi api, ToolsetInfoAttribute toolset)
		{
			// Check the arguments.
			if (null == api) throw new ArgumentNullException("api");
			if (null == toolset) throw new ArgumentNullException("toolset");

			// Set the parameters.
			this.api = api;
			this.toolset = toolset;

			// Get the tool information.
			this.info = Tool.GetToolInfo(this.GetType());

			// Check the tool information is not null.
			if (null == this.info) throw new InvalidOperationException("Cannot create a tool object from a class without the tool information attribute.");
		}

		// Public properties.

		/// <summary>
		/// Gets the user interface control for this tool.
		/// </summary>
		public abstract Control Control { get; }
		/// <summary>
		/// Gets the tree view icon for this tool.
		/// </summary>
		public virtual Image Icon { get { return null; } }
		/// <summary>
		/// Gets the tool information.
		/// </summary>
		public ToolInfoAttribute Info { get { return this.info; } }
		/// <summary>
		/// Gets the toolset information.
		/// </summary>
		public ToolsetInfoAttribute Toolset { get { return this.toolset; } }
		/// <summary>
		/// Gets the tool methods.
		/// </summary>
		public IEnumerable<ToolMethod> Methods { get { return this.methods.Values; } }

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

		/// <summary>
		/// Converts the current tool to a string.
		/// </summary>
		/// <returns>The string.</returns>
		public override string ToString()
		{
			return "{0} (version {1})".FormatWith(this.info.Name, this.info.Id.Version);
		}

		/// <summary>
		/// Adds a method to the current tool.
		/// </summary>
		/// <param name="id">The method identifier.</param>
		/// <param name="name">The method name.</param>
		/// <param name="description">The method description.</param>
		/// <param name="action">The method action.</param>
		public void AddMethod(Guid id, string name, string description, ToolMethodAction action)
		{
			this.methods.Add(id, new ToolMethod(this, id, name, description, action));
		}

		/// <summary>
		/// Finds the tool method with the specified identifier.
		/// </summary>
		/// <param name="guid">The method identifier.</param>
		/// <returns>The method, or <b>null</b> if the method does not exist.</returns>
		public ToolMethod GetMethod(Guid guid)
		{
			ToolMethod method;

			if (this.methods.TryGetValue(guid, out method))
			{
				return method;
			}
			else
			{
				return null;
			}
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
