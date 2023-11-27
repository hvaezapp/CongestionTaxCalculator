using CongestionTaxCalculator.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CongestionTaxCalculator.Persistence.Configurations.Entities
{
    public class CongestionTaxHistoryConfiguration : IEntityTypeConfiguration<CongestionTaxHistory>
    {
        public void Configure(EntityTypeBuilder<CongestionTaxHistory> builder)
        {

            builder.HasKey(a => a.Id);
            builder.HasQueryFilter(a => !a.IsDeleted);

           
        }
    }
}
