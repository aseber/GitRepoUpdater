using LibGit2Sharp;
using System;
using System.IO;

namespace GitMultiUpdate
{
    public class GitDirectory
    {
        public enum directoryState
        {
            NotAttempted,
            Failed,
            Succeeded
        }

        public string directory { get; }
        public string directoryName { get; }
        public directoryState fetchState { get; private set; }
        public directoryState pullState { get; private set; }

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
                    fetchState = directoryState.Failed;
                    return Tuple.Create(e.Message, false);
                }
            }

            fetchState = directoryState.Succeeded;
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
                    pullState = directoryState.Failed;
                    return Tuple.Create(e.Message, false);
                }
            }

            pullState = directoryState.Succeeded;
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
            Console.WriteLine("HELLLO");

            var returnString = directoryName;

            if (pullState != directoryState.NotAttempted)
            {
                if (pullState == directoryState.Succeeded)
                {
                    returnString += " Pull: Success";
                } else
                {
                    returnString += " Pull: Failed";
                }
            }

            if (fetchState != directoryState.NotAttempted)
            {
                if (fetchState == directoryState.Succeeded)
                {
                    returnString += " Fetch: Success";
                }
                else
                {
                    returnString += " Fetch: Failed";
                }
            }

            return directoryName;
        }
    }
}
