using Api.Data.Repositories;

namespace Api.Data.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        ICustomerPredictionRepository CustomerPredictions { get; }
        ICustomerRepository Customers { get; }
        IOrderRepository Orders { get; }
        IEmployeeRepository Employees { get; }
        IShipperRepository Shippers { get; }
        IProductRepository Products { get; }
        Task<int> CompleteAsync();
    }
}
