using System;

namespace InetApi.Net.Core.Protocols
{
	/// <summary>
	/// A class representing a protocol exception.
	/// </summary>
	public class ProtoException : FormatException
	{
		/// <summary>
		/// Creates a new protocol exception instance.
		/// </summary>
		/// <param name="message">The message.</param>
		public ProtoException(string message)
			: base(message)
		{
		}
	}
}
