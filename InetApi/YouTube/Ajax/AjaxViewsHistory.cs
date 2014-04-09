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
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using DotNetApi;
using InetCommon.Web;

namespace InetApi.YouTube.Ajax
{
	/// <summary>
	/// A class representing the views count history of a video.
	/// </summary>
	[Serializable]
	public class AjaxViewsHistory : AjaxHistory
	{
		private readonly Dictionary<string, AjaxViewsHistoryDiscoveryEvent> events = new Dictionary<string, AjaxViewsHistoryDiscoveryEvent>();
		private readonly List<AjaxException> exceptions = new List<AjaxException>();

		/// <summary>
		/// Parses a string containing history data in Google chart format, and creates a history object.
		/// </summary>
		/// <param name="data">A string containing history data in Google chart format.</param>
		/// <returns>A history object</returns>
		public static new AjaxViewsHistory Parse(string data)
		{
			AjaxViewsHistory history = new AjaxViewsHistory(ChartType.Lc);
			history.ParseSeries(data);
			return history;
		}

		/// <summary>
		/// Protected constructor.
		/// </summary>
		/// <param name="chartType">The chart type.</param>
		protected AjaxViewsHistory(ChartType chartType)
			: base(chartType)
		{
		}

		/// <summary>
		/// Returns the list of discovery events.
		/// </summary>
		public ICollection<KeyValuePair<string, AjaxViewsHistoryDiscoveryEvent>> DiscoveryEvents { get { return this.events; } }

		/// <summary>
		/// Returns the list of discovery exceptions.
		/// </summary>
		public ICollection<AjaxException> DiscoveryExceptions { get { return this.exceptions; } }

		/// <summary>
		/// Adds a new views history discovery event.
		/// </summary>
		/// <param name="evt">The discovery event.</param>
		public void AddViewsDiscoveryEvent(AjaxViewsHistoryDiscoveryEvent evt)
		{
			// Check if the history already contains the event name.
			if (this.events.ContainsKey(evt.Name)) throw new AjaxException("Cannot add a new discovery event: an event with the name \"{0}\" already exists.".FormatWith(evt.Name));

			// Set the event marker.
			evt.Marker = this.Markers.First(marker => marker.Name == evt.Name);

			// Check that the marker is not null.
			if (evt.Marker == null) throw new AjaxException("Cannot add a new discovery event: the event with the name \"{0}\" does not have an associated marker.".FormatWith(evt.Name));

			// Add the event.
			this.events.Add(evt.Name, evt);
		}

		/// <summary>
		/// Adds a new views history discovery exception.
		/// </summary>
		/// <param name="exception"></param>
		public void AddViewsDiscoveryEventException(AjaxException exception)
		{
			// Add the exception.
			this.exceptions.Add(exception);
		}
	}

	/// <summary>
	/// An enumeation representing the views history discovery type.
	/// </summary>
	public enum AjaxViewsHistoryDiscoveryType
	{
		[Description("Undefined")]
		Undefined,
		[Description("First referral from YouTube")]
		FirstReferralFromYouTube,
		[Description("First referral from a YouTube search")]
		FirstReferralFromYouTubeSearch,
		[Description("First referral from a related video")]
		FirstReferralFromRelatedVideo,
		[Description("First referral from a subscriber module")]
		FirstReferralFromSubscriberModule,
		[Description("First view from a mobile device")]
		FirstViewFromMobileDevice
	}

	/// <summary>
	/// A class representing the views history discovery events.
	/// </summary>
	[Serializable]
	public class AjaxViewsHistoryDiscoveryEvent
	{
		private static char[] uriSplit = { '&', '?' };

		private string name;
		private AjaxViewsHistoryDiscoveryType type;
		private string extra = null;

		protected AjaxViewsHistoryDiscoveryEvent(
			string name,
			AjaxViewsHistoryDiscoveryType type
			)
		{
			this.name = name;
			this.type = type;
		}

		protected AjaxViewsHistoryDiscoveryEvent(
			string name,
			AjaxViewsHistoryDiscoveryType type,
			string extra
			)
		{
			this.name = name;
			this.type = type;
			this.extra = extra;
		}

		/// <summary>
		/// Creates a discovery event based on a text description.
		/// </summary>
		/// <param name="name">Event name.</param>
		/// <param name="description">Event description.</param>
		/// <returns>A views history discovery event.</returns>
		public static AjaxViewsHistoryDiscoveryEvent Create(string name, string description)
		{
			if (Regex.IsMatch(description.ToLower(), "first.+referral.+subscriber.+module"))
				return new AjaxViewsHistoryDiscoveryEvent(name, AjaxViewsHistoryDiscoveryType.FirstReferralFromSubscriberModule);
			if (Regex.IsMatch(description.ToLower(), "first.+view.+mobile.+device"))
				return new AjaxViewsHistoryDiscoveryEvent(name, AjaxViewsHistoryDiscoveryType.FirstViewFromMobileDevice);
			throw new AjaxException("Cannot create a views history discovery event: unknown description \"{0}\".".FormatWith(description));
		}

		/// <summary>
		/// Creates a discovery event based on a text description and extra XML element.
		/// </summary>
		/// <param name="name">Event name.</param>
		/// <param name="description">Event description.</param>
		/// <param name="extra">An XML SPAN element with extra information.</param>
		/// <returns>A views history discovery event.</returns>
		public static AjaxViewsHistoryDiscoveryEvent Create(string name, string description, XElement extra)
		{
			if (Regex.IsMatch(description.ToLower(), "first.+referral.+youtube:"))
				return new AjaxViewsHistoryDiscoveryEvent(name, AjaxViewsHistoryDiscoveryType.FirstReferralFromYouTube, extra.Elements().Count<XElement>() > 0 ? extra.Element(XName.Get("a")).Attribute(XName.Get("href")).Value : extra.Value);
			if (Regex.IsMatch(description.ToLower(), "first.+referral.+youtube.+search:"))
				return new AjaxViewsHistoryDiscoveryEvent(name, AjaxViewsHistoryDiscoveryType.FirstReferralFromYouTubeSearch, extra.Element(XName.Get("a")).Attribute(XName.Get("href")).Value);
			if (Regex.IsMatch(description.ToLower(), "first.+referral.+related.+video:"))
				return new AjaxViewsHistoryDiscoveryEvent(name, AjaxViewsHistoryDiscoveryType.FirstReferralFromRelatedVideo, extra.Element(XName.Get("a")).Attribute(XName.Get("href")).Value);
			throw new AjaxException("Cannot create a views history discovery event: unknown description \"{0}\".".FormatWith(description));
		}

		/// <summary>
		/// The name of the views history discovery event.
		/// </summary>
		public string Name { get { return this.name; } }

		/// <summary>
		/// The type of the views history discovery event.
		/// </summary>
		public AjaxViewsHistoryDiscoveryType Type { get { return this.type; } }

		/// <summary>
		/// The marker for the views history discovery event.
		/// </summary>
		public AjaxHistoryMarker? Marker { get; set; }

		/// <summary>
		/// The extra information, if any, corresponding to the views history discovery event.
		/// </summary>
		public string Extra { get { return this.extra; } }

		/// <summary>
		/// Returns the description of a discovery type.
		/// </summary>
		/// <param name="value">The discovery type.</param>
		/// <returns>The display name.</returns>
		public static string GetTypeDescription(AjaxViewsHistoryDiscoveryType value)
		{
			string name = Enum.GetName(typeof(AjaxViewsHistoryDiscoveryType), value);
			if (null != name)
			{
				FieldInfo field = typeof(AjaxViewsHistoryDiscoveryType).GetField(name);
				if (null != field)
				{
					DescriptionAttribute attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
					if (null != attr)
					{
						return attr.Description;
					}
				}
			}
			return null;
		}

		/*
						// Get the ID of the related video.
						string href = null;
						string id = null;
						try { href = extra.Element(XName.Get("a")).Attribute(XName.Get("href")).Value; }
						catch { throw new AjaxException(string.Format("Cannot create a views history discoveery event with description \"{0}\" because it does not have a link to the related video.", description)); }

						// Parse the HREF string to get only the URI options.
						string[] options = href.Substring(href.IndexOf('?')).Split(AjaxViewsHistoryDiscoveryEvent.uriSplit, StringSplitOptions.RemoveEmptyEntries);

						// For all options.
						foreach (string option in options)
						{
							// If the option is the video ID, get the video ID.
							if (Regex.IsMatch(option, "^v=")) id = option.Substring(option.IndexOf('='));
						}
 
		 */
	}
}
