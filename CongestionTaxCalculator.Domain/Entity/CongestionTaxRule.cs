using CongestionTaxCalculator.Domain.Common;

namespace CongestionTaxCalculator.Domain.Entity
{
    public class CongestionTaxRule : BaseDomainEntity<long>
    {
        public City City { get; set; }
        public int CityId { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public double TaxAmount { get; set; }


        public CongestionTaxRule()
        {
            
        }

        public CongestionTaxRule(int cityId , DateTime fromtime , 
            DateTime totime , double taxamount )
        {
            CityId = cityId;
            FromTime = fromtime;
            ToTime = totime;
            TaxAmount = taxamount;
        }


        public void Edit(int cityId, DateTime fromtime,
            DateTime totime, double taxamount)
        {
            CityId = cityId;
            FromTime = fromtime;
            ToTime = totime;
            TaxAmount = taxamount;
        }


        public void Delete()
        {
            IsDeleted = true;
        }

    }
}
