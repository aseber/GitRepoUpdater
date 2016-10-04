using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GitMultiUpdate
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void SetDirectoryContent(IEnumerable<GitDirectory> directories)
        {
            directoriesList.Items.Clear();

            foreach (var directory in directories)
            {
                directoriesList.Items.Add(directory, true);
            }

            Refresh();
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
    }
}
