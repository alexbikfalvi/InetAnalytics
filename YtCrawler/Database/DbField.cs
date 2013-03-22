/* 
 * Copyright (C) 2012-2013 Alex Bikfalvi
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
using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace YtCrawler.Database
{
	/// <summary>
	/// A class representing the properties of a database table field.
	/// </summary>
	public class DbField
	{
		private string databaseName = null;
		private PropertyInfo property;
		private DbAttribute databaseAttribute;
		private DisplayNameAttribute displayNameAttribute = null;
		private DescriptionAttribute descriptionAttribute = null;

		/// <summary>
		/// Creates a new field instance for the specified property.
		/// </summary>
		/// <param name="property">The property name.</param>
		/// <param name="databaseAttribute">The database attribute</param>
		public DbField(PropertyInfo property, DbAttribute databaseAttribute)
		{
			// Set the property.
			this.property = property;
			// Set the database attribute.
			this.databaseAttribute = databaseAttribute;
			// Set the database name.
			this.databaseName = this.databaseAttribute.Name;
			// Get the display name attributes.
			object[] displayNameAttributes = property.GetCustomAttributes(typeof(DisplayNameAttribute), true);
			// If at least one attribute exists, set the display name attribute.
			if (displayNameAttributes.Length > 0) this.displayNameAttribute = displayNameAttributes[0] as DisplayNameAttribute;
			// Get the description attributes.
			object[] descriptionAttributes = property.GetCustomAttributes(typeof(DescriptionAttribute), true);
			// If at least one attribute exists, set the description attribute.
			if (descriptionAttributes.Length > 0) this.descriptionAttribute = descriptionAttributes[0] as DescriptionAttribute;
		}

		/// <summary>
		/// Gets the display name of the field.
		/// </summary>
		public string DisplayName
		{
			get { return this.displayNameAttribute != null ? this.displayNameAttribute.DisplayName : this.property.Name; }
		}
		/// <summary>
		/// Gets or sets the name of the field, or throws an exception if the name is undefined.
		/// </summary>
		public string DatabaseName
		{
			get
			{
				if (this.databaseName == null) throw new DbFieldException(string.Format("The property \'{0}\' is not mapped to a database field name.", this.property.Name), this.property.Name);
				if (this.databaseName == string.Empty) throw new DbFieldException(string.Format("The property \'{0}\' is not mapped to a database field name.", this.property.Name), this.property.Name);
				return this.databaseName;
			}
			set
			{
				this.databaseName = value;
			}
		}
		/// <summary>
		/// Gets the description of the current field.
		/// </summary>
		public string Description
		{
			get { return this.descriptionAttribute != null ? this.descriptionAttribute.Description : string.Empty; }
		}
		/// <summary>
		/// Returns <b>true</b> if the field has a database name, or <b>false</b> otherwise.
		/// </summary>
		public bool HasName
		{
			get
			{
				if (this.databaseName == null) return false;
				if (this.databaseName == string.Empty) return false;
				return true;
			}
		}
		/// <summary>
		/// Gets the database attribute for this field.
		/// </summary>
		public DbAttribute Attribute { get { return this.databaseAttribute; } }
		/// <summary>
		/// Gets the property information for this field.
		/// </summary>
		public PropertyInfo Property { get { return this.property; } }
	}
}
