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

namespace YtAnalytics.Controls
{
	/// <summary>
	/// A control that displays a calendar along with a tree view.
	/// </summary>
	public partial class ControlSideCalendar : ControlSide
	{
		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlSideCalendar()
		{
			// Initialize the control.
			InitializeComponent();
		}

		/// <summary>
		/// An event raised when the date has changed.
		/// </summary>
		public event DateRangeEventHandler DateChanged;
		/// <summary>
		/// An event raised when the control selection has changed.
		/// </summary>
		public event ControlEventHandler ControlChanged;

		/// <summary>
		/// Gets the calendar.
		/// </summary>
		public MonthCalendar Calendar
		{
			get { return this.calendar; }
		}

		/// <summary>
		/// Shows the control.
		/// </summary>
		public override void Show()
		{
			// Get the current tag as a control.
			Control control = this.Tag as Control;
			// Call the base class method.
			base.Show();
			// Call the event handler.
			if (null != this.ControlChanged) this.ControlChanged(this, new ControlEventArgs(control));
			// Refresh the log.
			this.OnRefresh(this, null);
		}

		/// <summary>
		/// An event handler called when the date has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnDateChanged(object sender, DateRangeEventArgs e)
		{
			// Update the labels.
			this.labelStart.Text = e.Start.ToShortDateString();
			this.labelEnd.Text = e.End.ToShortDateString();
			// Call the event handler.
			if (null != this.DateChanged) this.DateChanged(sender, e);
		}

		/// <summary>
		/// An event handler called when the user clicks on the refresh button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRefresh(object sender, EventArgs e)
		{
			// Call the event handler.
			this.OnDateChanged(this, new DateRangeEventArgs(this.calendar.SelectionStart, this.calendar.SelectionEnd));
		}
	}
}
