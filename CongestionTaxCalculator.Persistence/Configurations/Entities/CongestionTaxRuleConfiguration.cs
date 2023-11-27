using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CongestionTaxCalculator.Domain.Entity;

namespace CongestionTaxCalculator.Persistence.Configurations.Entities
{
    public class CongestionTaxRuleConfiguration : IEntityTypeConfiguration<CongestionTaxRule>
    {
        public void Configure(EntityTypeBuilder<CongestionTaxRule> builder)
        {

            builder.HasKey(a => a.Id);
            builder.HasQueryFilter(a=> !a.IsDeleted);

        }
    }
}
