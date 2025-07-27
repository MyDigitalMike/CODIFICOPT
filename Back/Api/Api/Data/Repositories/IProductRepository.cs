using Api.DTOs;
using Api.Models;

namespace Api.Data.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    }
}
