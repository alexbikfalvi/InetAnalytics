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

namespace InetCommon.Database
{
	/// <summary>
	/// A collection of database relationship templates.
	/// </summary>
	public sealed class DbRelationshipTemplates : IEnumerable<DbRelationshipTemplate>
	{
		private readonly List<DbRelationshipTemplate> templates = new List<DbRelationshipTemplate>();

		/// <summary>
		/// Creates a new collection of relationship templates.
		/// </summary>
		public DbRelationshipTemplates()
		{
		}

		// Public events.

		/// <summary>
		/// An event raised when a database relationship template was added.
		/// </summary>
		public event DbRelationshipTemplateEventHandler TemplateAdded;
		/// <summary>
		/// An event raised when a database relationship template was removed. 
		/// </summary>
		public event DbRelationshipTemplateEventHandler TemplateRemoved;

		// Public methods.

		/// <summary>
		/// Gets the enumerator for the list of templates.
		/// </summary>
		/// <returns>The enumerator.</returns>
		public IEnumerator<DbRelationshipTemplate> GetEnumerator()
		{
			return this.templates.GetEnumerator();
		}

		/// <summary>
		/// Gets the enumerator for the list of templates. 
		/// </summary>
		/// <returns>The enumerator.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		/// <summary>
		/// Adds a database relationship template.
		/// </summary>
		/// <param name="template">The relationship template.</param>
		public void Add(DbRelationshipTemplate template)
		{
			// Validate the arguments.
			if (null == template) throw new ArgumentNullException("template");

			// Add the relationship template.
			this.templates.Add(template);

			// Raise the event.
			if (null != this.TemplateAdded) this.TemplateAdded(this, new DbRelationshipTemplateEventArgs(template));
		}

		/// <summary>
		/// Removes a database relationship template.
		/// </summary>
		/// <param name="template">The relationship template.</param>
		public void Remove(DbRelationshipTemplate template)
		{
			// Validate the arguments.
			if (null == template) throw new ArgumentNullException("template");

			// Remove the template.
			if (this.templates.Remove(template))
			{
				// Raise the event.
				if (null != this.TemplateRemoved) this.TemplateRemoved(this, new DbRelationshipTemplateEventArgs(template));
			}
		}
	}
}
