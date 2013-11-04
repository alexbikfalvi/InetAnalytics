/* 
 * Copyright (C) 2013 Alex Bikfalvi
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
using System.Linq;
using System.Threading;
using DotNetApi;
using InetCrawler.Tasks.Triggers;

namespace InetCrawler.Tasks
{
	/// <summary>
	/// A class representing the crawler tasks, scheduled or background.
	/// </summary>
	public sealed class CrawlerTasks : ICrawlerTasks
	{
		private object sync = new object();

		private readonly Dictionary<Guid, CrawlerTask> tasks = new Dictionary<Guid, CrawlerTask>();
		private readonly SortedDictionary<DateTime, CrawlerTrigger> timeline = new SortedDictionary<DateTime, CrawlerTrigger>();

		private readonly Timer timer;
		private CrawlerTrigger timerTrigger = null;

		// Configuration.

		private TimeSpan minimumTriggerDelay = TimeSpan.FromSeconds(1.0);

		/// <summary>
		/// Creates a new crawler task scheduler.
		/// </summary>
		public CrawlerTasks()
		{
			// Create the scheduler timer.
			this.timer = new Timer(this.OnTrigger);
		}

		// Public events.

		/// <summary>
		/// An event raised when a task has been added.
		/// </summary>
		public event CrawlerTaskEventHandler TaskAdded;
		/// <summary>
		/// An event raised when a task has been removed.
		/// </summary>
		public event CrawlerTaskEventHandler TaskRemoved;

		// Public methods.

		/// <summary>
		/// Adds a task to the tasks list.
		/// </summary>
		/// <param name="task"></param>
		public void AddTask(CrawlerTask task)
		{
			// Validate the argument.
			if (null == task) throw new ArgumentNullException("task");

			// Check the task is in the stopped state.
			if (task.State != CrawlerTask.TaskState.Stopped) throw new CrawlerException("Cannot add the task because the it is not in the stopped state.");

			// Synchronize access.
			lock (this.sync)
			{
				// Check the task does not exist.
				if (this.tasks.ContainsKey(task.Id)) throw new CrawlerException("Cannot add task because a task with the identifier {0} already exists.".FormatWith(task.Id));

				// Add the task to the tasks list.
				this.tasks.Add(task.Id, task);

				// Add the task event handlers.
				task.ScheduleAdded += this.OnTaskScheduleAdded;
				task.ScheduleRemoved += this.OnTaskScheduleRemoved;
			}

			// Raise the event.
			if (null != this.TaskAdded) this.TaskAdded(this, new CrawlerTaskEventArgs(task));
		}

		/// <summary>
		/// Removes a task from the tasks list.
		/// </summary>
		/// <param name="task">The task.</param>
		public void RemoveTask(CrawlerTask task)
		{
			// Validate the argument.
			if (null == task) throw new ArgumentNullException("task");

			// Cancel the task execution.

		}

		/// <summary>
		/// Removes the task from the tasks list asynchronously.
		/// </summary>
		/// <param name="task">The task.</param>
		/// <param name="callback">A method called when the removal has completed.</param>
		public void RemoveTask(CrawlerTask task, CrawlerTaskCallback callback)
		{
			// Validate the arguments.
			if (null != task) throw new ArgumentNullException("task");
			if (null != callback) throw new ArgumentNullException("callback");

			// Call the remove task handler on the thread pool.
			ThreadPool.QueueUserWorkItem((object state) =>
			{
				try
				{
					// Call the remove the task handler.
					this.RemoveTask(task);
				}
				catch { } // Catch all exceptions
				finally
				{
					// Execute the callback method.
					callback(task);
				}
			});
		}

		/// <summary>
		/// Adds a new trigger to the tasks timeline.
		/// </summary>
		/// <param name="trigger">The trigger.</param>
		/// <param name="timestamp">The timeline timestamp.</param>
		public void AddTrigger(CrawlerTrigger trigger, out DateTime timestamp)
		{
			// Synchronize access.
			lock (this.sync)
			{
				// If the timeline is empty.
				if (this.timeline.Count == 0)
				{
					// Add the trigger to the timeline.
					this.OnAddTriggerSafe(trigger, out timestamp);
					// Update the timer.
					this.OnUpdateTimer(trigger);
				}
				else
				{
					// The first trigger.
					KeyValuePair<DateTime, CrawlerTrigger> first = this.timeline.First();
					// Add the trigger to the triggers list.
					this.OnAddTriggerSafe(trigger, out timestamp);
					// If the timestamp of the current schedule is smaller than the timestamp of the first schedule.
					if (trigger.Timestamp < first.Key)
					{
						// Update the timer.
						this.OnUpdateTimer(trigger);
					}
				}
			}
		}

		/// <summary>
		/// Removes a trigger from the tasks timeline.
		/// </summary>
		/// <param name="trigger">The trigger.</param>
		public void RemoveTrigger(CrawlerTrigger trigger)
		{
			// Synchronize access.
			lock (this.sync)
			{
				// Check the trigger list is not empty.
				if (this.timeline.Count == 0) throw new InvalidOperationException("Internal task scheduler exception: cannot remove a trigger because the trigger list is empty.");

				// Get the first trigger.
				KeyValuePair<DateTime, CrawlerTrigger> first = this.timeline.First();

				// Remove the trigger.
				if (!this.timeline.Remove(trigger.Timestamp)) throw new InvalidOperationException("Internal task schedule exception: cannot remove a trigger because it could not be found.");

				// If the trigger is the first trigger.
				if (object.ReferenceEquals(first.Value, trigger))
				{
					// If the trigger list is empty.
					if (this.timeline.Count == 0)
					{
						// Disable the timer.
						this.timer.Change(Timeout.Infinite, Timeout.Infinite);
					}
					else
					{
						// Get the next trigger.
						KeyValuePair<DateTime, CrawlerTrigger> next = this.timeline.First();
						// Update the timer.
						this.OnUpdateTimer(next.Value);
					}
				}
			}
		}

		// Private methods.

		/// <summary>
		/// An event handler called when a task has added a schedule.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnTaskScheduleAdded(object sender, CrawlerScheduleEventArgs e)
		{
		}

		/// <summary>
		/// An event handler called when a task has removed a schedule.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnTaskScheduleRemoved(object sender, CrawlerScheduleEventArgs e)
		{
		}

		/// <summary>
		/// Adds the specified trigger to the timeline.
		/// </summary>
		/// <param name="trigger">The trigger.</param>
		/// <param name="timestamp">The timeline timestamp.</param>
		private void OnAddTriggerSafe(CrawlerTrigger trigger, out DateTime timestamp)
		{
			// Synchronize access.
			lock (this.sync)
			{
				// Get the trigger timestamp.
				timestamp = trigger.Timestamp;
				// If the timestamp exists.
				while (this.timeline.ContainsKey(timestamp))
				{
					// Increment the timestamp.
					timestamp.AddTicks(1);
				}

				// Add the trigger.
				this.timeline.Add(timestamp, trigger);
			}
		}

		/// <summary>
		/// An event handler called when the trigger timer expires.
		/// </summary>
		/// <param name="state">The state.</param>
		private void OnTrigger(object state)
		{
			// The current trigger.
			KeyValuePair<DateTime, CrawlerTrigger> first;

			// Synchronize access.
			lock (this.sync)
			{
				// If the trigger list is empty, do nothing.
				if (this.timeline.Count == 0) return;

				// Get the first trigger.
				first = this.timeline.First();

				// Check the timer has been triggered for the current timer trigger. Otherwise, return.
				if (!object.ReferenceEquals(this.timerTrigger, first.Value)) return;

				// Remove the first trigger from the list.
				if (!this.timeline.Remove(first.Key)) throw new InvalidOperationException("Internal task scheduler exception: cannot remove an existing trigger.");

				// Set the current timer trigger to null.
				this.timerTrigger = null;

				// If the trigger list is not empty.
				if (this.timeline.Count > 0)
				{
					// Get the next trigger.
					KeyValuePair<DateTime, CrawlerTrigger> next = this.timeline.First();
					// Update the timer.
					this.OnUpdateTimer(next.Value);
				}
			}

			// Execute the current trigger.
			first.Value.Execute();
		}

		/// <summary>
		/// Updates the current trigger timer using the specified trigger.
		/// </summary>
		/// <param name="trigger">The trigger information.</param>
		private void OnUpdateTimer(CrawlerTrigger trigger)
		{
			// Synchronize access.
			lock (this.sync)
			{
				// Get the current time;
				DateTime now = DateTime.Now;
				// Set the current trigger.
				this.timerTrigger = trigger;
				// If the trigger timestamp does not meet the minimum trigger delay.
				if (now + this.minimumTriggerDelay > trigger.Timestamp)
				{
					// Disable the timer.
					this.timer.Change(Timeout.Infinite, Timeout.Infinite);
					// Execute the trigger now on the thread pool.
					ThreadPool.QueueUserWorkItem(this.OnTrigger);
				}
				else
				{
					// Update the timer.
					this.timer.Change((long)trigger.Timestamp.Subtract(now).TotalMilliseconds, Timeout.Infinite);
				}
			}
		}
	}
}
