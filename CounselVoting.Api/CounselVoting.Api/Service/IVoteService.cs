using CounselVoting.Api.ViewModel;
using CounselVoting.Domain.Model;
using CounselVoting.Domain.ViewModel;

namespace CounselVoting.Api.Service
{
    public interface IVoteService
    {
        public VoteResponse RegisterVote(VoteModel voteModel);
        public VoteResultResponse GetVoteResult(long measureId);
    }
}
