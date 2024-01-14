namespace RecordStoreDemo.Features.Inventory.Products;

public class PriceChange : BaseEntity
{
    public PriceChange(Guid productId, Price oldPrice, Price newPrice, string? reason)
    {
        ProductId = productId;
        OldPrice = oldPrice;
        NewPrice = newPrice;
        Reason = reason ?? string.Empty;
    }
    public Guid ProductId { get; set; }
    public Price OldPrice { get; private set; }
    public Price NewPrice { get; private set; }
    public string Reason { get; private set; }
#nullable disable
    private PriceChange() { }
}