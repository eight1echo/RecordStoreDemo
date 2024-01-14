namespace RecordStoreDemo.Features.Purchasing.PurchaseOrders;
public class PurchaseOrderItemModel
{
    public Guid PurchaseOrderId { get; set; }

    public Guid CatalogProductId { get; set; }
    public CatalogProductModel Product { get; set; } = new CatalogProductModel();

    public int Quantity { get; set; }
}