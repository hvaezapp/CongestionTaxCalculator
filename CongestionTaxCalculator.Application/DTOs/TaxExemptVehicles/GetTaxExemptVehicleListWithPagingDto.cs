using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Application.DTOs.TaxExemptVehicles
{
     public class GetTaxExemptVehicleListWithPagingDto
    {
        public List<TaxExemptVehiclesDto> taxExemptVehicles { get; set; }
        public int page { get; set; }


        public GetTaxExemptVehicleListWithPagingDto()
        {
            taxExemptVehicles = new List<TaxExemptVehiclesDto>();
            
        }
    }
}
