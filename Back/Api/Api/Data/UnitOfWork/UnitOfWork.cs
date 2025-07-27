using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repositories;
using Api.Models;
namespace Api.Data.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Customers = new CustomerRepository(_context);
            Orders = new OrderRepository(_context);
            Employees = new EmployeeRepository(_context);
            Shippers = new ShipperRepository(_context);
            Products = new ProductRepository(_context);
            CustomerPredictions = new CustomerPredictionRepository(_context);
        }
        public ICustomerPredictionRepository CustomerPredictions { get; private set; }
        public ICustomerRepository Customers { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IEmployeeRepository Employees { get; private set; }
        public IShipperRepository Shippers { get; private set; }
        public IProductRepository Products { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
