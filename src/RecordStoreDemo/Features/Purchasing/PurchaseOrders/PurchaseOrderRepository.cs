namespace RecordStoreDemo.Features.Purchasing.PurchaseOrders;

public class PurchaseOrderRepository : BaseRepository<PurchaseOrder>, IPurchaseOrderRepository
{
    private readonly RecordStoreDbContext _context;

    public PurchaseOrderRepository(RecordStoreDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<PurchaseOrder> GetPurchaseOrder(Guid orderId)
    {
        var vendor = await _context.PurchaseOrders
            .Where(po => po.Id == orderId)
            .Include(po => po.Items)
                .ThenInclude(i => i.CatalogProduct)
            .FirstOrDefaultAsync()
            ?? throw new EntityNotFoundException(orderId);

        return vendor;
    }

    public async Task<PurchaseOrder> GetPendingPurchaseOrderByVendorId(Guid vendorId)
    {
        var order = await _context.PurchaseOrders
            .Where(po => po.VendorId == vendorId && po.Status == PurchaseOrderStatus.Pending)
            .Include(po => po.Items)
                .ThenInclude(i => i.CatalogProduct)
            .FirstOrDefaultAsync();

        if (order is null)
        {
            order = new PurchaseOrder(vendorId);

            await Add(order);
            await _context.SaveChangesAsync();
        }

        return order;
    }

    public async Task<PurchaseOrder> GetPendingPurchaseOrderByProductId(Guid productId)
    {
        var order = await _context.PurchaseOrders
            .Where(po => po.Items.Any(i => i.CatalogProductId == productId) && po.Status == PurchaseOrderStatus.Pending)
            .Include(po => po.Items)
                .ThenInclude(i => i.CatalogProduct)
            .FirstOrDefaultAsync()
            ?? throw new Exception($"No Pending Purchase Order exists containing a CatalogProduct with Id:{productId}");

        return order;
    }
}