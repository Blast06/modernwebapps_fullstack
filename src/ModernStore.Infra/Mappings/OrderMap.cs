using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernStore.Domain.Entities;

namespace ModernStore.Infra.Mappings
{
    public class OrderMap
    {
        public OrderMap(EntityTypeBuilder<Order> entityBuilder)
        {
            entityBuilder.ToTable("Order");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.CreateDate);
            entityBuilder.Property(x => x.DeliveryFee).HasColumnType("money");
            entityBuilder.Property(x => x.Discount).HasColumnType("money");
            entityBuilder.Property(x => x.Number).IsRequired().HasMaxLength(8).IsFixedLength();
            entityBuilder.Property(x => x.Status);

            entityBuilder.HasMany(x => x.Items);
            entityBuilder.HasOne(x => x.Customer);
        }
    }
}
