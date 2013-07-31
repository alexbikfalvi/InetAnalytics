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
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using YtAnalytics.Forms;
using YtCrawler;

namespace YtAnalytics
{
	/// <summary>
	/// A class representing the YouTube Analytics program.
	/// </summary>
	static class Program
	{
		private static bool showCrash = true;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.ThreadException += Program.OnThreadException;
			try
			{
				using (Crawler crawler = new Crawler(Registry.CurrentUser, Resources.ConfigRootPath))
				{
					Application.Run(new FormMain(crawler));
				}
			}
			catch (Exception exception)
			{
				FormCrash formCrash = new FormCrash(exception);
				formCrash.ShowDialog();
			}
		}

		/// <summary>
		/// An event handler called when an exception occurs during the execution of the application.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
		{
			// If cannot show the crash form, do nothing.
			if (!Program.showCrash) return;
			// Set the show crash flag to false.
			Program.showCrash = false;
			// Show the crash form.
			Application.Run(new FormCrash(e.Exception));
		}
	}
}
