using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernStore.Domain.Entities;

namespace ModernStore.Infra.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BirthDate);
            //entityBuilder.Property(x => x.Document.Number).IsRequired().HasMaxLength(20);
            //entityBuilder.Property(x => x.Email.EmailAddress).IsRequired().HasMaxLength(160);
            //entityBuilder.Property(x => x.Name.FirstName).IsRequired().HasMaxLength(60);
            //entityBuilder.Property(x => x.Name.LastName).IsRequired().HasMaxLength(60);

            builder.HasOne(x => x.User);
            builder.Property(x => x.CreatedBy).IsRequired();
            builder.Property(x => x.UpdatedBy).IsRequired();
            builder.Property(x => x.CreatedIn).IsRequired();
            builder.Property(x => x.UpdatedIn).IsRequired();
            //builder.Ignore(x => x.Notifications);
            //builder.Ignore(x => x.Name);
            //builder.Ignore(x => x.Document);
            //builder.Ignore(x => x.Email);
        }
    }
}