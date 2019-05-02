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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
            new CustomerMap(modelBuilder.Entity<Customer>());
            new ProductMap(modelBuilder.Entity<Product>());
            new UserMap(modelBuilder.Entity<User>());
            new OrderMap(modelBuilder.Entity<Order>());
            new OrderItemMap(modelBuilder.Entity<OrderItem>());

            modelBuilder.Entity<Customer>().Ignore(d => d.Notifications);
            modelBuilder.Entity<Product>().Ignore(d => d.Notifications);
            modelBuilder.Entity<User>().Ignore(d => d.Notifications);
            modelBuilder.Entity<Order>().Ignore(d => d.Notifications);
            modelBuilder.Entity<OrderItem>().Ignore(d => d.Notifications);
            modelBuilder.Entity<Document>().Ignore(d => d.Notifications);
            modelBuilder.Entity<Email>().Ignore(d => d.Notifications);
            modelBuilder.Entity<Name>().Ignore(d => d.Notifications);

            //this tables without PK need to get a Primary Key, if don't, EF Migration will get problem...
            modelBuilder.Entity<Document>().HasKey(t => new { t.Number });
            modelBuilder.Entity<Email>().HasKey(t => new { t.EmailAddress });
            modelBuilder.Entity<Name>().HasKey(t => new { t.LastName }); 
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }        
    }
}