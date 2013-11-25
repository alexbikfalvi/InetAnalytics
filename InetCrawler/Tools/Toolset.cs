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

namespace InetCrawler.Tools
{
	/// <summary>
	/// An interface for a toolset.
	/// </summary>
	public abstract class Toolset
	{
		private readonly ToolsetInfoAttribute info;
		private readonly Dictionary<ToolId, Type> tools = new Dictionary<ToolId, Type>();
		private readonly string name;

		/// <summary>
		/// Creates a new toolset instance.
		/// </summary>
		/// <param name="name">The toolset name.</param>
		public Toolset(string name)
		{
			// Check the arguments.
			if (null == name) throw new ArgumentNullException("name");

			// Set the toolset parameters.
			this.name = name;

			// Get the toolset information.
			this.info = Toolset.GetToolsetInfo(this.GetType());

			// Check the toolset information is not null.
			if (null == this.info) throw new ToolException("Cannot create a toolset object from a class without the toolset information attribute.");
		}

		// Public properties.

		/// <summary>
		/// Returns the tool type for the specified identifier and version.
		/// </summary>
		/// <param name="id">The tool identifier.</param>
		/// <returns>The tool type or null, if the tool does not exist.</returns>
		public Type this[ToolId id] { get { return this.GetTool(id); } }
		/// <summary>
		/// Gets the toolset name.
		/// </summary>
		public string Name { get { return this.name; } }
		/// <summary>
		/// Gets the toolset information.
		/// </summary>
		public ToolsetInfoAttribute Info { get { return this.info; } }
		/// <summary>
		/// Gets the list of tools.
		/// </summary>
		public ICollection<Type> Tools { get { return this.tools.Values; } }

		// Static methods.

		/// <summary>
		/// Checks if the specified type is a toolset.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns><b>True</b> if the type is a toolset, <b>false</b> otherwise.</returns>
		public static bool IsToolset(Type type)
		{
			// Check the type inherits the toolset class.
			if (type.IsSubclassOf(typeof(Toolset)))
			{
				// Check the type has a toolset attribute.
				return type.GetCustomAttributes(typeof(ToolsetInfoAttribute), false).Length > 0;
			}
			else return false;
		}

		/// <summary>
		/// Returns the toolset info for the specified type.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns>The toolset attribute, or <b>null</b> if the attribute does not exist.</returns>
		public static ToolsetInfoAttribute GetToolsetInfo(Type type)
		{
			// Check the type inherits the tool class.
			if (type.IsSubclassOf(typeof(Toolset)))
			{
				// Get the toolset attributes.
				object[] attributes = type.GetCustomAttributes(typeof(ToolsetInfoAttribute), false);
				// If there exists a toolset attribute.
				return attributes.Length > 0 ? attributes[0] as ToolsetInfoAttribute : null;
			}
			else return null;
		}

		// Public methods.

		/// <summary>
		/// Returns the tool type for the specified identifier and version. The method does not throw an exception.
		/// </summary>
		/// <param name="strId">The tool identifier.</param>
		/// <returns>The type or <b>null</b>, if the tool does not exist.</returns>
		public Type GetTool(ToolId id)
		{
			Type type;
			if (this.tools.TryGetValue(id, out type)) return type;
			else return null;
		}

		// Protected methods.

		/// <summary>
		/// Adds the specified tool type to the tools list.
		/// </summary>
		/// <param name="type">The tool type.</param>
		protected void Add(Type type)
		{
			// Get the tool information.
			ToolInfoAttribute info = Tool.GetToolInfo(type);
			// If the information is not null.
			if (null != info)
			{
				// Add the type to the tools list.
				this.tools.Add(info.Id, type);
			}
		}
	}
}
