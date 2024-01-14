namespace RecordStoreDemo.Features.Purchasing.Vendors;

public class VendorRepository : BaseRepository<Vendor>, IVendorRepository
{
    private readonly RecordStoreDbContext _context;

    public VendorRepository(RecordStoreDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Vendor> GetVendor(Guid vendorId)
    {
        var vendor = await _context.Vendors
            .Where(v => v.Id == vendorId)
            .Include(v => v.Catalog)
            .Include(v => v.Orders)
                .ThenInclude(o => o.Items)
                    .ThenInclude(i => i.CatalogProduct)
            .FirstOrDefaultAsync()
            ?? throw new EntityNotFoundException(vendorId);

        return vendor;
    }

    public async Task<Vendor> GetVendorWithProducts(Guid vendorId)
    {
        var vendor = await _context.Vendors
            .Where(v => v.Id == vendorId)
            .Include(v => v.Catalog)
            .Include(v => v.Orders)
            .Include(v => v.Products)
            .FirstOrDefaultAsync()
            ?? throw new EntityNotFoundException(vendorId);

        return vendor;
    }

    public async Task<CatalogProduct> GetCatalogProduct(Guid productId)
    {
        var product = await _context.CatalogProducts
            .Where(v => v.Id == productId)
            .FirstOrDefaultAsync()
            ?? throw new EntityNotFoundException(productId);

        return product;
    }

    public async Task<List<CatalogProduct>> ListCatalogProducts(Guid[] productIds)
    {
        var products = await _context.CatalogProducts
            .Where(cp => productIds.Contains(cp.Id))
            .ToListAsync();

        return products;
    }
}