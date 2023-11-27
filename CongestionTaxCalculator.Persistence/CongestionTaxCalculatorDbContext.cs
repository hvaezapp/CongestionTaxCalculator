using Microsoft.EntityFrameworkCore;
using CongestionTaxCalculator.Domain.Common;
using CongestionTaxCalculator.Domain.Entity;

namespace CongestionTaxCalculator.Persistence
{
    public class CongestionTaxCalculatorDbContext : DbContext
    {
        public CongestionTaxCalculatorDbContext(DbContextOptions<CongestionTaxCalculatorDbContext> options)
            : base(options)
        {

        }

     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(CongestionTaxCalculatorDbContext).Assembly);
        }


        public DbSet<City> City { get; set; }
        public DbSet<TaxExemptVehicles> TaxExemptVehicles { get; set; }

        public DbSet<CongestionTaxRule> CongestionTaxRules { get; set; }

        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Holiday> Holiday { get; set; }
        public DbSet<CongestionTaxHistory> CongestionTaxHistory { get; set; }


    }
}
