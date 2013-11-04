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

namespace YtCrawler.Tasks.Triggers
{
	/// <summary>
	/// A class representing a crawler task stop trigger.
	/// </summary>
	public sealed class CrawlerTriggerTaskStop : CrawlerTriggerTask
	{
		private readonly CrawlerTask.RunningTaskState state;
		private TimeSpan interval;

		/// <summary>
		/// Creates a new trigger instance.
		/// </summary>
		/// <param name="tasks">The tasks handler.</param>
		/// <param name="task">The task.</param>
		/// <param name="interval">The delay interval to a restart after a failure.</param>
		public CrawlerTriggerTaskStop(ICrawlerTasks tasks, CrawlerTask task, CrawlerTask.RunningTaskState state, TimeSpan interval)
			: base(tasks, task)
		{
			this.state = state;
			this.interval = interval;
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

		// Protected methods.

		/// <summary>
		/// Executes the current trigger.
		/// </summary>
		protected override void OnExecute()
		{
			// Stops the task execution.
			this.Task.Cancel(this.state);
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
	}
}
