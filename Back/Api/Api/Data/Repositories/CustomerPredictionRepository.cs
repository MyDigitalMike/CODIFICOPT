using Api.Data.Context;
using Api.DTOs;
using Api.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace Api.Data.Repositories
{
    public class CustomerPredictionRepository: ICustomerPredictionRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerPredictionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CustomerPredictionDto>> GetCustomerPredictionsAsync(string? customerName)
        {
            var parameter = new SqlParameter("@CustomerName", customerName ?? (object)DBNull.Value);
            var predictions = await _context.CustomerPredictions
                .FromSqlRaw("EXEC GetNextOrderPrediction @CustomerName", parameter)
                .ToListAsync();

            return predictions.Select(p => new CustomerPredictionDto
            {
                CustId = p.CustId,
                CustomerName = p.CustomerName,
                LastOrderDate = p.LastOrderDate,
                NextPredictedOrder = p.NextPredictedOrder
            });
        }
    }
}
