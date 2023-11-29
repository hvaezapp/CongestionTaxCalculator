using CongestionTaxCalculator.Application.DTOs.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Application.DTOs.Holiday
{
    public class GetHolidayListWithPagingDto
    {
        public List<HolidayDto> holidays { get; set; }
        public int page { get; set; }

        public GetHolidayListWithPagingDto()
        {
            holidays = new List<HolidayDto>();
        }
    }
}
