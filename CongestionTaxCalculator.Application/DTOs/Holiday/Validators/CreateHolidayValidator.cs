using CongestionTaxCalculator.Application.DTOs.City;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Application.DTOs.Holiday.Validators
{
    public class CreateHolidayValidator : AbstractValidator<CreateHolidayDto>
    {
        public CreateHolidayValidator()
        {

            RuleFor(p => p.HolidayDate).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
             
        }
    }
}
