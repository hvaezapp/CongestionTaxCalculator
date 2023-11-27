using CongestionTaxCalculator.Domain.Common;
using System.Xml.Linq;

namespace CongestionTaxCalculator.Domain.Entity
{
    public class TaxExemptVehicles : BaseDomainEntity<long>
    {
        public City City { get; set; }
        public int CityId { get; set; }

        public Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }


        public TaxExemptVehicles()
        {

        }

        public TaxExemptVehicles(int cityId  , int vehicleId)
        {
            VehicleId = vehicleId;
            CityId = cityId;
        }

        public void Edit(int cityId, int vehicleId)
        {
            VehicleId = vehicleId;
            CityId = cityId;
        }


    }
}
