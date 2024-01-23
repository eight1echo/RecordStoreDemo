namespace RecordStoreDemo.Features.Customers.Profiles.Queries.GetCustomerDetails;
public class CustomerDetailsModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Contact { get; set; } = string.Empty;
    public RewardsCardModel RewardsCard { get; set; } = new();
    public List<SpecialOrderModel> SpecialOrders { get; set; } = new();
}