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
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using DotNetApi.Windows.Controls;
using YtAnalytics.Forms;
using YtApi.Api.V2.Data;

namespace YtAnalytics.Controls.YouTube
{
	/// <summary>
	/// A control that displays a YouTube user profile.
	/// </summary>
	public partial class ControlProfileProperties : ThreadSafeControl
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
		public ControlProfileProperties()
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
				// Save the old value.
				Profile old = this.profile;
				// Set the new profile.
				this.profile = value;
				// Call the event handler.
				this.OnProfileSet(old, value);
			}
		}

		// Protected methods.

		/// <summary>
		/// An event handler called when a new profile has been set.
		/// </summary>
		/// <param name="oldProfile">The old profile.</param>
		/// <param name="newProfile">The new profile.</param>
		protected virtual void OnProfileSet(Profile oldProfile, Profile newProfile)
		{
			// If the profile has not changed, do nothing.
			if (oldProfile == newProfile) return;

			if (null == newProfile)
			{
				this.labelProfile.Text = "No profile selected";
				this.pictureBox.Image = Resources.FileVideo_48;
				this.pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
				this.tabControl.Visible = false;
			}
			else
			{
				// Video title
				this.labelProfile.Text = newProfile.Title;

				// General
				this.textBoxId.Text = newProfile.Id;
				this.textBoxDisplayId.Text = newProfile.Username != null ? newProfile.Username.Display : ControlProfileProperties.notAvailable;
				this.textBoxTitle.Text = newProfile.Title;
				this.textBoxPublished.Text = newProfile.Published != null ? newProfile.Published.ToString() : ControlProfileProperties.notAvailable;
				this.textBoxUpdated.Text = newProfile.Updated.ToString();
				this.textBoxSummary.Text = newProfile.Summary != null ? newProfile.Summary : ControlProfileProperties.notAvailable;

				// Personal
				this.textBoxFirstName.Text = newProfile.FirstName != null ? newProfile.FirstName : ControlProfileProperties.notAvailable;
				this.textBoxLastName.Text = newProfile.LastName != null ? newProfile.LastName : ControlProfileProperties.notAvailable;
				this.textBoxAge.Text = newProfile.Age != null ? newProfile.Age.Value.ToString() : ControlProfileProperties.notAvailable;
				this.textBoxLocation.Text = newProfile.Location != null ? newProfile.Location : ControlProfileProperties.notAvailable;
				this.textBoxOccupation.Text = newProfile.Occupation != null ? newProfile.Occupation : ControlProfileProperties.notAvailable;
				this.textBoxCompany.Text = newProfile.Company != null ? newProfile.Company : ControlProfileProperties.notAvailable;
				this.textBoxSchool.Text = newProfile.School != null ? newProfile.School : ControlProfileProperties.notAvailable;
				this.textBoxHometown.Text = newProfile.Hometown != null ? newProfile.Hometown : ControlProfileProperties.notAvailable;
				this.radioButtonMale.Checked = newProfile.Gender != null ? newProfile.Gender == YtApi.Api.V2.Atom.Gender.Male ? true : false : false;
				this.radioButtonFemale.Checked = newProfile.Gender != null ? newProfile.Gender == YtApi.Api.V2.Atom.Gender.Female ? true : false : false;

				// Details
				this.textBoxAboutMe.Text = newProfile.AboutMe != null ? newProfile.AboutMe : ControlProfileProperties.notAvailable;
				this.textBoxBooks.Text = newProfile.Books != null ? newProfile.Books : ControlProfileProperties.notAvailable;
				this.textBoxHobbies.Text = newProfile.Hobbies != null ? newProfile.Hobbies : ControlProfileProperties.notAvailable;
				this.textBoxMovies.Text = newProfile.Movies != null ? newProfile.Movies : ControlProfileProperties.notAvailable;
				this.textBoxMusic.Text = newProfile.Music != null ? newProfile.Music : ControlProfileProperties.notAvailable;

				// Author
				this.textBoxAuthorName.Text = newProfile.Author != null ? newProfile.Author.Name : ControlProfileProperties.notAvailable;
				this.textBoxAuthorId.Text = newProfile.Author != null ? newProfile.Author.UserId : ControlProfileProperties.notAvailable;

				// Statistics
				this.textBoxProfileViews.Text = newProfile.Statistics != null ? newProfile.Statistics.ViewCount.ToString() : ControlProfileProperties.notAvailable;
				this.textBoxSubscribers.Text = newProfile.Statistics != null ? newProfile.Statistics.SubscriberCount.ToString() : ControlProfileProperties.notAvailable;
				this.textBoxVideoViews.Text = newProfile.Statistics != null ? newProfile.Statistics.VideoWatchCount.ToString() : ControlProfileProperties.notAvailable;
				this.textBoxUploadViews.Text = newProfile.Statistics != null ? newProfile.Statistics.TotalUploadViews.ToString() : ControlProfileProperties.notAvailable;
				this.textBoxLastWebAccess.Text = newProfile.Statistics != null ? newProfile.Statistics.LastWebAccess.ToString() : ControlProfileProperties.notAvailable;

				// Thumbnails - the update of the thumbnails is done asynchronously, on the thread pool.
				this.pictureBox.Image = Resources.FileVideo_48;
				this.pictureBox.SizeMode = PictureBoxSizeMode.Normal;
				ThreadPool.QueueUserWorkItem(this.UpdateThumbnailsAsync, newProfile);

				this.tabControl.Visible = true;
			}

			// Select the first tab page.
			this.tabControl.SelectedTab = this.tabPageGeneral;
			if (this.Focused)
			{
				this.textBoxId.Select();
				this.textBoxId.SelectionStart = 0;
				this.textBoxId.SelectionLength = 0;
			}
		}

		// Private methods.

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
		/// <param name="e">The event arguments.</param>
		private void OnThumbnailActivate(object sender, ImageListBoxItemActivateEventArgs e)
		{
			this.formImage.Show(this, e.Item.Text, e.Item.Image);
		}
	}
}
