using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Application.DTOs.CongestionTaxHistory
{
    public class GetCongestionTaxHistoryListWithPagingDto
    {
        public List<GetCongestionTaxHistoryDto> congestionTaxHistories { get; set; }
        public int page { get; set; }

        public GetCongestionTaxHistoryListWithPagingDto()
        {
            congestionTaxHistories = new List<GetCongestionTaxHistoryDto>();
           
        }
    }
}
