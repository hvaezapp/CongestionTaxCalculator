using CongestionTaxCalculator.Application.DTOs.City;
using CongestionTaxCalculator.Application.DTOs.Holiday;
using CongestionTaxCalculator.Application.Features.City.Requests.Commands;
using CongestionTaxCalculator.Application.Features.City.Requests.Queries;
using CongestionTaxCalculator.Application.Features.Holiday.Requests.Commands;
using CongestionTaxCalculator.Application.Features.Holiday.Requests.Queries;
using CongestionTaxCalculator.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace CongestionTaxCalculator.Api.Controllers.v1
{
    [ApiVersion("1", Deprecated = false)]
    public class HolidayController : BaseController
    {
        private readonly IMediator _mediator;

        public HolidayController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<HolidayController>
        [HttpGet("[action]")]
        public async Task<ActionResult<BaseCommandResponse>> GetAll(int page , CancellationToken cancellationToken)
        {
            var cities = await _mediator.Send(new GetHolidayListRequest() { Page = page }, cancellationToken);
            return Ok(cities);

        }


        // POST api/<HolidayController>
        [HttpPost("[action]")]
        public async Task<ActionResult<BaseCommandResponse>> Create([FromBody] CreateHolidayDto createHolidayDto,CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new CreateHolidayCommand { CreateHolidayDto = createHolidayDto }, cancellationToken);
            return Ok(response);

        }

    }
}
