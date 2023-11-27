using CongestionTaxCalculator.Application.DTOs.City;
using CongestionTaxCalculator.Application.Responses;
using MediatR;

namespace CongestionTaxCalculator.Application.Features.City.Requests.Queries
{
    public class GetCityByIdRequest : IRequest<BaseCommandResponse>
    {
        public int CityId { get; set; }

    }
}
