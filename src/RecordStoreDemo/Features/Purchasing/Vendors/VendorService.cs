using RecordStoreDemo.Features.Purchasing.Vendors.Commands.CreateVendor;
using RecordStoreDemo.Features.Purchasing.Vendors.Queries.GetVendorDetails;

namespace RecordStoreDemo.Features.Purchasing.Vendors;

public class VendorService : IVendorService
{
    private readonly HttpClient _httpClient;

    public VendorService(HttpClient httpClient)
    {
        _httpClient = httpClient;

        _httpClient.BaseAddress = new Uri("https://localhost:7067/api/purchasing/vendors/");
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    }

    public async Task<VendorModel> CreateVendor(CreateVendorRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("", request);
        response.EnsureSuccessStatusCode();

        var vendor = await response.Content.ReadFromJsonAsync<VendorModel>();

        if (vendor is not null)
        {
            return vendor;
        }
        else
            // TODO: Handle possible HttpClient errors.
            throw new Exception();
    }

    public async Task<VendorDetailsModel> GetVendor(Guid vendorId)
    {
        var response = await _httpClient.GetFromJsonAsync<VendorDetailsModel>($"{vendorId}");

        if (response is not null)
        {
            return response;
        }
        else
            // TODO: Handle possible HttpClient errors.
            throw new Exception();
    }

    public async Task<List<VendorModel>> ListVendors()
    {
        var response = await _httpClient.GetFromJsonAsync<List<VendorModel>>($"");

        if (response is not null)
        {
            return response;
        }
        else
            // TODO: Handle possible HttpClient errors.
            throw new Exception();
    }
}