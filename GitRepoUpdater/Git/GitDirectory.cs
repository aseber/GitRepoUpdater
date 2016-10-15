using GitRepoUpdater.GitDirectoryState;
using LibGit2Sharp;
using System;
using System.IO;

namespace GitRepoUpdater.Git
{
    public class GitDirectory
    {
        public static readonly IGitDirectoryState NotAttemptedState = new NotAttemptedState();
        public static readonly IGitDirectoryState SucceededState = new SucceededState();
        public static readonly IGitDirectoryState FailedState = new FailedState();

        public string directory { get; }
        public string directoryName { get; }
        public IGitDirectoryState fetchState { get; private set; }
        public IGitDirectoryState pullState { get; private set; }

        public GitDirectory(string directory)
        {
            if (!IsGitDirectory(directory))
            {
                throw new InvalidGitDirectoryException();
            }

            this.directory = directory;
            directoryName = Path.GetFileName(directory);
            fetchState = NotAttemptedState;
            pullState = NotAttemptedState;
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
                    Console.WriteLine("Exception: " + e.GetType());

                    fetchState = FailedState;
                    return Tuple.Create(e.Message, false);
                }
            }

            fetchState = SucceededState;
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
                    pullState = FailedState;
                    return Tuple.Create(e.Message, false);
                }
            }

            pullState = SucceededState;
            return Tuple.Create("Successful fetch", true);
        }

        private bool IsGitDirectory(string directory)
        {
            return Repository.IsValid(directory);
        }

        private string GetPullStateString()
        {
            return $"Pull: {pullState.GetState()}";
        }

        private string GetFetchStateString()
        {
            return $"Fetch: {fetchState.GetState()}";
        }

        public override string ToString()
        {
            if (pullState == NotAttemptedState && fetchState == NotAttemptedState)
            {
                return directoryName;
            }

            return $"{directoryName} - {GetPullStateString()} | {GetFetchStateString()}";
        }
    }
}
