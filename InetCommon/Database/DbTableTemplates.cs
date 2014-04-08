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
	/// A collection of database table templates.
	/// </summary>
	public sealed class DbTableTemplates : IEnumerable<DbTableTemplate>
	{
		private readonly Dictionary<Guid, DbTableTemplate> templates = new Dictionary<Guid,DbTableTemplate>();

		/// <summary>
		/// Creates a new collection of table templates.
		/// </summary>
		public DbTableTemplates()
		{
		}

		// Public events.

		/// <summary>
		/// An event raised when a database table template was added.
		/// </summary>
		public event DbTableTemplateEventHandler TemplateAdded;
		/// <summary>
		/// An event raised when a database table template was removed. 
		/// </summary>
		public event DbTableTemplateEventHandler TemplateRemoved;

		// Public methods.

		/// <summary>
		/// Gets the enumerator for the list of templates.
		/// </summary>
		/// <returns>The enumerator.</returns>
		public IEnumerator<DbTableTemplate> GetEnumerator()
		{
			return this.templates.Values.GetEnumerator();
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
		/// Adds a database table template.
		/// </summary>
		/// <param name="template">The table template.</param>
		public void Add(DbTableTemplate template)
		{
			// Validate the arguments.
			if (null == template) throw new ArgumentNullException("template");

			// Check the template does not exist.
			if (this.templates.ContainsKey(template.Id)) throw new DbException("A database table template with the specified identifier already exists.");

			// Add the table template.
			this.templates.Add(template.Id, template);

			// Raise the event.
			if (null != this.TemplateAdded) this.TemplateAdded(this, new DbTableTemplateEventArgs(template));
		}
		
		/// <summary>
		/// Removes a database table template.
		/// </summary>
		/// <param name="template">The table template.</param>
		public void Remove(DbTableTemplate template)
		{
			// Validate the arguments.
			if (null == template) throw new ArgumentNullException("template");

			// Remove the template.
			if (this.templates.Remove(template.Id))
			{
				// Raise the event.
				if (null != this.TemplateRemoved) this.TemplateRemoved(this, new DbTableTemplateEventArgs(template));
			}
		}
	}
}
