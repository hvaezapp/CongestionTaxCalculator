using CongestionTaxCalculator.Application.Contracts.Persistence;
using CongestionTaxCalculator.Domain.Entity;

namespace CongestionTaxCalculator.Persistence.Repositories
{
    public class CongestionTaxHistoryRepository : GenericRepository<CongestionTaxHistory>, ICongestionTaxHistoryRepository
    {
        private readonly CongestionTaxCalculatorDbContext _dbContext;

        public CongestionTaxHistoryRepository(CongestionTaxCalculatorDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }



    }
}
