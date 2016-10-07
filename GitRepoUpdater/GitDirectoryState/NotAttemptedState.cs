using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitMultiUpdate.GitDirectoryState
{
    public class NotAttemptedState : IGitDirectoryState
    {
        public string GetState()
        {
            return "Not Attempted";
        }
    }
}
