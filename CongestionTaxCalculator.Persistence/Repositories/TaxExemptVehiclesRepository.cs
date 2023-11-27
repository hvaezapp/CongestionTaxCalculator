using CongestionTaxCalculator.Application.Contracts.Persistence;
using CongestionTaxCalculator.Domain.Entity;

namespace CongestionTaxCalculator.Persistence.Repositories
{
    public class TaxExemptVehiclesRepository : GenericRepository<TaxExemptVehicles>, ITaxExemptVehiclesRepository
    {
        private readonly CongestionTaxCalculatorDbContext _dbContext;

        public TaxExemptVehiclesRepository(CongestionTaxCalculatorDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }



    }
}
