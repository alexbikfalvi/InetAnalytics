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
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YtAnalytics.Forms;
using YtApi.Api.V2.Data;

namespace YtAnalytics.Controls
{
	/// <summary>
	/// A control that displays a YouTube user profile.
	/// </summary>
	public partial class ControlProfile : UserControl
	{
		private Profile profile;
		private WebClient web = new WebClient();

		private Image thumbnail = null;
		private Mutex mutex = new Mutex();

		private WaitCallback delegateThumbnailUpdateCompleted;

		private FormImage formImage = new FormImage();

		private static string notAvailable = "(not available)";

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlProfile()
		{
			InitializeComponent();
			// Set the current video to null.
			this.Profile = null;
			// Create event handler for the web client.
			this.web.DownloadDataCompleted += DownloadThumbnailCompleted;
			// Create a delegate for the completion of thumbnail updates.
			this.delegateThumbnailUpdateCompleted = new WaitCallback(this.UpdateThumbnailsCompleted);
		}

		/// <summary>
		/// Gets or sets the current profile object.
		/// </summary>
		public Profile Profile
		{
			get { return this.profile; }
			set
			{
				// If the profile hasn't changed, do nothing.
				if (value == this.profile) return;

				this.profile = value;

				if (null != profile)
				{
					// Video title
					this.labelProfile.Text = this.profile.Title;

					// General
					this.textBoxId.Text = this.profile.Id;
					this.textBoxDisplayId.Text = this.profile.Username != null ? this.profile.Username.Display : ControlProfile.notAvailable;
					this.textBoxTitle.Text = this.profile.Title;
					this.textBoxPublished.Text = this.profile.Published != null ? this.profile.Published.ToString() : ControlProfile.notAvailable;
					this.textBoxUpdated.Text = this.profile.Updated.ToString();
					this.textBoxSummary.Text = this.profile.Summary != null ? this.profile.Summary : ControlProfile.notAvailable;

					// Personal
					this.textBoxFirstName.Text = this.profile.FirstName != null ? this.profile.FirstName : ControlProfile.notAvailable;
					this.textBoxLastName.Text = this.profile.LastName != null ? this.profile.LastName : ControlProfile.notAvailable;
					this.textBoxAge.Text = this.profile.Age != null ? this.profile.Age.Value.ToString() : ControlProfile.notAvailable;
					this.textBoxLocation.Text = this.profile.Location != null ? this.profile.Location : ControlProfile.notAvailable;
					this.textBoxOccupation.Text = this.profile.Occupation != null ? this.profile.Occupation : ControlProfile.notAvailable;
					this.textBoxCompany.Text = this.profile.Company != null ? this.profile.Company : ControlProfile.notAvailable;
					this.textBoxSchool.Text = this.profile.School != null ? this.profile.School : ControlProfile.notAvailable;
					this.textBoxHometown.Text = this.profile.Hometown != null ? this.profile.Hometown : ControlProfile.notAvailable;
					this.radioButtonMale.Checked = this.profile.Gender != null ? this.profile.Gender == YtApi.Api.V2.Atom.Gender.Male ? true : false : false;
					this.radioButtonFemale.Checked = this.profile.Gender != null ? this.profile.Gender == YtApi.Api.V2.Atom.Gender.Female ? true : false : false;

					// Details
					this.textBoxAboutMe.Text = this.profile.AboutMe != null ? this.profile.AboutMe : ControlProfile.notAvailable;
					this.textBoxBooks.Text = this.profile.Books != null ? this.profile.Books : ControlProfile.notAvailable;
					this.textBoxHobbies.Text = this.profile.Hobbies != null ? this.profile.Hobbies : ControlProfile.notAvailable;
					this.textBoxMovies.Text = this.profile.Movies != null ? this.profile.Movies : ControlProfile.notAvailable;
					this.textBoxMusic.Text = this.profile.Music != null ? this.profile.Music : ControlProfile.notAvailable;

					// Author
					this.textBoxAuthorName.Text = this.profile.Author != null ? this.profile.Author.Name : ControlProfile.notAvailable;
					this.textBoxAuthorId.Text = this.profile.Author != null ? this.profile.Author.UserId : ControlProfile.notAvailable;

					// Statistics
					this.textBoxProfileViews.Text = this.profile.Statistics != null ? this.profile.Statistics.ViewCount.ToString() : ControlProfile.notAvailable;
					this.textBoxSubscribers.Text = this.profile.Statistics != null ? this.profile.Statistics.SubscriberCount.ToString() : ControlProfile.notAvailable;
					this.textBoxVideoViews.Text = this.profile.Statistics != null ? this.profile.Statistics.VideoWatchCount.ToString() : ControlProfile.notAvailable;
					this.textBoxUploadViews.Text = this.profile.Statistics != null ? this.profile.Statistics.TotalUploadViews.ToString() : ControlProfile.notAvailable;
					this.textBoxLastWebAccess.Text = this.profile.Statistics != null ? this.profile.Statistics.LastWebAccess.ToString() : ControlProfile.notAvailable;

					// Thumbnails - the update of the thumbnails is done asynchronously, on the thread pool.
					this.pictureBox.Image = Resources.FileVideo_48;
					this.pictureBox.SizeMode = PictureBoxSizeMode.Normal;
					ThreadPool.QueueUserWorkItem(this.UpdateThumbnailsAsync, this.profile);

					// Select the first tab page.
					this.tabControl.SelectedTab = this.tabPageGeneral;
					this.textBoxId.Select();
					this.textBoxId.SelectionStart = 0;
					this.textBoxId.SelectionLength = 0;
				}
			}
		}

		/// <summary>
		/// Begins an asynchronous update of the video thuumbnails.
		/// </summary>
		/// <param name="state">The asynchronous state.</param>
		private void UpdateThumbnailsAsync(object state)
		{
			// Get the profile corresponding to the current update.
			Profile profile = state as Profile;

			// Wait on the thumbnail mutex.
			this.mutex.WaitOne();
			try
			{
				// Clear the thumbnail list.
				this.thumbnail = null;
			}
			finally
			{
				this.mutex.ReleaseMutex();
			}

			if (this.web.IsBusy)
			{
				// If a download is in progress, cancel the current download.
				this.web.CancelAsync();
			}
			else
			{
				if (profile.Thumbnail != null)
				{
					try
					{
						// Begin a new download for the first thumbnail.
						this.web.DownloadDataAsync(profile.Thumbnail.Url, profile);
					}
					catch (Exception exception)
					{
						// If an exception occurs, complete the download.
						this.DownloadThumbnailCompleted(profile, false, exception, null);
					}
				}
			}
		}

		/// <summary>
		/// An event handler called when the download of a thumbnail has completed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		void DownloadThumbnailCompleted(object sender, DownloadDataCompletedEventArgs e)
		{
			this.DownloadThumbnailCompleted(e.UserState as Profile, e.Cancelled, e.Error, e.Result);
		}

		/// <summary>
		/// Completes an asynchronous request for a thumbnail.
		/// </summary>
		/// <param name="profile">The request profile.</param>
		/// <param name="canceled">Indicates whether the request was canceled.</param>
		/// <param name="exception">The request exception, if any.</param>
		/// <param name="data">The reequest result.</param>
		void DownloadThumbnailCompleted(Profile profile, bool canceled, Exception exception, byte[] data)
		{
			if (canceled)
			{
				// If the request has been canceled, clear the thumbnail list.
				this.mutex.WaitOne();
				try { this.thumbnail = null; }
				finally { this.mutex.ReleaseMutex(); }

				// If the current video is not null and different from the current video.
				if ((this.profile != null) && (this.profile != profile))
				{
					// Restart the download for the new video.
					this.UpdateThumbnailsAsync(this.profile);
				}
				else
				{
					// Otherwise complete the update.
					this.UpdateThumbnailsCompleted(profile);
				}
			}
			else
			{
				// If the request completed.

				// Create the thumbnail image.
				Image image = null;

				// If no error occurred, get the image.
				if (null == exception)
				{
					// Create a memory stream from the specified data.
					using (MemoryStream stream = new MemoryStream(data))
					{
						try
						{
							// Create the image from the specified stream.
							image = Image.FromStream(stream);
						}
						catch (Exception) { }
					}
				}

				// Add the image to the list.
				this.mutex.WaitOne();
				try { this.thumbnail = image; }
				finally { this.mutex.ReleaseMutex(); }

				// Complete the update.
				this.UpdateThumbnailsCompleted(profile);
			}
		}

		/// <summary>
		/// A method called when the download of videos has completed.
		/// </summary>
		/// <param name="status">The user state.</param>
		void UpdateThumbnailsCompleted(object status)
		{
			// Invoke the method on the UI thread.
			if (this.InvokeRequired) this.Invoke(this.delegateThumbnailUpdateCompleted, new object[] { status });
			else
			{
				// Get the profile.
				Profile profile = status as Profile;

				// Clear the thumbnails list box.
				this.imageListBoxThumbnails.Items.Clear();

				if ((profile == this.profile) && (this.thumbnail != null))
				{
					this.pictureBox.Image = this.thumbnail;
					this.pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
					this.imageListBoxThumbnails.AddItem(string.Format("{0} ({1})", profile.Thumbnail.Name, profile.Thumbnail.Url.ToString()), this.thumbnail);
				}
				else
				{
					this.pictureBox.Image = Resources.FileUser_48;
					this.pictureBox.SizeMode = PictureBoxSizeMode.Normal;
				}
			}
		}

		/// <summary>
		/// An event handler called when the user activates a thumbnail.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="item">The item.</param>
		private void OnThumbnailActivate(object sender, DotNetApi.Windows.Controls.ImageListBoxItem item)
		{
			this.formImage.Show(this, item.Text, item.Image);
		}
	}
}
