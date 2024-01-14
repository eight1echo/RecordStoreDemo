namespace RecordStoreDemo.Features.Inventory.Products;

public class OnHandHistoryModel
{
    public Guid ProductId { get; set; }
    public string Date { get; set; } = string.Empty;
    public int NewOnHand { get; set; }
    public int QuantityChange { get; set; }
    public string Reason { get; set; } = string.Empty;
}