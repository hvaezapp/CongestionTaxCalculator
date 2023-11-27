using CongestionTaxCalculator.Application.Contracts.Persistence;
using CongestionTaxCalculator.Domain.Entity;

namespace CongestionTaxCalculator.Persistence.Repositories
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        private readonly CongestionTaxCalculatorDbContext _dbContext;

        public CityRepository(CongestionTaxCalculatorDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }



    }
}
