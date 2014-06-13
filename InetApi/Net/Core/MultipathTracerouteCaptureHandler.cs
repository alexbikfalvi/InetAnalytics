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

namespace InetApi.Net.Core
{
    /// <summary>
    /// The multipath traceroute packet capture handler.
    /// </summary>
    public sealed class MultipathTracerouteCaptureHandler : PacketCaptureHandler
    {
        public MultipathTracerouteCaptureHandler(PacketCapture parent, MultipathTracerouteResult result, PacketCaptureCallback success, PacketErrorCallback error)
            : base(parent, result.PacketFilters, success, error)
        {
            this.Result = result;
        }

        public MultipathTracerouteResult Result { get; private set; }
    }
}
