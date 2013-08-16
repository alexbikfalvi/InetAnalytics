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
using Microsoft.Win32;
using DotNetApi;

namespace YtCrawler.Testing
{
	/// <summary>
	/// A class that represents the crawler testing parameters.
	/// </summary>
	public sealed class Testing
	{
		private TestingWebRequest testingWebRequest;

		/// <summary>
		/// Creates a new testing instance.
		/// </summary>
		/// <param name="rootKey">The root registry key.</param>
		/// <param name="rootPath">The root registry path.</param>
		public Testing(RegistryKey rootKey, string rootPath)
		{
			this.testingWebRequest = new TestingWebRequest("{0}\\{1}\\Testing\\WebRequest".FormatWith(rootKey.Name, rootPath));
		}

		// Public properties.

		/// <summary>
		/// Gets the testing web request configuration.
		/// </summary>
		public TestingWebRequest WebRequest { get { return this.testingWebRequest; } }
	}
}
