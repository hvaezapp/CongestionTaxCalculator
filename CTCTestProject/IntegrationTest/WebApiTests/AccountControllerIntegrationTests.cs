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
using CongestionTaxCalculator.Application.Models.Identity;

namespace CTC_Test.IntegrationTest.WebApiTests
{
    public class AccountControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public AccountControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri(DefaultConst.ApiBaseUrl)
            });
        }

        [Fact]
        public async Task Login_Account()
        {
            // Arrange
            var login = new AuthRequest
            {
                Email = "admin@localhost.com",
                Password = "@Hwpro123"
            };

            // Act
            var jsonContent = JsonConvert.SerializeObject(login);
            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("Account/Login", stringContent);


            // Assert
            response.EnsureSuccessStatusCode();
        }


        [Fact]
        public async Task Register_Account()
        {
            // Arrange

            var register = new RegisterationRequest
            {
                FirstName = "Hassan",
                LastName = "Vaezzade",
                Email = "hassanvaez2445@gmail.com",
                Password = "@Hwpro123",
                UserName = "hwpro2020"
                
            };

            // Act
            var jsonContent = JsonConvert.SerializeObject(register);
            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("Account/Register", stringContent);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
