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
	public sealed class CrawlerTriggerTaskRestart : CrawlerTriggerTask
	{
		private TimeSpan delay;
		private uint count;

		/// <summary>
		/// Creates a new trigger instance.
		/// </summary>
		/// <param name="tasks">The tasks handler.</param>
		/// <param name="task">The task.</param>
		/// <param name="delay">The delay to a restart after a failure.</param>
		/// <param name="count">The maximum number of restarts.</param>
		public CrawlerTriggerTaskRestart(ICrawlerTasks tasks, CrawlerTask task, TimeSpan delay, uint count)
			: base(tasks, task)
		{
			this.delay = delay;
			this.count = count;
		}

		

		// Public methods.

		/// <summary>
		/// Executes the current trigger.
		/// </summary>
		public override void Execute()
		{
		}
	}
}
