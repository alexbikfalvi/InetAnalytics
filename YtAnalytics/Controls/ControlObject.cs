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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetApi.Windows.Controls;
using YtCrawler.Database.Data;

namespace YtAnalytics.Controls
{
	/// <summary>
	/// Displays the information of a database table.
	/// </summary>
	public partial class ControlObject : ThreadSafeControl
	{
		/// <summary>
		/// Creates a new log event control instance.
		/// </summary>
		public ControlObject()
		{
			InitializeComponent();
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the current object.
		/// </summary>
		public DbObject Object
		{
			get { return this.propertyGrid.SelectedObject as DbObject; }
			set
			{
				this.propertyGrid.SelectedObject = value;
				this.labelTitle.Text = (value != null) ? value.GetName() : "No object selected";
			}
		}
	}
}
