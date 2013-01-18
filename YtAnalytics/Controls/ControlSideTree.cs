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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YtAnalytics.Controls
{
	/// <summary>
	/// A tree control panel.
	/// </summary>
	public partial class ControlSideTree : ControlSide
	{
		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlSideTree()
		{
			InitializeComponent();
		}

		/// <summary>
		/// An event raised when the control selection has changed.
		/// </summary>
		public event ControlEventHandler ControlChanged;

		/// <summary>
		/// Gets or sets the tree view image list.
		/// </summary>
		public ImageList ImageList
		{
			get { return this.treeView.ImageList; }
			set { this.treeView.ImageList = value; }
		}

		/// <summary>
		/// Gets or sets the tree view selected node.
		/// </summary>
		public TreeNode SelectedNode
		{
			get { return this.treeView.SelectedNode; }
			set { this.treeView.SelectedNode = value; }
		}

		/// <summary>
		/// Adds a tree node to the tree view.
		/// </summary>
		/// <param name="treeNode">The tree node.</param>
		public void Add(TreeNode treeNode)
		{
			// Add the tree node.
			this.treeView.Nodes.Add(treeNode);
			// Expand all nodes.
			this.treeView.ExpandAll();
			// If this is the first node, select it.
			if (null == this.treeView.SelectedNode)
				this.treeView.SelectedNode = treeNode;
		}

		/// <summary>
		/// Adds a set of tree nodes to the tree view.
		/// </summary>
		/// <param name="treeNodes">The set of tree nodes.</param>
		public void AddRange(TreeNode[] treeNodes)
		{
			if (treeNodes.Length == 0) return;

			// Add the tree node.
			this.treeView.Nodes.AddRange(treeNodes);
			// Expand all nodes.
			this.treeView.ExpandAll();
			// If this is the first node, select it.
			if (null == this.treeView.SelectedNode)
				this.treeView.SelectedNode = treeNodes[0];
		}

		/// <summary>
		/// Shows the current control.
		/// </summary>
		public override void Show()
		{
			// Activate the tree view.
			this.treeView.Select();
			// Call the base class method.
			base.Show();
			// If the current list node tag is not null, get the control.
			if (this.treeView.SelectedNode != null)
			{
				Control control = this.treeView.SelectedNode.Tag as Control;
				// Raised a control changed event.
				if (null != this.ControlChanged)
					this.ControlChanged(this, new ControlEventArgs(control));
			}
		}

		/// <summary>
		/// An event handler called when the tree selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelect(object sender, TreeViewEventArgs e)
		{
			// If the current list node tag is not null, get the control.
			if (this.treeView.SelectedNode != null)
			{
				Control control = this.treeView.SelectedNode.Tag as Control;
				// Raised a control changed event.
				if (null != this.ControlChanged)
					this.ControlChanged(this, new ControlEventArgs(control));
			}
		}
	}
}
