using System.Reflection;

namespace RecordStoreDemo.Persistence;
public class RecordStoreDbContext(DbContextOptions<RecordStoreDbContext> options) : DbContext(options)
{
    // Customers
    public DbSet<CustomerProfile> CustomerProfiles => Set<CustomerProfile>();
    public DbSet<RewardsCard> RewardsCards => Set<RewardsCard>();
    public DbSet<RewardsTransaction> RewardsTransactions => Set<RewardsTransaction>();
    public DbSet<SpecialOrder> SpecialOrders => Set<SpecialOrder>();

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

    // Receiving
    public DbSet<Receive> Receives => Set<Receive>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}