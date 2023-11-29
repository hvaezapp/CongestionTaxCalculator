using CongestionTaxCalculator.Application.DTOs.Common;
using CongestionTaxCalculator.Domain.Entity;
using CongestionTaxCalculator.Infrastructure.Enums;

namespace CongestionTaxCalculator.Application.DTOs.City
{
    public class CityDto : BaseDto<int>
    {
        public string Name { get; set; }
        public bool IsTaxChargedInDuringFixedHours { get; set; }
        public bool IsSingleChargeRule { get; set; }
        public bool IsAvailableInWeekend { get; set; }
        public bool IsAvailableInHoliday { get; set; }
        public bool IsAvailableInBeforeHoliday { get; set; }
        public bool IsAvailableInDuringJuly { get; set; }
        public double MaxTaxAmountPerDay { get; set; }
        public CurrencyType CurrencyType { get; set; }

    }
}
