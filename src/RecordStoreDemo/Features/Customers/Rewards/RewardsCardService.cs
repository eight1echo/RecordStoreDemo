using RecordStoreDemo.Features.Customers.Rewards.Commands.AddRewardsTransaction;
using RecordStoreDemo.Features.Customers.Rewards.Commands.AttachRewardsCard;

namespace RecordStoreDemo.Features.Customers.Rewards;
public class RewardsCardService : IRewardsCardService
{
    private readonly HttpClient _httpClient;

    public RewardsCardService(HttpClient httpClient)
    {
        _httpClient = httpClient;

        _httpClient.BaseAddress = new Uri("https://localhost:7067/api/customers/rewards/");
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    }
    public async Task<ServiceResult<RewardsTransactionModel>> AddTransaction(AddRewardsTransactionRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync($"", request);
        var result = await ServiceResult<RewardsTransactionModel>.GetResultAsync(response);

        return result;
    }
    public async Task<ServiceResult<RewardsCardModel>> AttachRewardsCard(AttachRewardsCardRequest request)
    {
        var response = await _httpClient.PutAsJsonAsync($"", request);
        var result = await ServiceResult<RewardsCardModel>.GetResultAsync(response);

        return result;
    }
}