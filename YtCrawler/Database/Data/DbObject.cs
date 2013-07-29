/* 
 * Copyright (C) 2012-2013 Alex Bikfalvi
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
using System.Reflection;
using System.Xml.Serialization;
using DotNetApi.Windows;

namespace YtCrawler.Database.Data
{
	/// <summary>
	/// The root class for a database object.
	/// </summary>
	[Serializable]
	public abstract class DbObject
	{
		public DbObject() { }

		/// <summary>
		/// Returns the name of the current object.
		/// </summary>
		public abstract string GetName();

		/// <summary>
		/// Returns the value of the specified property.
		/// </summary>
		/// <param name="property">The property name.</param>
		/// <returns>The property value.</returns>
		public object GetValue(string property)
		{
			return this.GetType().GetProperty(property).GetValue(this, null);
		}

		/// <summary>
		/// Create a database object from the specified XML file.
		/// </summary>
		/// <typeparam name="T">The object type.</typeparam>
		/// <param name="fileName">The file name.</param>
		/// <returns>The database objects.</returns>
		public static T CreateFromXml<T>(string fileName) where T : DbObject, new()
		{
			try
			{
				// Open the specified file.
				using (FileStream stream = new FileStream(fileName, FileMode.Open))
				{
					// Create a new XML serializer.
					XmlSerializer serializer = new XmlSerializer(typeof(T));
					// Deserialize the file to the object.
					return serializer.Deserialize(stream) as T;
				}
			}
			catch(Exception exception)
			{
				throw new DbException(string.Format("Cannot create a database object of type \'{0}\' from the XML file \'{1}\'.", typeof(T), fileName), exception);
			}
		}

		/// <summary>
		/// Saves the contents of the specified object to the specified XML file.
		/// </summary>
		/// <typeparam name="T">The database object type.</typeparam>
		/// <param name="obj">The object to save.</param>
		/// <param name="fileName">The file name.</param>
		public static void SaveToXml<T>(T obj, string fileName) where T : DbObject, new()
		{
			try
			{
				// Open the specified file.
				using (FileStream stream = new FileStream(fileName, FileMode.CreateNew))
				{
					// Create a new XML serializer.
					XmlSerializer serializer = new XmlSerializer(typeof(T));
					// Serialize the current object to the file.
					serializer.Serialize(stream, obj);
				}
			}
			catch (Exception exception)
			{
				throw new DbException(string.Format("Cannot save the database object of type \'{0}\' to the XML file \'{1}\'.", typeof(T), fileName), exception);
			}
		}

		/// <summary>
		/// Creates a database object from the registry.
		/// </summary>
		/// <typeparam name="T">The database object type.</typeparam>
		/// <param name="key">The registry key.</param>
		/// <param name="value">The registry value.</param>
		/// <returns>The database object.</returns>
		public static T CreateFromRegistry<T>(string key, string value) where T : DbObject, new()
		{
			try
			{
				// Read the data from the registry to a buffer.
				byte[] buffer = Registry.GetBytes(key, value, null);
				// If the buffer is null, return null.
				if (null == buffer) return null;
				// Create a memory stream from where to deserialize the object.
				using (MemoryStream stream = new MemoryStream(buffer))
				{
					// Create a new XML serializer.
					XmlSerializer serializer = new XmlSerializer(typeof(T));
					// Deserialize the file to the object.
					return serializer.Deserialize(stream) as T;
				}
			}
			catch (Exception exception)
			{
				throw new DbException(string.Format("Cannot create a database object of type \'{0}\' from the registry key \'{1}\' value \'{2}\'.", typeof(T), key, value), exception);
			}
		}

		/// <summary>
		/// Saves the contents of the specified database object to the registry.
		/// </summary>
		/// <typeparam name="T">The database object type.</typeparam>
		/// <param name="obj">The object to save.</param>
		/// <param name="key">The registry key.</param>
		/// <param name="value">The registry value.</param>
		public static void SaveToRegistry<T>(T obj, string key, string value) where T : DbObject, new()
		{
			try
			{
				// Create a new memory stream.
				using (MemoryStream stream = new MemoryStream())
				{
					// Create a new XML serializer.
					XmlSerializer serializer = new XmlSerializer(typeof(T));
					// Serialize the current object to the file.
					serializer.Serialize(stream, obj);
					// Write the stream buffer to the registry.
					Registry.SetBytes(key, value, stream.ToArray());
				}
			}
			catch (Exception exception)
			{
				throw new DbException(string.Format("Cannot save the database object of type \'{0}\' to the registry key \'{1}\' value \'{2}\'.", typeof(T), key, value), exception);
			}
		}
	}
}
