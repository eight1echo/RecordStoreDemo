using RecordStoreDemo.Features.Receiving.Commands.AddItemToReceive;
using RecordStoreDemo.Features.Receiving.Commands.UpdateReceiveItem;
using RecordStoreDemo.Features.Receiving.Commands.CreateReceive;

namespace RecordStoreDemo.Features.Receiving;

public interface IReceiveService
{
    Task<ReceiveItemModel> AddItemToReceive(AddItemToReceiveRequest request);
    Task<ReceiveModel> CreateReceive(CreateReceiveRequest request);
    Task<AddItemToReceiveRequest> GetItemToReceive(string upc);
    Task<ReceiveModel> GetPendingReceive(Guid vendorId);
    Task SubmitReceive(Guid vendorId);
    Task UpdateReceiveItem(UpdateReceiveItemRequest request);
}