namespace RecordStoreDemo.Features.Purchasing.Catalogs;
public class CatalogProductModel
{
    public Guid Id { get; set; }
    public Guid VendorId { get; set; }
    public string VendorName { get; set; } = string.Empty;

    public string Artist { get; set; } = string.Empty;
    public decimal Cost { get; set; }
    public string Format { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
    public string SKU { get; set; } = string.Empty;
    public string StreetDate { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string UPC { get; set; } = string.Empty;

    public int CartQuantity { get; set; }
    public int OrderedQuantity { get; set; }
}