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
using YtAnalytics.Forms;
using YtApi.Api.V2.Atom;
using YtApi.Ajax;
using YtCrawler.Log;

namespace YtAnalytics.Controls
{
	/// <summary>
	/// Displays the information of a log event.
	/// </summary>
	public partial class ControlLogEvent : UserControl
	{
		private static Image[] eventImage = {
												Resources.EventInformation_32,
											    Resources.EventSuccess_32,
											    Resources.EventError_32,
											    Resources.EventCanceled_32,
											    Resources.EventWarning_32,
											    Resources.EventStop_32,
												Resources.EventSuccessWarning_32,
												Resources.EventErrorWarning_32
										    };

		private LogEvent evt = null;

		private FormLogEvent formLogEvent = null;
		private FormException formException = null;

		/// <summary>
		/// Creates a new log event control instance.
		/// </summary>
		public ControlLogEvent()
		{
			InitializeComponent();
			this.linkLabel.Width = this.linkLabel.PreferredWidth + 20;
			this.linkLabel.Height = this.linkLabel.PreferredHeight > 16 ? this.linkLabel.PreferredHeight : 16;
		}

		/// <summary>
		/// Gets or sets the current log event.
		/// </summary>
		public LogEvent Event
		{
			get { return this.evt; }
			set
			{
				if (null == value)
				{
					this.pictureBox.Image = Resources.EventMagenta_32;
					this.labelType.Text = "No event selected.";
					this.tabControl.Visible = false;
					return;
				}

				this.pictureBox.Image = ControlLogEvent.eventImage[(int)value.Type];
				this.labelType.Text = LogEvent.GetDescription(value.Type);
				this.tabControl.Visible = true;

				this.textBoxLevel.Text = LogEvent.GetDescription(value.Level);
				this.textBoxTimestamp.Text = value.Timestamp.ToString();
				this.textBoxSource.Text = value.Source;
				this.textBoxMessage.Text = value.MessageRaw;
				this.labelError.Text = string.Empty;

				if (value.Parent != null)
				{
					this.linkLabel.Text = string.Format("Event at {0}", value.Parent.Timestamp.ToString());
					this.linkLabel.ImageIndex = (int)value.Parent.Type + 1;
					this.linkLabel.Enabled = true;
				}
				else
				{
					this.linkLabel.Text = "None";
					this.linkLabel.ImageIndex = 0;
					this.linkLabel.Enabled = false;
				}
				this.linkLabel.Width = this.linkLabel.PreferredWidth + 20;
				this.linkLabel.Height = this.linkLabel.PreferredHeight > 16 ? this.linkLabel.PreferredHeight : 16;

				if (value.Paremeters != null)
				{
					this.listViewParameters.Items.Clear();
					int index = 0;
					foreach (object param in value.Paremeters)
						this.listViewParameters.Items.Add(new ListViewItem(new string[] { (index++).ToString(), param.ToString() }));
					if(!this.tabControl.TabPages.Contains(this.tabPageParameters)) this.tabControl.TabPages.Add(this.tabPageParameters);
				}
				else if (this.tabControl.TabPages.Contains(this.tabPageParameters)) this.tabControl.TabPages.Remove(this.tabPageParameters);

				// Exception
				if (value.Exception != null)
				{
					this.textBoxExceptionType.Text = value.Exception.GetType().ToString();
					this.textBoxExceptionMessage.Text = value.Exception.Message;
					this.textBoxExceptionStack.Text = value.Exception.StackTrace;
					if (!this.tabControl.TabPages.Contains(this.tabPageException)) this.tabControl.TabPages.Add(this.tabPageException);
				}
				else if (this.tabControl.TabPages.Contains(this.tabPageException)) this.tabControl.TabPages.Remove(this.tabPageException);

				// Exception serialization error
				if (value.ExceptionSerializationExceptionType != null)
				{
					this.labelError.Text += string.Format("Could not serialize the event exception while saving to the log file. An exception of type \'{0}\' occurred. {1}\r\n\r\n",
						value.ExceptionSerializationExceptionType,
						value.ExceptionSerializationExceptionMessage);
				}

				// Exception deserialization error
				if (value.ExceptionDeserializationException != null)
				{
					this.labelError.Text += string.Format("Could not deserialize the event exception while reading from the log file. An exception of type \'{0}\' occurred. {1}\r\n\r\n",
						value.ExceptionDeserializationException.GetType().ToString(),
						value.ExceptionDeserializationException.Message);
				}

				if (this.labelError.Text != string.Empty)
				{
					if (!this.tabControl.TabPages.Contains(this.tabPageError)) this.tabControl.TabPages.Add(this.tabPageError);
				}
				else if (this.tabControl.TabPages.Contains(this.tabPageError)) this.tabControl.TabPages.Remove(this.tabPageError);

				// Subevents
				if (value.Subevents != null)
				{
					this.listViewSubevents.Items.Clear();
					foreach (LogEvent evt in value.Subevents)
					{
						ListViewItem item = new ListViewItem(
							new string[] { evt.Timestamp.ToString(), evt.Message },
							(int)evt.Type + 1
							);
						item.Tag = evt;
						this.listViewSubevents.Items.Add(item);
					}
					if (!this.tabControl.TabPages.Contains(this.tabPageSubevents)) this.tabControl.TabPages.Add(this.tabPageSubevents);
				}
				else if (this.tabControl.TabPages.Contains(this.tabPageSubevents)) this.tabControl.TabPages.Remove(this.tabPageSubevents);

				// Load XML data.
				if (this.LoadXml(value.Exception))
				{
					if (!this.tabControl.TabPages.Contains(this.tabPageXml)) this.tabControl.TabPages.Add(this.tabPageXml);
				}
				else if (this.tabControl.TabPages.Contains(this.tabPageXml)) this.tabControl.TabPages.Remove(this.tabPageXml);

				// Load the atom data.
				if (this.LoadCode(value.Exception))
				{
					if (!this.tabControl.TabPages.Contains(this.tabPageCode)) this.tabControl.TabPages.Add(this.tabPageCode);
				}
				else if (this.tabControl.TabPages.Contains(this.tabPageCode)) this.tabControl.TabPages.Remove(this.tabPageCode);

				this.evt = value;
			}
		}

		/// <summary>
		/// An event handler called when the user clicks on the parent link.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnParentClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null == this.evt) return;
			if (null == this.evt.Parent) return;
			this.OpenEvent(this.evt.Parent);
		}

		/// <summary>
		/// An event handler called when the user activates a subevent.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSubeventActivate(object sender, EventArgs e)
		{
			if (0 == this.listViewSubevents.SelectedItems.Count) return;
			this.OpenEvent(this.listViewSubevents.SelectedItems[0].Tag as LogEvent);
		}

		/// <summary>
		/// Opens an event in a new dialog.
		/// </summary>
		/// <param name="evt"></param>
		private void OpenEvent(LogEvent evt)
		{
			if (null == evt) return;

			// Create a new dialog if one does not exist.
			if (null == this.formLogEvent)
			{
				this.formLogEvent = new FormLogEvent();
			}

			// Open the dialog.
			this.formLogEvent.ShowDialog(this, evt);
		}

		/// <summary>
		/// Loads data to the XML page.
		/// </summary>
		/// <param name="exception">The exception containing the XML data.</param>
		/// <returns>Returns <b>true</b> if data was loaded or <b>false</b>, otherwise.</returns>
		private bool LoadXml(Exception exception)
		{
			if (null == exception) return false;
			if (exception.GetType() == typeof(AtomException))
			{
				AtomException ex = exception as AtomException;
				this.listViewXml.Items.Clear();
				for(XmlNamespace ns = ex.Namespace; null != ns; ns = ns.Top)
				{
					foreach (KeyValuePair<string, string> entry in ns.Entries)
					{
						ListViewItem item = new ListViewItem(new string[] { entry.Key, entry.Value }, 9);
						this.listViewXml.Items.Add(item);
					}
				}
				return true;
			}
			else return false;
		}

		/// <summary>
		/// Loads data to the code page.
		/// </summary>
		/// <param name="exception">The exception containing the code data.</param>
		/// <returns>Returns <b>true</b> if data was loaded or <b>false</b>, otherwise.</returns>
		private bool LoadCode(Exception exception)
		{
			if (null == exception) return false;
			if (exception.GetType() == typeof(AtomException))
			{
				AtomException ex = exception as AtomException;
				this.textBoxCode.Text = ex.Xml;
				return true;
			}
			else if (exception.GetType() == typeof(AjaxParsingException))
			{
				AjaxParsingException ex = exception as AjaxParsingException;
				this.textBoxCode.Text = ex.Html;
				return true;
			}
			else return false;
		}

		/// <summary>
		/// An event handler called when the user clicks on the exception details button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event argument.</param>
		private void OnExceptionClick(object sender, EventArgs e)
		{
			if (null == this.evt) return;
			if (null == this.evt.Exception) return;
			if (null == this.formException)
				this.formException = new FormException();
			this.formException.ShowDialog(this, this.evt.Exception);
		}

		/// <summary>
		/// An event handler called when the user mouse clicks on the parameters list view.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnParametersMouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				if (this.listViewParameters.FocusedItem != null)
				{
					if(this.listViewParameters.FocusedItem.Bounds.Contains(e.Location))
					{
						this.contextMenu.Show(this.listViewParameters, e.Location);
					}
				}
			}
		}

		/// <summary>
		/// Copies the selected parameter to clipboard.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCopyClick(object sender, EventArgs e)
		{
			if(this.listViewParameters.FocusedItem == null) return;

			Clipboard.SetText(this.listViewParameters.FocusedItem.SubItems[1].Text);
		}
	}
}
