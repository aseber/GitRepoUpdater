using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitMultiUpdate
{
    public partial class MainWindow : Form
    {
        private FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        private string rootDirectory;

        public MainWindow(string rootDirectory)
        {
            InitializeComponent();
            folderBrowserDialog.Description = "Select the root directory for your git repositories";
            folderBrowserDialog.ShowNewFolderButton = false;
            setRootDirectory(rootDirectory);
        }

        private void SetDirectoryContent(string rootDirectory)
        {
            directoriesList.Items.Clear();

            var directories = Directory.GetDirectories(rootDirectory);

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

        public void setRootDirectory(string rootDirectory)
        {
            this.rootDirectory = rootDirectory;
            urlTextBox.Text = rootDirectory;
            SetDirectoryContent(rootDirectory);

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
                directory.FetchDirectory();
                directory.PullDirectory();
            }
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