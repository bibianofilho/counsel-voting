using CounselVoting.Api.ViewModel;
using CounselVoting.Domain.Enums;
using CounselVoting.Domain.Model;
using CounselVoting.Domain.ViewModel;
using CounselVoting.Infrastructure.Service;
using System.Collections.Generic;
using System.Linq;

namespace CounselVoting.Api.Service
{
    public class VoteService: IVoteService
    {
        private readonly IVoteServiceData _voteServiceData;
        private readonly IMeasureRuleServiceData _measureRuleServiceData;
        

        public VoteService(IVoteServiceData voteServiceData, 
                           IMeasureRuleServiceData measureRuleServiceData)
        {
            _voteServiceData = voteServiceData;
            _measureRuleServiceData = measureRuleServiceData;
        }

        public VoteResponse RegisterVote(VoteModel voteModel)
        {
            return null;
        }

        public VoteResultResponse GetVoteResult(long measureId)
        {
            var voteEntities = _voteServiceData.Get(measureId);

            if (!voteEntities.Any())
            {
                return new VoteResultResponse
                {
                    Result = VoteResult.Failed.ToString()
                };
            }

            var numberOfVoteYes = 0;
            var numberOfVetos = 0;
            var totalVotes = 0;

            foreach (var vote in voteEntities)
            { 
                switch (vote.VoteType)
                {
                    case VoteType.Yes:
                        ++numberOfVoteYes;
                        break;
                    case VoteType.Veto:
                        ++numberOfVetos;
                        break;                         
                }
            }

            totalVotes = voteEntities.Count();

            var measureRules = _measureRuleServiceData.GetId(measureId);
            var userWhoVotedList = voteEntities.Select(i => i.UserName).ToList();

            var result = VoteResult.Passed;

            if(!IsMininumOfVotesRuleValid(totalVotes,measureRules.MinNumberOfVotes))
                result = VoteResult.Failed;
            else if (!IsMininumPercentageofYesRuleValid(totalVotes, numberOfVoteYes, measureRules.MinPercentageOfYes))
            {
                result = VoteResult.Failed;
            }else if(!IsSpecificNameMustVoteForItPassRuleValid(measureRules.UserNamesMustVoteToPassList.Select(i => i.Name).ToList(),
                userWhoVotedList
                ))
            {
                result = VoteResult.Failed;
            }

            return new VoteResultResponse { Names = userWhoVotedList,
            Result = result.ToString()
            };
        }

        private bool IsMininumOfVotesRuleValid(int totalVotes, int minVotes)
        {
            if(totalVotes >= minVotes)
                return true;
            else
                return false;
        }

        private bool IsMininumPercentageofYesRuleValid(int totalVotes, int totalVoteYes, int minpercentageOfYes)
        {
            var minOfVoteYesRequired = ((decimal)totalVotes) * minpercentageOfYes / 100;
            if (minOfVoteYesRequired <= totalVoteYes)
                return true;
            else
                return false;
        }

        private bool IsSpecificNameMustVoteForItPassRuleValid(List<string> namesMustForItPassList, List<string> nameVotedList)
        {
            if(namesMustForItPassList == null)
            {
                return true;
            }

            if (nameVotedList.Any( item=> namesMustForItPassList.Contains(item))){
                return false;
            }

            return true;
        }
    }
}
