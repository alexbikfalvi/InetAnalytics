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
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace InetCrawler.PlanetLab
{
	/// <summary>
	/// A class representing the history of a PlanetLab manager run.
	/// </summary>
	[XmlRoot("PlanetLabRun")]
	public sealed class PlManagerHistoryRun : IDisposable
	{
		private readonly List<PlManagerHistoryNode> nodes = new List<PlManagerHistoryNode>();

		/// <summary>
		/// Creates an empty new manager history run instance.
		/// </summary>
		public PlManagerHistoryRun()
		{
		}

		/// <summary>
		/// Creates a new manager history run instance.
		/// </summary>
		/// <param name="state">The manager state.</param>
		public PlManagerHistoryRun(PlManagerState state)
		{
			// Validate the arguments.
			if (null == state) throw new ArgumentNullException("state");

			// Set the properties.
			this.Slice = state.Slice.Id;
			this.StartTime = state.StartTime;
			this.FinishTime = state.FinishTime;

			// Create the state nodes.
			this.nodes.AddRange(from nodeState in state.NodeStates select new PlManagerHistoryNode(nodeState));
		}

		// Public properties.

		/// <summary>
		/// Gets the slice identifier.
		/// </summary>
		[XmlAttribute("Slice")]
		public int Slice { get; private set; }
		/// <summary>
		/// Gets the start time.
		/// </summary>
		[XmlAttribute("StartTime")]
		public DateTime StartTime { get; private set; }
		/// <summary>
		/// Gets the finish time.
		/// </summary>
		[XmlAttribute("FinishTime")]
		public DateTime FinishTime { get; private set; }
		/// <summary>
		/// Gets the nodes history.
		/// </summary>
		[XmlArray("Nodes", IsNullable = true), XmlArrayItem("Node")]
		public List<PlManagerHistoryNode> Nodes { get { return this.nodes; } }

		// Public methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Creates a PlanetLab manager run history and saves it to a file.
		/// </summary>
		/// <param name="id">The history identifier.</param>
		/// <param name="state">The manager state.</param>
		public void Save(PlManagerHistoryId id, PlManagerState state)
		{
			// Create a new XML document.
			XDocument document = new XDocument();
		}
	}
}
