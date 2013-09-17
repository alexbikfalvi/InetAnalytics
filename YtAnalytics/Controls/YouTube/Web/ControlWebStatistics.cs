/* 
 * Copyright (C) 2012-2013 Alex Bikfalvi
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
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DotNetApi;
using DotNetApi.Windows.Controls;
using YtAnalytics.Controls.Comments;
using YtAnalytics.Events;
using YtAnalytics.Forms.YouTube;
using YtApi.Ajax;
using YtCrawler;
using YtCrawler.Comments;
using YtCrawler.Log;

namespace YtAnalytics.Controls.YouTube.Web
{
	/// <summary>
	/// A control that displays the video statistics using the web data.
	/// </summary>
	public partial class ControlWebStatistics : ThreadSafeControl
	{
		private static string logSource = "Web Statistics";

		private Crawler crawler;
		private AjaxRequestStatistics request;
		private IAsyncResult result;

		private AjaxVideoStatistics statistics = null;
		private string statisticsVideo = null;

		private FormDiscoveryProperties formEvent = new FormDiscoveryProperties();

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlWebStatistics()
		{
			InitializeComponent();
			// Default settings.
			this.Dock = DockStyle.Fill;
			this.Visible = false;
		}

		/// <summary>
		/// An event handler called when the user adds a new comment.
		/// </summary>
		public event StringEventHandler Comment;

		/// <summary>
		/// Initializes the control.
		/// </summary>
		/// <param name="crawler">A crawler object.</param>
		public void Initialize(Crawler crawler)
		{
			this.crawler = crawler;
			this.request = new AjaxRequestStatistics();
			this.Enabled = true;
		}

		/// <summary>
		/// Opens the specified video ID.
		/// </summary>
		/// <param name="video">The video ID.</param>
		public void View(string video)
		{
			if (!this.textBox.Enabled) return;
			this.textBox.Text = video;
			this.OnStart(null, null);
		}

		/// <summary>
		/// An event handler called when the video ID has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnVideoChanged(object sender, EventArgs e)
		{
			this.buttonStart.Enabled = string.IsNullOrWhiteSpace(this.textBox.Text);
		}

		/// <summary>
		/// Starts a query for the current video.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStart(object sender, EventArgs e)
		{
			// Check if executing the demo.
			if (this.textBox.Text.ToLower() == "demo")
			{
				this.OnDemo();
				return;
			}

			// Change the controls state.
			this.buttonStart.Enabled = false;
			this.buttonStop.Enabled = true;
			this.buttonDiscovery.Enabled = false;
			this.buttonComment.Enabled = false;
			this.textBox.Enabled = false;
			this.statisticsVideo = null;

			// Clear the previous results.
			this.chart.Series.Clear();
			this.chart.Annotations.Clear();
			this.listViewDiscovery.Items.Clear();

			foreach (var item in this.buttonChart.DropDown.Items)
				if (item is ToolStripMenuItem)
				{
					(item as ToolStripMenuItem).Checked = false;
					(item as ToolStripMenuItem).Enabled = false;
				}
			this.buttonChart.Text = "Select data";

			// Log
			this.log.Add(this.crawler.Log.Add(
				LogEventLevel.Verbose,
				LogEventType.Information,
				ControlWebStatistics.logSource,
				"Started request for the web statistics of the video \'{0}\'.",
				new object[] { this.textBox.Text }));

			// Clear the chart.
			//this.c;

			try
			{
				// Begin the request.
				this.result = this.request.Begin(this.textBox.Text, this.Callback);
			}
			catch (Exception exception)
			{
				this.log.Add(this.crawler.Log.Add(
					LogEventLevel.Important,
					LogEventType.Error,
					ControlWebStatistics.logSource,
					"The request for the web statistics of the video \'{0}\' failed. {1}",
					new object[] { this.textBox.Text, exception.Message },
					exception));
			}

		}

		/// <summary>
		/// Cancels the current query.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStop(object sender, EventArgs e)
		{
			// Cancel the request.
			this.request.Cancel(this.result);
			// Disable the stop button.
			this.buttonStop.Enabled = false;
		}

		/// <summary>
		/// The callback function of the asynchronous request.
		/// </summary>
		/// <param name="result">The </param>
		private void Callback(IAsyncResult result)
		{
			if (this.InvokeRequired)
				this.Invoke(new AsyncCallback(this.Callback), new object[] { result });
			else
			{
				try
				{
					this.statistics = this.request.End(result);
					this.statisticsVideo = this.textBox.Text;

					this.menuItemViews.Enabled = this.statistics.ViewsHistory != null;
					this.menuItemLikes.Enabled = this.statistics.LikesHistory != null;
					this.menuItemDislikes.Enabled = this.statistics.DislikesHistory != null;
					this.menuItemFavorites.Enabled = this.statistics.FavoritesHistory != null;
					this.menuItemComments.Enabled = this.statistics.CommentsHistory != null;
					this.menuItemPopularity.Enabled = this.statistics.ViewsHistory != null;

					this.buttonComment.Enabled = true;

					if (this.statistics.ViewsHistory != null)
					{
						this.OnChartViewsCount(null, null);
					}

					// Compute the event type.
					LogEventType eventType = (this.statistics.ViewsHistory.DiscoveryExceptions.Count == 0) ? LogEventType.Success : LogEventType.SuccessWarning;
					string eventMessage = eventType == LogEventType.Success ?
						"The request for the web statistics of the video \'{0}\' completed successfully." :
						"The request for the web statistics of the video \'{0}\' completed partially successfully. However, some errors have occurred.";

					// If there are failures, create a new subevent list.
					List<LogEvent> subevents = null;
					if (this.statistics.ViewsHistory.DiscoveryExceptions.Count != 0)
					{
						subevents = new List<LogEvent>();
						foreach (AjaxException exception in this.statistics.ViewsHistory.DiscoveryExceptions)
						{
							subevents.Add(new LogEvent(
								LogEventLevel.Important,
								LogEventType.Error,
								DateTime.MinValue,
								ControlWebStatistics.logSource,
								"Parsing of a views history discovery event has failed.",
								null,
								exception));
						}
					}

					// Log
					this.log.Add(this.crawler.Log.Add(
						LogEventLevel.Verbose,
						eventType,
						ControlWebStatistics.logSource,
						eventMessage,
						new object[] { this.textBox.Text },
						null,
						subevents));
				}
				catch (AjaxRequestException exception)
				{
					this.log.Add(this.crawler.Log.Add(
						LogEventLevel.Normal,
						LogEventType.Warning,
						ControlWebStatistics.logSource,
						"The web statistics for the video \'{0}\' are not available. {1}",
						new object[] { this.textBox.Text, exception.Message },
						exception));
				}
				catch (WebException exception)
				{
					if (exception.Status == WebExceptionStatus.RequestCanceled)
						this.log.Add(this.crawler.Log.Add(
							LogEventLevel.Verbose,
							LogEventType.Canceled,
							ControlWebStatistics.logSource,
							"The request for the web statistics of the video \'{0}\' has been canceled.",
							new object[] { this.textBox.Text }));
					else
						this.log.Add(this.crawler.Log.Add(
							LogEventLevel.Important,
							LogEventType.Error,
							ControlWebStatistics.logSource,
							"The request for the web statistics of the video \'{0}\' failed. {1}",
							new object[] { this.textBox.Text, exception.Message },
							exception));
				}
				catch (Exception exception)
				{
					this.log.Add(this.crawler.Log.Add(
						LogEventLevel.Important,
						LogEventType.Error,
						ControlWebStatistics.logSource,
						"The request for the web statistics of the video \'{0}\' failed. {1}",
						new object[] { this.textBox.Text, exception.Message },
						exception));
				}
				finally
				{
					this.buttonStart.Enabled = true;
					this.buttonStop.Enabled = false;
					this.textBox.Enabled = true;
				}
			}
		}

		/// <summary>
		/// An event handler called when executing the demo.
		/// </summary>
		private void OnDemo()
		{
			try
			{
				this.statistics = AjaxVideoStatistics.Parse(Resources.DemoOldInsightsAjax);
				this.statisticsVideo = this.textBox.Text;

				this.menuItemViews.Enabled = this.statistics.ViewsHistory != null;
				this.menuItemLikes.Enabled = this.statistics.LikesHistory != null;
				this.menuItemDislikes.Enabled = this.statistics.DislikesHistory != null;
				this.menuItemFavorites.Enabled = this.statistics.FavoritesHistory != null;
				this.menuItemComments.Enabled = this.statistics.CommentsHistory != null;
				this.menuItemPopularity.Enabled = this.statistics.ViewsHistory != null;

				this.buttonComment.Enabled = true;

				if (this.statistics.ViewsHistory != null)
				{
					this.OnChartViewsCount(null, null);
				}

				// Compute the event type.
				LogEventType eventType = (this.statistics.ViewsHistory.DiscoveryExceptions.Count == 0) ? LogEventType.Success : LogEventType.SuccessWarning;
				string eventMessage = eventType == LogEventType.Success ?
					"The request for the web statistics of the video \'{0}\' completed successfully." :
					"The request for the web statistics of the video \'{0}\' completed partially successfully. However, some errors have occurred.";

				// If there are failures, create a new subevent list.
				List<LogEvent> subevents = null;
				if (this.statistics.ViewsHistory.DiscoveryExceptions.Count != 0)
				{
					subevents = new List<LogEvent>();
					foreach (AjaxException exception in this.statistics.ViewsHistory.DiscoveryExceptions)
					{
						subevents.Add(new LogEvent(
							LogEventLevel.Important,
							LogEventType.Error,
							DateTime.MinValue,
							ControlWebStatistics.logSource,
							"Parsing of a views history discovery event has failed.",
							null,
							exception));
					}
				}

				// Log
				this.log.Add(this.crawler.Log.Add(
					LogEventLevel.Verbose,
					eventType,
					ControlWebStatistics.logSource,
					eventMessage,
					new object[] { this.textBox.Text },
					null,
					subevents));
			}
			catch (AjaxRequestException exception)
			{
				this.log.Add(this.crawler.Log.Add(
					LogEventLevel.Normal,
					LogEventType.Warning,
					ControlWebStatistics.logSource,
					"The web statistics for the video \'{0}\' are not available. {1}",
					new object[] { this.textBox.Text, exception.Message },
					exception));
			}
			catch (WebException exception)
			{
				if (exception.Status == WebExceptionStatus.RequestCanceled)
					this.log.Add(this.crawler.Log.Add(
						LogEventLevel.Verbose,
						LogEventType.Canceled,
						ControlWebStatistics.logSource,
						"The request for the web statistics of the video \'{0}\' has been canceled.",
						new object[] { this.textBox.Text }));
				else
					this.log.Add(this.crawler.Log.Add(
						LogEventLevel.Important,
						LogEventType.Error,
						ControlWebStatistics.logSource,
						"The request for the web statistics of the video \'{0}\' failed. {1}",
						new object[] { this.textBox.Text, exception.Message },
						exception));
			}
			catch (Exception exception)
			{
				this.log.Add(this.crawler.Log.Add(
					LogEventLevel.Important,
					LogEventType.Error,
					ControlWebStatistics.logSource,
					"The request for the web statistics of the video \'{0}\' failed. {1}",
					new object[] { this.textBox.Text, exception.Message },
					exception));
			}
			finally
			{
				this.buttonStart.Enabled = true;
				this.buttonStop.Enabled = false;
				this.textBox.Enabled = true;
			}
		}

		/// <summary>
		/// Displays the history for the current statistics.
		/// </summary>
		/// <param name="history">The views history.</param>
		/// <param name="axisX">The X axis.</param>
		/// <param name="axisY">The Y axis.</param>
		private void DisplayHistory(AjaxViewsHistory history, string axisX, string axisY)
		{
			if (null == history) return;

			this.chart.Series.Clear();
			this.chart.Annotations.Clear();
			this.listViewDiscovery.Items.Clear();

			// Update the chart.
			Series series = new Series("Video {0}".FormatWith(this.textBox));
			series.ChartType = SeriesChartType.Line;
			series.XValueType = ChartValueType.DateTime;
			series.YValueType = ChartValueType.Int32;
			series.Font = new Font(this.Font.FontFamily, this.Font.Size, this.Font.Style);
			series.MarkerStyle = MarkerStyle.Circle;

			foreach (AjaxHistoryPoint point in history.Series)
				series.Points.AddXY(point.Time, point.Value);

			this.chart.Series.Add(series);
			this.chart.ChartAreas[0].AxisX.Title = axisX;
			this.chart.ChartAreas[0].AxisY.Title = axisY;
			
			AjaxHistoryMarker? lastMarker = null;
			RectangleAnnotation lastAnnotation = null;

			// For all markers.
			foreach (AjaxHistoryMarker marker in history.Markers)
			{
				// Get the history point closest to the marker.
				AjaxHistoryPoint? point = history.GetPointAt(marker);

				// If the point does not exist, continue.
				if (null == point) continue;

				// If the last marker and last annotation exist.
				if ((lastMarker != null) && (lastAnnotation != null))
				{
					// If the last marker has the same date with the current one, only update the annotation text.
					if (lastMarker.Value.Time == marker.Time)
					{
						lastAnnotation.Text += " " + marker.Name;
						continue;
					}
				}

				RectangleAnnotation rect = new RectangleAnnotation();
				rect.Text = marker.Name;
				rect.ForeColor = Color.Black;
				rect.AxisX = this.chart.ChartAreas[0].AxisX;
				rect.AxisY = this.chart.ChartAreas[0].AxisY;
				rect.AnchorX = marker.Time.ToOADate();
				rect.AnchorY = point.Value.Value;
				rect.AnchorOffsetX = 0;
				rect.AnchorOffsetY = 5;
				rect.ShadowColor = Color.Gray;
				rect.ShadowOffset = 5;

				VerticalLineAnnotation line = new VerticalLineAnnotation();
				line.AxisX = this.chart.ChartAreas[0].AxisX;
				line.AxisY = this.chart.ChartAreas[0].AxisY;
				line.AnchorX = marker.Time.ToOADate();
				line.AnchorY = point.Value.Value;
				line.Height = -5;

				this.chart.Annotations.Add(line);
				this.chart.Annotations.Add(rect);
				this.chart.ResetAutoValues();

				lastAnnotation = rect;
				lastMarker = marker;
			}

			// Add discovery events.
			foreach (KeyValuePair<string, AjaxViewsHistoryDiscoveryEvent> evt in history.DiscoveryEvents)
			{
				ListViewItem item = new ListViewItem(new string[] {
						evt.Value.Name,
						evt.Value.Marker != null ? evt.Value.Marker.Value.Time.ToString() : "Unknown",
						AjaxViewsHistoryDiscoveryEvent.GetTypeDescription(evt.Value.Type),
						evt.Value.Extra != null ? evt.Value.Extra : string.Empty }, 0);
				item.Tag = evt.Value;

				this.listViewDiscovery.Items.Add(item);
			}
		}

		/// <summary>
		/// Displays the history variation for the current statistics.
		/// </summary>
		/// <param name="history">The views history.</param>
		/// <param name="axisX">The X axis.</param>
		/// <param name="axisY">The Y axis.</param>
		private void DisplayHistoryVariation(AjaxViewsHistory history, string axisX, string axisY)
		{
			if (null == history) return;

			this.chart.Series.Clear();
			this.chart.Annotations.Clear();
			this.listViewDiscovery.Items.Clear();

			// Update the chart.
			Series series = new Series("Video {0}".FormatWith(this.textBox));
			series.ChartType = SeriesChartType.Line;
			series.XValueType = ChartValueType.DateTime;
			series.YValueType = ChartValueType.Int32;
			series.Font = new Font(this.Font.FontFamily, this.Font.Size, this.Font.Style);
			series.MarkerStyle = MarkerStyle.Circle;

			DateTime[] time = new DateTime[history.Series.Length - 1];
			double[] popularity = new double[history.Series.Length - 1];
			for (int index = 1; index < history.Series.Length; index++)
			{
				TimeSpan dx = history.Series[index].Time - history.Series[index - 1].Time;
				time[index - 1] = new DateTime((history.Series[index].Time.Ticks + history.Series[index - 1].Time.Ticks) / 2);
				double dy = history.Series[index].Value - history.Series[index - 1].Value;
				popularity[index - 1] = dy / dx.TotalDays;

				series.Points.AddXY(time[index - 1], popularity[index - 1]);
			}

			this.chart.Series.Add(series);
			this.chart.ChartAreas[0].AxisX.Title = axisX;
			this.chart.ChartAreas[0].AxisY.Title = axisY;

			AjaxHistoryMarker? lastMarker = null;
			RectangleAnnotation lastAnnotation = null;

			// For all markers.
			foreach (AjaxHistoryMarker marker in history.Markers)
			{
				// Get the history point closest to the marker.
				AjaxHistoryPoint? point = history.GetPointAt(marker);

				// If the point does not exist, continue.
				if (null == point) continue;

				// Get index of the point.
				int index = Array.IndexOf<AjaxHistoryPoint>(history.Series, point.Value);

				// If the index is not found, skip the point.
				if (-1 == index) continue;

				// If the index is greater than the number of popularity points, limit the index to the size of the popularity array.
				if (index >= popularity.Length) index = popularity.Length - 1;

				// If the last marker and last annotation exist.
				if ((lastMarker != null) && (lastAnnotation != null))
				{
					// If the last marker has the same date with the current one, only update the annotation text.
					if (lastMarker.Value.Time == marker.Time)
					{
						lastAnnotation.Text += " " + marker.Name;
						continue;
					}
				}

				RectangleAnnotation rect = new RectangleAnnotation();
				rect.Text = marker.Name;
				rect.ForeColor = Color.Black;
				rect.AxisX = this.chart.ChartAreas[0].AxisX;
				rect.AxisY = this.chart.ChartAreas[0].AxisY;
				rect.AnchorX = time[index].ToOADate();
				rect.AnchorY = popularity[index];
				rect.AnchorOffsetX = 0;
				rect.AnchorOffsetY = 5;
				rect.ShadowColor = Color.Gray;
				rect.ShadowOffset = 5;

				VerticalLineAnnotation line = new VerticalLineAnnotation();
				line.AxisX = this.chart.ChartAreas[0].AxisX;
				line.AxisY = this.chart.ChartAreas[0].AxisY;
				line.AnchorX = time[index].ToOADate();
				line.AnchorY = popularity[index];
				line.Height = -5;

				this.chart.Annotations.Add(line);
				this.chart.Annotations.Add(rect);
				this.chart.ResetAutoValues();

				lastAnnotation = rect;
				lastMarker = marker;
			}

			// Add discovery events.
			foreach (KeyValuePair<string, AjaxViewsHistoryDiscoveryEvent> evt in history.DiscoveryEvents)
			{
				ListViewItem item = new ListViewItem(new string[] {
						evt.Value.Name,
						evt.Value.Marker != null ? evt.Value.Marker.Value.Time.ToString() : "Unknown",
						AjaxViewsHistoryDiscoveryEvent.GetTypeDescription(evt.Value.Type),
						evt.Value.Extra != null ? evt.Value.Extra : string.Empty }, 0);
				item.Tag = evt.Value;

				this.listViewDiscovery.Items.Add(item);
			}
		}

		/// <summary>
		/// Displays the statistics history.
		/// </summary>
		/// <param name="history">The statistics history.</param>
		/// <param name="axisX">The X axis.</param>
		/// <param name="axisY">The Y axis.</param>
		private void DisplayHistory(AjaxHistory history, string axisX, string axisY)
		{
			if (null == history) return;

			this.chart.Series.Clear();
			this.chart.Annotations.Clear();
			this.listViewDiscovery.Items.Clear();

			// Update the chart.
			Series series = new Series("Video {0}".FormatWith(this.textBox));
			series.ChartType = SeriesChartType.Line;
			series.XValueType = ChartValueType.DateTime;
			series.YValueType = ChartValueType.Int32;
			series.Font = new Font(this.Font.FontFamily, this.Font.Size, this.Font.Style);

			foreach (AjaxHistoryPoint point in history.Series)
				series.Points.AddXY(point.Time, point.Value);

			this.chart.Series.Add(series);
			this.chart.ChartAreas[0].AxisX.Title = axisX;
			this.chart.ChartAreas[0].AxisY.Title = axisY;
		}

		/// <summary>
		/// An event handler called when the user selects the views count chart.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnChartViewsCount(object sender, EventArgs e)
		{
			if (this.menuItemViews.Checked) return;
			foreach (var item in this.buttonChart.DropDown.Items)
				if (item is ToolStripMenuItem)
					(item as ToolStripMenuItem).Checked = false;
			this.menuItemViews.Checked = true;
			this.buttonChart.Text = this.menuItemViews.Text;
			this.DisplayHistory(this.statistics.ViewsHistory, "Time", "Views count");
		}

		/// <summary>
		/// An event handler called when the user selects the likes count chart.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnChartLikesCount(object sender, EventArgs e)
		{
			if (this.menuItemLikes.Checked) return;
			foreach (var item in this.buttonChart.DropDown.Items)
				if (item is ToolStripMenuItem)
					(item as ToolStripMenuItem).Checked = false;
			this.menuItemLikes.Checked = true;
			this.buttonChart.Text = this.menuItemLikes.Text;
			this.DisplayHistory(this.statistics.LikesHistory, "Time", "Likes count");
		}

		/// <summary>
		/// An event handler called when the user selects the dislikes count chart.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnChartDislikesCount(object sender, EventArgs e)
		{
			if (this.menuItemDislikes.Checked) return;
			foreach (var item in this.buttonChart.DropDown.Items)
				if (item is ToolStripMenuItem)
					(item as ToolStripMenuItem).Checked = false;
			this.menuItemDislikes.Checked = true;
			this.buttonChart.Text = this.menuItemDislikes.Text;
			this.DisplayHistory(this.statistics.DislikesHistory, "Time", "Dislikes count");
		}

		/// <summary>
		/// An event handler called when the user selects the favorites count chart.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnChartFavoritesCount(object sender, EventArgs e)
		{
			if (this.menuItemFavorites.Checked) return;
			foreach (var item in this.buttonChart.DropDown.Items)
				if (item is ToolStripMenuItem)
					(item as ToolStripMenuItem).Checked = false;
			this.menuItemFavorites.Checked = true;
			this.buttonChart.Text = this.menuItemFavorites.Text;
			this.DisplayHistory(this.statistics.FavoritesHistory, "Time", "Favorites count");
		}

		/// <summary>
		/// An event handler called when the user selects the comments count chart.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnChartCommentsCount(object sender, EventArgs e)
		{
			if (this.menuItemComments.Checked) return;
			foreach (var item in this.buttonChart.DropDown.Items)
				if (item is ToolStripMenuItem)
					(item as ToolStripMenuItem).Checked = false;
			this.menuItemComments.Checked = true;
			this.buttonChart.Text = this.menuItemComments.Text;
			this.DisplayHistory(this.statistics.CommentsHistory, "Time", "Comments count");
		}

		/// <summary>
		/// An event handler called when the user selects the popularity chart.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnChartPopularity(object sender, EventArgs e)
		{
			if (this.menuItemPopularity.Checked) return;
			foreach (var item in this.buttonChart.DropDown.Items)
			{
				if (item is ToolStripMenuItem)
				{
					(item as ToolStripMenuItem).Checked = false;
				}
			}
			this.menuItemPopularity.Checked = true;
			this.buttonChart.Text = this.menuItemPopularity.Text;
			this.DisplayHistoryVariation(this.statistics.ViewsHistory, "Time", "Popularity [delta views per day]");
		}

		/// <summary>
		/// An event handler called when the discovery event has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelectedDiscoveryEventChanged(object sender, EventArgs e)
		{
			this.buttonDiscovery.Enabled = this.listViewDiscovery.SelectedItems.Count > 0;
		}

		/// <summary>
		/// An event handler called when the user activates a discovery event.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnDiscoveryEventClick(object sender, EventArgs e)
		{
			// If there are no items selected, do nothing.
			if (this.listViewDiscovery.SelectedItems.Count == 0) return;
			// Else, open a dialog with the discovery event.
			this.formEvent.ShowDialog(this, this.listViewDiscovery.SelectedItems[0].Tag as AjaxViewsHistoryDiscoveryEvent);
		}

		/// <summary>
		/// An event handler called when the user adds a comment to a video.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnComment(object sender, EventArgs e)
		{
			if (null == this.statisticsVideo) return;
			if (this.Comment != null) this.Comment(this, new StringEventArgs(this.statisticsVideo));
		}
	}
}
