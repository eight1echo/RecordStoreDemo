namespace RecordStoreDemo.Persistence.Repositories;

public interface IPurchaseOrderRepository : IBaseRepository<PurchaseOrder>
{
    Task<PurchaseOrder> GetPendingPurchaseOrderByProductId(Guid productId);
    Task<PurchaseOrder> GetPendingPurchaseOrderByVendorId(Guid vendorId);
    Task<PurchaseOrder> GetPurchaseOrder(Guid orderId);
}