using CongestionTaxCalculator.Application.DTOs.CongestionTaxHistory;
using CongestionTaxCalculator.Application.Features.CongestionTaxHistory.Requests.Commands;
using CongestionTaxCalculator.Application.Features.CongestionTaxHistory.Requests.Queries;
using CongestionTaxCalculator.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CongestionTaxCalculator.Api.Controllers.v1
{

    [ApiVersion("1", Deprecated = false)]
    public class CongestionTaxHistoryController : BaseController
    {
        private readonly IMediator _mediator;
        public CongestionTaxHistoryController(IMediator mapper)
        {
            _mediator = mapper;

        }


        // GET: api/<CongestionTaxController>
        [HttpGet("[action]")]
        public async Task<ActionResult<BaseCommandResponse>> GetAll(int page, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetCongestionTaxHistoryListRequest() { Page = page }, cancellationToken);
            return Ok(response);

        }



        // GET: api/<CongestionTaxController>
        [HttpPost("[action]")]
        public async Task<ActionResult<BaseCommandResponse>> Create([FromBody] CreateCongestionTaxHistoryDto createCongestionTaxHistoryDto, CancellationToken cancellationToken)
        {

            var response = await _mediator.Send(new CreateCongestionTaxHistoryCommand { CreateCongestionTaxHistoryDto = createCongestionTaxHistoryDto }, cancellationToken);
            return Ok(response);


        }




    }
}
