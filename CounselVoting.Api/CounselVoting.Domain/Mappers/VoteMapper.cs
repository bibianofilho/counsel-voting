using CounselVoting.Domain.Model;
using CounselVoting.Domain.ViewModel;
using System;

namespace CounselVoting.Domain.Mappers
{
    public class VoteMapper : IMapper<VoteModel, VoteRequest>
    {
        public VoteModel ToEntity(VoteRequest model)
        {
            if (model == null) return null;

            return new VoteModel
            {
                MeasureId = model.MeasureId,
                UserName = model.UserName,
                VoteType = model.VoteType,
                VotedAt = model.VotedAt,
                VoteId = model.VoteId
            };
        }

        public VoteRequest ToModel(VoteModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
