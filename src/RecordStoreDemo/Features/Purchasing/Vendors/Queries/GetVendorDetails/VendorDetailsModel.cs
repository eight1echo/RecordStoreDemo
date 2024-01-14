namespace RecordStoreDemo.Features.Purchasing.Vendors.Queries.GetVendorDetails;

public class VendorDetailsModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public CatalogModel Catalog { get; set; } = new();
    public PurchaseOrderModel? PendingOrder { get; set; }
    public List<PurchaseOrderModel> PastOrders { get; set; } = new();
}