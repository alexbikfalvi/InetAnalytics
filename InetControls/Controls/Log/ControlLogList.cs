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
using InetAnalytics.Forms.Log;
using InetCrawler.Log;

namespace InetAnalytics.Controls.Log
{
	/// <summary>
	/// A control representing an event log list.
	/// </summary>
	public partial class ControlLogList : ThemeControl
	{
		private delegate void AddEventAction(LogEvent evt);

		private int maximumItems;
		private static readonly int[] maximumValues = { 10, 100, 1000, int.MaxValue };
		private readonly FormEventProperties formLogEvent = new FormEventProperties();

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlLogList()
		{
			// Initialize the component.
			this.InitializeComponent();
			// Set the combo box index.
			this.comboBox.SelectedIndex = 0;
			// Set the maximum items.
			this.MaximumItems = ControlLogList.maximumValues[this.comboBox.SelectedIndex];
		}

		// Public methods.

		/// <summary>
		/// Adds a new event to the event log. The method is thread-safe.
		/// </summary>
		/// <param name="evt">The event.</param>
		public void Add(LogEvent evt)
		{
			// Execute the code on the UI thread.
			this.Invoke(() =>
				{
					// Create a new list view menu item.
					ListViewItem item = new ListViewItem(new string[] { DateTime.Now.ToString(), evt.Message }, (int)evt.Type);
					item.Tag = evt;
					if (this.listView.Items.Count > this.MaximumItems)
						this.listView.Items.RemoveAt(0);
					this.listView.Items.Add(item);
					this.listView.EnsureVisible(this.listView.Items.Count - 1);
					// If the clear button is disabled, enable the button.
					if (!this.buttonClear.Enabled)
						this.buttonClear.Enabled = true;
				});
		}

		// Private properties.

		/// <summary>
		/// Gets or sets the maximum number of log items.
		/// </summary>
		private int MaximumItems
		{
			get { return this.maximumItems; }
			set
			{
				while (this.listView.Items.Count > value)
					this.listView.Items.RemoveAt(0);
				this.maximumItems = value;
			}
		}

		// Private methods.

		/// <summary>
		/// An event handler called when the maximum number of log items has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnMaximumItemsChanged(object sender, EventArgs e)
		{
			this.MaximumItems = ControlLogList.maximumValues[this.comboBox.SelectedIndex];
		}

		/// <summary>
		/// An event handler called when the event log list is cleared.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnClear(object sender, EventArgs e)
		{
			this.listView.Items.Clear();
			this.buttonClear.Enabled = false;
			this.buttonProperties.Enabled = false;
		}

		/// <summary>
		/// An event handler called when an item is activated.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnProperties(object sender, EventArgs e)
		{
			if (this.listView.SelectedItems.Count > 0)
			{
				this.formLogEvent.ShowDialog(this, this.listView.SelectedItems[0].Tag as LogEvent);
			}
		}

		/// <summary>
		/// An event handler called when the log event selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelectionChanged(object sender, EventArgs e)
		{
			if (this.listView.SelectedItems.Count > 0)
			{
				this.buttonProperties.Enabled = true;
				this.menuItemProperties.Enabled = true;
			}
			else
			{
				this.buttonProperties.Enabled = false;
				this.menuItemProperties.Enabled = false;
			}
		}

		/// <summary>
		/// An event handler called when the user clicks on the event list.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnMouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if (this.listView.FocusedItem != null)
				{
					if (this.listView.FocusedItem.Bounds.Contains(e.Location))
					{
						this.contextMenu.Show(this.listView, e.Location);
					}
				}
			}
		}
	}
}
