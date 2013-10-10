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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DotNetApi;

namespace YtCrawler.Log
{
	public enum LogEventType
	{
		[Description("Information")]
		Information = 0,
		[Description("Success")]
		Success = 1,
		[Description("Error")]
		Error = 2,
		[Description("Canceled")]
		Canceled = 3,
		[Description("Warning")]
		Warning = 4,
		[Description("Input validation")]
		Stop = 5,
		[Description("Success (warning)")]
		SuccessWarning = 6,
		[Description("Error (warning)")]
		ErrorWarning = 7
	}

	public enum LogEventLevel
	{
		[Description("Critcal")]
		Critical = 0,
		[Description("Important")]
		Important = 1,
		[Description("Normal")]
		Normal = 2,
		[Description("Verbose")]
		Verbose = 3
	};

	[Serializable]
	public class LogEvent
	{
		private LogEventLevel level;
		private LogEventType type;
		private DateTime timestamp;
		private string source;
		private string message;
		private object[] parameters;
		private Exception exception;
		private string exceptionSerializationExceptionType = null;
		private string exceptionSerializationExceptionMessage = null;
		private Exception exceptionDeserializationException = null;
		private LogEvent parent;
		private List<LogEvent> subevents;
		private int indent;

		/// <summary>
		/// Creates a new log event.
		/// </summary>
		/// <param name="level">The log event level.</param>
		/// <param name="type">The log event type.</param>
		/// <param name="timestamp">The event timestamp.</param>
		/// <param name="source">The even source.</param>
		/// <param name="message">The event message.</param>
		/// <param name="parameters">The event parameters.</param>
		/// <param name="exception">The event exception.</param>
		/// <param name="subevents">A list of subevents corresponding to this event.</param>
		public LogEvent(
			LogEventLevel level,
			LogEventType type,
			DateTime timestamp,
			string source,
			string message,
			object[] parameters = null,
			Exception exception = null,
			List<LogEvent> subevents = null
			)
		{
			this.level = level;
			this.type = type;
			this.timestamp = timestamp;
			this.source = source;
			this.message = message;
			this.parameters = parameters;
			this.exception = exception;
			this.subevents = subevents;
			this.parent = null;
			this.indent = (null != this.parent) ? this.parent.indent + 1 : 0;

			// If there are subevents, set their timestamp, level, and parent to this event.
			if (null != this.subevents)
			{
				foreach (LogEvent evt in this.subevents)
				{
					if((int)this.level > (int)evt.level) this.level = evt.level;
					evt.timestamp = this.timestamp;
					evt.parent = this;
				}
			}
		}

		/// <summary>
		/// Creates a new log event from an XML element.
		/// </summary>
		/// <param name="element">The XML element.</param>
		/// <param name="parent">The parent event.</param>
		public LogEvent(XElement element, LogEvent parent = null)
		{
			// Check the element name.
			if (element.Name != "event") throw new LogException("Cannot parse the XML element to create a new log event, the element name is \"{0}\".".FormatWith(element.Name));

			// Add the event data.
			try
			{
				this.level = (LogEventLevel) int.Parse(element.Attribute(XName.Get("level")).Value, CultureInfo.InvariantCulture);
				this.type = (LogEventType)int.Parse(element.Attribute(XName.Get("type")).Value, CultureInfo.InvariantCulture);
				this.timestamp = DateTime.Parse(element.Attribute(XName.Get("timestamp")).Value, CultureInfo.InvariantCulture);
				this.source = element.Element(XName.Get("source")).Value;
				this.message = element.Element(XName.Get("message")).Value;
				this.parent = parent;
				this.indent = (this.parent != null) ? this.parent.indent + 1 : 0;

				// Parameters.
				XElement parameters = element.Element(XName.Get("parameters"));
				if (null != parameters)
				{
					IEnumerable<XElement> parameter = parameters.Elements(XName.Get("parameter"));
					this.parameters = new object[parameter.Count()];
					for (int index = 0; index < parameter.Count(); index++)
						this.parameters[index] = parameter.ElementAt(index).Value;
				}
				else this.parameters = null;

				// Exception.
				XElement exception = element.Element(XName.Get("exception"));
				if (null != exception)
				{
					// Check if there exists a serialization exception attribute.
					XAttribute attr;
					if(null != (attr = exception.Attribute(XName.Get("serializationExceptionType"))))
						this.exceptionSerializationExceptionType = attr.Value;
					if(null != (attr = exception.Attribute(XName.Get("serializationExceptionMessage"))))
						this.exceptionSerializationExceptionMessage = attr.Value;

					// If the serialization was successfull.
					if(null == this.exceptionSerializationExceptionType)
					{
						// Try to deserialize the exception.
						try
						{
							// Create a new binary formatter and a memory stream.
							BinaryFormatter formatter = new BinaryFormatter();
							MemoryStream stream = new MemoryStream();
							// Read the base-64 string.
							byte[] bytes = Convert.FromBase64String(exception.Value);
							stream.Write(bytes, 0, bytes.Length);
							stream.Seek(0, SeekOrigin.Begin);
							// Deserialize the object.
							this.exception = formatter.Deserialize(stream) as Exception;
						}
						catch(Exception ex)
						{
							this.exceptionDeserializationException = ex;
						}
					}
				}
				else this.exception = null;

				// Sub-events.
				XElement subevents = element.Element(XName.Get("subevents"));
				if (null != subevents)
				{
					// Create the subevents array.
					this.subevents = new List<LogEvent>();
					// Add the sub-events.
					foreach (XElement child in subevents.Elements("event"))
					{
						this.subevents.Add(new LogEvent(child, this));
					}
				}
			}
			catch (Exception exception)
			{
				throw new LogException("Cannot parse the XML element to create a new log event; some data is missing or is malformed.", exception);
			}
		}

		/// <summary>
		/// Returns the log event level.
		/// </summary>
		public LogEventLevel Level { get { return this.level; } }
		/// <summary>
		/// Returns the log event type.
		/// </summary>
		public LogEventType Type { get { return this.type; } }
		/// <summary>
		/// Returns the log event timestamp.
		/// </summary>
		public DateTime Timestamp { get { return this.timestamp; } }
		/// <summary>
		/// Returns the source of the log event.
		/// </summary>
		public string Source { get { return this.source; } }
		/// <summary>
		/// Returns the log event message, with the parameters included.
		/// </summary>
		public string Message { get { return this.parameters != null ? this.message.FormatWith(this.parameters.ToExtendedString()) : this.message; } }
		/// <summary>
		/// Returns the raw log event message, without any parameters.
		/// </summary>
		public string MessageRaw { get { return this.message; } }
		/// <summary>
		/// Returns the log event parameters.
		/// </summary>
		public object[] Paremeters { get { return this.parameters; } }
		/// <summary>
		/// Returns the log event exception.
		/// </summary>
		public Exception Exception { get { return this.exception; } }
		/// <summary>
		/// Returns the type of the exception that occurred during the serialization of the event exception.
		/// </summary>
		public string ExceptionSerializationExceptionType { get { return this.exceptionSerializationExceptionType; } }
		/// <summary>
		/// Returns the message of the exception that occurred during the serialization of the event exception.
		/// </summary>
		public string ExceptionSerializationExceptionMessage { get { return this.exceptionSerializationExceptionMessage; } }
		/// <summary>
		/// Returns the exception that occurred during the deserialization of the event exception.
		/// </summary>
		public Exception ExceptionDeserializationException { get { return this.exceptionDeserializationException; } }
		/// <summary>
		/// Returns the list of sub-events.
		/// </summary>
		public ICollection<LogEvent> Subevents { get { return this.subevents; } }
		/// <summary>
		/// The parent event for this event.
		/// </summary>
		public LogEvent Parent { get { return this.parent; } }
		/// <summary>
		/// Gets the indent of the current event.
		/// </summary>
		public int Indent { get { return this.indent; } }
		/// <summary>
		/// Returns the current event as an XML element.
		/// </summary>
		public XElement Xml
		{
			get
			{
				XElement element = new XElement(
					XName.Get("event"),
					new XAttribute("level", ((int)this.Level).ToString(CultureInfo.InvariantCulture)),
					new XAttribute("type", ((int)this.Type).ToString(CultureInfo.InvariantCulture)),
					new XAttribute("timestamp", this.Timestamp.ToString(CultureInfo.InvariantCulture)),
					new XElement("source", this.Source),
					new XElement("message", this.MessageRaw));

				XElement parameters = null;
				XElement exception = null;
				XElement subevents = null;

				// Event parameters.
				if (this.Paremeters != null)
				{
					parameters = new XElement("parameters");
					foreach (object parameter in this.Paremeters)
						parameters.Add(new XElement("parameter", parameter));
					element.Add(parameters);
				}

				// Event exception.
				if (this.Exception != null)
				{
					// Create a new exception element.
					exception = new XElement("exception");
					// Create a new binary formatter and a memory stream.
					BinaryFormatter formatter = new BinaryFormatter();
					MemoryStream stream = new MemoryStream();
					try
					{
						// Serialize the exception object.
						formatter.Serialize(stream, this.Exception);
						// Add the serialized object as a base-64 string.
						exception.Value = Convert.ToBase64String(stream.ToArray());
					}
					catch (Exception ex)
					{
						// If an exception occurred during the serialization, add the exception type.
						exception.Add(new XAttribute("serializationExceptionType", ex.GetType().ToString()));
						exception.Add(new XAttribute("serializationExceptionMessage", ex.Message));
					}
					finally
					{
						element.Add(exception);
					}
				}

				// Sub-events.
				if (this.Subevents != null)
				{
					// Create a new subevents element.
					subevents = new XElement("subevents");
					// Add the XML for each sub-event to the element.
					foreach (LogEvent evt in this.Subevents)
					{
						subevents.Add(evt.Xml);
					}
					// Add the element.
					element.Add(subevents);
				}

				return element;
			}
		}
		/// <summary>
		/// Gets or sets a logger message.
		/// </summary>
		public string Logger { get; set; }
		/// <summary>
		/// Gets or sets a custom object tag.
		/// </summary>
		public object Tag { get; set; }

		/// <summary>
		/// Returns the description of a log event enumeration.
		/// </summary>
		/// <param name="value">The log event enumeration.</param>
		/// <returns>The display name.</returns>
		public static string GetDescription(Enum value)
		{
			Type type = value.GetType();
			string name = Enum.GetName(type, value);
			if (null != name)
			{
				FieldInfo field = type.GetField(name);
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
	}
}
