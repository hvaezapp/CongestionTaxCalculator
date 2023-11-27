using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CongestionTaxCalculator.Domain.Entity;

namespace CongestionTaxCalculator.Persistence.Configurations.Entities
{
    public class TaxExemptVehiclesConfiguration : IEntityTypeConfiguration<TaxExemptVehicles>
    {
        public void Configure(EntityTypeBuilder<TaxExemptVehicles> builder)
        {

            builder.HasKey(a => a.Id);
            builder.HasQueryFilter(a=> !a.IsDeleted);

        
        }
    }
}
