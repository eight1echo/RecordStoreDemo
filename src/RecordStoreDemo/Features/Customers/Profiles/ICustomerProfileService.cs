using RecordStoreDemo.Features.Customers.Profiles.Commands.CreateCustomer;
using RecordStoreDemo.Features.Customers.Profiles.Queries.FindCustomers;
using RecordStoreDemo.Features.Customers.Profiles.Queries.GetCustomerDetails;

namespace RecordStoreDemo.Features.Customers.Profiles;

public interface ICustomerProfileService
{
    Task<ServiceResult<CustomerProfileModel>> CreateCustomerProfile(CreateCustomerProfileRequest request);
    Task<ServiceResult<List<CustomerProfileModel>>> FindCustomers(FindCustomersRequest request);
    Task<ServiceResult<CustomerDetailsModel>> GetCustomer(Guid profileId);
    Task<ServiceResult<List<CustomerProfileModel>>> ListCustomers();
}