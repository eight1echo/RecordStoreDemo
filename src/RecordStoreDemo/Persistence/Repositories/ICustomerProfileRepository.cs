namespace RecordStoreDemo.Persistence.Repositories;

public interface ICustomerProfileRepository : IBaseRepository<CustomerProfile>
{
    Task<CustomerProfile> GetCustomer(Guid profileId);
}