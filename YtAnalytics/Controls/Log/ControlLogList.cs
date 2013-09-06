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
using YtAnalytics.Forms.Log;
using YtCrawler.Log;

namespace YtAnalytics.Controls.Log
{
	/// <summary>
	/// A control representing an event log list.
	/// </summary>
	public partial class ControlLogList : ThreadSafeControl
	{
		private int maximumItems;
		private static int[] maximumValues = { 10, 100, 1000, int.MaxValue };
		private FormEventProperties formLogEvent = new FormEventProperties();

		private delegate void AddEventHandler(LogEvent evt);

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlLogList()
		{
			InitializeComponent();

			this.toolStripComboBox.SelectedIndex = 0;

			this.MaximumItems = ControlLogList.maximumValues[this.toolStripComboBox.SelectedIndex];
		}

		/// <summary>
		/// Adds a new event to the event log. The method is thread-safe.
		/// </summary>
		/// <param name="evt">The event.</param>
		public void Add(LogEvent evt)
		{
			// Invoke this method on the UI thread.
			if (this.InvokeRequired)
			{
				this.Invoke(new AddEventHandler(this.Add), new object[] { evt });
				return;
			}
			// Create a new list view menu item.
			ListViewItem item = new ListViewItem(new string[] { DateTime.Now.ToString(), evt.Message }, (int)evt.Type);
			item.Tag = evt;
			if (this.listView.Items.Count > this.MaximumItems)
				this.listView.Items.RemoveAt(0);
			this.listView.Items.Add(item);
			this.listView.EnsureVisible(this.listView.Items.Count - 1);
			// If the clear button is disabled, enable the button.
			if (!this.toolStripButtonClear.Enabled)
				this.toolStripButtonClear.Enabled = true;
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
			this.MaximumItems = ControlLogList.maximumValues[this.toolStripComboBox.SelectedIndex];
		}

		/// <summary>
		/// An event handler called when the event log list is cleared.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnClear(object sender, EventArgs e)
		{
			this.listView.Items.Clear();
			this.toolStripButtonClear.Enabled = false;
		}

		/// <summary>
		/// An event handler called when an item is activated.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnItemActivate(object sender, EventArgs e)
		{
			if (this.listView.SelectedItems.Count != 0)
				this.formLogEvent.ShowDialog(this, this.listView.SelectedItems[0].Tag as LogEvent);
		}
	}
}
