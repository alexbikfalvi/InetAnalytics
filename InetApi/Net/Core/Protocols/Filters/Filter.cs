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

namespace InetApi.Net.Core.Protocols.Filters
{
    /// <summary>
    /// The base class for a protocol filter.
    /// </summary>
    public abstract class Filter
    {
        public enum FilterType
        {
            Ip = 0,
            Icmp = 1,
            Udp = 2
        }

        /// <summary>
        /// Creates a new filter instance.
        /// </summary>
        /// <param name="type">The filter type.</param>
        public Filter(FilterType type)
        {
            this.Type = type;
        }

        #region Public properties

        /// <summary>
        /// Gets the filter type.
        /// </summary>
        public FilterType Type { get; private set; }

        #endregion

        #region Public methods

        /// <summary>
        /// Verifies if the filter matches the specified packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <returns><b>True</b> if the packet matches the filter, <b>false</b> otherwise.</returns>
        public abstract bool Matches(ProtoPacket packet);

        #endregion
    }
}
