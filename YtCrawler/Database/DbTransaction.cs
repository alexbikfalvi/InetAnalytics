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

namespace YtCrawler.Database
{
	/// <summary>
	/// A class representing a database transaction.
	/// </summary>
	public abstract class DbTransaction : IDisposable
	{
		/// <summary>
		/// Creates a new database transaction instance.
		/// </summary>
		public DbTransaction() { }

		/// <summary>
		/// Commits the current transaction.
		/// </summary>
		public abstract void Commit();

		/// <summary>
		/// Rolls back the current transaction.
		/// </summary>
		public abstract void Rollback();

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			this.OnDispose();
		}

		// Protected methods.

		/// <summary>
		/// An event handler called when the current object is disposed.
		/// </summary>
		protected abstract void OnDispose();
	}
}
