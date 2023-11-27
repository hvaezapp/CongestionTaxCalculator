using FluentValidation;

namespace CongestionTaxCalculator.Application.DTOs.Vehicle.Validators
{
    public class CreateVehicleValidator : AbstractValidator<CreateVehicleDto>
    {
        public CreateVehicleValidator()
        {

            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull()
              .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50");


        }
    }
}
