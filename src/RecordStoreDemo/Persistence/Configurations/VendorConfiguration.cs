using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RecordStoreDemo.Persistence.Configurations;

public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
{
    public void Configure(EntityTypeBuilder<Vendor> builder)
    {
        builder.Property(e => e.Name).IsRequired().HasMaxLength(35);

        builder.HasMany(v => v.Products).WithOne().OnDelete(DeleteBehavior.Cascade);
    }
}