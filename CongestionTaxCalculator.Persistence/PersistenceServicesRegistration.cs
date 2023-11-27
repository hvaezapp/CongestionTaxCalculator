using CongestionTaxCalculator.Application.Contracts.Persistence;
using CongestionTaxCalculator.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CongestionTaxCalculator.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddDbContext<CongestionTaxCalculatorDbContext>(options =>
            {
                options.UseSqlServer(configuration
                    .GetConnectionString("CongestionTaxCalculatorConnectionString"));
            });


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IHolidayRepository, HolidayRepository>();
            services.AddScoped<ITaxExemptVehiclesRepository, TaxExemptVehiclesRepository>();
            services.AddScoped<ICongestionTaxRuleRepository, CongestionRuleRepository>();
            services.AddScoped<ICongestionTaxHistoryRepository, CongestionTaxHistoryRepository>();


            return services;
        }
    }
}
