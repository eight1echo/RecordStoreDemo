using RecordStoreDemo.Features.Purchasing.PurchaseOrders.Commands.UpdatePurchaseOrder;
using RecordStoreDemo.Features.Purchasing.PurchaseOrders.Commands.UpdatePurchaseOrderItem;

namespace RecordStoreDemo.Features.Purchasing.PurchaseOrders;

public interface IPurchaseOrderService
{
    Task DeleteItem(Guid catalogProductId);
    Task SubmitOrder(Guid vendorId);
    Task UpdateItem(UpdatePurchaseOrderItemRequest request);
    Task UpdateOrder(UpdatePurchaseOrderRequest request);
}