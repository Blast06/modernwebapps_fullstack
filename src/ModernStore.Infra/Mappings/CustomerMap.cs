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
            entityBuilder.Property(x => x.Document.Number).IsRequired().HasMaxLength(11).IsFixedLength();
            entityBuilder.Property(x => x.Email.EmailAddress).IsRequired().HasMaxLength(160);
            entityBuilder.Property(x => x.Name.FirstName).IsRequired().HasMaxLength(60);
            entityBuilder.Property(x => x.Name.LastName).IsRequired().HasMaxLength(60);
            entityBuilder.HasOne(x => x.User);
        }
    }
}