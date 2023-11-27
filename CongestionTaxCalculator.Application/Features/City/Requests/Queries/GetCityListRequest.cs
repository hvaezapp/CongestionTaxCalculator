using CongestionTaxCalculator.Application.DTOs.City;
using CongestionTaxCalculator.Application.Responses;
using MediatR;

namespace CongestionTaxCalculator.Application.Features.City.Requests.Queries
{
    public class GetCityListRequest : IRequest<BaseCommandResponse>
    {
        public int Page { get; set; }

        

    }
}
