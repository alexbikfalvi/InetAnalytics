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

namespace InetCrawler.Tools
{
	/// <summary>
	/// A deleate for a tool method action.
	/// </summary>
	/// <param name="cancel">The cancellation token.</param>
	/// <param name="arguments">The method arguments.</param>
	/// <returns>The method result.</returns>
	public delegate object ToolMethodAction(CancellationToken cancel, object[] arguments);

	/// <summary>
	/// A class representing a tool method.
	/// </summary>
	public sealed class ToolMethod
	{
		private readonly Tool tool;
		private readonly ToolMethodId id;
		private readonly string name;
		private readonly string description;
		private readonly ToolMethodAction action;

		/// <summary>
		/// Createa a new tool method instance.
		/// </summary>
		/// <param name="tool">The tool.</param>
		/// <param name="id">The tool method identifier.</param>
		/// <param name="name">The method name.</param>
		/// <param name="description">The method description.</param>
		/// <param name="action">The action.</param>
		public ToolMethod(Tool tool, Guid id, string name, string description, ToolMethodAction action)
		{
			// Validate the arguments.
			if (null == tool) throw new ArgumentNullException("tool");
			if (null == action) throw new ArgumentNullException("action");

			this.tool = tool;
			this.id = new ToolMethodId(tool.Info.Id.Guid, tool.Info.Id.Version, id);
			this.name = name;
			this.description = description;
			this.action = action;
		}

		// Public properties.

		/// <summary>
		/// Gets the tool.
		/// </summary>
		public Tool Tool { get { return this.tool; } }
		/// <summary>
		/// Gets the tool method identifier.
		/// </summary>
		public ToolMethodId Id { get { return this.id; } }
		/// <summary>
		/// Gets the tool method name.
		/// </summary>
		public string Name { get { return this.name; } }
		/// <summary>
		/// Gets the tool method description.
		/// </summary>
		public string Description { get { return this.description; } }

		// Public methods.

		/// <summary>
		/// Runs a synchronous call for the tool method.
		/// </summary>
		/// <param name="arguments">The arguments.</param>
		/// <returns>The method result.</returns>
		public object Call(params object[] arguments)
		{
			// Call the method action without a cancellation token.
			return this.action(CancellationToken.None, arguments);
		}

		/// <summary>
		/// Begins an asynchronous call for the tool method.
		/// </summary>
		/// <param name="callback">The callback method for an asynchronoud request.</param>
		/// <param name="state">The user state.</param>
		/// <param name="arguments">The method arguments.</param>
		/// <returns>The tool method state.</returns>
		public ToolMethodState BeginCall(AsyncCallback callback, object state, params object[] arguments)
		{
			// Create a new tool method state.
			ToolMethodState asyncState = new ToolMethodState(state);

			// Execute the method asynchronously on the thread pool.
			ThreadPool.QueueUserWorkItem((object userState) =>
				{
					try
					{
						// Call the method handler with the state cancellation token.
						asyncState.Result = this.action(asyncState.CancellationToken, arguments);
					}
					catch (Exception exception)
					{
						// Set the exception.
						asyncState.Exception = exception;
					}
					finally
					{
						// Complete the operation.
						asyncState.Complete();
						// Call the callback method.
						if (null != callback) callback(asyncState);
						// Dispose of the asynchronous state.
						asyncState.Dispose();
					}
				});
			
			// Return the asynchronous result.
			return asyncState;
		}

		/// <summary>
		/// Ends an asynchronous call for the tool method.
		/// </summary>
		/// <param name="result">The asynchronous result.</param>
		/// <returns>The method result.</returns>
		public object EndCall(IAsyncResult result)
		{
			// Get the asynchronous state.
			ToolMethodState asyncState = result as ToolMethodState;
			
			// If the asynchronous operation has an exception.
			if (null != asyncState.Exception)
			{
				// Rethrow the exception.
				throw asyncState.Exception;
			}

			// Return the operation result.
			return asyncState.Result;
		}

		/// <summary>
		/// Cancels the specified asynchronous operation.
		/// </summary>
		/// <param name="result">The asynchronous result.</param>
		public void Cancel(IAsyncResult result)
		{
			// Get the asynchronous state.
			ToolMethodState asyncState = result as ToolMethodState;

			// Cancel the asynchronous operation.
			asyncState.Cancel();
		}
	}
}
