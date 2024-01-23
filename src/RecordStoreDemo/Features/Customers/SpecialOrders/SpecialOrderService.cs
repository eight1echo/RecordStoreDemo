using RecordStoreDemo.Features.Customers.SpecialOrders.Commands.CreateSpecialOrder;

namespace RecordStoreDemo.Features.Customers.SpecialOrders;
public class SpecialOrderService : ISpecialOrderService
{
    private readonly HttpClient _httpClient;

    public SpecialOrderService(HttpClient httpClient)
    {
        _httpClient = httpClient;

        _httpClient.BaseAddress = new Uri("https://localhost:7067/api/specialorders/");
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    }

    public async Task<SpecialOrderModel> CreateSpecialOrder(CreateSpecialOrderRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("", request);
        response.EnsureSuccessStatusCode();

        var vendor = await response.Content.ReadFromJsonAsync<SpecialOrderModel>();

        if (vendor is not null)
        {
            return vendor;
        }
        else
            // TODO: Handle possible HttpClient errors.
            throw new Exception();
    }

    public async Task<List<SpecialOrderModel>> GetCustomerSpecialOrders(Guid customerProfileId)
    {
        var response = await _httpClient.GetFromJsonAsync<List<SpecialOrderModel>>($"customer/{customerProfileId}");

        if (response is not null)
        {
            return response;
        }
        else
            // TODO: Handle possible HttpClient errors.
            throw new Exception();
    }

    public async Task<List<SpecialOrderModel>> GetProductSpecialOrders(Guid inventoryProductId)
    {
        var response = await _httpClient.GetFromJsonAsync<List<SpecialOrderModel>>($"product/{inventoryProductId}");

        if (response is not null)
        {
            return response;
        }
        else
            // TODO: Handle possible HttpClient errors.
            throw new Exception();
    }
}