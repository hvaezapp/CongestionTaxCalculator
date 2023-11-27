using CongestionTaxCalculator.Application.DTOs.Vehicle;
using CongestionTaxCalculator.Application.Features.Vehicle.Requests.Commands;
using CongestionTaxCalculator.Application.Features.Vehicle.Requests.Queries;
using CongestionTaxCalculator.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CongestionTaxCalculator.Api.Controllers.v1
{
    [ApiVersion("1", Deprecated = false)]
    public class VehicleController : BaseController
    {
        private readonly IMediator _mediator;

        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<VehicleController>
        [HttpGet("[action]")]
        public async Task<ActionResult<BaseCommandResponse>> GetAll(int page , CancellationToken cancellationToken)
        {
            var cities = await _mediator.Send(new GetVehicleListRequest() { Page = page } , cancellationToken);
            return Ok(cities);

        }


        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<BaseCommandResponse>> GetById(int id , CancellationToken cancellationToken)
        {
            var cities = await _mediator.Send(new GetVehicleByIdRequest() { VehicleId = id }, cancellationToken);
            return Ok(cities);

        }


        // POST api/<VehicleController>
        [HttpPost("[action]")]
        public async Task<ActionResult<BaseCommandResponse>> Create([FromBody] CreateVehicleDto createVehicleDto , CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new CreateVehicleCommand { CreateVehicleDto = createVehicleDto }, cancellationToken);
            return Ok(response);

        }
    }
}
