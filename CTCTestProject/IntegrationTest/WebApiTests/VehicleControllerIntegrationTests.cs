using CongestionTaxCalculator.Application.DTOs.City;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CongestionTaxCalculator.Infrastructure.Enums;
using CongestionTaxCalculator.Infrastructure.Const;
using CongestionTaxCalculator.Application.DTOs.Vehicle;

namespace CTC_Test.IntegrationTest.WebApiTests
{
    public class VehicleControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public VehicleControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri(DefaultConst.ApiBaseUrl)
            });
        }

        [Fact]
        public async Task GetAll_Vehicle()
        {
            // Arrange
            int page = 1;

            // Act
            var response = await _client.GetAsync($"Vehicle/GetAll?page={page}");


            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetById_Vehicle()
        {
            // Arrange
            var vehicleId = 14;


            // Act
            var response = await _client.GetAsync($"Vehicle/GetById/{vehicleId}");


            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Create_Vehicle()
        {
            // Arrange
            var createCityDto = new CreateVehicleDto("Bus");
            

            // Act
            var jsonContent = JsonConvert.SerializeObject(createCityDto);
            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("Vehicle/Create", stringContent);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
