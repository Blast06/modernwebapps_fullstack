using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.Entities;
using ModernStore.Infra.Mappings;

namespace ModernStore.Infra.Contexts
{
    public class ModernStoreDataContext : DbContext
    {
        public ModernStoreDataContext(DbContextOptions<ModernStoreDataContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new CustomerMap(modelBuilder.Entity<Customer>());
            new ProductMap(modelBuilder.Entity<Product>());
            new UserMap(modelBuilder.Entity<User>());
            new OrderMap(modelBuilder.Entity<Order>());
            new OrderItemMap(modelBuilder.Entity<OrderItem>());
        }
    }
}