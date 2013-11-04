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
using System.Runtime.Serialization;

namespace InetApi.YouTube.Api.V2
{
	/// <summary>
	/// Represents an exception that occurs while parsing YouTube data.
	/// </summary>
	[Serializable]
	public class YouTubeException : Exception
	{
		/// <summary>
		/// Creates an exception object using a message.
		/// </summary>
		/// <param name="message">The message.</param>
		public YouTubeException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Craetes an exception object using a message and an inner exception.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="innerException">The inner exception.</param>
		public YouTubeException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		/// Creates a new exception instance from the serialization context.
		/// </summary>
		/// <param name="info">The serialization info.</param>
		/// <param name="context">The serialization context.</param>
		protected YouTubeException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
