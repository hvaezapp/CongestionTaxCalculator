using AutoMapper;
using CongestionTaxCalculator.Application.Contracts.Persistence;
using CongestionTaxCalculator.Application.DTOs.City;
using CongestionTaxCalculator.Application.DTOs.City.Validators;
using CongestionTaxCalculator.Application.Features.City.Requests.Commands;
using CongestionTaxCalculator.Application.Responses;
using CongestionTaxCalculator.Domain.Entity;
using MediatR;


namespace CongestionTaxCalculator.Application.Features.City.Handlers.Commands
{
    public class CreateCityCommandHandler
        : IRequestHandler<CreateCityCommand, BaseCommandResponse>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CreateCityCommandHandler(ICityRepository cityRepository,
            IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse();

            try
            {
                var validator = new CreateCityValidator();

                var validationResult = await validator.ValidateAsync(request.CreateCityDto);

                if (validationResult.IsValid == false)
                {
                    var Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    response.Failure(errors: Errors);
                }
                else
                {

                    var city = _mapper.Map<Domain.Entity.City>(request.CreateCityDto);
                    city = await _cityRepository.Create(city, cancellationToken);
                    await _cityRepository.SaveChanges(cancellationToken);

                    response.Success(data: _mapper.Map<CityDto>(city));

                }
            }
            catch (Exception ex)
            {
                throw;
                //response.Failure(message: ex.Message.ToString());
            }

            return response;
        }
    }
}
