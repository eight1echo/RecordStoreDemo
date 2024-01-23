using RecordStoreDemo.Features.Customers.Rewards.Commands.AddRewardsTransaction;
using RecordStoreDemo.Features.Customers.Rewards.Commands.AttachRewardsCard;

namespace RecordStoreDemo.Features.Customers.Rewards;

public interface IRewardsCardService
{
    Task<RewardsTransactionModel> AddTransaction(AddRewardsTransactionRequest request);
    Task<RewardsCardModel> AttachRewardsCard(AttachRewardsCardRequest request);
}