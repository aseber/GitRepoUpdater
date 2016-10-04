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

        public async Task FetchDirectory()
        {
            await Program.commandExecutor.ProcessCommand($"cd {directory}");
            await Program.commandExecutor.ProcessCommand("git fetch");
        }

        public async Task PullDirectory()
        {
            await Program.commandExecutor.ProcessCommand($"cd {directory}");
            await Program.commandExecutor.ProcessCommand("git pull");
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
