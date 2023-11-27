using CongestionTaxCalculator.Application.DTOs.City;
using CongestionTaxCalculator.Application.DTOs.Common;
using CongestionTaxCalculator.Application.DTOs.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Application.DTOs.CongestionTaxHistory
{

    public class GetCongestionTaxHistoryDto : BaseDto<long>
    {

        public CityDto City { get; set; }
        public VehicleDto Vehicle { get; set; }
        public double TaxAmount { get; set; }
    }
   //  public record GetCongestionTaxHistoryDto(CityDto City, VehicleDto Vehicle, double TaxAmount);
}
