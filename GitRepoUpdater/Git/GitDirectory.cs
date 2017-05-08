using GitRepoUpdater.GitDirectoryState;
using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        public Tuple<string, bool> FetchDirectory(CredentialsHandler credentials)
        {
            using (var repository = new Repository(directory))
            {
                FetchOptions options = new FetchOptions();
                options.CredentialsProvider = credentials;

                foreach (Remote remote in repository.Network.Remotes)
                {
                    IEnumerable<string> refSpecs = remote.FetchRefSpecs.Select(x => x.Specification);
                    Commands.Fetch(repository, remote.Name, refSpecs, options, null);
                }
            }

            fetchState = SucceededState;
            return Tuple.Create("Successful fetch", true);
        }

        public Tuple<string, bool> PullDirectory(CredentialsHandler credentials)
        {
            MergeResult result;

            using (var repository = new Repository(directory))
            {
                var options = new PullOptions();
                options.FetchOptions = new FetchOptions();
                options.FetchOptions.CredentialsProvider = credentials;

                var signature = new Signature(new Identity("GitRepoUpdater Pull", "aseber@techsouth.cc"), new DateTimeOffset(DateTime.Now));

                result = Commands.Pull(repository, signature, options);
            }

            pullState = SucceededState;
            return Tuple.Create(result.Status.ToString(), true);
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
