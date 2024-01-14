namespace RecordStoreDemo.Features.Receiving;

public class ReceiveItem : BaseEntity
{
    public ReceiveItem(Guid receiveId, Guid productId, Guid catalogProductId, int quantity)
    {
        ReceiveId = receiveId;
        CatalogProductId = catalogProductId;
        InventoryProductId = productId;
        Quantity = quantity;
    }

    public Guid ReceiveId { get; private set; }

    public Guid CatalogProductId { get; private set; }
    public virtual CatalogProduct CatalogProduct { get; set; } = null!;

    public Guid InventoryProductId { get; private set; }
    public virtual InventoryProduct InventoryProduct { get; set; } = null!;

    public int Quantity { get; private set; }

    public void AdjustQuantity(int quantityChange)
    {
        Quantity += quantityChange;

        if (Quantity < 0) 
            throw new InventoryQuantityException(InventoryProductId);
    }

    private ReceiveItem() { }
}