/*
 * Copyright (C) 2006-2014 Robert Iwancz
 * 
 * Released under the GNU General Public License.  See LICENSE.TXT
 * 
 */
using System;
using System.Windows.Forms;

namespace MSFileFormat
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new StartForm());
		}
		
	}
}
