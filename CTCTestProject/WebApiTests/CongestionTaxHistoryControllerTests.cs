using CongestionTaxCalculator.Api.Controllers.v1;
using CongestionTaxCalculator.Application.DTOs.CongestionTaxHistory;
using CongestionTaxCalculator.Application.Features.CongestionTaxHistory.Requests.Commands;
using CongestionTaxCalculator.Application.Features.CongestionTaxHistory.Requests.Queries;
using CongestionTaxCalculator.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CTCTestProject.WebApiTests
{
    public class CongestionTaxHistoryControllerTests
    {
        private readonly CongestionTaxHistoryController _controller;
        private readonly Mock<IMediator> _mediatorMock;


        public CongestionTaxHistoryControllerTests()
        {

            _mediatorMock = new Mock<IMediator>();
            _controller = new CongestionTaxHistoryController(_mediatorMock.Object);

        }


        [Fact]
        public async Task GetAll_ShouldReturnCongestionTaxHistory()
        {
            // Arrange

            var page = 1;
            var cancellationToken = CancellationToken.None;


            var expectedResponse = new BaseCommandResponse();
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetCongestionTaxHistoryListRequest>(), cancellationToken))
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
        public async Task Create_ShouldCreateCongestionTaxHistory()
        {
            // Arrange

            var createCongestionTaxHistoryDto = new CreateCongestionTaxHistoryDto(1, 1, new());
            var cancellationToken = CancellationToken.None;


            var expectedResponse = new BaseCommandResponse();
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateCongestionTaxHistoryCommand>(), cancellationToken))
                        .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.Create(createCongestionTaxHistoryDto, cancellationToken);

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
