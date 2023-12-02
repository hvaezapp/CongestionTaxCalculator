using CongestionTaxCalculator.Api.Controllers.v1;
using CongestionTaxCalculator.Application.DTOs.Vehicle;
using CongestionTaxCalculator.Application.Features.Vehicle.Requests.Commands;
using CongestionTaxCalculator.Application.Features.Vehicle.Requests.Queries;
using CongestionTaxCalculator.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace CTCTestProject.WebApiTests
{
    public class VehicleControllerTests
    {
        private readonly VehicleController _controller;
        private readonly Mock<IMediator> _mediatorMock;

        private readonly ILogger<VehicleControllerTests> _logger;

        public VehicleControllerTests()
        {

            _mediatorMock = new Mock<IMediator>();
            _controller = new VehicleController(_mediatorMock.Object);
            _logger = new LoggerFactory().CreateLogger<VehicleControllerTests>();

        }

        [Fact]
        public async Task GetAll_ShouldReturnListOfVehicles()
        {
            // Arrange
            var page = 1;
            var cancellationToken = CancellationToken.None;

            var expectedResponse = new BaseCommandResponse();
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetVehicleListRequest>(), cancellationToken))
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
        public async Task GetById_ShouldReturnVehicleById()
        {
            // Arrange
            var id = 1;
            var cancellationToken = CancellationToken.None;

            var expectedResponse = new BaseCommandResponse();
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetVehicleByIdRequest>(), cancellationToken))
                         .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetById(id, cancellationToken);


            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<BaseCommandResponse>(okResult.Value);


            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);

            Assert.NotNull(model);
            Assert.Same(expectedResponse, model);

        }

        [Fact]
        public async Task Create_ShouldCreateVehicle()
        {
            // Arrange
            var createVehicleDto = new CreateVehicleDto("Test Vehicle", null);

            var cancellationToken = CancellationToken.None;


            var expectedResponse = new BaseCommandResponse();
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateVehicleCommand>(), cancellationToken))
                         .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.Create(createVehicleDto, cancellationToken);

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
