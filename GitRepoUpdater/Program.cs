using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace GitMultiUpdate
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var window = new MainWindow();
            Application.EnableVisualStyles();
            window.SetDirectoryContent(GetGitDirectories());
            Application.Run(window);
        }

        static IEnumerable<GitDirectory> GetGitDirectories()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var directories = Directory.GetDirectories(currentDirectory);
            var gitDirectories = new List<GitDirectory>();

            foreach (var directory in directories)
            {
                try
                {
                    gitDirectories.Add(new GitDirectory(directory));
                }
                catch (InvalidGitDirectoryException) { }
            }

            return gitDirectories;
        }
    }
}
