using CongestionTaxCalculator.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Application.DTOs.CongestionTaxHistory
{
    public class CongestionTaxHistoryDto : BaseDto<long>
    {

        public int CityId { get; set; }
        public int VehicleId { get; set; }
        public double TaxAmount { get; set; }
    }
}
