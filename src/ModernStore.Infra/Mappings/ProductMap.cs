using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernStore.Domain.Entities;

namespace ModernStore.Infra.Mappings
{
    public class ProductMap
    {
        public ProductMap(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.ToTable("Product");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Image).IsRequired().HasMaxLength(1024);
            entityBuilder.Property(x => x.Price);
            entityBuilder.Property(x => x.QuantityOnHand);
            entityBuilder.Property(x => x.Title).IsRequired().HasMaxLength(80);
        }
    }
}
