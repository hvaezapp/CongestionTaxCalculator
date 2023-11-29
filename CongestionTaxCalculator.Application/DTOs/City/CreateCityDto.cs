using CongestionTaxCalculator.Domain.Entity;
using CongestionTaxCalculator.Infrastructure.Enums;

namespace CongestionTaxCalculator.Application.DTOs.City
{
    public record CreateCityDto(string Name, bool IsTaxChargedInDuringFixedHours, bool IsSingleChargeRule, bool IsAvailableInWeekend, bool IsAvailableInHoliday, bool IsAvailableInBeforeHoliday, bool IsAvailableInDuringJuly, double MaxTaxAmountPerDay, CurrencyType CurrencyType);
}
