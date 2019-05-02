using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.Entities;
using ModernStore.Shared.Entities;

namespace ModernStore.Infra.Contexts
{
    public class ModernStoreDataContext : DbContext
    {
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

            #region Keys
            //builder.Entity<User>().HasKey(t => t.Id);
            //builder.Entity<Customer>().HasKey(t => t.Id);
            //builder.Entity<Product>().HasKey(t => t.Id);
            //builder.Entity<Order>().HasKey(t => t.Id);
            //builder.Entity<OrderItem>().HasKey(t => t.Id);
            #endregion

            #region Ignored Fields
            builder.Entity<User>().Ignore(i => i.Notifications);
            builder.Entity<Product>().Ignore(i => i.Notifications);
            builder.Entity<Order>().Ignore(i => i.Notifications);
            builder.Entity<OrderItem>().Ignore(i => i.Notifications);
            builder.Entity<Customer>().Ignore(i => i.Notifications);
            builder.Entity<Customer>().Ignore(i => i.Name);
            builder.Entity<Customer>().Ignore(i => i.Email);
            builder.Entity<Customer>().Ignore(i => i.Document);
            builder.Entity<Entity>().Ignore(i => i.Notifications);
            #endregion            
        }
        #endregion

        #region Configura das Tabelas
        private void ConfigUser(ModelBuilder builder)
        {
            builder.Entity<User>(etd =>
            {
                etd.ToTable("User");
                etd.HasKey(c => c.Id).HasName("Id");
                //etd.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                etd.Property(c => c.Active);
                etd.Property(c => c.Username).HasMaxLength(20);
                etd.Property(c => c.Password).HasMaxLength(32);
                etd.Property(c => c.CreatedBy);
                etd.Property(c => c.UpdatedBy);
                etd.Property(c => c.CreatedIn);
                etd.Property(c => c.UpdatedIn);
                etd.Ignore(c => c.Notifications);
            });
        }

        private void ConfigCustomer(ModelBuilder builder)
        {
            builder.Entity<Customer>(etd=>
            {
                etd.ToTable("Customer");
                etd.HasKey(c => c.Id).HasName("Id");
                //etd.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                etd.Property(c => c.BirthDate);                
                //etd.Property(c => c.Name.FirstName).HasColumnName("FirstName").HasMaxLength(60);
                //etd.Property(c => c.Name.LastName).HasColumnName("LastName").HasMaxLength(60);
                //etd.Property(c => c.Document.Number).HasColumnName("Number").HasMaxLength(20);
                //etd.Property(c => c.Email.EmailAddress).HasColumnName("EmailAddress").HasMaxLength(160);
                //etd.Property(c => c.User).IsRequired();
                etd.Property(c => c.CreatedBy);
                etd.Property(c => c.UpdatedBy);
                etd.Property(c => c.CreatedIn);
                etd.Property(c => c.UpdatedIn);                
                builder.Entity<Customer>().OwnsOne(c => c.Name);                
                builder.Entity<Customer>().OwnsOne(c => c.Document);
                builder.Entity<Customer>().OwnsOne(c => c.Email);
                etd.Ignore(c => c.Notifications);
            });
        }

        private void ConfigProduct(ModelBuilder builder)
        {
            builder.Entity<Product>(etd =>
            {
                etd.ToTable("Product");
                etd.HasKey(c => c.Id).HasName("Id");
                etd.Property(c => c.Image).IsRequired().HasMaxLength(1024);
                etd.Property(c => c.Price);
                etd.Property(c => c.QuantityOnHand);
                etd.Property(c => c.Title).IsRequired().HasMaxLength(80);
                etd.Property(c => c.CreatedBy);
                etd.Property(c => c.UpdatedBy);
                etd.Property(c => c.CreatedIn);
                etd.Property(c => c.UpdatedIn);
                etd.Ignore(c => c.Notifications);
            });
        }

        private void ConfigOrder(ModelBuilder builder)
        {
            builder.Entity<Order>(etd =>
            {
                etd.ToTable("Order");
                etd.HasKey(c => c.Id).HasName("Id");
                etd.Property(c => c.CreateDate);
                etd.Property(c => c.DeliveryFee);
                etd.Property(c => c.Discount);
                etd.Property(c => c.Number).IsRequired().HasMaxLength(8);
                etd.Property(c => c.Status);
                etd.Property(c => c.CreatedBy);
                etd.Property(c => c.UpdatedBy);
                etd.Property(c => c.CreatedIn);
                etd.Property(c => c.UpdatedIn);
                etd.Ignore(c => c.Notifications);
            });
        }

        private void ConfigOrderItem(ModelBuilder builder)
        {
            builder.Entity<OrderItem>(etd =>
            {
                etd.ToTable("OrderItem");
                etd.HasKey(c => c.Id).HasName("Id");
                etd.Property(c => c.Price);
                etd.Property(c => c.Quantity);
                //etd.Property(c => c.Product);                
                etd.Property(c => c.CreatedBy);
                etd.Property(c => c.UpdatedBy);
                etd.Property(c => c.CreatedIn);
                etd.Property(c => c.UpdatedIn);
                etd.Ignore(c => c.Notifications);
            });
        }
        #endregion
    }
}