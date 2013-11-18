/* 
 * Copyright (C) 2013 Alex Bikfalvi
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
using DotNetApi.Windows.Controls;

namespace InetCrawler.Tools
{
	/// <summary>
	/// The base class for an analytics tool.
	/// </summary>
	public abstract class Tool : IDisposable
	{
		/// <summary>
		/// Creates a new tool instance.
		/// </summary>
		/// <param name="productId">The product identifier.</param>
		/// <param name="productName">The product name.</param>
		/// <param name="vendorName">The vendor name.</param>
		public Tool(Guid productId, string productName, string vendorName)
		{
			this.ProductId = productId;
			this.ProductName = productName;
			this.VendorName = vendorName;
		}

		/// <summary>
		/// The product identifier.
		/// </summary>
		public Guid ProductId { get; private set; }
		/// <summary>
		/// The product name.
		/// </summary>
		public string ProductName { get; private set; }
		/// <summary>
		/// The vendor name.
		/// </summary>
		public string VendorName { get; private set; }

		/// <summary>
		/// Gets the user interface control for this tool.
		/// </summary>
		public abstract ThemeControl Control { get; }

		// Public methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Call the dispose method.
			this.Dispose(true);
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		// Protected methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		/// <param name="disposing">If <b>true</b>, clean both managed and native resources. If <b>false</b>, clean only native resources.</param>
		protected virtual void Dispose(bool disposing)
		{
		}
	}
}
