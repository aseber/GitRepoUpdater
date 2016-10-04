using System;

namespace GitMultiUpdate
{
    class InvalidGitDirectoryException : Exception
    {
        public InvalidGitDirectoryException() : base("Directory is not a valid git repository") { }
    }
}
