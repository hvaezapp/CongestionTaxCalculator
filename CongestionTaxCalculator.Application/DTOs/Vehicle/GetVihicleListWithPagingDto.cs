using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Application.DTOs.Vehicle
{
    public class GetVihicleListWithPagingDto
    {
        public List<VehicleDto> vehicles { get; set; }
        public int page { get; set; }


        public GetVihicleListWithPagingDto()
        {
            vehicles = new List<VehicleDto>();
            
        }
    }
}
