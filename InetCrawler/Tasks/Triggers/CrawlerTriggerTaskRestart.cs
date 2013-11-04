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

namespace InetCrawler.Tasks.Triggers
{
	/// <summary>
	/// A class representing a crawler task restart trigger.
	/// </summary>
	public sealed class CrawlerTriggerTaskRestart : CrawlerTriggerTask
	{
		private TimeSpan interval;
		private uint maximum;
		private uint count;

		/// <summary>
		/// Creates a new trigger instance.
		/// </summary>
		/// <param name="tasks">The tasks handler.</param>
		/// <param name="task">The task.</param>
		/// <param name="interval">The delay interval to a restart after a failure.</param>
		/// <param name="maximum">The maximum number of restarts.</param>
		public CrawlerTriggerTaskRestart(ICrawlerTasks tasks, CrawlerTask task, TimeSpan interval, uint maximum)
			: base(tasks, task)
		{
			this.interval = interval;
			this.maximum = maximum;
			this.count = 0;
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the restart interval.
		/// </summary>
		public TimeSpan Interval
		{
			get { return this.interval; }
			set { this.OnIntervalSet(value); }
		}
		/// <summary>
		/// Gets or sets the maximum restart count.
		/// </summary>
		public uint Maximum
		{
			get { return this.maximum; }
			set { this.OnMaximumSet(value); }
		}
		/// <summary>
		/// Gets or sets the current restart count.
		/// </summary>
		public uint Count
		{
			get { return this.count; }
		}

		// Public methods.

		/// <summary>
		/// Reschedules the current trigger if the current count is less than the maximum count. Otherwise, it resets the current count.
		/// The schedule time is the current time plus the delay interval.
		/// </summary>
		public void Reschedule()
		{
			lock (this.Sync)
			{
				// If the counter is less than the maximum value.
				if (this.count < this.maximum)
				{
					// Enable the trigger.
					this.Enable(DateTime.Now + this.interval);
					// Increment the count.
					this.count++;
				}
				else
				{
					// Reset the counter.
					this.count = 0;
				}
			}
		}

		/// <summary>
		/// Resets the trigger.
		/// </summary>
		public void Reset()
		{
			// Reset the counter.
			lock (this.Sync)
			{
				this.count = 0;
			}
		}

		// Protected methods.

		/// <summary>
		/// Executes the current trigger.
		/// </summary>
		protected override void OnExecute()
		{
			// Execute the task.
			this.Task.Execute(this.Timestamp);
		}

		// Private methods.

		/// <summary>
		/// Sets the delay interval.
		/// </summary>
		/// <param name="value">The value.</param>
		private void OnIntervalSet(TimeSpan value)
		{
			lock (this.Sync)
			{
				// If the trigger is enabled.
				if (this.Enabled)
				{
					// Change the trigger timestamp using the new interval.
					this.Change(this.Timestamp - this.interval + value);
				}

				// Set the new value.
				this.interval = value;
			}
		}

		/// <summary>
		/// Sets the maximum delay count.
		/// </summary>
		/// <param name="value">The value.</param>
		private void OnMaximumSet(uint value)
		{
			lock (this.Sync)
			{
				// Set the new value.
				this.maximum = value;
			}
		}
	}
}
