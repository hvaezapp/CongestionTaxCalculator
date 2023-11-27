using CongestionTaxCalculator.Application.DTOs.Holiday;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Application.DTOs.TaxExemptVehicles.Validators
{
    public class CreateTaxExemptVehiclesValidator : AbstractValidator<CreateTaxExemptVehiclesDto>
    {
        public CreateTaxExemptVehiclesValidator()
        {

            RuleFor(p => p.CityId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.VehicleId).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");

        }
    }
}
