using System.Collections.Generic; 

namespace CounselVoting.Domain.ViewModel
{
    public class VoteResultResponse
    {
        public List<string> Names { get; set; }
        public string Result { get; set; }
    }
}
