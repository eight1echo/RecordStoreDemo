namespace RecordStoreDemo.Features.Purchasing.PurchaseOrders;
public class PurchaseOrderModel
{
    public Guid VendorId { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateSubmitted { get; set; }
    public int TotalItems { get; set; }
    public decimal TotalCost { get; set; }
    public List<PurchaseOrderItemModel> Items { get; set; } = [];
}