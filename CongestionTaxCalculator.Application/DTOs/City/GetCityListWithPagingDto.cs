using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Application.DTOs.City
{
    public class GetCityListWithPagingDto
    {
        public List<CityDto> cities { get; set; }
        public int page { get; set; }

        public GetCityListWithPagingDto()
        {
            cities = new List<CityDto>();
        }
    }
}
