using CounselVoting.Infrastructure.Context;

namespace CounselVoting.Infrastructure.Repository
{
    public class CounselVotingRepository<TEntity> : EFRepository<TEntity> where TEntity : class
    {
        public CounselVotingRepository(CounselContext counselContext) : base(counselContext)
        {

        }
    }
}
