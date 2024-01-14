using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RecordStoreDemo.Persistence.Configurations;
public class InventoryProductConfiguration : IEntityTypeConfiguration<InventoryProduct>
{
    public void Configure(EntityTypeBuilder<InventoryProduct> builder)
    {
        builder.Property(p => p.Artist).HasMaxLength(200);

        builder.OwnsOne(p => p.Category)
            .Property(x => x.Department).HasColumnName("Department");
        builder.OwnsOne(p => p.Category)
            .Property(x => x.Format).HasColumnName("Format");

        builder.OwnsOne(p => p.Price)
           .Property(p => p.Value)
           .HasColumnName("Price")
           .HasColumnType("decimal(8,2)");

        builder.Property(p => p.Title).HasMaxLength(200);

        builder.OwnsOne(p => p.UPC)
           .Property(p => p.Value).HasColumnName("UPC");
    }
}