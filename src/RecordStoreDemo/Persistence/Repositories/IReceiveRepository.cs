
namespace RecordStoreDemo.Persistence.Repositories;

public interface IReceiveRepository : IBaseRepository<Receive>
{
    Task<Receive> GetPendingReceiveByProductId(Guid productId);
    Task<Receive> GetPendingReceiveByVendorId(Guid vendorId);
    Task<Receive> GetReceive(Guid receiveId);
}