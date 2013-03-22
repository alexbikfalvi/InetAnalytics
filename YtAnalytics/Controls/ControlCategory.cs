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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetApi.Windows.Controls;
using YtApi.Api.V2;

namespace YtAnalytics.Controls
{
	/// <summary>
	/// Displays the information of a log event.
	/// </summary>
	public partial class ControlCategory : ThreadSafeControl
	{
		private YouTubeCategory category = null;

		/// <summary>
		/// Creates a new log event control instance.
		/// </summary>
		public ControlCategory()
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
				this.category = value;
				if (value == null)
				{
					this.labelTitle.Text = "No category selected";
					this.tabControl.Visible = false;
				}
				else
				{
					this.labelTitle.Text = value.Label;
					this.textBoxTerm.Text = value.Term;
					this.textBoxLabel.Text = value.Label;
					this.checkBoxAssignable.Checked = value.IsAssignable;
					this.checkBoxDeprecated.Checked = value.IsDeprecated;
					this.listViewBrowsable.Items.Clear();
					if (value.Browsable != null)
					{
						foreach (string region in value.Browsable)
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
}
