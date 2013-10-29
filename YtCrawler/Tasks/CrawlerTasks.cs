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

namespace YtCrawler.Tasks
{
	/// <summary>
	/// A class representing the crawler tasks, scheduled or background.
	/// </summary>
	public sealed class CrawlerTasks
	{
		private object sync = new object();

		private readonly Dictionary<Guid, CrawlerTask> tasks = new Dictionary<Guid, CrawlerTask>();
		private readonly SortedDictionary<DateTime, CrawlerTrigger> triggers = new SortedDictionary<DateTime, CrawlerTrigger>();

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

		/// <summary>
		/// Adds a new task to the tasks list.
		/// </summary>
		/// <param name="task">The task.</param>
		public void Add(CrawlerTask task)
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
			}
		}

		/// <summary>
		/// Removes the task from the tasks list.
		/// </summary>
		/// <param name="task">The task.</param>
		public void Remove(CrawlerTask task)
		{
		}

		// Private methods.

		/// <summary>
		/// Adds a schedule for the specified task.
		/// </summary>
		/// <param name="task"></param>
		private void OnAdd(CrawlerTask task)
		{
		}

		private void OnRemove(CrawlerTask task)
		{
		}

		/// <summary>
		/// A method called when adding a new trigger.
		/// </summary>
		/// <param name="trigger">The trigger.</param>
		private void OnAddTrigger(CrawlerTrigger trigger)
		{
			// Synchronize access.
			lock (this.sync)
			{
				// If the triggers list is empty.
				if (this.triggers.Count == 0)
				{
					// Add the trigger to the triggers list.
					this.OnAddTriggerSafe(trigger);
					// Update the timer.
					this.OnUpdateTimer(trigger);
				}
				else
				{
					// The first trigger.
					KeyValuePair<DateTime, CrawlerTrigger> first = this.triggers.First();
					// Add the trigger to the triggers list.
					this.OnAddTriggerSafe(trigger);
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
		/// Adds the specified trigger to the triggers list.
		/// </summary>
		/// <param name="trigger">The trigger.</param>
		private void OnAddTriggerSafe(CrawlerTrigger trigger)
		{
			// Synchronize access.
			lock (this.sync)
			{
				// Get the trigger timestamp.
				DateTime timestamp = trigger.Timestamp;
				// If the timestamp exists.
				while (this.triggers.ContainsKey(timestamp))
				{
					// Increment the timestamp.
					timestamp.AddTicks(1);
				}
				// If the timestamp has changed.
				if (timestamp != trigger.Timestamp)
				{
					// Update the trigger timestamp.
					trigger.Timestamp = timestamp;
				}

				// Add the trigger.
				this.triggers.Add(timestamp, trigger);
			}
		}

		/// <summary>
		/// A method called when removing a trigger.
		/// </summary>
		/// <param name="trigger">The trigger.</param>
		private void OnRemoveTrigger(CrawlerTrigger trigger)
		{
			// Synchronize access.
			lock (this.sync)
			{
				// Check the trigger list is not empty.
				if (this.triggers.Count == 0) throw new InvalidOperationException("Internal task scheduler exception: cannot remove a trigger because the trigger list is empty.");

				// Get the first trigger.
				KeyValuePair<DateTime, CrawlerTrigger> first = this.triggers.First();

				// Remove the trigger.
				if (!this.triggers.Remove(trigger.Timestamp)) throw new InvalidOperationException("Internal task schedule exception: cannot remove a trigger because it could not be found.");

				// If the trigger is the first trigger.
				if (object.ReferenceEquals(first.Value, trigger))
				{
					// If the trigger list is empty.
					if (this.triggers.Count == 0)
					{
						// Disable the timer.
						this.timer.Change(Timeout.Infinite, Timeout.Infinite);
					}
					else
					{
						// Get the next trigger.
						KeyValuePair<DateTime, CrawlerTrigger> next = this.triggers.First();
						// Update the timer.
						this.OnUpdateTimer(next.Value);
					}
				}
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
				if (this.triggers.Count == 0) return;

				// Get the first trigger.
				first = this.triggers.First();

				// Check the timer has been triggered for the current timer trigger. Otherwise, return.
				if (!object.ReferenceEquals(this.timerTrigger, first.Value)) return;

				// Remove the first trigger from the list.
				if (!this.triggers.Remove(first.Key)) throw new InvalidOperationException("Internal task scheduler exception: cannot remove an existing trigger.");

				// Set the current timer trigger to null.
				this.timerTrigger = null;

				// If the trigger list is not empty.
				if (this.triggers.Count > 0)
				{
					// Get the next trigger.
					KeyValuePair<DateTime, CrawlerTrigger> next = this.triggers.First();
					// Update the timer.
					this.OnUpdateTimer(next.Value);
				}
			}

			// Execute the current trigger.
			this.OnExecute(first.Value);
		}

		/// <summary>
		/// A method called when executing a trigger.
		/// </summary>
		/// <param name="trigger">The trigger.</param>
		private void OnExecute(CrawlerTrigger trigger)
		{
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
