using CongestionTaxCalculator.Domain.Common;
using CongestionTaxCalculator.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;

namespace CongestionTaxCalculator.Domain.Entity
{
    public class City : BaseDomainEntity<int>
    {
        public string Name { get; set; }

        // City Rules

        public bool IsTaxChargedInDuringFixedHours { get; set; }

        public bool IsSingleChargeRule { get; set; }

        public bool IsAvailableInWeekend { get; set; }

        public bool IsAvailableInHoliday { get; set; }

        public bool IsAvailableInBeforeHoliday { get; set; }

        public bool IsAvailableInDuringJuly { get; set; }

        public double MaxTaxAmountPerDay { get; set; }

        public CurrencyType CurrencyType { get; set; }


        public ICollection<CongestionTaxHistory> congestionTaxHistories { get; set; }
        public ICollection<CongestionTaxRule>  congestionTaxRules { get; set; }

        public ICollection<TaxExemptVehicles> taxExemptVehicles { get; set; }

        public City()
        {
            congestionTaxHistories = new List<CongestionTaxHistory>(); 
            congestionTaxRules = new List<CongestionTaxRule>();
            taxExemptVehicles = new List<TaxExemptVehicles>();
        }

        public City(string name, bool isTaxChargedInDuringFixedHours,
            bool isSingleChargeRule, bool isAvailableInWeekend,
            bool isAvailableInHoliday , bool isAvailableInBeforeHoliday ,
            bool isAvailableInDuringJuly , double maxTaxAmountPerDay ,
             CurrencyType currencyType):this()
        {
            Name = name;
            IsTaxChargedInDuringFixedHours = isTaxChargedInDuringFixedHours;
            IsSingleChargeRule = isSingleChargeRule;
            IsAvailableInWeekend = isAvailableInWeekend;
            IsAvailableInHoliday = isAvailableInHoliday;
            IsAvailableInBeforeHoliday = isAvailableInBeforeHoliday;
            IsAvailableInDuringJuly = isAvailableInDuringJuly;
            MaxTaxAmountPerDay = maxTaxAmountPerDay;
            CurrencyType = currencyType;
        }


        public void Edit(string name, bool isTaxChargedInDuringFixedHours,
            bool isSingleChargeRule, bool isAvailableInWeekend,
            bool isAvailableInHoliday, bool isAvailableInBeforeHoliday,
            bool isAvailableInDuringJuly, double maxTaxAmountPerDay,
             CurrencyType currencyType)
        {
            Name = name;
            IsTaxChargedInDuringFixedHours = isTaxChargedInDuringFixedHours;
            IsSingleChargeRule = isSingleChargeRule;
            IsAvailableInWeekend = isAvailableInWeekend;
            IsAvailableInHoliday = isAvailableInHoliday;
            IsAvailableInBeforeHoliday = isAvailableInBeforeHoliday;
            IsAvailableInDuringJuly = isAvailableInDuringJuly;
            MaxTaxAmountPerDay = maxTaxAmountPerDay;
            CurrencyType = currencyType;
        }



        // nav

        public ICollection<CongestionTaxHistory> CongestionHistories { get; set; }

        public ICollection<CongestionTaxRule> CongestionTaxRules { get; set; }
        public ICollection<TaxExemptVehicles> TaxExemptVehicles { get; set; }

    }

   
}
