using CongestionTaxCalculator.Application.DTOs.Holiday;
using CongestionTaxCalculator.Application.Responses;
using MediatR;

namespace CongestionTaxCalculator.Application.Features.Holiday.Requests.Commands
{
    public class CreateHolidayCommand : IRequest<BaseCommandResponse>
    {
        public CreateHolidayDto CreateHolidayDto { get; set; }

    }
}
