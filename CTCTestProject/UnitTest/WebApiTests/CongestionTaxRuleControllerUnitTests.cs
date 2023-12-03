using CongestionTaxCalculator.Api.Controllers.v1;
using CongestionTaxCalculator.Application.DTOs.CongestionTaxRule;
using CongestionTaxCalculator.Application.Features.CongestionTaxRule.Requests.Commands;
using CongestionTaxCalculator.Application.Features.CongestionTaxRule.Requests.Queries;
using CongestionTaxCalculator.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CTC_Test.UnitTest.WebApiTests
{
    public class CongestionTaxRuleControllerUnitTests
    {

        private readonly CongestionTaxRuleController _controller;
        private readonly Mock<IMediator> _mediatorMock;


        public CongestionTaxRuleControllerUnitTests()
        {

            _mediatorMock = new Mock<IMediator>();
            _controller = new CongestionTaxRuleController(_mediatorMock.Object);


        }


        [Fact]
        public async Task GetByCityId_ShouldReturnCongestionTaxRules()
        {
            // Arrange

            var cityId = 1;
            var cancellationToken = CancellationToken.None;


            var expectedResponse = new BaseCommandResponse();
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetCongestionTaxByCityRequest>(), cancellationToken))
                        .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetByCityId(cityId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<BaseCommandResponse>(okResult.Value);

            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);

            Assert.NotNull(model);
            Assert.Same(expectedResponse, model);

        }

        [Fact]
        public async Task Create_ShouldCreateCongestionTaxRule()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;
            var createCongestionTaxRuleDto = new CreateCongestionTaxRuleDto(1, "07:00", "07:10", 13); // Initialize DTO with data

            var expectedResponse = new BaseCommandResponse();
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateCongestionTaxRuleCommand>(), cancellationToken))
                        .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.Create(createCongestionTaxRuleDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<BaseCommandResponse>(okResult.Value);

            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);

            Assert.NotNull(model);
            Assert.Same(expectedResponse, model);

        }


    }
}
