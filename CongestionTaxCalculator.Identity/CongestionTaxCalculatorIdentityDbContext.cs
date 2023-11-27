using CongestionTaxCalculator.Identity.Configurations;
using CongestionTaxCalculator.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculator.Identity
{
    public class CongestionTaxCalculatorIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public CongestionTaxCalculatorIdentityDbContext(DbContextOptions<CongestionTaxCalculatorIdentityDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
