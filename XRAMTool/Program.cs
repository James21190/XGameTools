﻿using System;
using System.Windows.Forms;
using XCommonLib.RAM;

namespace XRAMTool
{
    public static class Program
    {
        public static GameHook GameHook;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            while (true)
            {
                GameHook = XWrapperLib.XGameHookFactory.GetGameHook();

                if (GameHook != null)
                {
                    break;
                }

                DialogResult result = MessageBox.Show("X is not currently running!\nPlease launch an X game and retry.", "Game not running", MessageBoxButtons.RetryCancel);
                if (result != DialogResult.Retry)
                {
                    return;
                }
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new XRAMTool());
        }
    }
}
