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
using System.Windows.Forms;
using DotNetApi.Windows.Controls;
using InetCommon.Tools;

namespace InetAnalytics.Controls.Tools
{
	/// <summary>
	/// A control that displays a tool.
	/// </summary>
	public partial class ControlToolInfoProperties : ThreadSafeControl
	{
		private Type tool = null;

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlToolInfoProperties()
		{
			InitializeComponent();
		}

		// Properties.

		/// <summary>
		/// Gets or sets the current tool.
		/// </summary>
		public Type Tool
		{
			get { return this.tool; }
			set
			{
				// Save the old value.
				Type old = this.tool;
				// Set the new tool.
				this.tool = value;
				// Call the event handler.
				this.OnToolSet(old, value);
			}
		}
		/// <summary>
		/// Gets the title.
		/// </summary>
		public string Title { get; private set; }


		// Protected methods.

		/// <summary>
		/// An event handler called when a new tool has been set.
		/// </summary>
		/// <param name="oldTool">The old tool.</param>
		/// <param name="newTool">The new tool.</param>
		protected virtual void OnToolSet(Type oldTool, Type newTool)
		{
			// Set the title to empty.
			this.Title = string.Empty;

			// If the tool has not changed, do nothing.
			if (oldTool == newTool) return;

			// The tool information.
			ToolInfoAttribute info = (null != newTool) ? InetCommon.Tools.Tool.GetToolInfo(newTool) : null;

			if (null == info)
			{
				this.labelTitle.Text = "No tool selected";
				this.tabControl.Visible = false;
			}
			else
			{
				this.labelTitle.Text = info.Name;
				this.textBoxName.Text = info.Name;
				this.textBoxId.Text = info.Id.Guid.ToString();
				this.textBoxVersion.Text = info.Id.Version.ToString();
				this.textBoxDescription.Text = info.Description;
				this.Title = info.Name;
				this.tabControl.Visible = true;
			}

			this.tabControl.SelectedTab = this.tabPageGeneral;
			if (this.Focused)
			{
				this.textBoxName.Select();
				this.textBoxName.SelectionStart = 0;
				this.textBoxName.SelectionLength = 0;
			}
		}
	}
}
