using CongestionTaxCalculator.Api.Controllers.v1;
using CongestionTaxCalculator.Application.DTOs.TaxExemptVehicles;
using CongestionTaxCalculator.Application.Features.TaxExemptVehicles.Requests.Commands;
using CongestionTaxCalculator.Application.Features.TaxExemptVehicles.Requests.Queries;
using CongestionTaxCalculator.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CTCTestProject.WebApiTests
{
    public class TaxExemptVehiclesControllerTests
    {
        private readonly TaxExemptVehiclesController _controller;
        private readonly Mock<IMediator> _mediatorMock;



        public TaxExemptVehiclesControllerTests()
        {

            _mediatorMock = new Mock<IMediator>();
            _controller = new TaxExemptVehiclesController(_mediatorMock.Object);


        }


        [Fact]
        public async Task GetAll_ShouldReturnListOfTaxExemptVehicles()
        {
            // Arrange
            var page = 1;
            var cancellationToken = CancellationToken.None;


            var expectedResponse = new BaseCommandResponse();
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetTaxExemptVehiclesListRequest>(), cancellationToken))
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
        public async Task Create_ShouldCreateTaxExemptVehicle()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var controller = new TaxExemptVehiclesController(mediatorMock.Object);
            var createTaxExemptVehiclesDto = new CreateTaxExemptVehiclesDto(1, 1);
            var cancellationToken = CancellationToken.None;


            var expectedResponse = new BaseCommandResponse();
            mediatorMock.Setup(m => m.Send(It.IsAny<CreateTaxExemptVehiclesCommand>(), cancellationToken))
                        .ReturnsAsync(expectedResponse);

            // Act
            var result = await controller.Create(createTaxExemptVehiclesDto, cancellationToken);

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
