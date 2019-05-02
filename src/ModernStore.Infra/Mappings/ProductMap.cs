using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernStore.Domain.Entities;

namespace ModernStore.Infra.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Image).IsRequired().HasMaxLength(1024);
            builder.Property(x => x.Price);
            builder.Property(x => x.QuantityOnHand);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(80);
            builder.Property(x => x.CreatedBy).IsRequired();
            builder.Property(x => x.UpdatedBy).IsRequired();
            builder.Property(x => x.CreatedIn).IsRequired();
            builder.Property(x => x.UpdatedIn).IsRequired();
            //builder.Ignore(x => x.Notifications);
        }
    }
}
