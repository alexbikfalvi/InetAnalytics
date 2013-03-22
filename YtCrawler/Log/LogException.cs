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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YtCrawler.Log
{
	/// <summary>
	/// A class representing a log exception.
	/// </summary>
	[Serializable]
	public class LogException : Exception
	{
		/// <summary>
		/// Creates a log exception with the specified message.
		/// </summary>
		/// <param name="message">The message.</param>
		public LogException(
			string message
			)
			: base(message)
		{
		}
		
		/// <summary>
		/// Creates a log exception with the specified message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="innerException">The inner exception.</param>
		public LogException(
			string message,
			Exception innerException
			)
			: base(message, innerException)
		{
		}
	}
}
