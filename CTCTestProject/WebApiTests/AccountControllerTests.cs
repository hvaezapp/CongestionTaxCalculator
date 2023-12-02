using CongestionTaxCalculator.Api.Controllers.v1;
using CongestionTaxCalculator.Application.Contracts.Identity;
using CongestionTaxCalculator.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CTCTestProject.WebApiTests
{
    public class AccountControllerTests
    {
        private readonly Mock<IAuthService> authServiceMock;
        private readonly AccountController controller;

        public AccountControllerTests()
        {
            authServiceMock = new Mock<IAuthService>();
            controller = new AccountController(authServiceMock.Object);
        }


        [Fact]
        public async Task Login_ShouldReturnAuthResponse()
        {
            // Arrange

            var authRequest = new AuthRequest();


            var expectedResponse = new AuthResponse();
            authServiceMock.Setup(m => m.Login(authRequest))
                                    .ReturnsAsync(expectedResponse);

            // Act
            var result = await controller.Login(authRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<AuthResponse>(okResult.Value);

            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);

            Assert.NotNull(model);
            Assert.Same(expectedResponse, model);
        }

        [Fact]
        public async Task Register_ShouldReturnRegistrationResponse()
        {
            // Arrange

            var registerationRequest = new RegisterationRequest();


            var expectedResponse = new RegistrationResponse();
            authServiceMock.Setup(m => m.Register(registerationRequest))
                                         .ReturnsAsync(expectedResponse);

            // Act
            var result = await controller.Register(registerationRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<RegistrationResponse>(okResult.Value);


            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);

            Assert.NotNull(model);
            Assert.Same(expectedResponse, model);
        }
    }
}
