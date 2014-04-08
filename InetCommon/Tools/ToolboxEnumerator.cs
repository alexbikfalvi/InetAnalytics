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

namespace InetCommon.Tools
{
	/// <summary>
	/// An enumerator that enumerates all tools in a toolbox.
	/// </summary>
	public sealed class ToolboxEnumerator : IEnumerator<Tool>
	{
		private readonly IEnumerator<ToolsetConfig> enumeratorToolset;
		private IEnumerator<ToolConfig> enumeratorTool = null;

		/// <summary>
		/// Creates a toolbox enumerator instance.
		/// </summary>
		public ToolboxEnumerator(IEnumerable<ToolsetConfig> enumerable)
		{
			// Get the toolset enumerator.
			this.enumeratorToolset = enumerable.GetEnumerator();
			// Set the current element.
			this.Current = null;
		}

		// Public properties.

		/// <summary>
		/// Gets the element in the collection at the current position of the enumerator.
		/// </summary>
		public Tool Current { get; private set; }
		/// <summary>
		/// Gets the element in the collection at the current position of the enumerator.
		/// </summary>
		object IEnumerator.Current { get { return this.Current; } }

		// Public methods.

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			// Dispose the enumerators.
			if (null != this.enumeratorToolset) this.enumeratorToolset.Dispose();
			if (null != this.enumeratorTool) this.enumeratorTool.Dispose();
		}

		/// <summary>
		/// Advances the enumerator to the next element of the collection.
		/// </summary>
		/// <returns><b>True</b> if the enumerator was successfully advanced to the next element; <b>false</b> if the enumerator has passed the end of the collection.</returns>
		public bool MoveNext()
		{
			// If the tool enumerator is null.
			if (null == this.enumeratorTool)
			{
				// Find the next toolset element.
				while (this.enumeratorToolset.MoveNext())
				{
					// Get an enumerator for the toolset.
					this.enumeratorTool = this.enumeratorToolset.Current.GetEnumerator();
					// Move to the next element in the toolset.
					if (this.MoveNext())
					{
						// Return true;
						return true;
					}
				}
				// Return false.
				return false;
			}
			else
			{
				// Move to the next element in the toolset.
				if (this.enumeratorTool.MoveNext())
				{
					// Set the element.
					this.Current = this.enumeratorTool.Current.Tool;
					// Set the element.
					return true;
				}
				else
				{
					// Dispose the tool enumerator.
					this.enumeratorTool.Dispose();
					// Set the tool enumerator to null.
					this.enumeratorTool = null;
					// Return false.
					return false;
				}
			}
		}

		/// <summary>
		/// Sets the enumerator to its initial position, which is before the first element in the collection.
		/// </summary>
		public void Reset()
		{
			// If the tool enumerator is not null.
			if (null != this.enumeratorTool)
			{
				// Dispose the tool enumerator.
				this.enumeratorTool.Dispose();
				// Set the tool enumerator to null.
				this.enumeratorTool = null;
			}
			// Reset the toolset enumerator.
			this.enumeratorToolset.Reset();
		}
	}
}
