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
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Windows.Controls;
using YtAnalytics.Controls.YouTube.Api2;
using YtAnalytics.Events;
using YtAnalytics.Forms;
using YtApi.Api.V2.Data;

namespace YtAnalytics.Controls.YouTube
{
	/// <summary>
	/// A control that displays a YouTube video.
	/// </summary>
	public partial class ControlVideoProperties : ThreadSafeControl
	{
		private Video video;
		private readonly WebClient web = new WebClient();

		private readonly List<Image> thumbnails = new List<Image>();
		private readonly object sync = new object();

		private WaitCallback delegateThumbnailUpdateCompleted;

		private readonly FormImage formImage = new FormImage();

		private static readonly string notAvailable = "(not available)";

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlVideoProperties()
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
		public event StringEventHandler ViewProfile;

		/// <summary>
		/// Gets or sets the current video object.
		/// </summary>
		public Video Video
		{
			get { return this.video; }
			set
			{
				// Save the old value.
				Video old = this.video;
				// Set the new video.
				this.video = value;
				// Call the event handler.
				this.OnVideoSet(old, value);
			}
		}

		// Protected methods.

		/// <summary>
		/// An event handler called when a new video has been set.
		/// </summary>
		/// <param name="oldVideo">Thd old video.</param>
		/// <param name="newVideo">The new video.</param>
		protected virtual void OnVideoSet(Video oldVideo, Video newVideo)
		{
			// If the video has not changed, do nothing.
			if (oldVideo == newVideo) return;

			if (null == newVideo)
			{
				this.labelVideo.Text = "No video selected";
				this.pictureBox.Image = Resources.FileVideo_48;
				this.pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
				this.tabControl.Visible = false;
			}
			else
			{
				// Video title
				this.labelVideo.Text = newVideo.Title;

				// General
				this.textBoxId.Text = newVideo.Id;
				this.textBoxTitle.Text = newVideo.Title;
				this.textBoxPublished.Text = newVideo.Published != null ? newVideo.Published.ToString() : ControlVideoProperties.notAvailable;
				this.textBoxUpdated.Text = newVideo.Updated.ToString();
				this.textBoxDescription.Text = newVideo.Description != null ? newVideo.Description : ControlVideoProperties.notAvailable;
				this.textBoxKeywords.Text = newVideo.Keywords != null ? newVideo.Keywords : ControlVideoProperties.notAvailable;
				this.textBoxCategory.Text = newVideo.Category.Label;
				this.textBoxDuration.Text = newVideo.Duration != null ? newVideo.Duration.ToString() : ControlVideoProperties.notAvailable;
				this.checkBoxPrivate.Checked = newVideo.IsPrivate;
				this.checkBoxWidescreen.Checked = newVideo.IsWidescreen;

				// Author
				this.textBoxAuthorName.Text = newVideo.Author != null ? newVideo.Author.Name : ControlVideoProperties.notAvailable;
				this.textBoxAuthorId.Text = newVideo.Author != null ? newVideo.Author.UserId : ControlVideoProperties.notAvailable;
				this.buttonViewProfile.Enabled = newVideo.Author != null;

				// Upload
				this.textBoxUploaded.Text = newVideo.Uploaded != null ? newVideo.Uploaded.ToString() : ControlVideoProperties.notAvailable;
				this.textBoxUploader.Text = newVideo.Uploader != null ? newVideo.Uploader : ControlVideoProperties.notAvailable;
				this.textBoxState.Text = newVideo.State != null ? newVideo.State.Name != null ? newVideo.State.Name.ToString() : ControlVideoProperties.notAvailable : ControlVideoProperties.notAvailable;
				this.textBoxReason.Text = newVideo.State != null ? newVideo.State.Reason != null ? newVideo.State.Reason.ToString() : ControlVideoProperties.notAvailable : ControlVideoProperties.notAvailable;
				this.checkBoxDraft.Checked = newVideo.State != null ? newVideo.State.IsDraft : false;
				this.textBoxLocation.Text = newVideo.Location != null ? newVideo.Location : ControlVideoProperties.notAvailable;
				this.textBoxRecorded.Text = newVideo.Recorded != null ? newVideo.Recorded.ToString() : ControlVideoProperties.notAvailable;

				// Statistics
				this.textBoxViews.Text = newVideo.Statistics != null ? newVideo.Statistics.ViewCount.ToString() : ControlVideoProperties.notAvailable;
				this.textBoxFavorites.Text = newVideo.Statistics != null ? newVideo.Statistics.FavoriteCount.ToString() : ControlVideoProperties.notAvailable;
				this.textBoxComments.Text = newVideo.Comments != null ? newVideo.Comments.ToString() : ControlVideoProperties.notAvailable;
				this.labelRatingLikes.Text = newVideo.UserRatingLike != null ? newVideo.UserRatingLike.NumLikes.ToString() : ControlVideoProperties.notAvailable;
				this.labelRatingDislikes.Text = newVideo.UserRatingLike != null ? newVideo.UserRatingLike.NumDislikes.ToString() : ControlVideoProperties.notAvailable;
				this.textBoxRatingMin.Text = newVideo.UserRatingStar != null ? newVideo.UserRatingStar.Min.ToString() : ControlVideoProperties.notAvailable;
				this.textBoxRatingMax.Text = newVideo.UserRatingStar != null ? newVideo.UserRatingStar.Max.ToString() : ControlVideoProperties.notAvailable;
				this.textBoxRatingAverage.Text = newVideo.UserRatingStar != null ? newVideo.UserRatingStar.Average.ToString() : ControlVideoProperties.notAvailable;
				this.textBoxRatingRaters.Text = newVideo.UserRatingStar != null ? newVideo.UserRatingStar.NumRaters.ToString() : ControlVideoProperties.notAvailable;

				// Permissions
				this.listViewPermissions.Items.Clear();
				foreach (AccessControlEntry entry in newVideo.AccessControl)
				{
					this.listViewPermissions.Items.Add(new ListViewItem(new string[] {
							entry.Action.ToString(),
							entry.Permission.ToString()}));
				}

				// Thumbnails - the update of the thumbnails is done asynchronously, on the thread pool.
				this.pictureBox.Image = Resources.FileVideo_48;
				this.pictureBox.SizeMode = PictureBoxSizeMode.Normal;
				ThreadPool.QueueUserWorkItem(this.UpdateThumbnailsAsync, newVideo);

				this.tabControl.Visible = true;

				// Select the first tab page.
				this.tabControl.SelectedTab = this.tabPageGeneral;
				if (this.Focused)
				{
					this.textBoxId.Select();
					this.textBoxId.SelectionStart = 0;
					this.textBoxId.SelectionLength = 0;
				}
			}
		}

		// Private methods.

		/// <summary>
		/// Begins an asynchronous update of the video thuumbnails.
		/// </summary>
		/// <param name="state">The asynchronous state.</param>
		private void UpdateThumbnailsAsync(object state)
		{
			// Get the video corresponding to the current update.
			Video video = state as Video;

			lock (this.sync)
			{
				// Clear the thumbnail list.
				this.thumbnails.Clear();
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

				lock (this.sync)
				{
					this.thumbnails.Clear();
				}

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
				lock (this.sync)
				{
					this.thumbnails.Add(image);
				}

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
						this.imageListBoxThumbnails.AddItem("{0} ({1})".FormatWith(video.Thumbnails[index].Name, video.Thumbnails[index].Url.ToString()), this.thumbnails[index]);
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
		/// <param name="e">The event arguments.</param>
		private void OnThumbnailActivate(object sender, ImageListBoxItemActivateEventArgs e)
		{
			this.formImage.Show(this, e.Item.Text, e.Item.Image);
		}

		/// <summary>
		/// An event handler called when the user clicks on the view user profile button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The item.</param>
		private void OnViewProfile(object sender, EventArgs e)
		{
			if (this.ViewProfile != null) this.ViewProfile(this, new StringEventArgs(this.video.Author.UserId));
		}
	}
}
