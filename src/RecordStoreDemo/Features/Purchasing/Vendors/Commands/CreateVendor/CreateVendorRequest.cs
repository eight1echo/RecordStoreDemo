namespace RecordStoreDemo.Features.Purchasing.Vendors.Commands.CreateVendor;
public class CreateVendorRequest
{
    [Required]
    [Length(2, 40)]
    public string Name { get; set; } = string.Empty;
}