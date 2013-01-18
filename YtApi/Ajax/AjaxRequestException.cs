/* 
 * Copyright (C) 2012 Alex Bikfalvi
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
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace YtApi.Ajax
{
	public enum AjaxRequestExceptionType
	{
		[Description("Public statistics have been disabled.")]
		PublicStatisticsDisabled = 0,
		[Description("No statistics available yet.")]
		NotAvailableYet = 1
	}

	/// <summary>
	/// A class representing an AJAX request exception.
	/// </summary>
	[Serializable]
	public class AjaxRequestException : AjaxException, ISerializable
	{
		private AjaxRequestExceptionType type;
		
		/// <summary>
		/// Creates a new exception instance using the specified message.
		/// </summary>
		/// <param name="type">The exception type.</param>
		public AjaxRequestException(AjaxRequestExceptionType type)
			: base((Attribute.GetCustomAttribute(typeof(AjaxRequestExceptionType).GetField(Enum.GetName(typeof(AjaxRequestExceptionType), type)), typeof(DescriptionAttribute)) as DescriptionAttribute).Description)
		{
			this.type = type;
		}

		/// <summary>
		/// Creates a new AJAX request exception instance during the deserialization.
		/// </summary>
		/// <param name="info">The serialization info.</param>
		/// <param name="ctx">The streaming context.</param>
		protected AjaxRequestException(SerializationInfo info, StreamingContext ctx)
			: base(info, ctx)
		{
			this.type = (AjaxRequestExceptionType)info.GetValue("requestExceptionType", typeof(AjaxRequestExceptionType));
		}

		/// <summary>
		/// Returns the object data during serialization.
		/// </summary>
		/// <param name="info">The serialization info.</param>
		/// <param name="context">The streaming context.</param>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("requestExceptionType", this.type);
			base.GetObjectData(info, context);
		}

		/// <summary>
		/// Returns the type of the AJAX request exception.
		/// </summary>
		public AjaxRequestExceptionType Type { get { return this.type; } }
	}
}
