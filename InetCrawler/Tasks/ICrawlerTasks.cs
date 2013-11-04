using System;
using InetCrawler.Tasks.Triggers;

namespace InetCrawler.Tasks
{
	/// <summary>
	/// An interface representing the tasks handler for a crawler trigger.
	/// </summary>
	public interface ICrawlerTasks
	{
		/// <summary>
		/// Adds a new trigger to the tasks timeline.
		/// </summary>
		/// <param name="trigger">The trigger.</param>
		/// <param name="timestamp">The timeline timestamp.</param>
		void AddTrigger(CrawlerTrigger trigger, out DateTime timestamp);
		
		/// <summary>
		/// Removes a trigger from the tasks timeline.
		/// </summary>
		/// <param name="trigger">The trigger.</param>
		void RemoveTrigger(CrawlerTrigger trigger);

		/// <summary>
		/// Removes a task from the tasks list.
		/// </summary>
		/// <param name="task">The task.</param>
		void RemoveTask(CrawlerTask task);
	}
}
