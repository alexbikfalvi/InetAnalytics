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
using System.Drawing;
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Web.XmlRpc;
using PlanetLab.Api;

namespace InetAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A class representing a properties PlanetLab control.
	/// </summary>
	public class ControlObjectProperties : ControlRequest
	{
		protected static string notAvailable = "(not available)";

		private Label labelTitle;
		private Label labelMessage;
		private PictureBox pictureBox;
		private PlObject obj;

		private Image[] images = {
									 Resources.GlobeSuccess_32,
									 Resources.GlobeWarning_32,
									 Resources.GlobeError_32,
									 Resources.GlobeClock_32
								 };

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlObjectProperties()
		{
			// Initialize the component.
			this.InitializeComponent();
		}

		// Public events.

		/// <summary>
		/// An event raised when the current object has changed.
		/// </summary>
		public event EventHandler ObjectChanged;

		// Public properties.

		/// <summary>
		/// Gets or sets the current PlanetLab object.
		/// </summary>
		public PlObject Object
		{
			get { return this.obj; }
			set
			{
				// Set the object.
				this.obj = value;
				// Call the event handler.
				this.OnObjectSet(value);
				// Raise the event.
				if (null != this.ObjectChanged) this.ObjectChanged(this, EventArgs.Empty);
			}
		}

		// Protected properties.

		/// <summary>
		/// Gets or sets the control icon image.
		/// </summary>
		protected Image Icon
		{
			get { return this.pictureBox.Image; }
			set { this.pictureBox.Image = value; }
		}
		/// <summary>
		/// Gets or sets the control title text.
		/// </summary>
		protected string Title
		{
			get { return this.labelTitle.Text; }
			set { this.labelTitle.Text = value; }
		}
		/// <summary>
		/// Gets or sets the control message text.
		/// </summary>
		protected string Message
		{
			get { return this.labelMessage.Text; }
			set { this.labelMessage.Text = value; }
		}

		// Public methods.

		/// <summary>
		/// Updates the control using the object with the specified identifies
		/// </summary>
		/// <param name="id">The object identifier.</param>
		public void Update(int id)
		{
			// Call the event handler.
			this.OnUpdate(id);
		}

		// Protected methods.

		/// <summary>
		/// An event handler called when the current request begins, and the notification box is shown.
		/// </summary>
		/// <param name="state">The request state.</param>
		protected override void OnRequestStarted(RequestState state)
		{
			// Update the status.
			this.pictureBox.Image = Resources.GlobeClock_32;
			this.labelMessage.Text = "Updating the PlanetLab information ...";
		}

		/// <summary>
		/// An event handler called when the control completes an asynchronous request for a PlanetLab resource.
		/// </summary>
		/// <param name="response">The XML-RPC response.</param>
		/// <param name="state">The request state.</param>
		protected override void OnRequestResult(XmlRpcResponse response, RequestState state)
		{
			// If the response fault component is not null.
			if (response.Fault != null)
			{
				// Update the status.
				this.pictureBox.Image = Resources.GlobeWarning_32;
				this.labelMessage.Text = "Refreshing the PlanetLab information has failed.{0}{1}RPC code: {2}{3}{4}{5})".FormatWith(
					Environment.NewLine,
					Environment.NewLine,
					response.Fault.FaultCode,
					Environment.NewLine,
					Environment.NewLine,
					response.Fault.FaultString);
			}
			else if (response.Value == null)
			{
				// Update the status.
				this.labelMessage.Text = "The requested PlanetLab information is not available.";
			}
		}

		/// <summary>
		/// An event handler called when an asynchronous request for a PlanetLab resource was canceled.
		/// </summary>
		/// <param name="state">The request state.</param>
		protected override void OnRequestCanceled(RequestState state)
		{
			// Update the status.
			this.pictureBox.Image = Resources.GlobeCanceled_32;
			this.labelMessage.Text = "Updating the PlanetLab information canceled.";
		}

		/// <summary>
		/// An event handler called when the current request throws an exception.
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <param name="state">The request state.</param>
		protected override void OnRequestException(Exception exception, RequestState state)
		{
			// Update the status.
			this.pictureBox.Image = Resources.GlobeError_32;
			this.labelMessage.Text = "Updating the PlanetLab information failed. {0}{1}{2}".FormatWith(
				Environment.NewLine,
				Environment.NewLine,
				exception.Message);
		}

		/// <summary>
		/// An event handler called when the current request finishes, and the notification box is hidden.
		/// </summary>
		/// <param name="state">The request state.</param>
		protected override void OnRequestFinished(RequestState state)
		{
		}

		/// <summary>
		/// An event handler called when a new PlanetLab object is set.
		/// </summary>
		/// <param name="obj">The PlanetLab object.</param>
		protected virtual void OnObjectSet(PlObject obj)
		{
		}

		/// <summary>
		/// An event handler called when updating the control with a PlanetLab object of the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		protected virtual void OnUpdate(int id)
		{
		}

		// Private methods.

		/// <summary>
		/// Initializes the control components.
		/// </summary>
		private void InitializeComponent()
		{
			this.labelTitle = new System.Windows.Forms.Label();
			this.labelMessage = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Location = new System.Drawing.Point(59, 29);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(96, 13);
			this.labelTitle.TabIndex = 1;
			this.labelTitle.Text = "No object selected";
			this.labelTitle.UseMnemonic = false;
			// 
			// labelMessage
			// 
			this.labelMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.labelMessage.AutoEllipsis = true;
			this.labelMessage.Location = new System.Drawing.Point(10, 62);
			this.labelMessage.Name = "labelMessage";
			this.labelMessage.Size = new System.Drawing.Size(330, 328);
			this.labelMessage.TabIndex = 2;
			this.labelMessage.Text = "No error";
			this.labelMessage.UseMnemonic = false;
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::InetAnalytics.Resources.Globe_32;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(32, 32);
			this.pictureBox.TabIndex = 3;
			this.pictureBox.TabStop = false;
			// 
			// ControlPlanetLab
			// 
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.labelMessage);
			this.Controls.Add(this.pictureBox);
			this.Name = "ControlPlanetLab";
			this.Size = new System.Drawing.Size(350, 400);
			this.Controls.SetChildIndex(this.pictureBox, 0);
			this.Controls.SetChildIndex(this.labelMessage, 0);
			this.Controls.SetChildIndex(this.labelTitle, 0);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
	}
}
