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
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace InetApi.Net.Core
{
    /// <summary>
    /// A class representing a multipath traceroute result set.
    /// </summary>
    [Serializable]
    public sealed class MultipathTracerouteResultSet : IEnumerable<MultipathTracerouteResult>
    {
        private readonly List<MultipathTracerouteResult> results = new List<MultipathTracerouteResult>();

        /// <summary>
        /// Creates a new multipath traceroute result set instance.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <param name="settings">The settings.</param>
        public MultipathTracerouteResultSet(IPAddress source, string destination, MultipathTracerouteSettings settings)
        {
            this.Source = source;
            this.Destination = destination;
            this.Settings = settings;
        }

        #region Public properties

        /// <summary>
        /// The source address.
        /// </summary>
        public IPAddress Source { get; private set; }
        /// <summary>
        /// The destination.
        /// </summary>
        public string Destination { get; private set; }
        /// <summary>
        /// The multipath traceroute settings.
        /// </summary>
        public MultipathTracerouteSettings Settings { get; private set; }

        #endregion

        #region Public methods

        /// <summary>
        /// Adds a result to the result set.
        /// </summary>
        /// <param name="result">The result.</param>
        public void Add(MultipathTracerouteResult result)
        {
            this.results.Add(result);
        }

        /// <summary>
        /// Gets the enumerator for the current results.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<MultipathTracerouteResult> GetEnumerator()
        {
            return this.results.GetEnumerator();
        }

        /// <summary>
        /// Gets the enumerator for the current results.
        /// </summary>
        /// <returns>The enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }
}
