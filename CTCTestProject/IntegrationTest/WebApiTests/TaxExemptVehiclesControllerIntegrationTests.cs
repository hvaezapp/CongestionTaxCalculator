using CongestionTaxCalculator.Application.DTOs.Holiday;
using CongestionTaxCalculator.Application.DTOs.TaxExemptVehicles;
using CongestionTaxCalculator.Infrastructure.Const;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC_Test.IntegrationTest.WebApiTests
{
    public class TaxExemptVehiclesControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public TaxExemptVehiclesControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri(DefaultConst.ApiBaseUrl)
            });
        }

        [Fact]
        public async Task GetAll_Tax_Exempt_Vehicles()
        {
            // Arrange
            int page = 1;

            // Act
            var response = await _client.GetAsync($"TaxExemptVehicles/GetAll?page={page}");


            // Assert
            response.EnsureSuccessStatusCode();
        }


        [Fact]
        public async Task Create_Tax_Exempt_Vehicles()
        {
            // Arrange
            int cityId = 3;
            int vehicleId = 14;
            var createHolidayDto = new CreateTaxExemptVehiclesDto(cityId,vehicleId);

            // Act
            var jsonContent = JsonConvert.SerializeObject(createHolidayDto);
            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("TaxExemptVehicles/Create", stringContent);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }

}
