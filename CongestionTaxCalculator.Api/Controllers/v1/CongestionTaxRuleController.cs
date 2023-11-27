using CongestionTaxCalculator.Application.DTOs.CongestionTaxRule;
using CongestionTaxCalculator.Application.Features.CongestionTaxRule.Requests.Commands;
using CongestionTaxCalculator.Application.Features.CongestionTaxRule.Requests.Queries;
using CongestionTaxCalculator.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CongestionTaxCalculator.Api.Controllers.v1
{
    [ApiVersion("1", Deprecated = false)]
    public class CongestionTaxRuleController : BaseController
    {
        private readonly IMediator _mediator;

        public CongestionTaxRuleController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<CongestionTaxRuleController>
        [HttpGet("[action]")]
        public async Task<ActionResult<BaseCommandResponse>> GetByCityId(int id = 1)
        {
            var cities = await _mediator.Send(new GetCongestionTaxByCityRequest() { CityId = id });
            return Ok(cities);

        }


        // POST api/<CongestionTaxRuleController>
        [HttpPost("[action]")]
        public async Task<ActionResult<BaseCommandResponse>> Create([FromBody] CreateCongestionTaxRuleDto createCongestionTaxRuleDto)
        {
            var response = await _mediator.Send(new CreateCongestionTaxRuleCommand { createCongestionTaxRuleDto = createCongestionTaxRuleDto });
            return Ok(response);

        }


    }
}
