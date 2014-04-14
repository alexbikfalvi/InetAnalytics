/* 
 * Copyright (C) 2014 Alex Bikfalvi
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
using DotNetApi.Windows.Themes;
using InetTraceroute.Forms;

namespace InetTraceroute
{
	/// <summary>
	/// The main program class.
	/// </summary>
	static class Program
	{
		private static FormCrash formCrash;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Program.formCrash = new FormCrash();
			Application.ThreadException += Program.OnThreadException;

			ToolStripManager.Renderer = new ThemeRenderer(ThemeSettings.Blue);

			try
			{
				using (TracerouteApplication application = new TracerouteApplication(Registry.CurrentUser, Resources.ConfigRootPath))
				{
					using (FormMain formMain = new FormMain(application))
					{
						Application.Run(formMain);
					}
				}
			}
			catch (Exception exception)
			{
				Program.formCrash.ShowDialog(exception);
			}
			finally
			{
				Program.formCrash.Dispose();
			}
		}

		/// <summary>
		/// An event handler called when an exception occurs during the execution of the application.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
		{
			// Show the crash form.
			Program.formCrash.ShowDialog(e.Exception);
		}
	}
}
