using System.Reflection;

namespace RecordStoreDemo.Persistence;
public class RecordStoreDbContext(DbContextOptions<RecordStoreDbContext> options) : DbContext(options)
{
    // Inventory
    public DbSet<InventoryProduct> InventoryProducts => Set<InventoryProduct>();
    public DbSet<OnHandChange> OnHandHistory => Set<OnHandChange>();
    public DbSet<PriceChange> PriceHistory => Set<PriceChange>();
    // Purchasing
    public DbSet<Catalog> Catalogs => Set<Catalog>();
    public DbSet<CatalogProduct> CatalogProducts => Set<CatalogProduct>();
    public DbSet<PurchaseOrder> PurchaseOrders => Set<PurchaseOrder>();
    public DbSet<PurchaseOrderItem> PurchaseOrderItems => Set<PurchaseOrderItem>();
    public DbSet<Vendor> Vendors => Set<Vendor>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}