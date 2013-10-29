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

namespace YtCrawler.Tasks
{
	/// <summary>
	/// A class representing the crawler task schedule.
	/// </summary>
	public abstract class CrawlerSchedule
	{
		/// <summary>
		/// An enumeration representing the schedule type.
		/// </summary>
		public enum ScheduleType
		{
			OneTime = 0,
			Daily = 1,
			Weekly = 2,
			Monthly = 3
		}

		private readonly CrawlerTask task;
		private readonly ScheduleType type;
		
		private DateTime startTime;
		private bool useUniversalStartTime;
		
		private bool enabled;

		private bool delayEnabled;
		private TimeSpan delayMaximumInterval;
		private bool repeatEnabled;
		private TimeSpan repeatInterval;
		private TimeSpan repeatDuration;
		private bool stopAfterRepeatEnabled;
		private bool stopEnabled;
		private TimeSpan stopInterval;
		private bool expiresEnabled;
		private DateTime expiresTime;
		private bool useUniversalExpiresTime;


		/// <summary>
		/// Creates a new task schedule instance.
		/// </summary>
		/// <param name="task">The task.</param>
		/// <param name="type">The schedule type.</param>
		/// <param name="startTime">The start time.</param>
		public CrawlerSchedule(CrawlerTask task, ScheduleType type, DateTime startTime)
		{
			// The identifier.
			this.Id = Guid.NewGuid();

			// The task.
			this.task = task;

			// The schedule type.
			this.type = type;

			// The start time.
			this.startTime = startTime;
			this.useUniversalStartTime = false;

			// Task enabled.
			this.enabled = true;

			// Settings.
			this.delayEnabled = false;
			this.delayMaximumInterval = TimeSpan.FromHours(1.0);
			this.repeatEnabled = false;
			this.repeatInterval = TimeSpan.FromHours(1.0);
			this.repeatDuration = TimeSpan.FromDays(1.0);
			this.stopAfterRepeatEnabled = false;
			this.stopEnabled = false;
			this.stopInterval = TimeSpan.FromDays(3.0);
			this.expiresEnabled = false;
			this.expiresTime = startTime.AddYears(1);

			// Compute the schedule.
		}

		// Public events.

		/// <summary>
		/// An event raised when the schedule enabled state has changed.
		/// </summary>
		public event CrawlerScheduleEventHandler EnabledChanged;
		/// <summary>
		/// An event raised when the schdule time has changed.
		/// </summary>
		public event CrawlerScheduleEventHandler ScheduleChanged;
		/// <summary>
		/// An event raised when the schedule expiration has changed.
		/// </summary>
		public event CrawlerScheduleEventHandler ExpiresChanged;

		// Public properties.

		/// <summary>
		/// Gets the schedule identifier.
		/// </summary>
		public Guid Id { get; private set; }
		/// <summary>
		/// Gets the schedule type.
		/// </summary>
		public ScheduleType Type { get { return this.type; } }
		/// <summary>
		/// Gets or sets the schedule start time.
		/// </summary>
		public DateTime StartTime
		{
			get { return this.startTime; }
			set { this.OnSetStartTime(value); }
		}
		/// <summary>
		/// Gets or sets whether the start time uses the universal time.
		/// </summary>
		public bool UseUniversalStartTime
		{
			get { return this.useUniversalStartTime; }
			set { this.OnSetUseUniversalStartTime(value); }
		}
		/// <summary>
		/// Gets or sets whether the schedule is enabled.
		/// </summary>
		public bool Enabled
		{
			get { return this.enabled; }
			set { this.OnSetEnabled(value); }
		}
		/// <summary>
		/// Gets or sets whether the schedule includes a random delay.
		/// </summary>
		public bool DelayEnabled
		{
			get { return this.delayEnabled; }
			set { this.OnSetDelayEnabled(value); }
		}
		/// <summary>
		/// Gets or sets the random delay maximum interval.
		/// </summary>
		public TimeSpan DelayMaximumInterval
		{
			get { return this.delayMaximumInterval; }
			set { this.OnSetDelayMaximumInterval(value); }
		}
		/// <summary>
		/// Gets or sets whether the schedule is repeated periodically.
		/// </summary>
		public bool RepeatEnabled
		{
			get { return this.repeatEnabled; }
			set { this.OnSetRepeatEnabled(value); }
		}
		/// <summary>
		/// Gets or sets the repeat interval.
		/// </summary>
		public TimeSpan RepeatInterval
		{
			get { return this.repeatInterval; }
			set { this.OnSetRepeatInterval(value); }
		}
		/// <summary>
		/// Gets or sets the repeat duration.
		/// </summary>
		public TimeSpan RepeatDuration
		{
			get { return this.repeatDuration; }
			set { this.OnSetRepeatDuration(value); }
		}
		/// <summary>
		/// Gets or sets whether an executing task is stopped at the end of the repetition duration.
		/// </summary>
		public bool StopAfterRepeatEnabled
		{
			get { return this.stopAfterRepeatEnabled; }
			set { this.OnSetStopAfterRepeatEnabled(value); }
		}
		/// <summary>
		/// Gets or sets whether the task is stopped after running for a specified time interval.
		/// </summary>
		public bool StopEnabled
		{
			get { return this.stopEnabled; }
			set { this.OnSetStopEnabled(value); }
		}
		/// <summary>
		/// Gets or sets the time interval after which a running task will be stopped.
		/// </summary>
		public TimeSpan StopInterval
		{
			get { return this.stopInterval; }
			set { this.OnSetStopInterval(value); }
		}
		/// <summary>
		/// Gets or sets whether the task schedule expires at a specified time.
		/// </summary>
		public bool ExpiresEnabled
		{
			get { return this.expiresEnabled; }
			set { this.OnSetExpiresEnabled(value); }
		}
		/// <summary>
		/// Gets or sets the expires time.
		/// </summary>
		public DateTime ExpiresTime
		{
			get { return this.expiresTime; }
			set { this.OnSetExpiresTime(value); }
		}
		/// <summary>
		/// Gets or sets 
		/// </summary>
		public bool UseUniversalExpiresTime
		{
			get { return this.useUniversalExpiresTime; }
			set { this.OnSetUseUniversalExpiresTime(value); }
		}

		// Internal properties.

		/// <summary>
		/// Gets or sets the core schedule.
		/// </summary>
		internal CrawlerTrigger CoreTrigger { get; set; }
		/// <summary>
		/// Gets or sets the repeat schedule.
		/// </summary>
		internal CrawlerTrigger RepeatTrigger { get; set; }
		/// <summary>
		/// Gets or sets the stop schedule.
		/// </summary>
		internal CrawlerTrigger StopTrigger { get; set; }
		/// <summary>
		/// Gets or sets the expires schedule.
		/// </summary>
		internal CrawlerTrigger ExpiresTrigger { get; set; }

		// Private methods.

		/// <summary>
		/// A method called when setting the start time.
		/// </summary>
		/// <param name="value">The value.</param>
		private void OnSetStartTime(DateTime value)
		{
			// Set the value.
			this.startTime = value;
			// Raise the schedule changed event.
			if (null != this.ScheduleChanged) this.ScheduleChanged(this, new CrawlerScheduleEventArgs(this));
		}

		/// <summary>
		/// A method called when setting whether the start time is universal time.
		/// </summary>
		/// <param name="value">The value.</param>
		private void OnSetUseUniversalStartTime(bool value)
		{
			// Set the value.
			this.useUniversalStartTime = value;
		}

		/// <summary>
		/// A method called when setting whether the schedule is enabled.
		/// </summary>
		/// <param name="value">The value.</param>
		private void OnSetEnabled(bool value)
		{
			// Set the value.
			this.enabled = value;
		}

		/// <summary>
		/// A method called when setting whether the start delay is enabled.
		/// </summary>
		/// <param name="value">The value.</param>
		private void OnSetDelayEnabled(bool value)
		{
			// Set the value.
			this.delayEnabled = value;
		}

		/// <summary>
		/// A method called when setting the the delay maximum interval.
		/// </summary>
		/// <param name="value">The value.</param>
		private void OnSetDelayMaximumInterval(TimeSpan value)
		{
			// Set the value.
			this.delayMaximumInterval = value;
		}

		/// <summary>
		/// A method called when setting whether the task repeat is enabled.
		/// </summary>
		/// <param name="value">The value.</param>
		private void OnSetRepeatEnabled(bool value)
		{
			// Set the value.
			this.repeatEnabled = value;
		}

		/// <summary>
		/// A method called when setting the repeat interval.
		/// </summary>
		/// <param name="value">The value.</param>
		private void OnSetRepeatInterval(TimeSpan value)
		{
			// Set the value.
			this.repeatInterval = value;
		}

		/// <summary>
		/// A method called when setting the repeat duration.
		/// </summary>
		/// <param name="value">The value.</param>
		private void OnSetRepeatDuration(TimeSpan value)
		{
			// Set the value.
			this.repeatDuration = value;
		}

		/// <summary>
		/// A method called when setting whether the tasks stops after repeat.
		/// </summary>
		/// <param name="value">The value.</param>
		private void OnSetStopAfterRepeatEnabled(bool value)
		{
			// Set the value.
			this.stopAfterRepeatEnabled = value;
		}

		/// <summary>
		/// A method called when setting whether the task stop is enabled.
		/// </summary>
		/// <param name="value">The value.</param>
		private void OnSetStopEnabled(bool value)
		{
			// Set the value.
			this.stopEnabled = value;
		}

		/// <summary>
		/// A method called when setting the task stop interval.
		/// </summary>
		/// <param name="value">The value.</param>
		private void OnSetStopInterval(TimeSpan value)
		{
			// Set the value.
			this.stopInterval = value;
		}

		/// <summary>
		/// A method called when setting whether the task expires.
		/// </summary>
		/// <param name="value">The value.</param>
		private void OnSetExpiresEnabled(bool value)
		{
			// Set the value.
			this.expiresEnabled = value;
		}

		/// <summary>
		/// A method called when setting the expiration time.
		/// </summary>
		/// <param name="value">The value.</param>
		private void OnSetExpiresTime(DateTime value)
		{
			// Set the value.
			this.expiresTime = value;
		}

		/// <summary>
		/// A method called when setting the expiration time is universal time.
		/// </summary>
		/// <param name="value">The value.</param>
		private void OnSetUseUniversalExpiresTime(bool value)
		{
			// Set the value.
			this.useUniversalExpiresTime = value;
		}
	}
}
