﻿/* 
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
using System.IO;
using DotNetApi.Concurrent.Generic;
using DotNetApi.Xml;
using PlanetLab.Api;

namespace InetCrawler.PlanetLab
{
	/// <summary>
	/// A class representing the execution history of the PlanetLab manager.
	/// </summary>
	public sealed class PlManagerHistory : IDisposable
	{
		private ConcurrentList<PlManagerHistoryId> runs = new ConcurrentList<PlManagerHistoryId>();

		/// <summary>
		/// Creates a new PlanetLab manager history instance for the specified folder.
		/// </summary>
		/// <param name="slice">The PlanetLab slice.</param>
		public PlManagerHistory(PlSlice slice)
		{
			// Validate the arguments.
			if (null == slice) throw new ArgumentNullException("slice");
		}

		// Public methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			//// Save all history runs.
			//this.runs.Lock();
			//try
			//{
			//	foreach (PlManagerHistoryRun run in this.runs)
			//	{
			//		run.Dispose();
			//	}
			//}
			//finally
			//{
			//	this.runs.Unlock();
			//}
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Adds a new manager state to the the manager history.
		/// </summary>
		/// <param name="state">The manager state.</param>
		public void Add(PlManagerState state)
		{
			// Create a new run identifier for the specified state.
			PlManagerHistoryId id = new PlManagerHistoryId(state.Slice.Id, state.StartTime, state.FinishTime);

			// Save the history to the file.
			PlManagerHistoryRun run = new PlManagerHistoryRun(state);

			// Ensure the file directory exists.
			if (DotNetApi.IO.Directory.EnsureFileDirectoryExists(id.FileName))
			{
				// Create the new file.
				using (FileStream file = new FileStream(id.FileName, FileMode.Create))
				{
					run.Serialize(file);
				}
			}

			// Add the history to the list.
			this.runs.Add(id);
		}
	}
}
