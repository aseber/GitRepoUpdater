using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitRepoUpdater.GitDirectoryState
{
    public class FailedState : IGitDirectoryState
    {
        public string GetState()
        {
            return "Failed";
        }
    }
}
