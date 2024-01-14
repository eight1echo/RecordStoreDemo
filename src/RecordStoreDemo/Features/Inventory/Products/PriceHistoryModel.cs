namespace RecordStoreDemo.Features.Inventory.Products;

public class PriceHistoryModel
{
    public Guid ProductId { get; set; }
    public string Date { get; set; } = string.Empty;
    public decimal OldPrice { get; set; }
    public decimal NewPrice { get; set; }
    public string Reason { get; set; } = string.Empty;
}