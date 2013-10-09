using System;

namespace YtApi.Api.V2
{
	public enum YouTubeStandardFeed
	{
		TopRated = 0,
		TopFavories = 1,
		MostShared = 2,
		MostPopular = 3,
		MostRecent = 4,
		MostDiscussed = 5,
		MostResponsed = 6,
		RecentlyFeatured = 7,
		TrendingVideos = 8
	}

	public enum YouTubeTimeId
	{
		AllTime = 0,
		Today = 1,
		ThisWeek = 2,
		ThisMonth = 3
	}
	
	/// <summary>
	/// A class that contains YouTube identifiers.
	/// </summary>
	public class YouTube
	{
		private static readonly YouTubeStandardFeed[] feeds = new YouTubeStandardFeed[] {
			YouTubeStandardFeed.TopRated,
			YouTubeStandardFeed.TopFavories,
			YouTubeStandardFeed.MostShared,
			YouTubeStandardFeed.MostPopular,
			YouTubeStandardFeed.MostRecent,
			YouTubeStandardFeed.MostDiscussed,
			YouTubeStandardFeed.MostResponsed,
			YouTubeStandardFeed.RecentlyFeatured,
			YouTubeStandardFeed.TrendingVideos
		};
		private static readonly YouTubeTimeId[] times = new YouTubeTimeId[] {
			YouTubeTimeId.AllTime,
			YouTubeTimeId.Today,
			YouTubeTimeId.ThisWeek,
			YouTubeTimeId.ThisMonth
		};

		/// <summary>
		/// Gets the list of YouTube standard feeds.
		/// </summary>
		public static YouTubeStandardFeed[] StandardFeeds { get { return YouTube.feeds; } }
		/// <summary>
		/// Gets the list of YouTube times.
		/// </summary>
		public static YouTubeTimeId[] Times { get { return YouTube.times; } }
	}
}
