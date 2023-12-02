using CongestionTaxCalculator.Api.Controllers.v1;
using CongestionTaxCalculator.Application.DTOs.City;
using CongestionTaxCalculator.Application.Features.City.Requests.Commands;
using CongestionTaxCalculator.Application.Features.City.Requests.Queries;
using CongestionTaxCalculator.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CTCTestProject.WebApiTests
{
    public class CityControllerTests
    {
        private readonly CityController _controller;
        private readonly Mock<IMediator> _mediatorMock;

        public CityControllerTests()
        {

            _mediatorMock = new Mock<IMediator>();
            _controller = new CityController(_mediatorMock.Object);

        }



        [Fact]
        public async Task GetAll_ShouldReturnListOfCities()
        {
            // Arrange
            var page = 1;
            var cancellationToken = CancellationToken.None;

            var expectedResponse = new BaseCommandResponse();
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetCityListRequest>(), cancellationToken))
                        .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetAll(page, cancellationToken);


            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<BaseCommandResponse>(okResult.Value);


            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);


            Assert.NotNull(model);
            Assert.Same(expectedResponse, model);
        }

        [Fact]
        public async Task GetById_ShouldReturnCityById()
        {
            // Arrange

            var cityId = 1;
            var cancellationToken = CancellationToken.None;


            var expectedResponse = new BaseCommandResponse();
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetCityByIdRequest>(), cancellationToken))
                                    .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetById(cityId, cancellationToken);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<BaseCommandResponse>(okResult.Value);

            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);

            Assert.NotNull(model);
            Assert.Same(expectedResponse, model);
        }

        [Fact]
        public async Task Create_ShouldCreateCity()
        {
            // Arrange

            var createCityDto = new CreateCityDto("Usa", true, false, true, true, false, false, 50, CongestionTaxCalculator.Infrastructure.Enums.CurrencyType.DOLLAR); // Initialize DTO with data
            var cancellationToken = CancellationToken.None;


            var expectedResponse = new BaseCommandResponse();
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateCityCommand>(), cancellationToken))
                        .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.Create(createCityDto, cancellationToken);

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
