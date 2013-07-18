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
using System.Windows.Forms;
using DotNetApi.Windows.Controls;
using YtCrawler.Database.Data;

namespace YtAnalytics.Controls.Database
{
	/// <summary>
	/// Displays the information of a database table.
	/// </summary>
	public partial class ControlObjectProperties : ThreadSafeControl
	{
		private DbObject obj;

		/// <summary>
		/// Creates a new log event control instance.
		/// </summary>
		public ControlObjectProperties()
		{
			InitializeComponent();
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the current object.
		/// </summary>
		public DbObject Object
		{
			get { return this.obj; }
			set
			{
				// Save the old object.
				DbObject old = this.obj;
				// Set the new object.
				this.obj = value;
				// Call the event handler.
				this.OnObjectSet(old, value);
			}
		}

		// Protected methods.

		/// <summary>
		/// An event handler called when a new object has been set.
		/// </summary>
		/// <param name="oldObject">The old object.</param>
		/// <param name="newObject">The new object.</param>
		protected virtual void OnObjectSet(DbObject oldObject, DbObject newObject)
		{
			// If the object has not changed, do nothing.
			if (oldObject == newObject) return;

			if (null == newObject)
			{
				this.labelTitle.Text = "No object selected";
				this.tabControl.Visible = false;
			}
			else
			{
				this.labelTitle.Text = newObject.GetName();
				this.propertyGrid.SelectedObject = newObject;
				this.tabControl.Visible = true;
			}
			this.tabControl.SelectedTab = this.tabPageProperties;
			if (this.Focused)
			{
				this.propertyGrid.Select();
			}
		}
	}
}
