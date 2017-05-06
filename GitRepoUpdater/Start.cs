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

            /*
             
             APP START
             Get current dir listing
             for each dir valid git dir, mark it's status (Do we need to push? uncommitted changes?)
                if we need to push, ask the user before attempting fetch / pull
                if uncommitted, notify and ignore
             sync dir by fetch and pulling the current branch of all dirs that reach this point
                Use a parallel library (if possible) to do multiple at once (4)
             
             */


            string workingDirectory = workingDirectory = GetWorkingDirectory();
            var window = new MainWindow(workingDirectory);
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

        public static Tuple<string, string> GetGitCredentials()
        {
            var username = (string) Properties.Settings.Default["GitUsername"];
            var password = (string) Properties.Settings.Default["GitPassword"];

            var credentials = Tuple.Create(username, password);

            if (!ValidGitCredentials(credentials))
            {
                throw new SettingsPropertyNotFoundException();
            }

            return credentials;
        }

        private static bool ValidGitCredentials(Tuple<string, string> credentials)
        {
            if (credentials.Item1 == string.Empty || credentials.Item2 == string.Empty)
            {
                return false;
            }

            return true;
        }

    }
}
