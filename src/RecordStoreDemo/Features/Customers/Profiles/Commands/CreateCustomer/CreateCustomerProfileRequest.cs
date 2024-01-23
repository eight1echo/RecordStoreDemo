namespace RecordStoreDemo.Features.Customers.Profiles.Commands.CreateCustomer;
public class CreateCustomerProfileRequest
{
    [Required]
    [Length(2, 40)]
    public string Name { get; set; } = null!;

    [Required]
    [EmailOrPhoneNumber]
    public string Contact { get; set; } = null!;
}