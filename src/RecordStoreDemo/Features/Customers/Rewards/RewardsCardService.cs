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
    public async Task<RewardsTransactionModel> AddTransaction(AddRewardsTransactionRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync($"", request);

        var result = await response.Content.ReadFromJsonAsync<RewardsTransactionModel>();

        if (result is not null)
        {
            return result;
        }
        else
            // TODO: Handle possible HttpClient errors.
            throw new Exception();
    }
    public async Task<RewardsCardModel> AttachRewardsCard(AttachRewardsCardRequest request)
    {
        var response = await _httpClient.PutAsJsonAsync($"", request);

        var result = await response.Content.ReadFromJsonAsync<RewardsCardModel>();

        if (result is not null)
        {
            return result;
        }
        else
            // TODO: Handle possible HttpClient errors.
            throw new Exception();
    }
}