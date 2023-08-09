using CounselVoting.Domain.Model;
using CounselVoting.Infrastructure.Repository;
using System.Linq; 

namespace CounselVoting.Infrastructure.Service
{
    public class MeasureRuleServiceData: IMeasureRuleServiceData
    {
        
        private readonly CounselVotingRepository<MeasureRuleModel> _counselVotingRepository;

        public MeasureRuleServiceData(
             CounselVotingRepository<MeasureRuleModel> counselVotingRepository)
        {
            
            _counselVotingRepository = counselVotingRepository;
        }

        public MeasureRuleModel Insert(MeasureRuleModel model)
        {           
            _counselVotingRepository.Insert(model);
            _counselVotingRepository.Save();
            return model;
        }

        public IQueryable<MeasureRuleModel> Get()
        {           
            return _counselVotingRepository.GetAll();
        }
        public MeasureRuleModel GetId(long measureId)
        {
            return _counselVotingRepository.GetByFilter( i => i.MeasureId.Equals(measureId),null,new string[] { "UserNamesMustVoteToPassList", "Measure" }).SingleOrDefault();
        }
    }
}
