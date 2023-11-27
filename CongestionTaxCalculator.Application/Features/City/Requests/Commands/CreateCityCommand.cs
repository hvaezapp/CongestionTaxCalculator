using CongestionTaxCalculator.Application.DTOs.City;
using CongestionTaxCalculator.Application.Responses;
using MediatR;

namespace CongestionTaxCalculator.Application.Features.City.Requests.Commands
{
    public class CreateCityCommand : IRequest<BaseCommandResponse>
    {
        public CreateCityDto CreateCityDto { get; set; }
    }
}
