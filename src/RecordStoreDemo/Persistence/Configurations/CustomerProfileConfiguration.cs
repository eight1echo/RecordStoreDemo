using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RecordStoreDemo.Persistence.Configurations;
public class CustomerProfileConfiguration : IEntityTypeConfiguration<CustomerProfile>
{
    public void Configure(EntityTypeBuilder<CustomerProfile> builder)
    {
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(80);

        builder.OwnsOne(c => c.EmailAddress)
            .Property(c => c.Address).HasColumnName("EmailAddress");

        builder.OwnsOne(c => c.PhoneNumber)
            .Property(c => c.Digits).HasColumnName("PhoneNumber");
    }
}