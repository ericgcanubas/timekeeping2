using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TimeKeepingII
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string configFile = "config.ini";

            if (File.Exists(configFile) == false)
            {
                Application.Run(new FrmSetup());
            }
            else
            {
                Application.Run(new FrmMain());
            }

              
        }
    }
}
