using CounselVoting.Domain.Model;
using CounselVoting.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace CounselVoting.Api.Controllers
{
    [ApiController]
    [Route("measurerules")]
    public class MeasureRulesController : ControllerBase
    {        
        private readonly IMeasureRuleServiceData service;

        public MeasureRulesController(IMeasureRuleServiceData service)
        {            
            this.service = service;
        }

        [HttpPost]
        public MeasureRuleModel Post([FromBody] MeasureRuleModel measureRuleModel)
        {
            
            service.Insert(measureRuleModel);
            return measureRuleModel;
        }
    }
}
