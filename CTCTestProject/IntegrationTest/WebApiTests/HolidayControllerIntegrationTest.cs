using CongestionTaxCalculator.Application.DTOs.City;
using CongestionTaxCalculator.Application.DTOs.Holiday;
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
    public class HolidayControllerIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public HolidayControllerIntegrationTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri(DefaultConst.ApiBaseUrl)
            });
        }

        [Fact]
        public async Task GetAll_Holiday_Dates()
        {
            // Arrange
            int page = 1;

            // Act
            var response = await _client.GetAsync($"Holiday/GetAll?page={page}");


            // Assert
            response.EnsureSuccessStatusCode();
        }


        [Fact]
        public async Task Create_Holiday_Date()
        {
            // Arrange
            var date = DateTime.Now.Date;
            var createHolidayDto = new CreateHolidayDto(date);

            // Act
            var jsonContent = JsonConvert.SerializeObject(createHolidayDto);
            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("Holiday/Create", stringContent);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }

}
