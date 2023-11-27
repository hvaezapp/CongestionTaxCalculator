using FluentValidation;

namespace CongestionTaxCalculator.Application.DTOs.CongestionTaxRule.Validators
{
    public class CreateCongestionTaxRuleValidator : AbstractValidator<CreateCongestionTaxRuleDto>
    {
        public CreateCongestionTaxRuleValidator()
        {

            RuleFor(p => p.CityId).NotNull().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.FromTime).NotNull().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.ToTime).NotNull().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.TaxAmount).NotNull().WithMessage("{PropertyName} is required.");


        }

    }
}
