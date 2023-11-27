using CongestionTaxCalculator.Application.DTOs.City;
using CongestionTaxCalculator.Application.DTOs.Common;
using CongestionTaxCalculator.Application.DTOs.Vehicle;
using Newtonsoft.Json;

namespace CongestionTaxCalculator.Application.DTOs.TaxExemptVehicles
{
    public class TaxExemptVehiclesDto : BaseDto<long>
    {

        public int CityId { get; set; }
        public int VehicleId { get; set; }

        //public CityDto City { get; set; }
        //public VehicleDto Vehicle { get; set; }

    }
}
