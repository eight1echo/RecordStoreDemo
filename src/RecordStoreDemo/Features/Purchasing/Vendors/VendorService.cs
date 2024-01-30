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

    public async Task<ServiceResult<VendorModel>> CreateVendor(CreateVendorRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("", request);
        var result = await ServiceResult<VendorModel>.GetResultAsync(response);

        return result;
    }

    public async Task<ServiceResult<VendorDetailsModel>> GetVendor(Guid vendorId)
    {
        var response = await _httpClient.GetAsync($"{vendorId}");
        var result = await ServiceResult<VendorDetailsModel>.GetResultAsync(response);

        return result;
    }

    public async Task<ServiceResult<List<VendorModel>>> ListVendors()
    {
        var response = await _httpClient.GetAsync($"");
        var result = await ServiceResult<List<VendorModel>>.GetResultAsync(response);

        return result;
    }
}