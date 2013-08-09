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

namespace YtAnalytics.Controls
{
	/// <summary>
	/// A control that displays a calendar along with a tree view.
	/// </summary>
	public partial class ControlSideCalendar : UserControl, ISideControl
	{
		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlSideCalendar()
		{
			// Initialize the control.
			InitializeComponent();
		}

		// Public events.

		/// <summary>
		/// An event raised when the date has changed.
		/// </summary>
		public event DateRangeEventHandler DateChanged;
		/// <summary>
		/// An event raised when the user clicks on the refresh button.
		/// </summary>
		public event DateRangeEventHandler DateRefresh;
		/// <summary>
		/// An event raised when the selected control has changed.
		/// </summary>
		public event SideTreeViewControlChangedEventHandler ControlChanged;

		// Public properties.

		/// <summary>
		/// Gets the calendar.
		/// </summary>
		public MonthCalendar Calendar { get { return this.calendar; } }

		// Public methods.

		/// <summary>
		/// Initializes the current side control.
		/// </summary>
		public void Initialize()
		{
			this.calendar.SelectionStart = DateTime.Today;
			this.calendar.SelectionEnd = this.calendar.SelectionStart.AddSeconds(86399);
		}

		/// <summary>
		/// Shows the current side control and activates the control content.
		/// </summary>
		public void ShowSideControl()
		{
			// Get the current tag as a control.
			Control control = this.Tag as Control;
			// Call the base class method.
			base.Show();
			// Call the event handler.
			if (null != this.ControlChanged) this.ControlChanged(this, control);
			// Refresh the log.
			this.OnRefresh(this, null);
		}

		/// <summary>
		/// Hides the current side control and deactivates the control content.
		/// </summary>
		public void HideSideControl()
		{
			// Call the base class method.7
			base.Hide();
		}

		/// <summary>
		/// Indicates whether the control has a selectable item.
		/// </summary>
		/// <returns><b>True</b> if the control has a selectable item, <b>false</b> otherwise.</returns>
		public bool HasSelected()
		{
			return false;
		}

		/// <summary>
		/// Returns the indices of the selected item.
		/// </summary>
		/// <returns>The indices.</returns>
		public int[] GetSelected()
		{
			return null;
		}

		/// <summary>
		/// Sets the selected item.
		/// </summary>
		/// <param name="index">The item indices.</param>
		public void SetSelected(int[] indices)
		{
			// Do nothing.
		}

		// Private methods.

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
			// Raise the event.
			if (null != this.DateChanged) this.DateChanged(sender, e);
		}

		/// <summary>
		/// An event handler called when the user clicks on the refresh button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRefresh(object sender, EventArgs e)
		{
			// Raise the event.
			if (this.DateRefresh != null) this.DateRefresh(this, new DateRangeEventArgs(this.calendar.SelectionStart, this.calendar.SelectionEnd));
		}
	}
}
