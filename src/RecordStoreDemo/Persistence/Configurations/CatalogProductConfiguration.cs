using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RecordStoreDemo.Persistence.Configurations;

public class VendorProductProductConfiguration : IEntityTypeConfiguration<CatalogProduct>
{
    public void Configure(EntityTypeBuilder<CatalogProduct> builder)
    {
        builder.Property(p => p.Artist).HasMaxLength(200);

        builder.OwnsOne(p => p.Cost)
          .Property(p => p.Value).HasColumnName("Cost").HasColumnType("decimal(8,2)");

        builder.Property(p => p.Title).HasMaxLength(200);

        builder.OwnsOne(p => p.UPC)
           .Property(p => p.Value).HasColumnName("UPC");
    }
}