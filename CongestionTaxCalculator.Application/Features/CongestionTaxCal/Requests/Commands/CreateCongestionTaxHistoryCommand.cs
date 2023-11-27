using CongestionTaxCalculator.Application.DTOs.CongestionTaxHistory;
using CongestionTaxCalculator.Application.Responses;
using MediatR;

namespace CongestionTaxCalculator.Application.Features.CongestionTaxHistory.Requests.Commands
{
    public class CreateCongestionTaxHistoryCommand : IRequest<BaseCommandResponse>
    {
        public CreateCongestionTaxHistoryDto CreateCongestionTaxHistoryDto { get; set; }

    }
}
