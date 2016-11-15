using GitRepoUpdater.Git;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitRepoUpdater.Gui
{
    public partial class MainWindow : Form
    {
        private FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        private string rootDirectory;

        public MainWindow(string workingDirectory)
        {
            InitializeComponent();
            folderBrowserDialog.Description = "Select the root directory for your git repositories";
            folderBrowserDialog.ShowNewFolderButton = false;
            setRootDirectory(workingDirectory);
        }

        private void SetDirectoryContent(string workingDirectory)
        {
            directoriesList.Items.Clear();

            var directories = Directory.GetDirectories(workingDirectory);

            foreach (var directory in directories)
            {
                try
                {
                    directoriesList.Items.Add(new GitDirectory(directory), true);
                }
                catch (InvalidGitDirectoryException) { }
            }

            Refresh();
        }

        public void setRootDirectory(string workingDirectory)
        {
            Start.SetWorkingDirectory(workingDirectory);
            this.rootDirectory = workingDirectory;
            urlTextBox.Text = workingDirectory;
            SetDirectoryContent(workingDirectory);

            urlTextBox.Refresh();
        }

        private IEnumerable<GitDirectory> GetCheckedGitDirectories()
        {
            var objectCollection = directoriesList.CheckedItems;
            var gitDirectoryCollection = new List<GitDirectory>();

            foreach (var obj in objectCollection)
            {
                gitDirectoryCollection.Add((GitDirectory) obj);
            }

            return gitDirectoryCollection;
        }

        private void PullAndFetchDirectories(object sender, EventArgs e)
        {
            var checkedDirectories = GetCheckedGitDirectories();

            foreach (var directory in checkedDirectories)
            {
                var fetchResult = directory.FetchDirectory();
                var pullResult = directory.PullDirectory();

                if (fetchResult.Item2 == false || pullResult.Item2 == false)
                {
                    var text = fetchResult.Item1;
                    var caption = $"Fetch / Pull failed on \"{directory.directoryName}\" repository";

                    CreateAsyncMessageBox(text, caption);
                }

                directoriesList.Refresh();
            }
        }

        private void CreateAsyncMessageBox(string text, string caption)
        {
            Task.Run(() =>
            {
                MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
        }

        private void ChangeRootDirectory(object sender, EventArgs e)
        {
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            var dialogResult = folderBrowserDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                setRootDirectory(folderBrowserDialog.SelectedPath);
            }
        }
    }
}