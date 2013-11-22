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
using System.Windows.Forms;
using DotNetApi.Windows.Controls;
using InetCrawler.Tools;

namespace InetAnalytics.Controls.Tools
{
	/// <summary>
	/// A control that displays a tool.
	/// </summary>
	public partial class ControlToolProperties : ThreadSafeControl
	{
		private Tool tool = null;

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlToolProperties()
		{
			InitializeComponent();
		}

		// Properties.

		/// <summary>
		/// Gets or sets the current tool.
		/// </summary>
		public Tool Tool
		{
			get { return this.tool; }
			set
			{
				// Save the old value.
				Tool old = this.tool;
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
		protected virtual void OnToolSet(Tool oldTool, Tool newTool)
		{
			// Set the title to empty.
			this.Title = string.Empty;

			// If the tool has not changed, do nothing.
			if (oldTool == newTool) return;

			if (null == newTool)
			{
				this.labelTitle.Text = "No tool selected";
				this.tabControl.Visible = false;
			}
			else
			{
				this.labelTitle.Text = newTool.Info.Name;
				this.textBoxName.Text = newTool.Info.Name;
				this.textBoxId.Text = newTool.Info.Id.Guid.ToString();
				this.textBoxVersion.Text = newTool.Info.Id.Version.ToString();
				this.textBoxDescription.Text = newTool.Info.Description;

				this.textBoxToolsetName.Text = newTool.Toolset.Name;
				this.textBoxToolsetId.Text = newTool.Toolset.Id.Guid.ToString();
				this.textBoxToolsetVersion.Text = newTool.Toolset.Id.Version.ToString();
				this.textBoxToolsetProduct.Text = newTool.Toolset.Product;
				this.textBoxToolsetAuthor.Text = newTool.Toolset.Author;
				this.textBoxToolsetDescription.Text = newTool.Toolset.Description;

				this.Title = newTool.Info.Name;

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
