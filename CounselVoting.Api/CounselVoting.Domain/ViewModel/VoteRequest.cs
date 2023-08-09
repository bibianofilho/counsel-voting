using CounselVoting.Domain.Enums;
using System; 

namespace CounselVoting.Domain.ViewModel
{
    public class VoteRequest
    {
        public long VoteId { get; set; }        
        public long MeasureId { get; set; }
        public string UserName { get; set; }
        public VoteType VoteType { get; set; }
        public DateTime VotedAt { get; set; }
    }
}
