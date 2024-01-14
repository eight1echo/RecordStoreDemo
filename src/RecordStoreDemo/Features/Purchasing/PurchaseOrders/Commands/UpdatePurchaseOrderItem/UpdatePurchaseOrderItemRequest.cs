namespace RecordStoreDemo.Features.Purchasing.PurchaseOrders.Commands.UpdatePurchaseOrderItem;

public class UpdatePurchaseOrderItemRequest
{
    [Required]
    public Guid VendorId { get; set; }
    [Required]
    public Guid CatalogProductId { get; set; }
    [Required]
    public int NewQuantity { get; set; }
}