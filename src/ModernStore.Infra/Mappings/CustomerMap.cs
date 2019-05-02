using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernStore.Domain.Entities;

namespace ModernStore.Infra.Mappings
{
    public class CustomerMap
    {
        public CustomerMap(EntityTypeBuilder<Customer> entityBuilder)
        {
            entityBuilder.ToTable("Customer");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.BirthDate);
            //entityBuilder.Property(x => x.Document.Number).IsRequired().HasMaxLength(20);
            //entityBuilder.Property(x => x.Email.EmailAddress).IsRequired().HasMaxLength(160);
            //entityBuilder.Property(x => x.Name.FirstName).IsRequired().HasMaxLength(60);
            //entityBuilder.Property(x => x.Name.LastName).IsRequired().HasMaxLength(60);
            entityBuilder.HasOne(x => x.User);
            entityBuilder.Property(x => x.Id).IsRequired();
            entityBuilder.Property(x => x.CreatedBy).IsRequired();
            entityBuilder.Property(x => x.UpdatedBy).IsRequired();
            entityBuilder.Property(x => x.CreatedIn).IsRequired();
            entityBuilder.Property(x => x.UpdatedIn).IsRequired();
            //entityBuilder.Ignore(x => x.Notifications);
            //entityBuilder.Ignore(x => x.User.Notifications);
            //entityBuilder.Ignore(x => x.Document.Notifications);
            //entityBuilder.Ignore(x => x.Email.Notifications);
        }
    }
}