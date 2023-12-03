using CongestionTaxCalculator.Application.DTOs.City;
using CongestionTaxCalculator.Application.DTOs.CongestionTaxRule;
using CongestionTaxCalculator.Infrastructure.Const;
using CongestionTaxCalculator.Infrastructure.Enums;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC_Test.IntegrationTest.WebApiTests
{
    public class CongestionTaxRuleControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public CongestionTaxRuleControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri(DefaultConst.ApiBaseUrl)
            });
        }

        [Fact]
        public async Task GetAll_ReturnsSuccessStatusCode()
        {
            // Arrange
            int page = 1;

            // Act
            var response = await _client.GetAsync($"City/GetAll?page={page}");


            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetByCityId_Congestion_Tax_Rule()
        {
            // Arrange
            var cityId = 3;


            // Act
            var response = await _client.GetAsync($"CongestionTaxRule/GetByCityId/{cityId}");


            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Create_Congestion_Tax_Rule()
        {
            // Arrange
            var createCongestionTaxRuleDto = new CreateCongestionTaxRuleDto(3,"06:00", "06:29", 40);

            // Act
            var jsonContent = JsonConvert.SerializeObject(createCongestionTaxRuleDto);
            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("CongestionTaxRule/Create", stringContent);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }

}
