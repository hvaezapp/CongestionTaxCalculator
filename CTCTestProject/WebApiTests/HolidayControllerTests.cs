using CongestionTaxCalculator.Api.Controllers.v1;
using CongestionTaxCalculator.Application.DTOs.Holiday;
using CongestionTaxCalculator.Application.Features.Holiday.Requests.Commands;
using CongestionTaxCalculator.Application.Features.Holiday.Requests.Queries;
using CongestionTaxCalculator.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CTCTestProject.WebApiTests
{
    public class HolidayControllerTests
    {
        private readonly HolidayController _controller;
        private readonly Mock<IMediator> _mediatorMock;


        public HolidayControllerTests()
        {

            _mediatorMock = new Mock<IMediator>();
            _controller = new HolidayController(_mediatorMock.Object);


        }

        [Fact]
        public async Task GetAll_ShouldReturnListOfHolidays()
        {
            // Arrange

            var page = 1;
            var cancellationToken = CancellationToken.None;

            var expectedResponse = new BaseCommandResponse();
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetHolidayListRequest>(), cancellationToken))
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
        public async Task Create_ShouldCreateHoliday()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var controller = new HolidayController(mediatorMock.Object);
            var createHolidayDto = new CreateHolidayDto(DateTime.Now);
            var cancellationToken = CancellationToken.None;

            var expectedResponse = new BaseCommandResponse();
            mediatorMock.Setup(m => m.Send(It.IsAny<CreateHolidayCommand>(), cancellationToken))
                        .ReturnsAsync(expectedResponse);

            // Act
            var result = await controller.Create(createHolidayDto, cancellationToken);

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
