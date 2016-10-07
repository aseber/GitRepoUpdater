using GitMultiUpdate.Gui;
using System;
using System.IO;
using System.Windows.Forms;

namespace GitMultiUpdate
{
    static class Start
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var rootDirectory = Directory.GetCurrentDirectory();
            //var rootDirectory = Directory.GetCurrentDirectory();
            var window = new mainWindow(rootDirectory);
            Application.EnableVisualStyles();
            Application.Run(window);
        }
    }
}
