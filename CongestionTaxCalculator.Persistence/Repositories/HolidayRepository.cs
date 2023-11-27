using CongestionTaxCalculator.Application.Contracts.Persistence;
using CongestionTaxCalculator.Domain.Entity;

namespace CongestionTaxCalculator.Persistence.Repositories
{
    public class HolidayRepository : GenericRepository<Holiday>, IHolidayRepository
    {
        private readonly CongestionTaxCalculatorDbContext _dbContext;

        public HolidayRepository(CongestionTaxCalculatorDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }



    }
}
