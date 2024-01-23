namespace RecordStoreDemo.Features.Customers.SpecialOrders.Commands.CreateSpecialOrder;
public class CreateSpecialOrderRequest
{
    public Guid CustomerProfileId { get; set; }
    public Guid InventoryProductId { get; set; }
    public int Quantity { get; set; } = 1;
}