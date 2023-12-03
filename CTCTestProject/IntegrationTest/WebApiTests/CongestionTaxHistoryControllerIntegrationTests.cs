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
using CongestionTaxCalculator.Application.DTOs.CongestionTaxHistory;

namespace CTC_Test.IntegrationTest.WebApiTests
{
    public class CongestionTaxHistoryControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public CongestionTaxHistoryControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri(DefaultConst.ApiBaseUrl)
            });
        }

        [Fact]
        public async Task GetAll_Congestion_Tax_History()
        {
            // Arrange
            int page = 1;

            // Act
            var response = await _client.GetAsync($"CongestionTaxHistory/GetAll?page={page}");


            // Assert
            response.EnsureSuccessStatusCode();
        }

      

        [Fact]
        public async Task Create_Congestion_Tax_History()
        {
            // Arrange
            int vehicleId = 14;
            int cityId = 3;
            var crossInfo = new List<CrossInfoDto>
            {
                new CrossInfoDto(DateTime.Now, false ,false),
                new CrossInfoDto(DateTime.Now.AddDays(1), false ,false)

            };

            var createCityDto = new CreateCongestionTaxHistoryDto(vehicleId, cityId, crossInfo);

            // Act
            var jsonContent = JsonConvert.SerializeObject(createCityDto);
            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("CongestionTaxHistory/Create", stringContent);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
