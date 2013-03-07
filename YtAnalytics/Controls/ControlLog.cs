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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YtAnalytics.Forms;
using YtCrawler;
using YtCrawler.Log;

namespace YtAnalytics.Controls
{
	/// <summary>
	/// A control that displays an event log.
	/// </summary>
	public partial class ControlLog : UserControl
	{
		private Crawler crawler;
		private ControlLogUpdateState state = null;
		private List<LogEvent> events = null;

		private ShowMessageEventHandler delegateShowMessage;
		private HideMessageEventHandler delegateHideMessage;

		private FormLogEvent formLogEvent = new FormLogEvent();

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlLog()
		{
			// Initialize the control.
			InitializeComponent();

			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;

			// Initialize the delegates.
			this.delegateShowMessage = new ShowMessageEventHandler(this.ShowMessage);
			this.delegateHideMessage = new HideMessageEventHandler(this.HideMessage);
			
			// Initialize the calendar
			this.calendar.Calendar.MaxSelectionCount = 3600;
			this.calendar.Calendar.DateChanged += OnCalendarDateChanged;

			// Add the event types to the list check box.
			foreach (LogEventType type in Enum.GetValues(typeof(LogEventType)))
				this.listTypes.AddItem(type, LogEvent.GetDescription(type), CheckState.Checked);
			// Add the event level to the list check box.
			foreach (LogEventLevel level in Enum.GetValues(typeof(LogEventLevel)))
				this.listLevels.AddItem(level, LogEvent.GetDescription(level), CheckState.Checked);
		}

		/// <summary>
		/// Initializes the control with a crawler object.
		/// </summary>
		/// <param name="crawler">The crawler object.</param>
		/// <param name="calendar">The log calendar.</param>
		public void Initialize(Crawler crawler)
		{
			// Set the crawler.
			this.crawler = crawler;
			// Refresh the log.
			this.Refresh();
		}

		/// <summary>
		/// Changes the calendar to the specified range.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The date range event arguments.</param>
		public void DateChanged(object sender, DateRangeEventArgs e)
		{
			// If the function is called before the initialization of the crawler, do nothing.
			if (null == this.crawler) return;

			// Update the calendar.
			this.calendar.Calendar.SelectionStart = e.Start;
			this.calendar.Calendar.SelectionEnd = e.End;
		}

		/// <summary>
		/// An event handler called when the calendar range has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCalendarDateChanged(object sender, DateRangeEventArgs e)
		{
			// Show a waiting message.
			this.ShowMessage(Resources.LogClock_48, "Reading log files...", true);
			this.listView.Enabled = false;
			this.toolStrip.Enabled = false;
			this.listView.Items.Clear();
			this.controlLogEvent.Event = null;

			// Clear the list of events.
			this.events = null;

			// Create a new update state.
			ControlLogUpdateState state = new ControlLogUpdateState(e);

			// If a current update is in progress, cancel the update state.
			if (null != this.state)
				this.state.Cancel();

			// Update the global state.
			this.state = state;

			// Update the log information asynchronously on a system thread pool.
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.BeginUpdateLog), state);
		}

		/// <summary>
		/// Begins an asynchronous request to update the log. The request is executed
		/// on a thread from the system thread pool.
		/// </summary>
		/// <param name="argument">The update state.</param>
		private void BeginUpdateLog(object argument)
		{
			// Get the state.
			ControlLogUpdateState state = argument as ControlLogUpdateState;
			try
			{
				// If the state is not canceled.
				if (!state.IsCanceled)
				{
					// Read the log for all the dates in the specified range.
					this.crawler.Log.Read(state.Range.Start, state.Range.End);
				}
				// If the state is not canceled.
				if (!state.IsCanceled)
				{
					// Get the list of events.
					state.Events = this.crawler.Log.Get(state.Range.Start, state.Range.End);
				}
				// If the state is not canceled.
				if (!state.IsCanceled)
				{
					// Update the message for a successful refresh.
					this.ShowMessage(
						Resources.LogSuccess_48,
						string.Format("Refreshing the log for dates {0} to {1} completed successfully.", state.Range.Start.ToShortDateString(), state.Range.End.ToShortDateString()),
						false);
				}
			}
			catch (Exception exception)
			{
				// If the state is not canceled.
				if (!state.IsCanceled)
				{
					// Update the message for a failed refresh.
					this.ShowMessage(
						Resources.Error_48,
						string.Format("Refreshing the log failed. {0}", exception.Message),
						false);
				}
			}
			finally
			{
				Thread.Sleep(this.crawler.Config.MessageCloseDelay);
			}

			// If the state is not canceled.
			if (!state.IsCanceled)
			{
				// Call the completion synchronous function.
				this.EndUpdateLog(state);
			}
		}

		/// <summary>
		/// Completes an asynchronous request to update the log. The request is completed
		/// on the UI thread.
		/// </summary>
		/// <param name="argument">The update state.</param>
		private void EndUpdateLog(object argument)
		{
			// Invoke the function on the UI thread.
			if (this.InvokeRequired)
				this.Invoke(new WaitCallback(this.EndUpdateLog), new object[] { argument });
			else
			{
				ControlLogUpdateState state = argument as ControlLogUpdateState;

				// If the state is not canceled.
				if (!state.IsCanceled)
				{
					// Complete the update.
					state.Complete();
					// Set the global state to null.
					this.state = null;
					// Hide the waiting message.
					this.HideMessage();
					this.listView.Enabled = true;
					this.toolStrip.Enabled = true;

					// Set the list of events.
					this.events = state.Events;

					// Update the log list.
					if (this.events != null)
					{
						// Add the events.
						foreach (LogEvent evt in this.events)
						{
							// Create a list view item for each event.
							ListViewItem item = new ListViewItem(
								new string[] { evt.Timestamp.ToString(), evt.Source, evt.Message },
								(int)evt.Type
								);
							item.Tag = evt;
							item.IndentCount = evt.Indent;
							evt.Tag = item;

							// Check whether this item should be in the log.
							if ((this.listTypes[(int)evt.Type].State != CheckState.Checked) ||
								(this.listLevels[(int)evt.Level].State != CheckState.Checked))
								continue;
							
							// Add the event item to the list.
							this.listView.Items.Add(item);
						}
					}					
				}
			}
		}

		/// <summary>
		/// Shows an alerting message on top of the control.
		/// </summary>
		/// <param name="image">The message icon.</param>
		/// <param name="text">The message text.</param>
		/// <param name="progress">The visibility of the progress bar.</param>
		private void ShowMessage(Image image, string text, bool progress = true)
		{
			// Invoke the function on the UI thread.
			if (this.InvokeRequired)
				this.Invoke(this.delegateShowMessage, new object[] { image, text, progress });
			else
			{
				// Show the message.
				this.message.Show(image, text, progress);
				// Disable the control.
				this.toolStrip.Enabled = false;
				this.listView.Enabled = false;
			}
		}

		/// <summary>
		/// Hides the alerting message.
		/// </summary>
		private void HideMessage()
		{
			// Invoke the function on the UI thread.
			if (this.InvokeRequired)
				this.Invoke(this.delegateHideMessage);
			else
			{
				// Hide the message.
				this.message.Hide();
				// Enable the control.
				this.toolStrip.Enabled = true;
				this.listView.Enabled = false;
			}
		}

		/// <summary>
		/// An event handler called when an item selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void EventSelectionChanged(object sender, EventArgs e)
		{
			if (this.listView.SelectedItems.Count > 0)
			{
				// If there are selected items, select the first event.
				this.controlLogEvent.Event = this.listView.SelectedItems[0].Tag as LogEvent;
			}
			else
			{
				// Else, set the current event to null.
				this.controlLogEvent.Event = null;
			}
		}

		/// <summary>
		/// An event handler called when the check has changed for an event type.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void EventTypeCheck(object sender, ItemCheckEventArgs e)
		{
			// If the events list is null, do nothing.
			if (null == this.events) return;

			// Get the event type.
			LogEventType type = (LogEventType)this.listTypes[e.Index].Item;
			// For each event level.
			foreach (LogEventLevel level in Enum.GetValues(typeof(LogEventLevel)))
			{
				// If the event level is checked.
				if (this.listLevels[(int)level].State == CheckState.Checked)
				{
					// Update the log.
					this.UpdateLog((LogEvent evt) => { return evt.Type == type && evt.Level == level; }, e);
				}
			}
		}

		/// <summary>
		/// An event handler called when the check has changed for an event level.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void EventLevelCheck(object sender, ItemCheckEventArgs e)
		{
			// If the events list is null, do nothing.
			if (null == this.events) return;
			
			// Get the event level.
			LogEventLevel level = (LogEventLevel)this.listLevels[e.Index].Item;
			// For each event type.
			foreach (LogEventType type in Enum.GetValues(typeof(LogEventType)))
			{
				// If the event type is checked.
				if (this.listTypes[(int)type].State == CheckState.Checked)
				{
					// Update the log.
					this.UpdateLog((LogEvent evt) => { return evt.Type == type && evt.Level == level; }, e);
				}
			}
		}

		private void UpdateLog(TestLogEvent test, ItemCheckEventArgs e)
		{
			// If the check state has changed.
			if (e.NewValue != e.CurrentValue)
			{
				switch (e.NewValue)
				{
					case CheckState.Checked:
						// The new state is checked: add the checked log items.
						int indexEvt = 0; // Index for the events.
						int indexItem = 0; // Index for the log items.
						while ((indexEvt < this.events.Count) && (indexItem < this.listView.Items.Count))
						{
							// Get the event at the current log item.
							LogEvent evt = this.listView.Items[indexItem].Tag as LogEvent;

							// If the current event matches the type
							if (test(this.events[indexEvt]))
							{
								// If the current event has a timestamp smaller than the current item.
								if (this.events[indexEvt].Timestamp < evt.Timestamp)
								{
									// Insert the event at the current item position
									this.listView.Items.Insert(indexItem, this.events[indexEvt].Tag as ListViewItem);
									// Increment the event index.
									indexEvt++;
								}
								// Else, increment the item index.
								else indexItem++;
							}
							// Else, increment the event index.
							else indexEvt++;
						}
						// If there are events remaining.
						for (; indexEvt < this.events.Count; indexEvt++)
						{
							// If the current event matches the type
							if (test(this.events[indexEvt]))
							{
								// Append the event.
								this.listView.Items.Add(this.events[indexEvt].Tag as ListViewItem);
							}
						}
						break;
					case CheckState.Unchecked:
						// The new state is unchecked: remove the uncheked log items.
						for (int index = 0; index < this.listView.Items.Count; )
						{
							// Get the log event.
							LogEvent evt = this.listView.Items[index].Tag as LogEvent;
							// If the type matches, remove the log item.
							if (test(evt))
								this.listView.Items.RemoveAt(index);
							// Else, increment the index
							else index++;
						}
						break;
				}
			}
		}

		/// <summary>
		/// An event handler called when the user activates a log event item.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void ItemActivate(object sender, EventArgs e)
		{
			// If there are selected items.
			if (this.listView.SelectedItems.Count > 0)
			{
				// Open the first selected item in a new window.
				this.formLogEvent.ShowDialog(this, this.listView.SelectedItems[0].Tag as LogEvent);
			}		
		}
	}

	internal delegate bool TestLogEvent(LogEvent evt);

	/// <summary>
	/// Represents the state of an update request.
	/// </summary>
	internal class ControlLogUpdateState
	{
		private DateRangeEventArgs range;
		private bool canceled = false;
		private bool completed = false;
		private Mutex mutex = new Mutex();
		private List<LogEvent> events = null;

		/// <summary>
		/// Creates a new state instance.
		/// </summary>
		/// <param name="range">The date range for this log update.</param>
		public ControlLogUpdateState(DateRangeEventArgs range)
		{
			this.range = range;
		}

		/// <summary>
		/// Gets the current date range.
		/// </summary>
		public DateRangeEventArgs Range { get { return this.range; } }

		/// <summary>
		/// Gets or sets the list of log events.
		/// </summary>
		public List<LogEvent> Events
		{
			get { return this.events; }
			set { this.events = value; }
		}

		/// <summary>
		/// Returns whether the request was canceled.
		/// </summary>
		public bool IsCanceled
		{
			get
			{
				// Acquire the mutex.
				this.mutex.WaitOne();
				try
				{
					// Return the canceled state.
					return this.canceled;
				}
				finally
				{
					// Release the mutex.
					this.mutex.ReleaseMutex();
				}
			}
		}

		/// <summary>
		/// Returns whether the request was completed.
		/// </summary>
		public bool IsCompleted
		{
			get
			{
				// Acquire the mutex.
				this.mutex.WaitOne();
				try
				{
					// Return the canceled state.
					return this.completed;
				}
				finally
				{
					// Release the mutex.
					this.mutex.ReleaseMutex();
				}
			}
		}

		/// <summary>
		/// Cancels the current update request.
		/// </summary>
		/// <returns>Returns <b>true</b> if the cancel was successful.</returns>
		public bool Cancel()
		{
			// Acquire the mutex.
			this.mutex.WaitOne();
			try
			{
				// If the update is completed, return false.
				if (this.completed) return false;
				// Else, set the canceled flag to true.
				this.canceled = true;
				// Return true.
				return true;
			}
			finally
			{
				// Release the mutex.
				this.mutex.ReleaseMutex();
			}
		}

		/// <summary>
		/// Completes the current update request.
		/// </summary>
		public void Complete()
		{
			// Acquire the mutex.
			this.mutex.WaitOne();
			try
			{
				// Set the completed flag to true.
				this.completed = true;
			}
			finally
			{
				// Release the mutex.
				this.mutex.ReleaseMutex();
			}
		}
	}
}
