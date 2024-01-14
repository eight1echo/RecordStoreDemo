using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RecordStoreDemo.Persistence.Configurations;

public class PurchaseOrderConfiguration : IEntityTypeConfiguration<PurchaseOrder>
{
    public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
    {
        builder.Property(item => item.Total)
            .HasColumnType("decimal(8,2)");

        builder.HasMany(po => po.Items).WithOne().OnDelete(DeleteBehavior.Cascade);
    }
}