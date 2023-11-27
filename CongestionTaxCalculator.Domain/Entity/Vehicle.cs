using CongestionTaxCalculator.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace CongestionTaxCalculator.Domain.Entity
{
    public class Vehicle : BaseDomainEntity<int>
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }

        //[ForeignKey(nameof(ParentId))]
        public Vehicle? ParentVehicle { get; set; }


        public Vehicle()
        {

        }

        public Vehicle(string name , int parentId)
        {
            Name = name;
            ParentId = parentId;


        }

        public void Edit(string name)
        {
            Name = name;
        }


   


        // nav

        public ICollection<CongestionTaxHistory> CongestionHistories { get; set; }
        public ICollection<TaxExemptVehicles> TaxExemptVehicles { get; set; }


    }
}
