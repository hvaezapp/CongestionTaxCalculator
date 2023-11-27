using CongestionTaxCalculator.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Domain.Entity
{
    public class CongestionTaxHistory : BaseDomainEntity<long>
    {
        public Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        //public DateTime CrossDateTime { get; set; }
        //public bool CrossFromTollingStation { get; set; }
        public double TaxAmount { get; set; }



        public CongestionTaxHistory()
        {

        }

        public CongestionTaxHistory(int vehicleId , 
                      int cityId , double taxAmount)

        {
            VehicleId = vehicleId;
            CityId = cityId;
            //CrossDateTime = congestionDateTime;
            TaxAmount = taxAmount;
            //CrossFromTollingStation = crossFromTollingStation;
        }

        public void Edit(int vehicleId,
           int cityId,
           double taxAmount)
        {
            VehicleId = vehicleId;
            CityId = cityId;
            //CrossDateTime = congestionDateTime;
            TaxAmount = taxAmount;
            //CrossFromTollingStation = crossFromTollingStation;
        }


    }
}
