/* 
 * Copyright (C) 2014 Alex Bikfalvi
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

namespace InetCommon
{
	/// <summary>
	/// A class with the static application configuration.
	/// </summary>
	public static class ApplicationConfig
	{
		#region Configuration properties

		/// <summary>
		/// The delay in closing a notification message.
		/// </summary>
		public static TimeSpan MessageCloseDelay { get; set; }
		/// <summary>
		/// The cryptographic key for securing application data.
		/// </summary>
		public static byte[] CryptoKey { get; set; }
		/// <summary>
		/// The cryptographic initialization vector for securing application data.
		/// </summary>
		public static byte[] CryptoIV { get; set; }

		#endregion
	}
}
