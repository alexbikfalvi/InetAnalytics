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
using YtCrawler.Database;
using DotNetApi;
using DotNetApi.Windows.Controls;

namespace YtAnalytics.Controls.Database
{
	/// <summary>
	/// Displays the information of a database table relationship.
	/// </summary>
	public partial class ControlRelationshipProperties : ThreadSafeControl
	{
		private IRelationship relationship;

		/// <summary>
		/// Creates a new log event control instance.
		/// </summary>
		public ControlRelationshipProperties()
		{
			InitializeComponent();
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the current database relationship.
		/// </summary>
		public IRelationship Relationship
		{
			get { return this.relationship; }
			set
			{
				// Save the old value.
				IRelationship old = this.relationship;
				// Set the new relationship.
				this.relationship = value;
				// Call the event handler.
				this.OnRelationshipSet(old, value);
			}
		}
		/// <summary>
		/// Gets the title for this control.
		/// </summary>
		public string Title { get { return this.labelTitle.Text; } }

		// Protected methods.

		/// <summary>
		/// An event handler called when a new relationship has been set.
		/// </summary>
		/// <param name="oldRelationship">The old relationship.</param>
		/// <param name="newRelationship">The new relationship.</param>
		protected virtual void OnRelationshipSet(IRelationship oldRelationship, IRelationship newRelationship)
		{
			// If the relationship has not changed, do nothing.
			if (oldRelationship == newRelationship) return;

			if (newRelationship == null)
			{
				this.labelTitle.Text = "No relationship selected";
				this.tabControl.Visible = false;
			}
			else
			{
				// Update the controls.
				this.textBoxTableLeft.Text = newRelationship.TableLeft.LocalName;
				this.textBoxTableRight.Text = newRelationship.TableRight.LocalName;
				this.textBoxFieldLeft.Text = newRelationship.FieldLeft;
				this.textBoxFieldRight.Text = newRelationship.FieldRight;
				this.checkBoxReadOnly.Checked = newRelationship.ReadOnly;
				this.labelTitle.Text = @"{0}\{1} ← {2}\{3}".FormatWith(
					newRelationship.TableLeft.LocalName,
					newRelationship.FieldLeft,
					newRelationship.TableRight.LocalName,
					newRelationship.FieldRight);
				this.tabControl.Visible = true;
			}
			this.tabControl.SelectedTab = this.tabPageGeneral;
			if (this.Focused)
			{
				this.textBoxTableLeft.Select();
				this.textBoxTableLeft.SelectionStart = 0;
				this.textBoxTableLeft.SelectionLength = 0;
			}
		}
	}
}
