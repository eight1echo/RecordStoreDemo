namespace RecordStoreDemo.Features.Customers.Profiles;

public class CustomerProfileRepository : BaseRepository<CustomerProfile>, ICustomerProfileRepository
{
    private readonly RecordStoreDbContext _context;

    public CustomerProfileRepository(RecordStoreDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<CustomerProfile> GetCustomer(Guid profileId)
    {
        var customer = await _context.CustomerProfiles
            .Where(p => p.Id == profileId)
            .Include(p => p.RewardsCard)
                .ThenInclude(r => r.Transactions)
            .Include(p => p.SpecialOrders)
                .ThenInclude(o => o.Product)
            .FirstOrDefaultAsync()
            ?? throw new EntityNotFoundException(profileId);

        return customer;
    }
}