using CongestionTaxCalculator.Application.Contracts.Persistence;
using CongestionTaxCalculator.Domain.Entity;

namespace CongestionTaxCalculator.Persistence.Repositories
{ 
    public class VehicleRepository : GenericRepository<Vehicle> , IVehicleRepository
    {
        private readonly CongestionTaxCalculatorDbContext _dbContext;

        public VehicleRepository(CongestionTaxCalculatorDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }



    }
}
