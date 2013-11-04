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
	/// A class representing a crawler task trigger.
	/// </summary>
	public sealed class CrawlerTriggerSchedule : CrawlerTrigger
	{
		/// <summary>
		/// Creates a new trigger instance.
		/// </summary>
		/// <param name="schedule">The schedule.</param>
		/// <param name="type">The trigger type.</param>
		/// <param name="actionSet">An action called when the trigger is set.</param>
		/// <param name="actionDisabled">An action called when the trigger is disabled.</param>
		public CrawlerTriggerSchedule(CrawlerSchedule schedule, TriggerType type)
		{
			// Validate the arguments.
			if (null == schedule) throw new ArgumentNullException("schedule");

			// Set the properties.
			this.Schedule = schedule;
			this.Type = type;
			this.Enabled = false;
		}

		// Public properties.

		/// <summary>
		/// Gets the schedule.
		/// </summary>
		public CrawlerSchedule Schedule { get; private set; }
		/// <summary>
		/// Gets the trigger type.
		/// </summary>
		public TriggerType Type { get; private set; }
		/// <summary>
		/// Gets whether the trigger is enabled.
		/// </summary>
		public bool Enabled { get; private set; }
		/// <summary>
		/// 
		/// </summary>
		public bool Executed { get; private set; }
		/// <summary>
		/// Gets the initial trigger time.
		/// </summary>
		public DateTime InitialTime { get; private set; }
		/// <summary>
		/// Gets the current trigger time.
		/// </summary>
		public DateTime CurrentTime { get; private set; }
		/// <summary>
		/// Get the last trigger time.
		/// </summary>
		public DateTime LastTime { get; private set; }

		// Public methods.

		/// <summary>
		/// Changes the current trigger time.
		/// </summary>
		/// <param name="time">The new time.</param>
		public void Change(DateTime time)
		{
			// Update the trigger time.
			this.LastTime = time;
			this.CurrentTime = time;
		}

		/// <summary>
		/// Enables the trigger to run at the specified time. The intial time is set at the specified time.
		/// </summary>
		/// <param name="time">The trigger time.</param>
		public void Enable(DateTime time)
		{
			// Set the enabled state.
			this.Enabled = true;
			// Set the time.
			this.InitialTime = time;
			this.LastTime = time;
			this.CurrentTime = time;
			// Call the set action.
			this.actionSet(this);
		}

		/// <summary>
		/// Disables the trigger.
		/// </summary>
		public void Disable()
		{
			// Set the enabled state.
			this.Enabled = false;
			// Call the disabled action.
			this.actionDisabled(this);
		}

		/// <summary>
		/// Executes the trigger.
		/// </summary>
		public void Execute()
		{
			// Set the executed to false.
			this.Executed = false;
			// Execute the task.
			this.Schedule.Task.Execute(this.CurrentTime);
		}

		/// <summary>
		/// Renewes the trigger at the specified interval after the last time.
		/// </summary>
		/// <param name="after">The time interval.</param>
		public void Renew(TimeSpan after)
		{
			// Check the trigger is enabled.
			if (!this.Enabled) throw new InvalidOperationException("Internal task scheduler exception: cannot renew a trigger because the trigger is disabled.");

			// Set the new time.

		}
	}
}
