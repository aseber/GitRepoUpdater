using System;

namespace GitMultiUpdate.Git
{
    class InvalidGitDirectoryException : Exception
    {
        public InvalidGitDirectoryException() : base("Directory is not a valid git repository") { }
    }
}
