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
	/// A class representing a crawler trigger.
	/// </summary>
	public abstract class CrawlerTrigger
	{
		private readonly ICrawlerTasks tasks = null;

		private bool enabled = false;
		private DateTime timestamp;

		private readonly object sync = new object();

		/// <summary>
		/// Creates a new trigger instance.
		/// </summary>
		/// <param name="tasks">The tasks handler.</param>
		public CrawlerTrigger(ICrawlerTasks tasks)
		{
			// Validate the arguments.
			if (null == tasks) throw new ArgumentNullException("tasks");
			// Set the tasks handler.
			this.tasks = tasks;
		}

		// Public properties.

		/// <summary>
		/// Gets whether the trigger is enabled.
		/// </summary>
		public bool Enabled
		{
			get { return this.enabled; }
		}
		/// <summary>
		/// Gets the trigger timestamp.
		/// </summary>
		public DateTime Timestamp
		{
			get { return this.timestamp; }
		}

		// Protected properties.

		/// <summary>
		/// Gets the synchronization object.
		/// </summary>
		protected object Sync { get { return this.sync; } }

		// Public methods.
		
		/// <summary>
		/// Executes the current trigger and disables the trigger state.
		/// </summary>
		public void Execute()
		{
			lock (this.sync)
			{
				// If the trigger is disabled, throw an exception.
				if (!this.enabled) throw new InvalidOperationException("Cannot disable a trigger because the trigger is already disabled.");
				// Disable the trigger.
				this.enabled = false;
			}
			// Call the execute handler.
			this.OnExecute();
		}
		
		/// <summary>
		/// Enables the trigger for the specified timestamp.
		/// </summary>
		/// <param name="timestamp">The timestamp.</param>
		public void Enable(DateTime timestamp)
		{
			lock (this.sync)
			{
				// If the trigger is already enabled, throw an exception.
				if (this.enabled) throw new InvalidOperationException("Cannot enable a trigger because the trigger is already enabled.");

				// Set the enabled state to true.
				this.enabled = true;
				// Set the timestamp.
				this.timestamp = timestamp;

				// Add the trigger to the tasks timeline.
				this.tasks.AddTrigger(this, out timestamp);

				// If the trigger timestamp has changed.
				if (this.timestamp != timestamp)
				{
					// Update the timestamp.
					this.timestamp = timestamp;
				}
			}
		}

		/// <summary>
		/// Disables the trigger.
		/// </summary>
		public void Disable()
		{
			lock (this.sync)
			{
				// If the trigger is disabled, throw an exception.
				if (!this.enabled) throw new InvalidOperationException("Cannot disable a trigger because the trigger is already disabled.");

				// Set the enabled state to false.
				this.enabled = false;

				// Remove the trigger from the tasks timeline.
				this.tasks.RemoveTrigger(this);
			}
		}

		/// <summary>
		/// Changes a trigger timestamp in the tasks timeline.
		/// </summary>
		/// <param name="timestamp"></param>
		public void Change(DateTime timestamp)
		{
			lock (this.sync)
			{
				// If the trigger is disabled, throw an exception.
				if (!this.enabled) throw new InvalidOperationException("Cannot change a trigger because the trigger is disabled.");

				// Remove the trigger.
				this.tasks.RemoveTrigger(this);

				// Set the new timestamp.
				this.timestamp = timestamp;

				// Add the trigger.
				this.tasks.AddTrigger(this, out timestamp);

				// If the trigger timestamp has changed.
				if (this.timestamp != timestamp)
				{
					// Update the timestamp.
					this.timestamp = timestamp;
				}
			}
		}

		// Protected methods.

		protected abstract void OnExecute();
	}
}
