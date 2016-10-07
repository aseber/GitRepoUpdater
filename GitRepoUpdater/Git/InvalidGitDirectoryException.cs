using System;

namespace GitRepoUpdater.Git
{
    [Serializable]
    class InvalidGitDirectoryException : Exception
    {
        public InvalidGitDirectoryException() : base("Directory is not a valid git repository") { }
    }
}
