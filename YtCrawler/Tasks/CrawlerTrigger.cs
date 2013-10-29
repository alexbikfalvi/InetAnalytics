using System;

namespace YtCrawler.Tasks
{
	/// <summary>
	/// A class representing a crawler task trigger.
	/// </summary>
	public sealed class CrawlerTrigger
	{
		/// <summary>
		/// An enumeration representing the trigger type.
		/// </summary>
		public enum TriggerType
		{
			CoreTrigger = 0,
			RepeatTrigger = 1,
			StopTrigger = 2,
			ExpiresTrigger = 3
		}

		/// <summary>
		/// Creates a new trigger instance.
		/// </summary>
		/// <param name="schedule">The schedule.</param>
		/// <param name="type">The trigger type.</param>
		/// <param name="timestamp">The schedule timestamp.</param>
		public CrawlerTrigger(CrawlerSchedule schedule, TriggerType type, DateTime timestamp)
		{
			this.Schedule = schedule;
			this.Type = type;

			this.Timestamp = timestamp;
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
		/// Gets or sets the trigger timestamp.
		/// </summary>
		public DateTime Timestamp { get; set; }
	}
}
