using CongestionTaxCalculator.Application.Responses;
using MediatR;

namespace CongestionTaxCalculator.Application.Features.Vehicle.Requests.Queries
{
    public class GetVehicleByIdRequest : IRequest<BaseCommandResponse>
    {
        public int VehicleId { get; set; }

    }
}
