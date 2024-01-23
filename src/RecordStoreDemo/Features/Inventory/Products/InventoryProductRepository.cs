namespace RecordStoreDemo.Features.Inventory.Products;

public class InventoryProductRepository : BaseRepository<InventoryProduct>, IInventoryProductRepository
{
    private readonly RecordStoreDbContext _context;

    public InventoryProductRepository(RecordStoreDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<InventoryProduct> GetProduct(Guid productId)
    {
        var product = await _context.InventoryProducts
            .Where(p => p.Id == productId)
            .Include(p => p.CatalogProduct)
            .Include(p => p.OnHandHistory)
            .Include(p => p.PriceHistory)
            .Include(p => p.SpecialOrders)
            .FirstOrDefaultAsync()
            ?? throw new EntityNotFoundException(productId);

        return product;
    }
    public async Task<List<InventoryProduct>> GetProducts(Guid[] productIds)
    {
        var products = await _context.InventoryProducts
            .Where(p => productIds.Contains(p.Id))
            .Include(p => p.CatalogProduct)
            .Include(p => p.OnHandHistory)
            .Include(p => p.PriceHistory)
            .ToListAsync();

        return products;
    }

    public async Task<InventoryProduct> GetProductByUPC(string upc)
    {
        var product = await _context.InventoryProducts
            .Where(p => p.UPC.Value == upc)
            .Include(p => p.CatalogProduct)
            .Include(p => p.OnHandHistory)
            .Include(p => p.PriceHistory)
            .FirstOrDefaultAsync()
            ?? throw new Exception($"No Product found with UPC: {upc}");

        return product;
    }
}