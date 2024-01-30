using RecordStoreDemo.Features.Inventory.Products.Commands.CreateInventoryProduct;
using RecordStoreDemo.Features.Inventory.Products.Commands.UpdateProductDetails;
using RecordStoreDemo.Features.Inventory.Products.Commands.UpdateProductOnHand;
using RecordStoreDemo.Features.Inventory.Products.Commands.UpdateProductPrice;

namespace RecordStoreDemo.Features.Inventory.Products;

public class InventoryProductService : IInventoryProductService
{
    private readonly HttpClient _httpClient;

    public InventoryProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;

        _httpClient.BaseAddress = new Uri("https://localhost:7067/api/inventory/");
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    }

    public async Task<ServiceResult<InventoryProductModel>> FindInventoryProductByUPC(string upc)
    {
        var response = await _httpClient.GetAsync($"find/{upc}");
        var result = await ServiceResult<InventoryProductModel>.GetResultAsync(response);

        return result;
    }

    public async Task<ServiceResult<List<InventoryProductModel>>> FindInventoryProducts(ProductQueryRequest request)
    {
        var response = await _httpClient.GetAsync($"find?Artist={request.Artist}&Title={request.Title}&UPC={request.UPC}");
        var result = await ServiceResult<List<InventoryProductModel>>.GetResultAsync(response);

        return result;
    }

    public async Task<ServiceResult<InventoryProductModel>> CreateInventoryProduct(CreateInventoryProductRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("", request);
        var result = await ServiceResult<InventoryProductModel>.GetResultAsync(response);

        return result;
    }

    public async Task<ServiceResult<List<PriceHistoryModel>>> GetProductPriceHistory(Guid id)
    {
        var response = await _httpClient.GetAsync($"price/{id}");
        var result = await ServiceResult<List<PriceHistoryModel>>.GetResultAsync(response);

        return result;
    }

    public async Task<ServiceResult<List<OnHandHistoryModel>>> GetProductOnHandHistory(Guid id)
    {
        var response = await _httpClient.GetAsync($"onhand/{id}");
        var result = await ServiceResult<List<OnHandHistoryModel>>.GetResultAsync(response);

        return result;
    }

    public async Task<ServiceResult<OnHandHistoryModel>> UpdateProductOnHand(UpdateProductOnHandRequest request)
    {
        var response = await _httpClient.PutAsJsonAsync($"onhand", request);
        var result = await ServiceResult<OnHandHistoryModel>.GetResultAsync(response);

        return result;
    }

    public async Task<ServiceResult<PriceHistoryModel>> UpdateProductPrice(UpdateProductPriceRequest request)
    {
        var response = await _httpClient.PutAsJsonAsync($"price", request);
        var result = await ServiceResult<PriceHistoryModel>.GetResultAsync(response);

        return result;
    }

    public async Task<ServiceResult<InventoryProductModel>> UpdateProductDetails(UpdateProductDetailsRequest request)
    {
        var response = await _httpClient.PutAsJsonAsync($"details", request);
        var result = await ServiceResult<InventoryProductModel>.GetResultAsync(response);

        return result;
    }
}