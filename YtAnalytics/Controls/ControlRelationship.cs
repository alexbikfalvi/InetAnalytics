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
using YtCrawler.Database;
using DotNetApi.Windows.Controls;

namespace YtAnalytics.Controls
{
	/// <summary>
	/// Displays the information of a database table relationship.
	/// </summary>
	public partial class ControlRelationship : ThreadSafeControl
	{
		private IRelationship relationship;

		/// <summary>
		/// Creates a new log event control instance.
		/// </summary>
		public ControlRelationship()
		{
			InitializeComponent();
		}

		// Public properties.

		/// <summary>
		/// Gets the current database relationship.
		/// </summary>
		public IRelationship Relationship
		{
			get { return this.relationship; }
			set
			{
				// Set the relationship.
				this.relationship = value;

				if (value != null)
				{
					// Update the controls.
					this.textBoxTableLeft.Text = value.TableLeft.LocalName;
					this.textBoxTableRight.Text = value.TableRight.LocalName;
					this.textBoxFieldLeft.Text = value.FieldLeft;
					this.textBoxFieldRight.Text = value.FieldRight;
					this.checkBoxReadOnly.Checked = value.ReadOnly;
					this.labelTitle.Text = string.Format("{0}\\{1} ← {2}\\{3}",
						value.TableLeft.LocalName,
						value.FieldLeft,
						value.TableRight.LocalName,
						value.FieldRight);
					this.tabControl.Visible = true;
				}
				else
				{
					this.tabControl.Visible = false;
				}
			}
		}
		/// <summary>
		/// Gets the title for this control.
		/// </summary>
		public string Title { get { return this.labelTitle.Text; } }
	}
}
