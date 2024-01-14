namespace RecordStoreDemo.Features.Receiving;

public class ReceiveRepository : BaseRepository<Receive>, IReceiveRepository
{
    private readonly RecordStoreDbContext _context;

    public ReceiveRepository(RecordStoreDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Receive> GetReceive(Guid receiveId)
    {
        var receive = await _context.Receives
            .Where(r => r.Id == receiveId)
            .Include(r => r.Items)
                .ThenInclude(i => i.CatalogProduct)
            .Include(r => r.Items)
                .ThenInclude(i => i.InventoryProduct)
            .FirstOrDefaultAsync()
            ?? throw new EntityNotFoundException(receiveId);

        return receive;
    }

    public async Task<Receive> GetPendingReceiveByVendorId(Guid vendorId)
    {
        var receive = await _context.Receives
            .Where(r => r.VendorId == vendorId && r.Status == ReceiveStatus.Pending)
            .Include(r => r.Items)
                .ThenInclude(i => i.CatalogProduct)
            .Include(r => r.Items)
                .ThenInclude(i => i.InventoryProduct)
            .FirstOrDefaultAsync()
            ?? throw new EntityNotFoundException(vendorId);

        return receive;
    }

    public async Task<Receive> GetPendingReceiveByProductId(Guid productId)
    {
        var receive = await _context.Receives
            .Where(r => r.Items.Any(i => i.InventoryProductId == productId) && r.Status == ReceiveStatus.Pending)
            .Include(r => r.Items)
                .ThenInclude(i => i.CatalogProduct)
            .Include(r => r.Items)
                .ThenInclude(i => i.InventoryProduct)
            .FirstOrDefaultAsync()
            ?? throw new Exception($"No Pending Receive exists containing a Product with Id:{productId}");

        return receive;
    }
}