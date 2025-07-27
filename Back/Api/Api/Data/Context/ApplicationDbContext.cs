using Microsoft.EntityFrameworkCore;
using Api.Models;
using Api.DTOs;
namespace Api.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<CustomerPrediction> CustomerPredictions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerPrediction>().HasNoKey();
            modelBuilder.Entity<ClientOrderDto>().HasNoKey(); 
            modelBuilder.Entity<EmployeeDto>().HasNoKey();
            modelBuilder.Entity<ShipperDto>().HasNoKey();
            modelBuilder.Entity<ProductDto>().HasNoKey();
            modelBuilder.Entity<NewOrderIdDto>().HasNoKey();
        }
    }
}
