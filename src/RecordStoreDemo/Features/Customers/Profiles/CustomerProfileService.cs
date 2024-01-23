using RecordStoreDemo.Features.Customers.Profiles.Commands.CreateCustomer;
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

    public async Task<CustomerProfileModel> CreateCustomerProfile(CreateCustomerProfileRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("", request);
        response.EnsureSuccessStatusCode();

        var customer = await response.Content.ReadFromJsonAsync<CustomerProfileModel>();

        if (customer is not null)
        {
            return customer;
        }
        else
            // TODO: Handle possible HttpClient errors.
            throw new Exception();
    }

    public async Task<List<CustomerProfileModel>> FindCustomers(string query)
    {
        var response = await _httpClient.GetFromJsonAsync<List<CustomerProfileModel>>($"find/{query}");

        if (response is not null)
        {
            return response;
        }
        else
            // TODO: Handle possible HttpClient errors.
            throw new Exception();
    }

    public async Task<CustomerDetailsModel> GetCustomerDetails(Guid profileId)
    {
        var response = await _httpClient.GetFromJsonAsync<CustomerDetailsModel>($"{profileId}");

        if (response is not null)
        {
            return response;
        }
        else
            // TODO: Handle possible HttpClient errors.
            throw new Exception();
    }

    public async Task<List<CustomerProfileModel>> ListCustomers()
    {
        var response = await _httpClient.GetFromJsonAsync<List<CustomerProfileModel>>($"");

        if (response is not null)
        {
            return response;
        }
        else
            // TODO: Handle possible HttpClient errors.
            throw new Exception();
    }
}