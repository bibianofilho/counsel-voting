using CounselVoting.Domain.Model; 
using System.Linq;

namespace CounselVoting.Infrastructure.Service
{
    public interface IMeasureRuleServiceData
    {
        public MeasureRuleModel Insert(MeasureRuleModel model);
        public IQueryable<MeasureRuleModel> Get();
        public MeasureRuleModel GetId(long measureId);
    }
}