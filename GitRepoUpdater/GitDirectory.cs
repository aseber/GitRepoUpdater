using System.IO;

namespace GitMultiUpdate
{
    public class GitDirectory
    {
        public string directory { get; }
        public string directoryName { get; }

        public GitDirectory(string directory)
        {
            if (!IsGitDirectory(directory))
            {
                throw new InvalidGitDirectoryException();
            }

            this.directory = directory;
            directoryName = Path.GetFileName(directory);
        }

        public void FetchDirectory()
        {

        }

        public void PullDirectory()
        {

        }

        private bool IsGitDirectory(string directory)
        {
            var subDirectories = Directory.EnumerateDirectories(directory);

            foreach (var subDirectory in subDirectories)
            {
                if (Path.GetFileName(subDirectory) == ".git")
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return directoryName;
        }
    }
}
