using AutoMapper;
using CongestionTaxCalculator.Application.Contracts.Persistence;
using CongestionTaxCalculator.Application.DTOs.City.Validators;
using CongestionTaxCalculator.Application.DTOs.City;
using CongestionTaxCalculator.Application.Features.TaxExemptVehicles.Requests.Commands;
using CongestionTaxCalculator.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CongestionTaxCalculator.Application.DTOs.TaxExemptVehicles.Validators;
using CongestionTaxCalculator.Application.DTOs.TaxExemptVehicles;

namespace CongestionTaxCalculator.Application.Features.TaxExemptVehicles.Handlers.Commands
{
    public class CreateTaxExemptVehiclesCommandHandler : IRequestHandler<CreateTaxExemptVehiclesCommand, BaseCommandResponse>
    {
        private readonly ITaxExemptVehiclesRepository _taxExemptVehiclesRepository;
        private readonly IMapper _mapper;

        public CreateTaxExemptVehiclesCommandHandler(ITaxExemptVehiclesRepository taxExemptVehiclesRepository,
            IMapper mapper)
        {
            _taxExemptVehiclesRepository = taxExemptVehiclesRepository;
            _mapper = mapper;
        }


        public async Task<BaseCommandResponse> Handle(CreateTaxExemptVehiclesCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            try
            {
                var validator = new CreateTaxExemptVehiclesValidator();

                var validationResult = await validator.ValidateAsync(request.CreateTaxExemptVehiclesDto);

                if (validationResult.IsValid == false)
                {
                    var Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    response.Failure(errors: Errors);
                }
                else
                {

                    var taxExemptVehicles = _mapper.Map<Domain.Entity.TaxExemptVehicles>(request.CreateTaxExemptVehiclesDto);
                    taxExemptVehicles = await _taxExemptVehiclesRepository.Create(taxExemptVehicles, cancellationToken);
                    await _taxExemptVehiclesRepository.SaveChanges(cancellationToken);

                    response.Success(data: new { id = taxExemptVehicles.Id  } );

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
