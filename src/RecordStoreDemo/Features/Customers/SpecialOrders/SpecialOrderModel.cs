namespace RecordStoreDemo.Features.Customers.SpecialOrders;
public class SpecialOrderModel
{
    public Guid Id { get; set; }
    public virtual CustomerProfileModel CustomerProfile { get; set; } = null!;
    public string Product { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string UPC { get; set; } = string.Empty;
    public DateTime DateOrdered { get; set; }
    public DateTime DateReceived { get; set; }
    public bool Contacted { get; set; }
    public SpecialOrderStatus Status { get; set; }
}