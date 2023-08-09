using CounselVoting.Domain.Exceptions;
using CounselVoting.Domain.Mappers;
using CounselVoting.Domain.Model;
using CounselVoting.Domain.ViewModel;
using CounselVoting.Infrastructure.Repository;
using System.Linq; 

namespace CounselVoting.Infrastructure.Service
{
    public class VoteServiceData: IVoteServiceData
    {        
        private readonly CounselVotingRepository<VoteModel> _counselVotingRepository;        

        public VoteServiceData(     
             CounselVotingRepository<VoteModel> counselVotingRepository,
             IMapper<VoteModel, VoteRequest> voteMapper)
        {            
            _counselVotingRepository = counselVotingRepository;            
        }

        public VoteModel Insert(VoteModel model)
        {
            if (!HasUserName(model.UserName))
                throw new FailedVoteException();
            _counselVotingRepository.Insert(model);
            _counselVotingRepository.Save();
            return model;
        }

        private bool HasUserName(string userName)
        {
            return !string.IsNullOrWhiteSpace(userName);
        }

        public IQueryable<VoteModel> Get()
        {           
            return _counselVotingRepository.GetAll();
        }
        public IQueryable<VoteModel> Get(long measureId)
        {
            return _counselVotingRepository.GetByFilter(a => a.MeasureId.Equals(measureId) ).AsQueryable() ;
        }
    }
}
