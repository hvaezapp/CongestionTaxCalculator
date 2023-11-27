using CongestionTaxCalculator.Domain.Common;

namespace CongestionTaxCalculator.Domain.Entity
{
    public class Holiday : BaseDomainEntity<long>
    {
        public DateTime HolidayDate { get; set; }

        public Holiday()
        {

        }

        public Holiday(DateTime holidayDate)
        {
            HolidayDate = holidayDate;
        }

        public void Edit(DateTime holidayDat)
        {
            HolidayDate = holidayDat;
        }


    }
}
