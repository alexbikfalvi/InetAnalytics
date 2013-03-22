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
using YtCrawler.Database;

namespace YtAnalytics.Controls
{
	/// <summary>
	/// Displays the information of a database table field.
	/// </summary>
	public partial class ControlField : ThreadSafeControl
	{
		private DbField field = null;

		/// <summary>
		/// Creates a new log event control instance.
		/// </summary>
		public ControlField()
		{
			InitializeComponent();
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the current database field.
		/// </summary>
		public DbField Field
		{
			get { return this.field; }
			set
			{
				this.field = value;
				if (null != value)
				{
					// Compute the local type string.
					Type type = field.Property.PropertyType;
					string typeName;
					if (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(Nullable<>)))
						typeName = string.Format("{0} or NULL", type.GetGenericArguments()[0].Name);
					else
						typeName = type.Name;

					this.labelTitle.Text = value.DisplayName;
					this.textBoxNameLocal.Text = value.Property.Name;
					this.textBoxNameDatabase.Text = value.HasName ? value.DatabaseName : string.Empty;
					this.textBoxNameDisplay.Text = value.DisplayName;
					this.textBoxTypeLocal.Text = typeName;
					this.textBoxTypeDatabase.Text = value.Attribute.Type.ToString();
					this.textBoxDescription.Text = value.Description;
					this.checkBoxNullable.Checked = value.Attribute.IsNullable;
					this.checkBoxConfigured.Checked = value.HasName;
					this.pictureBox.Image = value.HasName ? Resources.FieldSuccess_32 : Resources.FieldWarning_32;
					this.tabControl.Visible = true;
				}
				else
				{
					this.labelTitle.Text = "No field selected";
					this.tabControl.Visible = false;
				}
			}
		}
	}
}
