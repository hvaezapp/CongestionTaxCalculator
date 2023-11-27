using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Application.DTOs.CongestionTaxRule
{
    public record CreateCongestionTaxRuleDto(int CityId, string FromTime, string ToTime, double TaxAmount);
}
