using CongestionTaxCalculator.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Application.Features.TaxExemptVehicles.Requests.Queries
{
    public class GetTaxExemptVehiclesListRequest : IRequest<BaseCommandResponse>
    {
        public int Page { get; set; } 
    }
}
