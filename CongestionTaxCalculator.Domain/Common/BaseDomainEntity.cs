using System.ComponentModel.DataAnnotations;

namespace CongestionTaxCalculator.Domain.Common
{
    public abstract class BaseDomainEntity<T> where T : struct
    {
        //[Key]
        public T Id { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }


        public BaseDomainEntity()
        {
            IsDeleted = false;
            DateCreated = DateTime.Now;
        }


        public DateTime GetDateCreated()
        {
            return DateCreated;
        }


        public T GetId()
        {
            return Id;
        }


        public void Delete()
        {
            IsDeleted = true;
        }


    }
}
