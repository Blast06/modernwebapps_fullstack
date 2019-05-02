using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;
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
            optionsBuilder.UseSqlServer(Settings.ConnectionString);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Customer> Customer { get; set; }        
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<User>().Ignore(c => c.Notifications);
            modelBuilder.Entity<Customer>().Ignore(c => c.Notifications);
            modelBuilder.Entity<Product>().Ignore(c => c.Notifications);
            modelBuilder.Entity<Order>().Ignore(c => c.Notifications);
            modelBuilder.Entity<OrderItem>().Ignore(c => c.Notifications);
            modelBuilder.Entity<Customer>().Ignore(c => c.Email);
            modelBuilder.Entity<Customer>().Ignore(c => c.Document);
            modelBuilder.Entity<Customer>().Ignore(c => c.Name);

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderItemMap());

            //modelBuilder.Ignore<Customer>();
            //modelBuilder.Ignore<Document>();
            //modelBuilder.Ignore<Email>();
            //modelBuilder.Ignore<Name>();
            //modelBuilder.Ignore<Order>();
            //modelBuilder.Ignore<OrderItem>();

            //modelBuilder.ApplyConfiguration(new UserMap());
            //modelBuilder.ApplyConfiguration(new ProductMap());

            //new CustomerMap(modelBuilder.Entity<Customer>());
            //new ProductMap(modelBuilder.Entity<Product>());
            //new UserMap(modelBuilder.Entity<User>());
            //new OrderMap(modelBuilder.Entity<Order>());
            //new OrderItemMap(modelBuilder.Entity<OrderItem>());

            base.OnModelCreating(modelBuilder);
        }

        
    }
}