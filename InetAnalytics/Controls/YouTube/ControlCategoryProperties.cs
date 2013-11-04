/* 
 * Copyright (C) 2012 Alex Bikfalvi
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
using InetApi.YouTube.Api.V2;

namespace InetAnalytics.Controls.YouTube
{
	/// <summary>
	/// Displays the information of a log event.
	/// </summary>
	public partial class ControlCategoryProperties : ThreadSafeControl
	{
		private YouTubeCategory category = null;

		/// <summary>
		/// Creates a new log event control instance.
		/// </summary>
		public ControlCategoryProperties()
		{
			InitializeComponent();
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the current category.
		/// </summary>
		public YouTubeCategory Catergory
		{
			get { return this.category; }
			set
			{
				// Save the old value.
				YouTubeCategory old = this.category;
				// Set the new category.
				this.category = value;
				// Call the event handler.
				this.OnSetCategory(old, value);
			}
		}

		// Protected methods.

		/// <summary>
		/// An event handler called when a new category has been set.
		/// </summary>
		/// <param name="oldCategory">The old category.</param>
		/// <param name="newCategory">The new category.</param>
		protected virtual void OnSetCategory(YouTubeCategory oldCategory, YouTubeCategory newCategory)
		{
			// If the new and old category are equal, do nothing.
			if (oldCategory == newCategory) return;

			if (newCategory == null)
			{
				this.labelTitle.Text = "No category selected";
				this.tabControl.Visible = false;
			}
			else
			{
				this.labelTitle.Text = newCategory.Label;
				this.textBoxTerm.Text = newCategory.Term;
				this.textBoxLabel.Text = newCategory.Label;
				this.checkBoxAssignable.Checked = newCategory.IsAssignable;
				this.checkBoxDeprecated.Checked = newCategory.IsDeprecated;
				this.listViewBrowsable.Items.Clear();
				if (newCategory.Browsable != null)
				{
					foreach (string region in newCategory.Browsable)
					{
						this.listViewBrowsable.Items.Add(region);
					}
				}
				this.tabControl.Visible = true;
			}
			this.tabControl.SelectedTab = this.tabPageGeneral;
			if (this.Focused)
			{
				this.textBoxTerm.Select();
				this.textBoxTerm.SelectionStart = 0;
				this.textBoxTerm.SelectionLength = 0;
			}
		}
	}
}
