using Api.Data.Context;
using Api.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ClientOrderDto>> GetOrdersByCustomerAsync(int customerId)
        {
            var orders = await _context.Set<ClientOrderDto>()
                .FromSqlInterpolated($"EXEC GetClientOrders @CustomerId = {customerId}")
                .ToListAsync();

            return orders;
        }
        public async Task<int> AddNewOrderWithProductsAsync(OrderDto order)
        {
            try
            {
                // Crear DataTable para el parámetro de tipo tabla
                var orderDetailsTable = new DataTable();
                orderDetailsTable.Columns.Add("ProductId", typeof(int));
                orderDetailsTable.Columns.Add("UnitPrice", typeof(decimal));
                orderDetailsTable.Columns.Add("Qty", typeof(int));
                orderDetailsTable.Columns.Add("Discount", typeof(decimal));

                foreach (var detail in order.OrderDetails)
                {
                    orderDetailsTable.Rows.Add(detail.ProductId, detail.UnitPrice, detail.Qty, detail.Discount);
                }

                // Configurar los parámetros del SP
                var parameters = new[]
                {
                new SqlParameter("@Empid", order.EmpId),
                new SqlParameter("@Shipperid", order.ShipperId),
                new SqlParameter("@Shipname", order.ShipName),
                new SqlParameter("@Shipaddress", order.ShipAddress),
                new SqlParameter("@Shipcity", order.ShipCity),
                new SqlParameter("@Orderdate", order.OrderDate),
                new SqlParameter("@Requireddate", order.RequiredDate),
                new SqlParameter("@Shippeddate", (object)order.ShippedDate ?? DBNull.Value),
                new SqlParameter("@Freight", order.Freight),
                new SqlParameter("@Shipcountry", order.ShipCountry),
                new SqlParameter("@OrderDetails", SqlDbType.Structured)
                {
                    TypeName = "OrderDetailsType",
                    Value = orderDetailsTable
                }
            };

                // Llamada al SP
                var result =  _context.Set<NewOrderIdDto>()
                    .FromSqlRaw("EXEC AddNewOrderWithProducts @Empid, @Shipperid, @Shipname, @Shipaddress, @Shipcity, @Orderdate, @Requireddate, @Shippeddate, @Freight, @Shipcountry, @OrderDetails", parameters)
                    .AsEnumerable()
                    .Select(o => o.NewOrderId)
                    .FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return -1;
            }
        }
    }
}
