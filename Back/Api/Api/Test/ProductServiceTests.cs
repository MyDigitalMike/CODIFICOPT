using Api.Data.Repositories;
using Api.DTOs;
using Api.Services;
using Moq;
using Xunit;

namespace Api.Test
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task GetProducts_ShouldReturnProducts()
        {
            // Arrange
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.GetAllProductsAsync())
                    .ReturnsAsync(new List<ProductDto>
                    {
                    new ProductDto { ProductId = 1, ProductName = "Product A" },
                    new ProductDto { ProductId = 2, ProductName = "Product B" }
                    });

            var service = new ProductService(mockRepo.Object);

            // Act
            var result = await service.GetAllProductsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal("Product A", result.First().ProductName);
        }
    }
}
