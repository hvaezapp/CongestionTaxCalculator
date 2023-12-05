using CongestionTaxCalculator.Domain.Entity;
using CongestionTaxCalculator.Infrastructure.Enums;
using CongestionTaxCalculator.Persistence;
using CongestionTaxCalculator.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CTC_Test.RepositoryTest
{
    public class CityRepositoryTests : IDisposable
    {
        private readonly CongestionTaxCalculatorDbContext _dbContext;
        private readonly GenericRepository<City> _repository;

        public CityRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<CongestionTaxCalculatorDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Using in-memory database for testing
                .Options;

            _dbContext = new CongestionTaxCalculatorDbContext(options);
            _repository = new GenericRepository<City>(_dbContext);
        }





        [Fact]
        public async Task Create_City_AddedToDatabase()
        {
            // Arrange
            var entity = new City
            {
                Name = "Canada",
                IsAvailableInBeforeHoliday = true,
                IsAvailableInDuringJuly = true,
                IsAvailableInHoliday = false,
                IsAvailableInWeekend = false,
                IsSingleChargeRule = false,
                IsTaxChargedInDuringFixedHours = false,
                CurrencyType = CurrencyType.CAD
            };

            // Act
            var result = await _repository.Create(entity, CancellationToken.None);
            await _repository.SaveChanges(CancellationToken.None);

            // Assert
            Assert.NotNull(result);

        }


        [Fact]
        public async Task Update_City_InDatabase()
        {
            // Arrange
            var entity = new City
            {
                Name = "Canada",
                IsAvailableInBeforeHoliday = true,
                IsAvailableInDuringJuly = true,
                IsAvailableInHoliday = false,
                IsAvailableInWeekend = false,
                IsSingleChargeRule = false,
                IsTaxChargedInDuringFixedHours = false,
                CurrencyType = CurrencyType.CAD
            };

            await _repository.Create(entity, CancellationToken.None);
            await _repository.SaveChanges(CancellationToken.None);

            entity.Name  = "France";

            // Act
            await _repository.Update(entity);
            await _repository.SaveChanges(CancellationToken.None);


            // Assert
            var updatedEntity = await _repository.GetByIdAsync(entity.Id,
                                            CancellationToken.None);
            Assert.NotNull(updatedEntity);
            Assert.Equal("France", updatedEntity.Name);
            
        }


        [Fact]
        public async Task Delete_City_FromDatabase()
        {
            // Arrange
            var entity = new City
            {
                Name = "Canada",
                IsAvailableInBeforeHoliday = true,
                IsAvailableInDuringJuly = true,
                IsAvailableInHoliday = false,
                IsAvailableInWeekend = false,
                IsSingleChargeRule = false,
                IsTaxChargedInDuringFixedHours = false,
                CurrencyType = CurrencyType.CAD
            };
            await _repository.Create(entity, CancellationToken.None);
            await _repository.SaveChanges(CancellationToken.None);


            // Act
            await _repository.Delete(entity);
            await _repository.SaveChanges(CancellationToken.None);


            // Assert
            var deletedEntity = await _repository.GetByIdAsync(entity.Id,
                                CancellationToken.None);
            Assert.Null(deletedEntity);
            
        }



        [Fact]
        public async Task GetByIdAsync_City_FromDatabase()
        {
            // Arrange
            var entity = new City
            {
                Name = "Canada",
                IsAvailableInBeforeHoliday = true,
                IsAvailableInDuringJuly = true,
                IsAvailableInHoliday = false,
                IsAvailableInWeekend = false,
                IsSingleChargeRule = false,
                IsTaxChargedInDuringFixedHours = false,
                CurrencyType = CurrencyType.CAD
            };
            await _repository.Create(entity, CancellationToken.None);
            await _repository.SaveChanges(CancellationToken.None);

            // Act
            var retrievedEntity = await _repository.GetByIdAsync(entity.Id, CancellationToken.None);

            // Assert
            Assert.NotNull(retrievedEntity);
        }



        [Fact]
        public async Task GetAllAsync_City_WithCondition_ReturnsMatchingEntities()
        {
            // Arrange
            var entity = new City
            {
                Name = "Canada",
                IsAvailableInBeforeHoliday = true,
                IsAvailableInDuringJuly = true,
                IsAvailableInHoliday = false,
                IsAvailableInWeekend = false,
                IsSingleChargeRule = false,
                IsTaxChargedInDuringFixedHours = false,
                CurrencyType = CurrencyType.CAD
            };
            await _repository.Create(entity, CancellationToken.None);
            await _repository.SaveChanges(CancellationToken.None);


            // Act
            var retrievedEntities = await _repository
                                    .GetAllAsync(e => e.CurrencyType == CurrencyType.CAD,
                                     CancellationToken.None);

            // Assert
            Assert.NotNull(retrievedEntities);
            Assert.Equal(1, retrievedEntities.Count());
        }




        [Fact]
        public async Task GetAllAsyncWithPaging_City_WithCondition_PagingWorks()
        {
            // Arrange
            var entity1 = new City
            {
                Name = "Canada",
                IsAvailableInBeforeHoliday = true,
                IsAvailableInDuringJuly = true,
                IsAvailableInHoliday = false,
                IsAvailableInWeekend = false,
                IsSingleChargeRule = false,
                IsTaxChargedInDuringFixedHours = false,
                CurrencyType = CurrencyType.CAD
            };

            var entity2 = new City
            {
                Name = "Usa",
                IsAvailableInBeforeHoliday = true,
                IsAvailableInDuringJuly = true,
                IsAvailableInHoliday = false,
                IsAvailableInWeekend = true,
                IsSingleChargeRule = true,
                IsTaxChargedInDuringFixedHours = false,
                CurrencyType = CurrencyType.DOLLAR
            };

            var entity3 = new City
            {
                Name = "Turkey",
                IsAvailableInBeforeHoliday = true,
                IsAvailableInDuringJuly = true,
                IsAvailableInHoliday = false,
                IsAvailableInWeekend = false,
                IsSingleChargeRule = true,
                IsTaxChargedInDuringFixedHours = false,
                CurrencyType = CurrencyType.LIR
            };

            await _repository.Create(entity1, CancellationToken.None);
            await _repository.Create(entity2, CancellationToken.None);
            await _repository.Create(entity3, CancellationToken.None);
            await _repository.SaveChanges(CancellationToken.None);

            int skip = 0;
            int take = 2;

            // Act
            var retrievedEntities = await _repository.GetAllAsyncWithPaging(
                e => e.IsSingleChargeRule == true, skip: skip, take: take, 
                CancellationToken.None);

            // Assert
            Assert.NotNull(retrievedEntities);
            Assert.Equal(2, retrievedEntities.Count()); 
        }




        [Fact]
        public async Task GetAsync_City_WithConditions_ReturnsMatchingEntities()
        {
            // Arrange
            var entity1 = new City
            {
                Name = "Canada",
                IsAvailableInBeforeHoliday = true,
                IsAvailableInDuringJuly = true,
                IsAvailableInHoliday = false,
                IsAvailableInWeekend = false,
                IsSingleChargeRule = false,
                IsTaxChargedInDuringFixedHours = false,
                CurrencyType = CurrencyType.CAD
            };

            var entity2 = new City
            {
                Name = "Usa",
                IsAvailableInBeforeHoliday = true,
                IsAvailableInDuringJuly = true,
                IsAvailableInHoliday = false,
                IsAvailableInWeekend = true,
                IsSingleChargeRule = true,
                IsTaxChargedInDuringFixedHours = false,
                CurrencyType = CurrencyType.DOLLAR
            };

            await _repository.Create(entity1, CancellationToken.None);
            await _repository.Create(entity2, CancellationToken.None);
            await _repository.SaveChanges(CancellationToken.None);

            // Act
            var retrievedEntities = await _repository.GetAsync(
                e => e.CurrencyType == CurrencyType.DOLLAR,
                orderBy => orderBy.OrderBy(e => e.Id),
                "CongestionTaxRules,TaxExemptVehicles",
                CancellationToken.None);

            // Assert
            Assert.NotNull(retrievedEntities);
        }



        [Fact]
        public async Task GetSingleAsync_City_WithCondition_ReturnsSingleEntity()
        {
            // Arrange
            var entity1 = new City
            {
                Name = "Canada",
                IsAvailableInBeforeHoliday = true,
                IsAvailableInDuringJuly = true,
                IsAvailableInHoliday = false,
                IsAvailableInWeekend = false,
                IsSingleChargeRule = false,
                IsTaxChargedInDuringFixedHours = false,
                CurrencyType = CurrencyType.CAD
            };
            var entity2 = new City
            {
                Name = "Usa",
                IsAvailableInBeforeHoliday = true,
                IsAvailableInDuringJuly = true,
                IsAvailableInHoliday = true,
                IsAvailableInWeekend = false,
                IsSingleChargeRule = true,
                IsTaxChargedInDuringFixedHours = false,
                CurrencyType = CurrencyType.DOLLAR
            };

            await _repository.Create(entity1, CancellationToken.None);
            await _repository.Create(entity2, CancellationToken.None);
            await _repository.SaveChanges(CancellationToken.None);


            // Act
            var retrievedEntity = await _repository.GetSingleAsync(
                e => e.Name == "Usa",
                CancellationToken.None);


            // Assert
            Assert.NotNull(retrievedEntity);
           
        }



        [Fact]
        public async Task GetAsync_City_WithJoin_ReturnsSingleEntityWithIncludes()
        {
            // Arrange
            var entity1 = new City
            {
                Name = "Canada",
                IsAvailableInBeforeHoliday = true,
                IsAvailableInDuringJuly = true,
                IsAvailableInHoliday = false,
                IsAvailableInWeekend = false,
                IsSingleChargeRule = false,
                IsTaxChargedInDuringFixedHours = false,
                CurrencyType = CurrencyType.CAD
            };
            var entity2 = new City
            {
                Name = "Usa",
                IsAvailableInBeforeHoliday = true,
                IsAvailableInDuringJuly = true,
                IsAvailableInHoliday = true,
                IsAvailableInWeekend = false,
                IsSingleChargeRule = true,
                IsTaxChargedInDuringFixedHours = false,
                CurrencyType = CurrencyType.DOLLAR
            };

            await _repository.Create(entity1, CancellationToken.None);
            await _repository.Create(entity2, CancellationToken.None);
            await _repository.SaveChanges(CancellationToken.None);

            // Act
            var retrievedEntity = await _repository.GetAsync(
                e => e.Id == entity1.Id,
                "CongestionTaxRules,TaxExemptVehicles",
                CancellationToken.None);


            // Assert
            Assert.NotNull(retrievedEntity);
        }



        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }

}
