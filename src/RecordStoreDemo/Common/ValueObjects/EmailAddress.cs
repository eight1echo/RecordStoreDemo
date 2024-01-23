namespace RecordStoreDemo.Common.ValueObjects;

public class EmailAddress : BaseValueObject
{
    public EmailAddress(string value)
    {
        Address = Guard.Against.InvalidEmail(value, nameof(value));
    }

    public string Address { get; set; } = null!;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Address;
    }

    private EmailAddress() { } // Required for EF
}