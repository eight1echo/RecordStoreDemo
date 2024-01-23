namespace RecordStoreDemo.Features.Customers.SpecialOrders;
public class SpecialOrder : BaseEntity
{
    public SpecialOrder(Guid customerProfileId, Guid inventoryProductId)
    {
        CustomerProfileId = customerProfileId;
        InventoryProductId = inventoryProductId;
        DateOrdered = DateTime.Now;
        Status = SpecialOrderStatus.Ordered;
    }
    public Guid CustomerProfileId { get; private set; }
    public virtual CustomerProfile CustomerProfile { get; set; } = null!;

    public Guid InventoryProductId { get; private set; }
    public virtual InventoryProduct Product { get; set; } = null!;

    public DateTime DateOrdered { get; private set; }
    public DateTime DateReceived { get; private set; }
    public bool Contacted { get; private set; }
    public SpecialOrderStatus Status { get; private set; }

    public void CompleteOrder()
    {
        Status = SpecialOrderStatus.Complete;
    }
    public void ContactCustomer()
    {
        Contacted = true;
        Status = SpecialOrderStatus.Contacted;
    }
    public void ReceiveOrder()
    {
        DateReceived = DateTime.Now;
        Status = SpecialOrderStatus.Received;
    }
}