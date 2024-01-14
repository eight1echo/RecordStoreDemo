namespace RecordStoreDemo.Features.Purchasing.PurchaseOrders;

public class PurchaseOrder : BaseEntity
{
    public PurchaseOrder(Guid vendorId)
    {
        VendorId = vendorId;
        _items = [];
        Status = PurchaseOrderStatus.Pending;
        Total = 0.0m;
        DateCreated = DateTime.UtcNow;
    }

    public Guid VendorId { get; private set; }
    public virtual Vendor Vendor { get; set; } = null!;
    public decimal Total { get; private set; }

    private readonly List<PurchaseOrderItem> _items;
    public virtual ICollection<PurchaseOrderItem> Items => _items.OrderBy(i => i.CatalogProduct.Artist).ToList();

    public PurchaseOrderStatus Status { get; private set; }
    public DateTime DateSubmitted { get; private set; }

    public PurchaseOrderItem AddItem(CatalogProduct product, int quantity)
    {
        var item = new PurchaseOrderItem(product, quantity);
        _items.Add(item);
        item.CatalogProduct.AdjustCartQuantity(item.Quantity);
        UpdateTotal(product.Cost, item.Quantity);

        return item;
    }
    
    public void RemoveItem(Guid catalogProductId)
    {
        var item = GetItem(catalogProductId);

        _items.Remove(item);
        item.CatalogProduct.AdjustCartQuantity(-item.Quantity);
        UpdateTotal(item.CatalogProduct.Cost, -item.Quantity);
    }
    public PurchaseOrderItem UpdateItem(Guid catalogProductId, int newQuantity)
    {
        var item = GetItem(catalogProductId);

        var difference = newQuantity - item.Quantity;
        item.UpdateQuantity(difference);
        UpdateTotal(item.CatalogProduct.Cost, difference);

        return item;
    }    

    public void Submit()
    {
        if (Status != PurchaseOrderStatus.Pending)
            throw new InvalidOperationException("Order has already been submitted.");

        if (_items.Count == 0)
            throw new InvalidOperationException("Order has no items.");

        foreach (var item in _items)
        {

            item.CatalogProduct.AdjustCartQuantity(-item.Quantity);

            item.CatalogProduct.AdjustOrderedQuantity(item.Quantity);
        }

        Status = PurchaseOrderStatus.Submitted;
        DateSubmitted = DateTime.UtcNow;
    }

    private PurchaseOrderItem GetItem(Guid catalogProductId)
    {
        var item = _items
            .Where(x => x.CatalogProductId == catalogProductId)
            .FirstOrDefault()
            ?? throw new EntityNotFoundException(catalogProductId);        

        return item;
    }

    private void UpdateTotal(Price cost, int quantity)
    {
        Total += cost.Value * quantity;
    }
}