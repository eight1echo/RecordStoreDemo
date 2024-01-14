namespace RecordStoreDemo.Features.Inventory.Products;

public class OnHandChange : BaseEntity
{
    public OnHandChange(Guid productId, int currentOnHand, int quantityChange, string reason)
    {
        ProductId = productId;
        NewOnHand = currentOnHand + quantityChange;
        QuantityChange = quantityChange;
        Reason = reason;
    }
    public Guid ProductId { get; private set; }
    public int NewOnHand { get; private set; }
    public int QuantityChange { get; private set; }
    public string Reason { get; private set; }
#nullable disable
    private OnHandChange() { }
}