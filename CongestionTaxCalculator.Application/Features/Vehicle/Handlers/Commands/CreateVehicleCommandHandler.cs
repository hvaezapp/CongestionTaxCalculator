using AutoMapper;
using CongestionTaxCalculator.Application.Contracts.Persistence;
using CongestionTaxCalculator.Application.DTOs.Vehicle;
using CongestionTaxCalculator.Application.DTOs.Vehicle.Validators;
using CongestionTaxCalculator.Application.Features.Vehicle.Requests.Commands;
using CongestionTaxCalculator.Application.Responses;
using MediatR;


namespace CongestionTaxCalculator.Application.Features.Vehicle.Handlers.Commands
{
    public class CreateVehicleCommandHandler
        : IRequestHandler<CreateVehicleCommand, BaseCommandResponse>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public CreateVehicleCommandHandler(IVehicleRepository cityRepository,
            IMapper mapper)
        {
            _vehicleRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse();

            try
            {
                var validator = new CreateVehicleValidator();

                var validationResult = await validator.ValidateAsync(request.CreateVehicleDto);

                if (validationResult.IsValid == false)
                {
                    var Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    response.Failure(errors: Errors);
                }
                else
                {

                    var vehicle = _mapper.Map<Domain.Entity.Vehicle>(request.CreateVehicleDto);
                    vehicle = await _vehicleRepository.Create(vehicle, cancellationToken);
                    await _vehicleRepository.SaveChanges(cancellationToken);

                    response.Success(data:_mapper.Map<VehicleDto>(vehicle));

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
