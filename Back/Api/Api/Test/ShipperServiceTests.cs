using Api.Data.Repositories;
using Api.DTOs;
using Api.Services;
using Moq;
using Xunit;

namespace Api.Test
{
    public class ShipperServiceTests
    {
        [Fact]
        public async Task GetShippers_ShouldReturnShipperList()
        {
            // Arrange
            var mockRepo = new Mock<IShipperRepository>();
            mockRepo.Setup(repo => repo.GetAllShippersAsync())
                .ReturnsAsync(new List<ShipperDto>
                {
                new ShipperDto { ShipperId = 1, CompanyName = "Shipper 1" },
                new ShipperDto { ShipperId = 2, CompanyName = "Shipper 2" }
                });

            var service = new ShipperService(mockRepo.Object);

            // Act
            var result = (await service.GetAllShippersAsync()).ToList();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }
    }
}
