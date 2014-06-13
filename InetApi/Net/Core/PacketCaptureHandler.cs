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
using InetApi.Net.Core.Protocols;
using InetApi.Net.Core.Protocols.Filters;

namespace InetApi.Net.Core
{
    public delegate void PacketCaptureCallback(PacketCaptureHandler handler, byte[] buffer, int length, ProtoPacketIp ip);

    public delegate void PacketErrorCallback(PacketCaptureHandler handler, byte[] buffer, Exception exception);

    /// <summary>
    /// A filter for packet capture.
    /// </summary>
    public class PacketCaptureHandler : IDisposable
    {
        private readonly PacketCapture parent;
        private readonly FilterIp[] filters;
        private readonly PacketCaptureCallback success;
        private readonly PacketErrorCallback error;

        public PacketCaptureHandler(PacketCapture parent, FilterIp[] filters, PacketCaptureCallback success, PacketErrorCallback error)
        {
            this.parent = parent;
            this.filters = filters;
            this.success = success;
            this.error = error;

            this.parent.AddHandler(this);
        }

        /// <summary>
        /// Gets or sets the handler parent.
        /// </summary>
        public PacketCapture Parent { get { return this.parent; } }

        public void Dispose()
        {
            // Call the dispose event handler.
            this.Dispose(true);
            // Suppress the finalizer.
            GC.SuppressFinalize(this);
        }

        public bool Matches(ProtoPacketIp ip)
        {
            // Try and match the filters.
            bool match = false;
            for (int idx = 0; (idx < filters.Length) && (!match); idx++)
            {
                match = match || filters[idx].Matches(ip);
            }
            return match;
        }

        public bool Parse(byte[] buffer, ref int index, int length, out ProtoPacketIp ip)
        {
            return ProtoPacketIp.ParseFilter(buffer, ref index, length, this.filters, out ip);
        }

        public void Success(byte[] buffer, int length, ProtoPacketIp ip)
        {
            this.success(this, buffer, length, ip);
        }

        public void Error(byte[] buffer, Exception exception)
        {
            this.error(this, buffer, exception);
        }

        /// <summary>
        /// Disposes the current object.
        /// </summary>
        /// <param name="disposing">If <b>true</b>, clean both managed and native resources. If <b>false</b>, clean only native resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            // Dispose the current objects.
            if (disposing)
            {
                if (null != this.Parent)
                {
                    this.parent.RemoveHandler(this);
                }
            }
        }
    }
}
