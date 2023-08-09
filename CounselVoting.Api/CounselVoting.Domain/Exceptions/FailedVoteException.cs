using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounselVoting.Domain.Exceptions
{
    public class FailedVoteException : Exception
    {
        public FailedVoteException() : base("Vote failed.")
        {

        }
    }
}
