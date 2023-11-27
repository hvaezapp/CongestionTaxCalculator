using CongestionTaxCalculator.Application.DTOs.City;
using CongestionTaxCalculator.Application.Features.City.Requests.Commands;
using CongestionTaxCalculator.Application.Features.City.Requests.Queries;
using CongestionTaxCalculator.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CongestionTaxCalculator.Api.Controllers.v1
{

    [ApiVersion("1", Deprecated = false)]
    public class CityController : BaseController
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<CityController>
        [HttpGet("[action]")]
        public async Task<ActionResult<BaseCommandResponse>> GetAll(int page  , CancellationToken cancellationToken)
        {
            var cities = await _mediator.Send(new GetCityListRequest() { Page = page } , cancellationToken);
            return Ok(cities);

        }

        // GET: api/<CityController>
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<BaseCommandResponse>> GetById(int id , CancellationToken cancellationToken)
        {
            var cities = await _mediator.Send(new GetCityByIdRequest() { CityId = id } , cancellationToken);
            return Ok(cities);

        }


        // POST api/<CityController>
        [HttpPost("[action]")]
        public async Task<ActionResult<BaseCommandResponse>> Create([FromBody] CreateCityDto createCityDto, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new CreateCityCommand { CreateCityDto = createCityDto }, cancellationToken);
            return Ok(response);

        }


    }
}
