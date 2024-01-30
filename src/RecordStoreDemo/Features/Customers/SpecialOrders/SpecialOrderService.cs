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

    public async Task<ServiceResult<SpecialOrderModel>> CreateSpecialOrder(CreateSpecialOrderRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("", request);
        var result = await ServiceResult<SpecialOrderModel>.GetResultAsync(response);

        return result;
    }

    public async Task<ServiceResult<List<SpecialOrderModel>>> GetCustomerSpecialOrders(Guid customerProfileId)
    {
        var response = await _httpClient.GetAsync($"customer/{customerProfileId}");
        var result = await ServiceResult<List<SpecialOrderModel>>.GetResultAsync(response);

        return result;
    }

    public async Task<ServiceResult<List<SpecialOrderModel>>> GetProductSpecialOrders(Guid inventoryProductId)
    {
        var response = await _httpClient.GetAsync($"product/{inventoryProductId}");
        var result = await ServiceResult<List<SpecialOrderModel>>.GetResultAsync(response);

        return result;
    }
}