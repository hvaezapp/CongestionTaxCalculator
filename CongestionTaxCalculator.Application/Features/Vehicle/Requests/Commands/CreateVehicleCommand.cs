using CongestionTaxCalculator.Application.DTOs.Vehicle;
using CongestionTaxCalculator.Application.Responses;
using MediatR;

namespace CongestionTaxCalculator.Application.Features.Vehicle.Requests.Commands
{
    public class CreateVehicleCommand : IRequest<BaseCommandResponse>
    {
        public CreateVehicleDto CreateVehicleDto { get; set; }
    }
}
