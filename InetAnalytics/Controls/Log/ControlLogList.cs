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
			InitializeComponent();

			this.comboBox.SelectedIndex = 0;

			this.MaximumItems = ControlLogList.maximumValues[this.comboBox.SelectedIndex];
		}

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
