using Domain.Entities.DTOResults;
using Domain.Interfaces;
using Moq;
using Service.Services;
using System.Collections.Generic;
using Xunit;

namespace Service.Tests
{
    public class RouteServiceTests
    {
        private readonly RouteService _routeService;
        private readonly Mock<IRouteRepository> _routeRepositoryMock;

        public RouteServiceTests()
        {
            _routeRepositoryMock = new Mock<IRouteRepository>();
            _routeService = new RouteService(_routeRepositoryMock.Object);
        }

        [Fact]
        public void CheckCheapestRoute_ShouldCallCheckCheapestRouteOnRepository()
        {
            // Arrange
            var origin = "GRU";
            var destination = "CDG";
            var expected = new List<RankedRouteDTO>();
            _routeRepositoryMock.Setup(x => x.CheckCheapestRoute(origin, destination))
                .Returns(expected);

            // Act
            var result = _routeService.CheckCheapestRoute(origin, destination);

            // Assert
            _routeRepositoryMock.Verify(x => x.CheckCheapestRoute(origin, destination), Times.Once);
            Assert.Equal(expected, result);
        }
    }
}