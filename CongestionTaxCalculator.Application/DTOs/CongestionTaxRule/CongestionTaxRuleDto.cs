using CongestionTaxCalculator.Application.DTOs.City;
using CongestionTaxCalculator.Application.DTOs.Common;

namespace CongestionTaxCalculator.Application.DTOs.CongestionTaxRule
{
    public class CongestionTaxRuleDto : BaseDto<long>
    {
        public CityDto City { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public double TaxAmount { get; set; }

    }
}
