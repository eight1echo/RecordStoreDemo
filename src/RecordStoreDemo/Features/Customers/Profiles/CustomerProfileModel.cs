namespace RecordStoreDemo.Features.Customers.Profiles;
public class CustomerProfileModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Contact { get; set; } = string.Empty;
}