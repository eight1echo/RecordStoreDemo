using RecordStoreDemo.Features.Purchasing.PurchaseOrders.Commands.UpdatePurchaseOrder;
using RecordStoreDemo.Features.Purchasing.PurchaseOrders.Commands.UpdatePurchaseOrderItem;

namespace RecordStoreDemo.Features.Purchasing.PurchaseOrders;

public class PurchaseOrderService : IPurchaseOrderService
{
    private readonly HttpClient _httpClient;

    public PurchaseOrderService(HttpClient httpClient)
    {
        _httpClient = httpClient;

        _httpClient.BaseAddress = new Uri("https://localhost:7067/api/purchasing/orders/");
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    }

    // TODO: ServiceResult for Tasks when nothing is returned.
    public async Task DeleteItem(Guid catalogProductId)
    {
        var response = await _httpClient.DeleteAsync($"items/{catalogProductId}");
        response.EnsureSuccessStatusCode();        
    }

    public async Task SubmitOrder(Guid vendorId)
    {
        var response = await _httpClient.PostAsync($"{vendorId}", null);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateItem(UpdatePurchaseOrderItemRequest request)
    {
        var response = await _httpClient.PutAsJsonAsync($"items", request);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateOrder(UpdatePurchaseOrderRequest request)
    {
        var response = await _httpClient.PutAsJsonAsync($"", request);
        response.EnsureSuccessStatusCode();
    }
}