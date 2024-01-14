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

    public async Task<InventoryProductModel?> FindInventoryProductByUPC(string upc)
    {
        var response = await _httpClient.GetAsync($"find/{upc}");

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<InventoryProductModel>();

            return result;
        }

        return null;
    }

    public async Task<List<InventoryProductModel>> FindInventoryProducts(ProductQueryRequest request)
    {
        var response = await _httpClient.GetFromJsonAsync<List<InventoryProductModel>>($"find?Artist={request.Artist}&Title={request.Title}&UPC={request.UPC}");

        if (response is not null)
        {
            return response;
        }
        else
            // TODO: Handle possible HttpClient errors.
            throw new Exception();
    }

    public async Task<InventoryProductModel> CreateInventoryProduct(CreateInventoryProductRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("", request);

        var product = await response.Content.ReadFromJsonAsync<InventoryProductModel>();

        // TODO: Handle possible HttpClient errors.
        return product ?? throw new Exception();
    }

    public async Task<List<PriceHistoryModel>> GetProductPriceHistory(Guid id)
    {
        var response = await _httpClient.GetFromJsonAsync<List<PriceHistoryModel>>($"{id}/price");

        if (response is not null)
        {
            return response;
        }
        else
            // TODO: Handle possible HttpClient errors.
            throw new Exception();
    }

    public async Task<List<OnHandHistoryModel>> GetProductOnHandHistory(Guid id)
    {
        var response = await _httpClient.GetFromJsonAsync<List<OnHandHistoryModel>>($"{id}/onhand/");

        if (response is not null)
        {
            return response;
        }
        else
            // TODO: Handle possible HttpClient errors.
            throw new Exception();
    }

    public async Task<OnHandHistoryModel> UpdateProductOnHand(UpdateProductOnHandRequest request)
    {
        var response = await _httpClient.PutAsJsonAsync($"{request.ProductId}/onhand", request);

        var result = await response.Content.ReadFromJsonAsync<OnHandHistoryModel>();

        if (result is not null)
        {
            return result;
        }
        else
            // TODO: Handle possible HttpClient errors.
            throw new Exception();
    }

    public async Task<PriceHistoryModel> UpdateProductPrice(UpdateProductPriceRequest request)
    {
        var response = await _httpClient.PutAsJsonAsync($"{request.ProductId}/price", request);

        var result = await response.Content.ReadFromJsonAsync<PriceHistoryModel>();

        if (result is not null)
        {
            return result;
        }
        else
            // TODO: Handle possible HttpClient errors.
            throw new Exception();
    }

    public async Task UpdateProductDetails(UpdateProductDetailsRequest request)
    {
        var response = await _httpClient.PutAsJsonAsync($"{request.InventoryProductId}", request);
        response.EnsureSuccessStatusCode();
    }
}