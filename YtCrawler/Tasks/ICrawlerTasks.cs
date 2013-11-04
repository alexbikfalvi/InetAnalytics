using System;
using YtCrawler.Tasks.Triggers;

namespace YtCrawler.Tasks
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
		void OnAddTrigger(CrawlerTrigger trigger, out DateTime timestamp);
		
		/// <summary>
		/// Removes a trigger from the tasks timeline.
		/// </summary>
		/// <param name="trigger">The trigger.</param>
		void OnRemoveTrigger(CrawlerTrigger trigger);
	}
}
