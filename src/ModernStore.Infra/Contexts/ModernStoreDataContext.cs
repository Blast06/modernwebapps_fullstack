using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.Entities;
using ModernStore.Infra.Mappings;

namespace ModernStore.Infra.Contexts
{
    public class ModernStoreDataContext : DbContext
    {
        public ModernStoreDataContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\\MSSQLLocalDB;Database=ModernStore;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new CustomerMap(modelBuilder.Entity<Customer>());
            new ProductMap(modelBuilder.Entity<Product>());
            new UserMap(modelBuilder.Entity<User>());
            new OrderMap(modelBuilder.Entity<Order>());
            new OrderItemMap(modelBuilder.Entity<OrderItem>());
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }        
    }
}