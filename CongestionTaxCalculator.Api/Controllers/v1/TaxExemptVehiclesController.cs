using CongestionTaxCalculator.Application.DTOs.City;
using CongestionTaxCalculator.Application.DTOs.TaxExemptVehicles;
using CongestionTaxCalculator.Application.Features.City.Requests.Commands;
using CongestionTaxCalculator.Application.Features.City.Requests.Queries;
using CongestionTaxCalculator.Application.Features.TaxExemptVehicles.Requests.Commands;
using CongestionTaxCalculator.Application.Features.TaxExemptVehicles.Requests.Queries;
using CongestionTaxCalculator.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace CongestionTaxCalculator.Api.Controllers.v1
{

    [ApiVersion("1", Deprecated = false)]
    public class TaxExemptVehiclesController : BaseController
    {
        private readonly IMediator _mediator;

        public TaxExemptVehiclesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<TaxExemptVehiclesController>
        [HttpGet("[action]")]
        public async Task<ActionResult<BaseCommandResponse>> GetAll(int page  , CancellationToken cancellationToken)
        {
            var cities = await _mediator.Send(new GetTaxExemptVehiclesListRequest() { Page = page }, cancellationToken);
            return Ok(cities);

        }


        // POST api/<TaxExemptVehiclesController>
        [HttpPost("[action]")]
        public async Task<ActionResult<BaseCommandResponse>> Create([FromBody] CreateTaxExemptVehiclesDto createTaxExemptVehiclesDto , CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new CreateTaxExemptVehiclesCommand { CreateTaxExemptVehiclesDto = createTaxExemptVehiclesDto }, cancellationToken);
            return Ok(response);

        }


    }
}
