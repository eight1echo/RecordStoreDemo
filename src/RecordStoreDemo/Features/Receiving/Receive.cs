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

    /// <summary>
    /// Adds a new ReceiveItem to the Receive or increases the quantity of an existing Item.
    /// </summary>
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

    /// <summary>
    /// Updates a ReceiveItem in the Receive with a new quantity.
    /// </summary>
    public ReceiveItem UpdateItem(Guid inventoryProductId, int newQuantity)
    {
        var item = GetItem(inventoryProductId)
            ?? throw new InvalidOperationException($"Receive has no ReceiveItem with InventoryProductId: {inventoryProductId}.");

        var difference = newQuantity - item.Quantity;
        item.AdjustQuantity(difference);

        return item;
    }

    /// <summary>
    /// Removes a ReceiveItem from the Receive.
    /// </summary>
    public void RemoveItem(Guid inventoryProductId)
    {
        var item = GetItem(inventoryProductId)
            ?? throw new InvalidOperationException($"Receive has no ReceiveItem with InventoryProductId: {inventoryProductId}.");

        _items.Remove(item);
    }

    /// <summary>
    /// Submit a Receive. 
    /// Products included in the order will have their OnHand increased and their OrderedQuantity reduced by the respective quantities.
    /// </summary>
    public void Submit()
    {
        if (Status != ReceiveStatus.Pending)
            throw new InvalidOperationException("Receive has already been submitted.");

        if (_items.Count == 0)
            throw new InvalidOperationException("Receive has no items.");

        foreach (var item in _items)
        {
            // Update quantities.
            item.InventoryProduct.OnHandAdjustment(item.Quantity, $"Received on {DateTime.Now.ToShortDateString()}");
            item.CatalogProduct.AdjustOrderedQuantity(-item.Quantity);

            // Check if any SpecialOrders for the Product.
            var specialOrders = item.InventoryProduct.SpecialOrders.Where(so => so.Status == SpecialOrderStatus.Ordered).ToList();

            if (specialOrders.Count > 0)
            {
                var receivedQuantity = item.Quantity;

                foreach (var order in specialOrders)
                {
                    if (receivedQuantity == 0)                    
                        break;
                    
                    order.ReceiveOrder();
                    receivedQuantity -= 1;
                }
            }
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