namespace RecordStoreDemo.Features.Purchasing.PurchaseOrders.Commands.UpdatePurchaseOrder;

public class UpdatePurchaseOrderRequest
{
    [Required]
    public Guid VendorId { get; set; }

    public List<PurchaseOrderItemModel> Items { get; set; } = [];
}