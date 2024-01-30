using RecordStoreDemo.Features.Receiving.Commands.AddItemToReceive;
using RecordStoreDemo.Features.Receiving.Commands.UpdateReceiveItem;
using RecordStoreDemo.Features.Receiving.Commands.CreateReceive;
using RecordStoreDemo.Features.Receiving.Queries.GetItemToReceive;

namespace RecordStoreDemo.Features.Receiving;

public interface IReceiveService
{
    Task<ServiceResult<ReceiveItemModel>> AddItemToReceive(AddItemToReceiveRequest request);
    Task<ServiceResult<ReceiveModel>> CreateReceive(CreateReceiveRequest request);
    Task<ServiceResult<AddItemToReceiveRequest>> GetItemToReceive(GetItemToReceiveRequest request);
    Task<ServiceResult<ReceiveModel>> GetPendingReceive(Guid vendorId);
    Task SubmitReceive(Guid vendorId);
    Task UpdateReceiveItem(UpdateReceiveItemRequest request);
}