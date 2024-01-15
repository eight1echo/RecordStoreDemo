using RecordStoreDemo.Features.Receiving.Commands.AddItemToReceive;
using RecordStoreDemo.Features.Receiving.Commands.CreateReceive;
using RecordStoreDemo.Features.Receiving.Commands.UpdateReceiveItem;
using RecordStoreDemo.Features.Receiving.Queries.GetItemToReceive;

namespace RecordStoreDemo.Features.Receiving;

public class ReceiveService : IReceiveService
{
    private readonly HttpClient _httpClient;

    public ReceiveService(HttpClient httpClient)
    {
        _httpClient = httpClient;

        _httpClient.BaseAddress = new Uri("https://localhost:7067/api/receiving/");
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    }

    public async Task<ReceiveItemModel> AddItemToReceive(AddItemToReceiveRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("items", request);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<ReceiveItemModel>()
                ?? throw new Exception();

            return result;
        }
        else
            // TODO: Error Handling
            throw new Exception();
    }

    public async Task<ReceiveModel> CreateReceive(CreateReceiveRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("", request);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<ReceiveModel>()
                ?? throw new Exception();

            return result;
        }
        else
            // TODO: Error Handling
            throw new Exception();
    }

    public async Task<AddItemToReceiveRequest> GetItemToReceive(GetItemToReceiveRequest request)
    {
        var response = await _httpClient.GetAsync($"items/{request.UPC}");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<AddItemToReceiveRequest>()
                ?? throw new Exception();

            return result;
        }
        else
            // TODO: Error Handling
            throw new Exception();
    }

    public async Task<ReceiveModel> GetPendingReceive(Guid vendorId)
    {
        var response = await _httpClient.GetAsync($"{vendorId}");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<ReceiveModel>()
                ?? throw new Exception();

            return result;
        }
        else if (response.StatusCode == HttpStatusCode.NotFound)
        {
            var result = await CreateReceive(new CreateReceiveRequest { VendorId = vendorId });
            return result;
        }
        else
            // TODO: Error Handling
            throw new Exception();
    }

    public async Task SubmitReceive(Guid vendorId)
    {
        var response = await _httpClient.PostAsync($"submit/{vendorId}", null);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateReceiveItem(UpdateReceiveItemRequest request)
    {
        var response = await _httpClient.PutAsJsonAsync($"items", request);
        response.EnsureSuccessStatusCode();
    }
}