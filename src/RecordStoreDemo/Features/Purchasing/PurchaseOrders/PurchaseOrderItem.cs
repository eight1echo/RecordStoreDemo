namespace RecordStoreDemo.Features.Purchasing.PurchaseOrders;

public class PurchaseOrderItem : BaseEntity
{
    public PurchaseOrderItem(CatalogProduct catalogProduct, int quantity)
    {
        CatalogProductId = catalogProduct.Id;
        CatalogProduct = catalogProduct;
        Quantity = quantity;
    }

    public Guid PurchaseOrderId { get; private set; }

    public Guid CatalogProductId { get; private set; }
    public virtual CatalogProduct CatalogProduct { get; set; } = null!;

    public int Quantity { get; private set; }

    public void UpdateQuantity(int quantityChange)
    {
        CatalogProduct.AdjustCartQuantity(quantityChange);
        Quantity += quantityChange;
    }
#nullable disable
    private PurchaseOrderItem() { }
}