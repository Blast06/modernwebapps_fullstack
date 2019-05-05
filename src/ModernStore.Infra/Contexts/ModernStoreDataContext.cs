using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.Entities;
using ModernStore.Shared.Entities;

namespace ModernStore.Infra.Contexts
{
    public class ModernStoreDataContext : DbContext
    {
        #region Important Documentation
        //This is not the BEST Model I love. Because i had to do some adapts, because EF in Core 2.2 don't recognize some things
        //like EF6 in .Net 4.6 Does. So unfortunely i had to create aditional Configurators Methods and Keys on Models... say all the
        //keys, relationship... worst than that, i had to tell EF to ignore Notifications because he's giving erros because class
        //dont' have a PK (why the hell he is trying to create a table?). I had too problems with ValueObjects - a lot of problems...
        //so i had follow this article: https://docs.microsoft.com/en-us/ef/core/modeling/relationships . If in Future EF Core
        //accepts better DDD and SOLID architecture, i should Refactory some things here and Entities . Well (or hell?), who knows...

        //RelationShip One to One: modelBuilder.Entity<Blog>().HasMany(b => b.Posts).WithOne();
        //RelationShip One to N: modelBuilder.Entity<Post>().HasOne(p => p.Blog).WithMany(b => b.Posts);
        #endregion

        #region Constructors DbSets
        public ModernStoreDataContext(DbContextOptions<ModernStoreDataContext> options) : base(options) { }
        public ModernStoreDataContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.ConnectionString);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Customer> Customer { get; set; }        
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ForSqlServerUseIdentityColumns();
            builder.HasDefaultSchema("ModernStore");

            ConfigCustomer(builder);
            ConfigUser(builder);
            ConfigProduct(builder);
            ConfigOrder(builder);
            ConfigOrderItem(builder);                      
        }
        #endregion

        #region Configure Tables
        private void ConfigUser(ModelBuilder builder)
        {
            builder.Entity<User>(etd =>
            {
                etd.ToTable("User");
                etd.HasKey(c => c.UserId);
                etd.Property(c => c.Username).IsRequired().HasMaxLength(20);
                etd.Property(c => c.Password).IsRequired().HasMaxLength(32);
                etd.Property(c => c.Active).IsRequired();
                etd.Property(c => c.CreatedBy).IsRequired();
                etd.Property(c => c.UpdatedBy).IsRequired();
                etd.Property(c => c.CreatedIn).IsRequired();
                etd.Property(c => c.UpdatedIn).IsRequired();
                etd.Ignore(c => c.Notifications);
                etd.Ignore(c => c.Customer);
            });
        }

        private void ConfigCustomer(ModelBuilder builder)
        {
            builder.Entity<Customer>(etd=>
            {
                etd.ToTable("Customer");
                etd.HasKey(c => c.CustomerId);
                etd.Property(c => c.BirthDate);
                etd.Property(c => c.CreatedBy).IsRequired();
                etd.Property(c => c.UpdatedBy).IsRequired();
                etd.Property(c => c.CreatedIn).IsRequired();
                etd.Property(c => c.UpdatedIn).IsRequired();                
                //here i had to (1) show all my valueobject and (2) says to EF ignore the Notifications inside it                
                builder.Entity<Customer>().OwnsOne(c => c.Name).Ignore(p => p.Notifications);
                builder.Entity<Customer>().OwnsOne(c => c.Name).Property(c => c.FirstName).HasColumnName("FirstName").HasMaxLength(60);
                builder.Entity<Customer>().OwnsOne(c => c.Name).Property(c => c.LastName).HasColumnName("LastName").HasMaxLength(60);
                builder.Entity<Customer>().OwnsOne(c => c.Document).Ignore(c => c.Notifications);
                builder.Entity<Customer>().OwnsOne(c => c.Document).Property(c => c.Number).HasColumnName("DocumentNumber").HasMaxLength(20);
                builder.Entity<Customer>().OwnsOne(c => c.Email).Ignore(c => c.Notifications);
                builder.Entity<Customer>().OwnsOne(c => c.Email).Property(c => c.EmailAddress).HasColumnName("EmailAddress").HasMaxLength(60);
                builder.Entity<Customer>().OwnsOne(c => c.User).Ignore(c => c.Notifications);
                builder.Entity<Customer>().HasOne(a => a.User).WithOne(b => b.Customer).HasForeignKey<Customer>(b => b.UserId); //A Customer has one User
                etd.Ignore(c => c.Notifications);
                etd.Ignore(c => c.Order); //created just because EF needs it to create the FK... aff!
            });
        }

        private void ConfigProduct(ModelBuilder builder)
        {
            builder.Entity<Product>(etd =>
            {
                etd.ToTable("Product");
                etd.HasKey(c => c.ProductId);
                etd.Property(c => c.Image).IsRequired().HasMaxLength(1024);
                etd.Property(c => c.Price).IsRequired();
                etd.Property(c => c.QuantityOnHand).IsRequired();
                etd.Property(c => c.Title).IsRequired().HasMaxLength(160);
                etd.Property(c => c.CreatedBy).IsRequired();
                etd.Property(c => c.UpdatedBy).IsRequired();
                etd.Property(c => c.CreatedIn).IsRequired();
                etd.Property(c => c.UpdatedIn).IsRequired();
                etd.Ignore(c => c.Notifications);
                etd.Ignore(c => c.OrderItems);
            });
        }

        private void ConfigOrder(ModelBuilder builder)
        {
            builder.Entity<Order>(etd =>
            {
                etd.ToTable("Order");
                etd.HasKey(c => c.OrderId);                
                etd.Property(c => c.DeliveryFee).IsRequired();
                etd.Property(c => c.Discount).IsRequired();
                etd.Property(c => c.Number).IsRequired().HasMaxLength(8);
                etd.Property(c => c.Status).IsRequired();
                etd.Property(c => c.CreatedBy).IsRequired();
                etd.Property(c => c.UpdatedBy).IsRequired();
                etd.Property(c => c.CreatedIn).IsRequired();
                etd.Property(c => c.UpdatedIn).IsRequired();
                builder.Entity<Order>().OwnsOne(c => c.Customer).Ignore(c => c.Notifications);
                builder.Entity<Order>().HasOne(p => p.Customer).WithOne(b => b.Order).HasForeignKey<Order>(b => b.CustomerId); //A Order Belong to a Customer                etd.Ignore(c => c.Notifications);
                etd.Ignore(c => c.Items);               
            });
        }

        private void ConfigOrderItem(ModelBuilder builder)
        {
            builder.Entity<OrderItem>(etd =>
            {
                etd.ToTable("OrderItem");
                etd.HasKey(c => c.OrderItemId);
                etd.Property(c => c.Price).IsRequired();
                etd.Property(c => c.Quantity).IsRequired();
                etd.Property(c => c.CreatedBy).IsRequired();
                etd.Property(c => c.UpdatedBy).IsRequired();
                etd.Property(c => c.CreatedIn).IsRequired();
                etd.Property(c => c.UpdatedIn).IsRequired();
                builder.Entity<OrderItem>().OwnsOne(c => c.Product).Ignore(c => c.Notifications);
                builder.Entity<OrderItem>().OwnsOne(c => c.Order).Ignore(c => c.Notifications);

                //A Product will be in N OrderItems and A Order will have N OrderItems
                builder.Entity<OrderItem>().HasOne(p => p.Product).WithMany(p => p.OrderItems).HasForeignKey(p => p.ProductId);
                builder.Entity<OrderItem>().HasOne(p => p.Order).WithMany(p => p.Items).HasForeignKey(p => p.OrderId);
                etd.Ignore(c => c.Notifications);
            });
        }
        #endregion
    }
}