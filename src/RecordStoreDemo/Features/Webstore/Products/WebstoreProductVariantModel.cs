namespace RecordStoreDemo.Features.Webstore.Products;
public class WebstoreProductVariantModel
{
    public long Id { get; set; }
    public string Barcode { get; set; } = string.Empty;
    public long? InventoryItemId { get; set; }
    public decimal Price { get; set; }
    public string SKU { get; set; } = string.Empty;
    public decimal Weight { get; set; }
}