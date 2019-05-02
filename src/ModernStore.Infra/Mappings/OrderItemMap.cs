using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernStore.Domain.Entities;

namespace ModernStore.Infra.Mappings
{
    public class OrderItemMap
    {
        public OrderItemMap(EntityTypeBuilder<OrderItem> entityBuilder)
        {
            entityBuilder.ToTable("OrderItem");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Price).HasColumnType("money");
            entityBuilder.Property(x => x.Quantity);
            entityBuilder.HasOne(x => x.Product);
            entityBuilder.Property(x => x.Id).IsRequired();
            entityBuilder.Property(x => x.CreatedBy).IsRequired();
            entityBuilder.Property(x => x.UpdatedBy).IsRequired();
            entityBuilder.Property(x => x.CreatedIn).IsRequired();
            entityBuilder.Property(x => x.UpdatedIn).IsRequired();
            //entityBuilder.Ignore(x => x.Notifications);
        }
    }
}
