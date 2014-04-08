/* 
 * Copyright (C) 2014 Alex Bikfalvi
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
using System.Windows.Forms;

namespace InetCommon.Tools
{
	/// <summary>
	/// A class representing a tool item.
	/// </summary>
	public abstract class ToolItem : IDisposable
	{
		private readonly Tool tool;
		private readonly IToolApi api;

		/// <summary>
		/// Creates a new tool item instance.
		/// </summary>
		/// <param name="tool">The tool.</param>
		/// <param name="api">The tool API.</param>
		public ToolItem(Tool tool, IToolApi api)
		{
			this.tool = tool;
			this.api = api;
		}

		// Public properties.

		/// <summary>
		/// Gets the user interface control for this tool.
		/// </summary>
		public abstract Control Control { get; }

		// Protected properties.

		/// <summary>
		/// Gets the tool for this tool item.
		/// </summary>
		protected Tool Tool { get { return this.tool; } }
		/// <summary>
		/// Gets the tool API.
		/// </summary>
		protected IToolApi Api { get { return this.api; } }

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
