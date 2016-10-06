using LibGit2Sharp;
using System;
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

        public Tuple<string, bool> FetchDirectory()
        {
            using (var repository = new Repository(directory))
            {
                try
                {
                    repository.Network.Fetch(repository.Head.Remote);
                }
                catch (LibGit2SharpException e)
                {
                    Console.WriteLine($"{e.Message} caught on {directory}");
                    return Tuple.Create(e.Message, false);
                }
            }

            return Tuple.Create("Successful fetch", true);
        }

        public Tuple<string, bool> PullDirectory()
        {
            using (var repository = new Repository(directory))
            {
                try
                {
                    var pullOptions = new PullOptions();
                    repository.Network.Pull(new Signature(new Identity("GitRepoUpdater Pull", "aseber@techsouth.cc"), new DateTimeOffset(DateTime.Now)), pullOptions);
                }
                catch (LibGit2SharpException e)
                {
                    Console.WriteLine($"{e.Message} caught on {directory}");
                    return Tuple.Create(e.Message, false);
                }
            }

            return Tuple.Create("Successful fetch", true);
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
