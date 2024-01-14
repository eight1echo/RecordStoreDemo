namespace RecordStoreDemo.Features.Inventory.Products;

public class InventoryProductModel()
{
    public Guid Id { get; set; }
    public Guid CatalogProductId { get; set; }

    public string Artist { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string Format { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public int OnHand { get; set; }
    public decimal Price { get; set; }
    public DateTime StreetDate { get; set; }
    public string Title { get; set; } = string.Empty;
    public string UPC { get; set; } = string.Empty;

    public List<OnHandHistoryModel> OnHandHistory { get; set; } = [];
    public List<PriceHistoryModel> PriceHistory { get; set; } = [];
}