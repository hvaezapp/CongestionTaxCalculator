using CongestionTaxCalculator.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CongestionTaxCalculator.Persistence.Configurations.Entities
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {

            builder.HasKey(a => a.Id);
            builder.HasQueryFilter(a => !a.IsDeleted);

        }
    }
}
