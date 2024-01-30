using RecordStoreDemo.Features.Customers.Rewards.Commands.AddRewardsTransaction;
using RecordStoreDemo.Features.Customers.Rewards.Commands.AttachRewardsCard;

namespace RecordStoreDemo.Features.Customers.Rewards;

public interface IRewardsCardService
{
    Task<ServiceResult<RewardsTransactionModel>> AddTransaction(AddRewardsTransactionRequest request);
    Task<ServiceResult<RewardsCardModel>> AttachRewardsCard(AttachRewardsCardRequest request);
}