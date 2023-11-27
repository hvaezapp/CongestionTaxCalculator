using CongestionTaxCalculator.Application.Responses;
using MediatR;

namespace CongestionTaxCalculator.Application.Features.Vehicle.Requests.Queries
{
    public class GetVehicleListRequest : IRequest<BaseCommandResponse>
    {
        public int Page { get; set; }

    }
}
