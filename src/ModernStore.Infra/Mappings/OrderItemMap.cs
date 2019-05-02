using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernStore.Domain.Entities;

namespace ModernStore.Infra.Mappings
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Price).HasColumnType("money");
            builder.Property(x => x.Quantity);
            builder.HasOne(x => x.Product);            
            builder.Property(x => x.CreatedBy).IsRequired();
            builder.Property(x => x.UpdatedBy).IsRequired();
            builder.Property(x => x.CreatedIn).IsRequired();
            builder.Property(x => x.UpdatedIn).IsRequired();
            //builder.Ignore(x => x.Notifications);
        }
    }
}
