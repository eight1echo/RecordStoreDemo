using RecordStoreDemo.Features.Customers.Profiles.Commands.CreateCustomer;
using RecordStoreDemo.Features.Customers.Profiles.Queries.FindCustomers;
using RecordStoreDemo.Features.Customers.Profiles.Queries.GetCustomerDetails;

namespace RecordStoreDemo.Features.Customers.Profiles;

public class CustomerProfileService : ICustomerProfileService
{
    private readonly HttpClient _httpClient;

    public CustomerProfileService(HttpClient httpClient)
    {
        _httpClient = httpClient;

        _httpClient.BaseAddress = new Uri("https://localhost:7067/api/customers/");
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    }

    public async Task<ServiceResult<CustomerProfileModel>> CreateCustomerProfile(CreateCustomerProfileRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("", request);
        var result = await ServiceResult<CustomerProfileModel>.GetResultAsync(response);

        return result;     
    }

    public async Task<ServiceResult<List<CustomerProfileModel>>> FindCustomers(FindCustomersRequest request)
    {
        var response = await _httpClient.GetAsync($"find?Name={request.Name}");
        var result = await ServiceResult<List<CustomerProfileModel>>.GetResultAsync(response);

        return result;
    }

    public async Task<ServiceResult<CustomerDetailsModel>> GetCustomer(Guid profileId)
    {
        var response = await _httpClient.GetAsync($"{profileId}");
        var result = await ServiceResult<CustomerDetailsModel>.GetResultAsync(response);

        return result;
    }

    public async Task<ServiceResult<List<CustomerProfileModel>>> ListCustomers()
    {
        var response = await _httpClient.GetAsync("");
        var result = await ServiceResult<List<CustomerProfileModel>>.GetResultAsync(response);

        return result;
    }
}