﻿using System;
using System.Windows.Forms;

namespace X3TC_RAM_Tool
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new X3ToolForm());
        }
    }
}
