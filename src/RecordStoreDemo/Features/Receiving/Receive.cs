namespace RecordStoreDemo.Features.Receiving;

public class Receive : BaseEntity
{
    public Receive(Guid vendorId)
    {
        VendorId = vendorId;
        _items = [];
        DateCreated = DateTime.UtcNow;
    }

    public Guid VendorId { get; private set; }

    private readonly List<ReceiveItem> _items;
    public virtual ICollection<ReceiveItem> Items => _items;

    public ReceiveStatus Status { get; private set; }
    public DateTime DateSubmitted { get; private set; }

    public ReceiveItem AddItem(ReceiveItem newItem)
    {
        var existing = GetItem(newItem.InventoryProductId);
        if (existing is null) 
        {
            _items.Add(newItem);
            return newItem;
        }
        else
        {
            existing.AdjustQuantity(newItem.Quantity);
            return existing;
        }        
    }

    public ReceiveItem UpdateItem(Guid inventoryProductId, int newQuantity)
    {
        var item = GetItem(inventoryProductId)
            ?? throw new InvalidOperationException($"Receive has no ReceiveItem with InventoryProductId: {inventoryProductId}.");

        var difference = newQuantity - item.Quantity;
        item.AdjustQuantity(difference);

        return item;
    }

    public void RemoveItem(Guid inventoryProductId)
    {
        var item = GetItem(inventoryProductId)
            ?? throw new InvalidOperationException($"Receive has no ReceiveItem with InventoryProductId: {inventoryProductId}.");

        _items.Remove(item);
    }

    public void Submit()
    {
        if (Status != ReceiveStatus.Pending)
            throw new InvalidOperationException("Receive has already been submitted.");

        if (_items.Count == 0)
            throw new InvalidOperationException("Receive has no items.");

        foreach (var item in _items)
        {
            item.InventoryProduct.OnHandAdjustment(item.Quantity, $"Received on {DateTime.Now.ToShortDateString()}");
            item.CatalogProduct.AdjustOrderedQuantity(-item.Quantity);
        }

        Status = ReceiveStatus.Submitted;
        DateSubmitted = DateTime.Now;
    }

    private ReceiveItem? GetItem(Guid inventoryProductId)
    {
        var item = _items.FirstOrDefault(i => i.InventoryProductId == inventoryProductId);

        return item;
    }
}