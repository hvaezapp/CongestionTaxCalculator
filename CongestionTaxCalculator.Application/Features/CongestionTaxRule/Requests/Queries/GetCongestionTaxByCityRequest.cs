using CongestionTaxCalculator.Application.Responses;
using CongestionTaxCalculator.Domain.Entity;
using MediatR;

namespace CongestionTaxCalculator.Application.Features.CongestionTaxRule.Requests.Queries
{
    public class GetCongestionTaxByCityRequest : IRequest<BaseCommandResponse>
    {
        public int CityId { get; set; }

    }
}
