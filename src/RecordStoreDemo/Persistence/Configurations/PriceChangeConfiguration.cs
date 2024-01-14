using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RecordStoreDemo.Persistence.Configurations;

public class PriceChangeConfiguration : IEntityTypeConfiguration<PriceChange>
{
    public void Configure(EntityTypeBuilder<PriceChange> builder)
    {
        builder.OwnsOne(p => p.NewPrice)
           .Property(p => p.Value)
           .HasColumnName("New Price")
           .HasColumnType("decimal(8,2)");

        builder.OwnsOne(p => p.OldPrice)
           .Property(p => p.Value)
           .HasColumnName("Old Price")
           .HasColumnType("decimal(8,2)");
    }
}