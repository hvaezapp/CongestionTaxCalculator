using CongestionTaxCalculator.Application.DTOs.CongestionTaxRule;
using CongestionTaxCalculator.Application.Responses;
using MediatR;

namespace CongestionTaxCalculator.Application.Features.CongestionTaxRule.Requests.Commands
{
    public class CreateCongestionTaxRuleCommand : IRequest<BaseCommandResponse>
    {
        public CreateCongestionTaxRuleDto createCongestionTaxRuleDto { get; set; }
    }
}
