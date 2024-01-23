using RecordStoreDemo.Features.Customers.Profiles.Commands.CreateCustomer;
using RecordStoreDemo.Features.Customers.Profiles.Queries.GetCustomerDetails;

namespace RecordStoreDemo.Features.Customers.Profiles;

public interface ICustomerProfileService
{
    Task<CustomerProfileModel> CreateCustomerProfile(CreateCustomerProfileRequest request);
    Task<List<CustomerProfileModel>> FindCustomers(string query);
    Task<CustomerDetailsModel> GetCustomerDetails(Guid profileId);
    Task<List<CustomerProfileModel>> ListCustomers();
}