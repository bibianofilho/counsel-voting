using CounselVoting.Api.Service;
using CounselVoting.Api.ViewModel;
using CounselVoting.Domain.Enums;
using CounselVoting.Domain.Exceptions;
using CounselVoting.Domain.Mappers;
using CounselVoting.Domain.Model;
using CounselVoting.Domain.ViewModel;
using CounselVoting.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CounselVoting.Api.Controllers
{
    [ApiController]
    [Route("vote")]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService service;
        private readonly IVoteServiceData _voteServiceData;
        private readonly IMapper<VoteModel, VoteRequest> _voteMapper;

        public VoteController(
            IVoteService service,
            IVoteServiceData voteServiceData,
            IMapper<VoteModel, VoteRequest> voteMapper)
        {
            this.service = service;
            _voteMapper = voteMapper;
            _voteServiceData = voteServiceData;
        }


        [HttpPost]
        [Route("/api/vote")]
        public VoteResponse Post([FromBody] VoteRequest model)
        {
            try
            {
                _voteServiceData.Insert(_voteMapper.ToEntity(model));
            }
            catch (FailedVoteException)
            {

                return new VoteResponse { Result = VoteResult.Failed.ToString() };
            }
            catch (System.Exception ex)
            {
                throw;
            }

            return new VoteResponse { Result = VoteResult.Passed.ToString() };
        }


        [HttpGet]
        [Route("/api/voteMeasure/{measureId}")]
        public IEnumerable<VoteModel>  Get(long measureId)
        {         
            var measureRule = _voteServiceData.Get(measureId);
            return measureRule;
        }

        
        [HttpGet]
        [Route("/api/voteMeasure/{measureId}/result")]
        public VoteResultResponse GetResult(long measureId)
        {
            var result = service.GetVoteResult(measureId);
            return result;
        }
    }
}
