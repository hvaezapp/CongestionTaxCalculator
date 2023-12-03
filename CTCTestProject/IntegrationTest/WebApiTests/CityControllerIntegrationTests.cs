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

namespace CTC_Test.IntegrationTest.WebApiTests
{
    public class CityControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public CityControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri(DefaultConst.ApiBaseUrl)
            });
        }

        [Fact]
        public async Task GetAll_City()
        {
            // Arrange
            int page = 1;

            // Act
            var response = await _client.GetAsync($"City/GetAll?page={page}");


            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetById_City()
        {
            // Arrange
            var cityId = 1;


            // Act
            var response = await _client.GetAsync($"City/GetById/{cityId}");


            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Create_City()
        {
            // Arrange
            var createCityDto = new CreateCityDto("Germany", true, false, true,
                                    false, false, false, 10,
                                    CurrencyType.DOLLAR);

            // Act
            var jsonContent = JsonConvert.SerializeObject(createCityDto);
            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("City/Create", stringContent);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
