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
using System.Threading;
using DotNetApi.Async;
using DotNetApi.Web;

namespace InetTools.Tools.Alexa
{
	/// <summary>
	/// A class representing the Alexa request state.
	/// </summary>
	public abstract class AlexaRequestState : AsyncResult
	{
		private object sync = new object();
		private IAsyncResult result = null;

		/// <summary>
		/// Creates a new Alexa request state instance.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="state">The user state.</param>
		public AlexaRequestState(AsyncCallback callback, object state)
			: base(state)
		{
			this.Callback = callback;
			this.Exception = null;
		}

		// Public properties.

		/// <summary>
		/// Gets the request callback method.
		/// </summary>
		public AsyncCallback Callback { get; private set; }
		/// <summary>
		/// Gets or sets the request state exception.
		/// </summary>
		public Exception Exception { get; internal set; }
		/// <summary>
		/// Gets or sets the result of the asynchronous request.
		/// </summary>
		public IAsyncResult Result
		{
			get { lock (this.sync) { return this.result; } }
			internal set { lock (this.sync) { this.result = value; } }
		}
	}
}
