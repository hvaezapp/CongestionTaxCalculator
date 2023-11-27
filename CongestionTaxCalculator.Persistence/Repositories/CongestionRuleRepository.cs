using CongestionTaxCalculator.Application.Contracts.Persistence;
using CongestionTaxCalculator.Domain.Entity;

namespace CongestionTaxCalculator.Persistence.Repositories
{
    public class CongestionRuleRepository : GenericRepository<CongestionTaxRule>, ICongestionTaxRuleRepository
    {
        private readonly CongestionTaxCalculatorDbContext _dbContext;

        public CongestionRuleRepository(CongestionTaxCalculatorDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }



    }
}
