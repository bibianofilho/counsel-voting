using CounselVoting.Domain.Model; 
using System.Linq;

namespace CounselVoting.Infrastructure.Service
{
    public interface IVoteServiceData
    {
        public VoteModel Insert(VoteModel model);
        public IQueryable<VoteModel> Get();
        public IQueryable<VoteModel> Get(long measureId);
    }
}