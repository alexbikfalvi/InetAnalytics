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
using System.Threading;
using InetCrawler.Tasks.Triggers;

namespace InetCrawler.Tasks
{
	/// <summary>
	/// A delegate used for task asynchronous operations.
	/// </summary>
	/// <param name="task">The crawler task.</param>
	public delegate void CrawlerTaskCallback(CrawlerTask task);

	/// <summary>
	/// An abstract class representing a crawler task.
	/// </summary>
	public abstract class CrawlerTask
	{
		/// <summary>
		/// The task state.
		/// </summary>
		public enum TaskState
		{
			Stopped = 0,
			Started = 1
		}
		/// <summary>
		/// The policy for executing a running task.
		/// </summary>
		public enum RunningTaskPolicy
		{
			Ignore = 0,
			Parallel = 1,
			Queue = 2,
			Stop = 3
		}
		/// <summary>
		/// A structure representing the running task information.
		/// </summary>
		public sealed class RunningTaskState
		{
			public CancellationTokenSource CancellationSource { get; private set; }
			//public WaitHandle 
		}

		private readonly object sync = new object();
		private TaskState state = TaskState.Stopped;

		private readonly Dictionary<Guid, CrawlerSchedule> schedules = new Dictionary<Guid, CrawlerSchedule>();

		private readonly CrawlerTaskEventArgs args;

		private readonly CrawlerTriggerTaskRestart triggerRestart;

		private bool restartAfterFailureEnabled = false;
		private TimeSpan restartAfterFailureInterval = TimeSpan.FromMinutes(1.0);
		private uint restartAfterFailureMaximum = 3;

		private bool stopEnabled = false;
		private TimeSpan stopInterval = TimeSpan.FromDays(3.0);

		private bool deleteEnabled = false;
		private TimeSpan deleteInterval = TimeSpan.FromDays(30.0);

		/// <summary>
		/// Creates a new crawler task instance.
		/// </summary>
		/// <param name="tasks">The tasks handler.</param>
		/// <param name="name">The task name.</param>
		public CrawlerTask(ICrawlerTasks tasks, string name)
		{
			// Set the task properties.
			this.Id = Guid.NewGuid();
			this.Name = name;

			// Create the task event arguments.
			this.args = new CrawlerTaskEventArgs(this);

			// Create the task triggers.
			this.triggerRestart = new CrawlerTriggerTaskRestart(tasks, this, this.restartAfterFailureInterval, this.restartAfterFailureMaximum);
		}

		// Public properties.

		/// <summary>
		/// Gets the task identifier.
		/// </summary>
		public Guid Id { get; private set; }
		/// <summary>
		/// Gets the task synchronization object.
		/// </summary>
		public object Sync { get { return this.sync; } }
		/// <summary>
		/// Gets or sets the task 
		/// </summary>
		public string Name { get; private set; }
		/// <summary>
		/// Gets or sets the task description.
		/// </summary>
		public string Description { get; set; }
		/// <summary>
		/// Gets the task state.
		/// </summary>
		public TaskState State { get { lock (this.sync) { return this.state; } } }
		/// <summary>
		/// Gets the schedules collection.
		/// </summary>
		public ICollection<KeyValuePair<Guid, CrawlerSchedule>> Schedules { get { return schedules; } }

		// Public events.

		/// <summary>
		/// An event raised when the task has been started.
		/// </summary>
		public event CrawlerTaskEventHandler Started;
		/// <summary>
		/// An event raised when the task has been stopped.
		/// </summary>
		public event CrawlerTaskEventHandler Stopped;
		/// <summary>
		/// An event raised when the execution of the current task has started.
		/// </summary>
		public event CrawlerTaskEventHandler ExecuteStarted;
		/// <summary>
		/// An event raised when the execution of the current task has finished.
		/// </summary>
		public event CrawlerTaskEventHandler ExecuteFinished;
		/// <summary>
		/// An event raised when a schedule has been added to the task.
		/// </summary>
		public event CrawlerScheduleEventHandler ScheduleAdded;
		/// <summary>
		/// An event raised when a schedule has been removed from a task.
		/// </summary>
		public event CrawlerScheduleEventHandler ScheduleRemoved;

		// Public methods.

		/// <summary>
		/// Starts the crawler task.
		/// </summary>
		/// <param name="callback">A method called asynchronously when the task has started.</param>
		/// <param name="wait">A wait handle.</param>
		/// <param name="state">The task state.</param>
		public void Start(WaitCallback callback, EventWaitHandle wait, object state = null)
		{
			// Synchronize the task.
			lock (this.sync)
			{
				// Check the state.
				if (this.state != TaskState.Stopped) throw new CrawlerTaskException("The crawler task is not in the stopped state.");

				// Execute the starting on the thread pool.
				ThreadPool.QueueUserWorkItem((object st) =>
					{
						// Synchronize the task.
						lock (this.sync)
						{
							// Change the state.
							this.state = TaskState.Started;
							// Call the event handler.
							this.OnStarted();
							// Raise the event.
							if (null != this.Started) this.Started(this, this.args);
							// Set the wait handle.
							if (null != wait) wait.Set();
							// Call the callback method.
							if (null != callback) callback(state);
						}
					});
			}
		}

		/// <summary>
		/// Stops the crawler task.
		/// </summary>
		/// <param name="callback">A method called asynchronously when the task has stopped.</param>
		/// <param name="wait">A wait handle.</param>
		/// <param name="state">The task state.</param>
		public void Stop(WaitCallback callback, EventWaitHandle wait, object state = null)
		{
			// Synchronize the task.
			lock (this.sync)
			{
				// Check the state.
				if (this.state != TaskState.Started) throw new CrawlerTaskException("The crawler task is not in the started state.");

				// Execute the starting on the thread pool.
				ThreadPool.QueueUserWorkItem((object st) =>
				{
					// Synchronize the task.
					lock (this.sync)
					{
						// Change the state.
						this.state = TaskState.Stopped;
						// Call the event handler.
						this.OnStopped();
						// Raise the event.
						if (null != this.Stopped) this.Stopped(this, this.args);
						// Set the wait handle.
						if (null != wait) wait.Set();
						// Call the callback method.
						if (null != callback) callback(state);
					}
				});
			}
		}

		/// <summary>
		/// Executes the task.
		/// </summary>
		/// <param name="time">The scheduled time.</param>
		public void Execute(DateTime time)
		{
			// Synchronize the task.
			lock (this.sync)
			{
				// Check the state.
				if (this.state != TaskState.Started) throw new CrawlerTaskException("The crawler task is not in the started state.");

				// Raise the event.
				if (null != this.Stopped) this.Stopped(this, this.args);

				// Execute the event handler on the thread pool.
				ThreadPool.QueueUserWorkItem((object state) =>
					{
						// Create a cancellation token source.
						using (CancellationTokenSource cancellationSource = new CancellationTokenSource())
						{
							// Create a running task state.

							// Synchronize the task.

							try
							{
								// Call the task handler.
								this.OnExecute(cancellationSource.Token);
							}
							catch (Exception exception)
							{
							}
						}
					});
			}
		}

		/// <summary>
		/// Cancels the task execution.
		/// </summary>
		/// <param name="state">The running task state.</param>
		public void Cancel(RunningTaskState state)
		{

		}

		/// <summary>
		/// Cancels the execution of all task events.
		/// </summary>
		public void CancelAll()
		{

		}

		public void CancelAllAsync(WaitHandle wait)
		{

		}

		// Protected methods.

		/// <summary>
		/// A method called when the task is started.
		/// </summary>
		protected abstract void OnStarted();

		/// <summary>
		/// A method called when the task is stopped.
		/// </summary>
		protected abstract void OnStopped();

		/// <summary>
		/// A method called when the task is executed.
		/// </summary>
		/// <param name="cancel">The cancellation token.</param>
		protected abstract void OnExecute(CancellationToken cancel);
	}
}
