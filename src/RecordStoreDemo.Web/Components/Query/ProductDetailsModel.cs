using RecordStoreDemo.Features.Inventory.Products;
using RecordStoreDemo.Features.Purchasing.Catalogs;
using RecordStoreDemo.Features.Webstore.Products;

namespace RecordStoreDemo.Web.Components.Query;
public class ProductDetailsModel
{
    public CatalogProductModel? CatalogProduct { get; set; }
    public InventoryProductModel? InventoryProduct { get; set; }
    public WebstoreProductModel? WebstoreProduct { get; set; }

    public string UPC { get; set; } = string.Empty;
    public bool IsConsignment { get; set; }
}