using System;
using System.Data;

namespace InetCrawler.Database
{
	/// <summary>
	/// A class representing a database name attribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class DbAttribute : Attribute
	{
		private DbType type;
		private string name;
		private bool nullable;

		/// <summary>
		/// Creates a new attribute instance.
		/// </summary>
		/// <param name="type">The database type.</param>
		/// <param name="nullable">Indicates if the field is nullable.</param>
		/// <param name="name">The name of the field in the database.</param>
		public DbAttribute(DbType type, bool nullable, string name = null)
		{
			this.name = name;
			this.type = type;
			this.nullable = nullable;
		}

		/// <summary>
		/// Gets the field name.
		/// </summary>
		public string Name { get { return this.name; } }
		/// <summary>
		/// Gets the database type.
		/// </summary>
		public DbType Type { get { return this.type; } }
		/// <summary>
		/// Indicates whether the field is nullable.
		/// </summary>
		public bool IsNullable { get { return this.nullable; } }
	}
}
