/* 
 * Copyright (C) 2012 Alex Bikfalvi
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
using System.Text.RegularExpressions;
using DotNetApi;

namespace InetApi.YouTube.Ajax
{
	/// <summary>
	/// A class representing the history of a video metric.
	/// </summary>
	[Serializable]
	public class AjaxHistory
	{
		private	AjaxHistoryPoint[] series = null;
		private AjaxHistoryMarker[] markers = null;

		private static readonly char[] uriSplit = { '&', '?' };
		private static readonly char[] pipeSplit = { '|' };
		private static readonly char[] commaSplit = { ',' };

		private static readonly string regChartType = "^cht=";
		private static readonly string regChartAxisLabels = "^chxl=";
		private static readonly string regChartAxisLabelPositions = "^chxp=";
		private static readonly string regChartAxisRanges = "^chxr=";
		private static readonly string regChartAxisData = "^chd=";
		private static readonly string regChartAxisMarkers = "^chm=";

		protected enum ChartType
		{
			Lc = 0,
			Ls = 1
		}

		private ChartType chartType;

		/// <summary>
		/// Structure representing an internal axis range.
		/// </summary>
		protected struct Range
		{
			public double Start { get; set; }
			public double End { get; set; }
		}

		/// <summary>
		/// Structure representing an internal axis marker.
		/// </summary>
		protected struct Marker
		{
			public uint Point { get; set; }
			public string Name { get; set; }
		}

		/// <summary>
		/// Parses a string containing history data in Google chart format, and creates a history object.
		/// </summary>
		/// <param name="data">A string URI containing history data in Google chart format.</param>
		/// <returns>A history object</returns>
		public static AjaxHistory Parse(string data)
		{
			AjaxHistory history = new AjaxHistory(ChartType.Lc);
			history.ParseSeries(data);
			return history;
		}

		public static AjaxHistory Parse(string data, AjaxHistory sibling)
		{
			return null;
		}

		protected AjaxHistory(ChartType chartType)
		{
			this.chartType = chartType;
		}

		/// <summary>
		/// A series of history points.
		/// </summary>
		public AjaxHistoryPoint[] Series { get { return this.series; } }

		/// <summary>
		/// A set of markers.
		/// </summary>
		public AjaxHistoryMarker[] Markers { get { return this.markers; } }

		/// <summary>
		/// Returns the history point closest to the specified marker.
		/// </summary>
		/// <param name="marker">The marker.</param>
		/// <returns>The history point or <b>null</b>, if there are no points.</returns>
		public AjaxHistoryPoint? GetPointAt(AjaxHistoryMarker marker)
		{
			AjaxHistoryPoint? minPoint = null;
			TimeSpan minDuration = TimeSpan.MaxValue;
			TimeSpan duration;
			foreach (AjaxHistoryPoint point in this.series)
			{
				duration = (point.Time - marker.Time).Duration();
				if (duration < minDuration)
				{
					minDuration = duration;
					minPoint = point;
				}
			}
			return minPoint;
		}

		protected void ParseSeries(string data)
		{
			// Get all tokens from the query part
			string[] options = data.Substring(data.IndexOf('?')).Split(AjaxHistory.uriSplit, StringSplitOptions.RemoveEmptyEntries);
			string value;

			// Local variables
			DateTime[] parseLabels = null;
			double[] parseLabelPositions = null;
			Range[] parseRange = null;
			double[] parseData = null;
			Marker[] parseMarkers = null;
			
			// For each token in the query
			foreach (string option in options)
			{
				// Check for chart type
				if (Regex.IsMatch(option, AjaxHistory.regChartType, RegexOptions.IgnoreCase))
				{
					value = Regex.Replace(option, AjaxHistory.regChartType, string.Empty, RegexOptions.IgnoreCase).ToLower();
					switch (this.chartType)
					{
						case ChartType.Lc: if (!Regex.IsMatch(value, "^lc")) throw new AjaxException("Invalid series chart type \"{0}\".".FormatWith(value)); break;
						case ChartType.Ls: if (!Regex.IsMatch(value, "^ls")) throw new AjaxException("Invalid series chart type \"{0}\".".FormatWith(value)); break;
					}
					
				}
				// Check for chart axis labels
				if (Regex.IsMatch(option, AjaxHistory.regChartAxisLabels, RegexOptions.IgnoreCase))
				{
					value = Regex.Replace(option, AjaxHistory.regChartAxisLabels, string.Empty, RegexOptions.IgnoreCase);
					parseLabels = AjaxHistory.ParseLabels(value);
				}
				// Check for chart axis label positions
				if (Regex.IsMatch(option, AjaxHistory.regChartAxisLabelPositions, RegexOptions.IgnoreCase))
				{
					value = Regex.Replace(option, AjaxHistory.regChartAxisLabelPositions, string.Empty, RegexOptions.IgnoreCase);
					parseLabelPositions = AjaxHistory.ParseLabelPositions(value);
				}
				// Check for chart axis ranges
				if (Regex.IsMatch(option, AjaxHistory.regChartAxisRanges, RegexOptions.IgnoreCase))
				{
					value = Regex.Replace(option, AjaxHistory.regChartAxisRanges, string.Empty, RegexOptions.IgnoreCase);
					parseRange = AjaxHistory.ParseRange(value);
				}
				// Check for chart axis data
				if (Regex.IsMatch(option, AjaxHistory.regChartAxisData, RegexOptions.IgnoreCase))
				{
					value = Regex.Replace(option, AjaxHistory.regChartAxisData, string.Empty, RegexOptions.IgnoreCase);
					parseData = AjaxHistory.ParseData(value);
				}
				// Check for chart axis markers
				if (Regex.IsMatch(option, AjaxHistory.regChartAxisMarkers, RegexOptions.IgnoreCase))
				{
					value = Regex.Replace(option, AjaxHistory.regChartAxisMarkers, string.Empty, RegexOptions.IgnoreCase);
					parseMarkers = AjaxHistory.ParseMarkers(value);
				}
			}

			// Check variables
			if (null == parseLabels) throw new AjaxException("Cannot parse chart: axis labels not found while parsing a history series.");
			if (null == parseLabelPositions) throw new AjaxException("Cannot parse chart: axis label positions not found while parsing a history series.");
			if (null == parseRange) throw new AjaxException("Cannot parse chart: axis range not found while parsing a history series.");
			if (null == parseData) throw new AjaxException("Cannot parse chart: axis data not found while parsing a history series.");
			if (parseLabels.Length != parseLabelPositions.Length) throw new AjaxException("Cannot parse chart: axis labels and label positions must have the same length.");
			if (parseRange.Length != 2) throw new AjaxException("Cannot parse chart range: chart has range for {0} axes.".FormatWith(parseRange.Length));

			// Process history data
			this.series = new AjaxHistoryPoint[parseData.Length];

			for (uint index = 0; index < this.series.Length; index++)
			{
				this.series[index].Value = parseRange[0].Start + parseData[index] * (parseRange[0].End - parseRange[0].Start) / 100.0;
				this.series[index].Time = parseLabels[0] + TimeSpan.FromTicks(index * (parseLabels[parseLabels.Length - 1].Ticks - parseLabels[0].Ticks) / (this.Series.Length - 1));
			}

			// Process history markers
			this.markers = new AjaxHistoryMarker[parseMarkers.Length];

			for (uint index = 0; index < this.markers.Length; index++)
			{
				this.markers[index].Name = parseMarkers[index].Name;
				this.markers[index].Time = parseLabels[0] + TimeSpan.FromTicks(parseMarkers[index].Point * (parseLabels[parseLabels.Length - 1].Ticks - parseLabels[0].Ticks) / (this.Series.Length - 1));
			}
		}


		protected static DateTime[] ParseLabels(string value)
		{
			// Match the input value with the axis delimiters.
			MatchCollection matches = Regex.Matches(value, "^[0-9]:");
			
			if (!Regex.IsMatch(value, "^1:")) throw new AjaxException("Cannot parse chart axis labels: only the X axis should have labels.");
			if (matches.Count != 1) throw new AjaxException("Cannot parse chart axis labels: only the X axis should have labels, however {0} label sets were found.".FormatWith(matches.Count));

			// Get the labels
			string[] labelsString = value.Substring(matches[0].Length).Split(AjaxHistory.pipeSplit, StringSplitOptions.RemoveEmptyEntries);
			
			// Convert the labels into a date-time array
			DateTime[] labelsDate = new DateTime[labelsString.Length];
			for (uint index = 0; index < labelsString.Length; index++)
			{
				labelsDate[index] = DateTime.Parse(labelsString[index], AjaxRequestStatistics.culture);
			}

			return labelsDate;
		}

		protected static double[] ParseLabelPositions(string value)
		{
			// Divide the string into tokens
			string[] positionsString = value.Split(AjaxHistory.commaSplit, StringSplitOptions.RemoveEmptyEntries);

			// Convert the positions on a double array
			double[] positionDouble = new double[positionsString.Length - 1];
			for (uint index = 0; index < positionDouble.Length; index++)
			{
				positionDouble[index] = Double.Parse(positionsString[index + 1]);
			}

			return positionDouble;
		}

		protected static Range[] ParseRange(string value)
		{
			// Divide the string into tokens for each axis
			string[] rangeAxes = value.Split(AjaxHistory.pipeSplit, StringSplitOptions.RemoveEmptyEntries);


			// Allocate a new range array
			Range[] range = new Range[rangeAxes.Length];

			// For each axis range
			for (uint index = 0; index < rangeAxes.Length; index++)
			{
				// Split the string for each axis in values
				string[] rangeValues = rangeAxes[index].Split(AjaxHistory.commaSplit, StringSplitOptions.RemoveEmptyEntries);

				// The set of each range must have 3 or 4 values
				if ((rangeValues.Length != 3) && (rangeValues.Length != 4)) throw new AjaxException("Cannot parse chart axis range: range must have 3 or 4 values but it has {0}.".FormatWith(rangeValues.Length));

				// Check the axis index
				if (index != uint.Parse(rangeValues[0])) throw new AjaxException("Cannot parse chart axis range: axis index should be {0} but it is {1}.".FormatWith(index, rangeValues[0]));

				// Convert the range values to the Range type
				range[index].Start = double.Parse(rangeValues[1]);
				range[index].End = double.Parse(rangeValues[2]);
			}

			return range;
		}

		protected static double[] ParseData(string value)
		{
			// Match the input value with the axis data.
			MatchCollection matches = Regex.Matches(value, "^t:");

			if (matches.Count != 1) throw new AjaxException("Cannot parse chart axis data: the series type can only be \"t\".");
			if (Regex.IsMatch(value, @"\|")) throw new AjaxException("Cannot parse chart axis data: only one data series is allowed.");

			// Get the data
			string[] dataString = value.Substring(matches[0].Length).Split(AjaxHistory.commaSplit, StringSplitOptions.RemoveEmptyEntries);

			// Convert the data to numeric values
			double[] dataDouble = new double[dataString.Length];

			for (uint index = 0; index < dataString.Length; index++)
			{
				dataDouble[index] = double.Parse(dataString[index]);
			}

			return dataDouble;
		}

		protected static Marker[] ParseMarkers(string value)
		{
			// Divide the markers string
			string[] markersString = value.Split(AjaxHistory.pipeSplit, StringSplitOptions.RemoveEmptyEntries);

			List<Marker> markers = new List<Marker>();

			// For each marker
			foreach (string markerString in markersString)
			{
				// Only process the annotation (A) markers
				if (markerString[0] == 'A')
				{
					string[] valuesString = markerString.Split(AjaxHistory.commaSplit, StringSplitOptions.RemoveEmptyEntries);

					// Check that the marker has at least 4 values
					if (markerString.Length < 4) throw new AjaxException("Cannot parse chart axis marker: marker string {0} has only {1} values.".FormatWith(markerString, valuesString.Length));

					// Create a new marker object
					Marker marker = new Marker();
					marker.Name = valuesString[0].Substring(1);
					marker.Point = uint.Parse(valuesString[3]);
					markers.Add(marker);
				}
			}

			return markers.ToArray();
		}
	}

	[Serializable]
	public struct AjaxHistoryPoint
	{
		/// <summary>
		/// The time moment of the history point.
		/// </summary>
		public DateTime Time { get; set; }
		/// <summary>
		/// The data value of the history point.
		/// </summary>
		public double Value { get; set; }
	}

	[Serializable]
	public struct AjaxHistoryMarker
	{
		/// <summary>
		/// The time moment of the history marker.
		/// </summary>
		public DateTime Time { get; set; }
		/// <summary>
		/// The name of the history marker.
		/// </summary>
		public string Name { get; set; }
	}
}
