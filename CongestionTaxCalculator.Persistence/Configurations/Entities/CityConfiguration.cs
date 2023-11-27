using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CongestionTaxCalculator.Domain.Entity;

namespace CongestionTaxCalculator.Persistence.Configurations.Entities
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {

            builder.HasKey(a => a.Id);
            builder.HasQueryFilter(a=> !a.IsDeleted);

            //builder.HasData(
            //    new City
            //    {
            //        Id = 1,
            //        Name = "Germany",
            //    },
            //     new City
            //     { 
            //         Id = 2 , 
            //         Name = "Usa",
            //     }
            // );
        }
    }
}
