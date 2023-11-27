using CongestionTaxCalculator.Application.DTOs.Common;
using CongestionTaxCalculator.Domain.Entity;

namespace CongestionTaxCalculator.Application.DTOs.Vehicle
{
    public class VehicleDto : BaseDto<int>
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
       
    }
}
