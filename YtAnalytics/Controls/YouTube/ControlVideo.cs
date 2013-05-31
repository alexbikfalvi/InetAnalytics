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
using DotNetApi.Windows.Controls;
using YtAnalytics.Controls.YouTube.Api2;
using YtAnalytics.Forms;
using YtApi.Api.V2.Data;

namespace YtAnalytics.Controls.YouTube
{
	/// <summary>
	/// A control that displays a YouTube video.
	/// </summary>
	public partial class ControlVideo : ThreadSafeControl
	{
		private Video video;
		private WebClient web = new WebClient();

		private List<Image> thumbnails = new List<Image>();
		private Mutex mutex = new Mutex();

		private WaitCallback delegateThumbnailUpdateCompleted;

		private FormImage formImage = new FormImage();

		private static string notAvailable = "(not available)";

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlVideo()
		{
			InitializeComponent();
			// Set the current video to null.
			this.Video = null;
			// Create event handler for the web client.
			this.web.DownloadDataCompleted += DownloadThumbnailCompleted;
			// Create a delegate for the completion of thumbnail updates.
			this.delegateThumbnailUpdateCompleted = new WaitCallback(this.UpdateThumbnailsCompleted);
		}

		/// <summary>
		/// An event raised when the user selects the view profile.
		/// </summary>
		public event ViewIdEventHandler ViewProfile;

		/// <summary>
		/// Gets or sets the current video object.
		/// </summary>
		public Video Video
		{
			get { return this.video; }
			set
			{
				// If the video hasn't changed, do nothing.
				if (value == this.video) return;

				this.video = value;

				if (null != video)
				{
					// Video title
					this.labelVideo.Text = this.video.Title;

					// General
					this.textBoxId.Text = this.video.Id;
					this.textBoxTitle.Text = this.video.Title;
					this.textBoxPublished.Text = this.video.Published != null ? this.video.Published.ToString() : ControlVideo.notAvailable;
					this.textBoxUpdated.Text = this.video.Updated.ToString();
					this.textBoxDescription.Text = this.video.Description != null ? this.video.Description : ControlVideo.notAvailable;
					this.textBoxKeywords.Text = this.video.Keywords != null ? this.video.Keywords : ControlVideo.notAvailable;
					this.textBoxCategory.Text = this.video.Category.Label;
					this.textBoxDuration.Text = this.video.Duration != null ? this.video.Duration.ToString() : ControlVideo.notAvailable;
					this.checkBoxPrivate.Checked = this.video.IsPrivate;
					this.checkBoxWidescreen.Checked = this.video.IsWidescreen;

					// Author
					this.textBoxAuthorName.Text = this.video.Author != null ? this.video.Author.Name : ControlVideo.notAvailable;
					this.textBoxAuthorId.Text = this.video.Author != null ? this.video.Author.UserId : ControlVideo.notAvailable;
					this.buttonViewProfile.Enabled = this.video.Author != null;

					// Upload
					this.textBoxUploaded.Text = this.video.Uploaded != null ? this.video.Uploaded.ToString() : ControlVideo.notAvailable;
					this.textBoxUploader.Text = this.video.Uploader != null ? this.video.Uploader : ControlVideo.notAvailable;
					this.textBoxState.Text = this.video.State != null ? this.video.State.Name != null ? this.video.State.Name.ToString() : ControlVideo.notAvailable : ControlVideo.notAvailable;
					this.textBoxReason.Text = this.video.State != null ? this.video.State.Reason != null ? this.video.State.Reason.ToString() : ControlVideo.notAvailable : ControlVideo.notAvailable;
					this.checkBoxDraft.Checked = this.video.State != null ? this.video.State.IsDraft : false;
					this.textBoxLocation.Text = this.video.Location != null ? this.video.Location : ControlVideo.notAvailable;
					this.textBoxRecorded.Text = this.video.Recorded != null ? this.video.Recorded.ToString() : ControlVideo.notAvailable;

					// Statistics
					this.textBoxViews.Text = this.video.Statistics != null ? this.video.Statistics.ViewCount.ToString() : ControlVideo.notAvailable;
					this.textBoxFavorites.Text = this.video.Statistics != null ? this.video.Statistics.FavoriteCount.ToString() : ControlVideo.notAvailable;
					this.textBoxComments.Text = this.video.Comments != null ? this.video.Comments.ToString() : ControlVideo.notAvailable;
					this.labelRatingLikes.Text = this.video.UserRatingLike != null ? this.video.UserRatingLike.NumLikes.ToString() : ControlVideo.notAvailable;
					this.labelRatingDislikes.Text = this.video.UserRatingLike != null ? this.video.UserRatingLike.NumDislikes.ToString() : ControlVideo.notAvailable;
					this.textBoxRatingMin.Text = this.video.UserRatingStar != null ? this.video.UserRatingStar.Min.ToString() : ControlVideo.notAvailable;
					this.textBoxRatingMax.Text = this.video.UserRatingStar != null ? this.video.UserRatingStar.Max.ToString() : ControlVideo.notAvailable;
					this.textBoxRatingAverage.Text = this.video.UserRatingStar != null ? this.video.UserRatingStar.Average.ToString() : ControlVideo.notAvailable;
					this.textBoxRatingRaters.Text = this.video.UserRatingStar != null ? this.video.UserRatingStar.NumRaters.ToString() : ControlVideo.notAvailable;

					// Permissions
					this.listViewPermissions.Items.Clear();
					foreach (AccessControlEntry entry in this.video.AccessControl)
					{
						this.listViewPermissions.Items.Add(new ListViewItem(new string[] {
							entry.Action.ToString(),
							entry.Permission.ToString()}));
					}

					// Thumbnails - the update of the thumbnails is done asynchronously, on the thread pool.
					this.pictureBox.Image = Resources.FileVideo_48;
					this.pictureBox.SizeMode = PictureBoxSizeMode.Normal;
					ThreadPool.QueueUserWorkItem(this.UpdateThumbnailsAsync, this.video);

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
			// Get the video corresponding to the current update.
			Video video = state as Video;

			// Wait on the thumbnail mutex.
			this.mutex.WaitOne();
			try
			{
				// Clear the thumbnail list.
				this.thumbnails.Clear();
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
				// Else, if the video has thumbnails.
				if (video.Thumbnails.Count > 0)
				{
					try
					{
						// Begin a new download for the first thumbnail.
						this.web.DownloadDataAsync(video.Thumbnails[0].Url, video);
					}
					catch (Exception exception)
					{
						// If an exception occurs, complete the download.
						this.DownloadThumbnailCompleted(video, false, exception, null);
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
			this.DownloadThumbnailCompleted(
				e.UserState as Video,
				e.Cancelled,
				e.Error,
				e.Cancelled ? null : e.Error == null ? e.Result : null);
		}

		/// <summary>
		/// Completes an asynchronous request for a thumbnail.
		/// </summary>
		/// <param name="video">The request video.</param>
		/// <param name="canceled">Indicates whether the request was canceled.</param>
		/// <param name="exception">The request exception, if any.</param>
		/// <param name="data">The reequest result.</param>
		void DownloadThumbnailCompleted(Video video, bool canceled, Exception exception, byte[] data)
		{
			if (canceled)
			{
				// If the request has been canceled, clear the thumbnail list.
				this.mutex.WaitOne();
				try { this.thumbnails.Clear(); }
				finally { this.mutex.ReleaseMutex(); }

				// If the current video is not null and different from the current video.
				if ((this.video != null) && (this.video != video))
				{
					// Restart the download for the new video.
					this.UpdateThumbnailsAsync(this.video);
				}
				else
				{
					// Otherwise complete the update.
					this.UpdateThumbnailsCompleted(video);
				}
			}
			else
			{
				// If the request completed.

				// Create the thumbnail image.
				Image image = null;

				// If no error occurred, get the image.
				if ((null == exception) && (null != data))
				{
					// Create a memory stream from the specified data.
					using (MemoryStream stream = new MemoryStream(data))
					{
						// Create the image from the specified stream.
						try
						{
							image = Image.FromStream(stream);
						}
						catch (Exception) { }
					}
				}

				// Add the image to the list.
				this.mutex.WaitOne();
				try { this.thumbnails.Add(image); }
				finally { this.mutex.ReleaseMutex(); }

				// If there are more images to download.
				if (this.thumbnails.Count < video.Thumbnails.Count)
				{
					// Create a new request for the next thumbnail.
					try
					{
						// Begin a new download for the first thumbnail.
						this.web.DownloadDataAsync(video.Thumbnails[this.thumbnails.Count].Url, video);
					}
					catch (Exception ex)
					{
						// If an exception occurs, complete the download.
						this.DownloadThumbnailCompleted(video, false, ex, null);
					}
				}
				else
				{
					// Else, complete the update.
					this.UpdateThumbnailsCompleted(video);
				}
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
				// Get the video.
				Video video = status as Video;

				// Clear the thumbnails list box.
				this.imageListBoxThumbnails.Items.Clear();

				if ((video == this.video) && (this.thumbnails.Count > 0))
				{
					if (thumbnails[0] != null)
					{
						this.pictureBox.Image = this.thumbnails[0];
						this.pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
					}

					for (int index = 0; (index < video.Thumbnails.Count) && (index < this.thumbnails.Count); index++)
					{
						this.imageListBoxThumbnails.AddItem(string.Format("{0} ({1})", video.Thumbnails[index].Name, video.Thumbnails[index].Url.ToString()), this.thumbnails[index]);
					}
				}
				else
				{
					this.pictureBox.Image = Resources.FileVideo_48;
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

		/// <summary>
		/// An event handler called when the user clicks on the view user profile button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The item.</param>
		private void OnViewProfile(object sender, EventArgs e)
		{
			if (this.ViewProfile != null) this.ViewProfile(this.video.Author.UserId);
		}
	}
}
