using CongestionTaxCalculator.Application.Contracts.Persistence;
using CongestionTaxCalculator.Domain.Entity;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CongestionTaxCalculator.Persistence.Repositories
{
    public class CityRepository : GenericRepository<City>, ICityRepository 
    {
        private readonly CongestionTaxCalculatorDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private IDbConnection _db;

        public CityRepository(CongestionTaxCalculatorDbContext dbContext, IConfiguration configuration)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _db = new SqlConnection(_configuration.GetConnectionString("CongestionTaxCalculatorConnectionString"));
        }


        public async Task<IEnumerable<City>> GetAllWithPagingWithDapper(int skip , int take, CancellationToken cancellationToken)
        {
            try
            {
                string getAllCityQuery = $"SELECT * FROM City ORDER BY Id OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY";
                return await _db.QueryAsync<City>(getAllCityQuery);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
