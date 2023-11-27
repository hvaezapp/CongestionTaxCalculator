using CongestionTaxCalculator.Application.DTOs.TaxExemptVehicles;
using CongestionTaxCalculator.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Application.Features.TaxExemptVehicles.Requests.Commands
{
    public class CreateTaxExemptVehiclesCommand : IRequest<BaseCommandResponse>
    {
        public CreateTaxExemptVehiclesDto CreateTaxExemptVehiclesDto { get; set; }
    }
}
