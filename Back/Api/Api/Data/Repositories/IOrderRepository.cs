using Api.DTOs;
using Api.Models;

namespace Api.Data.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<ClientOrderDto>> GetOrdersByCustomerAsync(int customerId);
        Task<int> AddNewOrderWithProductsAsync(OrderDto orderDto);
    }
}
