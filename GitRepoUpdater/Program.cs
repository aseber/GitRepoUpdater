﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace GitMultiUpdate
{
    static class Program
    {
        public static CommandExecutor commandExecutor = new CommandExecutor(2);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var rootDirectory = Directory.GetCurrentDirectory();
            var window = new MainWindow(rootDirectory);
            Application.EnableVisualStyles();
            Application.Run(window);
        }
    }
}
