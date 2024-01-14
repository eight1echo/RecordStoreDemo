using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RecordStoreDemo.Persistence.Configurations;

public class ReceiveItemConfiguration : IEntityTypeConfiguration<ReceiveItem>
{
    public void Configure(EntityTypeBuilder<ReceiveItem> builder)
    {
        builder.HasOne(p => p.CatalogProduct).WithMany().OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(p => p.InventoryProduct).WithMany().OnDelete(DeleteBehavior.NoAction);
    }
}