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

    public async Task<ServiceResult<ReceiveItemModel>> AddItemToReceive(AddItemToReceiveRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("items", request);
        var result = await ServiceResult<ReceiveItemModel>.GetResultAsync(response);

        return result;
    }

    public async Task<ServiceResult<ReceiveModel>> CreateReceive(CreateReceiveRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("", request);
        var result = await ServiceResult<ReceiveModel>.GetResultAsync(response);

        return result;
    }

    public async Task<ServiceResult<AddItemToReceiveRequest>> GetItemToReceive(GetItemToReceiveRequest request)
    {
        var response = await _httpClient.GetAsync($"items/{request.UPC}");
        var result = await ServiceResult<AddItemToReceiveRequest>.GetResultAsync(response);

        return result;
    }

    public async Task<ServiceResult<ReceiveModel>> GetPendingReceive(Guid vendorId)
    {
        var response = await _httpClient.GetAsync($"{vendorId}");
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return await CreateReceive(new CreateReceiveRequest { VendorId = vendorId });
        }
        else return await ServiceResult<ReceiveModel>.GetResultAsync(response);
    }

    // TODO: ServiceResult for Tasks when nothing is returned.
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