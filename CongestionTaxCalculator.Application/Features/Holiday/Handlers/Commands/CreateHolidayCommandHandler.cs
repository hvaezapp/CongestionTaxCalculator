using AutoMapper;
using CongestionTaxCalculator.Application.Contracts.Persistence;
using CongestionTaxCalculator.Application.DTOs.Holiday;
using CongestionTaxCalculator.Application.DTOs.Holiday.Validators;
using CongestionTaxCalculator.Application.Features.Holiday.Requests.Commands;
using CongestionTaxCalculator.Application.Responses;
using MediatR;

namespace CongestionTaxCalculator.Application.Features.Holiday.Handlers.Commands
{
    public class CreateHolidayCommandHandler : IRequestHandler<CreateHolidayCommand, BaseCommandResponse>
    {

        private readonly IHolidayRepository _holidayRepository;
        private readonly IMapper _mapper;

        public CreateHolidayCommandHandler(IHolidayRepository holidayRepository
           , IMapper mapper)
        {
            _holidayRepository = holidayRepository;
            _mapper = mapper;

        }


        public async Task<BaseCommandResponse> Handle(CreateHolidayCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            try
            {
                var validator = new CreateHolidayValidator();

                var validationResult = await validator.ValidateAsync(request.CreateHolidayDto);

                if (validationResult.IsValid == false)
                {
                    var Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    response.Failure(errors: Errors);
                }
                else
                {

                    var holiday = _mapper.Map<Domain.Entity.Holiday>(request.CreateHolidayDto);
                    holiday = await _holidayRepository.Create(holiday, cancellationToken);
                    await _holidayRepository.SaveChanges(cancellationToken);

                    response.Success(data:_mapper.Map<HolidayDto>(holiday));

                }
            }
            catch (Exception ex)
            {
                response.Failure(message: ex.Message.ToString());
            }

            return response;
        }
    }
}
