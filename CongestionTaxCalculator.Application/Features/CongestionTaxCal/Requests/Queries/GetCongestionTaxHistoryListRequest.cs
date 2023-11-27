using CongestionTaxCalculator.Application.DTOs.City;
using CongestionTaxCalculator.Application.DTOs.Vehicle;
using CongestionTaxCalculator.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Application.Features.CongestionTaxCal.Requests.Queries
{
    public class GetCongestionTaxHistoryListRequest : IRequest<BaseCommandResponse>
    {
        public int Page { get; set; }
    }
}
