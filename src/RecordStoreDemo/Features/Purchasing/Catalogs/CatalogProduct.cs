namespace RecordStoreDemo.Features.Purchasing.Catalogs;

public class CatalogProduct : BaseEntity
{
    public CatalogProduct(string vendorName, string artist, decimal cost, string description,
                         string format, string label, string sku, DateTime streetDate, string title, string upc)
    {
        VendorName = vendorName;

        Artist = artist;
        Cost = new Price(cost);
        Description = description;
        Format = format;
        Label = label;
        SKU = sku;
        StreetDate = streetDate;
        Title = title;
        UPC = new UPC(upc);
    }

    public Guid VendorId { get; private set; }

    public string VendorName { get; private set; }

    public string Artist { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public Price Cost { get; private set; } = null!;
    public string Format { get; private set; } = null!;
    public string Label { get; private set; } = null!;
    public string SKU { get; private set; } = null!;
    public DateTime StreetDate { get; private set; }
    public string Title { get; private set; } = null!;
    public UPC UPC { get; private set; } = null!;

    public int CartQuantity { get; private set; }
    public int OrderedQuantity { get; private set; }

    /// <summary>
    /// Adjust the quantity currently On Order. To be called upon submition of a PurchaseOrder.
    /// </summary>
    public void AdjustOrderedQuantity(int quantityChange)
    {
        OrderedQuantity += quantityChange;
    }

    /// <summary>
    /// Adjust the quantity currently In Cart. To be called upon addition or deletion of a PurchaseOrderItem.
    /// </summary>
    public void AdjustCartQuantity(int quantityChange)
    {
        CartQuantity += quantityChange;
    }
#nullable disable
    private CatalogProduct() { } // Required by EF Core
}