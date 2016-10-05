using System.IO;
using System.Threading.Tasks;

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
            Program.commandExecutor.ProcessCommand(directory, $"{getGitExe()} fetch");
        }

        public void PullDirectory()
        {
            Program.commandExecutor.ProcessCommand(directory, $"{getGitExe()} fetch", $"{getGitExe()} pull");
        }

        private string getGitExe()
        {
            return "\"C:\\Program Files\\Git\\bin\\git.exe\"";
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
