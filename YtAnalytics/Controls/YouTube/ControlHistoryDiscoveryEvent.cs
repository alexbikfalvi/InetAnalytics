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
using YtAnalytics.Forms;
using YtApi.Ajax;

namespace YtAnalytics.Controls.YouTube
{
	/// <summary>
	/// Displays the information of a history discovery event for a YouTube video.
	/// </summary>
	public partial class ControlHistoryDiscoveryEvent : ThreadSafeControl
	{
		private AjaxViewsHistoryDiscoveryEvent evt = null;

		/// <summary>
		/// Creates a new log event control instance.
		/// </summary>
		public ControlHistoryDiscoveryEvent()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Gets or sets the current history discovery event.
		/// </summary>
		public AjaxViewsHistoryDiscoveryEvent Event
		{
			get { return this.evt; }
			set
			{
				this.evt = value;
				if (null == value)
				{
					this.labelTitle.Text = "No history discovery event selected.";
					this.tabControl.Visible = false;
				}
				else
				{
					this.labelTitle.Text = string.Format("{0} at {1}", value.Name, value.Marker.Value.Time.ToString());
					this.textBoxName.Text = value.Name;
					this.textBoxTime.Text = value.Marker.Value.Time.ToString();
					this.textBoxType.Text = string.Format("[{0}] {1}", ((int)value.Type).ToString(), value.Type.ToString());
					this.textBoxDescription.Text = AjaxViewsHistoryDiscoveryEvent.GetTypeDescription(value.Type);
					this.textBoxData.Text = value.Extra;
					this.tabControl.Visible = true;
				}
				this.tabControl.SelectedTab = this.tabPageGeneral;
				this.textBoxName.Select();
				this.textBoxName.SelectionStart = 0;
				this.textBoxName.SelectionLength = 0;
			}
		}
	}
}
