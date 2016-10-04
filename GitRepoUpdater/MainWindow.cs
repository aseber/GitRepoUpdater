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
            DirectoriesList.Items.Clear();

            foreach (var directory in directories)
            {
                DirectoriesList.Items.Add(directory, true);
            }

            Refresh();
        }

        public void printItems()
        {
            foreach (var item in DirectoriesList.Items)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private IEnumerable<GitDirectory> GetSelectedGitDirectories()
        {
            return new List<GitDirectory>();
        }

        private void PullAndFetchDirectories(object sender, EventArgs e)
        {
           
        }
    }
}
