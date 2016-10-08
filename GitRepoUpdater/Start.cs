using GitRepoUpdater.Gui;
using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace GitRepoUpdater
{
    static class Start
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string workingDirectory = workingDirectory = GetWorkingDirectory();
            var window = new mainWindow(workingDirectory);
            Application.EnableVisualStyles();
            Application.Run(window);
        }

        private static string GetWorkingDirectory()
        {
            return (string) Properties.Settings.Default["WorkingDirectory"];
        }

        public static void SetWorkingDirectory(string directory)
        {
            Properties.Settings.Default["WorkingDirectory"] = directory;
            Properties.Settings.Default.Save();
        }
    }
}
