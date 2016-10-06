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
            var rootDirectory = @"S:/GitHub/";
            //var rootDirectory = Directory.GetCurrentDirectory();
            var window = new MainWindow(rootDirectory);
            Application.EnableVisualStyles();
            Application.Run(window);
        }
    }
}
